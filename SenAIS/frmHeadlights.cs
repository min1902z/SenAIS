using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmHeadlights : Form
    {
        //private Timer updateTimer;
        private COMConnect comConnect;
        private SQLHelper sqlHelper;
        private OPCUtility opcManager;
        private CancellationTokenSource opcCancellationTokenSource;
        private CancellationTokenSource sensorCancellationTokenSource;

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
        public decimal leftHBHeightValue;
        public decimal rightHBHeightValue;
        public decimal leftLBHeightValue;
        public decimal rightLBHeightValue;

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
        private decimal minHBHeight;
        private decimal maxHBHeight;
        private bool isReady = false;
        private bool autoTestCheck = false;
        public bool isDataCollected = false;
        //private Timer turnSignalTimer;
        private static readonly string opcHLCounter = ConfigurationManager.AppSettings["Headlights_Counter"];
        private static readonly string opcLeftSen = ConfigurationManager.AppSettings["HL_InSen"];
        private static readonly string opcRightSen = ConfigurationManager.AppSettings["HL_OutSen"];
        public frmHeadlights(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            comConnect = new COMConnect(ConfigurationManager.AppSettings["COM_Headlights"], 2400, this);
            sqlHelper = new SQLHelper();
            opcManager = new OPCUtility();
            StartCounterMonitoring();
            StartSensorMonitoring();
            //InitializeTimer();
            //InitializeSenSignalTimer();
        }
        private void StartCounterMonitoring()
        {
            opcCancellationTokenSource = new CancellationTokenSource();
            var token = opcCancellationTokenSource.Token;

            Task.Run(async () =>
            {
                int lastStatus = -1;

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        int checkStatus = opcManager.GetOPCValue(opcHLCounter);

                        if (checkStatus != lastStatus || checkStatus == 2)
                        {
                            lastStatus = checkStatus;
                            this.BeginInvoke((MethodInvoker)(() => UpdateUI(checkStatus)));
                        }

                        await Task.Delay(200, token);
                    }
                    catch (Exception) { }
                }
            }, token);
        }
        private void StartSensorMonitoring()
        {
            sensorCancellationTokenSource = new CancellationTokenSource();
            var token = sensorCancellationTokenSource.Token;

            Task.Run(async () =>
            {
                int lastLeft = -1, lastRight = -1;

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        int left = opcManager.GetOPCValue(opcLeftSen);
                        int right = opcManager.GetOPCValue(opcRightSen);

                        if (left != lastLeft || right != lastRight)
                        {
                            lastLeft = left;
                            lastRight = right;

                            this.BeginInvoke((MethodInvoker)(() =>
                            {
                                cbLeft.BackColor = left == 1 ? Color.Green : SystemColors.Control;
                                cbRight.BackColor = right == 1 ? Color.Green : SystemColors.Control;
                            }));
                        }

                        await Task.Delay(200, token);
                    }
                    catch (Exception) { }
                }
            }, token);
        }
        private void UpdateUI(int checkStatus)
        {
            switch (checkStatus)
            {
                case 0:
                    ResetHeadlightUI();
                    break;
                case 1:
                    cbReady.BackColor = Color.Green;
                    tbHeadLights.Visible = true;
                    lbTitle.Visible = false;
                    break;
                case 2:
                    cbReady.BackColor = Color.Green;
                    isReady = true;
                    tbHeadLights.Visible = true;
                    lbTitle.Visible = false;

                    StopSensorMonitoring();

                    if (!autoTestCheck)
                    {
                        byte[] autoTest = { 0x41 };
                        comConnect.SendRequest(autoTest);
                        autoTestCheck = true;
                    }
                    break;
                case 3:
                    cbReady.BackColor = Color.Green;
                    tbHeadLights.Visible = true;
                    lbTitle.Visible = false;

                    if (isReady)
                    {
                        SaveDataToDatabase();
                        isReady = false;
                    }
                    break;
                case 4:
                    cbReady.BackColor = SystemColors.Control;
                    isReady = false;
                    tbHeadLights.Visible = true;
                    lbTitle.Visible = false;
                    comConnect.CloseConnection();
                    MoveToNextCar();
                    break;
                default:
                    ResetHeadlightUI();
                    break;
            }
        }
        //private void InitializeSenSignalTimer()
        //{
        //    turnSignalTimer = new Timer();
        //    turnSignalTimer.Interval = 200;
        //    turnSignalTimer.Tick += SenSignalTimer_Tick;
        //    turnSignalTimer.Start();
        //}
        //private void SenSignalTimer_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Lấy giá trị từ OPC
        //        int leftSen = opcManager.GetOPCValue(opcLeftSen);
        //        int rightSen = opcManager.GetOPCValue(opcRightSen);

        //        // Chỉ hiển thị pbLeft hoặc pbRight nếu cả hai giá trị khác nhau
        //        if (leftSen == 1)
        //        {
        //            cbLeft.BackColor = Color.Green;
        //        }
        //        else
        //        {
        //            cbLeft.BackColor = SystemColors.Control;
        //        }
        //        if (rightSen == 1)
        //        {
        //            cbRight.BackColor = Color.Green;
        //        }
        //        else
        //        {
        //            cbRight.BackColor = SystemColors.Control;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi cảm biến: {ex.Message}");
        //    }
        //}
        //private void InitializeTimer()
        //{
        //    updateTimer = new Timer();
        //    updateTimer.Interval = 1000;
        //    updateTimer.Tick += new EventHandler(UpdateReadyStatus);
        //    updateTimer.Start();
        //}
        //private async void UpdateReadyStatus(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lbVinNumber.Text = this.serialNumber;
        //        // Lấy giá trị OPC
        //        int checkStatus = await Task.Run(() => (int)opcManager.GetOPCValue(opcHLCounter));
        //        Invoke((Action)(() =>
        //         {
        //             switch (checkStatus)
        //             {
        //                 case 0:
        //                     cbReady.BackColor = SystemColors.Control;
        //                     lbHBRIntensity.Text = "0.0";
        //                     lbHBRVerticalDeviation.Text = "0.0";
        //                     lbHBRHorizontalDeviation.Text = "0.0";

        //                     lbLBRIntensity.Text = "0.0";
        //                     lbLBRVerticalDeviation.Text = "0.0";
        //                     lbLBRHorizontalDeviation.Text = "0.0";

        //                     lbHBLIntensity.Text = "0.0";
        //                     lbHBLVerticalDeviation.Text = "0.0";
        //                     lbHBLHorizontalDeviation.Text = "0.0";

        //                     lbLBLIntensity.Text = "0.0";
        //                     lbLBLVerticalDeviation.Text = "0.0";
        //                     lbLBLHorizontalDeviation.Text = "0.0";
        //                     tbHeadLights.Visible = false;
        //                     lbTitle.Visible = true;
        //                     isReady = false;
        //                     break;
        //                 case 1: // Xe vào vị trí
        //                     cbReady.BackColor = Color.Green; // Đèn xanh sáng
        //                     isReady = false; // Chưa sẵn sàng lưu
        //                     tbHeadLights.Visible = true;
        //                     lbTitle.Visible = false;
        //                     break;

        //                 case 2: // Bắt đầu đo
        //                     cbReady.BackColor = Color.Green; // Đèn xanh sáng
        //                     isReady = true; // Sẵn sàng lưu sau khi đo
        //                     lbTitle.Visible = false;
        //                     tbHeadLights.Visible = true;
        //                     if (turnSignalTimer != null)
        //                     {
        //                         turnSignalTimer.Stop(); // Dừng Timer
        //                         turnSignalTimer.Dispose(); // Giải phóng tài nguyên
        //                         turnSignalTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
        //                     }
        //                     if (!autoTestCheck)
        //                     {
        //                         byte[] autoTest = { 0x41 };
        //                         comConnect.SendRequest(autoTest);
        //                         autoTestCheck = true;
        //                     }
        //                     break;

        //                 case 3: // Quá trình đo hoàn tất, lưu vào DB
        //                     cbReady.BackColor = Color.Green; // Đèn xanh
        //                     tbHeadLights.Visible = true;
        //                     lbTitle.Visible = false;
        //                     if (isReady)
        //                     {
        //                         SaveDataToDatabase(); // Ghi dữ liệu vào DB
        //                         isReady = false; // Đặt lại trạng thái
        //                     }
        //                     break;
        //                 case 4: // Xe tiếp theo
        //                     cbReady.BackColor = SystemColors.Control;
        //                     isReady = false; // Đặt lại trạng thái
        //                     tbHeadLights.Visible = true;
        //                     lbTitle.Visible = false;
        //                     comConnect.CloseConnection();
        //                     OpenOrReplaceFormWithSerial<frmFogLights>(this.serialNumber);
        //                     break;

        //                 default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
        //                     cbReady.BackColor = SystemColors.Control; // Màu mặc định
        //                     isReady = false;
        //                     lbTitle.Visible = true;
        //                     break;
        //             }
        //         }));
        //    }
        //    catch
        //    {
        //    }
        //}
        //private void OpenOrReplaceFormWithSerial<T>(string serialNumber) where T : Form
        //{
        //    // 🔹 Kiểm tra xem form đã mở chưa
        //    var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

        //    if (existingForm != null)
        //    {
        //        existingForm.Close(); // 🔥 Đóng form cũ trước khi mở form mới
        //    }

        //    // 🔹 Sử dụng Reflection để khởi tạo form với `serialNumber`
        //    var form = (T)Activator.CreateInstance(typeof(T), serialNumber);
        //    form.Show();

        //    // 🔹 Đóng form hiện tại
        //    this.Close();
        //}
        private void ResetHeadlightUI()
        {
            cbReady.BackColor = SystemColors.Control;
            tbHeadLights.Visible = false;
            lbTitle.Visible = true;
            isReady = false;

            lbHBRIntensity.Text = lbHBRVerticalDeviation.Text = lbHBRHorizontalDeviation.Text = "0.0";
            lbLBRIntensity.Text = lbLBRVerticalDeviation.Text = lbLBRHorizontalDeviation.Text = "0.0";
            lbHBLIntensity.Text = lbHBLVerticalDeviation.Text = lbHBLHorizontalDeviation.Text = "0.0";
            lbLBLIntensity.Text = lbLBLVerticalDeviation.Text = lbLBLHorizontalDeviation.Text = "0.0";
        }
        private void MoveToNextCar()
        {
            cbReady.BackColor = SystemColors.Control;
            Form currentForm = this;

            this.BeginInvoke(new Action(() =>
            {
                if (Application.OpenForms.OfType<frmFogLights>().Any())
                    return;

                var form = new frmFogLights(this.serialNumber);
                form.Show();

                currentForm.Close();
            }));
        }
        private decimal ConvertToDecimal(object value)
        {
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }
        private void LoadVehicleStandards(string serialNumber)
        {
            lbVinNumber.Text = this.serialNumber;
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
                    minHBHeight = ConvertToDecimal(standard["MinLightHeight"]);
                    maxHBHeight = ConvertToDecimal(standard["MaxLightHeight"]);
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
                string rightHBLightHeight = Encoding.ASCII.GetString(data, 34, 4);

                string rightLBHorizontalDeviation = Encoding.ASCII.GetString(data, 20, 5);   // Lệch ngang Right LB (5 bytes)
                string rightLBVerticalDeviation = Encoding.ASCII.GetString(data, 25, 5);     // Lệch dọc Right LB (5 bytes)
                                                                                             // string rightLBLightIntensity = Encoding.ASCII.GetString(data, 30, 4);        // Cường độ Right LB (4 bytes)
                string rightLBLightHeight = Encoding.ASCII.GetString(data, 16, 4);

                // Xử lý 34 byte của đèn trái (Left Headlight)
                string leftHBHorizontalDeviation = Encoding.ASCII.GetString(data, 45, 5);    // Lệch ngang Left HB (5 bytes)
                string leftHBVerticalDeviation = Encoding.ASCII.GetString(data, 50, 5);      // Lệch dọc Left HB (5 bytes)
                string leftHBLightIntensity = Encoding.ASCII.GetString(data, 55, 4);         // Cường độ Left HB (4 bytes)
                string leftHBLightHeight = Encoding.ASCII.GetString(data, 77, 4);

                string leftLBHorizontalDeviation = Encoding.ASCII.GetString(data, 63, 5);    // Lệch ngang Left LB (5 bytes)
                string leftLBVerticalDeviation = Encoding.ASCII.GetString(data, 68, 5);      // Lệch dọc Left LB (5 bytes)
                //string leftLBLightIntensity = Encoding.ASCII.GetString(data, 73, 4);         // Cường độ Left LB (4 bytes)
                string leftLBLightHeight = Encoding.ASCII.GetString(data, 59, 4);

                // Chuyển đổi chuỗi ASCII thành số thực
                this.rightHBHorizontalValue = ConvertToPercentage(rightHBHorizontalDeviation);
                this.rightHBVerticalValue = ConvertToPercentage(rightHBVerticalDeviation);
                this.rightHBIntensityValue = ConvertToCd(rightHBLightIntensity);
                this.rightHBHeightValue = ConvertToMM(rightHBLightHeight);

                this.rightLBHorizontalValue = ConvertToPercentage(rightLBHorizontalDeviation);
                this.rightLBVerticalValue = ConvertToPercentage(rightLBVerticalDeviation);
                //this.rightLBIntensityValue = ConvertToCd(rightLBLightIntensity);
                this.rightLBHeightValue = ConvertToMM(rightLBLightHeight);

                this.leftHBHorizontalValue = ConvertToPercentage(leftHBHorizontalDeviation);
                this.leftHBVerticalValue = ConvertToPercentage(leftHBVerticalDeviation);
                this.leftHBIntensityValue = ConvertToCd(leftHBLightIntensity);
                this.leftHBHeightValue = ConvertToMM(leftHBLightHeight);

                this.leftLBHorizontalValue = ConvertToPercentage(leftLBHorizontalDeviation);
                this.leftLBVerticalValue = ConvertToPercentage(leftLBVerticalDeviation);
                //this.leftLBIntensityValue = ConvertToCd(leftLBLightIntensity);
                this.leftLBHeightValue = ConvertToMM(leftLBLightHeight);

                this.Invoke(new Action(() =>
                {
                    lbHBRIntensity.Text = rightHBIntensityValue.ToString();
                    lbHBRVerticalDeviation.Text = rightHBVerticalValue.ToString();
                    lbHBRHorizontalDeviation.Text = rightHBHorizontalValue.ToString();
                    lbHBRHeight.Text = rightHBHeightValue.ToString();

                    //lbLBRIntensity.Text = rightLBIntensityValue.ToString();
                    lbLBRVerticalDeviation.Text = rightLBVerticalValue.ToString();
                    lbLBRHorizontalDeviation.Text = rightLBHorizontalValue.ToString();
                    lbLBRHeight.Text = rightLBHeightValue.ToString();

                    lbHBLIntensity.Text = leftHBIntensityValue.ToString();
                    lbHBLVerticalDeviation.Text = leftHBVerticalValue.ToString();
                    lbHBLHorizontalDeviation.Text = leftHBHorizontalValue.ToString();
                    lbHBLHeight.Text = leftHBHeightValue.ToString();

                    //lbLBLIntensity.Text = leftLBIntensityValue.ToString();
                    lbLBLVerticalDeviation.Text = leftLBVerticalValue.ToString();
                    lbLBLHorizontalDeviation.Text = leftLBHorizontalValue.ToString();
                    lbLBLHeight.Text = leftLBHeightValue.ToString();

                    // Kiểm tra và đổi màu cho Right High Beam
                    lbHBRIntensity.ForeColor = rightHBIntensityValue >= minHBIntensity ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBRVerticalDeviation.ForeColor = (rightHBVerticalValue >= minDiffVertiHB && rightHBVerticalValue <= maxDiffVertiHB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBRHorizontalDeviation.ForeColor = (rightHBHorizontalValue >= minDiffHoriHB && rightHBHorizontalValue <= maxDiffHoriHB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBRHeight.ForeColor = (rightHBHeightValue >= minHBHeight && rightHBHeightValue <= maxHBHeight) ? SystemColors.HotTrack : Color.DarkRed;

                    // Kiểm tra và đổi màu cho Right Low Beam
                    lbLBRIntensity.ForeColor = rightLBIntensityValue >= minLBIntensity ? SystemColors.HotTrack : Color.DarkRed;
                    lbLBRVerticalDeviation.ForeColor = (rightLBVerticalValue >= minDiffVertiLB && rightLBVerticalValue <= maxDiffVertiLB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbLBRHorizontalDeviation.ForeColor = (rightLBHorizontalValue >= minDiffHoriLB && rightLBHorizontalValue <= maxDiffHoriLB) ? SystemColors.HotTrack : Color.DarkRed;

                    // Kiểm tra và đổi màu cho Left High Beam
                    lbHBLIntensity.ForeColor = leftHBIntensityValue >= minHBIntensity ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBLVerticalDeviation.ForeColor = (leftHBVerticalValue >= minDiffVertiHB && leftHBVerticalValue <= maxDiffVertiHB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBLHorizontalDeviation.ForeColor = (leftHBHorizontalValue >= minDiffHoriHB && leftHBHorizontalValue <= maxDiffHoriHB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbHBLHeight.ForeColor = (leftHBHeightValue >= minHBHeight && leftHBHeightValue <= maxHBHeight) ? SystemColors.HotTrack : Color.DarkRed;

                    // Kiểm tra và đổi màu cho Left Low Beam
                    lbLBLIntensity.ForeColor = leftLBIntensityValue >= minLBIntensity ? SystemColors.HotTrack : Color.DarkRed;
                    lbLBLVerticalDeviation.ForeColor = (leftLBVerticalValue >= minDiffVertiLB && leftLBVerticalValue <= maxDiffVertiLB) ? SystemColors.HotTrack : Color.DarkRed;
                    lbLBLHorizontalDeviation.ForeColor = (leftLBHorizontalValue >= minDiffHoriLB && leftLBHorizontalValue <= maxDiffHoriLB) ? SystemColors.HotTrack : Color.DarkRed;

                    isDataCollected = true;
                    opcManager.SetOPCValue(opcHLCounter, 3);
                }));
            }
        }
        private decimal ConvertToCd(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result / 10; // Đơn vị gửi về là x100cd, chia 100 để ra cd
            }
            return 0;
        }
        private decimal ConvertToPercentage(string value)
        {
            if (value.StartsWith("+"))
            {
                value = value.Substring(1); // Loại bỏ dấu '+'
            }
            if (decimal.TryParse(value, out decimal result))
            {
                return result / 10; // Quy đổi từ cm/10m sang %
            }
            return 0;
        }
        private decimal ConvertToMM(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result; // đưa cm về mm
            }
            return 0;
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
                if (isReady)
                {
                    SaveDataToDatabase();
                }

                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
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
            sqlHelper.SaveHeadlightsData(this.serialNumber, this.leftHBIntensityValue, this.leftHBVerticalValue, this.leftHBHorizontalValue,
                                                                this.rightHBIntensityValue, this.rightHBVerticalValue, this.rightHBHorizontalValue,
                                                                this.leftLBIntensityValue, this.leftLBVerticalValue, this.leftLBHorizontalValue,
                                                                this.rightLBIntensityValue, this.rightLBVerticalValue, this.rightLBHorizontalValue,
                                                                this.rightHBHeightValue, this.rightLBHeightValue, this.leftHBHeightValue, this.leftLBHeightValue);
        }
        private void StopSensorMonitoring()
        {
            sensorCancellationTokenSource?.Cancel();
            sensorCancellationTokenSource?.Dispose();
            sensorCancellationTokenSource = null;
        }
        private void frmCosLightL_Load(object sender, EventArgs e)
        {
            comConnect.OpenConnection();
            LoadVehicleStandards(serialNumber);
        }
        private void frmCosLightL_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (updateTimer != null)
            //{
            //    updateTimer.Stop(); // Dừng Timer
            //    updateTimer.Dispose(); // Giải phóng tài nguyên
            //    updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            //}
            //if (turnSignalTimer != null)
            //{
            //    turnSignalTimer.Stop(); // Dừng Timer
            //    turnSignalTimer.Dispose(); // Giải phóng tài nguyên
            //    turnSignalTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            //}
            //e.Cancel = false;
            if (opcCancellationTokenSource != null)
            {
                opcCancellationTokenSource.Cancel();
                opcCancellationTokenSource.Dispose();
                opcCancellationTokenSource = null;
            }
        }
    }
}
