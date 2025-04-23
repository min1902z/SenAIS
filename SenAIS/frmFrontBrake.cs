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
    public partial class frmFrontBrake : Form
    {
        //private Timer updateTimer;
        private SQLHelper sqlHelper;
        private OPCUtility opcManager;
        private CancellationTokenSource opcCancellationToken;
        private string serialNumber;
        public decimal frontLeftBrake;
        public decimal frontRightBrake;
        public decimal diffFrontBrake;
        public decimal sumFrontBrake;
        private bool isReady = false;
        private decimal minSumBrake = 0;
        private decimal maxDiffBrake = 0;
        private double brakeLeftA = 1;
        private double brakeRightA = 1;
        private static readonly string opcBrakeCounter = ConfigurationManager.AppSettings["BrakeF_Counter"];
        private static readonly string opcLBrakeResult = ConfigurationManager.AppSettings["Front_LBrake_Result"];
        private static readonly string opcRBrakeResult = ConfigurationManager.AppSettings["Front_RBrake_Result"];
        public frmFrontBrake(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            opcManager = new OPCUtility();
            LoadVehicleStandards(serialNumber);
            //InitializeTimer();
            StartOPCListener();
        }
        //private void InitializeTimer()
        //{
        //    updateTimer = new Timer();
        //    updateTimer.Interval = 500; // Kiểm tra mỗi giây
        //    updateTimer.Tick += new EventHandler(UpdateReadyStatus);
        //    updateTimer.Start();
        //}
        //private async void UpdateReadyStatus(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lbVinNumber.Text = this.serialNumber;
        //        // Lấy giá trị OPC
        //        int checkStatus = await Task.Run(() => (int)opcManager.GetOPCValue(opcBrakeCounter));
        //        Invoke((Action)(async () =>
        //        {
        //            switch (checkStatus)
        //            {
        //                case 0: // Mặc định
        //                    cbReady.BackColor = SystemColors.Control;
        //                    cbBrake.BackColor = SystemColors.Control;
        //                    lbLeft_Brake.Text = "0.0";
        //                    lbRight_Brake.Text = "0.0";
        //                    lbDiff_Brake.Text = "0.0";
        //                    lbSum_Brake.Text = "0.0";
        //                    tbLeft.Visible = false;
        //                    tbRight.Visible = false;
        //                    lbBrakeTitle.Visible = true;
        //                    isReady = false;
        //                    break;

        //                case 1: // Xe vào vị trí
        //                    cbReady.BackColor = Color.Green; // Đèn xanh sáng
        //                    isReady = false; // Chưa sẵn sàng lưu
        //                    tbLeft.Visible = false;
        //                    tbRight.Visible = false;
        //                    break;

        //                case 2: // Bắt đầu đo
        //                    cbReady.BackColor = Color.Green; // Đèn xanh sáng
        //                    isReady = true; // Sẵn sàng lưu sau khi đo
        //                    lbBrakeTitle.Visible = false;
        //                    tbLeft.Visible = true;
        //                    tbRight.Visible = true;
        //                    cbBrake.BackColor = Color.Red;
        //                    await HandleMeasurement(); // Đo và xử lý dữ liệu
        //                    break;

        //                case 3: // Quá trình đo hoàn tất, lưu vào DB
        //                    cbReady.BackColor = Color.Green; // Đèn xanh
        //                    cbBrake.BackColor = SystemColors.Control;
        //                    lbBrakeTitle.Visible = false;
        //                    tbLeft.Visible = true;
        //                    tbRight.Visible = true;
        //                    if (isReady)
        //                    {
        //                        SaveDataToDatabase(); // Lưu dữ liệu
        //                        isReady = false;
        //                    }
        //                    break;

        //                case 4: // Xe tiếp theo
        //                    cbReady.BackColor = SystemColors.Control;
        //                    lbBrakeTitle.Visible = false;
        //                    var formBrake = new frmRearBrake(this.serialNumber);
        //                    formBrake.Show();
        //                    this.Close();
        //                    break;

        //                default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
        //                    cbReady.BackColor = SystemColors.Control; // Màu mặc định
        //                    isReady = false;
        //                    lbBrakeTitle.Visible = true;
        //                    break;
        //            }
        //        }));
        //    }
        //    catch
        //    {
        //    }
        //}
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

            frontLeftBrake = Convert.ToDecimal(leftBrake);
            frontRightBrake = Convert.ToDecimal(rightBrake);
            diffFrontBrake = Convert.ToDecimal(diffBrake);
            sumFrontBrake = Convert.ToDecimal(sumBrake);

            lbSum_Brake.ForeColor = sumFrontBrake >= minSumBrake ? Color.Blue : Color.DarkRed;
            lbDiff_Brake.ForeColor = (maxDiffBrake == 0 || diffFrontBrake <= maxDiffBrake) ? Color.Blue : Color.DarkRed;
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
                if (Application.OpenForms.OfType<frmRearBrake>().Any())
                    return;

                // 🔹 Mở frmRearBrake
                var formBrake = new frmRearBrake(this.serialNumber);
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
                    minSumBrake = ConvertToDecimal(standard["MinFrontBrake"]);
                    maxDiffBrake = ConvertToDecimal(standard["MaxDiffFrontBrake"]);
                }
            }
            brakeLeftA = sqlHelper.GetParaValue("LeftBrake", "ParaA");
            brakeRightA = sqlHelper.GetParaValue("RightBrake", "ParaA");
        }
        //private Task HandleMeasurement()
        //{
        //    // Đảm bảo giá trị ParaA không bằng 0 để tránh lỗi chia 0
        //    brakeRightA = brakeRightA == 0 ? 1 : brakeRightA;
        //    brakeLeftA = brakeLeftA == 0 ? 1 : brakeLeftA;

        //    // Lấy giá trị OPC
        //    double leftBrakeResult = opcManager.GetOPCValue(opcLBrakeResult);
        //    double rightBrakeResult = opcManager.GetOPCValue(opcRBrakeResult);

        //    // Tính toán giá trị phanh với hệ số điều chỉnh
        //    double leftBrake = leftBrakeResult / brakeLeftA;
        //    double rightBrake = rightBrakeResult / brakeRightA;

        //    // Tính độ lệch, tránh lỗi chia 0
        //    double maxBrake = Math.Max(leftBrake, rightBrake);
        //    double diffBrake = maxBrake > 0 ? Math.Abs(leftBrake - rightBrake) / maxBrake * 100 : 0;

        //    double sumBrake = leftBrake + rightBrake;
        //    lbLeft_Brake.Text = leftBrake.ToString("F0");
        //    lbRight_Brake.Text = rightBrake.ToString("F0");
        //    lbDiff_Brake.Text = diffBrake.ToString("F1");
        //    lbSum_Brake.Text = sumBrake.ToString("F0");

        //    frontLeftBrake = Convert.ToDecimal(leftBrake);
        //    frontRightBrake = Convert.ToDecimal(rightBrake);
        //    diffFrontBrake = Convert.ToDecimal(diffBrake);
        //    sumFrontBrake = Convert.ToDecimal(sumBrake);

        //    // Kiểm tra tiêu chuẩn phanh
        //    bool isSumStandard = sumFrontBrake >= minSumBrake;
        //    bool isDiffStandard = maxDiffBrake == 0 || diffFrontBrake <= maxDiffBrake;

        //    lbSum_Brake.ForeColor = isSumStandard ? SystemColors.HotTrack : Color.DarkRed;
        //    lbDiff_Brake.ForeColor = isDiffStandard ? SystemColors.HotTrack : Color.DarkRed;
        //    return Task.CompletedTask;
        //}

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
            catch (Exception)
            {
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
            catch (Exception)
            {
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveFrontBrakeData(this.serialNumber, this.frontLeftBrake, this.frontRightBrake);
        }
        private void frmFrontBrake_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (updateTimer != null)
            //{
            //    updateTimer.Stop(); // Dừng Timer
            //    updateTimer.Dispose(); // Giải phóng tài nguyên
            //    updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            //}
            //e.Cancel = false;
            if (opcCancellationToken != null)
            {
                opcCancellationToken.Cancel();
                opcCancellationToken.Dispose();
                opcCancellationToken = null;
            }
        }
    }
}
