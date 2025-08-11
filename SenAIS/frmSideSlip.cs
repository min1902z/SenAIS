using SenAIS.Logger;
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
                        if (!this.IsDisposed && this.IsHandleCreated)
                        {
                            this.BeginInvoke((Action)(() => UpdateUI(checkStatus)));
                        }

                        if (checkStatus == 2) // Chỉ lấy SideSlip khi counter == 2
                        {
                            UpdateSideSlip();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.LogError(this, ex);
                    }
                    await Task.Delay(100, token); // Giảm trễ xuống 100ms để cập nhật nhanh hơn
                }
            }, token);
        }
        private  async void UpdateUI(int checkStatus)
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
                        await Task.Run(() => SaveDataToDatabase());
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

                if (!this.IsDisposed && this.IsHandleCreated)
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        lbSideSlip.Text = sideSlip.ToString("F1");
                        this.sideSlip = Convert.ToDecimal(sideSlip.ToString("F1"));

                        bool isValueInStandard = this.sideSlip >= minSideSlip && (maxSideSlip == 0 || this.sideSlip <= maxSideSlip);
                        lbSideSlip.ForeColor = isValueInStandard ? Color.Blue : Color.DarkRed;
                    }));
                }
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private void NextVin()
        {
            try
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
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private decimal ConvertToDecimal(object value)
        {
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }
        private async Task LoadVehicleStandards(string serialNumber)
        {
            try
            {
                lbVinNumber.Text = this.serialNumber;
                DataRow vehicleDetails = await Task.Run(() => sqlHelper.GetVehicleDetails(serialNumber));
                if (vehicleDetails != null)
                {
                    string vehicleType = vehicleDetails["VehicleType"].ToString();
                    DataTable vehicleStandards = await Task.Run(() => sqlHelper.GetVehicleStandardsByTypeCar(vehicleType));
                    if (vehicleStandards.Rows.Count > 0)
                    {
                        DataRow standard = vehicleStandards.Rows[0];
                        minSideSlip = ConvertToDecimal(standard["MinSideSlip"]);
                        maxSideSlip = ConvertToDecimal(standard["MaxSideSlip"]);
                    }
                    lbStandard.Text = (minSideSlip != 0 && maxSideSlip != 0) ? $"[{minSideSlip:F1}]  -  [{maxSideSlip:F1}]" : "--  -  --";
                }
                this.alignA = await Task.Run(() => sqlHelper.GetParaValue("SideSlip", "ParaA"));
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private async void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu dữ liệu hiện tại
                if (isReady)
                {
                    await Task.Run(() => SaveDataToDatabase());
                }
                // Lấy SerialNumber trước đó
                string previousSerialNumber = await Task.Run(() => sqlHelper.GetPreviousSerialNumber(this.serialNumber));
                if (!string.IsNullOrEmpty(previousSerialNumber))
                {
                    // Cập nhật serialNumber mới
                    this.serialNumber = previousSerialNumber;
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
                    await LoadVehicleStandards(serialNumber);
                }
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private async void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (isReady)
                {
                    await Task.Run(() => SaveDataToDatabase());
                }

                string nextSerialNumber = await Task.Run(() => sqlHelper.GetNextSerialNumber(this.serialNumber));
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
                    await LoadVehicleStandards(serialNumber);
                }
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private void SaveDataToDatabase()
        {
            try
            {
                sqlHelper.SaveSideSlipData(this.serialNumber, this.sideSlip);
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
        private void frmSideSlip_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                opcCancellationTokenSource?.Cancel();
                opcCancellationTokenSource?.Dispose();
                opcCancellationTokenSource = null;

                if (opcManager != null && opcManager.IsConnected)
                {
                    opcManager.DisconnectOPC();
                }
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }

        private async void frmSideSlip_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadVehicleStandards(serialNumber);
                opcManager.SetOPCValue(opcSSCounter, 1);
                StartListening();
            }
            catch (Exception ex)
            {
                Logging.LogError(this, ex);
            }
        }
    }
}
