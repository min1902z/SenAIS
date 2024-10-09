using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmGasEmission : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private COMConnect comConnect;
        private bool isReady = false;
        private decimal hcValue;
        private decimal coValue;
        private decimal co2Value;
        private decimal o2Value;
        private decimal noValue;
        private decimal oilTemp;
        private decimal rpm;
        private string serialNumber;
        private byte[] lastReceivedData;
        public frmGasEmission(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
            comConnect = new COMConnect("COM7", 9600, this);
            sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000; // Kiểm tra mỗi giây
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();

        }
        private async void UpdateReadyStatus(object sender, EventArgs e)
        {
            //int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");
            int checkStatus = 1;

            if (checkStatus == 1)
            {
                cbReady.BackColor = Color.Green;
                await Task.Delay(10000); // Chờ 10 giây

                // Sau khi đợi 10 giây, gửi yêu cầu lấy dữ liệu
                byte[] request = { 0x03 };
                comConnect.SendRequest(request);
                isReady = true;
                //CheckCounterPosition();
            }
            else
            {
                cbReady.BackColor = SystemColors.Control;
                isReady = false;
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
            if (data.Length == 21 && data[0] == 0x06)
            {
                // Lưu lại dữ liệu cuối cùng
                lastReceivedData = data;

                // Xử lý từng giá trị từ gói dữ liệu
                double? hcValue = ConvertToDouble(data[1], data[2], 1); // Không chia scale
                double? coValue = ConvertToDouble(data[3], data[4], 100);
                double? co2Value = ConvertToDouble(data[5], data[6], 100);
                double? o2Value = ConvertToDouble(data[7], data[8], 100);
                double? noValue = ConvertToDouble(data[9], data[10], 100);
                double? otValue = ConvertToDouble(data[11], data[12], 1); // Không chia scale
                double? rpmValue = ConvertToDouble(data[13], data[14], 1); // Không chia scale

                this.Invoke(new Action(() =>
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
                        SetNOValue(noValue.Value.ToString("F2"));
                    if (otValue != null)
                        SetOilTempValue(otValue.ToString());
                    if (rpmValue != null)
                        SetRPMValue(rpmValue.ToString());
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
            // Thay đổi giá trị CounterPosition và mở form trước
            try
            {
                opcCounterPos.Write(10); // Giá trị cho form chờ hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị CounterPosition: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị CounterPosition và mở form tiếp theo
            try
            {
                opcCounterPos.Write(12); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(12);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị CounterPosition: " + ex.Message);
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

        private void frmGasEmission_Load(object sender, EventArgs e)
        {
            //comConnect = new COMConnect("COM7", this);
            comConnect.OpenConnection();
        }

        private void frmGasEmission_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveGasEmissionData(this.serialNumber, hcValue, coValue, co2Value, o2Value, noValue, oilTemp, rpm);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition != 11)
            {
                SaveDataToDatabase();
            }
        }
    }

}
