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
        private SQLHelper sqlHelper;
        private OPCUtility opcManager;
        private CancellationTokenSource opcCancellationTokenSource;
        private string serialNumber;
        public decimal sideSlip;
        private bool isReady = false;
        private decimal minSideSlip = 0;
        private decimal maxSideSlip = 0;
        private double alignA = 1.0;
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
                    cbReady.BackColor = SystemColors.Control;
                    lbSideSlipTitle.Visible = true;
                    lbStandard.Visible = false;
                    NextVin();
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
        private void NextVin()
        {
                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);

                if (!(Application.OpenForms.OfType<frmInspection>().FirstOrDefault() is frmInspection frmMain))
                    return;

                if (!(frmMain.Controls.Find("txtVinNum", true).FirstOrDefault() is TextBox txtVinNum))
                    return;

                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber;
                    lbVinNumber.Text = this.serialNumber;

                    txtVinNum.Text = this.serialNumber;
                    frmMain.UpdateVehicleInfo(this.serialNumber);
                }
                else
                {
                    txtVinNum.Text = string.Empty;
                }
                this.Close();
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
