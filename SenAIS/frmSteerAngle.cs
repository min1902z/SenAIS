using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSteerAngle : Form
    {
        private Timer updateTimer;
        private SQLHelper sqlHelper;
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
        private List<string> opcItems = new List<string>
        {
            opcSteerCounter,
            opcLeftSteer,
            opcRightSteer,
            opcLeftSteerLW,
            opcRightSteerLW,
            opcLeftSteerRW,
            opcRightSteerRW
        };
        private List<string> opcTurn = new List<string>
        {
            opcTurnLeft,
            opcTurnRight,
            opcPosTest
        };
        private Timer turnSignalTimer;
        private static readonly string opcSteerCounter = ConfigurationManager.AppSettings["Steering_Counter"];
        private static readonly string opcTurnLeft = ConfigurationManager.AppSettings["TurnLeft_Steer"];
        private static readonly string opcTurnRight = ConfigurationManager.AppSettings["TurnRight_Steer"];
        private static readonly string opcLeftSteer = ConfigurationManager.AppSettings["LeftSteer_Result"];
        private static readonly string opcRightSteer = ConfigurationManager.AppSettings["RightSteer_Result"];
        private static readonly string opcLeftSteerLW = ConfigurationManager.AppSettings["LeftSteerLW_Result"];
        private static readonly string opcRightSteerLW = ConfigurationManager.AppSettings["RightSteerLW_Result"];
        private static readonly string opcLeftSteerRW = ConfigurationManager.AppSettings["LeftSteerRW_Result"];
        private static readonly string opcRightSteerRW = ConfigurationManager.AppSettings["RightSteerRW_Result"];
        //private static readonly string opcPos1 = ConfigurationManager.AppSettings["GL_Pos1"];
        //private static readonly string opcPos2 = ConfigurationManager.AppSettings["GL_Pos2"];
        private static readonly string opcPosTest = ConfigurationManager.AppSettings["GL_PosTest"];
        public frmSteerAngle(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
            InitializePollingTimer();
            InitializeSenSignalTimer();
        }
        private void InitializeSenSignalTimer()
        {
            turnSignalTimer = new Timer();
            turnSignalTimer.Interval = 200;
            turnSignalTimer.Tick += SenSignalTimer_Tick;
            turnSignalTimer.Start();
        }
        private void SenSignalTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                var values = OPCUtility.GetMultipleOPCValues(opcTurn);

                // Xử lý các giá trị OPC
                if (values.TryGetValue(opcTurnLeft, out var turnLeft))
                {
                    pbLeft.Visible = turnLeft == 1; // Hiển thị nếu turnLeft = 1, ẩn nếu = 0
                }

                if (values.TryGetValue(opcTurnRight, out var turnRight))
                {
                    pbRight.Visible = turnRight == 1; // Hiển thị nếu turnRight = 1, ẩn nếu = 0
                }

                if (values.TryGetValue(opcPosTest, out var posTest))
                {
                    cbPosTest.BackColor = posTest == 1 ? Color.Green : SystemColors.Control;
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
                        tbSteerAngle.Visible = true;
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
                        tbSteerAngle.Visible = true;
                        lbSteerTitle.Visible = true;
                        this.Close();
                        //if (!hasProcessedNextVin)
                        //{
                        //    string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                        //    if (!string.IsNullOrEmpty(nextSerialNumber))
                        //    {
                        //        this.serialNumber = nextSerialNumber;
                        //        var frmMain = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
                        //        if (frmMain != null)
                        //        {
                        //            var txtVinNumber = frmMain.Controls.Find("txtVinNum", true).FirstOrDefault() as TextBox;
                        //            if (txtVinNumber != null)
                        //            {
                        //                txtVinNumber.Text = this.serialNumber; // Cập nhật số VIN
                        //            }
                        //        }
                        //        hasProcessedNextVin = true; // Đánh dấu đã xử lý
                        //        this.Close();
                        //    }
                        //    else
                        //    {
                        //        this.Close();
                        //    }
                        //}
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
            {
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

            this.leftSteer = Convert.ToDecimal(lbLeft.Text);
            this.rightSteer = Convert.ToDecimal(lbRight.Text);
            this.leftSteerLW = Convert.ToDecimal(lbLeftSteerLW.Text);
            this.rightSteerLW = Convert.ToDecimal(lbRightSteerLW.Text);
            this.leftSteerRW = Convert.ToDecimal(lbLeftSteerRW.Text);
            this.rightSteerRW = Convert.ToDecimal(lbRightSteerRW.Text);

            // So sánh với tiêu chuẩn
            lbLeftSteerLW.ForeColor = this.leftSteerLW >= minLeftSteer ? SystemColors.HotTrack : Color.DarkRed;
            lbLeftSteerRW.ForeColor = this.leftSteerRW >= minLeftSteer ? SystemColors.HotTrack : Color.DarkRed;
            lbRightSteerLW.ForeColor = this.rightSteerLW >= minRightSteer ? SystemColors.HotTrack : Color.DarkRed;
            lbRightSteerRW.ForeColor = this.rightSteerRW >= minRightSteer ? SystemColors.HotTrack : Color.DarkRed;
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
                else
                {
                    MessageBox.Show("Không có xe trước đó.");
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
                else
                {
                    MessageBox.Show("Không có xe tiếp theo.");
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
            if (updateTimer != null)
            {
                updateTimer.Stop(); // Dừng Timer
                updateTimer.Dispose(); // Giải phóng tài nguyên
                updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            }
            if (turnSignalTimer != null)
            {
                turnSignalTimer.Stop(); // Dừng Timer
                turnSignalTimer.Dispose(); // Giải phóng tài nguyên
                turnSignalTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            }
            e.Cancel = false;
        }
    }
}
