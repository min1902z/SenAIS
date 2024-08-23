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
    public partial class frmReport : Form
    {
        private Form parentForm;
        private SQLHelper sqlHelper;
        private string serialNumber;
        public frmReport(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
            if (!string.IsNullOrEmpty(serialNumber))
            {
                DisplayVehicleDetails(serialNumber);
            }
        }
        public frmReport()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
               string searchTerm = txtSearch.Text.Trim();
            DataTable results = sqlHelper.SearchVehicleInfo(searchTerm);

            // Hiển thị kết quả tìm kiếm trong DataGridView
            dgVehicleInfo.DataSource = results;
        }
        // Hiển thị chi tiết của phương tiện trong các TextBox
        private void DisplayVehicleDetails(string serialNumber)
        {
            DataRow vehicleDetails = sqlHelper.GetVehicleDetails(serialNumber);
            ClearTextBoxes();
            if (vehicleDetails != null)
            {
                txtSerialNum.Text = vehicleDetails["SerialNumber"].ToString();
                txtFrameNum.Text = vehicleDetails["FrameNumber"].ToString();
                txtTypeCar.Text = vehicleDetails["VehicleType"].ToString();
                txtInspector.Text = vehicleDetails["Inspector"].ToString();
                txtEngineNum.Text = vehicleDetails["EngineNumber"].ToString();
                DateTime inspectionDate;
                if (DateTime.TryParse(vehicleDetails["InspectionDate"].ToString(), out inspectionDate))
                {
                    txtDateInspec.Text = inspectionDate.ToShortDateString();
                }

                txtSpeed.Text = vehicleDetails["Speed"]?.ToString();
                txtSideSlip.Text = vehicleDetails["SideSlip"]?.ToString();
                txtNoise.Text = vehicleDetails["Noise"]?.ToString();
                txtWhistle.Text = vehicleDetails["Whistle"]?.ToString();
                txtHC.Text = vehicleDetails["HC"]?.ToString();
                txtCO.Text = vehicleDetails["CO"]?.ToString();
                txtCO2.Text = vehicleDetails["CO2"]?.ToString();
                txtO2.Text = vehicleDetails["O2"]?.ToString();
                txtNO.Text = vehicleDetails["NO"]?.ToString();
                txtOT.Text = vehicleDetails["OilTemp"]?.ToString();
                txtRPM.Text = vehicleDetails["RPM"]?.ToString();
                txtFrontLeftWeight.Text = vehicleDetails["FrontLeftWeight"]?.ToString();
                txtFrontRightWeight.Text = vehicleDetails["FrontRightWeight"]?.ToString();
                if (!string.IsNullOrWhiteSpace(txtFrontLeftWeight.Text) && !string.IsNullOrWhiteSpace(txtFrontRightWeight.Text))
                {
                    CalculateAndDisplaySum(txtFrontLeftWeight, txtFrontRightWeight, txtFrontSumWeight);
                }
                else
                {
                    txtFrontSumWeight.Text = string.Empty;
                }
                txtRearLeftWeight.Text = vehicleDetails["RearLeftWeight"]?.ToString();
                txtRearRightWeight.Text = vehicleDetails["RearRightWeight"]?.ToString();
                if (!string.IsNullOrWhiteSpace(txtRearLeftWeight.Text) && !string.IsNullOrWhiteSpace(txtRearRightWeight.Text))
                {
                    CalculateAndDisplaySum(txtRearLeftWeight, txtRearRightWeight, txtRearSumWeight);
                }
                else
                {
                    txtRearSumWeight.Text = string.Empty;
                }
                txtFrontLeftBrake.Text = vehicleDetails["FrontLeftBrake"]?.ToString();
                txtFrontRightBrake.Text = vehicleDetails["FrontRightBrake"]?.ToString();
                if (!string.IsNullOrWhiteSpace(txtFrontLeftBrake.Text) && !string.IsNullOrWhiteSpace(txtFrontRightBrake.Text))
                {
                    CalculateAndDisplaySum(txtFrontLeftBrake, txtFrontRightBrake, txtFrontSumBrake);
                    CalculateAndDisplayDiff(txtFrontLeftBrake, txtFrontRightBrake, txtFrontDiffBrake);
                }
                else
                {
                    txtFrontSumBrake.Text = string.Empty;
                    txtFrontDiffBrake.Text = string.Empty;
                }    
                txtRearLeftBrake.Text = vehicleDetails["RearLeftBrake"]?.ToString();
                txtRearRightBrake.Text = vehicleDetails["RearRightBrake"]?.ToString();
                if (!string.IsNullOrWhiteSpace(txtRearLeftBrake.Text) && !string.IsNullOrWhiteSpace(txtRearRightBrake.Text))
                {
                    CalculateAndDisplaySum(txtRearLeftBrake, txtRearRightBrake, txtRearSumBrake);
                    CalculateAndDisplayDiff(txtRearLeftBrake, txtRearRightBrake, txtRearDiffBrake);
                }
                else
                {
                    txtRearSumBrake.Text = string.Empty;
                    txtRearDiffBrake.Text = string.Empty;
                }
                txtHandLeftBrake.Text = vehicleDetails["HandBrakeLeft"]?.ToString();
                txtHandRightBrake.Text = vehicleDetails["HandBrakeRight"]?.ToString();
                if (!string.IsNullOrWhiteSpace(txtHandLeftBrake.Text) && !string.IsNullOrWhiteSpace(txtHandRightBrake.Text))
                {
                    CalculateAndDisplaySum(txtHandLeftBrake, txtHandRightBrake, txtHandSumBrake);
                    CalculateAndDisplayDiff(txtHandLeftBrake, txtHandRightBrake, txtHandDiffBrake);
                }
                else
                {
                    txtHandSumBrake.Text = string.Empty;
                    txtHandDiffBrake.Text = string.Empty;
                }
                txtLHLIntensity.Text = vehicleDetails["LHLIntensity"]?.ToString();
                txtLHLVertical.Text = vehicleDetails["LHLVertical"]?.ToString();
                txtLHLHorizontal.Text = vehicleDetails["LHLHorizontal"]?.ToString();
                txtRHLIntensity.Text = vehicleDetails["RHLIntensity"]?.ToString();
                txtRHLVertical.Text = vehicleDetails["RHLVertical"]?.ToString();
                txtRHLHorizontal.Text = vehicleDetails["RHLHorizontal"]?.ToString();
                txtLLBIntensity.Text = vehicleDetails["LLBIntensity"]?.ToString();
                txtLLBVertical.Text = vehicleDetails["LLBVertical"]?.ToString();
                txtLLBHorizontal.Text = vehicleDetails["LLBHorizontal"]?.ToString();
                txtRLBIntensity.Text = vehicleDetails["RLBIntensity"]?.ToString();
                txtRLBVertical.Text = vehicleDetails["RLBVertical"]?.ToString();
                txtRLBHorizontal.Text = vehicleDetails["RLBHorizontal"]?.ToString();
                txtMinSpeed1.Text = vehicleDetails["MinSpeed"]?.ToString();
                txtMaxSpeed1.Text = vehicleDetails["MaxSpeed"]?.ToString();
                txtHSU1.Text = vehicleDetails["HSU"]?.ToString();

            }
            else
            {
                // Xử lý khi không có dữ liệu trả về (có thể xóa sạch các TextBox nếu cần)
                ClearTextBoxes();
            }
        }
        private void ClearTextBoxes()
        {
            txtSerialNum.Clear();
            txtFrameNum.Clear();
            txtTypeCar.Clear();
            txtInspector.Clear();
            txtEngineNum.Clear();
            txtDateInspec.Clear();

            txtFrontSumWeight.Clear();
            txtRearSumWeight.Clear();
            txtFrontSumBrake.Clear();
            txtFrontDiffBrake.Clear();
            txtRearSumBrake.Clear();
            txtRearDiffBrake.Clear();
            txtHandSumBrake.Clear();
            txtHandDiffBrake.Clear();
            // Làm sạch các TextBox khác tương tự
        }
        private void CalculateAndDisplaySum(TextBox textBox1, TextBox textBox2, TextBox resultTextBox)
        {
            // Chuyển đổi giá trị từ TextBox1 và TextBox2 sang decimal, mặc định là 0 nếu không chuyển đổi được
            decimal value1 = decimal.TryParse(textBox1.Text, out decimal v1) ? v1 : 0;
            decimal value2 = decimal.TryParse(textBox2.Text, out decimal v2) ? v2 : 0;

            // Tính tổng
            decimal sum = value1 + value2;

            // Hiển thị kết quả vào resultTextBox
            if (sum > 0)
            {
                resultTextBox.Text = sum.ToString("F2"); // Định dạng 2 chữ số thập phân
            }
        }
        private void CalculateAndDisplayDiff(TextBox textBox1, TextBox textBox2, TextBox resultTextBox)
        {
            // Chuyển đổi giá trị từ TextBox1 và TextBox2 sang decimal, mặc định là 0 nếu không chuyển đổi được
            decimal value1 = decimal.TryParse(textBox1.Text, out decimal v1) ? v1 : 0;
            decimal value2 = decimal.TryParse(textBox2.Text, out decimal v2) ? v2 : 0;

            // Tính diff
            decimal diff = 0;
            if (value1 > value2)
            diff = 100*(value1 - value2) / value1;
            else
            diff = 100*(value2 - value1) / value2;

            // Hiển thị kết quả vào resultTextBox
            resultTextBox.Text = diff.ToString("F2"); // Định dạng 2 chữ số thập phân
            
        }
        private void dgVehicleInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgVehicleInfo.SelectedRows.Count > 0)
            {
                string selectedSerialNumber = dgVehicleInfo.SelectedRows[0].Cells["SerialNumber"].Value.ToString();
                DisplayVehicleDetails(selectedSerialNumber);
            }
        }
    }
}
