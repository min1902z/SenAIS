using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSideSlip2 : Form
    {
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public decimal sideSlip;
        private decimal minSideSlip = 0;
        private decimal maxSideSlip = 0;
        private static readonly string opcSSCounter = ConfigurationManager.AppSettings["SideSlip_Counter"];
        private static readonly string opcSSResult = ConfigurationManager.AppSettings["SideSlip_Result"];
        private static readonly string opcSSSign = ConfigurationManager.AppSettings["SideSlip_Sign"];
        public frmSideSlip2(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 500; // Kiểm tra mỗi giây
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();
        }
        private async void UpdateReadyStatus(object sender, EventArgs e)
        {
            try
            {
                lbVinNumber.Text = this.serialNumber;
                // Lấy giá trị OPC
                int checkStatus = await Task.Run(() => (int)OPCUtility.GetOPCValue(opcSSCounter));
                Invoke((Action)(() =>
                {
                    switch (checkStatus)
                    {
                        case 0: // Mặc định
                            cbReady.BackColor = SystemColors.Control;
                            lbSideSlip.Visible = false;
                            lbStandard.Visible = false;
                            break;

                        case 1: // Xe vào vị trí
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            lbSideSlip.Visible = false;
                            lbStandard.Visible = true;
                            lbStandard.Text = (minSideSlip != 0 && maxSideSlip != 0) ? $"[{minSideSlip.ToString("F0")}]  -  [{maxSideSlip.ToString("F0")}]" : "--  -  --";
                            break;

                        case 2: // Bắt đầu đo
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            lbSideSlipTitle.Visible = false;
                            lbSideSlip.Visible = true;

                            double alignA = 1.0;
                            alignA = sqlHelper.GetParaValue("SideSlip", "ParaA");
                            double sideSlipSign = (double)OPCUtility.GetOPCValue(opcSSSign);
                            double sideSlipResult = (double)OPCUtility.GetOPCValue(opcSSResult);
                            double sideSlip = 0.0;

                            if (sideSlipSign == 0)
                            {
                                sideSlip = sideSlipResult / alignA;
                            }
                            else if (sideSlipSign == 1)
                            {
                                sideSlip = -1 * (sideSlipResult / alignA);
                            }
                            else
                            {
                                MessageBox.Show("Lỗi giá trị SideSlip_Sign. ");
                            }
                            lbSideSlip.Text = sideSlip.ToString("F1");

                            this.sideSlip = Convert.ToDecimal(sideSlip.ToString("F1"));
                            break;

                        case 3: // Quá trình đo hoàn tất, lưu vào DB
                            cbReady.BackColor = Color.Green; // Đèn xanh
                            lbSideSlipTitle.Visible = false;
                            lbSideSlip.Visible = true;
                            break;
                        case 4: // Xe tiếp theo
                            cbReady.BackColor = SystemColors.Control;
                            lbSideSlipTitle.Visible = true;
                            lbStandard.Visible = false;
                            this.Close();
                            break;
                        default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                            cbReady.BackColor = SystemColors.Control; // Màu mặc định
                            lbStandard.Visible = false;
                            break;
                    }
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
            }
        }

        private void frmSideSlip2_FormClosing(object sender, FormClosingEventArgs e)
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
