using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmWhistle : Form
    {
        private COMConnect comConnect;
        //private Timer updateTimer;
        private SQLHelper sqlHelper;
        private OPCUtility opcManager;
        private CancellationTokenSource opcCancellationTokenSource;
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
            opcManager = new OPCUtility();
            StartOPCListener();
            //InitializeTimer();
        }
        private void StartOPCListener()
        {
            opcCancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = opcCancellationTokenSource.Token;

            Task.Run(async () =>
            {
                int lastCounter = -1;

                while (!token.IsCancellationRequested)
                {
<<<<<<< HEAD:SenAIS/frmWhistle.cs
                    try
                    {
                        int checkStatus = opcManager.GetOPCValue(opcWhistleCounter);
=======
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
>>>>>>> SenAIS_HD:SenAIS_old/frmWhistle.cs

                        if (checkStatus != lastCounter || checkStatus == 2)
                        {
                            lastCounter = checkStatus;

                            this.BeginInvoke((MethodInvoker)(() =>
                            {
                                UpdateWhistleUI(checkStatus);
                            }));
                        }
                    }
                    catch { }

<<<<<<< HEAD:SenAIS/frmWhistle.cs
                    await Task.Delay(100, token);
                }
            }, token);
        }
        private void UpdateWhistleUI(int status)
        {
            switch (status)
=======
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
>>>>>>> SenAIS_HD:SenAIS_old/frmWhistle.cs
            {
                case 0:
                    cbReady.BackColor = SystemColors.Control;
                    lbWhistle.Visible = false;
                    lbStandard.Visible = false;
                    lbWhistleTitle.Visible = true;
                    isReady = false;
                    isMeasuring = false;
                    break;

                case 1:
                    cbReady.BackColor = Color.Green;
                    lbWhistle.Visible = false;
                    lbStandard.Visible = true;
                    lbWhistleTitle.Visible = true;
                    isReady = false;
                    isMeasuring = false;
                    break;

                case 2:
                    cbReady.BackColor = Color.Green;
                    lbWhistleTitle.Visible = false;
                    lbWhistle.Visible = true;
                    lbEnd.Text = "Bấm Còi...";
                    lbEnd.Visible = true;
                    isReady = true;

                    if (!isMeasuring)
                    {
                        byte[] startCommand = { 0xB8 };
                        comConnect.SendRequest(startCommand);
                        isMeasuring = true;
                    }
                    break;

                case 3:
                    cbReady.BackColor = Color.Green;
                    lbWhistleTitle.Visible = false;
                    lbWhistle.Visible = true;
                    lbEnd.Text = "Kết Thúc";

                    if (isReady)
                    {
                        SaveDataToDatabase();
                        isReady = false;
                    }
                    isMeasuring = false;
                    break;

                case 4:
                    cbReady.BackColor = SystemColors.Control;
                    lbStandard.Visible = false;
                    lbEnd.Visible = false;
                    lbWhistleTitle.Visible = true;
                    MoveToNextCar();
                    break;

                default:
                    cbReady.BackColor = SystemColors.Control;
                    lbWhistleTitle.Visible = true;
                    isReady = false;
                    break;
            }
        }
        //private void InitializeTimer()
        //{
        //    updateTimer = new Timer();
        //    updateTimer.Interval = 200; // Kiểm tra mỗi giây
        //    updateTimer.Tick += UpdateReadyStatus;
        //    updateTimer.Start();
        //}
        //private async void UpdateReadyStatus(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lbVinNumber.Text = this.serialNumber;
        //        // Lấy giá trị OPC
        //        int checkStatus = await Task.Run(() => (int)OPCUtility.GetOPCValue(opcWhistleCounter));
        //        Invoke((Action)(() =>
        //        {
        //            switch (checkStatus)
        //            {
        //                case 0: // Mặc định
        //                    cbReady.BackColor = SystemColors.Control;
        //                    lbWhistle.Visible = false;
        //                    lbStandard.Visible = false;
        //                    lbWhistleTitle.Visible = true;
        //                    isReady = false;
        //                    isMeasuring = false;
        //                    break;
        //                case 1: // Xe vào vị trí
        //                    cbReady.BackColor = Color.Green; // Đèn xanh sáng
        //                    lbWhistle.Visible = false;
        //                    lbStandard.Visible = true;
        //                    lbWhistleTitle.Visible = true;
        //                    isReady = false; // Chưa sẵn sàng lưu
        //                    isMeasuring = false;
        //                    break;

        //                case 2: // Bắt đầu đo
        //                    cbReady.BackColor = Color.Green; // Đèn xanh sáng
        //                    isReady = true; // Sẵn sàng lưu sau khi đo
        //                    lbWhistleTitle.Visible = false;
        //                    lbWhistle.Visible = true;
        //                    lbEnd.Text = "Bấm Còi...";
        //                    lbEnd.Visible = true;
        //                    if (!isMeasuring) // Chỉ gửi lệnh đo 1 lần
        //                    {
        //                        byte[] startCommand = { 0xB8 };
        //                        comConnect.SendRequest(startCommand);
        //                        isMeasuring = true; // Đánh dấu đang đo
        //                    }
        //                    break;

        //                case 3: // Quá trình đo hoàn tất, lưu vào DB
        //                    cbReady.BackColor = Color.Green; // Đèn xanh
        //                    isMeasuring = false;
        //                    lbWhistleTitle.Visible = false;
        //                    lbWhistle.Visible = true;
        //                    lbEnd.Text = "Kết Thúc";
        //                    if (isReady)
        //                    {
        //                        SaveDataToDatabase(); // Ghi dữ liệu vào DB
        //                        isReady = false; // Đặt lại trạng thái
        //                    }
        //                    break;
        //                case 4: // Xe tiếp theo
        //                    cbReady.BackColor = SystemColors.Control;
        //                    lbStandard.Visible = false;
        //                    lbEnd.Visible = false;
        //                    lbWhistleTitle.Visible = true;
        //                    if (updateTimer != null)
        //                    {
        //                        updateTimer.Stop(); // Dừng Timer
        //                        updateTimer.Dispose(); // Giải phóng tài nguyên
        //                        updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
        //                    }
        //                    OpenOrReplaceFormWithSerial<frmSideSlip>(this.serialNumber);
        //                    break;

        //                default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
        //                    cbReady.BackColor = SystemColors.Control; // Màu mặc định
        //                    isReady = false;
        //                    lbWhistleTitle.Visible = true;
        //                    break;
        //            }
        //        }));

        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
        //private void OpenOrReplaceFormWithSerial<T>(string serialNumber) where T : Form
        //{
        //    // 🔹 Kiểm tra xem form đã mở chưa
        //    var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

        //    if (existingForm != null)
        //    {
        //        existingForm.Close(); // 🔥 Đóng form cũ trước khi mở form mới
        //    }

        //    // 🔹 Sử dụng Reflection để khởi tạo form với `serialNumber`
        //    var form = (T)Activator.CreateInstance(typeof(T), serialNumber);
        //    form.Show();

        //    // 🔹 Đóng form hiện tại
        //    this.Close();
        //}
        private void MoveToNextCar()
        {
            cbReady.BackColor = SystemColors.Control;
            Form currentForm = this;

            this.BeginInvoke(new Action(() =>
            {
                if (Application.OpenForms.OfType<frmSideSlip>().Any())
                    return;

                var form = new frmSideSlip(this.serialNumber);
                form.Show();

                currentForm.Close();
            }));
        }
        private decimal ConvertToDecimal(object value)
        {
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }
        private void LoadVehicleStandards(string serialNumber)
        {
            lbVinNumber.Text = this.serialNumber;
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
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
                    LoadVehicleStandards(serialNumber);
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
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
                    LoadVehicleStandards(serialNumber);
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
                if (data[0] == 0x01) // Check start and end byte
                {
                    // Xử lý và hiển thị giá trị max sound
                    string maxSoundLevel = Encoding.ASCII.GetString(data, 1, 5); // 5 bytes ASCII

                    if (double.TryParse(maxSoundLevel, out double soundLevel))
                    {
                        if (soundLevel > maxSoundValue) // Cập nhật giá trị lớn nhất trước khi gửi lên UI
                        {
                            maxSoundValue = soundLevel;
                        }

                        this.BeginInvoke(new Action(() =>
                        {
                            lbWhistle.Text = maxSoundValue.ToString("F1");
                            this.whistle = Convert.ToDecimal(maxSoundValue);
                            bool isValueInStandard = this.whistle >= minWhistle && (maxWhistle == 0 || this.whistle <= maxWhistle);
                            lbWhistle.ForeColor = isValueInStandard ? SystemColors.HotTrack : Color.DarkRed;
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
            LoadVehicleStandards(serialNumber);
            opcManager.SetOPCValue(opcWhistleCounter, 1);
        }

        private void frmWhistle_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (updateTimer != null)
            //{
            //    updateTimer.Stop(); // Dừng Timer
            //    updateTimer.Dispose(); // Giải phóng tài nguyên
            //    updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            //}
            //e.Cancel = false;
            if (opcCancellationTokenSource != null)
            {
                opcCancellationTokenSource.Cancel();
                opcCancellationTokenSource.Dispose();
                opcCancellationTokenSource = null;
            }
            comConnect.CloseConnection();

        }
    }
}
