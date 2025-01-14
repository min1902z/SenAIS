using OPCAutomation;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public frmSpeed(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
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

                    double speedA = sqlHelper.GetParaValue("Speed", "ParaA");
                    double speedResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Speed_Result");
                    double speed = speedResult / speedA;
                    lbSpeed.Text = speed.ToString("F1");

                    this.speedValue = Convert.ToDecimal(speed.ToString("F1"));

                    // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
                    bool isValueInStandard = sqlHelper.CheckValueAgainstStandard("Speed", this.speedValue, this.serialNumber);

                    if (isValueInStandard)
                    {
                        lbSpeed.BackColor = SystemColors.ControlLight;
                        await Task.Delay(15000); // Đợi thêm 15 giây trước khi đổi trạng thái
                        OPCUtility.SetOPCValue("Hyundai.OCS10.Test1", 3); // Đặt Test1 thành 3
                    }
                    else
                    {
                        lbSpeed.BackColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
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
        private void btnPreSpeed_Click(object sender, EventArgs e)
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

        private void btnNextSpeed_Click(object sender, EventArgs e)
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
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveSpeedData(this.serialNumber, this.speedValue);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition == 3)
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
