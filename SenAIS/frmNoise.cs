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
    public partial class frmNoise : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private COMConnect comConnect;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal noiseValue;
        private bool isReady = false;
        public frmNoise(Form parent, OPCItem opcCounterPos, string serialNumber)
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
        private void UpdateReadyStatus(object sender, EventArgs e)
        {
            //int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");
            int checkStatus = 1;
            if (checkStatus == 1)
            {
                cbReady.BackColor = Color.Green;
                //await Task.Delay(10000); // Chờ 10 giây
                isReady = true;

                //Lấy giá trị Độ ồn
                // Gửi lệnh để bắt đầu nhận dữ liệu thời gian thực
                byte[] startcommand = { 0xB8 }; // gửi lệnh bắt đầu phát hiện
                comConnect.SendRequest(startcommand);
                //CheckCounterPosition();
            }
            else
            {
                cbReady.BackColor = SystemColors.Control;
                isReady = false;
            }
            // Reset lỗi để lần sau có thể hiển thị lại lỗi nếu cần
            OPCUtility.ResetErrorFlag();
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                opcCounterPos.Write(2); // Giá trị cho form chờ hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(2);
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
                opcCounterPos.Write(4); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveNoiseData(this.serialNumber, this.noiseValue);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition != 1)
            {
                SaveDataToDatabase();
            }
        }
        public void ProcessNoiseData(byte[] data)
        {
            MessageBox.Show("ProcessNoiseData");
            try
            {
                if (data.Length == 9 && data[0] == 0x01 && data[8] == 0xFF) // Check start and end byte
                {
                    // Extract sound level data (5 bytes in ASCII)
                    string soundLevelString = Encoding.ASCII.GetString(data, 1, 5);

                    if (double.TryParse(soundLevelString, out double soundLevel))
                    {
                        this.Invoke(new Action(() =>
                        {
                            // Update UI with the sound level value
                            lbNoise.Text = soundLevel.ToString("F1");
                        }));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý dữ liệu tiếng ồn: " + ex.Message);
            }

        }
        private void frmNoise_Load(object sender, EventArgs e)
        {
            comConnect.OpenConnection();
            //byte[] startcommand = { 0xB2, 0xB8, 0xB5 }; // gửi lệnh bắt đầu phát hiện
            //comConnect.SendRequest(startcommand);
        }

        private void frmNoise_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
    }
}
