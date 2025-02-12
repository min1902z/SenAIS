using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmHeadlights : Form
    {
        private Timer updateTimer;
        private COMConnect comConnect;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal rightHBIntensityValue;
        public decimal rightHBVerticalValue;
        public decimal rightHBHorizontalValue;
        public decimal leftHBIntensityValue;
        public decimal leftHBVerticalValue;
        public decimal leftHBHorizontalValue;
        public decimal rightLBIntensityValue;
        public decimal rightLBVerticalValue;
        public decimal rightLBHorizontalValue;
        public decimal leftLBIntensityValue;
        public decimal leftLBVerticalValue;
        public decimal leftLBHorizontalValue;

        private decimal minHBIntensity;
        private decimal minDiffHoriLeftHB;
        private decimal maxDiffHoriLeftHB;
        private decimal minDiffHoriHB;
        private decimal maxDiffHoriHB;
        private decimal minDiffVertiHB;
        private decimal maxDiffVertiHB;
        private decimal minDiffHoriLB;
        private decimal maxDiffHoriLB;
        private decimal minDiffVertiLB;
        private decimal maxDiffVertiLB;
        private decimal minLBIntensity;
        private bool isReady = false;
        private bool autoTestCheck = false;
        public bool isDataCollected = false;
        private Timer turnSignalTimer;
        private static readonly string opcHLCounter = ConfigurationManager.AppSettings["Headlights_Counter"];
        private static readonly string opcLeftSen = ConfigurationManager.AppSettings["HL_LeftSen"];
        private static readonly string opcRightSen = ConfigurationManager.AppSettings["HL_RightSen"];
        public frmHeadlights(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            comConnect = new COMConnect(ConfigurationManager.AppSettings["COM_Headlights"], 2400, this);
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
            InitializeTimer();
            InitializeSenSignalTimer();
        }
        private void InitializeSenSignalTimer()
        {
            turnSignalTimer = new Timer();
            turnSignalTimer.Interval = 200; 
            turnSignalTimer.Tick += SenSignalTimer_Tick;
            turnSignalTimer.Start();
        }
        private void SenSignalTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ OPC
                int leftSen = OPCUtility.GetOPCValue(opcLeftSen);
                int rightSen = OPCUtility.GetOPCValue(opcRightSen);

                // Chỉ hiển thị pbLeft hoặc pbRight nếu cả hai giá trị khác nhau
                if (leftSen == 1)
                {
                    cbLeft.BackColor = Color.Green;
                }
                else
                {
                    cbLeft.BackColor = Color.Red;
                }
                if (rightSen == 1)
                {
                    cbRight.BackColor = Color.Green;
                }
                else
                {
                    cbRight.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cảm biến: {ex.Message}");
            }
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();
        }
        private async void UpdateReadyStatus(object sender, EventArgs e)
        {
            try
            {
                lbEngineNumber.Text = this.serialNumber;
                // Lấy giá trị OPC
               int checkStatus = await Task.Run(() => (int)OPCUtility.GetOPCValue(opcHLCounter));
               Invoke((Action)(() =>
                {
                    switch (checkStatus)
                    {
                        case 0:
                            cbReady.BackColor = SystemColors.Control;
                            lbHBRIntensity.Text = "0.0";
                            lbHBRVerticalDeviation.Text = "0.0";
                            lbHBRHorizontalDeviation.Text = "0.0";

                            lbLBRIntensity.Text = "0.0";
                            lbLBRVerticalDeviation.Text = "0.0";
                            lbLBRHorizontalDeviation.Text = "0.0";

                            lbHBLIntensity.Text = "0.0";
                            lbHBLVerticalDeviation.Text = "0.0";
                            lbHBLHorizontalDeviation.Text = "0.0";

                            lbLBLIntensity.Text = "0.0";
                            lbLBLVerticalDeviation.Text = "0.0";
                            lbLBLHorizontalDeviation.Text = "0.0";
                            tbHeadLights.Visible = false;
                            lbTitle.Visible = true;
                            isReady = false;
                            break;
                        case 1: // Xe vào vị trí
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            isReady = false; // Chưa sẵn sàng lưu
                            tbHeadLights.Visible = false;
                            lbTitle.Visible = true;
                            break;

                        case 2: // Bắt đầu đo
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            isReady = true; // Sẵn sàng lưu sau khi đo
                            lbTitle.Visible = false;
                            tbHeadLights.Visible = true;
                            if (turnSignalTimer != null)
                            {
                                turnSignalTimer.Stop(); // Dừng Timer
                                turnSignalTimer.Dispose(); // Giải phóng tài nguyên
                                turnSignalTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
                            }
                            if (!autoTestCheck)
                            {
                                byte[] autoTest = { 0x41 };
                                comConnect.SendRequest(autoTest);
                                autoTestCheck = true;
                            }
                            if (isDataCollected)
                            {
                                OPCUtility.SetOPCValue(opcHLCounter, 3); // Đặt Test1 thành 3
                            }
                            break;

                        case 3: // Quá trình đo hoàn tất, lưu vào DB
                            cbReady.BackColor = Color.Green; // Đèn xanh
                            tbHeadLights.Visible = true;
                            lbTitle.Visible = false;
                            if (isReady)
                            {
                                SaveDataToDatabase(); // Ghi dữ liệu vào DB
                                isReady = false; // Đặt lại trạng thái
                            }
                            break;
                        case 4: // Xe tiếp theo
                            cbReady.BackColor = SystemColors.Control;
                            isReady = false; // Đặt lại trạng thái
                            tbHeadLights.Visible = true;
                            lbTitle.Visible = false;
                            byte[] exit = { 0x50 };
                            comConnect.SendRequest(exit);
                            var formWhistle = new frmWhistle(this.serialNumber);
                            formWhistle.Show();
                            this.Close();
                            break;

                        default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                            cbReady.BackColor = SystemColors.Control; // Màu mặc định
                            isReady = false;
                            lbTitle.Visible = true;
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

                    // Gán các giá trị tiêu chuẩn
                    minHBIntensity = ConvertToDecimal(standard["MinHLIntensity"]);
                    minDiffHoriLeftHB = ConvertToDecimal(standard["MinDiffHoriLeftHB"]);
                    maxDiffHoriLeftHB = ConvertToDecimal(standard["MaxDiffHoriLeftHB"]);
                    minDiffHoriHB = ConvertToDecimal(standard["MinDiffHoriHB"]);
                    maxDiffHoriHB = ConvertToDecimal(standard["MaxDiffHoriHB"]);
                    minDiffVertiHB = ConvertToDecimal(standard["MinDiffVertiHB"]);
                    maxDiffVertiHB = ConvertToDecimal(standard["MaxDiffVertiHB"]);
                    minDiffHoriLB = ConvertToDecimal(standard["MinDiffHoriLB"]);
                    maxDiffHoriLB = ConvertToDecimal(standard["MaxDiffHoriLB"]);
                    minDiffVertiLB = ConvertToDecimal(standard["MinDiffVertiLB"]);
                    maxDiffVertiLB = ConvertToDecimal(standard["MaxDiffVertiLB"]);
                    minLBIntensity = ConvertToDecimal(standard["MinLBIntensity"]);
                }
            }
        }
        // Method to process and display data on frmCosLightL
        public void ProcessNHD6109Data(byte[] data)
        {
            if (data[0] == 0x01)
            {
                // Xử lý 34 byte của đèn phải (Right Headlight)
                string rightHBHorizontalDeviation = Encoding.ASCII.GetString(data, 2, 5);    // Lệch ngang Right HB (5 bytes)
                string rightHBVerticalDeviation = Encoding.ASCII.GetString(data, 7, 5);      // Lệch dọc Right HB (5 bytes)
                string rightHBLightIntensity = Encoding.ASCII.GetString(data, 12, 4);        // Cường độ Right HB (4 bytes)

                string rightLBHorizontalDeviation = Encoding.ASCII.GetString(data, 19, 5);   // Lệch ngang Right LB (5 bytes)
                string rightLBVerticalDeviation = Encoding.ASCII.GetString(data, 24, 5);     // Lệch dọc Right LB (5 bytes)
                string rightLBLightIntensity = Encoding.ASCII.GetString(data, 12, 4);        // Cường độ Right LB (4 bytes)

                // Xử lý 34 byte của đèn trái (Left Headlight)
                string leftHBHorizontalDeviation = Encoding.ASCII.GetString(data, 36, 5);    // Lệch ngang Left HB (5 bytes)
                string leftHBVerticalDeviation = Encoding.ASCII.GetString(data, 41, 5);      // Lệch dọc Left HB (5 bytes)
                string leftHBLightIntensity = Encoding.ASCII.GetString(data, 46, 4);         // Cường độ Left HB (4 bytes)

                string leftLBHorizontalDeviation = Encoding.ASCII.GetString(data, 53, 5);    // Lệch ngang Left LB (5 bytes)
                string leftLBVerticalDeviation = Encoding.ASCII.GetString(data, 58, 5);      // Lệch dọc Left LB (5 bytes)
                string leftLBLightIntensity = Encoding.ASCII.GetString(data, 46, 4);         // Cường độ Left LB (4 bytes)

                // Chuyển đổi chuỗi ASCII thành số thực
                this.rightHBHorizontalValue = decimal.Parse(rightHBHorizontalDeviation.Replace("+", "").Replace("-", "-"));
                this.rightHBVerticalValue = decimal.Parse(rightHBVerticalDeviation.Replace("+", "-").Replace("-", ""));
                this.rightHBIntensityValue = decimal.Parse(rightHBLightIntensity);

                this.rightLBHorizontalValue = decimal.Parse(rightLBHorizontalDeviation.Replace("+", "").Replace("-", "-"));
                this.rightLBVerticalValue = decimal.Parse(rightLBVerticalDeviation.Replace("+", "-").Replace("-", ""));
                //this.rightLBIntensityValue = decimal.Parse(rightLBLightIntensity);

                this.leftHBHorizontalValue = decimal.Parse(leftHBHorizontalDeviation.Replace("+", "").Replace("-", "-"));
                this.leftHBVerticalValue = decimal.Parse(leftHBVerticalDeviation.Replace("+", "-").Replace("-", ""));
                this.leftHBIntensityValue = decimal.Parse(leftHBLightIntensity);

                this.leftLBHorizontalValue = decimal.Parse(leftLBHorizontalDeviation.Replace("+", "").Replace("-", "-"));
                this.leftLBVerticalValue = decimal.Parse(leftLBVerticalDeviation.Replace("+", "-").Replace("-", ""));
                //this.leftLBIntensityValue = decimal.Parse(leftLBLightIntensity);

                this.Invoke(new Action(() =>
                {
                    lbHBRIntensity.Text = rightHBIntensityValue.ToString();
                    lbHBRVerticalDeviation.Text = rightHBVerticalValue.ToString();
                    lbHBRHorizontalDeviation.Text = rightHBHorizontalValue.ToString();

                    //lbLBRIntensity.Text = rightLBIntensityValue.ToString();
                    lbLBRVerticalDeviation.Text = rightLBVerticalValue.ToString();
                    lbLBRHorizontalDeviation.Text = rightLBHorizontalValue.ToString();

                    lbHBLIntensity.Text = leftHBIntensityValue.ToString();
                    lbHBLVerticalDeviation.Text = leftHBVerticalValue.ToString();
                    lbHBLHorizontalDeviation.Text = leftHBHorizontalValue.ToString();

                    //lbLBLIntensity.Text = leftLBIntensityValue.ToString();
                    lbLBLVerticalDeviation.Text = leftLBVerticalValue.ToString();
                    lbLBLHorizontalDeviation.Text = leftLBHorizontalValue.ToString();

                    // Kiểm tra và đổi màu cho Right High Beam
                    lbHBRIntensity.ForeColor = rightHBIntensityValue >= minHBIntensity ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBRVerticalDeviation.ForeColor = (rightHBVerticalValue >= minDiffVertiHB && rightHBVerticalValue <= maxDiffVertiHB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBRHorizontalDeviation.ForeColor = (rightHBHorizontalValue >= minDiffHoriHB && rightHBHorizontalValue <= maxDiffHoriHB) ? SystemColors.HotTrack : Color.DarkRed;

                    // Kiểm tra và đổi màu cho Right Low Beam
                    //lbLBRIntensity.ForeColor = rightLBIntensityValue >= minLBIntensity ? SystemColors.HotTrack : Color.DarkRed;
                    lbLBRVerticalDeviation.ForeColor = (rightLBVerticalValue >= minDiffVertiLB && rightLBVerticalValue <= maxDiffVertiLB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbLBRHorizontalDeviation.ForeColor = (rightLBHorizontalValue >= minDiffHoriLB && rightLBHorizontalValue <= maxDiffHoriLB) ? SystemColors.HotTrack : Color.DarkRed;

                    // Kiểm tra và đổi màu cho Left High Beam
                    lbHBLIntensity.ForeColor = leftHBIntensityValue >= minHBIntensity ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBLVerticalDeviation.ForeColor = (leftHBVerticalValue >= minDiffVertiHB && leftHBVerticalValue <= maxDiffVertiHB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBLHorizontalDeviation.ForeColor = (leftHBHorizontalValue >= minDiffHoriHB && leftHBHorizontalValue <= maxDiffHoriHB) ? SystemColors.HotTrack : Color.DarkRed;

                    // Kiểm tra và đổi màu cho Left Low Beam
                    //lbLBLIntensity.ForeColor = leftLBIntensityValue >= minLBIntensity ? SystemColors.HotTrack : Color.DarkRed;
                    lbLBLVerticalDeviation.ForeColor = (leftLBVerticalValue >= minDiffVertiLB && leftLBVerticalValue <= maxDiffVertiLB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbLBLHorizontalDeviation.ForeColor = (leftLBHorizontalValue >= minDiffHoriLB && leftLBHorizontalValue <= maxDiffHoriLB) ? SystemColors.HotTrack : Color.DarkRed;

                    isDataCollected = true;
                }));
            }
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
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
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
                if (isReady)
                {
                    SaveDataToDatabase();
                }

                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
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
        private async void SaveDataToDatabase()
        {
            await Task.Run(() =>
            {
                sqlHelper.SaveHeadlightsData(this.serialNumber, this.leftHBIntensityValue, this.leftHBVerticalValue, this.leftHBHorizontalValue,
                                                                    this.rightHBIntensityValue, this.rightHBVerticalValue, this.rightHBHorizontalValue,
                                                                    this.leftLBIntensityValue, this.leftLBVerticalValue, this.leftLBHorizontalValue,
                                                                    this.rightLBIntensityValue, this.rightLBVerticalValue, this.rightLBHorizontalValue);
            });
        }
        private void frmCosLightL_Load(object sender, EventArgs e)
        {
            comConnect.OpenConnection();
        }
        private void frmCosLightL_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
            if (updateTimer != null)
            {
                updateTimer.Stop(); // Dừng Timer
                updateTimer.Dispose(); // Giải phóng tài nguyên
                updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            }
            if (turnSignalTimer != null)
            {
                turnSignalTimer.Stop(); // Dừng Timer
                turnSignalTimer.Dispose(); // Giải phóng tài nguyên
                turnSignalTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            }
            e.Cancel = false;
        }
    }
}
