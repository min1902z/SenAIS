using System;
using System.Configuration;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class SenAIS : Form
    {
        //private Form activeChildForm;
        private static readonly string calibSpeed = ConfigurationManager.AppSettings["Calib_Speed"];
        private static readonly string calibSS = ConfigurationManager.AppSettings["Calib_SS"];
        private static readonly string calibLBrake = ConfigurationManager.AppSettings["Calib_LBrake"];
        private static readonly string calibRBrake = ConfigurationManager.AppSettings["Calib_RBrake"];
        public SenAIS()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            // Đóng form con hiện tại nếu có
            if (panelBody.Controls.Count > 0)
                panelBody.Controls[0].Dispose();

            // Thiết lập form con mới
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Show();
        }
        private void TSHoTro_Click(object sender, EventArgs e)
        {
        }

        private void TSDangKiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInspection());
        }

        private void TSTruyXuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReport());
        }

        public string SelectedCalibrationType { get; private set; }
        private void tsLWeightCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "LeftWeight";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.Text = "Kiểm Chuẩn Tham Số - T.Lượng Trái";
            calibrationForm.lbCalibA.Text = "Calib\\LeftWeightA";
            calibrationForm.lbCalibB.Text = "Calib\\LeftWeightB";
            calibrationForm.lbParaA.Text = "Para\\LeftWeightA";
            calibrationForm.lbParaB.Text = "Para\\LeftWeightB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem("Hyundai.OCS10.T99");
        }

        private void tsRWeightCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "RightWeight";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - T.Lượng Phải";
            calibrationForm.lbCalibA.Text = "Calib\\RightWeightA";
            calibrationForm.lbCalibB.Text = "Calib\\RightWeightB";
            calibrationForm.lbParaA.Text = "Para\\RightWeightA";
            calibrationForm.lbParaB.Text = "Para\\RightWeightB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem("Hyundai.OCS10.T99");
        }

        private void tsSpeedCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "Speed";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - Tốc Độ";
            calibrationForm.lbCalibA.Text = "Calib\\SpeedA";
            calibrationForm.lbCalibB.Text = "Calib\\SpeedB";
            calibrationForm.lbParaA.Text = "Para\\SpeedA";
            calibrationForm.lbParaB.Text = "Para\\SpeedB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem(calibSpeed);
        }

        private void tsSideSlipCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "SideSlip";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - Trượt Ngang";
            calibrationForm.lbCalibA.Text = "Calib\\SideSlipA";
            calibrationForm.lbCalibB.Text = "Calib\\SideSlipB";
            calibrationForm.lbParaA.Text = "Para\\SideSlipA";
            calibrationForm.lbParaB.Text = "Para\\SideSlipB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem(calibSS);
        }

        private void tsLBrakeCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "LeftBrake";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - L.Phanh Trái";
            calibrationForm.lbCalibA.Text = "Calib\\LeftBrakeA";
            calibrationForm.lbCalibB.Text = "Calib\\LeftBrakeB";
            calibrationForm.lbParaA.Text = "Para\\LeftBrakeA";
            calibrationForm.lbParaB.Text = "Para\\LeftBrakeB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem(calibLBrake);
        }

        private void tsRBrakeCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "RightBrake";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - L.Phanh Phải";
            calibrationForm.lbCalibA.Text = "Calib\\RightBrakeA";
            calibrationForm.lbCalibB.Text = "Calib\\RightBrakeB";
            calibrationForm.lbParaA.Text = "Para\\RightBrakeA";
            calibrationForm.lbParaB.Text = "Para\\RightBrakeB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem(calibRBrake);
        }

        private void TSDuLieu_Click(object sender, EventArgs e)
        {

        }

        private void SenAIS_Load(object sender, EventArgs e)
        {
            OpenChildForm(new frmInspection());
        }

        private void TSReset_Click(object sender, EventArgs e)
        {
            RestartApplication();
        }
        private void RestartApplication()
        {
            try
            {
                // Lấy đường dẫn của ứng dụng hiện tại
                var applicationPath = Application.ExecutablePath;

                // Khởi động lại ứng dụng
                System.Diagnostics.Process.Start(applicationPath);

                // Thoát ứng dụng hiện tại
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể khởi động lại ứng dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TSAuboutMe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAboutUs());
        }

        private void tsVehicleStandard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmStandards());
        }

        private void tsInspector_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInspector());
        }

        private void TSTruyCapAdmin_Click(object sender, EventArgs e)
        {
            string adminPassword = ConfigurationManager.AppSettings["PasswordAdmin"];
            if (string.IsNullOrEmpty(adminPassword))
            {
                MessageBox.Show("Không tìm thấy cấu hình mật khẩu trong app.config.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string password = Prompt.ShowDialog("Vui lòng nhập mật khẩu để truy cập quyền:", "Xác nhận mật khẩu");
            if (password == adminPassword)
            {
                // Tạo đối tượng formReport hoặc tìm kiếm nếu đã tồn tại
                foreach (Form form in Application.OpenForms)
                {
                    if (form is frmReport reportForm)
                    {
                        reportForm.EnableEditButton(); // Gọi hàm hiển thị nút "Chỉnh sửa"
                        return;
                    }
                }
                MessageBox.Show("Vui lòng truy cập tính năng này khi cần thiết.");
            }
            else
            {
                MessageBox.Show("Mật khẩu không đúng!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsLeftSteerCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "LeftSteer";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - Góc Lái Trái";
            calibrationForm.lbCalibA.Text = "Calib\\LeftSteerA";
            calibrationForm.lbCalibB.Text = "Calib\\LeftSteerB";
            calibrationForm.lbParaA.Text = "Para\\LeftSteerA";
            calibrationForm.lbParaB.Text = "Para\\LeftSteerB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem("Hyundai.OCS10.T99");
        }

        private void tsRightSteerCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "RightSteer";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - Góc Lái Phải";
            calibrationForm.lbCalibA.Text = "Calib\\RightSteerA";
            calibrationForm.lbCalibB.Text = "Calib\\RightSteerB";
            calibrationForm.lbParaA.Text = "Para\\RightSteerA";
            calibrationForm.lbParaB.Text = "Para\\RightSteerB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem("Hyundai.OCS10.T99");
        }

        private void tsMMSConfig_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmMMSConfig());
            var editConfigForm = new frmMMSConfig();
            editConfigForm.Show();
        }

        private void SenAIS_FormClosing(object sender, FormClosingEventArgs e)
        {
            OPCUtility.DisconnectOPC();
        }
    }
}
