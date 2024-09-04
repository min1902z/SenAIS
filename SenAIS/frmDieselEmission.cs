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
            byte[] command = new byte[] { 0xA5, 0x00 };
            command[1] = CalculateCheckCode(new byte[] { 0xA5 });
            comConnect.SendRequest(command);
            InitializeTimer();
        }
        private byte CalculateCheckCode(byte[] data)
        {
            int sum = 0;
            foreach (byte b in data)
            {
                sum += b;
            }
            return (byte)((~(sum & 0xFF)) + 1);
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000; // Kiểm tra mỗi giây
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();

        }
        private void UpdateReadyStatus(object sender, EventArgs e)
        {
            //int checkStatus = OPCUtility.GetOPCValue("Hyundai.OCS10.Test1");
            int checkStatus = 1;

            if (checkStatus == 1)
            {
                cbReady.BackColor = Color.Green;
                //await Task.Delay(10000); // Chờ 10 giây

                // Sau khi đợi 10 giây, gửi yêu cầu lấy dữ liệu
                //byte[] request = { 0xA5};
                //comConnect.SendRequest(request);
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
            if (lbMinSpeed1.Text != value)
            {
                lbMinSpeed1.Text = value;
            }
            this.minSpeed = Convert.ToDecimal(value);
        }
        public void SetMaxSpeed(string value)
        {
            if (lbMaxSpeed1.Text != value)
            {
                lbMaxSpeed1.Text = value;
            }
            this.maxSpeed = Convert.ToDecimal(value);
        }
        public void SetHSU(string value)
        {
            if (lbHSU1.Text != value)
            {
                lbHSU1.Text = value;
            }
            this.hsu = Convert.ToDecimal(value);
        }
        public void ProcessNHT6Data(byte[] data)
        {
            if (data.Length >= 9 && data[0] == 0xA5)
            {
                // Extract speed (assuming bytes 6-7) and oil temperature (assuming bytes 8-9)
                int speedValue = (data[5] << 8) + data[6];
                int oilTempValue = (data[7] << 8) + data[8] - 273; // Convert from absolute temperature to Celsius

                this.Invoke(new Action(() =>
                {
                    lbMinSpeed1.Text = speedValue.ToString();
                    lbMinSpeed2.Text = oilTempValue.ToString(); 
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
            //byte[] request = { 0xA5 };
            //comConnect.SendRequest(request);
        }

        private void frmDieselEmission_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
    }
}
