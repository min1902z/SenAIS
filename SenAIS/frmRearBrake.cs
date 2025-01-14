using System;
using System.Configuration;
using System.Data;
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
        private static readonly string opcBrakeCounter = ConfigurationManager.AppSettings["BrakeR_Counter"];
        private static readonly string opcLBrakeResult = ConfigurationManager.AppSettings["Rear_LBrake_Result"];
        private static readonly string opcRBrakeRResult = ConfigurationManager.AppSettings["Rear_RBrake_Result"];

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
                lbVinNumber.Text = this.serialNumber;
                // Lấy giá trị OPC
                //int checkStatus = await Task.Run(() => (int)OPCUtility.GetOPCValue(opcBrakeCounter));
                int checkStatus = (int)OPCUtility.GetOPCValue(opcBrakeCounter);
                Invoke((Action)(async () =>
                {
                    switch (checkStatus)
                    {
                        case 0: // Mặc định
                            cbReady.BackColor = SystemColors.Control;
                            lbLeft_Brake.Text = "0.0";
                            lbRight_Brake.Text = "0.0";
                            lbDiff_Brake.Text = "0.0";
                            lbSum_Brake.Text = "0.0";
                            tbLeft.Visible = false;
                            tbRight.Visible = false;
                            lbBrakeTitle.Visible = true;
                            isReady = false;
                            break;

                        case 1: // Xe vào vị trí
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            isReady = false; // Chưa sẵn sàng lưu
                            tbLeft.Visible = false;
                            tbRight.Visible = false;
                            lbBrakeTitle.Visible = true;
                            break;

                        case 2: // Bắt đầu đo
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            isReady = true; // Sẵn sàng lưu sau khi đo
                            lbBrakeTitle.Visible = false;
                            tbLeft.Visible = true;
                            tbRight.Visible = true;
                            await HandleMeasurement(); // Đo và xử lý dữ liệu
                            break;

                        case 3: // Quá trình đo hoàn tất, lưu vào DB
                            cbReady.BackColor = Color.Green; // Đèn xanh
                            lbBrakeTitle.Visible = false;
                            tbLeft.Visible = true;
                            tbRight.Visible = true;
                            if (isReady)
                            {
                                CheckCounterPosition(); // Lưu dữ liệu
                                isReady = false;
                            }
                            break;

                        case 4: // Xe tiếp theo
                            cbReady.BackColor = SystemColors.Control;
                            lbBrakeTitle.Visible = false;
                            tbLeft.Visible = true;
                            tbRight.Visible = true;
                            var formBrake = new frmHandBrake(this.serialNumber);
                            formBrake.Show();
                            this.Close();
                            break;

                        default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                            cbReady.BackColor = SystemColors.Control; // Màu mặc định
                            isReady = false;
                            lbBrakeTitle.Visible = true;
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
            double leftBrakeResult = OPCUtility.GetOPCValue(opcLBrakeResult);
            double rightBrakeResult = OPCUtility.GetOPCValue(opcRBrakeRResult);

            double leftBrake = leftBrakeResult / brakeRightA;
            double rightBrake = rightBrakeResult / brakeRightA;
            double diffBrake = Math.Abs(leftBrake - rightBrake) / Math.Max(leftBrake, rightBrake) * 100;
            double sumBrake = leftBrake + rightBrake;

            lbLeft_Brake.Text = leftBrake.ToString("F0");
            lbRight_Brake.Text = rightBrake.ToString("F0");
            lbDiff_Brake.Text = diffBrake.ToString("F1");
            lbSum_Brake.Text = sumBrake.ToString("F0");

            this.rearLeftBrake = Convert.ToDecimal(leftBrake.ToString("F0"));
            this.rearRightBrake = Convert.ToDecimal(rightBrake.ToString("F0"));
            this.diffRearBrake = Convert.ToDecimal(diffBrake.ToString("F1"));
            this.sumRearBrake = Convert.ToDecimal(sumBrake.ToString("F0"));
            // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
            bool isSumStandard = sumRearBrake >= minSumBrake;
            bool isDiffStandard = maxDiffBrake == 0 || diffRearBrake <= maxDiffBrake;
            if (isSumStandard && isDiffStandard)
            {
                lbSum_Brake.ForeColor = SystemColors.HotTrack;
                lbDiff_Brake.ForeColor = SystemColors.HotTrack;
                // Hiển thị thông báo đạt chuẩn
            }
            else if (!isSumStandard)
            {
                lbSum_Brake.ForeColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
            }
            else if (!isDiffStandard)
            {
                lbDiff_Brake.ForeColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
            }
            else
            {
                lbSum_Brake.ForeColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                lbDiff_Brake.ForeColor = Color.DarkRed;
            }
            return Task.CompletedTask;
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
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
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
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
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
            int currentPosition = (int)OPCUtility.GetOPCValue(opcBrakeCounter);

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
