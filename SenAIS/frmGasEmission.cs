using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmGasEmission : Form
    {
        private SQLHelper sqlHelper;
        private COMConnect comConnect;
        private decimal hcValue;
        private decimal coValue;
        private decimal co2Value;
        private decimal o2Value;
        private decimal noValue;
        private decimal oilTemp;
        private decimal rpm;
        private decimal lamda;
        private decimal maxHC;
        private decimal maxCO;
        private decimal minLamda;
        private string serialNumber;
        private byte[] lastReceivedData;
        private bool hasMeasured = false; // Đánh dấu quá trình đo đã hoàn tất
        private bool isManualStop = false;
        private bool isManualMode;
        private CancellationTokenSource cts; // Quản lý hủy bỏ task

        public frmGasEmission(string serialNumber, bool isManualMode)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            this.isManualMode = isManualMode;
            comConnect = new COMConnect(ConfigurationManager.AppSettings["COM_PetrolEmission"], 9600, this);
            sqlHelper = new SQLHelper();
            LoadVehicleStandards(serialNumber);
        }
        private async Task StartEmissionProcess(CancellationToken cancellationToken)
        {
            try
            {
                // Trạng thái 1: Hiển thị tiêu đề và chờ 2 giây
                UpdateTitle("Khí Xả - Động Cơ Xăng");
                await Task.Delay(3000, cancellationToken);

                // Trạng thái 3: Hiển thị thông báo bắt đầu đo, gửi request đo
                UpdateTitle("Ấn KMeas để bắt đầu");
                await Task.Delay(5000, cancellationToken);
                lbEmissionTitle.Visible = false;
                tbGasEmission.Visible = true; // Hiển thị bảng đo
                tbEmission2.Visible = true;
                byte[] request = { 0x03 }; // Lệnh gửi đo
                comConnect.SendRequest(request);

                // Dừng cập nhật và lưu kết quả
                await Task.Delay(10000, cancellationToken);
                if (hasMeasured == true)
                {
                    SaveDataToDatabase(); // Lưu DB
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Quá trình đo đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình đo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetToDefault()
        {
            tbGasEmission.Visible = false;
            tbEmission2.Visible = false;
            lbHCValue.Text = "0.0";
            lbCOValue.Text = "0.0";
            lbCO2Value.Text = "0.0";
            lbO2Value.Text = "0.0";
            lbNOValue.Text = "0.0";
            lbOTValue.Text = "0.0";
            lbRPMValue.Text = "0.0";
            hasMeasured = false; // Đặt lại cờ đã đo
        }
        private void UpdateTitle(string title)
        {
            lbEmissionTitle.Text = title;
            lbEmissionTitle.Visible = true;
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
                    maxHC = ConvertToDecimal(standard["MaxHC"]);
                    maxCO = ConvertToDecimal(standard["MaxCO"]);
                    minLamda = ConvertToDecimal(standard["MinLamda"]);
                }
            }
        }
        private double? ConvertToDouble(byte highByte, byte lowByte, double scale)
        {
            // Kết hợp hai byte để tạo ra một số nguyên
            int value = (highByte << 8) | lowByte;

            // Kiểm tra nếu số là âm (nếu high byte là 0xFF)
            if (highByte == 0xFF)
            {
                // Nếu là số âm, tính lại giá trị
                value = value - 0x10000;
            }
            // Kiểm tra nếu giá trị là -256 (giá trị lỗi)
            if (value == -256)
            {
                return null; // Trả về null nếu gặp giá trị lỗi
            }

            // Chia giá trị theo scale (ví dụ 100) để ra giá trị thực tế
            return value / scale;
        }
        public void ProcessNHA506Data(byte[] data)
        {
            if (data[0] == 0x06)
            {
                // Lưu lại dữ liệu cuối cùng
                lastReceivedData = data;

                // Xử lý từng giá trị từ gói dữ liệu
                double? hcValue = ConvertToDouble(data[1], data[2], 1); // Không chia scale
                double? coValue = ConvertToDouble(data[3], data[4], 100);
                double? co2Value = ConvertToDouble(data[5], data[6], 100);
                double? o2Value = ConvertToDouble(data[7], data[8], 100);
                double? noValue = ConvertToDouble(data[9], data[10], 100);
                double? otValue = ConvertToDouble(data[13], data[14], 1); // Không chia scale
                double? rpmValue = ConvertToDouble(data[11], data[12], 1); // Không chia scale
                double? lamdaValue = ConvertToDouble(data[15], data[16], 100);

                this.Invoke(new Action(async () =>
                {
                    // Cập nhật giá trị mới chỉ khi giá trị không phải là null (không phải giá trị lỗi)
                    if (hcValue != null)
                        SetHCValue(hcValue.ToString());
                    if (coValue != null)
                        SetCOValue(coValue.Value.ToString("F2"));
                    if (co2Value != null)
                        SetCO2Value(co2Value.Value.ToString("F2"));
                    if (o2Value != null)
                        SetO2Value(o2Value.Value.ToString("F2"));
                    if (noValue != null)
                        SetNOValue(noValue.Value.ToString("F1"));
                    if (otValue != null)
                        SetOilTempValue(otValue.ToString());
                    if (rpmValue != null)
                        SetRPMValue(rpmValue.ToString());
                    if (lamdaValue != null)
                        SetLamdaValue(lamdaValue.Value.ToString("F3"));
                    // Kiểm tra tiêu chuẩn và đổi màu
                    bool isHCInStandard = maxHC == 0 || this.hcValue <= maxHC;
                    bool isCOInStandard = maxCO == 0 || this.coValue <= maxCO;
                    bool isLamdaInStandard = minLamda == 0 || this.lamda >= minLamda;

                    lbHCValue.ForeColor = isHCInStandard ? SystemColors.HotTrack : Color.DarkRed;
                    lbCOValue.ForeColor = isCOInStandard ? SystemColors.HotTrack : Color.DarkRed;
                    lbLamdaValue.ForeColor = isLamdaInStandard ? SystemColors.HotTrack : Color.DarkRed;

                    if (!isManualMode) // Nếu đo tự động
                    {
                        if (isHCInStandard && isCOInStandard && isLamdaInStandard)
                        {
                            await Task.Delay(2000);
                            hasMeasured = true; // Đạt tiêu chuẩn, gán cờ hoàn tất đo
                            pbCorrect.BackColor = Color.Green;
                        }
                        else
                        {
                            // Gửi lại lệnh đo nếu chưa đạt tiêu chuẩn
                            pbCorrect.BackColor = Color.Red;
                            if (!isManualStop) // Chỉ gửi lệnh đo tiếp nếu chưa bấm dừng
                            {
                                byte[] measureCommand = { 0x03 };
                                comConnect.SendRequest(measureCommand);
                            }
                        }
                    }
                    else
                    {
                        if (!isManualStop) // Chỉ gửi lệnh đo tiếp nếu chưa bấm dừng
                        {
                            byte[] measureCommand = { 0x03 };
                            comConnect.SendRequest(measureCommand);
                        }
                    }
                }));
            }
            else if (data.Length == 0)
            {
                // Dữ liệu rỗng, sử dụng dữ liệu cuối cùng được lưu lại
                this.Invoke(new Action(() =>
                {
                    if (lastReceivedData != null)
                    {
                        ProcessNHA506Data(lastReceivedData); // Gọi lại hàm với dữ liệu cuối cùng
                    }
                }));
            }
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy SerialNumber trước đó
                string previousSerialNumber = sqlHelper.GetPreviousSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(previousSerialNumber))
                {
                    // Cập nhật serialNumber mới
                    this.serialNumber = previousSerialNumber;
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    hasMeasured = false; // Đặt lại trạng thái
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
                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    hasMeasured = false; // Đặt lại trạng thái
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
        public void SetHCValue(string value)
        {
            if (lbHCValue.Text != value)
            {
                lbHCValue.Text = value;
            }
            this.hcValue = Convert.ToDecimal(value);
        }
        public void SetCOValue(string value)
        {
            if (lbCOValue.Text != value)
            {
                lbCOValue.Text = value;
            }
            this.coValue = Convert.ToDecimal(value);
        }
        public void SetCO2Value(string value)
        {
            if (lbCO2Value.Text != value)
            {
                lbCO2Value.Text = value;
            }
            this.co2Value = Convert.ToDecimal(value);
        }
        public void SetO2Value(string value)
        {
            if (lbCO2Value.Text != value)
            {
                lbO2Value.Text = value;
            }
            this.o2Value = Convert.ToDecimal(value);
        }
        public void SetNOValue(string value)
        {
            if (lbNOValue.Text != value)
            {
                lbNOValue.Text = value;
            }
            this.noValue = Convert.ToDecimal(value);
        }
        public void SetOilTempValue(string value)
        {
            if (lbOTValue.Text != value)
            {
                lbOTValue.Text = value;
            }
            this.oilTemp = Convert.ToDecimal(value);
        }
        public void SetRPMValue(string value)
        {
            if (lbRPMValue.Text != value)
            {
                lbRPMValue.Text = value;
            }
            this.rpm = Convert.ToDecimal(value);
        }
        public void SetLamdaValue(string value)
        {
            if (lbLamdaValue.Text != value)
            {
                lbLamdaValue.Text = value;
            }
            this.lamda = Convert.ToDecimal(value);
        }

        private void frmGasEmission_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveGasEmissionData(this.serialNumber, hcValue, coValue, co2Value, o2Value, noValue, oilTemp, rpm, lamda);
        }

        private async void frmGasEmission_Load(object sender, EventArgs e)
        {
            lbVinNumber.Text = this.serialNumber;
            comConnect.OpenConnection();
            if (comConnect.IsConnected())
            {
                cbReady.BackColor = Color.Green; // Đèn xanh nếu kết nối thành công
                cts = new CancellationTokenSource();
                await StartEmissionProcess(cts.Token); // Bắt đầu quá trình đo
            }
            else
            {
                cbReady.BackColor = SystemColors.Control; // Màu mặc định nếu không kết nối
            }
        }

        private async void btnReMeasure_Click(object sender, EventArgs e)
        {
            ResetToDefault();
            cts = new CancellationTokenSource();
            await StartEmissionProcess(cts.Token); // Bắt đầu quá trình đo
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);

            var frmMain = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
            if (frmMain != null)
            {
                var txtVinNumber = frmMain.Controls.Find("txtVinNum", true).FirstOrDefault() as TextBox;

                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber;
                    lbVinNumber.Text = this.serialNumber;
                    if (txtVinNumber != null)
                    {
                        txtVinNumber.Text = this.serialNumber;
                        frmMain.UpdateVehicleInfo(this.serialNumber);
                    }
                }
                else
                {
                    if (txtVinNumber != null)
                    {
                        txtVinNumber.Text = string.Empty;
                    }
                }
            }
            comConnect.CloseConnection();
            this.Close();
        }

        private void pbCorrect_Click(object sender, EventArgs e)
        {
            isManualStop = true;
            SaveDataToDatabase();
        }
    }

}
