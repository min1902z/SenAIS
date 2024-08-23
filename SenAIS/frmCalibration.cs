using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPCAutomation;

namespace SenAIS
{
    public partial class frmCalibration : Form
    {
        private OPCServer opcServer;
        private OPCGroup opcGroup;
        private string opcItem;

        private double beforeCalib = 0.0;
        private double refPoint1;
        private double measurePoint1;
        private double refPoint2;
        private double measurePoint2;
        private double calibA = 1.0;
        private double calibB = 0.0;
        private double calibResult = 0.0;
        private string calibrationType;
        public frmCalibration(string calibrationType)
        {
            InitializeComponent();
            InitializeOPC();
            this.calibrationType = calibrationType;
            txtBeforeCalib.TextChanged += new EventHandler(txtBeforeCalib_TextChanged);
        }

        private void InitializeOPC()
        {
            try
            {
                // Kết nối tới OPC Server
                opcServer = new OPCServer();
                opcServer.Connect("Kepware.KEPServerEX.V4", "");

                // Tạo một nhóm OPC
                opcGroup = opcServer.OPCGroups.Add("OPCGroup1");
                opcGroup.IsActive = true;
                opcGroup.IsSubscribed = true;
                opcGroup.UpdateRate = 1000;

                // Đăng ký sự kiện DataChange
                opcGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(OnDataChange);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới OPC Server: " + ex.Message);
            }
        }

        public void SetOPCItem(string itemName)
        {
            try
            {
                // Thêm item mới vào group
                OPCItem opcItem = opcGroup.OPCItems.AddItem(itemName, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thiết lập OPC Item: " + ex.Message);
            }
        }

        private void OnDataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            // Lấy giá trị từ ItemValues
            double brakeValue = Convert.ToDouble(ItemValues.GetValue(1));

            // Gán giá trị cho txtBeforeCalib (invoke để đảm bảo an toàn thread)
            if (txtBeforeCalib.InvokeRequired)
            {
                txtBeforeCalib.Invoke(new MethodInvoker(delegate
                {
                    txtBeforeCalib.Text = brakeValue.ToString("F2");
                }));
            }
            else
            {
                txtBeforeCalib.Text = brakeValue.ToString("F2");
            }

        }
        private void btnAcpCalibrate1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtBeforeCalib.Text, out beforeCalib))
            {
                lbCalibrateIput1.Text = beforeCalib.ToString();
                measurePoint1 = beforeCalib;
            }
            else
            {
                MessageBox.Show("Giá trị 'Trước Kiểm Chuẩn' không hợp lệ.");
            }
        }

        private void btnAcpCalibrate2_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtBeforeCalib.Text, out beforeCalib))
            {
                lbCalibrateIput2.Text = beforeCalib.ToString();
                measurePoint2 = beforeCalib;
            }
            else
            {
                MessageBox.Show("Giá trị 'Trước Kiểm Chuẩn' không hợp lệ.");
            }
        }

        private void btnCalculateCalib_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtCalibrateInput1.Text, out refPoint1) && double.TryParse(txtCalibrateInput2.Text, out refPoint2))
            {
                if (refPoint1 != refPoint2)
                {
                    calibA = (measurePoint1 - measurePoint2) / (refPoint1 - refPoint2);
                    calibB = measurePoint1 / calibA - refPoint1;

                    lbCalibWeightLA.Text = calibA.ToString("F2");
                    lbCalibWeightLB.Text = calibB.ToString("F2");

                    calibResult = beforeCalib / calibA - calibB;
                    lbCalibResult.Text = $"{calibResult:F2}";
                    MessageBox.Show("Hệ số Kiểm Chuẩn đã được xác định.");
                }
                else
                {
                    MessageBox.Show("Điểm Đo Chuẩn 1 và Điểm Đo Chuẩn 2 không được trùng nhau.");
                }
            }
            else
            {
                MessageBox.Show("Giá trị của Điểm Đo Chuẩn 1 hoặc Điểm Đo Chuẩn 2 không hợp lệ.");
            }
        }
        private void txtBeforeCalib_TextChanged(object sender, EventArgs e)
        {
            double beforeCalib, calibWeightLA, calibWeightLB;

            // Kiểm tra nếu tất cả các giá trị cần thiết đều có thể chuyển đổi sang số
            if (double.TryParse(txtBeforeCalib.Text, out beforeCalib) &&
                double.TryParse(lbCalibWeightLA.Text, out calibWeightLA) &&
                double.TryParse(lbCalibWeightLB.Text, out calibWeightLB))
            {
                if (calibWeightLA != 0)
                {
                    // Tính toán và hiển thị kết quả
                    double calibResult = beforeCalib / calibWeightLA - calibWeightLB;
                    lbCalibResult.Text = $"{calibResult:F2}"; // Hiển thị giá trị số với 2 chữ số thập phân
                }
                else
                {
                    lbCalibResult.Text = "0.0";
                }
            }
            else
            {
                // Nếu không đủ giá trị, hiển thị 0.00
                lbCalibResult.Text = "0.0";
            }
        }
        private void btnSavePara_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại nhập mật khẩu trước khi lưu dữ liệu
                string password = Prompt.ShowDialog("Vui lòng nhập mật khẩu để lưu thông số:", "Xác nhận mật khẩu");

                // Kiểm tra mật khẩu đã nhập
                if (!string.IsNullOrEmpty(password))
                {
                    if (ValidatePassword(password))
                    {
                        // Nếu mật khẩu đúng, thực hiện lưu dữ liệu
                        decimal paraA = Convert.ToDecimal(calibA);
                        decimal paraB = Convert.ToDecimal(calibB);
                        string paraType = this.calibrationType;

                        // Sử dụng SQLHelper để thực hiện truy vấn
                        SQLHelper sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True;");
                        sqlHelper.UpdateCalibrationData(paraType, paraA, paraB);

                        // Cập nhật giá trị lên giao diện
                        lbParaWeightLA.Text = paraA.ToString("F1");
                        lbParaWeightLB.Text = paraB.ToString("F1");

                        MessageBox.Show("Lưu dữ liệu Kiểm Chuẩn Thành Công!");
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lưu dữ liệu đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu dữ liệu xảy ra lỗi: " + ex.Message);
            }
        }
        private bool ValidatePassword(string enteredPassword)
        {
            return enteredPassword == "Sentek.vn";
        }
        private void frmCalibration_Load(object sender, EventArgs e)
        {
            if (this.Owner is SenAIS mainForm)
            {
                this.calibrationType = mainForm.SelectedCalibrationType;
            }
        }
    }
}
