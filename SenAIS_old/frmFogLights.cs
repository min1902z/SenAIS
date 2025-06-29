﻿using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmFogLights : Form
    {
        private COMConnect comConnect;
        private SQLHelper sqlHelper;
        private CancellationTokenSource measurementTokenSource;
        private string serialNumber;
        private bool autoTestCheck = false;
        private bool isDataCollected = false;
        private decimal rightFLIntensity, rightFLVerticalValue, rightFLHorizontalValue, rightFLHeight;
        private decimal leftFLIntensity, leftFLVerticalValue, leftFLHorizontalValue, leftFLHeight;
        private decimal minFLIntensity, maxFLIntensity, minDiffHoriFL, maxDiffHoriFL, minDiffVertiFL, maxDiffVertiFL, minFLHeight, maxFLHeight;

        public frmFogLights(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            comConnect = new COMConnect(ConfigurationManager.AppSettings["COM_Headlights"], 2400, this);
            sqlHelper = new SQLHelper();
        }

        private void frmFogLights_Shown(object sender, EventArgs e)
        {
            //StartMeasurementProcess();
        }

        public void StartMeasurementProcess()
        {
            // Nếu đang đo, bỏ qua
            if (measurementTokenSource != null && !measurementTokenSource.IsCancellationRequested)
                return;

            measurementTokenSource = new CancellationTokenSource();
            var token = measurementTokenSource.Token;

            Task.Run(async () =>
            {
                try
                {
                    // 🟡 Hiển thị chuẩn bị đo
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
<<<<<<< HEAD:SenAIS/frmFogLights.cs
                        this.BeginInvoke((Action)(() =>
                        {
                            lbTitle.Text = "Đèn Sương Mù";
                            lbTitle.Visible = true;
                            tbHeadLights.Visible = false;
                        }));
                    }

                    await Task.Delay(5000, token); // Quãng nghỉ 5s trước khi bắt đầu

                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            lbTitle.Visible = false;
                            tbHeadLights.Visible = true;
                        }));
                    }

                    // Gửi lệnh Auto Test nếu chưa gửi
                    if (!autoTestCheck)
                    {
                        byte[] autoTest = { 0x41 };
                        comConnect.SendRequest(autoTest);
                        autoTestCheck = true;
                    }
                    bool hasCollected = false;
                    // Giới hạn 4 phút
                    int timeoutMinutes = 4; // mặc định 4 phút
                    try
                    {
                        string configValue = ConfigurationManager.AppSettings["FogLightTimeoutMinutes"];
                        if (!string.IsNullOrWhiteSpace(configValue) && int.TryParse(configValue, out int parsed))
                        {
                            timeoutMinutes = parsed;
                        }
                    }
                    catch { }
                    var timeoutCts = new CancellationTokenSource(TimeSpan.FromMinutes(timeoutMinutes));
                    using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(token, timeoutCts.Token))
                    {
                        while (!isDataCollected && !linkedCts.Token.IsCancellationRequested)
                        {
                            await Task.Delay(1000, linkedCts.Token);
                        }
                        hasCollected = isDataCollected;
                        if (hasCollected)
                        {
                            if (this.IsHandleCreated && !this.IsDisposed)
                            {
                                this.BeginInvoke((Action)(() => SaveDataToDatabase()));
                            }
                            await Task.Delay(5000, token); // Nghỉ 5s sau khi lưu
                            if (this.IsHandleCreated && !this.IsDisposed)
                            {
                                this.BeginInvoke((Action)(() => MoveToNextCar()));
                            }
                        }
                        else
                        {
                            if (this.IsHandleCreated && !this.IsDisposed)
                            {
                                this.BeginInvoke((Action)(() => this.Close()));
                            }
                        }
=======
                        await Task.Delay(1000, cts.Token);
>>>>>>> SenAIS_HD:SenAIS_old/frmFogLights.cs
                    }

                }
                catch (TaskCanceledException)
                {
                    // Bị huỷ đo thủ công hoặc hết thời gian
                }
                catch (Exception)
                {
                }
            }, token);
        }
        private void MoveToNextCar()
        {
            cbReady.BackColor = SystemColors.Control;
            Form currentForm = this;

            this.BeginInvoke(new Action(() =>
            {
                if (Application.OpenForms.OfType<frmWhistle>().Any())
                    return;

                var form = new frmWhistle(this.serialNumber);
                form.Show();

                currentForm.Close();
            }));
        }
        public void ProcessNHD6109Data(byte[] data)
        {
            if (data[0] == 0x01)
            {
                // Xử lý 34 byte của đèn phải (Right Headlight)
                string rightFLHorizontalDeviation = Encoding.ASCII.GetString(data, 2, 5);    // Lệch ngang Right HB (5 bytes)
                string rightFLVerticalDeviation = Encoding.ASCII.GetString(data, 7, 5);      // Lệch dọc Right HB (5 bytes)
                string rightFLLightIntensity = Encoding.ASCII.GetString(data, 12, 4);        // Cường độ Right HB (4 bytes)
                string rightFLLightHeight = Encoding.ASCII.GetString(data, 34, 4);

                string leftFLHorizontalDeviation = Encoding.ASCII.GetString(data, 45, 5);    // Lệch ngang Left HB (5 bytes)
                string leftFLVerticalDeviation = Encoding.ASCII.GetString(data, 50, 5);      // Lệch dọc Left HB (5 bytes)
                string leftFLLightIntensity = Encoding.ASCII.GetString(data, 55, 4);         // Cường độ Left HB (4 bytes)
                string leftFLLightHeight = Encoding.ASCII.GetString(data, 77, 4);

                // Chuyển đổi chuỗi ASCII thành số thực
                this.rightFLHorizontalValue = ConvertToPercentage(rightFLHorizontalDeviation);
                this.rightFLVerticalValue = ConvertToPercentage(rightFLVerticalDeviation);
                this.rightFLIntensity = ConvertToCd(rightFLLightIntensity);
                this.rightFLHeight = ConvertToMM(rightFLLightHeight);

                this.leftFLHorizontalValue = ConvertToPercentage(leftFLHorizontalDeviation);
                this.leftFLVerticalValue = ConvertToPercentage(leftFLVerticalDeviation);
                this.leftFLIntensity = ConvertToCd(leftFLLightIntensity);
                this.leftFLHeight = ConvertToMM(leftFLLightHeight);

                this.Invoke(new Action(() =>
                {
                    lbRFLIntensity.Text = rightFLIntensity.ToString();
                    lbRFLVerticalDeviation.Text = rightFLVerticalValue.ToString();
                    lbRFLHorizontalDeviation.Text = rightFLHorizontalValue.ToString();
                    lbRFLHeight.Text = rightFLHeight.ToString();

                    lbLFLIntensity.Text = leftFLIntensity.ToString();
                    lbLFLVerticalDeviation.Text = leftFLVerticalValue.ToString();
                    lbLFLHorizontalDeviation.Text = leftFLHorizontalValue.ToString();
                    lbLFLHeight.Text = leftFLHeight.ToString();

                    // Kiểm tra và đổi màu cho Right High Beam
                    lbRFLIntensity.ForeColor = (rightFLIntensity >= minFLIntensity && rightFLIntensity <= maxFLIntensity) ? SystemColors.HotTrack : Color.DarkRed;
                    lbRFLVerticalDeviation.ForeColor = (rightFLVerticalValue >= minDiffVertiFL && rightFLVerticalValue <= maxDiffVertiFL) ? SystemColors.HotTrack : Color.DarkRed;
                    lbRFLHorizontalDeviation.ForeColor = (rightFLHorizontalValue >= minDiffHoriFL && rightFLHorizontalValue <= maxDiffHoriFL) ? SystemColors.HotTrack : Color.DarkRed;

                    // Kiểm tra và đổi màu cho Left High Beam
                    lbLFLIntensity.ForeColor = (leftFLIntensity >= minFLIntensity && leftFLIntensity <= maxFLIntensity) ? SystemColors.HotTrack : Color.DarkRed;
                    lbLFLVerticalDeviation.ForeColor = (leftFLVerticalValue >= minDiffVertiFL && leftFLVerticalValue <= maxDiffVertiFL) ? SystemColors.HotTrack : Color.DarkRed;
                    lbLFLHorizontalDeviation.ForeColor = (leftFLHorizontalValue >= minDiffHoriFL && leftFLHorizontalValue <= maxDiffHoriFL) ? SystemColors.HotTrack : Color.DarkRed;

                    isDataCollected = true;
                }));
            }
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

                    // Gán các giá trị tiêu chuẩn
                    minFLIntensity = ConvertToDecimal(standard["MinFLIntensity"]);
                    maxFLIntensity = ConvertToDecimal(standard["MaxFLIntensity"]);
                    minDiffHoriFL = ConvertToDecimal(standard["MinDiffHoriFL"]);
                    maxDiffHoriFL = ConvertToDecimal(standard["MaxDiffHoriFL"]);
                    minDiffVertiFL = ConvertToDecimal(standard["MinDiffVertiFL"]);
                    maxDiffVertiFL = ConvertToDecimal(standard["MaxDiffVertiFL"]);
                    minFLHeight = ConvertToDecimal(standard["MinFLHeight"]);
                    maxFLHeight = ConvertToDecimal(standard["MaxFLHeight"]);
                }
            }
        }
        private decimal ConvertToCd(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result / 10; // Đơn vị gửi về là x100cd, chia 100 để ra cd
            }
            return 0;
        }
        private decimal ConvertToPercentage(string value)
        {
            if (value.StartsWith("+"))
            {
                value = value.Substring(1); // Loại bỏ dấu '+'
            }
            if (decimal.TryParse(value, out decimal result))
            {
                return result / 10; // Quy đổi từ cm/10m sang %
            }
            return 0;
        }
        private decimal ConvertToMM(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result; // đưa cm về mm
            }
            return 0;
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveFogLightsData(serialNumber, rightFLIntensity, rightFLVerticalValue, rightFLHorizontalValue, rightFLHeight,
                                        leftFLIntensity, leftFLVerticalValue, leftFLHorizontalValue, leftFLHeight);
        }
        private void frmFogLights_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (measurementTokenSource != null)
            {
                measurementTokenSource.Cancel();
                measurementTokenSource.Dispose();
                measurementTokenSource = null;
            }
            comConnect.CloseConnection();
        }

        private void frmFogLights_Load(object sender, EventArgs e)
        {
            comConnect.OpenConnection();
            LoadVehicleStandards(serialNumber);
            if (comConnect.IsConnected())
            {
                cbReady.BackColor = Color.Green; // Đèn xanh nếu kết nối thành công
                StartMeasurementProcess();
            }
            else
            {
                cbReady.BackColor = SystemColors.Control; // Màu mặc định nếu không kết nối
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDataCollected)
                {
                    SaveDataToDatabase();
                }

                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isDataCollected = false; // Đặt lại trạng thái
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

        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu dữ liệu hiện tại
                if (isDataCollected)
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
                    isDataCollected = false; // Đặt lại trạng thái
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

    }
}
