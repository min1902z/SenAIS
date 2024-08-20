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

namespace SenAIS
{
    public partial class frmSideSlip : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal sideSlip;
        private bool isReady = false;
        public frmSideSlip(Form parent, OPCItem opcCounterPos, string serialNumber)
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

                double alignA = 1.0;
                alignA = sqlHelper.GetParaValue("SideSlip", "ParaA");
                double sideSlipSign = OPCUtility.GetOPCValue("Hyundai.OCS10.SideSlip_Sign");
                double sideSlipResult = OPCUtility.GetOPCValue("Hyundai.OCS10.SideSlip_Result");
                double sideSlip = 0.0;

                if (sideSlipSign == 0)
                {
                    sideSlip = sideSlipResult / alignA;
                }
                else if(sideSlipSign == 1)
                {
                    sideSlip = -1 * (sideSlipResult / alignA);
                }
                else
                {
                    MessageBox.Show("Lỗi giá trị SideSlip_Sign. ");
                }
                lbSideSlip.Text = sideSlip.ToString("F1");

                this.sideSlip = Convert.ToDecimal(sideSlip.ToString("F1"));
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
            // Thay đổi giá trị CounterPosition và mở form trước
            try
            {
                opcCounterPos.Write(1); // Giá trị cho form chờ hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị CounterPosition: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị CounterPosition và mở form tiếp theo
            try
            {
                opcCounterPos.Write(3); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị CounterPosition: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveSideSlipData(this.serialNumber, this.sideSlip);
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
