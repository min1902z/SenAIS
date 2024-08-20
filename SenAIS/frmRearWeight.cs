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
        private string serialNumber;
        public decimal rearLeftWeight;
        public decimal rearRightWeight;
        private bool isReady = false;
        public frmRearWeight(Form parent, OPCItem opcCounterPos, string serialNumber)
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
            updateTimer.Interval = 10000; // Kiểm tra mỗi giây
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

                this.rearLeftWeight = Convert.ToDecimal(leftWeight.ToString("F1"));
                this.rearRightWeight = Convert.ToDecimal(rightWeight.ToString("F1"));
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
                opcCounterPos.Write(7); // Giá trị cho form chờ hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
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
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(9);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị CounterPosition: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveRearWeightData(this.serialNumber, this.rearLeftWeight, this.rearRightWeight);
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
