using System;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmFrontWeight : Form
    {
        private Timer updateTimer;
        private SQLHelper sqlHelper;
        private OPCUtility opcManager;
        private string serialNumber;
        public decimal frontLeftWeight;
        public decimal frontRightWeight;
        private bool isReady = false;
        private double weightLeftA = 1.0;
        private double weightRightA = 1.0;
        private static readonly string opcWeightCounter = ConfigurationManager.AppSettings["Weight_Counter"];
        private static readonly string opcLWeightResult = ConfigurationManager.AppSettings["Front_LWeight_Result"];
        private static readonly string opcRWeightRResult = ConfigurationManager.AppSettings["Front_RWeight_Result"];

        public frmFrontWeight(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            opcManager = new OPCUtility();
            weightLeftA = sqlHelper.GetParaValue("LeftWeight", "ParaA");
            weightRightA = sqlHelper.GetParaValue("RightWeight", "ParaA");
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 500; // Kiểm tra mỗi giây
            updateTimer.Tick += new EventHandler(UpdateReadyStatus);
            updateTimer.Start();
        }
        private async void UpdateReadyStatus(object sender, EventArgs e)
        {
            try
            {
                lbVinNumber.Text = this.serialNumber;
                // Lấy giá trị OPC
                int checkStatus = await Task.Run(() => (int)opcManager.GetOPCValue(opcWeightCounter));
                Invoke((Action)(() =>
                {
                    switch (checkStatus)
                    {
                        case 0: // Mặc định
                            cbReady.BackColor = SystemColors.Control;
                            lbLeft_Weight.Text = "0.0";
                            lbRight_Weight.Text = "0.0";
                            lbSum_Weight.Text = "0.0";
                            tbFrontWeight.Visible = false;
                            lbWeightTitle.Visible = true;
                            isReady = false;
                            break;
                        case 1: // Xe vào vị trí
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            tbFrontWeight.Visible = false;
                            lbWeightTitle.Visible = true;
                            isReady = false; // Chưa sẵn sàng lưu
                            break;

                        case 2: // Bắt đầu đo
                            cbReady.BackColor = Color.Green; // Đèn xanh sáng
                            isReady = true; // Sẵn sàng lưu sau khi đo
                            lbWeightTitle.Visible = false;
                            tbFrontWeight.Visible = true;
                            double leftWeightResult = opcManager.GetOPCValue(opcLWeightResult);
                            double rightWeightResult = opcManager.GetOPCValue(opcRWeightRResult);
                            double leftWeight = leftWeightResult / weightLeftA;
                            double rightWeight = rightWeightResult / weightRightA;
                            double sumWeight = leftWeight + rightWeight;

                            lbLeft_Weight.Text = leftWeight.ToString("F1");
                            lbRight_Weight.Text = rightWeight.ToString("F1");
                            lbSum_Weight.Text = sumWeight.ToString("F1");

                            this.frontLeftWeight = Convert.ToDecimal(leftWeight.ToString("F1"));
                            this.frontRightWeight = Convert.ToDecimal(rightWeight.ToString("F1"));
                            break;

                        case 3: // Quá trình đo hoàn tất, lưu vào DB
                            cbReady.BackColor = Color.Green; // Đèn xanh
                            tbFrontWeight.Visible = true;
                            if (isReady)
                            {
                                SaveDataToDatabase(); // Ghi dữ liệu vào DB
                                isReady = false; // Đặt lại trạng thái
                            }
                            break;
                        case 4: // Xe tiếp theo
                            cbReady.BackColor = SystemColors.Control;
                            lbWeightTitle.Visible = false;
                            var formWeight = new frmRearWeight(this.serialNumber);
                            formWeight.Show();
                            this.Close();
                            break;

                        default: // Trạng thái không hợp lệ hoặc chưa sẵn sàng
                            cbReady.BackColor = SystemColors.Control; // Màu mặc định
                            isReady = false;
                            lbWeightTitle.Visible = false;
                            break;
                    }
                }));
            }
            catch
            {
            }
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu dữ liệu hiện tại
                if (isReady)
                {
                    SaveDataToDatabase();
                }
                // Lấy SerialNumber trước đó
                string previousSerialNumber = sqlHelper.GetPreviousSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(previousSerialNumber))
                {
                    // Cập nhật serialNumber mới
                    this.serialNumber = previousSerialNumber;
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
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
                    SaveDataToDatabase();
                }

                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbVinNumber.Text = this.serialNumber; // Hiển thị serial number mới
                    isReady = false; // Đặt lại trạng thái
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
            sqlHelper.SaveFrontWeightData(this.serialNumber, this.frontLeftWeight, this.frontRightWeight);
        }
        private void frmFrontWeight_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateTimer != null)
            {
                updateTimer.Stop(); // Dừng Timer
                updateTimer.Dispose(); // Giải phóng tài nguyên
                updateTimer = null; // Gán null để tránh tham chiếu ngoài ý muốn
            }
            e.Cancel = false;
        }
    }
}
