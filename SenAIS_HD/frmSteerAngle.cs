using OPCAutomation;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSteerAngle : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal leftSteerLW = 0;
        public decimal rightSteerLW = 0;
        public decimal leftSteerRW = 0;
        public decimal rightSteerRW = 0;
        private bool isReady = false;
        public frmSteerAngle(Form parent, OPCItem opcCounterPos, string serialNumber)
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
                    double leftSteerLWResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Steer_Angle_Result");
                    double rightSteerLWResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Steer_Angle_Result");
                    double leftSteerRWResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Steer_Angle_Result");
                    double rightSteerRWResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Steer_Angle_Result");
                    lbLeftSteerLW.Text = leftSteerLWResult.ToString("F1");
                    lbRightSteerLW.Text = rightSteerLWResult.ToString("F1");
                    lbLeftSteerRW.Text = leftSteerRWResult.ToString("F1");
                    lbRightSteerRW.Text = rightSteerRWResult.ToString("F1");
                    this.leftSteerLW = Convert.ToDecimal(leftSteerLWResult.ToString("F1"));
                    this.rightSteerLW = Convert.ToDecimal(rightSteerLWResult.ToString("F1"));
                    this.leftSteerRW = Convert.ToDecimal(leftSteerRWResult.ToString("F1"));
                    this.rightSteerRW = Convert.ToDecimal(rightSteerRWResult.ToString("F1"));
                    // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
                    bool isLeftSteerLWInStandard = sqlHelper.CheckValueAgainstStandard("LeftSteer", leftSteerLW, this.serialNumber);
                    bool isLeftSteerRWInStandard = sqlHelper.CheckValueAgainstStandard("LeftSteer", leftSteerRW, this.serialNumber);
                    bool isRightSteerLWInStandard = sqlHelper.CheckValueAgainstStandard("RightSteer", rightSteerLW, this.serialNumber);
                    bool isRightSteerRWInStandard = sqlHelper.CheckValueAgainstStandard("RightSteer", rightSteerRW, this.serialNumber);

                    if (isLeftSteerLWInStandard && isLeftSteerRWInStandard && isRightSteerLWInStandard && isRightSteerRWInStandard)
                    {
                        lbLeftSteerLW.BackColor = SystemColors.ControlLight;
                        lbLeftSteerRW.BackColor = SystemColors.ControlLight;
                        lbRightSteerLW.BackColor = SystemColors.ControlLight;
                        lbRightSteerRW.BackColor = SystemColors.ControlLight;
                        await Task.Delay(15000); // Đợi thêm 15 giây trước khi đổi trạng thái
                        OPCUtility.SetOPCValue("Hyundai.OCS10.Test1", 3); // Đặt Test1 thành 3
                    }
                    else if (!isLeftSteerLWInStandard)
                    {
                        lbLeftSteerLW.BackColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                    }
                    else if (!isLeftSteerRWInStandard)
                    {
                        lbLeftSteerRW.BackColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                    }
                    else if (!isRightSteerLWInStandard)
                    {
                        lbRightSteerLW.BackColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                    }
                    else if (!isRightSteerRWInStandard)
                    {
                        lbRightSteerRW.BackColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
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
            sqlHelper.SaveSteerAngleData(this.serialNumber, this.leftSteerLW, this.rightSteerLW, this.leftSteerRW, this.rightSteerRW);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition == 3)
            {
                SaveDataToDatabase();
            }
        }

        private void tbSteerAngle_Resize(object sender, EventArgs e)
        {
            // Căn giữa TextBox theo chiều ngang
            tbSteerAngle.Left = (this.ClientSize.Width - tbSteerAngle.Width) / 2;

            // Căn giữa TextBox theo chiều dọc nếu muốn
            tbSteerAngle.Top = (this.ClientSize.Height - tbSteerAngle.Height) / 2;
        }
    }
}
