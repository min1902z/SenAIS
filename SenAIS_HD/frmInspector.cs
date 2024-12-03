using System;
using System.Data;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmInspector : Form
    {
        private SQLHelper sqlHelper;
        private DataTable inspectorTable;
        public frmInspector()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper();
            LoadInspectorData();
        }
        private void LoadInspectorData()
        {
            try
            {
                // Tải dữ liệu từ cơ sở dữ liệu
                inspectorTable = sqlHelper.GetInspectorData();

                if (inspectorTable == null || inspectorTable.Rows.Count == 0)
                {
                    // Nếu không có dữ liệu, tạo bảng trống với header
                    inspectorTable = new DataTable();
                    inspectorTable.Columns.Add("InspectorID", typeof(string));
                    inspectorTable.Columns.Add("InspectorName", typeof(string));
                }

                // Gán bảng dữ liệu cho DataGridView
                dgInspector.DataSource = inspectorTable;

                // Đổi tên các cột thành tiếng Việt
                dgInspector.Columns["InspectorID"].HeaderText = "Mã Thanh tra";
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
                    sqlHelper.UpdateInspectorData(inspectorTable);
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
                        dgInspector.Rows.Remove(row);
                    }
                    sqlHelper.UpdateInspectorData(inspectorTable);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }
    }
}
