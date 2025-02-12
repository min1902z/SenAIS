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
        private double brakeLeftA = 1;
        private double brakeRightA = 1;
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
            updateTimer.Interval = 500; // Kiểm tra mỗi giây
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();
        }
        private async void UpdateReadyStatus(object sender, EventArgs e)
        {
            try
            {
                lbVinNumber.Text = this.serialNumber;
                // Lấy giá trị OPC
                int checkStatus = await Task.Run(() => (int)OPCUtility.GetOPCValue(opcBrakeCounter));
                Invoke((Action)(async () =>
                {
                    switch (checkStatus)
                    {
                        case 0: // Mặc định
                            cbReady.BackColor = SystemColors.Control;
                            cbBrake.BackColor = SystemColors.Control;
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
                            cbBrake.BackColor = Color.Red;
                            await HandleMeasurement(); // Đo và xử lý dữ liệu
                            break;

                        case 3: // Quá trình đo hoàn tất, lưu vào DB
                            cbReady.BackColor = Color.Green; // Đèn xanh
                            cbBrake.BackColor = SystemColors.Control;
                            lbBrakeTitle.Visible = false;
                            tbLeft.Visible = true;
                            tbRight.Visible = true;
                            if (isReady)
                            {
                                SaveDataToDatabase(); // Lưu dữ liệu
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
            catch
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
            brakeLeftA = sqlHelper.GetParaValue("LeftBrake", "ParaA");
            brakeRightA = sqlHelper.GetParaValue("RightBrake", "ParaA");
        }
        private Task HandleMeasurement()
        {
            // Đảm bảo giá trị ParaA không bằng 0 để tránh lỗi chia 0
            brakeRightA = brakeRightA == 0 ? 1 : brakeRightA;
            brakeLeftA = brakeLeftA == 0 ? 1 : brakeLeftA;

            // Lấy giá trị OPC
            double leftBrakeResult = OPCUtility.GetOPCValue(opcLBrakeResult);
            double rightBrakeResult = OPCUtility.GetOPCValue(opcRBrakeRResult);

            // Tính toán giá trị phanh với hệ số điều chỉnh
            double leftBrake = leftBrakeResult / brakeLeftA;
            double rightBrake = rightBrakeResult / brakeRightA;

            // Tính độ lệch, tránh lỗi chia 0
            double maxBrake = Math.Max(leftBrake, rightBrake);
            double diffBrake = maxBrake > 0 ? Math.Abs(leftBrake - rightBrake) / maxBrake * 100 : 0;

            double sumBrake = leftBrake + rightBrake;

            lbLeft_Brake.Text = leftBrake.ToString("F0");
            lbRight_Brake.Text = rightBrake.ToString("F0");
            lbDiff_Brake.Text = diffBrake.ToString("F1");
            lbSum_Brake.Text = sumBrake.ToString("F0");

            rearLeftBrake = Convert.ToDecimal(leftBrake);
            rearRightBrake = Convert.ToDecimal(rightBrake);
            diffRearBrake = Convert.ToDecimal(diffBrake);
            sumRearBrake = Convert.ToDecimal(sumBrake);

            // Kiểm tra tiêu chuẩn phanh
            bool isSumStandard = sumRearBrake >= minSumBrake;
            bool isDiffStandard = maxDiffBrake == 0 || diffRearBrake <= maxDiffBrake;

            lbSum_Brake.ForeColor = isSumStandard ? SystemColors.HotTrack : Color.DarkRed;
            lbDiff_Brake.ForeColor = isDiffStandard ? SystemColors.HotTrack : Color.DarkRed;
            return Task.CompletedTask;
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu dữ liệu hiện tại
                if (isReady)
                {
                    SaveDataToDatabase(); // Lưu DB nếu đèn xanh và CP xác nhận lưu
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
                    SaveDataToDatabase(); // Lưu dữ liệu nếu sẵn sàng
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
        private async void SaveDataToDatabase()
        {
            await Task.Run(() =>
            {
                sqlHelper.SaveRearBrakeData(this.serialNumber, this.rearLeftBrake, this.rearRightBrake);
            });
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
