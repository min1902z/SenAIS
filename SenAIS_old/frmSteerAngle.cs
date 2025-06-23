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
        private CancellationTokenSource sensorCancellationTokenSource;

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
        public decimal maxLeftSteer;
        public decimal maxRightSteer;
        private bool isReady = false;
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
                int lastCounter = -1;
                while (!token.IsCancellationRequested)
                {
<<<<<<< HEAD:SenAIS/frmSteerAngle.cs
                    try
                    {
                        int steerCounter = opcManager.GetOPCValue(opcSteerCounter);
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
                    }
                    catch
                    {
                        // Bỏ qua lỗi, tránh crash
                    }
                    await Task.Delay(100, token);
                }
            }, token);
        }
        private void StartSensorMonitoring()
        {
            sensorCancellationTokenSource = new CancellationTokenSource();
            var token = sensorCancellationTokenSource.Token;

            Task.Run(async () =>
=======
                    pbLeft.Visible = turnLeft == 1; // Hiển thị nếu turnLeft = 1, ẩn nếu = 0
                }

                if (values.TryGetValue(opcTurnRight, out var turnRight))
                {
                    pbRight.Visible = turnRight == 1; // Hiển thị nếu turnRight = 1, ẩn nếu = 0
                }

                if (values.TryGetValue(opcPos1, out var pos1))
                {
                    cbPos1.BackColor = pos1 == 1 ? Color.Green : Color.Red;
                }

                if (values.TryGetValue(opcPos2, out var pos2))
                {
                    cbPos2.BackColor = pos2 == 1 ? Color.Green : Color.Red;
                }

                if (values.TryGetValue(opcPosTest, out var posTest))
                {
                    cbPosTest.BackColor = posTest == 1 ? Color.Green : Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cảm biến: {ex.Message}");
            }
        }
        private void InitializePollingTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 200; // Kiểm tra mỗi 0.2 giây
            updateTimer.Tick += PollOPCValues;
            updateTimer.Start();
        }
        private void PollOPCValues(object sender, EventArgs e)
        {
            try
            {
                // Lấy tất cả giá trị OPC trong một lần
                var values = OPCUtility.GetMultipleOPCValues(opcItems);
                // Xử lý trạng thái dựa trên SteerCounter
                int steerCounter = values.ContainsKey(opcSteerCounter) ? (int)values[opcSteerCounter] : 0;
                UpdateReadyStatus(steerCounter, values);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in PollOPCValues: {ex.Message}");
            }
        }
        private void UpdateReadyStatus(int steerCounter, Dictionary<string, decimal> values)
        {
            try
            {
                lbVinNumber.Text = this.serialNumber;
                Invoke((Action)(() =>
            {
                switch (steerCounter)
                {
                    case 0: // Mặc định
                        cbReady.BackColor = SystemColors.Control;
                        tbSteerAngle.Visible = false;
                        lbSteerTitle.Visible = true;
                        isReady = false;
                        hasProcessedNextVin = false; // Reset cờ chuyển số VIN
                        break;
                    case 1: // Xe vào vị trí
                        cbReady.BackColor = Color.Green; // Đèn xanh sáng
                        tbSteerAngle.Visible = false;
                        lbSteerTitle.Visible = true;
                        isReady = false; // Chưa sẵn sàng lưu
                        break;

                    case 2: // Bắt đầu đo
                        cbReady.BackColor = Color.Green; // Đèn xanh sáng
                        isReady = true; // Sẵn sàng lưu sau khi đo
                        tbSteerAngle.Visible = true;
                        lbSteerTitle.Visible = false;
                        UpdateSteerValuesUI(values);
                        break;

                    case 3: // Quá trình đo hoàn tất, lưu vào DB
                        cbReady.BackColor = Color.Green; // Đèn xanh
                        tbSteerAngle.Visible = true;
                        lbSteerTitle.Visible = false;
                        if (isReady)
                        {
                            SaveDataToDatabase(); // Ghi dữ liệu vào DB
                            isReady = false; // Đặt lại trạng thái
                        }
                        break;
                    case 4: // Xe tiếp theo
                        cbReady.BackColor = SystemColors.Control;
                        tbSteerAngle.Visible = false;
                        lbSteerTitle.Visible = true;
                        if (!hasProcessedNextVin)
                        {
                            string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                            if (!string.IsNullOrEmpty(nextSerialNumber))
                            {
                                this.serialNumber = nextSerialNumber;
                                var frmMain = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
                                if (frmMain != null)
                                {
                                    var txtVinNumber = frmMain.Controls.Find("txtVinNum", true).FirstOrDefault() as TextBox;
                                    if (txtVinNumber != null)
                                    {
                                        txtVinNumber.Text = this.serialNumber; // Cập nhật số VIN
                                    }
                                }
                                hasProcessedNextVin = true; // Đánh dấu đã xử lý
                                this.Close();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        break;

                    default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                        cbReady.BackColor = SystemColors.Control; // Màu mặc định
                        lbSteerTitle.Visible = true;
                        isReady = false;
                        break;
                }
            }));
            }
            catch
>>>>>>> SenAIS_HD:SenAIS_old/frmSteerAngle.cs
            {
                int lastPosTest = -1, lastTurnLeft = -1, lastTurnRight = -1;

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        int posTest = opcManager.GetOPCValue(opcPosTest);
                        int turnLeft = opcManager.GetOPCValue(opcTurnLeft);
                        int turnRight = opcManager.GetOPCValue(opcTurnRight);

                        if (posTest != lastPosTest || turnLeft != lastTurnLeft || turnRight != lastTurnRight)
                        {
                            lastPosTest = posTest;
                            lastTurnLeft = turnLeft;
                            lastTurnRight = turnRight;

                            BeginInvoke((MethodInvoker)(() => UpdateSensorStatus(posTest, turnLeft, turnRight)));
                        }
                    }
                    catch { }

                    await Task.Delay(50, token);
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
                    MoveToNextVin();
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
            lbLeftSteerLW.ForeColor = (maxLeftSteer == 0 && leftSteerLW > minLeftSteer) || (maxLeftSteer > 0 && leftSteerLW >= minLeftSteer && leftSteerLW <= maxLeftSteer) ? SystemColors.HotTrack : Color.DarkRed;
            //lbLeftSteerRW.ForeColor = (maxLeftSteer == 0 && leftSteerRW > minLeftSteer) || (maxLeftSteer > 0 && leftSteerRW >= minLeftSteer && leftSteerRW <= maxLeftSteer) ? SystemColors.HotTrack : Color.DarkRed;
            //lbRightSteerLW.ForeColor = (maxRightSteer == 0 && rightSteerLW > minRightSteer) || (maxRightSteer > 0 && rightSteerLW >= minRightSteer && rightSteerLW <= maxRightSteer) ? SystemColors.HotTrack : Color.DarkRed;
            lbRightSteerRW.ForeColor = (maxRightSteer == 0 && rightSteerRW > minRightSteer) || (maxRightSteer > 0 && rightSteerRW >= minRightSteer && rightSteerRW <= maxRightSteer) ? SystemColors.HotTrack : Color.DarkRed;
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
            lbVinNumber.Text = serialNumber;
            DataRow vehicleDetails = sqlHelper.GetVehicleDetails(serialNumber);
            if (vehicleDetails != null)
            {
                string vehicleType = vehicleDetails["VehicleType"].ToString();
                DataTable vehicleStandards = sqlHelper.GetVehicleStandardsByTypeCar(vehicleType);
                if (vehicleStandards.Rows.Count > 0)
                {
                    DataRow standard = vehicleStandards.Rows[0];
                    minLeftSteer = ConvertToDecimal(standard["MinLeftSteer"]);
                    minRightSteer = ConvertToDecimal(standard["MinRightSteer"]);
                    maxLeftSteer = ConvertToDecimal(standard["MaxLeftSteer"]);
                    maxRightSteer = ConvertToDecimal(standard["MaxRightSteer"]);
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
            if (sensorCancellationTokenSource != null)
            {
                sensorCancellationTokenSource.Cancel();
                sensorCancellationTokenSource.Dispose();
                sensorCancellationTokenSource = null;
            }
        }
        private void frmSteerAngle_Load(object sender, EventArgs e)
        {
            LoadVehicleStandards(this.serialNumber);
            StartOPCListener();
            StartSensorMonitoring();
        }
    }
}
