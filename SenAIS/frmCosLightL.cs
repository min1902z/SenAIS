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
        public decimal intensity;
        public decimal vertiDeviation;
        public decimal horiDeviation;
        private bool isReady = false;
        public frmCosLightL(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
            comConnect = new COMConnect("COM7", this);
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
            int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");

            if (checkStatus == 1)
            {
                cbReady.BackColor = Color.Green;
                await Task.Delay(10000); // Chờ 10 giây
                isReady = true;

                // Gửi request đến NHD6109 để lấy dữ liệu
                byte[] request = { 0x4D }; // Thay đổi lệnh nếu cần thiết (4D cho CosLightL)
                comConnect.SendRequest(request);

                this.intensity = Convert.ToDecimal(intensity.ToString("F1"));
                this.vertiDeviation = Convert.ToDecimal(vertiDeviation.ToString("F1"));
                this.horiDeviation = Convert.ToDecimal(horiDeviation.ToString("F1"));
                CheckCounterPosition();
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
            // Assuming the data format is correctly parsed here
            string intensityStr = Encoding.ASCII.GetString(data, 2, 5);   // Extract Intensity (example positions)
            string verticalDeviationStr = Encoding.ASCII.GetString(data, 7, 5);  // Extract Vertical Deviation
            string horizontalDeviationStr = Encoding.ASCII.GetString(data, 12, 5);  // Extract Horizontal Deviation

            // Convert the strings to decimal or float as needed
            decimal intensity = decimal.Parse(intensityStr);
            decimal verticalDeviation = decimal.Parse(verticalDeviationStr);
            decimal horizontalDeviation = decimal.Parse(horizontalDeviationStr);

            // Update UI
            this.Invoke(new Action(() =>
            {
                lbIntensity.Text = intensity.ToString("F2");
                lbVerticalDeviation.Text = verticalDeviation.ToString("F2");
                lbHorizontalDeviation.Text = horizontalDeviation.ToString("F2");
            }));
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
            sqlHelper.SaveLeftLowBeamData(this.serialNumber, this.intensity, this.vertiDeviation, this.horiDeviation);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition != 1)
            {
                SaveDataToDatabase();
            }
        }
    }
}
