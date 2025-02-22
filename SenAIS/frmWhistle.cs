using OPCAutomation;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmWhistle : Form
    {
        private COMConnect comConnect;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        private double maxSoundValue = 0;
        public decimal whistle;
        public decimal minWhistle;
        public decimal maxWhistle;
        private bool isReady = false;
        private bool isMeasuring = false;
        private static readonly string opcWhistleCounter = ConfigurationManager.AppSettings["Whistle_Counter"];
        public frmWhistle(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            comConnect = new COMConnect(ConfigurationManager.AppSettings["COM_Whistle"], 300, this);
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 500; // Kiểm tra mỗi giây
            updateTimer.Tick += UpdateReadyStatus;
            updateTimer.Start();
        }
        private async void UpdateReadyStatus(object sender, EventArgs e)
        {
            try
            {
                lbEngineNumber.Text = this.serialNumber;
                // Lấy giá trị OPC
                int checkStatus = await Task.Run(() => (int)OPCUtility.GetOPCValue(opcWhistleCounter));
                Invoke((Action)(() =>
                {
                    switch (checkStatus)
                {
                        case 0: // Mặc định
                            cbReady.BackColor = SystemColors.Control;
                            lbWhistle.Visible = false;
                            lbStandard.Visible = false;
                            lbWhistleTitle.Visible = true;
                            isReady = false;
                            isMeasuring = false;
                            break;
                        case 1: // Xe vào vị trí
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            lbWhistle.Visible = false;
                            lbStandard.Visible = true;
                            lbWhistleTitle.Visible = true;
                            isReady = false; // Chưa sẵn sàng lưu
                            isMeasuring = false;
                            break;

                        case 2: // Bắt đầu đo
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            isReady = true; // Sẵn sàng lưu sau khi đo
                            lbWhistleTitle.Visible = false;
                            lbWhistle.Visible = true;
                            lbEnd.Text = "Bấm Còi...";
                            lbEnd.Visible = true;
                            if (!isMeasuring) // Chỉ gửi lệnh đo 1 lần
                            {
                                byte[] startCommand = { 0xB8 };
                                comConnect.SendRequest(startCommand);
                                isMeasuring = true; // Đánh dấu đang đo
                            }
                            break;

                        case 3: // Quá trình đo hoàn tất, lưu vào DB
                            cbReady.BackColor = Color.Green; // Đèn xanh
                            isMeasuring = false;
                            lbWhistleTitle.Visible = false;
                            lbWhistle.Visible = true;
                            lbEnd.Text = "Kết Thúc";
                            if (isReady)
                            {
                                SaveDataToDatabase(); // Ghi dữ liệu vào DB
                                isReady = false; // Đặt lại trạng thái
                            }
                            break;
                        case 4: // Xe tiếp theo
                            cbReady.BackColor = SystemColors.Control;
                            lbStandard.Visible = false;
                            lbEnd.Visible = false;
                            lbWhistleTitle.Visible = true;
                            frmSideSlip ssForm = new frmSideSlip(serialNumber);
                            ssForm.Show();
                            this.Close();
                            break;

                        default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                            cbReady.BackColor = SystemColors.Control; // Màu mặc định
                            isReady = false;
                            lbWhistleTitle.Visible = true;
                            break;
                }
                }));

            }
            catch (Exception)
            {
            }
        }
        private decimal ConvertToDecimal(object value)
        {
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }
        private void LoadVehicleStandards(string serialNumber)
        {
            DataRow vehicleDetails = sqlHelper.GetVehicleDetails(serialNumber);
            if (vehicleDetails != null)
            {
                string vehicleType = vehicleDetails["VehicleType"].ToString();
                DataTable vehicleStandards = sqlHelper.GetVehicleStandardsByTypeCar(vehicleType);
                if (vehicleStandards.Rows.Count > 0)
                {
                    DataRow standard = vehicleStandards.Rows[0];
                    minWhistle = ConvertToDecimal(standard["MinWhistle"]);
                    maxWhistle = ConvertToDecimal(standard["MaxWhistle"]);
                }
                lbStandard.Text = (minWhistle > 0 && maxWhistle > 0) ? $"{minWhistle.ToString("F1")}  -  {maxWhistle.ToString("F1")}" : "--  -  --";
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (isReady)
                {
                    SaveDataToDatabase();// Lưu dữ liệu nếu sẵn sàng
                }

                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
                    LoadVehicleStandards(serialNumber);
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
                    SaveDataToDatabase(); // Lưu DB nếu đèn xanh và CP xác nhận lưu
                }
                // Lấy SerialNumber trước đó
                string previousSerialNumber = sqlHelper.GetPreviousSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(previousSerialNumber))
                {
                    // Cập nhật serialNumber mới
                    this.serialNumber = previousSerialNumber;
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
                    LoadVehicleStandards(serialNumber);
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
        public void ProcessMaxSoundData(byte[] data)
        {
            try
            {
                if (data.Length >= 6 && data[0] == 0x01) // Check start and end byte
                {
                    // Xử lý và hiển thị giá trị max sound
                    string maxSoundLevel = Encoding.ASCII.GetString(data, 1, 5); // 5 bytes ASCII

                    if (double.TryParse(maxSoundLevel, out double soundLevel))
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (isMeasuring && soundLevel > maxSoundValue) // Chỉ cập nhật nếu đang đo
                            {
                                maxSoundValue = soundLevel;
                                lbWhistle.Text = maxSoundValue.ToString("F1");
                                this.whistle = Convert.ToDecimal(maxSoundValue);
                                bool isValueInStandard = this.whistle >= minWhistle && (maxWhistle == 0 || this.whistle <= maxWhistle);
                                lbWhistle.ForeColor = isValueInStandard ? SystemColors.HotTrack : Color.DarkRed;
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
            OPCUtility.SetOPCValue(opcWhistleCounter, 1);
        }

        private void frmWhistle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateTimer != null)
            {
                updateTimer.Stop(); // Dừng Timer
                updateTimer.Dispose(); // Giải phóng tài nguyên
                updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            }
            e.Cancel = false;
            comConnect.CloseConnection();
        }
    }
}
