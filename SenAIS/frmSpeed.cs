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
    public partial class frmSpeed : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal speedValue;
        private bool isReady = false;
        private bool isUpdatingStatus = false;

        public frmSpeed(Form parent, OPCItem opcCounterPos, string serialNumber)
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
            if (isUpdatingStatus) return; // Nếu hàm đang chạy, thoát ra
            isUpdatingStatus = true; // Đặt cờ khi bắt đầu chạy

            try
            {
                int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");

                if (checkStatus == 1)
                {
                    cbReady.BackColor = Color.Green;
                    await Task.Delay(10000); // Chờ 10 giây
                    isReady = true;

                    double speedA = sqlHelper.GetParaValue("Speed", "ParaA");
                    double speedResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Speed_Result");
                    double speed = speedResult / speedA;
                    lbSpeed.Text = speed.ToString("F1");

                    this.speedValue = Convert.ToDecimal(speed.ToString("F1"));
                    CheckCounterPosition();
                }
                else
                {
                    cbReady.BackColor = SystemColors.Control;
                    isReady = false;
                }

                // Reset lỗi để lần sau có thể hiển thị lại lỗi nếu cần
                OPCUtility.ResetErrorFlag();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in UpdateReadyStatus: {ex.Message}");
                updateTimer.Stop(); // Dừng timer nếu có lỗi nghiêm trọng
            }
            finally
            {
                isUpdatingStatus = false; // Giải phóng cờ khi kết thúc
            }
        }
        private void btnPreSpeed_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị CounterPosition và mở form trước
            try
            {
                opcCounterPos.Write(0); // Giá trị cho form chờ hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị CounterPosition: " + ex.Message);
            }
        }

        private void btnNextSpeed_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị CounterPosition và mở form tiếp theo
            try
            {
                opcCounterPos.Write(2); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị CounterPosition: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveSpeedData(this.serialNumber, this.speedValue);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition != 1)
            {
                SaveDataToDatabase();
            }
        }

        private void frmSpeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateTimer != null)
            {
                updateTimer.Stop();    // Dừng Timer khi form đóng
                updateTimer.Dispose(); // Giải phóng tài nguyên Timer
            }
        }
    }
}
