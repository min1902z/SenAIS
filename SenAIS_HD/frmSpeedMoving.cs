using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSpeedMoving : Form
    {
        private bool isAutoMode = true;
        private bool isHoldingButton = false;
        private bool isMotorOn = false;
        private Timer opcUpdateTimer;
        private SQLHelper sqlHelper;
        private bool isOPCConnected = true; // Trạng thái kết nối OPC

        // OPC Tags từ app.config
        private static readonly string opcStart = ConfigurationManager.AppSettings["OPC_Start"];
        private static readonly string opcStop = ConfigurationManager.AppSettings["OPC_Stop"];
        private static readonly string opcMotorControl = ConfigurationManager.AppSettings["OPC_Motor"];
        private static readonly string opcLeftDistance = ConfigurationManager.AppSettings["OPC_LeftDistance"];
        private static readonly string opcRightDistance = ConfigurationManager.AppSettings["OPC_RightDistance"];
        private static readonly string opcSetLeft = ConfigurationManager.AppSettings["OPC_SetLeft"];
        private static readonly string opcSetRight = ConfigurationManager.AppSettings["OPC_SetRight"];
        private static readonly string opcSetAuto = ConfigurationManager.AppSettings["OPC_SetAuto"];
        private static readonly string opcIncreaseLeft = ConfigurationManager.AppSettings["OPC_IncreaseLeft"];
        private static readonly string opcIncreaseRight = ConfigurationManager.AppSettings["OPC_IncreaseRight"];
        private static readonly string opcDecreaseLeft = ConfigurationManager.AppSettings["OPC_DecreaseLeft"];
        private static readonly string opcDecreaseRight = ConfigurationManager.AppSettings["OPC_DecreaseRight"];
        public frmSpeedMoving()
        {
            InitializeComponent();
            InitializeOPCUpdater();
            sqlHelper = new SQLHelper();
            //SetMode(true); // Mặc định là Auto Mode
        }
        private void InitializeOPCUpdater()
        {
            opcUpdateTimer = new Timer { Interval = 500 };
            opcUpdateTimer.Tick += async (s, e) => await UpdateOPCValues();
            opcUpdateTimer.Start();
        }

        private async Task UpdateOPCValues()
        {
            await Task.Run(() =>
            {
                try
                {
                    decimal leftValue = Convert.ToDecimal(OPCUtility.GetOPCValue(opcLeftDistance));
                    decimal rightValue = Convert.ToDecimal(OPCUtility.GetOPCValue(opcRightDistance));

                    decimal leftParaA = Convert.ToDecimal(sqlHelper.GetParaValue("LeftAxis", "ParaA"));
                    decimal leftParaB = Convert.ToDecimal(sqlHelper.GetParaValue("LeftAxis", "ParaB"));

                    decimal rightParaA = Convert.ToDecimal(sqlHelper.GetParaValue("RightAxis", "ParaA"));
                    decimal rightParaB = Convert.ToDecimal(sqlHelper.GetParaValue("RightAxis", "ParaB"));

                    if (leftParaA - leftParaB != 0 && rightParaA - rightParaB != 0)
                    {
                        decimal calculatedLeft = leftValue / (leftParaA - leftParaB);
                        decimal calculatedRight = rightValue / (rightParaA - rightParaB);

                        Invoke(new Action(() =>
                        {
                            txtLeftDistance.Text = calculatedLeft.ToString("F0");
                            txtRightDistance.Text = calculatedRight.ToString("F0");
                        }));
                    }
                    isOPCConnected = true; // Kết nối OPC hoạt động
                }
                catch (Exception)
                {
                    if (isOPCConnected) // Chỉ hiển thị lỗi 1 lần để tránh spam
                    {
                        isOPCConnected = false;
                        MessageBox.Show("Không thể kết nối với OPC. Vui lòng kiểm tra lại!", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            });
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            isAutoMode = !isAutoMode;
            SetMode(isAutoMode);
        }
        private void SetMode(bool isAuto)
        {
            AutoPanel.Enabled = isAuto;
            ManualPanel.Enabled = !isAuto;
            btnMode.Text = isAuto ? "Chế độ: Tự động" : "Chế độ: Thủ công";
            if (isOPCConnected)
            {
                OPCUtility.SetOPCValue(opcSetAuto, isAuto ? 1 : 0);
            }
            else
            {
                // Nếu mất kết nối, đặt mặc định Auto = 1
                isAutoMode = true;
                AutoPanel.Enabled = true;
                ManualPanel.Enabled = false;
                btnMode.Text = "Chế độ: Tự động";
            }
        }
        private void btnDistance1_Click(object sender, EventArgs e)
        {
            txtDistanceValue.Text = "2650";
        }

        private void btnDistance2_Click(object sender, EventArgs e)
        {
            txtDistanceValue.Text = "2750";
        }

        private void btnDistance3_Click(object sender, EventArgs e)
        {
            txtDistanceValue.Text = "2850";
        }

        private void btnDistance4_Click(object sender, EventArgs e)
        {
            txtDistanceValue.Text = "2950";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDistanceValue.Text, out decimal distanceValue))
            {
                decimal leftParaA = Convert.ToDecimal(sqlHelper.GetParaValue("LeftAxis", "ParaA"));
                decimal leftParaB = Convert.ToDecimal(sqlHelper.GetParaValue("LeftAxis", "ParaB"));

                decimal rightParaA = Convert.ToDecimal(sqlHelper.GetParaValue("RightAxis", "ParaA"));
                decimal rightParaB = Convert.ToDecimal(sqlHelper.GetParaValue("RightAxis", "ParaB"));

                int setLeft = (int)((distanceValue + leftParaB) * leftParaA);
                int setRight = (int)((distanceValue + rightParaB) * rightParaA);

                OPCUtility.SetOPCValue(opcSetLeft, setLeft);
                OPCUtility.SetOPCValue(opcSetRight, setRight);
            }
        }
        private void btnStart_MouseDown(object sender, MouseEventArgs e) => OPCUtility.SetOPCValue(opcStart, 1);
        private void btnStart_MouseUp(object sender, MouseEventArgs e) => OPCUtility.SetOPCValue(opcStart, 0);

        private void btnStop_MouseDown(object sender, MouseEventArgs e) => OPCUtility.SetOPCValue(opcStop, 1);
        private void btnStop_MouseUp(object sender, MouseEventArgs e) => OPCUtility.SetOPCValue(opcStop, 0);
        private void btnStartMotor_Click(object sender, EventArgs e)
        {
            isMotorOn = !isMotorOn;
            OPCUtility.SetOPCValue(opcMotorControl, isMotorOn ? 1 : 0);
            btnStartMotor.Text = isMotorOn ? "Tắt Motor" : "Bật Motor";
            pbMotor.BackColor = isMotorOn ? System.Drawing.Color.Green : SystemColors.Control;
        }
        // Xử lý giữ nút để tăng/giảm khoảng cách
        private async void btnHoldDown_MouseDown(object sender, MouseEventArgs e)
        {
            isHoldingButton = true;
            Button btn = sender as Button;
            string opcTag = GetOPCTagByButton(btn);

            while (isHoldingButton)
            {
                OPCUtility.SetOPCValue(opcTag, 1);
                await Task.Delay(200);
            }
        }

        private void btnHoldDown_MouseUp(object sender, MouseEventArgs e)
        {
            isHoldingButton = false;
            Button btn = sender as Button;
            string opcTag = GetOPCTagByButton(btn);
            OPCUtility.SetOPCValue(opcTag, 0);
        }

        private string GetOPCTagByButton(Button btn)
        {
            switch (btn.Name)
            {
                case "btnUpLeftDistance": return opcIncreaseLeft;
                case "btnUpRightDistance": return opcIncreaseRight;
                case "btnDownLeftDistance": return opcDecreaseLeft;
                case "btnDownRightDistance": return opcDecreaseRight;
                default: return "";
            }
        }
        private void btnBackMain_Click(object sender, EventArgs e)
        {
            SenAIS mainForm = Application.OpenForms.OfType<SenAIS>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.BringToFront(); // Đưa Main lên trước
            }
            this.Close(); // Đóng frmSpeedMoving
        }

        private void frmSpeedMoving_FormClosing(object sender, FormClosingEventArgs e)
        {
            opcUpdateTimer?.Stop();
            opcUpdateTimer?.Dispose();
        }
    }
}
