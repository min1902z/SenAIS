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
    public partial class frmRearWeight : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        public frmRearWeight(Form parent, OPCItem opcCounterPos)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            sqlHelper = new SQLHelper("Server=LAPTOP-G4Q0RA59\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 10000; // Kiểm tra mỗi giây
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();
        }
        private void UpdateReadyStatus(object sender, EventArgs e)
        {
            int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");

            if (checkStatus == 1)
            {
                cbReady.BackColor = Color.Green;
                double weightRightA = 1.0;
                weightRightA = sqlHelper.GetParaValue("RightWeight", "ParaA");
                double leftWeightResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Weight_Rear_Result");
                double rightWeightResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Weight_Rear_Result");
                double leftWeight = leftWeightResult / weightRightA;
                double rightWeight = rightWeightResult / weightRightA;
                double sumWeight = leftWeight + rightWeight;

                lbLeft_Weight.Text = leftWeight.ToString("F1");
                lbRight_Weight.Text = rightWeight.ToString("F1");
                lbSum_Weight.Text = sumWeight.ToString("F1");
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
                opcCounterPos.Write(7); // Giá trị cho form chờ hoặc giá trị tương ứng
                ((frmInspection)parentForm).ProcessMeasurement(7);
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
                opcCounterPos.Write(9); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                ((frmInspection)parentForm).ProcessMeasurement(9);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị CounterPosition: " + ex.Message);
            }
        }
    }
}
