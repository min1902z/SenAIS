using OPCAutomation;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmRearBrake : Form
    {
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal rearLeftBrake;
        public decimal rearRightBrake;
        public decimal diffRearBrake;
        public decimal sumRearBrake;
        private bool isReady = false;
        private decimal minSumBrake = 0;
        private decimal maxDiffBrake = 0;
        private int retryCount = 0; // Đếm số lần đo lại

        public frmRearBrake(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000; // Kiểm tra mỗi giây
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();
        }
        private async void UpdateReadyStatus(object sender, EventArgs e)
        {
            try
            {
                lbEngineNumber.Text = this.serialNumber;
                // Lấy giá trị OPC
                int checkStatus = await Task.Run(() => (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99"));
                Invoke((Action)(async () =>
                {
                    switch (checkStatus)
                    {
                        case 5: // Mặc định
                            cbReady.BackColor = SystemColors.Control;
                            lbLeft_Brake.Text = "0.0";
                            lbRight_Brake.Text = "0.0";
                            lbDiff_Brake.Text = "0.0";
                            lbSum_Brake.Text = "0.0";
                            lbDiffStandard.Text = "--";
                            lbSumStandard.Text = "--";
                            lbNotice.Visible = false;
                            isReady = false;
                            break;

                        case 6: // Xe vào vị trí
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            isReady = false; // Chưa sẵn sàng lưu
                            lbNotice.Visible = true;
                            lbNotice.Text = $"Phương tiện có số VIN '{this.serialNumber}' đã vào vị trí, chuẩn bị kiểm tra.";
                            lbDiffStandard.Text = (maxDiffBrake != 0) ? maxDiffBrake.ToString("F0") : "--";
                            lbSumStandard.Text = (minSumBrake != 0) ? minSumBrake.ToString("F0") : "--";
                            break;

                        case 7: // Bắt đầu đo
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            isReady = true; // Sẵn sàng lưu sau khi đo

                            await HandleMeasurement(); // Đo và xử lý dữ liệu
                            break;

                        case 8: // Quá trình đo hoàn tất, lưu vào DB
                            cbReady.BackColor = Color.Green; // Đèn xanh
                            if (isReady)
                            {
                                bool isSumStandard3 = sqlHelper.CheckValueAgainstStandard("RearBrake", sumRearBrake, this.serialNumber);
                                bool isDiffStandard3 = sqlHelper.CheckValueAgainstStandard("DiffRearBrake", diffRearBrake, this.serialNumber);

                                if (isSumStandard3 && isDiffStandard3)
                                {
                                    CheckCounterPosition(); // Lưu dữ liệu
                                    isReady = false;
                                }
                                else if ((!isSumStandard3 || !isDiffStandard3)&& retryCount < 2)
                                {
                                    CheckCounterPosition(); // Lưu dữ liệu
                                    OPCUtility.SetOPCValue("Hyundai.OCS10.T99", 5); // Đặt lại trạng thái để đo lại
                                    retryCount++; // Tăng số lần đo lại
                                }
                            }
                            break;

                        case 9: // Xe tiếp theo
                            cbReady.BackColor = SystemColors.Control;
                            lbLeft_Brake.Text = "0.0";
                            lbRight_Brake.Text = "0.0";
                            lbDiff_Brake.Text = "0.0";
                            lbSum_Brake.Text = "0.0";
                            lbDiffStandard.Text = "--";
                            lbSumStandard.Text = "--";
                            retryCount = 0; // Reset đếm số lần đo lại khi đạt chuẩn
                            lbNotice.Visible = true;
                            lbNotice.Text = "Chuẩn bị kiểm tra xe tiếp theo.";
                            OPCUtility.SetOPCValue("Hyundai.OCS10.T99", 10);
                            var formBrake = new frmHandBrake(this.serialNumber);
                            formBrake.Show();
                            this.Close();
                            break;

                        default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                            cbReady.BackColor = SystemColors.Control; // Màu mặc định
                            isReady = false;
                            lbNotice.Visible = false;
                            break;
                    }
            }));
            }
            catch (Exception)
            {
            }
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
                    minSumBrake = ConvertToDecimal(standard["MinRearBrake"]);
                    maxDiffBrake = ConvertToDecimal(standard["MaxDiffRearBrake"]);
                }
            }
        }
        private Task HandleMeasurement()
        {
            double brakeRightA = sqlHelper.GetParaValue("RightBrake", "ParaA");
            double leftBrakeResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Brake_Rear_Result");
            double rightBrakeResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Brake_Rear_Result");

            double leftBrake = leftBrakeResult / brakeRightA;
            double rightBrake = rightBrakeResult / brakeRightA;
            double diffBrake = Math.Abs(leftBrake - rightBrake) / Math.Max(leftBrake, rightBrake) * 100;
            double sumBrake = leftBrake + rightBrake;

            lbLeft_Brake.Text = leftBrake.ToString("F1");
            lbRight_Brake.Text = rightBrake.ToString("F1");
            lbDiff_Brake.Text = diffBrake.ToString("F1");
            lbSum_Brake.Text = sumBrake.ToString("F1");

            this.rearLeftBrake = Convert.ToDecimal(leftBrake.ToString("F1"));
            this.rearRightBrake = Convert.ToDecimal(rightBrake.ToString("F1"));
            this.diffRearBrake = Convert.ToDecimal(diffBrake.ToString("F1"));
            this.sumRearBrake = Convert.ToDecimal(sumBrake.ToString("F1"));
            // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
            bool isSumStandard = sqlHelper.CheckValueAgainstStandard("RearBrake", sumRearBrake, this.serialNumber);
            bool isDiffStandard = sqlHelper.CheckValueAgainstStandard("DiffRearBrake", diffRearBrake, this.serialNumber);

            if (isSumStandard && isDiffStandard)
            {
                lbSum_Brake.ForeColor = SystemColors.HotTrack;
                lbDiff_Brake.ForeColor = SystemColors.HotTrack;
                // Hiển thị thông báo đạt chuẩn
                lbNotice.Visible = true;
                lbNotice.Text = "Giá trị kiểm tra đã đạt tiêu chuẩn. Vui lòng chờ ...";
            }
            else if (!isSumStandard)
            {
                lbSum_Brake.ForeColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                lbNotice.Visible = true;
                lbNotice.Text = "Giá trị Tổng lực phanh kiểm tra chưa đạt tiêu chuẩn.";
            }
            else if (!isDiffStandard)
            {
                lbDiff_Brake.ForeColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                lbNotice.Visible = true;
                lbNotice.Text = "Giá trị Chênh lệch lực phanh kiểm tra chưa đạt tiêu chuẩn.";
            }
            else
            {
                lbSum_Brake.ForeColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                lbDiff_Brake.ForeColor = Color.DarkRed;
                lbNotice.Text = "Giá trị kiểm tra chưa đạt tiêu chuẩn.";
            }
            return Task.CompletedTask;
        }
        private async Task<bool> CheckValueFor10SecondsAsync()
        {
            const int checkInterval = 1000; // Kiểm tra mỗi giây
            const int stabilityDuration = 10000; // Tổng thời gian kiểm tra (10 giây)
            var stopwatch = Stopwatch.StartNew();

            while (stopwatch.ElapsedMilliseconds < stabilityDuration)
            {
                await Task.Delay(checkInterval); // Chờ 1 giây

                bool isSumStandard = sqlHelper.CheckValueAgainstStandard("RearBrake", sumRearBrake, this.serialNumber);
                bool isDiffStandard = sqlHelper.CheckValueAgainstStandard("DiffRearBrake", diffRearBrake, this.serialNumber);

                // Nếu bất kỳ giá trị nào không đạt chuẩn, reset thời gian kiểm tra
                if (!isSumStandard || !isDiffStandard)
                {
                    stopwatch.Restart(); // Đặt lại thời gian nếu giá trị không đạt
                }
            }
            stopwatch.Stop();
            // Nếu hoàn thành 10 giây mà không reset, coi như ổn định
            return true;
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu dữ liệu hiện tại
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu DB nếu đèn xanh và CP xác nhận lưu
                }
                // Lấy SerialNumber trước đó
                string previousSerialNumber = sqlHelper.GetPreviousSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(previousSerialNumber))
                {
                    // Cập nhật serialNumber mới
                    this.serialNumber = previousSerialNumber;
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
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
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu sẵn sàng
                }

                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
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
            sqlHelper.SaveRearBrakeData(this.serialNumber, this.rearLeftBrake, this.rearRightBrake);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition == 3)
            {
                SaveDataToDatabase();
            }
        }

        private void frmRearBrake_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateTimer != null)
            {
                updateTimer.Stop(); // Dừng Timer
                updateTimer.Dispose(); // Giải phóng tài nguyên
                updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            }
            e.Cancel = false;
        }
    }
}
