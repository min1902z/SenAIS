using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSideSlip : Form
    {
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal sideSlip;
        private bool isReady = false;
        private decimal minSideSlip = 0;
        private decimal maxSideSlip = 0;
        private bool hasProcessedNextVin = false; // Cờ kiểm soát việc next số VIN
        private static readonly string opcSSCounter = ConfigurationManager.AppSettings["SideSlip_Counter"];
        private static readonly string opcSSResult = ConfigurationManager.AppSettings["SideSlip_Result"];
        private static readonly string opcSSSign = ConfigurationManager.AppSettings["SideSlip_Sign"];
        public frmSideSlip(string serialNumber)
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
                int checkStatus = await Task.Run(() => (int)OPCUtility.GetOPCValue(opcSSCounter));
                Invoke((Action)(() =>
                {
                    switch (checkStatus)
                    {
                        case 0: // Mặc định
                            cbReady.BackColor = SystemColors.Control;
                            lbSideSlip.Visible = false;
                            lbStandard.Visible = false;
                            isReady = false;
                            hasProcessedNextVin = false; // Reset cờ chuyển số VIN
                            break;

                        case 1: // Xe vào vị trí
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            lbSideSlip.Visible = false;
                            isReady = false; // Chưa sẵn sàng lưu
                            lbStandard.Visible = true;
                            break;

                        case 2: // Bắt đầu đo
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            lbSideSlipTitle.Visible = false;
                            lbSideSlip.Visible = true;
                            isReady = true; // Sẵn sàng lưu sau khi đo

                            double alignA = 1.0;
                            alignA = sqlHelper.GetParaValue("SideSlip", "ParaA");
                            double sideSlipSign = (double)OPCUtility.GetOPCValue(opcSSSign);
                            double sideSlipResult = (double)OPCUtility.GetOPCValue(opcSSResult);
                            double sideSlip = 0.0;

                            if (sideSlipSign == 0)
                            {
                                sideSlip = sideSlipResult / alignA;
                            }
                            else if (sideSlipSign == 1)
                            {
                                sideSlip = -1 * (sideSlipResult / alignA);
                            }
                            else
                            {
                                MessageBox.Show("Lỗi giá trị SideSlip_Sign. ");
                            }
                            lbSideSlip.Text = sideSlip.ToString("F1");

                            this.sideSlip = Convert.ToDecimal(sideSlip.ToString("F1"));

                            // Kiểm tra và đổi màu label Noise nếu ngoài tiêu chuẩn
                            bool isValueInStandard = this.sideSlip >= minSideSlip && (maxSideSlip == 0 || this.sideSlip <= maxSideSlip);

                            if (isValueInStandard)
                            {
                                lbSideSlip.ForeColor = SystemColors.HotTrack;
                            }
                            else
                            {
                                lbSideSlip.ForeColor = Color.DarkRed; // Nếu không đạt tiêu chuẩn, đổi màu
                            }
                            break;

                        case 3: // Quá trình đo hoàn tất, lưu vào DB
                            cbReady.BackColor = Color.Green; // Đèn xanh
                            lbSideSlipTitle.Visible = false;
                            lbSideSlip.Visible = true;
                            if (isReady)
                            {
                                SaveDataToDatabase();
                                isReady = false;
                                var formSideSlip2 = new frmSideSlip2(this.serialNumber);
                                formSideSlip2.Show();
                                OPCUtility.SetOPCValue(opcSSCounter, 2);
                                this.Close();
                            }
                            break;
                        case 4: // Xe tiếp theo
                            cbReady.BackColor = SystemColors.Control;
                            lbSideSlipTitle.Visible = true;
                            lbSideSlipTitle.Text = "Xe tiếp theo";
                            lbSideSlipTitle.Visible = true;
                            lbStandard.Visible = false;
                            if (!hasProcessedNextVin)
                            {
                                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                                if (!string.IsNullOrEmpty(nextSerialNumber))
                                {
                                    this.serialNumber = nextSerialNumber;
                                    lbVinNumber.Text = this.serialNumber;

                                    // Lấy và hiển thị tiêu chuẩn mới
                                    LoadVehicleStandards(this.serialNumber);
                                    lbStandard.Text = (minSideSlip != 0 && maxSideSlip != 0) ? $"[{minSideSlip.ToString("F0")}]  -  [{maxSideSlip.ToString("F0")}]" : "--  -  --";
                                    lbStandard.Visible = true;
                                    hasProcessedNextVin = true; // Đánh dấu đã xử lý
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Không có xe tiếp theo để kiểm tra.");
                                    break;
                                }

                            }
                            break;
                        default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                            cbReady.BackColor = SystemColors.Control; // Màu mặc định
                            isReady = false;
                            lbStandard.Visible = false;
                            break;
                    }
                }));
            }
            catch
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
                    minSideSlip = ConvertToDecimal(standard["MinSideSlip"]);
                    maxSideSlip = ConvertToDecimal(standard["MaxSideSlip"]);
                }
                lbStandard.Text = (minSideSlip != 0 && maxSideSlip != 0) ? $"[{minSideSlip.ToString("F0")}]  -  [{maxSideSlip.ToString("F0")}]" : "--  -  --";
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
                    SaveDataToDatabase(); // Lưu dữ liệu nếu sẵn sàng
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
            sqlHelper.SaveSideSlipData(this.serialNumber, this.sideSlip);
        }
        private void frmSideSlip_FormClosing(object sender, FormClosingEventArgs e)
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
