using System;
using System.Data;
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
            sqlHelper = new SQLHelper();
            LoadStandardsData();
        }
        private void LoadStandardsData()
        {
            try
            {
                vehicleStandardsTable = sqlHelper.GetVehicleStandardsData();

                if (vehicleStandardsTable != null && vehicleStandardsTable.Rows.Count != 0)
                {
                    // Đặt DataTable vào DataGridView và thay đổi tên các cột thành tiếng Việt
                    dgStandards.DataSource = vehicleStandardsTable;

                    // Đổi tên các cột thành tiếng Việt
                    dgStandards.DataSource = vehicleStandardsTable;
                    dgStandards.Columns["VehicleType"].HeaderText = "Loại xe";
                    dgStandards.Columns["MinSpeed"].HeaderText = "Tốc độ tối thiểu";
                    dgStandards.Columns["MaxSpeed"].HeaderText = "Tốc độ tối đa";
                    dgStandards.Columns["MinFrontBrake"].HeaderText = "Phanh trước tối thiểu";
                    dgStandards.Columns["MinRearBrake"].HeaderText = "Phanh sau tối thiểu";
                    dgStandards.Columns["MinHandBrake"].HeaderText = "Phanh tay tối thiểu";
                    dgStandards.Columns["MaxDiffFrontBrake"].HeaderText = "Chênh lệch phanh trước tối đa";
                    dgStandards.Columns["MaxDiffRearBrake"].HeaderText = "Chênh lệch phanh sau tối đa";
                    dgStandards.Columns["MaxDiffHandBrake"].HeaderText = "Chênh lệch phanh tay tối đa";
                    dgStandards.Columns["MaxNoise"].HeaderText = "Độ ồn tối đa";
                    dgStandards.Columns["MinWhistle"].HeaderText = "Còi tối thiểu";
                    dgStandards.Columns["MaxWhistle"].HeaderText = "Còi tối đa";
                    dgStandards.Columns["MinSideSlip"].HeaderText = "Độ trượt ngang tối thiểu";
                    dgStandards.Columns["MaxSideSlip"].HeaderText = "Độ trượt ngang tối đa";
                    dgStandards.Columns["MaxHC"].HeaderText = "HC tối đa";
                    dgStandards.Columns["MaxCO"].HeaderText = "CO tối đa";
                    dgStandards.Columns["MaxCO2"].HeaderText = "CO2 tối đa";
                    dgStandards.Columns["MaxO2"].HeaderText = "O2 tối đa";
                    dgStandards.Columns["MaxNO"].HeaderText = "NO tối đa";
                    dgStandards.Columns["MaxHSU"].HeaderText = "HSU tối đa";
                    dgStandards.Columns["MaxDiesel"].HeaderText = "Hệ số Diesel";
                    dgStandards.Columns["MinHLIntensity"].HeaderText = "Cường độ đen Pha tối thiểu";
                    dgStandards.Columns["MinDiffHoriLeftHB"].HeaderText = "Chênh lệch ngang đèn Pha trái tối thiểu";
                    dgStandards.Columns["MaxDiffHoriLeftHB"].HeaderText = "Chênh lệch ngang đèn Pha trái tối đa";
                    dgStandards.Columns["MinDiffHoriHB"].HeaderText = "Chênh lệch ngang đèn Pha tối thiểu";
                    dgStandards.Columns["MaxDiffHoriHB"].HeaderText = "Chênh lệch ngang đèn Pha tối đa";
                    dgStandards.Columns["MinDiffVertiHB"].HeaderText = "Chênh lệch dọc đèn Pha tối thiểu";
                    dgStandards.Columns["MaxDiffVertiHB"].HeaderText = "Chênh lệch dọc đèn Pha tối đa";
                    dgStandards.Columns["MinDiffHoriLB"].HeaderText = "Chênh lệch ngang đèn Cốt tối thiểu";
                    dgStandards.Columns["MaxDiffHoriLB"].HeaderText = "Chênh lệch ngang đèn Cốt tối đa";
                    dgStandards.Columns["MinDiffVertiLB"].HeaderText = "Chênh lệch dọc đèn Cốt tối thiểu";
                    dgStandards.Columns["MaxDiffVertiLB"].HeaderText = "Chênh lệch dọc đèn Cốt tối đa";
                    dgStandards.Columns["MinLBIntensity"].HeaderText = "Cường độ đèn Cốt tối thiểu";
                    dgStandards.Columns["MinLightHeight"].HeaderText = "Độ cao đèn tối thiểu";
                    dgStandards.Columns["MaxLightHeight"].HeaderText = "Độ cao đèn tối đa";
                    dgStandards.Columns["MinLeftSteer"].HeaderText = "Độ góc lái trái tối thiểu";
                    dgStandards.Columns["MinRightSteer"].HeaderText = "Độ góc lái phải tối thiểu";
                    dgStandards.Columns["MaxLeftSteer"].HeaderText = "Độ góc lái trái tối đa";
                    dgStandards.Columns["MaxRightSteer"].HeaderText = "Độ góc lái phải tối đa";
                    dgStandards.Columns["MinFLIntensity"].HeaderText = "Cường độ đèn Sương mù tối thiểu";
                    dgStandards.Columns["MaxFLIntensity"].HeaderText = "Cường độ đèn Sương mù tối đa";
                    dgStandards.Columns["MinDiffVertiFL"].HeaderText = "Chênh lệch dọc đèn Sương mù tối thiểu";
                    dgStandards.Columns["MaxDiffVertiFL"].HeaderText = "Chênh lệch dọc đèn Sương mù tối đa";
                    dgStandards.Columns["MinDiffHoriFL"].HeaderText = "Chênh lệch ngang đèn Sương mù tối thiểu";
                    dgStandards.Columns["MaxDiffHoriFL"].HeaderText = "Chênh lệch ngang đèn Sương mù tối đa";
                    dgStandards.Columns["MinFLHeight"].HeaderText = "Độ cao đèn Sương mù tối thiểu";
                    dgStandards.Columns["MaxFLHeight"].HeaderText = "Độ cao đèn Sương mù tối đa";
                    dgStandards.Columns["SampleVin"].HeaderText = "Số Vin mẫu";
                    dgStandards.Columns["SampleEngine"].HeaderText = "Số Máy mẫu";
                    dgStandards.Columns["MinLamda"].HeaderText = "Lamda tối thiểu";
                    dgStandards.Columns["MaxLamda"].HeaderText = "Lamda tối đa";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tiêu chuẩn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
