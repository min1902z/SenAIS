using OfficeOpenXml;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class SenAIS : Form
    {
        private Form activeForm = null;
        public string serialNumber;
        private static readonly string calibWeightL = ConfigurationManager.AppSettings["Calib_WeightL"];
        private static readonly string calibWeightR = ConfigurationManager.AppSettings["Calib_WeightR"];
        private static readonly string calibSpeed = ConfigurationManager.AppSettings["Calib_Speed"];
        private static readonly string calibSS = ConfigurationManager.AppSettings["Calib_SS"];
        private static readonly string calibLBrake = ConfigurationManager.AppSettings["Calib_LBrake"];
        private static readonly string calibRBrake = ConfigurationManager.AppSettings["Calib_RBrake"];
        private static readonly string calibLSteer = ConfigurationManager.AppSettings["Calib_SteerL"];
        private static readonly string calibRSteer = ConfigurationManager.AppSettings["Calib_SteerR"];
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
            activeForm = childForm;
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
            if (activeForm is frmInspection currentInspection)
            {
                this.serialNumber = currentInspection.GetVinNumber();
                currentInspection.Close();
            }
            OpenChildForm(new frmInspection(this.serialNumber));
        }

        private void TSTruyXuat_Click(object sender, EventArgs e)
        {
            if (activeForm is frmInspection currentInspection)
            {
                this.serialNumber = currentInspection.GetVinNumber();
            }
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
            calibrationForm.SetOPCItem(calibWeightL);
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
            calibrationForm.SetOPCItem(calibWeightR);
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
            string newUI = ConfigurationManager.AppSettings["DefaultMainUI"];
            tsSwitchMainUI.Text = newUI == "Menu" ? "Đổi Bảng Danh Sách Xe" : "Đổi Bảng Điều Khiển";
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
            if (activeForm is frmInspection currentInspection)
            {
                this.serialNumber = currentInspection.GetVinNumber();
            }
            OpenChildForm(new frmAboutUs());
        }

        private void tsVehicleStandard_Click(object sender, EventArgs e)
        {
            if (activeForm is frmInspection currentInspection)
            {
                this.serialNumber = currentInspection.GetVinNumber();
            }
            OpenChildForm(new frmStandards());
        }

        private void tsInspector_Click(object sender, EventArgs e)
        {
            if (activeForm is frmInspection currentInspection)
            {
                this.serialNumber = currentInspection.GetVinNumber();
            }
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
            calibrationForm.SetOPCItem(calibLSteer);
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
            calibrationForm.SetOPCItem(calibRSteer);
        }

        internal class VehicleDataSet : global::SenAIS.VehicleDataSet
        {
        }

        private void tsReportByDate_Click(object sender, EventArgs e)
        {
            SQLHelper sqlHelper = new SQLHelper();
            DataTable vehicleList = sqlHelper.GetVehicleListByDate();
            if (vehicleList.Rows.Count == 0)
            {
                MessageBox.Show("Không có xe nào trong ngày hôm nay để xuất Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
<<<<<<< HEAD
            string sourcePath = @"D:\DanhSachXe.xlsx";  // File mẫu
            string exportPath = $@"D:\DanhSachXe_{DateTime.Now:yyyy-MM-dd}.xlsx";
=======
            string sourcePath = @"D:\Report\DanhSachXe.xlsx";  // File mẫu
            string exportPath = $@"D:\Report\DanhSachXe_{DateTime.Now:yyyy-MM-dd}.xlsx";
>>>>>>> SenAIS_DH
            if (File.Exists(exportPath))
            {
                DialogResult result = MessageBox.Show($"File {exportPath} đã tồn tại. Bạn có muốn ghi đè không?", "Xác nhận ghi đè",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Xuất dữ liệu bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            File.Copy(sourcePath, exportPath, true);
            ExportToExcel(exportPath, vehicleList);
        }
        //private void ExportToExcel(string filePath, DataTable vehicleList)
        //{
        //    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        //    using (var package = new ExcelPackage(new FileInfo(filePath)))
        //    {
        //        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];  // Chọn sheet đầu tiên

        //        int rowCount = worksheet.Dimension?.Rows ?? 0;
        //        int startRow = 0;
        //        int totalRow = 0;

        //        // 4️⃣ Tìm dòng có số "1"
        //        for (int row = 1; row <= rowCount; row++)
        //        {
        //            var firstCellValue = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
        //            if (firstCellValue == "1")
        //            {
        //                startRow = row;
        //                break;
        //            }
        //        }

        //        // 5️⃣ Ghi dữ liệu vào Excel
        //        for (int i = 0; i < vehicleList.Rows.Count; i++)
        //        {
        //            worksheet.Cells[startRow + i, 2].Value = vehicleList.Rows[i]["VehicleType"];  // Kiểu Loại
        //            worksheet.Cells[startRow + i, 3].Value = vehicleList.Rows[i]["SerialNumber"]; // Số Khung
        //            worksheet.Cells[startRow + i, 4].Value = vehicleList.Rows[i]["FrameNumber"];  // Số Máy
        //            worksheet.Cells[startRow + i, 5].Value = vehicleList.Rows[i]["Color"];        // Màu Sơn
        //        }

        //        // 6️⃣ Ghi tổng số xe vào dòng cuối cùng
        //        totalRow = vehicleList.Rows.Count;
        //        for (int row = 1; row <= rowCount; row++)
        //        {
        //            var cellValue = worksheet.Cells[row, 1].Value?.ToString();
        //            if (cellValue != null && cellValue.Contains("Tổng cộng/ Total:"))
        //            {
        //                worksheet.Cells[row, 1].Value = $"Tổng cộng/ Total: {totalRow} Xe/ Vehicle";
        //                break;
        //            }
        //        }

        //        // 7️⃣ Lưu file
        //        package.Save();
        //        MessageBox.Show("Xuất biên bản bàn giao thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        private void ExportToExcel(string filePath, DataTable vehicleList)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet ws1 = package.Workbook.Worksheets[0]; // Sheet 1
                int maxPerSheet = 30;
                int totalVehicles = vehicleList.Rows.Count;

                int startRowSheet1 = FindStartRow(ws1);

                // Ghi dữ liệu vào Sheet 1
                for (int i = 0; i < Math.Min(maxPerSheet, totalVehicles); i++)
                {
                    int row = startRowSheet1 + i;
                    ws1.Cells[row, 1].Value = (i + 1); // STT
                    ws1.Cells[row, 2].Value = vehicleList.Rows[i]["VehicleType"];
                    ws1.Cells[row, 3].Value = vehicleList.Rows[i]["SerialNumber"];
                    ws1.Cells[row, 4].Value = vehicleList.Rows[i]["FrameNumber"];
                    ws1.Cells[row, 5].Value = vehicleList.Rows[i]["Color"];
                }

                // Ghi ngày xuất biên bản
                UpdateExportDate(ws1);
                UpdateTotalRow(ws1, totalVehicles);

                // Nếu có hơn 30 xe, tạo thêm Sheet 2
                if (totalVehicles > maxPerSheet)
                {
                    ExcelWorksheet ws2 = package.Workbook.Worksheets.Count > 1
                        ? package.Workbook.Worksheets[1]
                        : package.Workbook.Worksheets.Add("SHEET 2", ws1);

                    int startRowSheet2 = FindStartRow(ws2);
                    int itemsInSheet2 = Math.Min(maxPerSheet, totalVehicles - maxPerSheet);

                    int vehiclesInSheet2 = totalVehicles - maxPerSheet;

                    for (int i = 0; i < maxPerSheet; i++)
                    {
                        int row = startRowSheet2 + i;
                        int index = i + maxPerSheet;

                        ws2.Cells[row, 1].Value = (i + 1); // STT 1-30

                        if (i < vehiclesInSheet2)
                        {
                            ws2.Cells[row, 2].Value = vehicleList.Rows[index]["VehicleType"];
                            ws2.Cells[row, 3].Value = vehicleList.Rows[index]["SerialNumber"];
                            ws2.Cells[row, 4].Value = vehicleList.Rows[index]["FrameNumber"];
                            ws2.Cells[row, 5].Value = vehicleList.Rows[index]["Color"];
                        }
                        else
                        {
                            // Xóa dữ liệu dư nếu có
                            for (int col = 2; col <= 5; col++)
                            {
                                ws2.Cells[row, col].Clear();
                            }
                        }
                    }

                    UpdateExportDate(ws2);
                    UpdateTotalRow(ws2, totalVehicles);
                }

                package.Save();
                MessageBox.Show("Xuất dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private int FindStartRow(ExcelWorksheet ws)
        {
            for (int row = 1; row <= ws.Dimension.Rows; row++)
            {
                var firstCellValue = ws.Cells[row, 1].Value?.ToString()?.Trim();
                if (firstCellValue == "1")
                    return row;
            }
            return 0;
        }

        private void UpdateExportDate(ExcelWorksheet ws)
        {
            string today = DateTime.Now.ToString("dd");
            string month = DateTime.Now.ToString("MM");
            string year = DateTime.Now.ToString("yyyy");

            for (int row = 1; row <= ws.Dimension.Rows; row++)
            {
                for (int col = 1; col <= ws.Dimension.Columns; col++)
                {
                    var value = ws.Cells[row, col].Value?.ToString();
                    if (!string.IsNullOrEmpty(value) && value.Trim().StartsWith("Ngày/ Date"))
                    {
                        ws.Cells[row, col].Value = $"Ngày/ Date..{today}.... Tháng/Month.. {month}.. Năm/ Year.. {year}";
                        return;
                    }
                }
            }
        }
        private void UpdateTotalRow(ExcelWorksheet ws, int totalVehicles)
        {
            bool updated = false;
            for (int row = 1; row <= ws.Dimension.Rows; row++)
            {
                var val = ws.Cells[row, 1].Value?.ToString();
                if (!string.IsNullOrEmpty(val) && val.Contains("Tổng cộng/ Total:"))
                {
                    ws.Cells[row, 1].Value = $"Tổng cộng/ Total: {totalVehicles} Xe/ Vehicle";
                    updated = true;
                    break;
                }
            }

            // Nếu không có dòng sẵn, thêm vào cuối cùng
            if (!updated)
            {
                int lastRow = ws.Dimension?.Rows ?? 0;
                ws.Cells[lastRow + 1, 1].Value = $"Tổng cộng/ Total: {totalVehicles} Xe/ Vehicle";
            }
        }
        private bool ValidatePassword(string inputPassword)
        {
            string adminPassword = ConfigurationManager.AppSettings["PasswordConfig"];
            return inputPassword == adminPassword;
        }
        private void tsSwitchMainUI_Click(object sender, EventArgs e)
        {
            string password = Prompt.ShowDialog("Vui lòng nhập mật khẩu để chuyển giao diện:", "Xác nhận mật khẩu");

            if (!string.IsNullOrEmpty(password))
            {
                if (ValidatePassword(password))
                {
                    if (activeForm is frmInspection currentInspection)
                    {
                        // Gọi phương thức chuyển đổi giao diện
                        currentInspection.ToggleMainUI();

                        // Cập nhật lại Text cho nút toolstrip
                        string newUI = ConfigurationManager.AppSettings["DefaultMainUI"];
                        tsSwitchMainUI.Text = newUI == "Menu" ? "Đổi Bảng Danh Sách Xe" : "Đổi Bảng Điều Khiển";
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Đổi giao diện bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void tsSettingConfig_Click(object sender, EventArgs e)
        {
            var form = new frmSettingConfig();
            form.ShowDialog();
        }
    }
}
