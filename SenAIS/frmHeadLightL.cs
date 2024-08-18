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
        public int Intensity { get; set; }
        public int HorizontalDeviation { get; set; }
        public int VerticalDeviation { get; set; }
        public frmHeadLightL(Form parent, OPCItem opcCounterPos)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 2000; // Kiểm tra mỗi giây
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();
        }
        private void UpdateReadyStatus(object sender, EventArgs e)
        {
            int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");

            if (checkStatus == 1)
            {
                cbReady.BackColor = Color.Green;
                UpdateLabels();

            }
            else
            {
                cbReady.BackColor = SystemColors.Control;
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị T99 và mở form trước
            try
            {
                opcCounterPos.Write(8); // Giá trị cho form chờ hoặc giá trị tương ứng
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
            lbIntensity.Text = Intensity.ToString();
            lbHorizontalDeviation.Text = HorizontalDeviation.ToString();
            lbVerticalDeviation.Text = VerticalDeviation.ToString();
        }
    }
}
