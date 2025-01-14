using OPCAutomation;
using System;
using System.Drawing;
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
        public decimal diffHandBrake;
        public decimal sumHandBrake;
        private bool isReady = false;
        public frmHandBrake(Form parent, OPCItem opcCounterPos, string serialNumber)
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
            //int checkStatus = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");
            int checkStatus = 1;
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
                    this.diffHandBrake = Convert.ToDecimal(diffBrake.ToString("F1"));
                    this.sumHandBrake = Convert.ToDecimal(sumBrake.ToString("F1"));
                    // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
                    bool isSumStandard = sqlHelper.CheckValueAgainstStandard("HandBrake", sumHandBrake, this.serialNumber);
                    bool isDiffStandard = sqlHelper.CheckValueAgainstStandard("DiffHandBrake", diffHandBrake, this.serialNumber);

                    if (isSumStandard && isDiffStandard)
                    {
                        lbSum_Brake.BackColor = SystemColors.ControlLight;
                        lbDiff_Brake.BackColor = SystemColors.ControlLight;
                        await Task.Delay(15000); // Đợi thêm 15 giây trước khi đổi trạng thái
                        OPCUtility.SetOPCValue("Hyundai.OCS10.Test1", 3); // Đặt Test1 thành 3
                    }
                    else
                    {
                        lbSum_Brake.BackColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                        lbDiff_Brake.BackColor = Color.DarkRed;
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
                    opcCounterPos.Write(4); // Chuyển vị trí OPC về form tiếp theo
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
            sqlHelper.SaveHandBrakeData(this.serialNumber, this.handLeftBrake, this.handRightBrake);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition == 3)
            {
                SaveDataToDatabase();
            }
        }
    }
}
