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
    public partial class frmSpeed : Form
    {
        private CancellationTokenSource opcCancellationTokenSource;
        private SQLHelper sqlHelper;
        private OPCManager opcManager;
        private string serialNumber;
        public decimal speedValue;
        private bool isReady = false;
        private decimal minSpeed = 0;
        private decimal maxSpeed = 0;
        private double speedA = 1.0;
        private static readonly string opcSpeedCounter = ConfigurationManager.AppSettings["Speed_Counter"];
        private static readonly string opcSpeedResult = ConfigurationManager.AppSettings["Speed_Result"];
        private static readonly string opcBrakeHCounter = ConfigurationManager.AppSettings["BrakeH_Counter"];

        public frmSpeed(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
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
                        int checkStatus = (int)opcManager.GetOPCValue(opcSpeedCounter);
                        this.Invoke((Action)(() => UpdateUI(checkStatus)));

                        if (checkStatus == 2)
                        {
                            UpdateSpeed();
                        }
                    }
                    catch (Exception)
                    {
                    }
                    await Task.Delay(100, token);
                }
            }, token);
        }
        private void UpdateUI(int checkStatus)
        {
            switch (checkStatus)
            {
                case 0:
                    cbReady.BackColor = SystemColors.Control;
                    lbSpeed.Visible = lbEnd.Visible = lbStandard.Visible = false;
                    isReady = false;
                    break;

                case 1:
                    cbReady.BackColor = Color.Green;
                    isReady = false;
                    lbSpeed.Visible = false;
                    lbEnd.Visible = false;
                    lbStandard.Visible = true;
                    break;

                case 2:
                    cbReady.BackColor = Color.Green;
                    isReady = true;
                    lbTitleSpeed.Visible = false;
                    lbEnd.Visible = false;
                    lbSpeed.Visible = true;
                    break;

                case 3:
                    cbReady.BackColor = Color.Green;
                    lbTitleSpeed.Visible = false;
                    lbEnd.Visible = true;
                    lbSpeed.Visible = true;
                    if (isReady)
                    {
                        SaveDataToDatabase();
                        isReady = false;
                    }
                    break;

                case 4:
                    cbReady.BackColor = SystemColors.Control;
                    lbEnd.Visible = true;
                    lbStandard.Visible = false;
                    lbTitleSpeed.Visible = true;
                    this.Close();
                    break;

                default:
                    cbReady.BackColor = SystemColors.Control;
                    isReady = false;
                    lbTitleSpeed.Visible = true;
                    break;
            }
        }

        private void UpdateSpeed()
        {
            try
            {
                double speedResult = (double)opcManager.GetOPCValue(opcSpeedResult);
                double speed = speedResult / speedA;

                this.Invoke((Action)(() =>
                {
                    lbSpeed.Text = speed.ToString("F1");
                    this.speedValue = Convert.ToDecimal(speed.ToString("F1"));

                    bool isValueInStandard = this.speedValue >= minSpeed && (maxSpeed == 0 || this.speedValue <= maxSpeed);
                    lbSpeed.ForeColor = isValueInStandard ? Color.Blue : Color.DarkRed;
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
            lbVinNumber.Text = this.serialNumber;
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
                lbStandard.Text = (minSpeed > 0 && maxSpeed > 0) ? $"[{minSpeed.ToString("F0")} - {maxSpeed.ToString("F0")}]" : "-- - --";
            }
            speedA = sqlHelper.GetParaValue("Speed", "ParaA");
        }
        private void btnPreSpeed_Click(object sender, EventArgs e)
        {
            var existingForm = Application.OpenForms.OfType<frmHandBrake>().FirstOrDefault();
            if (existingForm != null)
            {
                existingForm.Close(); // 🔥 Đóng form cũ nếu có
            }

            var preForm = new frmHandBrake(this.serialNumber);
            preForm.Show();
            opcManager.SetOPCValue(opcBrakeHCounter, 1);

            this.Close();
        }
        private void btnNextSpeed_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveSpeedData(this.serialNumber, this.speedValue);
        }

        private void frmSpeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (opcCancellationTokenSource != null)
            {
                opcCancellationTokenSource.Cancel();
                opcCancellationTokenSource.Dispose();
                opcCancellationTokenSource = null;
            }
        }
    }
}
