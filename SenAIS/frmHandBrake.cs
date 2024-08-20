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
    public partial class frmHandBrake : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal handLeftBrake;
        public decimal handRightBrake;
        private bool isReady = false;
        public frmHandBrake(Form parent, OPCItem opcCounterPos, string serialNumber)
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

                double brakeRightA = 1.0;
                brakeRightA = sqlHelper.GetParaValue("RightBrake", "ParaA");
                double leftBrakeResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Brake_Rear_Result");
                double rightBrakeResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Brake_Rear_Result");
                double leftBrake = leftBrakeResult / brakeRightA;
                double rightBrake = rightBrakeResult / brakeRightA;
                double diffBrake = 0.0;
                if (leftBrake > rightBrake)
                {
                    diffBrake = 100 * (leftBrake - rightBrake) / leftBrake;
                }
                else
                {
                    diffBrake = 100 * (rightBrake - leftBrake) / rightBrake;
                }

                double sumBrake = leftBrake + rightBrake;

                lbLeft_Brake.Text = leftBrake.ToString("F1");
                lbRight_Brake.Text = rightBrake.ToString("F1");
                lbDiff_Brake.Text = diffBrake.ToString("F1");
                lbSum_Brake.Text = sumBrake.ToString("F1");

                this.handLeftBrake = Convert.ToDecimal(leftBrake.ToString("F1"));
                this.handRightBrake = Convert.ToDecimal(rightBrake.ToString("F1"));
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
            sqlHelper.SaveHandBrakeData(this.serialNumber, this.handLeftBrake, this.handRightBrake);
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
