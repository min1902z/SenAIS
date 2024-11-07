using OPCAutomation;
using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmHeadlights : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
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
        private bool isReady = false;
        private bool autoTestCheck = false;
        public bool isDataCollected = false;
        public frmHeadlights(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
            comConnect = new COMConnect("COM7", 2400, this);
            sqlHelper = new SQLHelper();
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
            lbEngineNumber.Text = this.serialNumber;
            // Lấy giá trị OPC
            //int checkStatus = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");
            int checkStatus = 1;
            switch (checkStatus)
            {
                case 1: // Xe vào vị trí
                    cbReady.BackColor = Color.Green; // Đèn xanh sáng
                    isReady = false; // Chưa sẵn sàng lưu
                    break;

                case 2: // Bắt đầu đo
                    cbReady.BackColor = Color.Green; // Đèn xanh sáng
                    isReady = true; // Sẵn sàng lưu sau khi đo
                    await Task.Delay(10000); // Chờ 10 giây trước khi bắt đầu đo
                    if (!autoTestCheck)
                    {
                        await Task.Delay(1000); // Đợi 10 giây lần đầu

                        byte[] autoTest = { 0x41 };
                        comConnect.SendRequest(autoTest);
                        autoTestCheck = true;
                    }
                    // Gửi request đến NHD6109 để lấy dữ liệu
                    if (comConnect.respone47H == true && !isDataCollected)
                    {
                        byte[] request = { 0x4E, 0x4D };
                        comConnect.SendRequest(request);
                    }

                    if (isDataCollected)
                    {
                        OPCUtility.SetOPCValue("Hyundai.OCS10.Test1", 3); // Đặt Test1 thành 3
                    }
                    break;

                case 3: // Quá trình đo hoàn tất, lưu vào DB
                    cbReady.BackColor = Color.Green; // Đèn xanh
                    if (isReady)
                    {
                        CheckCounterPosition(); // Ghi dữ liệu vào DB
                        isReady = false; // Đặt lại trạng thái

                        await Task.Delay(15000); // Chờ 15 giây trước khi tăng SerialNumber

                        string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber); // Lấy SerialNumber tiếp theo
                        if (!string.IsNullOrEmpty(nextSerialNumber))
                        {
                            this.serialNumber = nextSerialNumber; // Cập nhật SerialNumber
                            lbEngineNumber.Text = this.serialNumber; // Cập nhật lbEngineNumber
                        }
                        else
                        {
                            MessageBox.Show("Không có xe tiếp theo để đo.");
                        }
                    }
                    break;

                default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                    cbReady.BackColor = SystemColors.Control; // Màu mặc định
                    isReady = false;
                    break;
            }

        }
        // Method to process and display data on frmCosLightL
        public void ProcessNHD6109Data(byte[] data)
        {
            if (data.Length >= 68 && data[0] == 0x01)
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
                this.rightHBVerticalValue = decimal.Parse(rightHBVerticalDeviation.Replace("+", "").Replace("-", "-"));
                this.rightHBIntensityValue = decimal.Parse(rightHBLightIntensity);

                this.rightLBHorizontalValue = decimal.Parse(rightLBHorizontalDeviation.Replace("+", "").Replace("-", "-"));
                this.rightLBVerticalValue = decimal.Parse(rightLBVerticalDeviation.Replace("+", "").Replace("-", "-"));
                this.rightLBIntensityValue = decimal.Parse(rightLBLightIntensity);

                this.leftHBHorizontalValue = decimal.Parse(leftHBHorizontalDeviation.Replace("+", "").Replace("-", "-"));
                this.leftHBVerticalValue = decimal.Parse(leftHBVerticalDeviation.Replace("+", "").Replace("-", "-"));
                this.leftHBIntensityValue = decimal.Parse(leftHBLightIntensity);

                this.leftLBHorizontalValue = decimal.Parse(leftLBHorizontalDeviation.Replace("+", "").Replace("-", "-"));
                this.leftLBVerticalValue = decimal.Parse(leftLBVerticalDeviation.Replace("+", "").Replace("-", "-"));
                this.leftLBIntensityValue = decimal.Parse(leftLBLightIntensity);

                this.Invoke(new Action(() =>
                {
                    lbHBRIntensity.Text = rightHBIntensityValue.ToString();
                    lbHBRVerticalDeviation.Text = rightHBVerticalValue.ToString();
                    lbHBRHorizontalDeviation.Text = rightHBHorizontalValue.ToString();

                    lbLBRIntensity.Text = rightLBIntensityValue.ToString();
                    lbLBRVerticalDeviation.Text = rightLBVerticalValue.ToString();
                    lbLBRHorizontalDeviation.Text = rightLBHorizontalValue.ToString();

                    lbHBLIntensity.Text = leftHBIntensityValue.ToString();
                    lbHBLVerticalDeviation.Text = leftHBVerticalValue.ToString();
                    lbHBLHorizontalDeviation.Text = leftHBHorizontalValue.ToString();

                    lbLBLIntensity.Text = leftLBIntensityValue.ToString();
                    lbLBLVerticalDeviation.Text = leftLBVerticalValue.ToString();
                    lbLBLHorizontalDeviation.Text = leftLBHorizontalValue.ToString();
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
                    opcCounterPos.Write(4); // Chuyển vị trí OPC về form tiếp theo
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
            sqlHelper.SaveHeadlightsData(this.serialNumber, this.leftHBIntensityValue, this.leftHBVerticalValue, this.leftHBHorizontalValue,
                                                                    this.rightHBIntensityValue, this.rightHBVerticalValue, this.rightHBHorizontalValue,
                                                                    this.leftLBIntensityValue, this.leftLBVerticalValue, this.leftLBHorizontalValue,
                                                                    this.rightLBIntensityValue, this.rightLBVerticalValue, this.rightLBHorizontalValue);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition == 3)
            {
                SaveDataToDatabase();
            }
        }

        private void frmCosLightL_Load(object sender, EventArgs e)
        {
            comConnect.OpenConnection();
        }

        private void frmCosLightL_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
    }
}
