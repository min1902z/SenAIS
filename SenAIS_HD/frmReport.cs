using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmReport : Form
    {
        private SQLHelper sqlHelper;
        private string serialNumber;
        private DataTable standardsTable;
        private Dictionary<string, (string minField, string maxField)> textBoxMappings = new Dictionary<string, (string minField, string maxField)>()
        {
            { "txtSpeed", ("MinSpeed", "MaxSpeed") },
            { "txtFrontSumBrake", ("MinFrontBrake", null) },
            { "txtRearSumBrake", ("MinRearBrake", null) },
            { "txtHandSumBrake", ("MinHandBrake", null) },
            { "txtFrontDiffBrake", (null, "MaxDiffFrontBrake") },
            { "txtRearDiffBrake", (null, "MaxDiffRearBrake") },
            { "txtHandDiffBrake", (null, "MaxDiffHandBrake") },
            { "txtNoise", (null, "MaxNoise") },
            { "txtWhistle", ("MinWhistle", "MaxWhistle") },
            { "txtSideSlip", ("MinSideSlip", "MaxSideSlip") },
            { "txtHC", (null, "MaxHC") },
            { "txtCO", (null, "MaxCO") },
            { "txtCO2", (null, "MaxCO2") },
            { "txtO2", (null, "MaxO2") },
            { "txtNO", (null, "MaxNO") },
            { "txtHSU1", (null, "MaxHSU") },
            { "txtHSU2", (null, "MaxHSU") },
            { "txtHSU3", (null, "MaxHSU") },
            { "txtLHLIntensity", ("MinHLIntensity", "MaxHBIntensity") },
            { "txtRHLIntensity", ("MinHLIntensity", "MaxHBIntensity") },
            { "txtLHLHorizontal", ("MinDiffHoriHB", "MaxDiffHoriHB") },
            { "txtRHLHorizontal", ("MinDiffHoriHB", "MaxDiffHoriHB") },
            { "txtLHLVertical", ("MinDiffVertiHB", "MaxDiffVertiHB") },
            { "txtRHLVertical", ("MinDiffVertiHB", "MaxDiffVertiHB") },
            { "txtLLBIntensity", ("MinLBIntensity", "MaxLBIntensity") },
            { "txtRLBIntensity", ("MinLBIntensity", "MaxLBIntensity") },
            { "txtLLBHorizontal", ("MinDiffHoriLB", "MaxDiffHoriLB") },
            { "txtRLBHorizontal", ("MinDiffHoriLB", "MaxDiffHoriLB") },
            { "txtLLBVertical", ("MinDiffVertiLB", "MaxDiffVertiLB") },
            { "txtRLBVertical", ("MinDiffVertiLB", "MaxDiffVertiLB") },
            { "txtLeftSteerLW", ("MinLeftSteer", "MaxLeftSteer") },
            { "txtLeftSteerRW", ("MinLeftSteer", "MaxLeftSteer") },
            { "txtRightSteerLW", ("MinRightSteer", "MaxRightSteer") },
            { "txtRightSteerRW", ("MinRightSteer", "MaxRightSteer") }
        };
        public frmReport(string serialNumber)
        {
            InitializeComponent();
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            if (!string.IsNullOrEmpty(serialNumber))
            {
                DisplayVehicleDetails(serialNumber);
            }
        }
        public frmReport()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                DataTable results = sqlHelper.SearchVehicleInfo(searchTerm);
                if (results != null && results.Rows.Count != 0)
                {
                    // Hiển thị kết quả tìm kiếm trong DataGridView
                    dgVehicleInfo.DataSource = results;
                    dgVehicleInfo.Columns["SerialNumber"].HeaderText = "Số vin";
                    dgVehicleInfo.Columns["FrameNumber"].HeaderText = "Số máy";
                    dgVehicleInfo.Columns["VehicleType"].HeaderText = "Loại xe";
                    dgVehicleInfo.Columns["Inspector"].HeaderText = "Người kiểm tra";
                    dgVehicleInfo.Columns["InspectionDate"].HeaderText = "Ngày kiểm tra";
                    dgVehicleInfo.Columns["Fuel"].HeaderText = "Nhiên liệu";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy dữ liệu danh sách xe.", "Thông báo");
            }
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
                DateTime inspectionDate;
                if (DateTime.TryParse(vehicleDetails["InspectionDate"].ToString(), out inspectionDate))
                {
                    txtDateInspec.Text = inspectionDate.ToString("dd/MM/yyyy HH:mm");
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
                txtMinSpeed1.Text = vehicleDetails["MinSpeed1"]?.ToString();
                txtMaxSpeed1.Text = vehicleDetails["MaxSpeed1"]?.ToString();
                txtMinSpeed2.Text = vehicleDetails["MinSpeed2"]?.ToString();
                txtMaxSpeed2.Text = vehicleDetails["MaxSpeed2"]?.ToString();
                txtMinSpeed3.Text = vehicleDetails["MinSpeed3"]?.ToString();
                txtMaxSpeed3.Text = vehicleDetails["MaxSpeed3"]?.ToString();
                txtHSU1.Text = vehicleDetails["HSU1"]?.ToString();
                txtHSU2.Text = vehicleDetails["HSU2"]?.ToString();
                txtHSU3.Text = vehicleDetails["HSU3"]?.ToString();
                txtLeftSteerLW.Text = vehicleDetails["LeftSteerLW"]?.ToString();
                txtLeftSteerRW.Text = vehicleDetails["LeftSteerRW"]?.ToString();
                txtRightSteerLW.Text = vehicleDetails["RightSteerLW"]?.ToString();
                txtRightSteerRW.Text = vehicleDetails["RightSteerRW"]?.ToString();

                EvaluateMeasurements();
            }
            else
            {
                // Xử lý khi không có dữ liệu trả về (có thể xóa sạch các TextBox nếu cần)
                ClearTextBoxes();
            }
        }
        private void ClearTextBoxes()
        {
            ClearTextBoxes(txtSerialNum);
            ClearTextBoxes(txtFrameNum);
            ClearTextBoxes(txtTypeCar);
            ClearTextBoxes(txtInspector);
            ClearTextBoxes(txtDateInspec);

            ClearTextBoxes(txtSpeed);
            ClearTextBoxes(txtSideSlip);
            ClearTextBoxes(txtNoise);
            ClearTextBoxes(txtWhistle);

            ClearTextBoxes(txtHC);
            ClearTextBoxes(txtCO);
            ClearTextBoxes(txtCO2);
            ClearTextBoxes(txtO2);
            ClearTextBoxes(txtNO);
            ClearTextBoxes(txtOT);
            ClearTextBoxes(txtRPM);

            ClearTextBoxes(txtLHLIntensity);
            ClearTextBoxes(txtRHLIntensity);
            ClearTextBoxes(txtLHLVertical);
            ClearTextBoxes(txtRHLVertical);
            ClearTextBoxes(txtLHLHorizontal);
            ClearTextBoxes(txtRHLHorizontal);
            ClearTextBoxes(txtLLBIntensity);
            ClearTextBoxes(txtRLBIntensity);
            ClearTextBoxes(txtLLBVertical);
            ClearTextBoxes(txtRLBVertical);
            ClearTextBoxes(txtLLBHorizontal);
            ClearTextBoxes(txtRLBHorizontal);

            ClearTextBoxes(txtHSU1);
            ClearTextBoxes(txtHSU2);
            ClearTextBoxes(txtHSU3);
            ClearTextBoxes(txtMinSpeed1);
            ClearTextBoxes(txtMinSpeed2);
            ClearTextBoxes(txtMinSpeed3);
            ClearTextBoxes(txtMaxSpeed1);
            ClearTextBoxes(txtMaxSpeed2);
            ClearTextBoxes(txtMaxSpeed3);

            ClearTextBoxes(txtFrontLeftBrake);
            ClearTextBoxes(txtFrontRightBrake);
            ClearTextBoxes(txtRearLeftBrake);
            ClearTextBoxes(txtRearRightBrake);
            ClearTextBoxes(txtHandLeftBrake);
            ClearTextBoxes(txtHandRightBrake);
            ClearTextBoxes(txtFrontSumBrake);
            ClearTextBoxes(txtFrontDiffBrake);
            ClearTextBoxes(txtRearSumBrake);
            ClearTextBoxes(txtRearDiffBrake);
            ClearTextBoxes(txtHandSumBrake);
            ClearTextBoxes(txtHandDiffBrake);

            ClearTextBoxes(txtFrontLeftWeight);
            ClearTextBoxes(txtFrontRightWeight);
            ClearTextBoxes(txtRearLeftWeight);
            ClearTextBoxes(txtRearRightWeight);
            ClearTextBoxes(txtFrontSumWeight);
            ClearTextBoxes(txtRearSumWeight);

            ClearTextBoxes(txtLeftSteerLW);
            ClearTextBoxes(txtLeftSteerRW);
            ClearTextBoxes(txtRightSteerLW);
            ClearTextBoxes(txtRightSteerRW);
        }
        private void ClearTextBoxes(TextBox textBox)
        {
            textBox.Clear();
            textBox.BackColor = SystemColors.Window; // Đặt lại màu nền mặc định
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
            // Kiểm tra các trường hợp
            if (value1 == 0 && value2 == 0)
            {
                diff = 0; // Trường hợp cả hai giá trị bằng 0
            }
            else if (value1 == 0 || value2 == 0)
            {
                diff = 100; // Trường hợp một trong hai giá trị bằng 0
            }
            else if (value1 > value2)
            {
                diff = 100 * (value1 - value2) / value1;
            }
            else
            {
                diff = 100 * (value2 - value1) / value2;
            }
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
        private void EvaluateMeasurements()
        {
            if (string.IsNullOrEmpty(txtTypeCar.Text)) return;

            // Lấy dữ liệu tiêu chuẩn từ DB
            standardsTable = sqlHelper.GetVehicleStandardsByTypeCar(txtTypeCar.Text);

            if (standardsTable.Rows.Count > 0)
            {
                DataRow standard = standardsTable.Rows[0];

                foreach (var mapping in textBoxMappings)
                {
                    Control[] controls = this.Controls.Find(mapping.Key, true);
                    if (controls.Length > 0 && controls[0] is TextBox textBox)
                    {
                        decimal? minValue = mapping.Value.minField != null ? standard.Field<decimal?>(mapping.Value.minField) : null;
                        decimal? maxValue = mapping.Value.maxField != null ? standard.Field<decimal?>(mapping.Value.maxField) : null;

                        CheckAndColorTextBox(textBox, minValue, maxValue);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu tiêu chuẩn cho loại xe này.", "Thông báo");
            }
        }
        private void CheckAndColorTextBox(TextBox txtBox, decimal? minValue, decimal? maxValue)
        {
            if (decimal.TryParse(txtBox.Text, out decimal value))
            {
                // Nếu chỉ có giá trị tối thiểu
                if (minValue.HasValue && !maxValue.HasValue)
                {
                    if (value < minValue.Value)
                    {
                        txtBox.BackColor = Color.Gold; // Dưới mức chuẩn
                    }
                    else
                    {
                        txtBox.BackColor = Color.LightGreen; // Trong mức chuẩn
                    }
                }
                // Nếu chỉ có giá trị tối đa
                else if (!minValue.HasValue && maxValue.HasValue)
                {
                    if (value > maxValue.Value)
                    {
                        txtBox.BackColor = Color.Gold; // Vượt quá mức chuẩn
                    }
                    else
                    {
                        txtBox.BackColor = Color.LightGreen; // Trong mức chuẩn
                    }
                }
                // Nếu có cả giá trị tối thiểu và tối đa
                else if (minValue.HasValue && maxValue.HasValue)
                {
                    if (value < minValue.Value)
                    {
                        txtBox.BackColor = Color.Gold; // Dưới mức chuẩn
                    }
                    else if (value > maxValue.Value)
                    {
                        txtBox.BackColor = Color.Gold; // Vượt quá mức chuẩn
                    }
                    else
                    {
                        txtBox.BackColor = Color.LightGreen; // Trong mức chuẩn
                    }
                }
                // Nếu không có giá trị chuẩn (không đổi màu)
                else
                {
                    txtBox.BackColor = SystemColors.Window; // Màu nền mặc định
                }
            }
            else
            {
                txtBox.BackColor = SystemColors.Window; // Màu nền mặc định nếu giá trị không hợp lệ hoặc trống
            }
        }
        private DataTable GetVehicleReportData(string serialNumber)
        {
            // Tạo DataTable để chứa dữ liệu báo cáo
            DataTable reportDataTable = new DataTable();

            reportDataTable.Columns.Add("PublishSeri", typeof(string));
            reportDataTable.Columns.Add("PublishVer", typeof(string));
            reportDataTable.Columns.Add("PublishDate", typeof(string));
            // Thêm các cột cho báo cáo
            reportDataTable.Columns.Add("SerialNumber", typeof(string));
            reportDataTable.Columns.Add("FrameNumber", typeof(string));
            reportDataTable.Columns.Add("VehicleType", typeof(string));
            reportDataTable.Columns.Add("Inspector", typeof(string));
            reportDataTable.Columns.Add("InspectionDate", typeof(DateTime));
            reportDataTable.Columns.Add("Fuel", typeof(string));

            reportDataTable.Columns.Add("Speed", typeof(decimal));
            reportDataTable.Columns.Add("MinSpeed", typeof(decimal));
            reportDataTable.Columns.Add("MaxSpeed", typeof(decimal));

            reportDataTable.Columns.Add("SideSlip", typeof(decimal));
            reportDataTable.Columns.Add("MinSideSlip", typeof(decimal));
            reportDataTable.Columns.Add("MaxSideSlip", typeof(decimal));

            reportDataTable.Columns.Add("Noise", typeof(decimal));
            reportDataTable.Columns.Add("MaxNoise", typeof(decimal));

            reportDataTable.Columns.Add("Whistle", typeof(decimal));
            reportDataTable.Columns.Add("MinWhistle", typeof(decimal));
            reportDataTable.Columns.Add("MaxWhistle", typeof(decimal));

            reportDataTable.Columns.Add("HC", typeof(decimal));
            reportDataTable.Columns.Add("MaxHC", typeof(decimal));

            reportDataTable.Columns.Add("CO", typeof(decimal));
            reportDataTable.Columns.Add("MaxCO", typeof(decimal));

            reportDataTable.Columns.Add("CO2", typeof(decimal));
            reportDataTable.Columns.Add("MaxCO2", typeof(decimal));

            reportDataTable.Columns.Add("O2", typeof(decimal));
            reportDataTable.Columns.Add("MaxO2", typeof(decimal));

            reportDataTable.Columns.Add("NO", typeof(decimal));
            reportDataTable.Columns.Add("MaxNO", typeof(decimal));
            reportDataTable.Columns.Add("OilTemp", typeof(decimal));
            reportDataTable.Columns.Add("RPM", typeof(decimal));

            reportDataTable.Columns.Add("FrontLeftWeight", typeof(decimal));
            reportDataTable.Columns.Add("FrontRightWeight", typeof(decimal));
            reportDataTable.Columns.Add("FrontSumWeight", typeof(decimal));
            reportDataTable.Columns.Add("RearLeftWeight", typeof(decimal));
            reportDataTable.Columns.Add("RearRightWeight", typeof(decimal));
            reportDataTable.Columns.Add("RearSumWeight", typeof(decimal));

            reportDataTable.Columns.Add("FrontLeftBrake", typeof(decimal));
            reportDataTable.Columns.Add("FrontRightBrake", typeof(decimal));
            reportDataTable.Columns.Add("RearLeftBrake", typeof(decimal));
            reportDataTable.Columns.Add("RearRightBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandLeftBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandRightBrake", typeof(decimal));
            reportDataTable.Columns.Add("FrontSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinFrontBrake", typeof(decimal));
            reportDataTable.Columns.Add("RearSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinRearBrake", typeof(decimal));
            reportDataTable.Columns.Add("FrontDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffFrontBrake", typeof(decimal));
            reportDataTable.Columns.Add("RearDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffRearBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinHandBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHandBrake", typeof(decimal));

            reportDataTable.Columns.Add("LHLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("RHLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MinHLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MaxHBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("LHLVertical", typeof(decimal));
            reportDataTable.Columns.Add("RHLVertical", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffVertiHB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffVertiHB", typeof(decimal));
            reportDataTable.Columns.Add("LHLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("RHLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffHoriHB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHoriHB", typeof(decimal));
            reportDataTable.Columns.Add("LLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("RLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MinLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MaxLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("LLBVertical", typeof(decimal));
            reportDataTable.Columns.Add("RLBVertical", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffVertiLB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffVertiLB", typeof(decimal));
            reportDataTable.Columns.Add("LLBHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("RLBHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffHoriLB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHoriLB", typeof(decimal));

            reportDataTable.Columns.Add("MinSpeed1", typeof(decimal));
            reportDataTable.Columns.Add("MaxSpeed1", typeof(decimal));
            reportDataTable.Columns.Add("HSU1", typeof(decimal));
            reportDataTable.Columns.Add("MinSpeed2", typeof(decimal));
            reportDataTable.Columns.Add("MaxSpeed2", typeof(decimal));
            reportDataTable.Columns.Add("HSU2", typeof(decimal));
            reportDataTable.Columns.Add("MinSpeed3", typeof(decimal));
            reportDataTable.Columns.Add("MaxSpeed3", typeof(decimal));
            reportDataTable.Columns.Add("HSU3", typeof(decimal));
            reportDataTable.Columns.Add("AvgHSU", typeof(decimal));
            reportDataTable.Columns.Add("MaxHSU", typeof(decimal));

            reportDataTable.Columns.Add("LeftSteerLW", typeof(decimal));
            reportDataTable.Columns.Add("LeftSteerRW", typeof(decimal));
            reportDataTable.Columns.Add("MinLeftSteer", typeof(decimal));
            reportDataTable.Columns.Add("MaxLeftSteer", typeof(decimal));
            reportDataTable.Columns.Add("RightSteerLW", typeof(decimal));
            reportDataTable.Columns.Add("RightSteerRW", typeof(decimal));
            reportDataTable.Columns.Add("MinRightSteer", typeof(decimal));
            reportDataTable.Columns.Add("MaxRightSteer", typeof(decimal));

            reportDataTable.Columns.Add("MinLightHeight", typeof(decimal));

            reportDataTable.Columns.Add("SideSlipResult", typeof(bool));
            reportDataTable.Columns.Add("BrakeResult", typeof(bool));
            reportDataTable.Columns.Add("SteerAngleResult", typeof(bool));
            reportDataTable.Columns.Add("SpeedResult", typeof(bool));
            reportDataTable.Columns.Add("PetrolResult", typeof(bool));
            reportDataTable.Columns.Add("DieselResult", typeof(bool));
            reportDataTable.Columns.Add("HLResult", typeof(bool));
            reportDataTable.Columns.Add("NoiseResult", typeof(bool));
            reportDataTable.Columns.Add("WhistleResult", typeof(bool));
            reportDataTable.Columns.Add("FinalResult", typeof(bool));


            // Gọi hàm GetVehicleDetails để lấy thông tin xe theo serialNumber
            DataRow vehicleDetails = sqlHelper.GetVehicleDetails(serialNumber);

            if (vehicleDetails != null)
            {
                // Gọi hàm GetVehicleStandardsByTypeCar để lấy tiêu chuẩn theo loại xe
                string vehicleType = vehicleDetails["VehicleType"].ToString();
                DataTable vehicleStandards = sqlHelper.GetVehicleStandardsByTypeCar(vehicleType);
                DataRow standard = vehicleStandards.Rows[0];
                // Tính toán giá trị FrontSumWeight (tổng của FrontLeftWeight và FrontRightWeight)
                decimal frontLeftWeight = ConvertToDecimal(vehicleDetails["FrontLeftWeight"]);
                decimal frontRightWeight = ConvertToDecimal(vehicleDetails["FrontRightWeight"]);
                decimal frontSumWeight = frontLeftWeight + frontRightWeight;

                // Tính toán RearSumWeight (tổng của RearLeftWeight và RearRightWeight)
                decimal rearLeftWeight = ConvertToDecimal(vehicleDetails["RearLeftWeight"]);
                decimal rearRightWeight = ConvertToDecimal(vehicleDetails["RearRightWeight"]);
                decimal rearSumWeight = rearLeftWeight + rearRightWeight;

                decimal frontLeftBrake = ConvertToDecimal(vehicleDetails["FrontLeftBrake"]);
                decimal frontRightBrake = ConvertToDecimal(vehicleDetails["FrontRightBrake"]);
                decimal frontDiffBrake = ConvertToDecimal(txtFrontDiffBrake.Text);
                decimal frontSumBrake = frontLeftBrake + frontRightBrake;

                decimal rearLeftBrake = ConvertToDecimal(vehicleDetails["RearLeftBrake"]);
                decimal rearRightBrake = ConvertToDecimal(vehicleDetails["RearRightBrake"]);
                decimal rearDiffBrake = ConvertToDecimal(txtRearDiffBrake.Text);
                decimal rearSumBrake = rearLeftBrake + rearRightBrake;

                decimal handLeftBrake = ConvertToDecimal(vehicleDetails["HandBrakeLeft"]);
                decimal handRightBrake = ConvertToDecimal(vehicleDetails["HandBrakeRight"]);
                decimal handDiffBrake = ConvertToDecimal(txtHandDiffBrake.Text);
                decimal handSumBrake = handLeftBrake + handRightBrake;

                decimal hsu1 = vehicleDetails["HSU1"] != DBNull.Value ? vehicleDetails.Field<decimal>("HSU1") : 0;
                decimal hsu2 = vehicleDetails["HSU2"] != DBNull.Value ? vehicleDetails.Field<decimal>("HSU2") : 0;
                decimal hsu3 = vehicleDetails["HSU3"] != DBNull.Value ? vehicleDetails.Field<decimal>("HSU3") : 0;
                decimal avgHSU = (hsu1 + hsu2 + hsu3) / 3;

                // Tính toán kết quả cho các phần
                bool sideSlipResult = CheckStandard(ConvertToDecimal(vehicleDetails["SideSlip"]),
                                                    standard.Field<decimal?>("MinSideSlip"),
                                                    standard.Field<decimal?>("MaxSideSlip"));

                bool brakeResult = CheckStandard(frontSumBrake,
                                                 standard.Field<decimal?>("MinFrontBrake"), null)
                                   && CheckStandard(rearSumBrake,
                                                    standard.Field<decimal?>("MinRearBrake"), null)
                                   && CheckStandard(handSumBrake,
                                                    standard.Field<decimal?>("MinHandBrake"), null)
                                   && CheckStandard(frontDiffBrake, null,
                                                    standard.Field<decimal?>("MaxDiffFrontBrake"))
                                   && CheckStandard(rearDiffBrake, null,
                                                    standard.Field<decimal?>("MaxDiffRearBrake"))
                                   && CheckStandard(handDiffBrake, null,
                                                    standard.Field<decimal?>("MaxDiffHandBrake"));

                bool steerAngleResult = CheckStandard(ConvertToDecimal(vehicleDetails["LeftSteerLW"]),
                                                 standard.Field<decimal?>("MinLeftSteer"), standard.Field<decimal?>("MaxLeftSteer"))
                                    && CheckStandard(ConvertToDecimal(vehicleDetails["RightSteerLW"]),
                                                    standard.Field<decimal?>("MinRightSteer"), standard.Field<decimal?>("MaxRightSteer"));
                //&& CheckStandard(ConvertToDecimal(vehicleDetails["LeftSteerRW"]),
                //                 standard.Field<decimal?>("MinLeftSteer"), standard.Field<decimal?>("MaxLeftSteer"))
                //&& CheckStandard(ConvertToDecimal(vehicleDetails["RightSteerRW"]),
                //                 standard.Field<decimal?>("MinRightSteer"), standard.Field<decimal?>("MaxRightSteer"));

                bool speedResult = CheckStandard(ConvertToDecimal(vehicleDetails["Speed"]),
                                                 standard.Field<decimal?>("MinSpeed"),
                                                 standard.Field<decimal?>("MaxSpeed"));

                bool petrolResult = CheckStandard(ConvertToDecimal(vehicleDetails["HC"]), null,
                                                  standard.Field<decimal?>("MaxHC"))
                                    && CheckStandard(ConvertToDecimal(vehicleDetails["CO"]), null,
                                                     standard.Field<decimal?>("MaxCO"));

                bool dieselResult = CheckStandard(avgHSU, null,
                                                  standard.Field<decimal?>("MaxHSU"));

                bool hlResult = CheckStandard(ConvertToDecimal(vehicleDetails["LHLIntensity"]),
                                              standard.Field<decimal?>("MinHLIntensity"), standard.Field<decimal?>("MaxHBIntensity"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["RHLIntensity"]),
                                                 standard.Field<decimal?>("MinHLIntensity"), standard.Field<decimal?>("MaxHBIntensity"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["LHLHorizontal"]),
                                                 standard.Field<decimal?>("MinDiffHoriHB"),
                                                 standard.Field<decimal?>("MaxDiffHoriHB"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["RHLHorizontal"]),
                                                 standard.Field<decimal?>("MinDiffHoriHB"),
                                                 standard.Field<decimal?>("MaxDiffHoriHB"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["LHLVertical"]),
                                                 standard.Field<decimal?>("MinDiffVertiHB"),
                                                 standard.Field<decimal?>("MaxDiffVertiHB"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["RHLVertical"]),
                                                 standard.Field<decimal?>("MinDiffVertiHB"),
                                                 standard.Field<decimal?>("MaxDiffVertiHB"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["RLBIntensity"]),
                                                 standard.Field<decimal?>("MinLBIntensity"), standard.Field<decimal?>("MaxLBIntensity"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["LLBIntensity"]),
                                                 standard.Field<decimal?>("MinLBIntensity"), standard.Field<decimal?>("MaxLBIntensity"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["LLBHorizontal"]),
                                                 standard.Field<decimal?>("MinDiffHoriLB"),
                                                 standard.Field<decimal?>("MaxDiffHoriLB"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["RLBHorizontal"]),
                                                 standard.Field<decimal?>("MinDiffHoriLB"),
                                                 standard.Field<decimal?>("MaxDiffHoriLB"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["LLBVertical"]),
                                                 standard.Field<decimal?>("MinDiffVertiLB"),
                                                 standard.Field<decimal?>("MaxDiffVertiLB"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["RLBVertical"]),
                                                 standard.Field<decimal?>("MinDiffVertiLB"),
                                                 standard.Field<decimal?>("MaxDiffVertiLB"));

                bool noiseResult = CheckStandard(ConvertToDecimal(vehicleDetails["Noise"]), null,
                                                 standard.Field<decimal?>("MaxNoise"));

                bool whistleResult = CheckStandard(ConvertToDecimal(vehicleDetails["Whistle"]),
                                                   standard.Field<decimal?>("MinWhistle"),
                                                   standard.Field<decimal?>("MaxWhistle"));

                // Tính toán kết quả cuối cùng
                string engineType = vehicleDetails["Fuel"].ToString();
                bool engineResult = (engineType == "Xăng") ? petrolResult :
                                    (engineType == "Dầu") ? dieselResult : false;

                bool finalResult = sideSlipResult && brakeResult && speedResult && steerAngleResult &&
                                   engineResult && hlResult && noiseResult && whistleResult;

                // Thêm dữ liệu vào DataTable
                DataRow reportRow = reportDataTable.NewRow();

                reportRow["PublishSeri"] = ConfigurationManager.AppSettings["PublishSeri"];
                reportRow["PublishVer"] = ConfigurationManager.AppSettings["PublishVer"];
                reportRow["PublishDate"] = ConfigurationManager.AppSettings["PublishDate"];

                reportRow["SerialNumber"] = vehicleDetails["SerialNumber"].ToString();
                reportRow["FrameNumber"] = vehicleDetails["FrameNumber"].ToString();
                reportRow["VehicleType"] = vehicleDetails["VehicleType"].ToString();
                reportRow["Inspector"] = vehicleDetails["Inspector"].ToString();
                reportRow["InspectionDate"] = Convert.ToDateTime(vehicleDetails["InspectionDate"]).ToShortDateString();
                reportRow["Fuel"] = vehicleDetails["Fuel"].ToString();

                reportRow["Speed"] = ConvertToDecimal(vehicleDetails["Speed"]).ToString("F1");
                reportRow["MinSpeed"] = ConvertToDecimal(standard["MinSpeed"]).ToString("F1");
                reportRow["MaxSpeed"] = ConvertToDecimal(standard["MaxSpeed"]).ToString("F1");

                reportRow["SideSlip"] = ConvertToDecimal(vehicleDetails["SideSlip"]).ToString("F1");
                reportRow["MinSideSlip"] = ConvertToDecimal(standard["MinSideSlip"]).ToString("F1");
                reportRow["MaxSideSlip"] = ConvertToDecimal(standard["MaxSideSlip"]).ToString("F1");

                reportRow["Noise"] = ConvertToDecimal(vehicleDetails["Noise"]).ToString("F1");
                reportRow["MaxNoise"] = ConvertToDecimal(standard["MaxNoise"]).ToString("F1");
                reportRow["Whistle"] = ConvertToDecimal(vehicleDetails["Whistle"]).ToString("F1");
                reportRow["MinWhistle"] = ConvertToDecimal(standard["MinWhistle"]).ToString("F1");
                reportRow["MaxWhistle"] = ConvertToDecimal(standard["MaxWhistle"]).ToString("F1");

                reportRow["HC"] = ConvertToDecimal(vehicleDetails["HC"]).ToString("F1");
                reportRow["MaxHC"] = ConvertToDecimal(standard["MaxHC"]).ToString("F1");
                reportRow["CO"] = ConvertToDecimal(vehicleDetails["CO"]).ToString("F2");
                reportRow["MaxCO"] = ConvertToDecimal(standard["MaxCO"]).ToString("F2");
                reportRow["CO2"] = ConvertToDecimal(vehicleDetails["CO2"]).ToString("F2");
                reportRow["MaxCO2"] = ConvertToDecimal(standard["MaxCO2"]).ToString("F2");
                reportRow["O2"] = ConvertToDecimal(vehicleDetails["O2"]).ToString("F2");
                reportRow["MaxO2"] = ConvertToDecimal(standard["MaxO2"]).ToString("F2");
                reportRow["NO"] = ConvertToDecimal(vehicleDetails["NO"]).ToString("F2");
                reportRow["MaxNO"] = ConvertToDecimal(standard["MaxNO"]).ToString("F2");
                reportRow["OilTemp"] = ConvertToDecimal(vehicleDetails["OilTemp"]).ToString("F1");
                reportRow["RPM"] = ConvertToDecimal(vehicleDetails["RPM"]).ToString("F1");

                reportRow["FrontLeftWeight"] = frontLeftWeight.ToString("F1");
                reportRow["FrontRightWeight"] = frontRightWeight.ToString("F1");
                reportRow["FrontSumWeight"] = frontSumWeight.ToString("F1");
                reportRow["RearLeftWeight"] = rearLeftWeight.ToString("F1");
                reportRow["RearRightWeight"] = rearRightWeight.ToString("F1");
                reportRow["RearSumWeight"] = rearSumWeight.ToString("F1");

                reportRow["FrontLeftBrake"] = frontLeftBrake.ToString("F1");
                reportRow["FrontRightBrake"] = frontRightBrake.ToString("F1");
                reportRow["FrontDiffBrake"] = frontDiffBrake.ToString("F1");
                reportRow["MaxDiffFrontBrake"] = ConvertToDecimal(standard["MaxDiffFrontBrake"]).ToString("F1");
                reportRow["FrontSumBrake"] = frontSumBrake.ToString("F1");
                reportRow["MinFrontBrake"] = ConvertToDecimal(standard["MinFrontBrake"]).ToString("F1");
                reportRow["RearLeftBrake"] = rearLeftBrake.ToString("F1");
                reportRow["RearRightBrake"] = rearRightBrake.ToString("F1");
                reportRow["RearDiffBrake"] = rearDiffBrake.ToString("F1");
                reportRow["MaxDiffRearBrake"] = ConvertToDecimal(standard["MaxDiffRearBrake"]).ToString("F1");
                reportRow["RearSumBrake"] = rearSumBrake.ToString("F1");
                reportRow["MinRearBrake"] = ConvertToDecimal(standard["MinRearBrake"]).ToString("F1");
                reportRow["HandLeftBrake"] = handLeftBrake.ToString("F1");
                reportRow["HandRightBrake"] = handRightBrake.ToString("F1");
                reportRow["HandDiffBrake"] = handDiffBrake.ToString("F1");
                reportRow["MaxDiffHandBrake"] = ConvertToDecimal(standard["MaxDiffHandBrake"]).ToString("F1");
                reportRow["HandSumBrake"] = handSumBrake.ToString("F1");
                reportRow["MinHandBrake"] = ConvertToDecimal(standard["MinHandBrake"]).ToString("F1");

                reportRow["LHLIntensity"] = ConvertToDecimal(vehicleDetails["LHLIntensity"]).ToString("F0");
                reportRow["RHLIntensity"] = ConvertToDecimal(vehicleDetails["RHLIntensity"]).ToString("F0");
                reportRow["MinHLIntensity"] = ConvertToDecimal(standard["MinHLIntensity"]).ToString("F0");
                reportRow["MaxHBIntensity"] = ConvertToDecimal(standard["MaxHBIntensity"]).ToString("F0");
                reportRow["LHLVertical"] = ConvertToDecimal(vehicleDetails["LHLVertical"]).ToString("F1");
                reportRow["RHLVertical"] = ConvertToDecimal(vehicleDetails["RHLVertical"]).ToString("F1");
                reportRow["MinDiffVertiHB"] = ConvertToDecimal(standard["MinDiffVertiHB"]).ToString("F1");
                reportRow["MaxDiffVertiHB"] = ConvertToDecimal(standard["MaxDiffVertiHB"]).ToString("F1");
                reportRow["LHLHorizontal"] = ConvertToDecimal(vehicleDetails["LHLHorizontal"]).ToString("F1");
                reportRow["RHLHorizontal"] = ConvertToDecimal(vehicleDetails["RHLHorizontal"]).ToString("F1");
                reportRow["MinDiffHoriHB"] = ConvertToDecimal(standard["MinDiffHoriHB"]).ToString("F1");
                reportRow["MaxDiffHoriHB"] = ConvertToDecimal(standard["MaxDiffHoriHB"]).ToString("F1");

                reportRow["LLBIntensity"] = ConvertToDecimal(vehicleDetails["LLBIntensity"]).ToString("F0");
                reportRow["RLBIntensity"] = ConvertToDecimal(vehicleDetails["RLBIntensity"]).ToString("F0");
                reportRow["MinLBIntensity"] = ConvertToDecimal(standard["MinLBIntensity"]).ToString("F0");
                reportRow["MaxLBIntensity"] = ConvertToDecimal(standard["MaxLBIntensity"]).ToString("F0");
                reportRow["LLBVertical"] = ConvertToDecimal(vehicleDetails["LLBVertical"]).ToString("F1");
                reportRow["RLBVertical"] = ConvertToDecimal(vehicleDetails["RLBVertical"]).ToString("F1");
                reportRow["MinDiffVertiLB"] = ConvertToDecimal(standard["MinDiffVertiLB"]).ToString("F1");
                reportRow["MaxDiffVertiLB"] = ConvertToDecimal(standard["MaxDiffVertiLB"]).ToString("F1");
                reportRow["LLBHorizontal"] = ConvertToDecimal(vehicleDetails["LLBHorizontal"]).ToString("F1");
                reportRow["RLBHorizontal"] = ConvertToDecimal(vehicleDetails["RLBHorizontal"]).ToString("F1");
                reportRow["MinDiffHoriLB"] = ConvertToDecimal(standard["MinDiffHoriLB"]).ToString("F1");
                reportRow["MaxDiffHoriLB"] = ConvertToDecimal(standard["MaxDiffHoriLB"]).ToString("F1");

                reportRow["MinSpeed1"] = ConvertToDecimal(vehicleDetails["MinSpeed1"]).ToString("F0");
                reportRow["MaxSpeed1"] = ConvertToDecimal(vehicleDetails["MaxSpeed1"]).ToString("F0");
                reportRow["HSU1"] = ConvertToDecimal(hsu1).ToString("F2");
                reportRow["MinSpeed2"] = ConvertToDecimal(vehicleDetails["MinSpeed2"]).ToString("F0");
                reportRow["MaxSpeed2"] = ConvertToDecimal(vehicleDetails["MaxSpeed2"]).ToString("F0");
                reportRow["HSU2"] = ConvertToDecimal(hsu2).ToString("F2");
                reportRow["MinSpeed3"] = ConvertToDecimal(vehicleDetails["MinSpeed3"]).ToString("F0");
                reportRow["MaxSpeed3"] = ConvertToDecimal(vehicleDetails["MaxSpeed3"]).ToString("F0");
                reportRow["HSU3"] = ConvertToDecimal(hsu3).ToString("F2");
                reportRow["AvgHSU"] = ConvertToDecimal(avgHSU).ToString("F2");
                reportRow["MaxHSU"] = ConvertToDecimal(standard["MaxHSU"]).ToString("F2");

                reportRow["LeftSteerLW"] = ConvertToDecimal(vehicleDetails["LeftSteerLW"]).ToString("F1");
                reportRow["LeftSteerRW"] = ConvertToDecimal(vehicleDetails["LeftSteerRW"]).ToString("F1");
                reportRow["MinLeftSteer"] = ConvertToDecimal(standard["MinLeftSteer"]).ToString("F1");
                reportRow["MaxLeftSteer"] = ConvertToDecimal(standard["MaxLeftSteer"]).ToString("F1");
                reportRow["RightSteerLW"] = ConvertToDecimal(vehicleDetails["RightSteerLW"]).ToString("F1");
                reportRow["RightSteerRW"] = ConvertToDecimal(vehicleDetails["RightSteerRW"]).ToString("F1");
                reportRow["MinRightSteer"] = ConvertToDecimal(standard["MinRightSteer"]).ToString("F1");
                reportRow["MaxRightSteer"] = ConvertToDecimal(standard["MaxRightSteer"]).ToString("F1");

                reportRow["MinLightHeight"] = ConvertToDecimal(standard["MinLightHeight"]).ToString("F1");

                reportRow["SideSlipResult"] = sideSlipResult;
                reportRow["BrakeResult"] = brakeResult;
                reportRow["SteerAngleResult"] = steerAngleResult;
                reportRow["SpeedResult"] = speedResult;
                reportRow["PetrolResult"] = petrolResult;
                reportRow["DieselResult"] = dieselResult;
                reportRow["HLResult"] = hlResult;
                reportRow["NoiseResult"] = noiseResult;
                reportRow["WhistleResult"] = whistleResult;
                reportRow["FinalResult"] = finalResult;

                reportDataTable.Rows.Add(reportRow);
            }

            return reportDataTable;
        }
        private bool CheckStandard(decimal? value, decimal? minValue, decimal? maxValue)
        {
            if (!value.HasValue)
                return true; // Nếu không có giá trị cần kiểm tra, mặc định đạt

            if (minValue.HasValue && value < minValue.Value)
                return false;

            if (maxValue.HasValue && value > maxValue.Value)
                return false;

            return true;
        }
        private decimal ConvertToDecimal(object value, decimal defaultValue = 0)
        {
            if (value != DBNull.Value && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                return Convert.ToDecimal(value);
            }
            return defaultValue;
        }
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            string serialNumber = txtSerialNum.Text; // Lấy số serial từ TextBox
            DataTable reportDataList = GetVehicleReportData(serialNumber);
            TestReport exportReportForm = new TestReport(reportDataList);
            exportReportForm.ShowDialog();
        }

        private decimal? GetDecimalFromTextBox(TextBox textBox)
        {
            if (decimal.TryParse(textBox.Text, out decimal value))
            {
                return value;
            }
            return null; // Trả về null nếu không có giá trị
        }
        private void btnEditSave_Click(object sender, EventArgs e)
        {
            if (btnEditSave.Text == "Chỉnh sửa") // Nếu nút đang ở chế độ Edit
            {
                EnableTextBoxes(true); // Cho phép chỉnh sửa
                btnEditSave.Text = "Lưu"; // Đổi thành nút Lưu
            }
            else if (btnEditSave.Text == "Lưu") // Nếu nút đang ở chế độ Save
            {
                try
                {
                    // Lấy dữ liệu từ các TextBox
                    string serialNumber = txtSerialNum.Text;

                    decimal? speed = GetDecimalFromTextBox(txtSpeed);
                    decimal? sideSlip = GetDecimalFromTextBox(txtSideSlip);
                    decimal? frontLeftWeight = GetDecimalFromTextBox(txtFrontLeftWeight);
                    decimal? frontRightWeight = GetDecimalFromTextBox(txtFrontRightWeight);
                    decimal? rearLeftWeight = GetDecimalFromTextBox(txtRearLeftWeight);
                    decimal? rearRightWeight = GetDecimalFromTextBox(txtRearRightWeight);
                    decimal? frontLeftBrake = GetDecimalFromTextBox(txtFrontLeftBrake);
                    decimal? frontRightBrake = GetDecimalFromTextBox(txtFrontRightBrake);
                    decimal? rearLeftBrake = GetDecimalFromTextBox(txtRearLeftBrake);
                    decimal? rearRightBrake = GetDecimalFromTextBox(txtRearRightBrake);
                    decimal? handBrakeLeft = GetDecimalFromTextBox(txtHandLeftBrake);
                    decimal? handBrakeRight = GetDecimalFromTextBox(txtHandRightBrake);
                    decimal? noise = GetDecimalFromTextBox(txtNoise);
                    decimal? whistle = GetDecimalFromTextBox(txtWhistle);
                    decimal? lhlIntensity = GetDecimalFromTextBox(txtLHLIntensity);
                    decimal? lhlVertical = GetDecimalFromTextBox(txtLHLVertical);
                    decimal? lhlHorizontal = GetDecimalFromTextBox(txtLHLHorizontal);
                    decimal? rhlIntensity = GetDecimalFromTextBox(txtRHLIntensity);
                    decimal? rhlVertical = GetDecimalFromTextBox(txtRHLVertical);
                    decimal? rhlHorizontal = GetDecimalFromTextBox(txtRHLHorizontal);
                    decimal? llbIntensity = GetDecimalFromTextBox(txtLLBIntensity);
                    decimal? llbVertical = GetDecimalFromTextBox(txtLLBVertical);
                    decimal? llbHorizontal = GetDecimalFromTextBox(txtLLBHorizontal);
                    decimal? rlbIntensity = GetDecimalFromTextBox(txtRLBIntensity);
                    decimal? rlbVertical = GetDecimalFromTextBox(txtRLBVertical);
                    decimal? rlbHorizontal = GetDecimalFromTextBox(txtRLBHorizontal);
                    decimal? hc = GetDecimalFromTextBox(txtHC);
                    decimal? co = GetDecimalFromTextBox(txtCO);
                    decimal? co2 = GetDecimalFromTextBox(txtCO2);
                    decimal? o2 = GetDecimalFromTextBox(txtO2);
                    decimal? no = GetDecimalFromTextBox(txtNO);
                    decimal? oilTemp = GetDecimalFromTextBox(txtOT);
                    decimal? rpm = GetDecimalFromTextBox(txtRPM);
                    decimal? minSpeed1 = GetDecimalFromTextBox(txtMinSpeed1);
                    decimal? maxSpeed1 = GetDecimalFromTextBox(txtMaxSpeed1);
                    decimal? hsu1 = GetDecimalFromTextBox(txtHSU1);
                    decimal? minSpeed2 = GetDecimalFromTextBox(txtMinSpeed2);
                    decimal? maxSpeed2 = GetDecimalFromTextBox(txtMaxSpeed2);
                    decimal? hsu2 = GetDecimalFromTextBox(txtHSU2);
                    decimal? minSpeed3 = GetDecimalFromTextBox(txtMinSpeed3);
                    decimal? maxSpeed3 = GetDecimalFromTextBox(txtMaxSpeed3);
                    decimal? hsu3 = GetDecimalFromTextBox(txtHSU3);
                    decimal? leftSteerLW = GetDecimalFromTextBox(txtLeftSteerLW);
                    decimal? leftSteerRW = GetDecimalFromTextBox(txtLeftSteerRW);
                    decimal? rightSteerLW = GetDecimalFromTextBox(txtRightSteerLW);
                    decimal? rightSteerRW = GetDecimalFromTextBox(txtRightSteerRW);

                    // Thực hiện cập nhật từng bảng trong cơ sở dữ liệu
                    sqlHelper.UpdateSpeed(serialNumber, speed);
                    sqlHelper.UpdateSideSlip(serialNumber, sideSlip);
                    sqlHelper.UpdateWeight(serialNumber, frontLeftWeight, frontRightWeight, rearLeftWeight, rearRightWeight);
                    sqlHelper.UpdateSteerAngle(serialNumber, leftSteerLW, leftSteerRW, rightSteerLW, rightSteerRW);
                    sqlHelper.UpdateBrakeForce(serialNumber, frontLeftBrake, frontRightBrake, rearLeftBrake, rearRightBrake, handBrakeLeft, handBrakeRight);
                    sqlHelper.UpdateNoise(serialNumber, noise, whistle);
                    sqlHelper.UpdateHeadlights(serialNumber, lhlIntensity, lhlVertical, lhlHorizontal, rhlIntensity, rhlVertical, rhlHorizontal, llbIntensity, llbVertical, llbHorizontal, rlbIntensity, rlbVertical, rlbHorizontal);
                    sqlHelper.UpdateGasEmissionPetrol(serialNumber, hc, co, co2, o2, no, oilTemp, rpm);
                    sqlHelper.UpdateGasEmissionDiesel(serialNumber, minSpeed1, maxSpeed1, hsu1, minSpeed2, maxSpeed2, hsu2, minSpeed3, maxSpeed3, hsu3);

                    MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEditSave.Text = "Chỉnh sửa";
                    //btnEditSave.Visible = false;
                    EnableTextBoxes(false); // Tắt chỉnh sửa TextBox sau khi lưu thành công
                    DisplayVehicleDetails(serialNumber);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Giữ dữ liệu cũ trên form mà không thay đổi
                    DisplayVehicleDetails(txtSerialNum.Text); // Reload lại dữ liệu cũ từ cơ sở dữ liệu
                }
            }
        }
        private void EnableTextBoxes(bool enable)
        {
            // Danh sách các TextBox được phép chỉnh sửa
            List<TextBox> editableTextBoxes = new List<TextBox>
            {
                txtSpeed, txtSideSlip, txtNoise, txtWhistle, txtHC, txtCO, txtCO2, txtO2, txtNO, txtOT, txtRPM,
                txtFrontLeftWeight, txtFrontRightWeight, txtRearLeftWeight, txtRearRightWeight,
                txtLeftSteerLW, txtLeftSteerRW, txtRightSteerLW, txtRightSteerRW,
                txtFrontLeftBrake, txtFrontRightBrake, txtRearLeftBrake, txtRearRightBrake,
                txtHandLeftBrake, txtHandRightBrake,
                txtLHLIntensity, txtLHLVertical, txtLHLHorizontal,
                txtRHLIntensity, txtRHLVertical, txtRHLHorizontal,
                txtLLBIntensity, txtLLBVertical, txtLLBHorizontal,
                txtRLBIntensity, txtRLBVertical, txtRLBHorizontal,
                txtMinSpeed1, txtMaxSpeed1, txtMinSpeed2, txtMaxSpeed2,
                txtMinSpeed3, txtMaxSpeed3, txtHSU1, txtHSU2, txtHSU3
            };

            foreach (TextBox txtBox in editableTextBoxes)
            {
                txtBox.ReadOnly = !enable;

                if (enable)
                {
                    txtBox.TextChanged += TextBox_TextChanged; // Gán sự kiện tự động
                }
                else
                {
                    txtBox.TextChanged -= TextBox_TextChanged; // Xóa sự kiện khi tắt chỉnh sửa
                }
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txtBox && !string.IsNullOrEmpty(txtTypeCar.Text))
            {
                // Lấy dữ liệu tiêu chuẩn từ DB nếu chưa có
                if (standardsTable == null || standardsTable.Rows.Count == 0)
                {
                    standardsTable = sqlHelper.GetVehicleStandardsByTypeCar(txtTypeCar.Text);
                }

                // Logic xử lý riêng cho weight
                if (txtBox == txtFrontLeftWeight || txtBox == txtFrontRightWeight)
                {
                    if (!string.IsNullOrWhiteSpace(txtFrontLeftWeight.Text) && !string.IsNullOrWhiteSpace(txtFrontRightWeight.Text))
                        CalculateAndDisplaySum(txtFrontLeftWeight, txtFrontRightWeight, txtFrontSumWeight);
                }
                else if (txtBox == txtRearLeftWeight || txtBox == txtRearRightWeight)
                {
                    if (!string.IsNullOrWhiteSpace(txtRearLeftWeight.Text) && !string.IsNullOrWhiteSpace(txtRearRightWeight.Text))
                        CalculateAndDisplaySum(txtRearLeftWeight, txtRearRightWeight, txtRearSumWeight);
                }

                // Logic xử lý riêng cho brake
                else if (txtBox == txtFrontLeftBrake || txtBox == txtFrontRightBrake)
                {
                    if (!string.IsNullOrWhiteSpace(txtFrontLeftBrake.Text) && !string.IsNullOrWhiteSpace(txtFrontRightBrake.Text))
                    {
                        CalculateAndDisplaySum(txtFrontLeftBrake, txtFrontRightBrake, txtFrontSumBrake);
                        CalculateAndDisplayDiff(txtFrontLeftBrake, txtFrontRightBrake, txtFrontDiffBrake);
                        CheckStandard(txtFrontSumBrake);
                        CheckStandard(txtFrontDiffBrake);
                    }
                }
                else if (txtBox == txtRearLeftBrake || txtBox == txtRearRightBrake)
                {
                    if (!string.IsNullOrWhiteSpace(txtRearLeftBrake.Text) && !string.IsNullOrWhiteSpace(txtRearRightBrake.Text))
                    {
                        CalculateAndDisplaySum(txtRearLeftBrake, txtRearRightBrake, txtRearSumBrake);
                        CalculateAndDisplayDiff(txtRearLeftBrake, txtRearRightBrake, txtRearDiffBrake);
                        CheckStandard(txtRearSumBrake);
                        CheckStandard(txtRearDiffBrake);
                    }
                }
                else if (txtBox == txtHandLeftBrake || txtBox == txtHandRightBrake)
                {
                    if (!string.IsNullOrWhiteSpace(txtHandLeftBrake.Text) && !string.IsNullOrWhiteSpace(txtHandRightBrake.Text))
                    {
                        CalculateAndDisplaySum(txtHandLeftBrake, txtHandRightBrake, txtHandSumBrake);
                        CalculateAndDisplayDiff(txtHandLeftBrake, txtHandRightBrake, txtHandDiffBrake);
                        CheckStandard(txtHandSumBrake);
                        CheckStandard(txtHandDiffBrake);
                    }
                }
                else
                {
                    // Kiểm tra bình thường với các TextBox còn lại
                    if (standardsTable.Rows.Count > 0 && textBoxMappings.TryGetValue(txtBox.Name, out var mapping))
                    {
                        DataRow standard = standardsTable.Rows[0];
                        decimal? minValue = mapping.minField != null ? standard.Field<decimal?>(mapping.minField) : null;
                        decimal? maxValue = mapping.maxField != null ? standard.Field<decimal?>(mapping.maxField) : null;

                        CheckAndColorTextBox(txtBox, minValue, maxValue);
                    }
                }
            }
        }
        private void CheckStandard(TextBox txtBox)
        {
            if (textBoxMappings.TryGetValue(txtBox.Name, out var mapping) && standardsTable != null && standardsTable.Rows.Count > 0)
            {
                DataRow standard = standardsTable.Rows[0];
                decimal? minValue = mapping.minField != null ? standard.Field<decimal?>(mapping.minField) : null;
                decimal? maxValue = mapping.maxField != null ? standard.Field<decimal?>(mapping.maxField) : null;

                CheckAndColorTextBox(txtBox, minValue, maxValue);
            }
        }
        public void EnableEditButton()
        {
            btnEditSave.Visible = true; // Hiển thị nút "Chỉnh sửa"
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            btnEditSave.Visible = false; // Ẩn nút "Chỉnh sửa" khi mở form
        }

        private async void btnSaveMMS_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy VIN từ txtSerialNum
                string vin = txtSerialNum.Text.Trim();
                if (string.IsNullOrEmpty(vin))
                {
                    MessageBox.Show("VIN không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin xe từ cơ sở dữ liệu
                DataRow vehicleDetails = sqlHelper.GetVehicleDetails(vin);
                if (vehicleDetails == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Tạo danh sách testDetails
                var testDetails = BuildTestDetails(vehicleDetails);

                // Tổng hợp dữ liệu gửi MMS
                string inspectionDate = vehicleDetails["InspectionDate"].ToString();
                var dataToSend = new
                {
                    VIN = vin,
                    TestRptDTime = inspectionDate,
                    TestResult = EvaluateTestResult().ToString(),
                    ListQC_TestReportDtl = testDetails
                };

                // Chuỗi JSON để gửi lên MMS
                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dataToSend);

                // Lấy sessionid từ MMS
                string apiLoginUrl = ConfigurationManager.AppSettings["ApiLoginUrl"];
                string username = ConfigurationManager.AppSettings["UsernameMMS"];
                string password = ConfigurationManager.AppSettings["PasswordMMS"];
                string sessionId = await GetSessionIdFromMMS(apiLoginUrl, username, password);
                if (string.IsNullOrEmpty(sessionId))
                {
                    MessageBox.Show("Không lấy được session key từ MMS.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gửi dữ liệu lên MMS
                string apiSaveUrl = ConfigurationManager.AppSettings["ApiSaveUrl"];
                bool isSaved = await SaveDataToMMS(apiSaveUrl, sessionId, jsonData);
                if (isSaved)
                {
                    MessageBox.Show("Lưu dữ liệu thành công lên MMS.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu dữ liệu thất bại lên MMS.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int EvaluateTestResult()
        {
            // Danh sách các TextBox cần kiểm tra
            List<TextBox> textBoxes = new List<TextBox>
            {
                txtSpeed, txtSideSlip, txtNoise, txtWhistle,
                txtHC, txtCO, txtFrontSumBrake, txtRearSumBrake, txtHandSumBrake,
                txtFrontDiffBrake, txtRearDiffBrake, txtHandDiffBrake, txtHSU1, txtHSU2, txtHSU3
            };
            // Kiểm tra tất cả các TextBox có nền màu xanh lá không
            bool allGreen = textBoxes.All(tb => tb.BackColor != Color.Gold);

            return allGreen ? 1 : 0;
        }
        // Hàm tạo danh sách testDetails (tùy chỉnh được nội dung)
        private List<object> BuildTestDetails(DataRow vehicleDetails)
        {
            string vehicleType = vehicleDetails["VehicleType"].ToString();
            DataTable vehicleStandards = sqlHelper.GetVehicleStandardsByTypeCar(vehicleType);
            if (vehicleStandards == null || vehicleStandards.Rows.Count == 0)
            {
                throw new Exception("Không tìm thấy tiêu chuẩn kiểm tra cho loại xe.");
            }

            DataRow standard = vehicleStandards.Rows[0];
            List<object> testDetails = new List<object>();
            void AddIfEnabled(string key, object testDetail)
            {
                if (ConfigurationManager.AppSettings[key] == "true")
                {
                    testDetails.Add(testDetail);
                }
            }
            decimal speed = ConvertToDecimal(vehicleDetails["Speed"]);
            decimal minSpeed = ConvertToDecimal(standard["MinSpeed"]);
            decimal maxSpeed = ConvertToDecimal(standard["MaxSpeed"]);
            string speedTestResult = (speed >= minSpeed && speed <= maxSpeed) ? "1" : "0";
            AddIfEnabled("SpeedMMS", new
            {
                TestTypeCode = "SPEED",
                TestDtlCode = "SPEED_S",
                MeasureValue = speed.ToString("F1"),
                StandardValue = $"{minSpeed} - {maxSpeed}",
                TestDtlResult = speedTestResult
            });

            // Giá trị SideSlip
            decimal sideSlipMeasure = ConvertToDecimal(vehicleDetails["SideSlip"]);
            decimal minSideSlip = ConvertToDecimal(standard["MinSideSlip"]);
            decimal maxSideSlip = ConvertToDecimal(standard["MaxSideSlip"]);
            string sideSlipTestResult = (sideSlipMeasure >= minSideSlip && sideSlipMeasure <= maxSideSlip) ? "1" : "0";
            AddIfEnabled("SideSlipMMS", new
            {
                TestTypeCode = "SIDESLIP",
                TestDtlCode = "SIDESLIP_F",
                MeasureValue = sideSlipMeasure.ToString("F1"),
                StandardValue = $"{minSideSlip} - {maxSideSlip}",
                TestDtlResult = sideSlipTestResult
            });

            decimal whistle = ConvertToDecimal(vehicleDetails["Whistle"]);
            decimal minWhistle = ConvertToDecimal(standard["MinWhistle"]);
            decimal maxWhistle = ConvertToDecimal(standard["MaxWhistle"]);
            string whistleTestResult = (whistle >= minWhistle && whistle <= maxWhistle) ? "1" : "0";
            AddIfEnabled("WhistleMMS", new
            {
                TestTypeCode = "HORNLOADNESS",
                TestDtlCode = "HORNLOADNESS_H",
                MeasureValue = whistle.ToString("F1"),
                LimitValue = $"{minWhistle} - {maxWhistle}",
                TestDtlResult = whistleTestResult
            });

            decimal noiseMeasure = ConvertToDecimal(vehicleDetails["Noise"]);
            decimal maxNoise = ConvertToDecimal(standard["MaxNoise"]);
            string noiseTestResult = (noiseMeasure <= maxNoise) ? "1" : "0";
            AddIfEnabled("NoiseMMS", new
            {
                TestTypeCode = "SOUND",
                TestDtlCode = "SOUND_S",
                MeasureValue = noiseMeasure.ToString("F1"),
                LimitValue = maxNoise.ToString("F1"),
                TestDtlResult = noiseTestResult
            });


            // Giá trị Brake Force
            decimal frontLeftBrake = ConvertToDecimal(vehicleDetails["FrontLeftBrake"]);
            decimal frontRightBrake = ConvertToDecimal(vehicleDetails["FrontRightBrake"]);
            decimal frontDiffBrake = ConvertToDecimal(txtFrontDiffBrake.Text);
            decimal maxDiffFrontBrake = ConvertToDecimal(standard["MaxDiffFrontBrake"]);
            decimal frontSumBrake = frontLeftBrake + frontRightBrake;
            decimal minFrontBrake = ConvertToDecimal(standard["MinFrontBrake"]);
            decimal frontWeight = ConvertToDecimal(standard["FrontWeight"]);
            decimal frontEfficiencyBrake = (frontWeight > 0) ? (frontSumBrake / frontWeight) * 100 : 0;
            string frontBrakeResult = "0";
            if (txtFrontSumBrake.BackColor == Color.LightGreen && txtFrontDiffBrake.BackColor == Color.LightGreen)
                frontBrakeResult = "1";
            else
                frontBrakeResult = "0";
            AddIfEnabled("BrakeMMS", new
            {
                TestTypeCode = "BRAKEFORCE",
                TestDtlCode = "BRAKEFORCE_F",
                LeftValue = frontLeftBrake.ToString("F1"),
                RightValue = frontRightBrake.ToString("F1"),
                DifferentValue = frontDiffBrake.ToString("F1"),
                LimitValue = maxDiffFrontBrake.ToString("F1"),
                TotalValue = frontSumBrake.ToString("F1"),
                TotalLimitValue = minFrontBrake.ToString("F1"),
                BrakeEfficiencyValue = frontEfficiencyBrake.ToString("F1"),
                TestDtlResult = frontBrakeResult
            });

            decimal rearLeftBrake = ConvertToDecimal(vehicleDetails["RearLeftBrake"]);
            decimal rearRightBrake = ConvertToDecimal(vehicleDetails["RearRightBrake"]);
            decimal rearDiffBrake = ConvertToDecimal(txtRearDiffBrake.Text);
            decimal maxDiffRearBrake = ConvertToDecimal(standard["MaxDiffRearBrake"]);
            decimal rearSumBrake = rearLeftBrake + rearRightBrake;
            decimal minRearBrake = ConvertToDecimal(standard["MinRearBrake"]);
            decimal rearWeight = ConvertToDecimal(standard["RearWeight"]);
            decimal rearEfficiencyBrake = (rearWeight > 0) ? (rearSumBrake / rearWeight) * 100 : 0;
            string rearBrakeResult = "0";
            if (txtRearSumBrake.BackColor == Color.LightGreen && txtRearDiffBrake.BackColor == Color.LightGreen)
                rearBrakeResult = "1";
            else
                rearBrakeResult = "0";
            AddIfEnabled("BrakeMMS", new
            {
                TestTypeCode = "BRAKEFORCE",
                TestDtlCode = "BRAKEFORCE_R",
                LeftValue = rearLeftBrake.ToString("F1"),
                RightValue = rearRightBrake.ToString("F1"),
                DifferentValue = rearDiffBrake.ToString("F1"),
                LimitValue = maxDiffRearBrake.ToString("F1"),
                TotalValue = rearSumBrake.ToString("F1"),
                TotalLimitValue = minRearBrake.ToString("F1"),
                BrakeEfficiencyValue = rearEfficiencyBrake.ToString("F1"),
                TestDtlResult = rearBrakeResult
            });

            decimal mainSumBrake = frontSumBrake + rearSumBrake;
            decimal minMainSum = minFrontBrake + minRearBrake;
            decimal mainWeight = frontWeight + rearWeight;
            decimal mainEfficiencyBrake = (mainWeight > 0) ? (mainSumBrake / mainWeight) * 100 : 0;
            string mainBrakeResult = "0";
            if (frontBrakeResult == "1" && rearBrakeResult == "1")
                mainBrakeResult = "1";
            else
                mainBrakeResult = "0";
            AddIfEnabled("BrakeMMS", new
            {
                TestTypeCode = "BRAKEFORCE",
                TestDtlCode = "BRAKEFORCE_M",
                TotalValue = mainSumBrake.ToString("F1"),
                TotalLimitValue = minMainSum.ToString("F1"),
                BrakeEfficiencyValue = mainEfficiencyBrake.ToString("F1"),
                TestDtlResult = mainBrakeResult
            });

            decimal handLeftBrake = ConvertToDecimal(vehicleDetails["HandBrakeLeft"]);
            decimal handRightBrake = ConvertToDecimal(vehicleDetails["HandBrakeRight"]);
            decimal handDiffBrake = ConvertToDecimal(txtHandDiffBrake.Text);
            decimal handSumBrake = handLeftBrake + handRightBrake;
            decimal minHandBrake = ConvertToDecimal(standard["MinHandBrake"]);
            string handBrakeResult = "0";
            if (txtHandSumBrake.BackColor == Color.LightGreen && txtHandDiffBrake.BackColor == Color.LightGreen)
                handBrakeResult = "1";
            else
                handBrakeResult = "0";
            AddIfEnabled("BrakeMMS", new
            {
                TestTypeCode = "BRAKEFORCE",
                TestDtlCode = "BRAKEFORCE_H",
                LeftValue = handLeftBrake.ToString("F1"),
                RightValue = handRightBrake.ToString("F1"),
                TotalValue = handSumBrake.ToString("F1"),
                TotalLimitValue = minHandBrake.ToString("F1"),
                TestDtlResult = handBrakeResult
            });

            // Giá trị Petrol Emision
            decimal coValue = ConvertToDecimal(vehicleDetails["CO"]);
            decimal maxCO = ConvertToDecimal(standard["MaxCO"]);
            string coResult = (coValue <= maxCO) ? "1" : "0";
            decimal hcValue = ConvertToDecimal(vehicleDetails["CO"]);
            decimal maxHC = ConvertToDecimal(standard["MaxCO"]);
            string hcResult = (hcValue <= maxHC) ? "1" : "0";
            decimal otValue = ConvertToDecimal(vehicleDetails["OilTemp"]);
            decimal eSpeedValue = ConvertToDecimal(vehicleDetails["RPM"]);
            AddIfEnabled("PetrolMMS", new
            {
                TestTypeCode = "EXHAUSTGA",
                TestDtlCode = "EXHAUSTGA_CO",
                MeasureValue = coValue.ToString("F2"),
                LimitValue = maxCO.ToString("F2"),
                TestDtlResult = coResult
            });
            AddIfEnabled("PetrolMMS", new
            {
                TestTypeCode = "EXHAUSTGA",
                TestDtlCode = "EXHAUSTGA_HC",
                MeasureValue = hcValue.ToString("F1"),
                LimitValue = maxHC.ToString("F1"),
                TestDtlResult = hcResult
            });
            AddIfEnabled("PetrolMMS", new
            {
                TestTypeCode = "EXHAUSTGA",
                TestDtlCode = "EXHAUSTGA_E",
                MeasureValue = eSpeedValue.ToString("F1"),
                TestDtlResult = "1"
            });
            AddIfEnabled("PetrolMMS", new
            {
                TestTypeCode = "EXHAUSTGA",
                TestDtlCode = "EXHAUSTGA_O",
                MeasureValue = otValue.ToString("F1"),
                TestDtlResult = "1"
            });

            // Giá trị Diesel Emission
            decimal minspeed1 = ConvertToDecimal(vehicleDetails["MinSpeed1"]);
            decimal minspeed2 = ConvertToDecimal(vehicleDetails["MinSpeed2"]);
            decimal minspeed3 = ConvertToDecimal(vehicleDetails["MinSpeed3"]);
            decimal maxspeed1 = ConvertToDecimal(vehicleDetails["MaxSpeed1"]);
            decimal maxspeed2 = ConvertToDecimal(vehicleDetails["MaxSpeed2"]);
            decimal maxspeed3 = ConvertToDecimal(vehicleDetails["MaxSpeed3"]);
            decimal hsu1 = ConvertToDecimal(vehicleDetails["HSU1"]);
            decimal hsu2 = ConvertToDecimal(vehicleDetails["HSU2"]);
            decimal hsu3 = ConvertToDecimal(vehicleDetails["HSU3"]);
            decimal avgHSU = (hsu1 + hsu2 + hsu3) / 3;
            decimal maxHSU = ConvertToDecimal(standard["MaxHSU"]);
            string hsuResult = (avgHSU <= maxHSU) ? "1" : "0";
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "RPMMIN_1",
                MeasureValue = minspeed1.ToString("F0"),
                TestDtlResult = "0"
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "RPMMIN_2",
                MeasureValue = minspeed2.ToString("F0"),
                TestDtlResult = "0"
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "RPMMIN_3",
                MeasureValue = minspeed3.ToString("F0"),
                TestDtlResult = "0"
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "RPMMAX_1",
                MeasureValue = maxspeed1.ToString("F0"),
                TestDtlResult = "0"
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "RPMMAX_2",
                MeasureValue = maxspeed2.ToString("F0"),
                TestDtlResult = "0"
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "RPMMAX_3",
                MeasureValue = maxspeed3.ToString("F0"),
                TestDtlResult = "0"
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "OPACITY_1",
                MeasureValue = hsu1.ToString("F2"),
                TestDtlResult = "0"
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "OPACITY_2",
                MeasureValue = hsu2.ToString("F2"),
                TestDtlResult = "0"
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "OPACITY_3",
                MeasureValue = hsu3.ToString("F2"),
                TestDtlResult = "0"
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "DIESELOPACITY_A",
                AverageValue = avgHSU.ToString("F2"),
                TestDtlResult = hsuResult
            });
            AddIfEnabled("DieselMMS", new
            {
                TestTypeCode = "DIESELOPACITY",
                TestDtlCode = "DIESELOPACITY_L",
                LimitValue = maxHSU.ToString("F2"),
                TestDtlResult = hsuResult
            });
            // Góc Lái
            AddIfEnabled("SteeringAngleMMS", new
            {
                TestTypeCode = "STEERINGANGLE",
                TestDtlCode = "STEERINGANGLE_L",
                MeasureValue = ConvertToDecimal(vehicleDetails["LeftSteerLW"]).ToString("F1"),
                LimitValue = $"{standard["MinLeftSteer"]} ~ {standard["MaxLeftSteer"]}",
                TestDtlResult = CheckStandard(ConvertToDecimal(vehicleDetails["LeftSteerLW"]),
                                  standard.Field<decimal?>("MinLeftSteer"),
                                  standard.Field<decimal?>("MaxLeftSteer")) ? "1" : "0"
            });

            AddIfEnabled("SteeringAngleMMS", new
            {
                TestTypeCode = "STEERINGANGLE",
                TestDtlCode = "STEERINGANGLE_R",
                MeasureValue = ConvertToDecimal(vehicleDetails["RightSteerLW"]).ToString("F1"),
                LimitValue = $"{standard["MinRightSteer"]} ~ {standard["MaxRightSteer"]}",
                TestDtlResult = CheckStandard(ConvertToDecimal(vehicleDetails["RightSteerLW"]),
                                              standard.Field<decimal?>("MinRightSteer"),
                                              standard.Field<decimal?>("MaxRightSteer")) ? "1" : "0"
            });

            return testDetails;
        }
        // Hàm gọi API Login để lấy sessionid
        private async Task<string> GetSessionIdFromMMS(string apiUrl, string username, string password)
        {
            try
            {
                var loginData = new { username, password };
                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);

                using (var client = new HttpClient())
                {
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    string result = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                        string sessionId = responseObject?.SessionId;

                        if (!string.IsNullOrEmpty(sessionId))
                        {
                            LogToFile("LoginLog.txt", $"[{DateTime.Now}] Login Success: Username={username}, SessionId={sessionId}");
                            return sessionId; // Trả về SessionId
                        }
                        else
                        {
                            LogToFile("LoginLog.txt", $"[{DateTime.Now}] Login Failed: Username={username}, Error=SessionId not found");
                            throw new Exception("Không tìm thấy SessionId trong phản hồi từ server.");
                        }
                    }
                    else
                    {
                        LogToFile("LoginLog.txt", $"[{DateTime.Now}] Login Failed: Username={username}, Error={response.StatusCode}, Response={result}");
                        throw new Exception($"Yêu cầu đăng nhập thất bại: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogToFile("LoginLog.txt", $"[{DateTime.Now}] Login Exception: Username={username}, Error={ex.Message}");
                MessageBox.Show($"Lỗi khi login vào MMS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        // Hàm gọi API QC_TestReport_Save để lưu dữ liệu lên MMS
        private async Task<bool> SaveDataToMMS(string apiUrl, string sessionId, string jsonData)
        {
            try
            {
                var requestData = new
                {
                    sessionid = sessionId,
                    flagisdelete = "0", // Mặc định là lưu
                    strQC_TestReport = jsonData
                };
                string requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                LogToFile("SaveDataLog.txt", $"[{DateTime.Now}] Request Sent: {requestJson}");

                using (var client = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    string responseResult = await response.Content.ReadAsStringAsync();
                    // Kiểm tra phản hồi
                    if (response.IsSuccessStatusCode)
                    {
                        LogToFile("SaveDataLog.txt", $"[{DateTime.Now}] Save Success: sessionid={sessionId}, Request={requestJson}");
                        return true; // Thành công
                    }
                    else
                    {
                        LogToFile("SaveDataLog.txt", $"[{DateTime.Now}] Save Failed: sessionid={sessionId}, Error={response.StatusCode}, Response={responseResult}, Request={requestJson}");
                        MessageBox.Show($"Lỗi từ server: {responseResult}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                LogToFile("SaveDataLog.txt", $"[{DateTime.Now}] Save Exception: sessionid={sessionId}, Error={ex.Message}, Request={jsonData}");
                MessageBox.Show($"Lỗi khi lưu dữ liệu lên MMS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private void LogToFile(string fileName, string logContent)
        {
            try
            {
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    string singleLineLog = logContent.Replace(Environment.NewLine, "").Replace("\n", "").Replace("\r", "");
                    writer.WriteLine(singleLineLog);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể ghi log: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick(); // Kích hoạt nút Search
                e.Handled = true;         // Ngăn Enter thực hiện hành động mặc định
                e.SuppressKeyPress = true; // Ngăn âm báo "ding"
            }
        }
    }
}
