using OPCAutomation;
using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmWhistle : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private COMConnect comConnect;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private OPCManager opcManager;
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
            sqlHelper = new SQLHelper();
            InitializeTimer();
            opcManager = new OPCManager();
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
            int checkStatus = (int)opcManager.GetOPCValue("Hyundai.OCS10.Test1");

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
                    //Lấy giá trị Còi
                    byte[] startcommand = { 0xB8 }; // gửi lệnh bắt đầu phát hiện
                    comConnect.SendRequest(startcommand);

                    // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
                    bool isValueInStandard = sqlHelper.CheckValueAgainstStandard("Whistle", this.whistle, this.serialNumber);

                    if (isValueInStandard)
                    {
                        lbWhistle.BackColor = SystemColors.Control;
                        await Task.Delay(15000); // Đợi thêm 15 giây trước khi đổi trạng thái
                        opcManager.SetOPCValue("Hyundai.OCS10.Test1", 3); // Đặt Test1 thành 3
                    }
                    else
                    {
                        lbWhistle.BackColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                    }
                    break;

                case 3: // Quá trình đo hoàn tất, lưu vào DB
                    cbReady.BackColor = Color.Green; // Đèn xanh
                    if (isReady)
                    {
                        CheckCounterPosition(); // Ghi dữ liệu vào DB
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
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu sẵn sàng
                }

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

        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu dữ liệu hiện tại
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu DB nếu đèn xanh và CP xác nhận lưu
                }
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
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveWhistleData(this.serialNumber, this.whistle);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)opcManager.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition == 3)
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
