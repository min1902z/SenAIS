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
    public partial class frmInspector : Form
    {
        private SQLHelper sqlHelper;
        private DataTable inspectorTable;
        public frmInspector()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
            LoadInspectorData();
        }
        private void LoadInspectorData()
        {
            inspectorTable = sqlHelper.GetInspectorData();
            dgInspector.DataSource = inspectorTable;

            // Đổi tên cột cho thân thiện (nếu cần)
            dgInspector.Columns["InspectorID"].HeaderText = "Mã Thanh tra";
            dgInspector.Columns["InspectorName"].HeaderText = "Tên Thanh tra";

            dgInspector.Columns["InspectorID"].ReadOnly = true;
            dgInspector.Columns["InspectorName"].ReadOnly = false;
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
