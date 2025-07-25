using SenAIS.Core.Repositories;
using System;
using System.Data;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmInspector : Form
    {
        private readonly InspectorRepository inspectorRepo = new InspectorRepository();
        private DataTable inspectorTable;
        public frmInspector()
        {
            InitializeComponent();
            LoadInspectorData();
        }
        private void LoadInspectorData()
        {
            try
            {
                // Tải dữ liệu từ cơ sở dữ liệu
                inspectorTable = inspectorRepo.GetInspectorData();

                if (inspectorTable == null || inspectorTable.Rows.Count == 0)
                {
                    // Nếu không có dữ liệu, tạo bảng trống với header
                    inspectorTable = new DataTable();
                    inspectorTable.Columns.Add("InspectorID", typeof(int));
                    inspectorTable.Columns.Add("InspectorName", typeof(string));
                }

                // Gán bảng dữ liệu cho DataGridView
                dgInspector.DataSource = inspectorTable;

                // Đổi tên các cột thành tiếng Việt
                if (dgInspector.Columns.Contains("InspectorID"))
                    dgInspector.Columns["InspectorID"].HeaderText = "Mã Thanh tra";

                if (dgInspector.Columns.Contains("InspectorName"))
                    dgInspector.Columns["InspectorName"].HeaderText = "Tên Thanh tra";

                // Đặt trạng thái chỉ đọc cho các cột
                dgInspector.Columns["InspectorID"].ReadOnly = true;
                dgInspector.Columns["InspectorName"].ReadOnly = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thanh tra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn lưu các thay đổi?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    inspectorRepo.UpdateInspectorData(inspectorTable);
                    MessageBox.Show("Lưu thay đổi thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lưu thay đổi thất bại: {ex.Message}");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgInspector.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa thông tin người kiểm tra này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgInspector.SelectedRows)
                    {
                        if (row.DataBoundItem is DataRowView rowView)
                        {
                            int inspectorId = Convert.ToInt32(rowView["InspectorID"]);
                            inspectorRepo.DeleteInspector(inspectorId); // gọi hàm xóa DB
                            dgInspector.Rows.Remove(row); // xóa khỏi DataGridView
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void dgInspector_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var columnName = dgInspector.Columns[e.ColumnIndex].Name;

            if (columnName == "InspectorName")
            {
                string value = e.FormattedValue?.ToString()?.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    dgInspector.Rows[e.RowIndex].ErrorText = "Tên thanh tra không được để trống.";
                    e.Cancel = true;
                    return;
                }

                // Kiểm tra trùng tên trong dgv (nội bộ)
                for (int i = 0; i < dgInspector.Rows.Count; i++)
                {
                    if (i == e.RowIndex) continue;

                    var cellValue = dgInspector.Rows[i].Cells["InspectorName"].Value?.ToString()?.Trim();
                    if (!string.IsNullOrEmpty(cellValue) && string.Equals(cellValue, value, StringComparison.OrdinalIgnoreCase))
                    {
                        dgInspector.Rows[e.RowIndex].ErrorText = "Tên thanh tra bị trùng.";
                        e.Cancel = true;
                        return;
                    }
                }

                dgInspector.Rows[e.RowIndex].ErrorText = string.Empty; // Clear error
            }
        }
    }
}
