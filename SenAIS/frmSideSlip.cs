using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SenAIS
{
    public partial class frmSideSlip : Form
    {
        //private Timer updateTimer;
        private SQLHelper sqlHelper;
        private OPCUtility opcManager;
        private CancellationTokenSource opcCancellationTokenSource;
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
            opcManager = new OPCUtility();
            StartListening();
            //InitializeTimer();
        }
        private void StartListening()
        {
            opcCancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = opcCancellationTokenSource.Token;

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        int checkStatus = (int)opcManager.GetOPCValue(opcSSCounter);
                        this.Invoke((Action)(() => UpdateUI(checkStatus))); // Cập nhật UI từ Thread chính

                        if (checkStatus == 2) // Chỉ lấy SideSlip khi counter == 2
                        {
                            UpdateSideSlip();
                        }
                    }
                    catch (Exception)
                    {
                    }
                    await Task.Delay(100, token); // Giảm trễ xuống 100ms để cập nhật nhanh hơn
                }
            }, token);
        }
        private void UpdateUI(int checkStatus)
        {
            switch (checkStatus)
            {
                case 0:
                    ResetUI();
                    break;

                case 1:
                    cbReady.BackColor = Color.Green;
                    lbSideSlip.Visible = false;
                    lbStandard.Visible = true;
                    isReady = false;
                    break;

                case 2:
                    cbReady.BackColor = Color.Green;
                    lbSideSlipTitle.Visible = false;
                    lbSideSlip.Visible = true;
                    isReady = true;
                    break;

                case 3:
                    cbReady.BackColor = Color.Green;
                    lbSideSlipTitle.Visible = false;
                    lbSideSlip.Visible = true;
                    lbEnd.Visible = true;
                    if (isReady)
                    {
                        SaveDataToDatabase();
                        isReady = false;
                    }
                    break;

                case 4:
                    lbSideSlipTitle.Visible = true;
                    lbStandard.Visible = false;
                    MoveToNextCar();
                    break;

                default:
                    ResetUI();
                    break;
            }
        }
        private void ResetUI()
        {
            cbReady.BackColor = SystemColors.Control;
            lbSideSlip.Visible = false;
            lbStandard.Visible = false;
            lbEnd.Visible = false;
            lbSideSlipTitle.Visible = true;
            isReady = false;
            hasProcessedNextVin = false;
            lbSideSlip.Text  = "0.0";
        }
        private void UpdateSideSlip()
        {
            try
            {
                double sideSlipSign = (double)opcManager.GetOPCValue(opcSSSign);
                double sideSlipResult = (double)opcManager.GetOPCValue(opcSSResult);
                double sideSlip = (sideSlipSign == 0) ? (sideSlipResult / alignA) : (-1 * (sideSlipResult / alignA));

                this.Invoke((Action)(() =>
                {
                    lbSideSlip.Text = sideSlip.ToString("F1");
                    this.sideSlip = Convert.ToDecimal(sideSlip.ToString("F1"));

                    bool isValueInStandard = this.sideSlip >= minSideSlip && (maxSideSlip == 0 || this.sideSlip <= maxSideSlip);
                    lbSideSlip.ForeColor = isValueInStandard ? Color.Blue : Color.DarkRed;
                }));
            }
            catch (Exception)
            {
            }
        }
        private void MoveToNextCar()
        {
            cbReady.BackColor = SystemColors.Control;
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
        }
        //private void InitializeTimer()
        //{
        //    updateTimer = new Timer();
        //    updateTimer.Interval = 200; // Kiểm tra mỗi giây
        //    updateTimer.Tick += PollOPCValues;
        //    updateTimer.Start();
        //}
        //private void PollOPCValues(object sender, EventArgs e)
        //{
        //    updateTimer.Stop();
        //    try
        //    {
        //        // Lấy tất cả giá trị OPC trong một lần
        //        var values = OPCUtility.GetMultipleOPCValues(opcItems);

        //        // Xử lý trạng thái dựa trên SideSlipCounter
        //        int ssCounter = values.ContainsKey(opcSSCounter) ? (int)values[opcSSCounter] : 0;
        //        UpdateReadyStatus(ssCounter, values);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in PollOPCValues: {ex.Message}");
        //    }
        //    finally
        //    {
        //        updateTimer.Start(); // Khởi động lại Timer
        //    }
        //}
        //private void UpdateReadyStatus(int ssCounter, Dictionary<string, decimal> values)
        //{
        //    try
        //    {
        //        Task.Run(() =>
        //        {
        //            // Tính toán giá trị cần thiết trước
        //            double sideSlipSign = values.ContainsKey(opcSSSign) ? (double)values[opcSSSign] : 0;
        //            double sideSlipResult = values.ContainsKey(opcSSResult) ? (double)values[opcSSResult] : 0;
        //            double sideSlip = sideSlipSign == 0
        //                ? sideSlipResult / alignA
        //                : -1 * (sideSlipResult / alignA);

        //            // Lấy giá trị OPC
        //            this.Invoke(new Action(() =>
        //            {
        //                lbVinNumber.Text = this.serialNumber;
        //                switch (ssCounter)
        //                {
        //                    case 0: // Mặc định
        //                        cbReady.BackColor = SystemColors.Control;
        //                        lbSideSlip.Visible = false;
        //                        lbStandard.Visible = false;
        //                        lbEnd.Visible = false;
        //                        lbSideSlipTitle.Visible = true;
        //                        isReady = false;
        //                        hasProcessedNextVin = false; // Reset cờ chuyển số VIN
        //                        break;

        //                    case 1: // Xe vào vị trí
        //                        cbReady.BackColor = Color.Green; // Đèn xanh sáng
        //                        lbSideSlip.Visible = false;
        //                        lbEnd.Visible = false;
        //                        lbSideSlipTitle.Visible = true;
        //                        isReady = false; // Chưa sẵn sàng lưu
        //                        lbStandard.Visible = true;
        //                        break;

        //                    case 2: // Bắt đầu đo
        //                        cbReady.BackColor = Color.Green; // Đèn xanh sáng
        //                        lbSideSlipTitle.Visible = false;
        //                        lbEnd.Visible = false;
        //                        lbSideSlip.Visible = true;
        //                        isReady = true; // Sẵn sàng lưu sau khi đo
        //                        lbSideSlip.Text = sideSlip.ToString("F1");
        //                        bool isValueInStandard = this.sideSlip >= minSideSlip && (maxSideSlip == 0 || this.sideSlip <= maxSideSlip);
        //                        lbSideSlip.ForeColor = isValueInStandard ? SystemColors.HotTrack : Color.DarkRed;
        //                        this.sideSlip = Convert.ToDecimal(sideSlip.ToString("F1"));
        //                        break;

        //                    case 3: // Quá trình đo hoàn tất, lưu vào DB
        //                        cbReady.BackColor = Color.Green; // Đèn xanh
        //                        lbSideSlipTitle.Visible = false;
        //                        lbSideSlip.Visible = true;
        //                        lbEnd.Visible = true;
        //                        if (isReady)
        //                        {
        //                            SaveDataToDatabase();
        //                            isReady = false;
        //                        }
        //                        break;
        //                    case 4: // Xe tiếp theo
        //                        cbReady.BackColor = SystemColors.Control;
        //                        lbSideSlipTitle.Visible = true;
        //                        lbStandard.Visible = false;
        //                        if (!hasProcessedNextVin)
        //                        {
        //                            string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);

        //                            var frmMain = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
        //                            if (frmMain != null)
        //                            {
        //                                var txtVinNumber = frmMain.Controls.Find("txtVinNum", true).FirstOrDefault() as TextBox;

        //                                if (!string.IsNullOrEmpty(nextSerialNumber))
        //                                {
        //                                    this.serialNumber = nextSerialNumber;
        //                                    lbVinNumber.Text = this.serialNumber;
        //                                    if (txtVinNumber != null)
        //                                    {
        //                                        txtVinNumber.Text = this.serialNumber;
        //                                        frmMain.UpdateVehicleInfo(this.serialNumber);
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (txtVinNumber != null)
        //                                    {
        //                                        txtVinNumber.Text = string.Empty;
        //                                    }
        //                                }
        //                            }
        //                            hasProcessedNextVin = true;
        //                            this.Close();
        //                        }
        //                        else
        //                        {
        //                            this.Close();
        //                        }
        //                        break;
        //                    default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
        //                        cbReady.BackColor = SystemColors.Control; // Màu mặc định
        //                        isReady = false;
        //                        lbSideSlipTitle.Visible = true;
        //                        break;
        //                }
        //            }));
        //        });
        //    }
        //    catch
        //    {
        //    }
        //}
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
        }

        private void frmSideSlip_Load(object sender, EventArgs e)
        {
            LoadVehicleStandards(serialNumber);
            opcManager.SetOPCValue(opcSSCounter, 1);
        }
    }
}
