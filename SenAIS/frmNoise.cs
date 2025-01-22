using OPCAutomation;
using System;
using System.Configuration;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmNoise : Form
    {
        private COMConnect comConnect;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal noiseValue = 0;
        private bool isReady = false;
        private bool hasProcessedNextVin = false; // Cờ kiểm soát việc next số VIN
        private static readonly string opcSpeedCounter = ConfigurationManager.AppSettings["Noise_Counter"];
        public frmNoise(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            comConnect = new COMConnect(ConfigurationManager.AppSettings["COM_Noise"], 300, this);
            sqlHelper = new SQLHelper();
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
            lbEngineNumber.Text = this.serialNumber;
            // Lấy giá trị OPC
            int checkStatus = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");

            switch (checkStatus)
            {
                case 1: // Xe vào vị trí
                    cbReady.BackColor = Color.Green; // Đèn xanh sáng
                    isReady = false; // Chưa sẵn sàng lưu
                    break;

                case 2: // Bắt đầu đo
                    cbReady.BackColor = Color.Green; // Đèn xanh sáng
                    isReady = true; // Sẵn sàng lưu sau khi đo
                    await Task.Delay(10000); // Chờ 10 giây trước khi bắt đầu đo
                    byte[] startCommand = { 0xB8 };
                    comConnect.SendRequest(startCommand); // Gửi request để lấy giá trị

                    // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
                    bool isValueInStandard = sqlHelper.CheckValueAgainstStandard("Noise", noiseValue, this.serialNumber);

                    if (isValueInStandard)
                    {
                        lbNoise.BackColor = SystemColors.ControlLight;
                        await Task.Delay(15000); // Đợi thêm 15 giây trước khi đổi trạng thái
                        OPCUtility.SetOPCValue("Hyundai.OCS10.Test1", 3); // Đặt Test1 thành 3
                    }
                    else
                    {
                        lbNoise.BackColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                    }
                    break;

                case 3: // Quá trình đo hoàn tất, lưu vào DB
                    cbReady.BackColor = Color.Green; // Đèn xanh
                    if (isReady)
                    {
                        SaveDataToDatabase(); // Ghi dữ liệu vào DB
                        isReady = false; // Đặt lại trạng thái

                        await Task.Delay(15000); // Chờ 15 giây trước khi tăng SerialNumber

                        string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber); // Lấy SerialNumber tiếp theo
                        if (!string.IsNullOrEmpty(nextSerialNumber))
                        {
                            this.serialNumber = nextSerialNumber; // Cập nhật SerialNumber
                            lbEngineNumber.Text = this.serialNumber; // Cập nhật lbEngineNumber
                        }
                        else
                        {
                            MessageBox.Show("Không có xe tiếp theo để đo.");
                        }
                    }
                    break;

                default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                    cbReady.BackColor = SystemColors.Control; // Màu mặc định
                    isReady = false;
                    break;
            }
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy SerialNumber trước đó
                string previousSerialNumber = sqlHelper.GetPreviousSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(previousSerialNumber))
                {
                    // Cập nhật serialNumber mới
                    this.serialNumber = previousSerialNumber;
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
                }
                else
                {
                    MessageBox.Show("Không có xe trước đó.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi Số Máy: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
                }
                else
                {
                    MessageBox.Show("Không có xe tiếp theo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi Số Máy: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveNoiseData(this.serialNumber, this.noiseValue);
        }
        public void ProcessNoiseData(byte[] data)
        {
            try
            {
                if (data[0] == 0x01) // Check start and end byte
                {
                    // Extract sound level data (5 bytes in ASCII)
                    string soundLevelString = Encoding.ASCII.GetString(data, 1, 5);

                    if (double.TryParse(soundLevelString, out double soundLevel))
                    {
                        this.Invoke(new Action(() =>
                        {
                            // Update UI with the sound level value
                            lbNoise.Text = soundLevel.ToString("F1");
                            this.noiseValue = Convert.ToDecimal(lbNoise.Text);
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
        }
        private void frmNoise_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
    }
}
