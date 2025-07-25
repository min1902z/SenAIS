using SenAIS.Core.Repositories;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSideSlip2 : Form
    {
        private readonly VehicleRepository vehicleRepo = new VehicleRepository();
        private readonly StandardRepository standardRepo = new StandardRepository();
        private readonly InspectionRepository inspectionRepo = new InspectionRepository();
        private readonly CalibrationRepository calibrationRepo = new CalibrationRepository();
        private CancellationTokenSource opcCancellationTokenSource;
        private OPCManager opcManager;
        private string serialNumber;
        public decimal sideSlip;
        private double alignA = 1.0;
        private decimal minSideSlip = 0;
        private decimal maxSideSlip = 0;
        private static readonly string opcSSCounter = ConfigurationManager.AppSettings["SideSlip_Counter"];
        private static readonly string opcSSResult = ConfigurationManager.AppSettings["SideSlip_Result"];
        private static readonly string opcSSSign = ConfigurationManager.AppSettings["SideSlip_Sign"];
        public frmSideSlip2(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            LoadVehicleStandards(serialNumber);
            opcManager = new OPCManager();
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
                    cbReady.BackColor = SystemColors.Control;
                    lbSideSlip.Visible = false;
                    lbStandard.Visible = false;
                    lbSideSlipTitle.Visible = true;
                    break;

                case 1:
                    cbReady.BackColor = Color.Green;
                    lbSideSlip.Visible = false;
                    lbSideSlipTitle.Visible = true;
                    lbStandard.Visible = true;
                    break;

                case 2:
                    cbReady.BackColor = Color.Green;
                    lbSideSlipTitle.Visible = false;
                    lbSideSlip.Visible = true;
                    break;

                case 3:
                    cbReady.BackColor = Color.Green;
                    lbSideSlipTitle.Visible = false;
                    lbSideSlip.Visible = true;
                    break;

                case 4:
                    cbReady.BackColor = SystemColors.Control;
                    lbSideSlipTitle.Visible = false;
                    lbSideSlip.Visible = true;
                    lbStandard.Visible = false;
                    MoveToNextCar();
                    break;

                default:
                    cbReady.BackColor = SystemColors.Control;
                    lbStandard.Visible = false;
                    break;
            }
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
                    lbSideSlip.ForeColor = isValueInStandard ? Color.Blue : Color.Red;
                }));
            }
            catch (Exception)
            {
            }
        }
        private void MoveToNextCar()
        {
            Form currentForm = this;

            // 🔹 Đóng form hiện tại trước khi mở frmRearBrake
            this.BeginInvoke(new Action(() =>
            {
                // Kiểm tra nếu frmRearBrake đã mở, không mở lại
                if (Application.OpenForms.OfType<frmSideSlip>().Any())
                    return;

                // 🔹 Mở Form tiếp theo
                var form = new frmSideSlip(this.serialNumber);
                form.Show();

                // 🔹 Đóng form hiện tại
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
            var vehicle = vehicleRepo.GetVehicleDetails(serialNumber);
            if (vehicle != null)
            {
                string vehicleType = vehicle.VehicleType;
                var standard = standardRepo.GetVehicleStandardByTypeCar(vehicleType);
                if (standard != null)
                {
                    minSideSlip = standard.MinSideSlip ?? 0;
                    maxSideSlip = standard.MaxSideSlip ?? 0;
                }
                lbStandard.Text = (minSideSlip != 0 && maxSideSlip != 0) ? $"[{minSideSlip.ToString("F0")}]  -  [{maxSideSlip.ToString("F0")}]" : "--  -  --";
            }
            this.alignA = calibrationRepo.GetParaValue("SideSlip", "ParaA");
        }

        private void frmSideSlip2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (opcCancellationTokenSource != null)
            {
                opcCancellationTokenSource.Cancel();
                opcCancellationTokenSource.Dispose();
                opcCancellationTokenSource = null;
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            var existingForm = Application.OpenForms.OfType<frmSideSlip>().FirstOrDefault();
            if (existingForm != null)
            {
                existingForm.Close(); // 🔥 Đóng form cũ nếu có
            }

            var preForm = new frmSideSlip(this.serialNumber);
            preForm.Show();
            opcManager.SetOPCValue(opcSSCounter, 1);

            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
