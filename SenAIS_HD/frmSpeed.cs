using OPCAutomation;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSpeed : Form
    {
       // private Form parentForm;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal speedValue;
        private bool isReady = false;
        private decimal minSpeed = 0;
        private decimal maxSpeed = 0;
        private int retryCount = 0; // Đếm số lần đo lại
        private bool hasProcessedNextVin = false; // Cờ kiểm soát việc next số VIN

        public frmSpeed(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
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
            try
            {
                lbVinNumber.Text = this.serialNumber;
                // Lấy giá trị OPC
                int checkStatus = await Task.Run(() => (int)OPCUtility.GetOPCValue("Hyundai.OCS10.Speed_Counter"));

                Invoke((Action)(() =>
                {
                    switch (checkStatus)
                    {
                        case 0: // Mặc định
                            cbReady.BackColor = SystemColors.Control;
                            lbSpeed.Text = "0.0";
                            lbNotice.Visible = false;
                            lbStandard.Visible = false;
                            isReady = false;
                            hasProcessedNextVin = false; // Reset cờ chuyển số VIN
                            break;

                        case 1: // Xe vào vị trí
                                cbReady.BackColor = Color.Green; // Đèn xanh sáng
                                isReady = false; // Chưa sẵn sàng lưu
                                lbNotice.Visible = true;
                                lbNotice.Text = $"Phương tiện có số VIN '{this.serialNumber}' đã vào vị trí, chuẩn bị kiểm tra.";
                                lbStandard.Visible = true;
                                lbStandard.Text = (minSpeed > 0 && maxSpeed > 0) ? $"[{minSpeed.ToString("F0")}  -  {maxSpeed.ToString("F0")}]" : "--  -  --";
                            break;

                        case 2: // Bắt đầu đo
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            isReady = true; // Sẵn sàng lưu sau khi đo

                            double speedA = sqlHelper.GetParaValue("Speed", "ParaA");
                            double speedResult = OPCUtility.GetOPCValue("Hyundai.OCS10.Speed_Result");
                            double speed = speedResult / speedA;
                            lbSpeed.Text = speed.ToString("F1");

                            this.speedValue = Convert.ToDecimal(speed.ToString("F1"));

                            // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
                            bool isValueInStandard = sqlHelper.CheckValueAgainstStandard("Speed", this.speedValue, this.serialNumber);

                            if (isValueInStandard)
                            {
                                lbSpeed.ForeColor = SystemColors.HotTrack;
                                lbNotice.Visible = true;
                                lbNotice.Text = "Giá trị kiểm tra đã đạt tiêu chuẩn. Vui lòng chờ ...";
                            }
                            else
                            {
                                lbSpeed.ForeColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                                lbNotice.Visible = false;
                            }
                            break;

                        case 3: // Quá trình đo hoàn tất, lưu vào DB
                            cbReady.BackColor = Color.Green; // Đèn xanh
                            if (isReady)
                            {
                                bool isValueInStandard3 = sqlHelper.CheckValueAgainstStandard("Speed", this.speedValue, this.serialNumber);

                                if (isValueInStandard3)
                                {
                                    CheckCounterPosition(); // Lưu dữ liệu
                                    isReady = false;
                                }
                                else if (!isValueInStandard3 && retryCount < 2)
                                {
                                    CheckCounterPosition(); // Lưu dữ liệu
                                    OPCUtility.SetOPCValue("Hyundai.OCS10.Speed_Counter", 0); // Đặt lại trạng thái để đo lại
                                    retryCount++; // Tăng số lần đo lại
                                }
                            }
                            break;

                        case 4: // Xe tiếp theo
                            cbReady.BackColor = SystemColors.Control;
                            lbSpeed.Text = "0.0";
                            retryCount = 0; // Reset đếm số lần đo lại khi đạt chuẩn
                            lbNotice.Visible = true;
                            lbNotice.Text = "Chuẩn bị kiểm tra xe tiếp theo.";
                            lbStandard.Visible = false;
                            if(!hasProcessedNextVin)
                            {
                                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                                if (!string.IsNullOrEmpty(nextSerialNumber))
                                {
                                    this.serialNumber = nextSerialNumber;
                                    lbVinNumber.Text = this.serialNumber;

                                    // Lấy và hiển thị tiêu chuẩn mới
                                    LoadVehicleStandards(this.serialNumber);
                                    lbStandard.Text = (minSpeed > 0 && maxSpeed > 0) ? $"[{minSpeed.ToString("F0")} - {maxSpeed.ToString("F0")}]" : "-- - --";
                                    lbStandard.Visible = true;
                                    hasProcessedNextVin = true; // Đánh dấu đã xử lý
                                }
                                else
                                {
                                    MessageBox.Show("Không có xe tiếp theo để kiểm tra.");
                                }

                            }
                            break;

                        default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                                cbReady.BackColor = SystemColors.Control; // Màu mặc định
                                isReady = false;
                                lbNotice.Visible = false;
                                lbStandard.Visible = false;
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
                    minSpeed = ConvertToDecimal(standard["MinSpeed"]);
                    maxSpeed = ConvertToDecimal(standard["MaxSpeed"]);
                }
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
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
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
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
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
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.Speed_Counter");

            if (currentPosition == 3)
            {
                SaveDataToDatabase();
            }
        }

        private void frmSpeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateTimer != null)
            {
                updateTimer.Stop(); // Dừng Timer
                updateTimer.Dispose(); // Giải phóng tài nguyên
                updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            }
            e.Cancel = false;
        }
    }
}
