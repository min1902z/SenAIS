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
                lbNotice.Text = "Chuẩn bị đạp ga 3 lần.";
                await Task.Delay(5000, cancellationToken);
                byte[] commandA5 = { 0xA5, 0xB5 };
                comConnect.SendRequest(commandA5);
                // Trạng thái 3: Hướng dẫn đo và đo 3 lần
                tbEmission.Visible = true;
                //while (currentDataRequest <= 3)
                //{
                //    for (int countdown = 5; countdown >= 0; countdown--)
                //    {
                //        lbNotice.Text = $"Đạp ga lần {currentDataRequest}. Thực hiện {countdown} giây...";
                //        await Task.Delay(1000, cancellationToken); // Đếm ngược từng giây

                //        if (countdown == 4)
                //        {
                //            byte[] commandA5 = { 0xA5, CalculateCheckCode(0xA5) };
                //            comConnect.SendRequest(commandA5);
                //            isRequestInProgress = true; // Đánh dấu đang chờ dữ liệu
                //        }
                //    }
                //}

                // Trạng thái 4: Kết thúc đo, lưu kết quả
                if (currentDataRequest > 3)
                {
                    CalculateAverages();
                    SaveDataToDatabase();
                    lbNotice.Text = "Đã lưu dữ liệu.";
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
            lbHsuAvg.Text = "0.0";
            lbNotice.Text = string.Empty;
            tbEmission.Visible = false;
            avgHsu = 0;
            currentDataRequest = 1;
            isRequestInProgress = false;
        }

        private void CalculateAverages()
        {
            avgHsu = (hsu1 + hsu2 + hsu3) / 3;
            lbHsuAvg.Text = avgHsu.ToString("F1");

            bool isValueInStandard = maxHsu == 0 || avgHsu <= maxHsu;
            lbHsuAvg.BackColor = isValueInStandard ? SystemColors.HotTrack : Color.DarkRed;

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
        public void ProcessNHT6MaxData(byte[] data)
        {
            if (data.Length >= 7 && data[0] == 0xA6)
            {
                int maxRpm = (data[5] << 8) + data[6]; // Max Speed (revolving speed)
                this.Invoke(new Action(() =>
                {
                    switch (currentDataRequest)
                    {
                        case 1:
                            lbMaxSpeed1.Text = maxRpm.ToString();
                            this.maxSpeed1 = Convert.ToDecimal(maxRpm);
                            break;
                        case 2:
                            lbMaxSpeed2.Text = maxRpm.ToString();
                            this.maxSpeed2 = Convert.ToDecimal(maxRpm);
                            break;
                        case 3:
                            lbMaxSpeed3.Text = maxRpm.ToString();
                            this.maxSpeed3 = Convert.ToDecimal(maxRpm);
                            break;
                    }
                }));
                currentDataRequest++;
                isRequestInProgress = false;
            }
        }
        public void ProcessNHT6Data(byte[] data)
        {
            if (data.Length >= 9 && data[0] == 0xA5)
            {
                // Xử lý dữ liệu MinSpeed và OilTemp
                decimal opacity = (data[1] << 8) + data[2]; // Opacity (2 bytes, high byte in front)
                decimal lightAbsorption = (data[3] << 8) + data[4]; // Light absorption coefficient (2 bytes, high byte in front)
                int rpm = (data[5] << 8) + data[6];
                int oilTempRaw = (data[7] << 8) + data[8];
                string oilTemperature;
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

                this.Invoke(new Action(() =>
                {
                    switch (currentDataRequest)
                    {
                        case 1:
                            lbMinSpeed1.Text = rpm.ToString("F0");
                            lbHSU1.Text = opacity.ToString("F1");
                            this.minSpeed1 = Convert.ToDecimal(rpm);
                            this.hsu1 = opacity;
                            break;
                        case 2:
                            lbMinSpeed2.Text = rpm.ToString("F0");
                            lbHSU2.Text = opacity.ToString("F1");
                            this.minSpeed2 = Convert.ToDecimal(rpm);
                            this.hsu2 = opacity;
                            break;
                        case 3:
                            lbMinSpeed3.Text = rpm.ToString("F0");
                            lbHSU3.Text = opacity.ToString("F1");
                            this.minSpeed3 = Convert.ToDecimal(rpm);
                            this.hsu3 = opacity;
                            break;
                    }
                }));
                byte[] commandA6 = { 0xA6, CalculateCheckCode(0xA6) };
                comConnect.SendRequest(commandA6);
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
