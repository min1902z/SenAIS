using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmRearBrake : Form
    {
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal rearLeftBrake;
        public decimal rearRightBrake;
        public decimal diffRearBrake;
        public decimal sumRearBrake;
        private bool isReady = false;
        private decimal minSumBrake = 0;
        private decimal maxDiffBrake = 0;
        private double brakeLeftA = 1;
        private double brakeRightA = 1;
        private CancellationTokenSource opcCancellationToken;
        private int lastCounter = -1;
        private int lastBrakeSensor = -1;
        private OPCManager opcManager;
        private static readonly string opcBrakeRCounter = ConfigurationManager.AppSettings["BrakeR_Counter"];
        private static readonly string opcLBrakeResult = ConfigurationManager.AppSettings["Rear_LBrake_Result"];
        private static readonly string opcRBrakeResult = ConfigurationManager.AppSettings["Rear_RBrake_Result"];
        private static readonly string opcBrakeFCounter = ConfigurationManager.AppSettings["BrakeF_Counter"];
        private static readonly string opcBrakeSen = ConfigurationManager.AppSettings["Brake_Sensor"];
        public frmRearBrake(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
            opcManager = new OPCManager();
            StartOPCListener();
        }
        private void StartOPCListener()
        {
            if (opcCancellationToken != null)
                return; // Đã khởi tạo rồi thì không khởi tạo lại

            opcCancellationToken = new CancellationTokenSource();
            CancellationToken token = opcCancellationToken.Token;

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        // 🔹 Lấy Counter và cảm biến Brake
                        int checkCounter = (int)opcManager.GetOPCValue(opcBrakeRCounter);
                        int brakeSensor = (int)opcManager.GetOPCValue(opcBrakeSen);

                        Dictionary<string, decimal> values = new Dictionary<string, decimal>();

                        if (checkCounter == 2)
                        {
                            values[opcLBrakeResult] = opcManager.GetOPCValue(opcLBrakeResult);
                            values[opcRBrakeResult] = opcManager.GetOPCValue(opcRBrakeResult);
                        }

                        // 🔹 Nếu Counter thay đổi hoặc = 2 thì cập nhật
                        if (checkCounter != lastCounter || checkCounter == 2)
                        {
                            lastCounter = checkCounter;
                            this.BeginInvoke((MethodInvoker)(() => UpdateUI(checkCounter, values)));
                        }

                        // 🔹 Nếu cảm biến Brake thay đổi thì cập nhật màu
                        if (brakeSensor != lastBrakeSensor)
                        {
                            lastBrakeSensor = brakeSensor;
                            this.BeginInvoke((MethodInvoker)(() =>
                            {
                                cbSensor.BackColor = (brakeSensor == 1) ? Color.Green : SystemColors.Control;
                            }));
                        }
                    }
                    catch
                    {
                        // Bỏ qua lỗi đọc OPC
                    }

                    await Task.Delay(100, token);
                }
            }, token);
        }
        private void UpdateUI(int counter, Dictionary<string, decimal> values)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateUI(counter, values)));
                return;
            }

            UpdateCounterStatus(counter);

            if (counter == 2)
            {
                UpdateBrakeValues(values);
            }
        }
        private void UpdateCounterStatus(int counter)
        {
            switch (counter)
            {
                case 0: // Mặc định
                    ResetUI();
                    break;
                case 1: // Xe vào vị trí
                    cbReady.BackColor = Color.Green;
                    break;
                case 2: // Bắt đầu đo
                    cbReady.BackColor = Color.Green;
                    isReady = true;
                    cbBrake.BackColor = Color.Red;
                    lbBrakeTitle.Visible = false;
                    tbLeft.Visible = tbRight.Visible = true;
                    break;
                case 3: // Hoàn tất, lưu DB
                    cbReady.BackColor = Color.Green;
                    cbBrake.BackColor = SystemColors.Control;
                    if (isReady)
                    {
                        SaveDataToDatabase();
                        isReady = false;
                    }
                    break;
                case 4: // Xe tiếp theo
                    cbReady.BackColor = SystemColors.Control;
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
            cbBrake.BackColor = SystemColors.Control;
            lbBrakeTitle.Visible = true;
            lbLeft_Brake.Text = lbRight_Brake.Text = "0.0";
            lbDiff_Brake.Text = lbSum_Brake.Text = "0.0";
            tbLeft.Visible = tbRight.Visible = false;
            isReady = false;
        }

        private void UpdateBrakeValues(Dictionary<string, decimal> values)
        {
            double leftBrakeResult = values.ContainsKey(opcLBrakeResult) ? (double)values[opcLBrakeResult] : 0;
            double rightBrakeResult = values.ContainsKey(opcRBrakeResult) ? (double)values[opcRBrakeResult] : 0;

            double leftBrake = leftBrakeResult / (brakeLeftA == 0 ? 1 : brakeLeftA);
            double rightBrake = rightBrakeResult / (brakeRightA == 0 ? 1 : brakeRightA);
            double maxBrake = Math.Max(leftBrake, rightBrake);
            double diffBrake = maxBrake > 0 ? Math.Abs(leftBrake - rightBrake) / maxBrake * 100 : 0;
            double sumBrake = leftBrake + rightBrake;

            lbLeft_Brake.Text = leftBrake.ToString("F0");
            lbRight_Brake.Text = rightBrake.ToString("F0");
            lbDiff_Brake.Text = diffBrake.ToString("F1");
            lbSum_Brake.Text = sumBrake.ToString("F0");

            rearLeftBrake = Convert.ToDecimal(leftBrake);
            rearRightBrake = Convert.ToDecimal(rightBrake);
            diffRearBrake = Convert.ToDecimal(diffBrake);
            sumRearBrake = Convert.ToDecimal(sumBrake);

            lbSum_Brake.ForeColor = sumRearBrake >= minSumBrake ? Color.Blue : Color.DarkRed;
            lbDiff_Brake.ForeColor = (maxDiffBrake == 0 || diffRearBrake <= maxDiffBrake) ? Color.Blue : Color.DarkRed;
        }

        private void MoveToNextCar()
        {
            cbReady.BackColor = SystemColors.Control;
            Form currentForm = this;

            // 🔹 Đóng form hiện tại trước khi mở frmRearBrake
            this.BeginInvoke(new Action(() =>
            {
                // Kiểm tra nếu frmRearBrake đã mở, không mở lại
                if (Application.OpenForms.OfType<frmHandBrake>().Any())
                    return;

                // 🔹 Mở frmRearBrake
                var formBrake = new frmHandBrake(this.serialNumber);
                formBrake.Show();

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
            DataRow vehicleDetails = sqlHelper.GetVehicleDetails(serialNumber);
            if (vehicleDetails != null)
            {
                string vehicleType = vehicleDetails["VehicleType"].ToString();
                DataTable vehicleStandards = sqlHelper.GetVehicleStandardsByTypeCar(vehicleType);
                if (vehicleStandards.Rows.Count > 0)
                {
                    DataRow standard = vehicleStandards.Rows[0];
                    minSumBrake = ConvertToDecimal(standard["MinRearBrake"]);
                    maxDiffBrake = ConvertToDecimal(standard["MaxDiffRearBrake"]);
                }
            }
            brakeLeftA = sqlHelper.GetParaValue("LeftBrake", "ParaA");
            brakeRightA = sqlHelper.GetParaValue("RightBrake", "ParaA");
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            var existingForm = Application.OpenForms.OfType<frmFrontBrake>().FirstOrDefault();
            if (existingForm != null)
            {
                existingForm.Close(); // 🔥 Đóng form cũ nếu có
            }

            var preForm = new frmFrontBrake(this.serialNumber);
            preForm.Show();
            opcManager.SetOPCValue(opcBrakeFCounter, 1);

            this.Close();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveRearBrakeData(this.serialNumber, this.rearLeftBrake, this.rearRightBrake);
        }
        private void frmRearBrake_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (opcCancellationToken != null)
            {
                opcCancellationToken.Cancel();
                opcCancellationToken.Dispose();
                opcCancellationToken = null;
            }
        }
    }
}
