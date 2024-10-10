using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SenAIS
{
    public partial class frmCosLightL : Form
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
        public frmCosLightL(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
            comConnect = new COMConnect("COM7", 2400, this);
            sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
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
            //int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");
            int checkStatus = 1;
            if (checkStatus == 1)
            {
                cbReady.BackColor = Color.Green;
                isReady = true;

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
                //CheckCounterPosition();
            }
            else
            {
                cbReady.BackColor = SystemColors.Control;
                isReady = false;
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
                opcCounterPos.Write(9); // Giá trị cho form chờ hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(9);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị T99 và mở form tiếp theo
            try
            {
                opcCounterPos.Write(11); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(11);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
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

            if (currentPosition != 1)
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
