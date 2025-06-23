using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmCarList : Form
    {
        private frmInspection inspectionForm;
        public frmCarList(frmInspection inspectionForm)
        {
            InitializeComponent();
            this.inspectionForm = inspectionForm;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Chọn file Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;  // Gán đường dẫn vào txtFilePath
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("Vui lòng chọn file hợp lệ!");
                return;
            }

            DataTable dt = ReadExcel(txtFilePath.Text);
            if (dt != null)
            {
                dgVehicleList.DataSource = dt;
                AddSelectButton();
            }
        }
        private void AddSelectButton()
        {
            if (dgVehicleList.Columns["SelectCar"] == null)  // Kiểm tra tránh trùng cột
            {
                DataGridViewButtonColumn btnSelect = new DataGridViewButtonColumn();
                btnSelect.Name = "SelectCar";
                btnSelect.HeaderText = "Chọn xe";
                btnSelect.Text = "Chọn";
                btnSelect.UseColumnTextForButtonValue = true;
                dgVehicleList.Columns.Add(btnSelect);

                dgVehicleList.CellClick += dgVehicleList_CellClick;  // Bắt sự kiện click
            }
        }
        private DataTable ReadExcel(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];  // Lấy sheet đầu tiên
                DataTable dt = new DataTable();

                // Thêm cột dữ liệu
                dt.Columns.Add("NO.");   // Số thứ tự
                dt.Columns.Add("Model");
                dt.Columns.Add("VIN");
                dt.Columns.Add("Engine");
                dt.Columns.Add("Color");

                int rowCount = worksheet.Dimension.Rows;
                int startRow = 0;

                // 🔎 Tìm dòng đầu tiên có số "1"  
                for (int row = 1; row <= rowCount; row++)
                {
                    var firstCellValue = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
                    if (firstCellValue == "1")
                    {
                        startRow = row;
                        break;
                    }
                }

                if (startRow == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu hợp lệ trong file Excel!");
                    return null;
                }

                // 🚀 Đọc dữ liệu từ dòng có số 1, bỏ qua các STT không hợp lệ
                for (int row = startRow; row <= rowCount; row++)
                {
                    var stt = worksheet.Cells[row, 1].Value?.ToString()?.Trim();

                    // ✅ Chỉ lấy STT là số, bỏ các dòng STT không phải số
                    if (!int.TryParse(stt, out int sttNum)) break;

                    var model = worksheet.Cells[row, 2].Value?.ToString()?.Trim();
                    var vin = worksheet.Cells[row, 3].Value?.ToString()?.Trim();
                    var engine = worksheet.Cells[row, 4].Value?.ToString()?.Trim();
                    var color = worksheet.Cells[row, 5].Value?.ToString()?.Trim();

                    // ⏭ Bỏ qua dòng chỉ có STT mà không có dữ liệu
                    if (string.IsNullOrEmpty(model) && string.IsNullOrEmpty(vin) && string.IsNullOrEmpty(engine) && string.IsNullOrEmpty(color))
                        continue;

                    dt.Rows.Add(stt, model, vin, engine, color);
                }

                return dt;
            }

        }

        private void dgVehicleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgVehicleList.Columns["SelectCar"].Index && e.RowIndex >= 0)
            {
                string model = dgVehicleList.Rows[e.RowIndex].Cells["Model"].Value.ToString();
                string vin = dgVehicleList.Rows[e.RowIndex].Cells["VIN"].Value.ToString();
                string engine = dgVehicleList.Rows[e.RowIndex].Cells["Engine"].Value.ToString();
                string color = dgVehicleList.Rows[e.RowIndex].Cells["Color"].Value.ToString();

                // Gửi dữ liệu sang frmInspection
                inspectionForm.UpdateCarInfo(vin, engine, model, color);
            }
        }
    }
}
