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

namespace SenAIS
{
    public partial class SenAIS : Form
    {
        private Form activeChildForm;
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
        public void ShowFormInNewWindow(Form form)
        {
            form.FormClosed += (s, args) => activeChildForm = null;
            form.Show();
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
            calibrationForm.lbCalibA.Text = "Calib\\WeightLeftA";
            calibrationForm.lbCalibB.Text = "Calib\\WeightLeftB";
            calibrationForm.lbParaA.Text = "Para\\WeightLeftA";
            calibrationForm.lbParaB.Text = "Para\\WeightLeftB";

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
            calibrationForm.lbCalibA.Text = "Calib\\WeightRightA";
            calibrationForm.lbCalibB.Text = "Calib\\WeightRightB";
            calibrationForm.lbParaA.Text = "Para\\WeightRightA";
            calibrationForm.lbParaB.Text = "Para\\WeightRightB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem("Hyundai.OCS10.T99");
        }

        private void tsSpeedCalib_Click(object sender, EventArgs e)
        {
            string calibrationType  = "Speed";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - Tốc Độ";
            calibrationForm.lbCalibA.Text = "Calib\\SpeedA";
            calibrationForm.lbCalibB.Text = "Calib\\SpeedB";
            calibrationForm.lbParaA.Text = "Para\\SpeedA";
            calibrationForm.lbParaB.Text = "Para\\SpeedB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem("Hyundai.OCS10.T99");
        }

        private void tsSideSlipCalib_Click(object sender, EventArgs e)
        {
            string calibrationType  = "SideSlip";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - Trượt Ngang";
            calibrationForm.lbCalibA.Text = "Calib\\AlignA";
            calibrationForm.lbCalibB.Text = "Calib\\AlignB";
            calibrationForm.lbParaA.Text = "Para\\AlignA";
            calibrationForm.lbParaB.Text = "Para\\AlignB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem("Hyundai.OCS10.T99");
        }

        private void tsLBrakeCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "LeftBrake";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - L.Phanh Trái";
            calibrationForm.lbCalibA.Text = "Calib\\BrakeLeftA";
            calibrationForm.lbCalibB.Text = "Calib\\BrakeLeftB";
            calibrationForm.lbParaA.Text = "Para\\BrakeLeftA";
            calibrationForm.lbParaB.Text = "Para\\BrakeLeftB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem("Hyundai.OCS10.T99");
        }

        private void tsRBrakeCalib_Click(object sender, EventArgs e)
        {
            string calibrationType = "RightBrake";
            frmCalibration calibrationForm = new frmCalibration(calibrationType);

            // Thiết lập tiêu đề và các thông tin khác
            calibrationForm.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - L.Phanh Phải";
            calibrationForm.lbCalibA.Text = "Calib\\BrakeRightA";
            calibrationForm.lbCalibB.Text = "Calib\\BrakeRightB";
            calibrationForm.lbParaA.Text = "Para\\BrakeRightA";
            calibrationForm.lbParaB.Text = "Para\\BrakeRightB";

            // Sử dụng OpenChildForm để mở form Calibration
            OpenChildForm(calibrationForm);
            calibrationForm.SetOPCItem("Hyundai.OCS10.T99");
        }

        private void TSDuLieu_Click(object sender, EventArgs e)
        {

        }

        private void SenAIS_Load(object sender, EventArgs e)
        {
            OpenChildForm(new frmInspection());
        }
    }
}
