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
        private decimal minSpeed1;
        private decimal minSpeed2;
        private decimal minSpeed3;
        private decimal maxSpeed1;
        private decimal maxSpeed2;
        private decimal maxSpeed3;
        private decimal hsu1;
        private decimal hsu2;
        private decimal hsu3;
        private bool isRequestInProgress = false;  // To prevent sending multiple requests simultaneously
        private int currentDataRequest = 1;        // Keep track of the current request count

        public frmDieselEmission(Form parent, OPCItem opcCounterPos, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcCounterPos = opcCounterPos;
            this.serialNumber = serialNumber;
            comConnect = new COMConnect("COM7", 9600,  this);
            sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 2000; // Kiểm tra mỗi giây
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
                isReady = true;
                if (!isRequestInProgress && currentDataRequest <=3)
                {
                    if (currentDataRequest == 1)
                    {
                        await Task.Delay(2000); // Đợi 10 giây
                    }
                    lbNotice.Text = $"Vui Lòng Đạp Ga lần {currentDataRequest}!";
                    await Task.Delay(5000);
                    byte[] commandA5 = { 0xA5, CalculateCheckCode(0xA5) };
                    comConnect.SendRequest(commandA5);
                    isRequestInProgress = true;
                }
                else if (currentDataRequest>3)
                {
                    updateTimer.Stop();

                    lbMinAvg.Text = ((minSpeed1 + minSpeed2 + minSpeed3) / 3).ToString("F1");
                    lbMaxAvg.Text = ((maxSpeed1 + maxSpeed2 + maxSpeed3) / 3).ToString("F1");
                    lbHsuAvg.Text = ((hsu1 + hsu2 + hsu3) / 3).ToString("F1");
                    lbNotice.Text = "Đã hoàn thành 3 lần lấy dữ liệu!";

                }
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
        public void SetMinSpeed1(string value)
        {
            if (lbMinSpeed1.Text != value)
            {
                lbMinSpeed1.Text = value;
            }
            this.minSpeed1 = Convert.ToDecimal(value);
        }
        public void SetMinSpeed2(string value)
        {
            if (lbMinSpeed1.Text != value)
            {
                lbMinSpeed1.Text = value;
            }
            this.minSpeed1 = Convert.ToDecimal(value);
        }
        public void SetMaxSpeed1(string value)
        {
            if (lbMaxSpeed1.Text != value)
            {
                lbMaxSpeed1.Text = value;
            }
            this.maxSpeed2 = Convert.ToDecimal(value);
        }
        public void SetHSU(string value)
        {
            if (lbHSU1.Text != value)
            {
                lbHSU1.Text = value;
            }
            this.hsu1 = Convert.ToDecimal(value);
        }
        public async void ProcessNHT6MaxData(byte[] data)
        {
            if (data.Length >= 7 && data[0] == 0xA6)
            {
                    int maxRpm = (data[5] << 8) + data[6]; // Max Speed (revolving speed)
                    this.Invoke(new Action(async () =>
                    {
                         switch (currentDataRequest)
                        {
                            case 1:
                                lbMaxSpeed1.Text = maxRpm.ToString();
                                this.maxSpeed1 = Convert.ToDecimal(maxRpm);
                                break;
                            case 2:
                                lbMaxSpeed2.Text = maxRpm.ToString();
                                this.maxSpeed2 = Convert.ToDecimal(maxRpm);
                                break;
                            case 3:
                                lbMaxSpeed3.Text = maxRpm.ToString();
                                this.maxSpeed3 = Convert.ToDecimal(maxRpm);
                                break;
                        }
                    }));
                        currentDataRequest++;
                        isRequestInProgress = false;
                        await Task.Delay(5000);
            }
        }
        public void ProcessNHT6Data(byte[] data)
        {
            if (data.Length >= 9 && data[0] == 0xA5)
            {
                    // Xử lý dữ liệu MinSpeed và OilTemp
                    int rpm = (data[5] << 8) + data[6];
                    int oilTempRaw = (data[7] << 8) + data[8];
                    string oilTemperature;
                    int  oilTempCelsius = 0;
                    if (oilTempRaw == 0xFFFF)
                    {
                        oilTemperature = "--";  // Không có cảm biến nhiệt độ
                        oilTempCelsius = 0;
                    }
                    else
                    {
                        oilTempCelsius = oilTempRaw;
                        oilTemperature = oilTempCelsius.ToString();
                    }

                    this.Invoke(new Action(() =>
                    {
                        switch (currentDataRequest)
                        {
                            case 1:
                                lbMinSpeed1.Text = rpm.ToString("F0");
                                lbHSU1.Text = oilTemperature;
                                this.minSpeed1 = Convert.ToDecimal(rpm);
                                this.hsu1 = oilTempCelsius;
                                break;
                            case 2:
                                lbMinSpeed2.Text = rpm.ToString("F0");
                                lbHSU2.Text = oilTemperature;
                                this.minSpeed2 = Convert.ToDecimal(rpm);
                                this.hsu2 = oilTempCelsius;
                                break;
                            case 3:
                                lbMinSpeed3.Text = rpm.ToString("F0");
                                lbHSU3.Text = oilTemperature;
                                this.minSpeed3 = Convert.ToDecimal(rpm);
                                this.hsu3 = oilTempCelsius;
                                break;
                        }
                    }));
                    byte[] commandA6 = { 0xA6, CalculateCheckCode(0xA6) };
                    comConnect.SendRequest(commandA6);
                
                }
            }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveDieselEmissionData(this.serialNumber, minSpeed1, maxSpeed1, hsu1, minSpeed2, maxSpeed2, hsu2, minSpeed3, maxSpeed3, hsu3);
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
        private byte CalculateCheckCode(byte command)
        {
            int sum = command;
            return (byte)(~sum + 1);
        }
        private void frmDieselEmission_FormClosing(object sender, FormClosingEventArgs e)
        {
            comConnect.CloseConnection();
        }
    }
}
