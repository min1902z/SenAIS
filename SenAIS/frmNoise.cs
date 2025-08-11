using SenAIS.Logger;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmNoise : Form
    {
        private COMConnect comConnect;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal noiseValue = 0;
        public decimal maxNoise;
        private bool isMeasuring = false;
        public frmNoise(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            comConnect = new COMConnect(ConfigurationManager.AppSettings["COM_Noise"], 300, this);
            sqlHelper = new SQLHelper();
        }
        private async Task StartMeasurementProcess()
        {
            int measurementDelay;
            // Đọc thời gian từ App.config, nếu không có thì mặc định là 10 giây
            if (!int.TryParse(ConfigurationManager.AppSettings["NoiseMeasurementDelay"], out measurementDelay))
            {
                measurementDelay = 10; // Mặc định nếu không tìm thấy key
            }
            lbNoiseTitle.Text = "Độ Ồn";
            await Task.Delay(3000); // Quãng nghỉ 3 giây trước khi bắt đầu đo

            lbNoiseTitle.Text = "Chuẩn bị quá trình đo...";
            await Task.Delay(5000);

            lbNoise.Visible = true;
            isMeasuring = true;
            byte[] startCommand = { 0xB8 };
            await Task.Run(() => comConnect.SendRequest(startCommand)); // COM chạy thread phụ
            lbEnd.Visible = true;
            lbEnd.Text = "Bắt đầu";
            for (int countdown = measurementDelay; countdown >= 0; countdown--)
            {
                lbEnd.Text = $"Giá trị sẽ lấy sau {countdown}s...";
                await Task.Delay(1000); // Chờ 1 giây
            }

            isMeasuring = false;
            lbEnd.Text = "Kết thúc";
            await Task.Run(() => SaveDataToDatabase()); // DB chạy thread phụ
            await Task.Delay(2000);
            NextVin();
        }
        private void NextVin()
        {
            string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);

            if (!(Application.OpenForms.OfType<frmInspection>().FirstOrDefault() is frmInspection frmMain))
                return;

            if (!(frmMain.Controls.Find("txtVinNum", true).FirstOrDefault() is TextBox txtVinNum))
                return;

            if (!string.IsNullOrEmpty(nextSerialNumber))
            {
                this.serialNumber = nextSerialNumber;
                lbVinNumber.Text = this.serialNumber;

                txtVinNum.Text = this.serialNumber;
                frmMain.UpdateVehicleInfo(nextSerialNumber);
            }
            else
            {
                txtVinNum.Text = string.Empty;
            }
            this.Close();
        }
        private void ResetToDefault()
        {
            lbNoise.Visible = false;
            lbNoise.Text = "0.0";
            lbEnd.Visible = false;
        }
        private decimal ConvertToDecimal(object value)
        {
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }
        private async Task LoadVehicleStandards(string serialNumber)
        {
            lbVinNumber.Text = this.serialNumber;
            var vehicleDetails = await Task.Run(() => sqlHelper.GetVehicleDetails(serialNumber));
            if (vehicleDetails != null)
            {
                string vehicleType = vehicleDetails["VehicleType"].ToString();
                var vehicleStandards = await Task.Run(() => sqlHelper.GetVehicleStandardsByTypeCar(vehicleType));
                if (vehicleStandards.Rows.Count > 0)
                {
                    DataRow standard = vehicleStandards.Rows[0];
                    maxNoise = ConvertToDecimal(standard["MaxNoise"]);
                    lbStandard.Text = (maxNoise > 0) ? $"≤ {maxNoise.ToString("F1")}" : "--";
                }
            }
        }
        private async void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy SerialNumber trước đó
                string previousSerialNumber = sqlHelper.GetPreviousSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(previousSerialNumber))
                {
                    // Cập nhật serialNumber mới
                    this.serialNumber = previousSerialNumber;
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    await LoadVehicleStandards(serialNumber);
                }
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private async void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    await LoadVehicleStandards(serialNumber);
                }
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private void SaveDataToDatabase()
        {
            try
            {
                sqlHelper.SaveNoiseData(serialNumber, noiseValue);
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        public void ProcessNoiseData(byte[] data)
        {
            try
            {
                if (data[0] == 0x01) // Check start and end byte
                {
                    // Extract sound level data (5 bytes in ASCII)
                    string soundLevelString = Encoding.ASCII.GetString(data, 1, 5);

                    if (double.TryParse(soundLevelString, out double soundLevel))
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            if (isMeasuring) // Chỉ cập nhật UI nếu còn trong quá trình đo
                            {
                                lbNoise.Text = soundLevel.ToString("F1");
                                this.noiseValue = Convert.ToDecimal(lbNoise.Text);
                                bool isValueInStandard = maxNoise == 0 || noiseValue <= maxNoise;
                                lbNoise.ForeColor = isValueInStandard ? SystemColors.HotTrack : Color.DarkRed;
                            }
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private async  void frmNoise_Load(object sender, EventArgs e)
        {
            try
            {
                lbVinNumber.Text = this.serialNumber;
                await LoadVehicleStandards(serialNumber);
                bool connected = await Task.Run(() =>
                {
                    comConnect.OpenConnection();
                    return comConnect.IsConnected();
                });

                cbReady.BackColor = connected ? Color.Green : SystemColors.Control;

                if (connected)
                    await StartMeasurementProcess();
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private void frmNoise_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                comConnect?.CloseConnection();
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }

        private async void btnReMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                ResetToDefault();
                await StartMeasurementProcess();
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            NextVin();
        }
    }
}
