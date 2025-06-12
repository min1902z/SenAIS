using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmDieselEmission : Form
    {
        private SQLHelper sqlHelper;
        private COMConnect comConnect;
        private string serialNumber;
        private decimal minSpeed1;
        private decimal minSpeed2;
        private decimal minSpeed3;
        private decimal maxSpeed1;
        private decimal maxSpeed2;
        private decimal maxSpeed3;
        private decimal hsu1;
        private decimal hsu2;
        private decimal hsu3;
        private decimal avgHsu;
        private decimal maxHsu;
        private decimal lastRpm;
        private decimal lastMaxSpeed;
        private decimal opacity;
        private decimal lightAbsorption;
        private string oilTemperature;
        private int currentDataRequest = 1;        // Keep track of the current request count
        private CancellationTokenSource cts; // Quản lý hủy bỏ task
        private static readonly string comDieselEmission = ConfigurationManager.AppSettings["COM_DieselEmission"];

        public frmDieselEmission(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            comConnect = new COMConnect(comDieselEmission, 9600, this);
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
        }
        private async Task StartDieselEmissionProcess(CancellationToken cancellationToken)
        {
            try
            {
                // Trạng thái 1: Hiển thị tiêu đề và chờ 2 giây
                UpdateTitle("Khí Xả - Động Cơ Diesel");
                await Task.Delay(3000, cancellationToken);
                int probeSetupTime = int.Parse(ConfigurationManager.AppSettings["ProbeSetupTime"] ?? "10") * 1000;
                int throttleDuration = int.Parse(ConfigurationManager.AppSettings["ThrottleDuration"] ?? "5"); // Số giây đạp ga
                int restDuration = int.Parse(ConfigurationManager.AppSettings["RestDuration"] ?? "5"); // Thời gian nghỉ giữa các lần đo

                // Trạng thái 2: Chờ 30 giây chuẩn bị đầu dò
                UpdateTitle("Trang bị đầu dò");
                await Task.Delay(probeSetupTime, cancellationToken);

                lbNotice.Visible = true;
                lbNotice.Text = "Chuẩn bị đạp ga 3 lần.";
                byte[] commandA7 = { 0xA7, CalculateCheckCode(0xA7) };
                comConnect.SendRequest(commandA7);
                await Task.Delay(5000, cancellationToken);

                // Trạng thái 3: Hướng dẫn đo và đo 3 lần
                tbEmission.Visible = true;
                currentDataRequest = 1;

                byte[] commandA5 = { 0xA5, 0xB5 };
                comConnect.SendRequest(commandA5);
                while (currentDataRequest <= 3)
                {
                    for (int countdown = throttleDuration; countdown >= 0; countdown--)
                    {
                        lbNotice.Text = $"Đạp ga lần {currentDataRequest}. Thực hiện trong {countdown} giây...";
                        await Task.Delay(1000, cancellationToken);
                    }

                    // 🔹 Đếm ngược 3 giây
                    for (int countdown = 3; countdown > 0; countdown--)
                    {
                        lbNotice.Text = $"Giữ nguyên, đo kết quả trong {countdown} giây...";
                        await Task.Delay(1000, cancellationToken);

                        if (countdown == 1)
                        {
                            ConfirmMeasurement();
                        }
                    }
                    if (currentDataRequest < 3)
                    {
                        for (int restCount = restDuration; restCount > 0; restCount--)
                        {
                            lbNotice.Text = $"Chờ {restCount} giây trước lần tiếp theo...";
                            await Task.Delay(1000, cancellationToken);
                        }
                    }
                    currentDataRequest++;
                }

                // Trạng thái 4: Kết thúc đo, lưu kết quả
                if (currentDataRequest > 3)
                {
                    CalculateAverages();
                    SaveDataToDatabase();
                    lbNotice.Text = "Quá trình lưu dữ liệu hoàn tất.";
                    await Task.Delay(3000, cancellationToken);
                    NextVin();
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Quá trình đo đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình đo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                frmMain.UpdateVehicleInfo(this.serialNumber);
            }
            else
            {
                txtVinNum.Text = string.Empty;
            }
            this.Close();
        }
        public void ProcessNHT6Data(byte[] data)
        {
            if (data[0] == 0xA5)
            {
                opacity = ((data[1] << 8) + data[2]) / 10.0m; // Opacity chia 10
                lightAbsorption = ((data[3] << 8) + data[4]) / 100.0m; // Light absorption chia 100
                lastRpm = (data[5] << 8) + data[6]; // Lưu tạm tốc độ
                int oilTempRaw = (data[7] << 8) + data[8];
                oilTemperature = (oilTempRaw == 0xFFFF) ? "--" : oilTempRaw.ToString();
            }
        }
        public void ProcessNHT6MaxData(byte[] data)
        {
            if (data[0] == 0xA6)
            {
                lastMaxSpeed = (data[5] << 8) + data[6]; // Lưu tạm tốc độ tối đa
            }
        }
        private void ConfirmMeasurement()
        {
            this.Invoke(new Action(() =>
            {
                if (currentDataRequest == 1)
                {
                    minSpeed1 = lastRpm;
                    maxSpeed1 = Math.Max(lastRpm, lastMaxSpeed); // Đảm bảo max >= min
                    hsu1 = opacity;
                    hsu1 = (decimal)Math.Max(0.01, Math.Round((double)hsu1, 2));
                }
                else if (currentDataRequest == 2)
                {
                    minSpeed2 = lastRpm;
                    maxSpeed2 = Math.Max(lastRpm, lastMaxSpeed);
                    hsu2 = opacity;
                    hsu2 = (decimal)Math.Max(0.01, Math.Round((double)hsu2, 2));
                }
                else if (currentDataRequest == 3)
                {
                    minSpeed3 = lastRpm;
                    maxSpeed3 = Math.Max(lastRpm, lastMaxSpeed);
                    hsu3 = opacity;
                    hsu3 = (decimal)Math.Max(0.01, Math.Round((double)hsu3, 2));
                }

                UpdateUI(currentDataRequest);
            }));
        }
        private void UpdateUI(int measurementStep)
        {
            switch (measurementStep)
            {
                case 1:
                    if (maxSpeed1 < minSpeed1) maxSpeed1 = minSpeed1;
                    lbMinSpeed1.Text = minSpeed1.ToString("F0");
                    lbMaxSpeed1.Text = maxSpeed1.ToString("F0");
                    lbHSU1.Text = hsu1.ToString("F2");
                    break;

                case 2:
                    maxSpeed2 = Math.Max(maxSpeed2, Math.Max(maxSpeed1, minSpeed2));
                    lbMinSpeed2.Text = minSpeed2.ToString("F0");
                    lbMaxSpeed2.Text = maxSpeed2.ToString("F0");
                    lbHSU2.Text = hsu2.ToString("F2");
                    break;

                case 3:
                    maxSpeed3 = Math.Max(maxSpeed3, Math.Max(maxSpeed2, minSpeed3));
                    lbMinSpeed3.Text = minSpeed3.ToString("F0");
                    lbMaxSpeed3.Text = maxSpeed3.ToString("F0");
                    lbHSU3.Text = hsu3.ToString("F2");
                    break;
            }
        }
        private void UpdateTitle(string message)
        {
            lbDieselTitle.Text = message;
        }
        private void ResetToDefault()
        {
            tbEmission.Visible = false;
            lbMinSpeed1.Text = "0.0";
            lbMinSpeed2.Text = "0.0";
            lbMinSpeed3.Text = "0.0";
            lbMaxSpeed1.Text = "0.0";
            lbMaxSpeed2.Text = "0.0";
            lbMaxSpeed3.Text = "0.0";
            lbHSU1.Text = "0.0";
            lbHSU2.Text = "0.0";
            lbHSU3.Text = "0.0";
            lbMinAvg.Text = "0.0";
            lbMaxAvg.Text = "0.0";
            lbHsuAvg.Text = "0.0";
            lbNotice.Text = string.Empty;
            tbEmission.Visible = false;
            avgHsu = 0;
            opacity = 0;
            lastMaxSpeed = 0;
            lastRpm = 0;
            currentDataRequest = 1;
        }
        private void CalculateAverages()
        {
            avgHsu = (hsu1 + hsu2 + hsu3) / 3;
            avgHsu = (decimal)Math.Max(0.01, Math.Round((double)avgHsu, 2));
            lbHsuAvg.Text = avgHsu.ToString("F2");

            bool isValueInStandard = maxHsu == 0 || avgHsu <= maxHsu;
            lbHsuAvg.ForeColor = isValueInStandard ? SystemColors.HotTrack : Color.DarkRed;

            lbMinAvg.Text = ((minSpeed1 + minSpeed2 + minSpeed3) / 3).ToString("F0");
            lbMaxAvg.Text = ((maxSpeed1 + maxSpeed2 + maxSpeed3) / 3).ToString("F0");
        }
        private decimal ConvertToDecimal(object value)
        {
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }
        private void LoadVehicleStandards(string serialNumber)
        {
            DataRow vehicleDetails = sqlHelper.GetVehicleDetails(serialNumber);
            if (vehicleDetails != null)
            {
                string vehicleType = vehicleDetails["VehicleType"].ToString();
                DataTable vehicleStandards = sqlHelper.GetVehicleStandardsByTypeCar(vehicleType);
                if (vehicleStandards.Rows.Count > 0)
                {
                    DataRow standard = vehicleStandards.Rows[0];
                    maxHsu = ConvertToDecimal(standard["MaxHSU"]);
                }
            }
        }
        private void btnPre_Click(object sender, EventArgs e)
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
                    LoadVehicleStandards(serialNumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi Số Máy: " + ex.Message);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    LoadVehicleStandards(serialNumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi Số Máy: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveDieselEmissionData(this.serialNumber, minSpeed1, maxSpeed1, hsu1, minSpeed2, maxSpeed2, hsu2, minSpeed3, maxSpeed3, hsu3);
        }
        private async void frmDieselEmission_LoadAsync(object sender, EventArgs e)
        {
            lbVinNumber.Text = this.serialNumber;
            comConnect.OpenConnection();
            if (comConnect.IsConnected())
            {
                cbReady.BackColor = Color.Green; // Đèn xanh nếu kết nối thành công
                cts = new CancellationTokenSource();
                await StartDieselEmissionProcess(cts.Token); // Bắt đầu quá trình đo
            }
            else
            {
                cbReady.BackColor = SystemColors.Control; // Màu mặc định nếu không kết nối
            }
        }
        private byte CalculateCheckCode(byte command)
        {
            int sum = command;
            return (byte)(~sum + 1);
        }
        private void frmDieselEmission_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
            comConnect.CloseConnection();
        }

        private async void btnReMeasure_Click(object sender, EventArgs e)
        {
            ResetToDefault();
            cts = new CancellationTokenSource();
            await StartDieselEmissionProcess(cts.Token); // Bắt đầu quá trình đo
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            NextVin();
        }
    }
}
