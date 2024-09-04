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
    public partial class frmStandards : Form
    {
        private SQLHelper sqlHelper;
        private DataTable vehicleStandardsTable;
        public frmStandards()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
            LoadStandardsData();
        }
        private void LoadStandardsData()
        {
            vehicleStandardsTable = sqlHelper.GetVehicleStandardsData();

            // Đặt DataTable vào DataGridView và thay đổi tên các cột thành tiếng Việt
            dgStandards.DataSource = vehicleStandardsTable;

            // Đổi tên các cột thành tiếng Việt
            dgStandards.DataSource = vehicleStandardsTable;
            dgStandards.Columns["TypeCar"].HeaderText = "Loại xe";
            dgStandards.Columns["MinSpeed"].HeaderText = "Tốc độ tối thiểu";
            dgStandards.Columns["MaxSpeed"].HeaderText = "Tốc độ tối đa";
            dgStandards.Columns["MinFrontBrake"].HeaderText = "Phanh trước tối thiểu";
            dgStandards.Columns["MinRearBrake"].HeaderText = "Phanh sau tối thiểu";
            dgStandards.Columns["MinHandBrake"].HeaderText = "Phanh tay tối thiểu";
            dgStandards.Columns["DiffFrontBrakeMax"].HeaderText = "Chênh lệch phanh trước tối đa";
            dgStandards.Columns["DiffRearBrakeMax"].HeaderText = "Chênh lệch phanh sau tối đa";
            dgStandards.Columns["DiffHandBrakeMax"].HeaderText = "Chênh lệch phanh tay tối đa";
            dgStandards.Columns["MaxNoise"].HeaderText = "Độ ồn tối đa";
            dgStandards.Columns["MinWhistle"].HeaderText = "Còi tối thiểu";
            dgStandards.Columns["MaxWhistle"].HeaderText = "Còi tối đa";
            dgStandards.Columns["MinSideSlip"].HeaderText = "Độ lệch ngang tối thiểu";
            dgStandards.Columns["MaxSideSlip"].HeaderText = "Độ lệch ngang tối đa";
            dgStandards.Columns["MaxHC"].HeaderText = "HC tối đa";
            dgStandards.Columns["MaxCO"].HeaderText = "CO tối đa";
            dgStandards.Columns["MaxCO2"].HeaderText = "CO2 tối đa";
            dgStandards.Columns["MaxO2"].HeaderText = "O2 tối đa";
            dgStandards.Columns["MaxNO"].HeaderText = "NO tối đa";
            dgStandards.Columns["MaxHSU"].HeaderText = "HSU tối đa";
            dgStandards.Columns["Diesel"].HeaderText = "Hệ số Diesel";
            dgStandards.Columns["MinHLIntensity"].HeaderText = "Cường độ chiếu sáng tối thiểu";
            dgStandards .Columns["DiffHoriLeftHLMin"].HeaderText = "Chênh lệch ngang đèn pha trái tối thiểu";
            dgStandards.Columns["DiffHoriLeftHLMax"].HeaderText = "Chênh lệch ngang đèn pha trái tối đa";
            dgStandards.Columns["DiffHoriHLMin"].HeaderText = "Chênh lệch ngang đèn pha tối thiểu";
            dgStandards.Columns["DiffHoriRightHLMax"].HeaderText = "Chênh lệch ngang phải đèn pha tối đa";
            dgStandards.Columns["DiffVertiHLMin"].HeaderText = "Chênh lệch dọc đèn pha tối thiểu";
            dgStandards.Columns["DiffVertiHLMax"].HeaderText = "Chênh lệch dọc đèn pha tối đa";
            dgStandards.Columns["DiffHoriLBMin"].HeaderText = "Chênh lệch ngang đèn cos tối thiểu";
            dgStandards.Columns["DiffHoriLBMax"].HeaderText = "Chênh lệch ngang đèn cos tối đa";
            dgStandards.Columns["DiffVertiLBMin"].HeaderText = "Chênh lệch dọc đèn cốt tối thiểu";
            dgStandards.Columns["DiffVertiLBMax"].HeaderText = "Chênh lệch dọc đèn cốt tối đa";
            dgStandards.Columns["MinLBIntensity"].HeaderText = "Cường độ đèn cốt tối thiểu";
            dgStandards.Columns["LightHeight"].HeaderText = "Độ cao đèn";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn lưu các thay đổi?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    sqlHelper.UpdateVehicleStandardsData(vehicleStandardsTable);
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
            if (dgStandards.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgStandards.SelectedRows)
                    {
                        dgStandards.Rows.Remove(row);
                    }
                    // Cập nhật thay đổi vào cơ sở dữ liệu
                    sqlHelper.UpdateVehicleStandardsData(vehicleStandardsTable);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa.");
            }
        }
    }
}
