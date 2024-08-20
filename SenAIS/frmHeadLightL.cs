using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SenAIS
{
    public partial class frmHeadLightL : Form
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
        
        public frmHeadLightL(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 2000; // Kiểm tra mỗi giây
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

                UpdateLabels();

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

        private void btnPre_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị T99 và mở form trước
            try
            {
                opcCounterPos.Write(8); // Giá trị cho form chờ hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(8);
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
                opcCounterPos.Write(10); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
            }
        }
        private void frmHeadLightL_Load(object sender, EventArgs e)
        {
            comConnect.OpenConnection();
        }

        private void frmHeadLightL_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
        public void UpdateLabels()
        {
            lbIntensity.Text = intensity.ToString();
            lbHorizontalDeviation.Text = horiDeviation.ToString();
            lbVerticalDeviation.Text = vertiDeviation.ToString();
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveLeftHeadLightData(this.serialNumber, this.intensity, this.vertiDeviation, this.horiDeviation);
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
