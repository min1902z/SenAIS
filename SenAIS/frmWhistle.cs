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
    public partial class frmWhistle : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private COMConnect comConnect;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        private double maxSoundValue = 0;
        public decimal whistle;
        private bool isReady = false;
        public frmWhistle(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
            comConnect = new COMConnect("COM7", 300, this);
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
            //int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");
            int checkStatus = 1;
            if (checkStatus == 1)
            {
                cbReady.BackColor = Color.Green;
                await Task.Delay(5000); // Chờ 10 giây
                isReady = true;

                //Lấy giá trị Độ ồn
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
        private void btnNext_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị T99 và mở form tiếp theo
            try
            {
                opcCounterPos.Write(7); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(7);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị T99 và mở form trước
            try
            {
                opcCounterPos.Write(5); // Giá trị cho form chờ hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveWhistleData(this.serialNumber, this.whistle);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition != 1)
            {
                SaveDataToDatabase();
            }
        }
        public void ProcessMaxSoundData(byte[] data)
        {
            try
            {
                if (data.Length == 9 && data[0] == 0x01) // Check start and end byte
                {
                    // Xử lý và hiển thị giá trị max sound
                    string maxSoundLevel = Encoding.ASCII.GetString(data, 1, 5); // 5 bytes ASCII

                    if (double.TryParse(maxSoundLevel, out double soundLevel))
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (soundLevel > maxSoundValue)
                            {
                                maxSoundValue = soundLevel;
                                lbWhistle.Text = maxSoundValue.ToString("F1");
                                this.whistle = Convert.ToDecimal(maxSoundValue);
                            }
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý dữ liệu Còi: " + ex.Message);
            }
        }

        private void frmWhistle_Load(object sender, EventArgs e)
        {
            comConnect.OpenConnection();
        }

        private void frmWhistle_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
    }
}
