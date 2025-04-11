using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private double alignA = 1.0;
        private bool hasProcessedNextVin = false; // Cờ kiểm soát việc next số VIN
        private readonly List<string> opcItems = new List<string>
        {
            opcSSCounter,
            opcSSResult,
            opcSSSign
        };
        private static readonly string opcSSCounter = ConfigurationManager.AppSettings["SideSlip_Counter"];
        private static readonly string opcSSResult = ConfigurationManager.AppSettings["SideSlip_Result"];
        private static readonly string opcSSSign = ConfigurationManager.AppSettings["SideSlip_Sign"];
        public frmSideSlip(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
            OPCUtility.SetOPCValue(opcSSCounter, 1);
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 200; // Kiểm tra mỗi giây
            updateTimer.Tick += PollOPCValues;
            updateTimer.Start();
        }
        private void PollOPCValues(object sender, EventArgs e)
        {
            updateTimer.Stop();
            try
            {
                // Lấy tất cả giá trị OPC trong một lần
                var values = OPCUtility.GetMultipleOPCValues(opcItems);

                // Xử lý trạng thái dựa trên SideSlipCounter
                int ssCounter = values.ContainsKey(opcSSCounter) ? (int)values[opcSSCounter] : 0;
                UpdateReadyStatus(ssCounter, values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PollOPCValues: {ex.Message}");
            }
            finally
            {
                updateTimer.Start(); // Khởi động lại Timer
            }
        }
        private void UpdateReadyStatus(int ssCounter, Dictionary<string, decimal> values)
        {
            try
            {
                Task.Run(() =>
                {
                    // Tính toán giá trị cần thiết trước
                    double sideSlipSign = values.ContainsKey(opcSSSign) ? (double)values[opcSSSign] : 0;
                    double sideSlipResult = values.ContainsKey(opcSSResult) ? (double)values[opcSSResult] : 0;
                    double sideSlip = sideSlipSign == 0
                        ? sideSlipResult / alignA
                        : -1 * (sideSlipResult / alignA);

                    // Lấy giá trị OPC
                    this.Invoke(new Action(() =>
                    {
                        lbVinNumber.Text = this.serialNumber;
                        switch (ssCounter)
                        {
                            case 0: // Mặc định
                                cbReady.BackColor = SystemColors.Control;
                                lbSideSlip.Visible = false;
                                lbStandard.Visible = false;
                                lbEnd.Visible = false;
                                lbSideSlipTitle.Visible = true;
                                isReady = false;
                                hasProcessedNextVin = false; // Reset cờ chuyển số VIN
                                break;

                            case 1: // Xe vào vị trí
                                cbReady.BackColor = Color.Green; // Đèn xanh sáng
                                lbSideSlip.Visible = false;
                                lbEnd.Visible = false;
                                lbSideSlipTitle.Visible = true;
                                isReady = false; // Chưa sẵn sàng lưu
                                lbStandard.Visible = true;
                                break;

                            case 2: // Bắt đầu đo
                                cbReady.BackColor = Color.Green; // Đèn xanh sáng
                                lbSideSlipTitle.Visible = false;
                                lbEnd.Visible = false;
                                lbSideSlip.Visible = true;
                                isReady = true; // Sẵn sàng lưu sau khi đo
                                lbSideSlip.Text = sideSlip.ToString("F1");
                                bool isValueInStandard = this.sideSlip >= minSideSlip && (maxSideSlip == 0 || this.sideSlip <= maxSideSlip);
                                lbSideSlip.ForeColor = isValueInStandard ? SystemColors.HotTrack : Color.DarkRed;
                                this.sideSlip = Convert.ToDecimal(sideSlip.ToString("F1"));
                                break;

                            case 3: // Quá trình đo hoàn tất, lưu vào DB
                                cbReady.BackColor = Color.Green; // Đèn xanh
                                lbSideSlipTitle.Visible = false;
                                lbSideSlip.Visible = true;
                                lbEnd.Visible = true;
                                if (isReady)
                                {
                                    SaveDataToDatabase();
                                    isReady = false;
                                }
                                break;
                            case 4: // Xe tiếp theo
                                cbReady.BackColor = SystemColors.Control;
                                lbSideSlipTitle.Visible = true;
                                lbStandard.Visible = false;
                                if (!hasProcessedNextVin)
                                {
                                    string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);

                                    var frmMain = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
                                    if (frmMain != null)
                                    {
                                        var txtVinNumber = frmMain.Controls.Find("txtVinNum", true).FirstOrDefault() as TextBox;

                                        if (!string.IsNullOrEmpty(nextSerialNumber))
                                        {
                                            this.serialNumber = nextSerialNumber;
                                            lbVinNumber.Text = this.serialNumber;
                                            if (txtVinNumber != null)
                                            {
                                                txtVinNumber.Text = this.serialNumber;
                                                frmMain.UpdateVehicleInfo(this.serialNumber);
                                            }
                                        }
                                        else
                                        {
                                            if (txtVinNumber != null)
                                            {
                                                txtVinNumber.Text = string.Empty;
                                            }
                                        }
                                    }
                                    hasProcessedNextVin = true;
                                    this.Close();
                                }
                                else
                                {
                                    this.Close();
                                }
                                break;
                            default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                                cbReady.BackColor = SystemColors.Control; // Màu mặc định
                                isReady = false;
                                lbSideSlipTitle.Visible = true;
                                break;
                        }
                    }));
                });
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
                lbStandard.Text = (minSideSlip != 0 && maxSideSlip != 0) ? $"[{minSideSlip.ToString("F1")}]  -  [{maxSideSlip.ToString("F1")}]" : "--  -  --";
            }
            this.alignA = sqlHelper.GetParaValue("SideSlip", "ParaA");
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
