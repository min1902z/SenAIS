using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmFrontWeight : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private SQLHelper sqlHelper;
        private OPCManager opcManager;
        private string serialNumber;
        private double frontLWeight, frontRWeight, rearLWeight, rearRWeight;
        private double weightLeftA = 1.0;
        private double weightRightA = 1.0;
        private static readonly string opcLFWeightResult = ConfigurationManager.AppSettings["Front_LWeight_Result"];
        private static readonly string opcRFWeightResult = ConfigurationManager.AppSettings["Front_RWeight_Result"];
        private static readonly string opcLRWeightResult = ConfigurationManager.AppSettings["Rear_LWeight_Result"];
        private static readonly string opcRRWeightResult = ConfigurationManager.AppSettings["Rear_RWeight_Result"];
        private static readonly string opcSSCounter = ConfigurationManager.AppSettings["SideSlip_Counter"];

        public frmFrontWeight(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            LoadWeightParameters();
            opcManager = new OPCManager();
            cancellationTokenSource = new CancellationTokenSource();

            // 🔹 Khởi tạo UI với giá trị 0
            ResetWeightDisplay();

            // 🔹 Bắt đầu quy trình hiển thị UI và cập nhật OPC
            Task.Run(async () => await StartProcess(cancellationTokenSource.Token), cancellationTokenSource.Token);
        }
        private void LoadWeightParameters()
        {
            lbVinNumber.Text = this.serialNumber;
            try
            {
                weightLeftA = sqlHelper.GetParaValue("LeftWeight", "ParaA");
                weightRightA = sqlHelper.GetParaValue("RightWeight", "ParaA");
            }
            catch (Exception)
            {
                weightLeftA = 1.0;  // Giá trị mặc định tránh lỗi chia 0
                weightRightA = 1.0;
            }
        }
        private void ResetWeightDisplay()
        {
            lbWeightTitle.Visible = true; // 🔹 Hiển thị tiêu đề ban đầu
            tbWeight.Visible = false; // Ẩn bảng cân trước khi bắt đầu

            lbLeft_FWeight.Text = "0.0";
            lbRight_FWeight.Text = "0.0";
            lbSum_FWeight.Text = "0.0";
            lbLeft_RWeight.Text = "0.0";
            lbRight_RWeight.Text = "0.0";
            lbSum_RWeight.Text = "0.0";
        }

        private async Task StartProcess(CancellationToken token)
        {
            try
            {
                // 🔹 Hiển thị `lbWeightTitle` trong 2 giây
                await Task.Delay(2000, token);

                // 🔹 Ẩn `lbWeightTitle`, hiển thị bảng cân
                Invoke((Action)(() =>
                {
                    lbWeightTitle.Visible = false;
                    tbWeight.Visible = true;
                }));

                // 🔹 Bắt đầu cập nhật giá trị cân
                await UpdateWeightValues(token);
            }
            catch (TaskCanceledException) { /* Task bị hủy do đóng form */ }
        }

        private async Task UpdateWeightValues(CancellationToken token)
        {
            try
            {
                int timeoutSeconds = int.TryParse(ConfigurationManager.AppSettings["WeightCheckTimeout"], out int timeout) ? timeout : 30;
                var startTime = DateTime.Now;
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(200, token); // Delay 200ms mỗi lần cập nhật

                    // Lấy dữ liệu OPC
                    double rawFrontLWeight = opcManager.GetOPCValue(opcLFWeightResult);
                    double rawFrontRWeight = opcManager.GetOPCValue(opcRFWeightResult);
                    double rawRearLWeight = opcManager.GetOPCValue(opcLRWeightResult);
                    double rawRearRWeight = opcManager.GetOPCValue(opcRRWeightResult);

                    // 🔹 Tính toán trọng lượng (chia cho weight từ DB)
                    frontLWeight = rawFrontLWeight / weightLeftA;
                    frontRWeight = rawFrontRWeight / weightRightA;
                    //frontRWeight = rawFrontRWeight / weightLeftA;
                    rearLWeight = rawRearLWeight / weightLeftA;
                    rearRWeight = rawRearRWeight / weightRightA;
                    //rearRWeight = rawRearRWeight / weightLeftA;

                    double totalFrontWeight = frontLWeight + frontRWeight;
                    double totalRearWeight = rearLWeight + rearRWeight;

                    // 🔹 Cập nhật UI trên luồng chính
                    if (InvokeRequired)
                    {
                        Invoke((Action)(() => UpdateUI(totalFrontWeight, totalRearWeight)));
                    }
                    else
                    {
                        UpdateUI(totalFrontWeight, totalRearWeight);
                    }

                    // 🔹 Khi có dữ liệu hợp lệ, chờ 2s rồi mở frmSideSlip
                    if (totalFrontWeight > 100 && totalRearWeight > 100)
                    {
                        await Task.Delay(3000, token);
                        MoveToNextStep();
                        return;
                    }
                    if ((DateTime.Now - startTime).TotalSeconds > timeoutSeconds)
                    {
                        MoveToNextStep();
                        return;
                    }
                }
            }
            catch (TaskCanceledException) { }
            catch (Exception)
            {
            }
        }

        private void UpdateUI(double totalFrontWeight, double totalRearWeight)
        {
            lbLeft_FWeight.Text = frontLWeight.ToString("F0");
            lbRight_FWeight.Text = frontRWeight.ToString("F0");
            lbSum_FWeight.Text = totalFrontWeight.ToString("F0");

            lbLeft_RWeight.Text = rearLWeight.ToString("F0");
            lbRight_RWeight.Text = rearRWeight.ToString("F0");
            lbSum_RWeight.Text = totalRearWeight.ToString("F0");
        }

        private void MoveToNextStep()
        {
            cbReady.BackColor = SystemColors.Control;
            // 🔹 Mở form SideSlip
            this.BeginInvoke(new Action(() =>
                {
                    // Kiểm tra nếu frm đã mở, không mở lại
                    if (Application.OpenForms.OfType<frmSideSlip>().Any())
                        return;

                    var nextForm = new frmSideSlip(this.serialNumber);
                    nextForm.Show();
                    opcManager.SetOPCValue(opcSSCounter, 1);

                    // 🔹 Đóng form hiện tại
                    this.Close();
                }));
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmFrontWeight_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
            }
        }
    }
}
