using System;
using System.Configuration;
using System.Data;
using System.Drawing;
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
        private bool isRequestInProgress = false;  // To prevent sending multiple requests simultaneously
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

                // Trạng thái 2: Chờ 30 giây chuẩn bị đầu dò
                UpdateTitle("Trang bị đầu dò");
                lbNotice.Visible = true;
                lbNotice.Text = "Chuẩn bị đạp ga 3 lần.";
                await Task.Delay(5000, cancellationToken);

                // Trạng thái 3: Hướng dẫn đo và đo 3 lần
                tbEmission.Visible = true;
                currentDataRequest = 1;
                byte[] commandA7 = { 0xA7, CalculateCheckCode(0xA7) };
                comConnect.SendRequest(commandA7);
                byte[] commandA5 = { 0xA5, 0xB5 };
                comConnect.SendRequest(commandA5);
                isRequestInProgress = true;
                while (currentDataRequest <= 3)
                {
                    // Hiển thị đếm ngược
                    for (int countdown = 5; countdown > 0; countdown--)
                    {
                        lbNotice.Text = $"Đạp ga lần {currentDataRequest}. Thực hiện trong {countdown} giây...";
                        await Task.Delay(1000, cancellationToken);
                    }
                    ConfirmMeasurement();
                    currentDataRequest++;
                }

                // Trạng thái 4: Kết thúc đo, lưu kết quả
                if (currentDataRequest > 3)
                {
                    CalculateAverages();
                    SaveDataToDatabase();
                    isRequestInProgress = false;
                    lbNotice.Text = "Quá trình lưu dữ liệu hoàn tất.";
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
        public void ProcessNHT6Data(byte[] data)
        {
            if (data.Length >= 9 && data[0] == 0xA5 && isRequestInProgress)
            {
                opacity = ((data[1] << 8) + data[2]) / 10.0m; // Opacity chia 10
                lightAbsorption = ((data[3] << 8) + data[4]) / 100.0m; // Light absorption chia 100
                lastRpm = (data[5] << 8) + data[6]; // Lưu tạm tốc độ
                int oilTempRaw = (data[7] << 8) + data[8];
                int oilTempCelsius = 0;
                if (oilTempRaw == 0xFFFF)
                {
                    oilTemperature = "--";  // Không có cảm biến nhiệt độ
                    oilTempCelsius = 0;
                }
                else
                {
                    oilTempCelsius = oilTempRaw;
                    oilTemperature = oilTempCelsius.ToString();
                }
            }
        }
        public void ProcessNHT6MaxData(byte[] data)
        {
            if (data.Length >= 7 && data[0] == 0xA6 && isRequestInProgress)
            {
                lastMaxSpeed = (data[5] << 8) + data[6]; // Lưu tạm tốc độ tối đa
            }
        }
        private void ConfirmMeasurement()
        {
            this.Invoke(new Action(() =>
            {
                switch (currentDataRequest)
                {
                    case 1:
                        minSpeed1 = lastRpm;
                        maxSpeed1 = lastMaxSpeed;
                        hsu1 = opacity;

                        lbMinSpeed1.Text = minSpeed1.ToString("F0");
                        lbMaxSpeed1.Text = maxSpeed1.ToString("F0");
                        lbHSU1.Text = hsu1.ToString("F1");
                        break;
                    case 2:
                        minSpeed2 = lastRpm;
                        maxSpeed2 = lastMaxSpeed;
                        hsu2 = opacity;

                        lbMinSpeed2.Text = minSpeed2.ToString("F0");
                        lbMaxSpeed2.Text = maxSpeed2.ToString("F0");
                        lbHSU2.Text = hsu2.ToString("F1");
                        break;
                    case 3:
                        minSpeed3 = lastRpm;
                        maxSpeed3 = lastMaxSpeed;
                        hsu3 = opacity;

                        lbMinSpeed3.Text = minSpeed3.ToString("F0");
                        lbMaxSpeed3.Text = maxSpeed3.ToString("F0");
                        lbHSU3.Text = hsu3.ToString("F1");
                        break;
                }
            }));
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
            isRequestInProgress = false;
        }
        private void CalculateAverages()
        {
            avgHsu = (hsu1 + hsu2 + hsu3) / 3;
            lbHsuAvg.Text = avgHsu.ToString("F1");

            bool isValueInStandard = maxHsu == 0 || avgHsu <= maxHsu;
            lbHsuAvg.ForeColor = isValueInStandard ? SystemColors.HotTrack : Color.DarkRed;

            lbMinAvg.Text = ((minSpeed1 + minSpeed2 + minSpeed3) / 3).ToString("F1");
            lbMaxAvg.Text = ((maxSpeed1 + maxSpeed2 + maxSpeed3) / 3).ToString("F1");
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
                else
                {
                    MessageBox.Show("Không có xe trước đó.");
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
                else
                {
                    MessageBox.Show("Không có xe tiếp theo.");
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
            comConnect.CloseConnection();
            this.Close();
        }
    }
}
