using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SenAIS
{
    public partial class frmDieselEmission : Form
    {
        private Form parentForm;
        private OPCItem opcCounterPos;
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private COMConnect comConnect;
        private bool isReady = false;
        private string serialNumber;
        private decimal minSpeed;
        private decimal maxSpeed;
        private decimal hsu;
        private byte[] lastReceivedData;

        public frmDieselEmission(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
            comConnect = new COMConnect("COM7", this);
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
        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                opcCounterPos.Write(11); // Giá trị cho form chờ hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(11);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                opcCounterPos.Write(13); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                if (isReady)
                {
                    CheckCounterPosition(); // Lưu dữ liệu nếu đèn đã sáng 10 giây
                }
                ((frmInspection)parentForm).ProcessMeasurement(13);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
            }
        }
        public void SetMinSpeed(string value)
        {
            if (lbMinSpeed.Text != value)
            {
                lbMinSpeed.Text = value;
            }
            this.minSpeed = Convert.ToDecimal(value);
        }
        public void SetMaxSpeed(string value)
        {
            if (lbMaxSpeed.Text != value)
            {
                lbMaxSpeed.Text = value;
            }
            this.maxSpeed = Convert.ToDecimal(value);
        }
        public void SetHSU(string value)
        {
            if (lbHSU.Text != value)
            {
                lbHSU.Text = value;
            }
            this.hsu = Convert.ToDecimal(value);
        }
        public void ProcessNHT6Data(byte[] data)
        {
            if (data.Length == 21 && data[0] == 0xA5) // Kiểm tra mã lệnh A5H và độ dài dữ liệu
            {
                // Lưu lại dữ liệu cuối cùng
                lastReceivedData = data;

                // Xử lý từng giá trị từ gói dữ liệu NHT6
                double opacity = ConvertToDouble(data[1], data[2], 10); // Độ mờ chia 10
                double lightAbsorption = ConvertToDouble(data[3], data[4], 100); // Hệ số hấp thụ ánh sáng chia 100
                int rpm = ConvertToInt(data[5], data[6]); // Vòng quay không chia scale
                int oilTemp = ConvertToInt(data[7], data[8]) - 273; // Nhiệt độ dầu (đã chuyển đổi sang độ C)

                this.Invoke(new Action(() =>
                {
                    // Cập nhật giá trị lên UI
                    //SetOpacityValue(opacity.ToString("F1"));
                    //SetLightAbsorptionValue(lightAbsorption.ToString("F2"));
                    //SetRPMValue(rpm.ToString());
                    //SetOilTempValue(oilTemp.ToString());
                }));
            }
            else if (data.Length == 0)
            {
                // Dữ liệu rỗng, sử dụng dữ liệu cuối cùng được lưu lại
                this.Invoke(new Action(() =>
                {
                    if (lastReceivedData != null)
                    {
                        ProcessNHT6Data(lastReceivedData); // Gọi lại hàm với dữ liệu cuối cùng
                    }
                }));
            }
        }
        private double ConvertToDouble(byte highByte, byte lowByte, double scale)
        {
            int value = (highByte << 8) | lowByte;
            return value / scale;
        }

        private int ConvertToInt(byte highByte, byte lowByte)
        {
            return (highByte << 8) | lowByte;
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveDieselEmissionData(this.serialNumber, minSpeed, maxSpeed, hsu);
        }
        private void CheckCounterPosition()
        {
            int currentPosition = (int)OPCUtility.GetOPCValue("Hyundai.OCS10.T99");

            if (currentPosition != 11)
            {
                SaveDataToDatabase();
            }
        }

        private void frmDieselEmission_Load(object sender, EventArgs e)
        {
            comConnect.OpenConnection();
        }

        private void frmDieselEmission_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
    }
}
