using OPCAutomation;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmDieselEmission : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private OPCManager opcManager;
        private COMConnect comConnect;
        private bool isReady = false;
        private string serialNumber;
        private decimal minSpeed1;
        private decimal minSpeed2;
        private decimal minSpeed3;
        private decimal maxSpeed1;
        private decimal maxSpeed2;
        private decimal maxSpeed3;
        private decimal hsu1;
        private decimal hsu2;
        private decimal hsu3;
        private decimal avgHsu;
        private bool isRequestInProgress = false;  // To prevent sending multiple requests simultaneously
        private int currentDataRequest = 1;        // Keep track of the current request count

        public frmDieselEmission(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
            comConnect = new COMConnect("COM7", 9600, this);
            sqlHelper = new SQLHelper();
            InitializeTimer();
            opcManager = new OPCManager();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 2000; // Kiểm tra mỗi giây
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
                    if (!isRequestInProgress && currentDataRequest <= 3)
                    {
                        if (currentDataRequest == 1)
                        {
                            await Task.Delay(2000);
                        }
                        lbNotice.Text = $"Vui Lòng Đạp Ga lần {currentDataRequest}!";
                        await Task.Delay(5000);
                        byte[] commandA5 = { 0xA5, CalculateCheckCode(0xA5) };
                        comConnect.SendRequest(commandA5);
                        isRequestInProgress = true;
                    }
                    else if (currentDataRequest > 3)
                    {
                        updateTimer.Stop();

                        lbMinAvg.Text = ((minSpeed1 + minSpeed2 + minSpeed3) / 3).ToString("F1");
                        lbMaxAvg.Text = ((maxSpeed1 + maxSpeed2 + maxSpeed3) / 3).ToString("F1");
                        avgHsu = (hsu1 + hsu2 + hsu3) / 3;
                        lbHsuAvg.Text = avgHsu.ToString("F1");
                        lbNotice.Text = "Đã hoàn thành 3 lần lấy dữ liệu!";

                    }

                    // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
                    bool isValueInStandard = sqlHelper.CheckValueAgainstStandard("HSU", avgHsu, this.serialNumber);

                    if (isValueInStandard)
                    {
                        lbHsuAvg.BackColor = SystemColors.Control;
                        await Task.Delay(15000); // Đợi thêm 15 giây trước khi đổi trạng thái
                        opcManager.SetOPCValue("Hyundai.OCS10.Test1", 3); // Đặt Test1 thành 3
                    }
                    else
                    {
                        lbHsuAvg.BackColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
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
        public async void ProcessNHT6MaxData(byte[] data)
        {
            if (data.Length >= 7 && data[0] == 0xA6)
            {
                int maxRpm = (data[5] << 8) + data[6]; // Max Speed (revolving speed)
                this.Invoke(new Action(() =>
                {
                    switch (currentDataRequest)
                    {
                        case 1:
                            lbMaxSpeed1.Text = maxRpm.ToString();
                            this.maxSpeed1 = Convert.ToDecimal(maxRpm);
                            break;
                        case 2:
                            lbMaxSpeed2.Text = maxRpm.ToString();
                            this.maxSpeed2 = Convert.ToDecimal(maxRpm);
                            break;
                        case 3:
                            lbMaxSpeed3.Text = maxRpm.ToString();
                            this.maxSpeed3 = Convert.ToDecimal(maxRpm);
                            break;
                    }
                }));
                currentDataRequest++;
                isRequestInProgress = false;
                await Task.Delay(5000);
            }
        }
        public void ProcessNHT6Data(byte[] data)
        {
            if (data.Length >= 9 && data[0] == 0xA5)
            {
                // Xử lý dữ liệu MinSpeed và OilTemp
                int rpm = (data[5] << 8) + data[6];
                int oilTempRaw = (data[7] << 8) + data[8];
                string oilTemperature;
                int oilTempCelsius = 0;
                if (oilTempRaw == 0xFFFF)
                {
                    oilTemperature = "--";  // Không có cảm biến nhiệt độ
                    oilTempCelsius = 0;
                }
                else
                {
                    oilTempCelsius = oilTempRaw;
                    oilTemperature = oilTempCelsius.ToString();
                }

                this.Invoke(new Action(() =>
                {
                    switch (currentDataRequest)
                    {
                        case 1:
                            lbMinSpeed1.Text = rpm.ToString("F0");
                            lbHSU1.Text = oilTemperature;
                            this.minSpeed1 = Convert.ToDecimal(rpm);
                            this.hsu1 = oilTempCelsius;
                            break;
                        case 2:
                            lbMinSpeed2.Text = rpm.ToString("F0");
                            lbHSU2.Text = oilTemperature;
                            this.minSpeed2 = Convert.ToDecimal(rpm);
                            this.hsu2 = oilTempCelsius;
                            break;
                        case 3:
                            lbMinSpeed3.Text = rpm.ToString("F0");
                            lbHSU3.Text = oilTemperature;
                            this.minSpeed3 = Convert.ToDecimal(rpm);
                            this.hsu3 = oilTempCelsius;
                            break;
                    }
                }));
                byte[] commandA6 = { 0xA6, CalculateCheckCode(0xA6) };
                comConnect.SendRequest(commandA6);

            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveDieselEmissionData(this.serialNumber, minSpeed1, maxSpeed1, hsu1, minSpeed2, maxSpeed2, hsu2, minSpeed3, maxSpeed3, hsu3);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)opcManager.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition == 3)
            {
                SaveDataToDatabase();
            }
        }
        private void frmDieselEmission_Load(object sender, EventArgs e)
        {
            comConnect.OpenConnection();
        }
        private byte CalculateCheckCode(byte command)
        {
            int sum = command;
            return (byte)(~sum + 1);
        }
        private void frmDieselEmission_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
    }
}
