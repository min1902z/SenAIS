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
        public frmSideSlip(Form parent, OPCItem opcCounterPos)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 5000; // Kiểm tra mỗi giây
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();
        }
        private void UpdateReadyStatus(object sender, EventArgs e)
        {
            int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");

            if (checkStatus == 1)
            {
                cbReady.BackColor = Color.Green;
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
            }
            else
            {
                cbReady.BackColor = SystemColors.Control;
            }
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị CounterPosition và mở form trước
            try
            {
                opcCounterPos.Write(1); // Giá trị cho form chờ hoặc giá trị tương ứng
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
                ((frmInspection)parentForm).ProcessMeasurement(3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị CounterPosition: " + ex.Message);
            }
        }
        
    }
}
