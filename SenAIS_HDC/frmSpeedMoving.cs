using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSpeedMoving : Form
    {
        private bool isAutoMode = true;
        private bool isHoldingButton = false;
        private bool isMotorOn = false;
        //private Timer opcUpdateTimer;
        private SQLHelper sqlHelper;
        private OPCManager opcManager;
        private decimal leftParaA = 1, leftParaB = 0;
        private decimal rightParaA = 1, rightParaB = 0;
        private bool isOPCConnected = true; // Trạng thái kết nối OPC
        private CancellationTokenSource opcUpdateCts;

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
            sqlHelper = new SQLHelper();
            opcManager = new OPCManager();
            if (opcManager.IsConnected)
            {
                LoadParaValues();
                StartOPCUpdater();
            }
        }
        private void StartOPCUpdater()
        {
            opcUpdateCts = new CancellationTokenSource();
            CancellationToken token = opcUpdateCts.Token;

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    await UpdateOPCValues();
                    await Task.Delay(200, token);
                }
            }, token);
        }
        private void LoadParaValues()
        {
            try
            {
                btnDistance1.Text = $"{ConfigurationManager.AppSettings["Distance1Name"]} \n {ConfigurationManager.AppSettings["Distance1Value"]} mm";
                btnDistance2.Text = $"{ConfigurationManager.AppSettings["Distance2Name"]} \n {ConfigurationManager.AppSettings["Distance2Value"]} mm";
                btnDistance3.Text = $"{ConfigurationManager.AppSettings["Distance3Name"]} \n {ConfigurationManager.AppSettings["Distance3Value"]} mm";
                btnDistance4.Text = $"{ConfigurationManager.AppSettings["Distance4Name"]} \n {ConfigurationManager.AppSettings["Distance4Value"]} mm";

                leftParaA = Convert.ToDecimal(sqlHelper.GetParaValue("LeftAxis", "ParaA"));
                leftParaB = Convert.ToDecimal(sqlHelper.GetParaValue("LeftAxis", "ParaB"));

                rightParaA = Convert.ToDecimal(sqlHelper.GetParaValue("RightAxis", "ParaA"));
                rightParaB = Convert.ToDecimal(sqlHelper.GetParaValue("RightAxis", "ParaB"));
            }
            catch (Exception)
            {
                leftParaA = 1; leftParaB = 0;
                rightParaA = 1; rightParaB = 0;
            }
        }
        private async Task UpdateOPCValues()
        {
            try
            {
                decimal leftValue = 0, rightValue = 0;
                await Task.Run(() =>
                {
                    try
                    {
                        leftValue = Convert.ToDecimal(opcManager.GetOPCValue(opcLeftDistance));
                        rightValue = Convert.ToDecimal(opcManager.GetOPCValue(opcRightDistance));
                    }
                    catch (Exception)
                    {
                            isOPCConnected = false;
                    }
                });

                if (leftParaA - leftParaB != 0 && rightParaA - rightParaB != 0)
                {
                    decimal calculatedLeft = leftValue / leftParaA - leftParaB;
                    decimal calculatedRight = rightValue / rightParaA - rightParaB;
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            txtLeftDistance.Text = calculatedLeft.ToString("F0");
                            txtRightDistance.Text = calculatedRight.ToString("F0");
                        }));
                    }
                }

                isOPCConnected = true;
            }
            catch (Exception)
            {
                // Nếu form đóng thì không cần thông báo lỗi nhiều lần
            }

        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            isAutoMode = !isAutoMode;
            SetMode(isAutoMode);
        }
        private void SetMode(bool isAuto)
        {
            btnMode.Text = isAuto ? "Chế độ: Tự động" : "Chế độ: Thủ công";

            if (isOPCConnected)
            {
                if (isAuto)
                {
                    isMotorOn = false;
                    btnStartMotor.Text = "Bật Motor";
                    pbMotor.BackColor = SystemColors.Control;
                    opcManager.SetOPCValue(opcMotorControl, 0);
                }
                opcManager.SetOPCValue(opcSetAuto, isAuto ? 0 : 1);
            }
            else
            {
                // Nếu mất kết nối, đặt mặc định Auto = 1
                isAutoMode = true;
                btnMode.Text = "Chế độ: Tự động";
            }
        }
        private void btnDistance1_Click(object sender, EventArgs e)
        {
            txtDistanceValue.Text = ConfigurationManager.AppSettings["Distance1Value"];
        }

        private void btnDistance2_Click(object sender, EventArgs e)
        {
            txtDistanceValue.Text = ConfigurationManager.AppSettings["Distance2Value"];
        }

        private void btnDistance3_Click(object sender, EventArgs e)
        {
            txtDistanceValue.Text = ConfigurationManager.AppSettings["Distance3Value"];
        }

        private void btnDistance4_Click(object sender, EventArgs e)
        {
            txtDistanceValue.Text = ConfigurationManager.AppSettings["Distance4Value"];
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDistanceValue.Text, out decimal distanceValue))
            {
                int setLeft = (int)((distanceValue + leftParaB) * leftParaA);
                int setRight = (int)((distanceValue + rightParaB) * rightParaA);

                opcManager.SetOPCValue(opcSetLeft, setLeft);
                opcManager.SetOPCValue(opcSetRight, setRight);
            }
        }
        private void btnStart_MouseDown(object sender, MouseEventArgs e) => opcManager.SetOPCValue(opcStart, 1);
        private void btnStart_MouseUp(object sender, MouseEventArgs e) => opcManager.SetOPCValue(opcStart, 0);

        private void btnStop_MouseDown(object sender, MouseEventArgs e) => opcManager.SetOPCValue(opcStop, 1);
        private void btnStop_MouseUp(object sender, MouseEventArgs e) => opcManager.SetOPCValue(opcStop, 0);
        private async void btnStartMotor_ClickAsync(object sender, EventArgs e)
        {
            isMotorOn = !isMotorOn;
            btnStartMotor.Text = isMotorOn ? "Tắt Motor" : "Bật Motor";
            pbMotor.BackColor = isMotorOn ? System.Drawing.Color.Green : SystemColors.Control;
            await Task.Run(() => opcManager.SetOPCValue(opcMotorControl, isMotorOn ? 1 : 0));
        }
        // Xử lý giữ nút để tăng/giảm khoảng cách
        private void btnHoldDown_MouseDown(object sender, MouseEventArgs e)
        {
            isHoldingButton = true;
            Button btn = sender as Button;
            string opcTag = GetOPCTagByButton(btn);
            if (isHoldingButton)
                opcManager.SetOPCValue(opcTag, 1);
        }

        private void btnHoldDown_MouseUp(object sender, MouseEventArgs e)
        {
            isHoldingButton = false;
            Button btn = sender as Button;
            string opcTag = GetOPCTagByButton(btn);
            if (!isHoldingButton)
                opcManager.SetOPCValue(opcTag, 0);
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
            opcUpdateCts?.Cancel();
            opcUpdateCts?.Dispose();
        }
    }
}
