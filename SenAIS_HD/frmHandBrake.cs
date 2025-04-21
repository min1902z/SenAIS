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
    public partial class frmHandBrake : Form
    {
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal handLeftBrake;
        public decimal handRightBrake;
        public decimal diffHandBrake;
        public decimal sumHandBrake;
        private bool isReady = false;
        private decimal minSumBrake = 0;
        private decimal maxDiffBrake = 0;
        private double brakeLeftA = 1;
        private double brakeRightA = 1;
        private CancellationTokenSource opcCancellationToken = new CancellationTokenSource();
        private OPCManager opcManager;
        private static readonly string opcBrakeCounter = ConfigurationManager.AppSettings["BrakeH_Counter"];
        private static readonly string opcLBrakeResult = ConfigurationManager.AppSettings["Hand_LBrake_Result"];
        private static readonly string opcRBrakeResult = ConfigurationManager.AppSettings["Hand_RBrake_Result"];
        private static readonly string opcBrakeRCounter = ConfigurationManager.AppSettings["BrakeR_Counter"];
        public frmHandBrake(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
            opcManager = new OPCManager();
            StartOPCListener();
        }
        private async void StartOPCListener()
        {
            opcCancellationToken = new CancellationTokenSource();
            CancellationToken token = opcCancellationToken.Token;

            try
            {
                int lastCounter = -1;
                await Task.Run(async () =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        try
                        {
                            // 🔹 Lấy giá trị counter trước
                            int checkCounter = (int)opcManager.GetOPCValue(opcBrakeCounter);

                            // 🔹 Chỉ lấy giá trị brake nếu counter == 2
                            Dictionary<string, decimal> values = new Dictionary<string, decimal>();
                            if (checkCounter == 2)
                            {
                                values[opcLBrakeResult] = opcManager.GetOPCValue(opcLBrakeResult);
                                values[opcRBrakeResult] = opcManager.GetOPCValue(opcRBrakeResult);
                            }

                            // 🔹 Cập nhật UI nếu có thay đổi
                            if (checkCounter != lastCounter || checkCounter == 2)
                            {
                                lastCounter = checkCounter;
                                UpdateUI(checkCounter, values);
                            }
                        }
                        catch (Exception)
                        {
                        }
                        await Task.Delay(100, token); // Giữ tốc độ lấy dữ liệu nhanh nhưng có thể điều chỉnh linh hoạt
                    }
                }, token);
            }
            catch (TaskCanceledException)
            {
            }
            catch (Exception)
            {
            }
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

            handLeftBrake = Convert.ToDecimal(leftBrake);
            handRightBrake = Convert.ToDecimal(rightBrake);
            diffHandBrake = Convert.ToDecimal(diffBrake);
            sumHandBrake = Convert.ToDecimal(sumBrake);

            lbSum_Brake.ForeColor = sumHandBrake >= minSumBrake ? Color.Blue : Color.DarkRed;
            lbDiff_Brake.ForeColor = (maxDiffBrake == 0 || diffHandBrake <= maxDiffBrake) ? Color.Blue : Color.DarkRed;
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
        private void MoveToNextCar()
        {
            cbReady.BackColor = SystemColors.Control;
            Form currentForm = this;

            // 🔹 Đóng form hiện tại trước khi mở frmRearBrake
            this.BeginInvoke(new Action(() =>
            {
                // Kiểm tra nếu frmRearBrake đã mở, không mở lại
                if (Application.OpenForms.OfType<frmSpeed>().Any())
                    return;

                // 🔹 Mở frmRearBrake
                var formBrake = new frmSpeed(this.serialNumber);
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
                    minSumBrake = ConvertToDecimal(standard["MinHandBrake"]);
                    maxDiffBrake = ConvertToDecimal(standard["MaxDiffHandBrake"]);
                }
            }
            brakeLeftA = sqlHelper.GetParaValue("LeftBrake", "ParaA");
            brakeRightA = sqlHelper.GetParaValue("RightBrake", "ParaA");
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            var existingForm = Application.OpenForms.OfType<frmRearBrake>().FirstOrDefault();
            if (existingForm != null)
            {
                existingForm.Close(); // 🔥 Đóng form cũ nếu có
            }

            var preForm = new frmRearBrake(this.serialNumber);
            preForm.Show();
            opcManager.SetOPCValue(opcBrakeRCounter, 1);

            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveHandBrakeData(this.serialNumber, this.handLeftBrake, this.handRightBrake);
        }
        private void frmHandBrake_FormClosing(object sender, FormClosingEventArgs e)
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
