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
    public partial class frmSteerAngle : Form
    {
        private SQLHelper sqlHelper;
        private OPCUtility opcManager;
        private CancellationTokenSource opcCancellationTokenSource;
        private CancellationTokenSource steerMeasurementCts;

        private string serialNumber;
        public decimal leftSteer = 0;
        public decimal rightSteer = 0;
        public decimal leftSteerLW = 0;
        public decimal rightSteerLW = 0;
        public decimal leftSteerRW = 0;
        public decimal rightSteerRW = 0;
        private decimal steerLeftA = 1;
        private decimal steerRightA = 1;
        public decimal minLeftSteer;
        public decimal minRightSteer;
        private bool isReady = false;
        private bool hasProcessedNextVin = false; // Cờ kiểm soát việc next số VIN
        private int lastCounter = -1;
        private int lastPosTest = -1;
        private int lastTurnLeft = -1;
        private int lastTurnRight = -1;
        private List<string> opcItems = new List<string>
        {
            opcLeftSteer,
            opcRightSteer,
            opcLeftSteerLW,
            opcRightSteerLW,
            opcLeftSteerRW,
            opcRightSteerRW
        };
        private static readonly string opcSteerCounter = ConfigurationManager.AppSettings["Steering_Counter"];
        private static readonly string opcTurnLeft = ConfigurationManager.AppSettings["TurnLeft_Steer"];
        private static readonly string opcTurnRight = ConfigurationManager.AppSettings["TurnRight_Steer"];
        private static readonly string opcLeftSteer = ConfigurationManager.AppSettings["LeftSteer_Result"];
        private static readonly string opcRightSteer = ConfigurationManager.AppSettings["RightSteer_Result"];
        private static readonly string opcLeftSteerLW = ConfigurationManager.AppSettings["LeftSteerLW_Result"];
        private static readonly string opcRightSteerLW = ConfigurationManager.AppSettings["RightSteerLW_Result"];
        private static readonly string opcLeftSteerRW = ConfigurationManager.AppSettings["LeftSteerRW_Result"];
        private static readonly string opcRightSteerRW = ConfigurationManager.AppSettings["RightSteerRW_Result"];
        private static readonly string opcPosTest = ConfigurationManager.AppSettings["GL_PosTest"];
        public frmSteerAngle(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            opcManager = new OPCUtility();
        }
        private void StartOPCListener()
        {
            opcCancellationTokenSource = new CancellationTokenSource();
            var token = opcCancellationTokenSource.Token;

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        int steerCounter = opcManager.GetOPCValue(opcSteerCounter);
                        int posTest = opcManager.GetOPCValue(opcPosTest);
                        int turnLeft = opcManager.GetOPCValue(opcTurnLeft);
                        int turnRight = opcManager.GetOPCValue(opcTurnRight);

                        if (steerCounter != lastCounter)
                        {
                            lastCounter = steerCounter;
                            BeginInvoke((MethodInvoker)(() => UpdateCounterStatus(steerCounter)));
                        }

                        if (steerCounter == 2)
                        {
                            var values = opcManager.GetMultipleOPCValues(opcItems);
                            BeginInvoke((MethodInvoker)(() => UpdateSteerValuesUI(values)));
                        }

                        if (posTest != lastPosTest || turnLeft != lastTurnLeft || turnRight != lastTurnRight)
                        {
                            lastPosTest = posTest;
                            lastTurnLeft = turnLeft;
                            lastTurnRight = turnRight;

                            BeginInvoke((MethodInvoker)(() => UpdateSensorStatus(posTest, turnLeft, turnRight)));
                        }
                    }
                    catch
                    {
                        // Bỏ qua lỗi, tránh crash
                    }
                    await Task.Delay(100, token);
                }
            }, token);
        }
        private void UpdateSensorStatus(int posTest, int turnLeft, int turnRight)
        {
            cbPosTest.BackColor = (posTest == 1) ? Color.Green : SystemColors.Control;
            pbLeft.Visible = (turnLeft == 1);
            pbRight.Visible = (turnRight == 1);
        }
        private void UpdateCounterStatus(int counter)
        {
            switch (counter)
            {
                case 0: // Mặc định
                    cbReady.BackColor = SystemColors.Control;
                    tbSteerAngle.Visible = true;
                    lbSteerTitle.Visible = true;
                    isReady = false;
                    hasProcessedNextVin = false;
                    break;

                case 1: // Xe vào vị trí
                    cbReady.BackColor = Color.Green;
                    tbSteerAngle.Visible = false;
                    lbSteerTitle.Visible = true;
                    isReady = false;
                    break;

                case 2: // Bắt đầu đo
                    cbReady.BackColor = Color.Green;
                    tbSteerAngle.Visible = true;
                    lbSteerTitle.Visible = false;
                    isReady = true;
                    break;

                case 3: // Kết thúc đo
                    cbReady.BackColor = Color.Green;
                    tbSteerAngle.Visible = true;
                    lbSteerTitle.Visible = false;

                    if (isReady)
                    {
                        SaveDataToDatabase();
                        isReady = false;
                    }
                    break;

                case 4: // Xe tiếp theo
                    cbReady.BackColor = SystemColors.Control;
                    tbSteerAngle.Visible = true;
                    lbSteerTitle.Visible = true;

                    if (!hasProcessedNextVin)
                    {
                        MoveToNextVin();
                        hasProcessedNextVin = true;
                    }
                    else
                    {
                        this.Close();
                    }
                    break;

                default:
                    cbReady.BackColor = SystemColors.Control;
                    lbSteerTitle.Visible = true;
                    isReady = false;
                    break;
            }
        }
        private void UpdateSteerValuesUI(Dictionary<string, decimal> values)
        {
            lbLeft.Text = Math.Abs(values[opcLeftSteer] / steerLeftA).ToString("F1");
            lbRight.Text = Math.Abs(values[opcRightSteer] / steerRightA).ToString("F1");
            lbLeftSteerLW.Text = Math.Abs(values[opcLeftSteerLW] / steerLeftA).ToString("F1");
            lbRightSteerLW.Text = Math.Abs(values[opcRightSteerLW] / steerRightA).ToString("F1");
            lbLeftSteerRW.Text = Math.Abs(values[opcLeftSteerRW] / steerLeftA).ToString("F1");
            lbRightSteerRW.Text = Math.Abs(values[opcRightSteerRW] / steerRightA).ToString("F1");

            leftSteer = Convert.ToDecimal(lbLeft.Text);
            rightSteer = Convert.ToDecimal(lbRight.Text);
            leftSteerLW = Convert.ToDecimal(lbLeftSteerLW.Text);
            rightSteerLW = Convert.ToDecimal(lbRightSteerLW.Text);
            leftSteerRW = Convert.ToDecimal(lbLeftSteerRW.Text);
            rightSteerRW = Convert.ToDecimal(lbRightSteerRW.Text);

            // Kiểm tra tiêu chuẩn và đổi màu
            lbLeftSteerLW.ForeColor = leftSteerLW >= minLeftSteer ? SystemColors.HotTrack : Color.DarkRed;
            lbLeftSteerRW.ForeColor = leftSteerRW >= minLeftSteer ? SystemColors.HotTrack : Color.DarkRed;
            lbRightSteerLW.ForeColor = rightSteerLW >= minRightSteer ? SystemColors.HotTrack : Color.DarkRed;
            lbRightSteerRW.ForeColor = rightSteerRW >= minRightSteer ? SystemColors.HotTrack : Color.DarkRed;
        }
        private void MoveToNextVin()
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
                    minLeftSteer = ConvertToDecimal(standard["MinLeftSteer"]);
                    minLeftSteer = ConvertToDecimal(standard["MinRightSteer"]);
                }
            }
            steerLeftA = (decimal)sqlHelper.GetParaValue("LeftSteer", "ParaA");
            steerRightA = (decimal)sqlHelper.GetParaValue("RightSteer", "ParaA");
        }
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi Số Máy: " + ex.Message);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi Số Máy: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveSteerAngleData(this.serialNumber, this.leftSteerLW, this.rightSteerLW, this.leftSteerRW, this.rightSteerRW);
        }
        private void frmSteerAngle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (opcCancellationTokenSource != null)
            {
                opcCancellationTokenSource.Cancel();
                opcCancellationTokenSource.Dispose();
                opcCancellationTokenSource = null;
            }
            if (steerMeasurementCts != null)
            {
                steerMeasurementCts.Cancel();
                steerMeasurementCts.Dispose();
                steerMeasurementCts = null;
            }
        }
        private void frmSteerAngle_Load(object sender, EventArgs e)
        {
            LoadVehicleStandards(serialNumber);
            StartOPCListener();
            opcManager.InitializeOPCItems(opcItems);
        }
    }
}
