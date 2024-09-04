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
        //private Form parentForm;
        private SQLHelper sqlHelper;
        private string serialNumber;
        private DataTable reportDataTable;
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
                txtMinSpeed1.Text = vehicleDetails["MinSpeed1"]?.ToString();
                txtMaxSpeed1.Text = vehicleDetails["MaxSpeed1"]?.ToString();
                txtMinSpeed2.Text = vehicleDetails["MinSpeed2"]?.ToString();
                txtMaxSpeed2.Text = vehicleDetails["MaxSpeed2"]?.ToString();
                txtMinSpeed3.Text = vehicleDetails["MinSpeed3"]?.ToString();
                txtMaxSpeed3.Text = vehicleDetails["MaxSpeed3"]?.ToString();
                txtHSU1.Text = vehicleDetails["HSU1"]?.ToString();
                txtHSU2.Text = vehicleDetails["HSU2"]?.ToString();
                txtHSU3.Text = vehicleDetails["HSU3"]?.ToString();

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
            ClearTextBoxes(txtEngineNum);
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

            ClearTextBoxes(txtFrontSumWeight);
            ClearTextBoxes(txtRearSumWeight);
            ClearTextBoxes(txtFrontSumBrake);
            ClearTextBoxes(txtFrontDiffBrake);
            ClearTextBoxes(txtRearSumBrake);
            ClearTextBoxes(txtRearDiffBrake);
            ClearTextBoxes(txtHandSumBrake);
            ClearTextBoxes(txtHandDiffBrake);
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
        private void EvaluateMeasurements()
        {
            // Lấy loại xe hiện tại
            string typeCar = txtTypeCar.Text;

            // Lấy dữ liệu tiêu chuẩn từ DB
            DataTable standardsTable = sqlHelper.GetVehicleStandardsByTypeCar(typeCar);

            if (standardsTable.Rows.Count > 0)
            {
                DataRow standard = standardsTable.Rows[0];

                // Kiểm tra tốc độ
                CheckAndColorTextBox(txtSpeed, standard.Field<decimal?>("MinSpeed"), standard.Field<decimal?>("MaxSpeed"));

                // Kiểm tra lực phanh trước
                CheckAndColorTextBox(txtFrontSumBrake, standard.Field<decimal?>("MinFrontBrake"), null); // Chỉ có giá trị tối thiểu

                // Kiểm tra lực phanh sau
                CheckAndColorTextBox(txtRearSumBrake, standard.Field<decimal?>("MinRearBrake"), null);

                // Kiểm tra phanh tay
                CheckAndColorTextBox(txtHandSumBrake, standard.Field<decimal?>("MinHandBrake"), null);

                CheckAndColorTextBox(txtFrontDiffBrake, null, standard.Field<decimal?>("DiffFrontBrakeMax"));
                CheckAndColorTextBox(txtRearDiffBrake, null, standard.Field<decimal?>("DiffRearBrakeMax"));
                CheckAndColorTextBox(txtHandDiffBrake, null, standard.Field<decimal?>("DiffHandBrakeMax"));

                CheckAndColorTextBox(txtNoise, null, standard.Field<decimal?>("MaxNoise"));
                CheckAndColorTextBox(txtWhistle, standard.Field<decimal?>("MinWhistle"), standard.Field<decimal?>("MaxWhistle"));
                CheckAndColorTextBox(txtSideSlip, standard.Field<decimal?>("MinSideSlip"), standard.Field<decimal?>("MaxSideSlip"));
                CheckAndColorTextBox(txtHC, null, standard.Field<decimal?>("MaxHC"));
                CheckAndColorTextBox(txtCO, null, standard.Field<decimal?>("MaxCO"));
                CheckAndColorTextBox(txtCO2, null, standard.Field<decimal?>("MaxCO2"));
                CheckAndColorTextBox(txtO2, null, standard.Field<decimal?>("MaxO2"));
                CheckAndColorTextBox(txtNO, null, standard.Field<decimal?>("MaxNO"));
                CheckAndColorTextBox(txtHSU1, null, standard.Field<decimal?>("MaxHSU"));
                CheckAndColorTextBox(txtHSU2, null, standard.Field<decimal?>("MaxHSU"));
                CheckAndColorTextBox(txtHSU3, null, standard.Field<decimal?>("MaxHSU"));
                CheckAndColorTextBox(txtLHLIntensity, standard.Field<decimal?>("MinHLIntensity"), null);
                CheckAndColorTextBox(txtRHLIntensity, standard.Field<decimal?>("MinLBIntensity"), null);
                CheckAndColorTextBox(txtLHLHorizontal, standard.Field<decimal?>("DiffHoriLeftHLMin"), standard.Field<decimal?>("DiffHoriLeftHLMax"));
                CheckAndColorTextBox(txtRHLHorizontal, standard.Field<decimal?>("DiffHoriHLMin"), standard.Field<decimal?>("DiffHoriRightHLMax"));
                CheckAndColorTextBox(txtLHLVertical, standard.Field<decimal?>("DiffVertiHLMin"), standard.Field<decimal?>("DiffVertiHLMax"));
                CheckAndColorTextBox(txtRHLVertical, standard.Field<decimal?>("DiffVertiHLMin"), standard.Field<decimal?>("DiffVertiHLMax"));
                CheckAndColorTextBox(txtLLBIntensity, standard.Field<decimal?>("MinHLIntensity"), null);
                CheckAndColorTextBox(txtRLBIntensity, standard.Field<decimal?>("MinHLIntensity"), null);
                CheckAndColorTextBox(txtLLBHorizontal, standard.Field<decimal?>("DiffHoriLBMin"), standard.Field<decimal?>("DiffHoriLBMax"));
                CheckAndColorTextBox(txtRLBHorizontal, standard.Field<decimal?>("DiffHoriLBMin"), standard.Field<decimal?>("DiffHoriLBMax"));
                CheckAndColorTextBox(txtLLBVertical, standard.Field<decimal?>("DiffVertiLBMin"), standard.Field<decimal?>("DiffVertiLBMax"));
                CheckAndColorTextBox(txtRLBVertical, standard.Field<decimal?>("DiffVertiLBMin"), standard.Field<decimal?>("DiffVertiLBMax"));
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
                        txtBox.BackColor = Color.Yellow; // Dưới mức chuẩn
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
                        txtBox.BackColor = Color.IndianRed; // Vượt quá mức chuẩn
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
                        txtBox.BackColor = Color.Yellow; // Dưới mức chuẩn
                    }
                    else if (value > maxValue.Value)
                    {
                        txtBox.BackColor = Color.IndianRed; // Vượt quá mức chuẩn
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
        //private DataTable GetVehicleReportData(string serialNumber)
        //{
        //    reportDataTable = new DataTable();

        //    // Tạo các cột tương ứng với dữ liệu trên báo cáo
        //    reportDataTable.Columns.Add("SerialNumber");
        //    reportDataTable.Columns.Add("FrameNumber");
        //    reportDataTable.Columns.Add("VehicleType");
        //    reportDataTable.Columns.Add("Inspector");
        //    reportDataTable.Columns.Add("EngineNumber");
        //    reportDataTable.Columns.Add("InspectionDate");

        //    reportDataTable.Columns.Add("Speed");
        //    reportDataTable.Columns.Add("SideSlip");
        //    reportDataTable.Columns.Add("Noise");
        //    reportDataTable.Columns.Add("Whistle");

        //    reportDataTable.Columns.Add("HC");
        //    reportDataTable.Columns.Add("CO");
        //    reportDataTable.Columns.Add("CO2");
        //    reportDataTable.Columns.Add("O2");
        //    reportDataTable.Columns.Add("NO");
        //    reportDataTable.Columns.Add("OilTemp");
        //    reportDataTable.Columns.Add("RPM");

        //    reportDataTable.Columns.Add("FrontLeftWeight");
        //    reportDataTable.Columns.Add("FrontRightWeight");
        //    reportDataTable.Columns.Add("FrontSumWeight");
        //    reportDataTable.Columns.Add("RearLeftWeight");
        //    reportDataTable.Columns.Add("RearRightWeight");
        //    reportDataTable.Columns.Add("RearSumWeight");

        //    reportDataTable.Columns.Add("FrontLeftBrake");
        //    reportDataTable.Columns.Add("FrontRightBrake");
        //    reportDataTable.Columns.Add("RearLeftBrake");
        //    reportDataTable.Columns.Add("RearRightBrake");
        //    reportDataTable.Columns.Add("HandLeftBrake");
        //    reportDataTable.Columns.Add("HandRightBrake");
        //    reportDataTable.Columns.Add("FrontSumBrake");
        //    reportDataTable.Columns.Add("RearSumBrake");
        //    reportDataTable.Columns.Add("FrontDiffBrake");
        //    reportDataTable.Columns.Add("RearDiffBrake");
        //    reportDataTable.Columns.Add("HandSumBrake");
        //    reportDataTable.Columns.Add("HandDiffBrake");

        //    reportDataTable.Columns.Add("LHLIntensity");
        //    reportDataTable.Columns.Add("RHLIntensity");
        //    reportDataTable.Columns.Add("LHLVertical");
        //    reportDataTable.Columns.Add("RHLVertical");
        //    reportDataTable.Columns.Add("LHLHorizontal");
        //    reportDataTable.Columns.Add("RHLHorizontal");
        //    reportDataTable.Columns.Add("LLBIntensity");
        //    reportDataTable.Columns.Add("RLBIntensity");
        //    reportDataTable.Columns.Add("LLBVertical");
        //    reportDataTable.Columns.Add("RLBVertical");
        //    reportDataTable.Columns.Add("LLBHorizontal");
        //    reportDataTable.Columns.Add("RLBHorizontal");

        //    reportDataTable.Columns.Add("MinSpeed1");
        //    reportDataTable.Columns.Add("MaxSpeed1");
        //    reportDataTable.Columns.Add("HSU1");
        //    reportDataTable.Columns.Add("MinSpeed2");
        //    reportDataTable.Columns.Add("MaxSpeed2");
        //    reportDataTable.Columns.Add("HSU2");
        //    reportDataTable.Columns.Add("MinSpeed3");
        //    reportDataTable.Columns.Add("MaxSpeed3");
        //    reportDataTable.Columns.Add("HSU3");



        //    // Tạo hàng dữ liệu và thêm vào DataTable
        //    DataRow reportRow = reportDataTable.NewRow();
        //    reportRow["SerialNumber"] = txtSerialNum.Text;
        //    reportRow["FrameNumber"] = txtFrameNum.Text;
        //    reportRow["VehicleType"] = txtTypeCar.Text;
        //    reportRow["Inspector"] = txtInspector.Text;
        //    reportRow["EngineNumber"] = txtEngineNum.Text;
        //    reportRow["InspectionDate"] = txtDateInspec.Text;

        //    reportRow["Speed"] = txtSpeed.Text;
        //    reportRow["SideSlip"] = txtSideSlip.Text;
        //    reportRow["Noise"] = txtNoise.Text;
        //    reportRow["Whistle"] = txtWhistle.Text;

        //    reportRow["HC"] = txtHC.Text;
        //    reportRow["CO"] = txtCO.Text;
        //    reportRow["CO2"] = txtCO2.Text;
        //    reportRow["NO"] = txtNO.Text;
        //    reportRow["OilTemp"] = txtOT.Text;
        //    reportRow["RPM"] = txtRPM.Text;

        //    reportRow["FrontLeftWeight"] = txtFrontLeftWeight.Text;
        //    reportRow["FrontRightWeight"] = txtFrontRightWeight.Text;
        //    reportRow["FrontSumWeight"] = txtFrontSumWeight.Text;
        //    reportRow["RearLeftWeight"] = txtRearLeftWeight.Text;
        //    reportRow["RearRightWeight"] = txtRearRightWeight.Text;
        //    reportRow["RearSumWeight"] = txtRearSumWeight.Text;

        //    reportRow["FrontLeftBrake"] = txtFrontLeftWeight.Text;
        //    reportRow["FrontRightBrake"] = txtFrontRightWeight.Text;
        //    reportRow["RearLeftBrake"] = txtRearLeftWeight.Text;
        //    reportRow["RearRightBrake"] = txtRearRightWeight.Text;
        //    reportRow["FrontSumBrake"] = txtFrontSumBrake.Text;
        //    reportRow["RearSumBrake"] = txtRearSumBrake.Text;
        //    reportRow["FrontDiffBrake"] = txtFrontDiffBrake.Text;
        //    reportRow["RearDiffBrake"] = txtRearDiffBrake.Text;
        //    reportRow["HandLeftBrake"] = txtFrontLeftWeight.Text;
        //    reportRow["HandRightBrake"] = txtFrontRightWeight.Text;
        //    reportRow["HandSumBrake"] = txtRearLeftWeight.Text;
        //    reportRow["HandDiffBrake"] = txtRearLeftWeight.Text;

        //    reportRow["LHLIntensity"] = txtLHLIntensity.Text;
        //    reportRow["RHLIntensity"] = txtRHLIntensity.Text;
        //    reportRow["LHLVertical"] = txtLHLVertical.Text;
        //    reportRow["RHLVertical"] = txtRHLVertical.Text;
        //    reportRow["LHLHorizontal"] = txtLHLHorizontal.Text;
        //    reportRow["RHLHorizontal"] = txtRHLHorizontal.Text;
        //    reportRow["LLBIntensity"] = txtLLBIntensity.Text;
        //    reportRow["RLBIntensity"] = txtRLBIntensity.Text;
        //    reportRow["LLBVertical"] = txtLLBVertical.Text;
        //    reportRow["RLBVertical"] = txtRLBVertical.Text;
        //    reportRow["LLBHorizontal"] = txtLLBHorizontal.Text;
        //    reportRow["RLBHorizontal"] = txtRLBHorizontal.Text;

        //    reportRow["MinSpeed1"] = txtMinSpeed1.Text;
        //    reportRow["MaxSpeed1"] = txtMaxSpeed1.Text;
        //    reportRow["HSU2"] = txtHSU2.Text;
        //    reportRow["MinSpeed2"] = txtMinSpeed2.Text;
        //    reportRow["MaxSpeed2"] = txtMaxSpeed2.Text;
        //    reportRow["HSU2"] = txtHSU2.Text;
        //    reportRow["MinSpeed3"] = txtMinSpeed3.Text;
        //    reportRow["MaxSpeed3"] = txtMaxSpeed3.Text;
        //    reportRow["HSU3"] = txtHSU3.Text;

        //    reportDataTable.Rows.Add(reportRow);

        //    return reportDataTable;
        //}
        private List<VehicleReportData> GetVehicleReportData(string serialNumber)
        {
            DataRow vehicleDetails = sqlHelper.GetVehicleDetails(serialNumber);
            DataTable standardsTable = sqlHelper.GetVehicleStandardsByTypeCar(vehicleDetails["VehicleType"].ToString());

            if (standardsTable.Rows.Count > 0)
            {
                DataRow standard = standardsTable.Rows[0];

                var reportData = new VehicleReportData
                {
                    SerialNumber = vehicleDetails["SerialNumber"].ToString(),
                    FrameNumber = vehicleDetails["FrameNumber"].ToString(),
                    VehicleType = vehicleDetails["VehicleType"].ToString(),
                    Inspector = vehicleDetails["Inspector"].ToString(),
                    Speed = Convert.ToDecimal(vehicleDetails["Speed"]),
                    MinSpeed = standard.Field<decimal?>("MinSpeed"),
                    MaxSpeed = standard.Field<decimal?>("MaxSpeed"),
                    IsSpeedWithinStandard = CheckIfWithinStandard(Convert.ToDecimal(vehicleDetails["Speed"]), standard.Field<decimal?>("MinSpeed"), standard.Field<decimal?>("MaxSpeed")),
                    // Thêm các trường khác theo cách tương tự...
                };

                return new List<VehicleReportData> { reportData };
            }

            return null;
        }
        private bool CheckIfWithinStandard(decimal measuredValue, decimal? minValue, decimal? maxValue)
        {
            if (minValue.HasValue && measuredValue < minValue.Value) return false;
            if (maxValue.HasValue && measuredValue > maxValue.Value) return false;
            return true;
        }
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            string serialNumber = txtSerialNum.Text; // Lấy số serial từ TextBox
            List<VehicleReportData> reportDataList = GetVehicleReportData(serialNumber);
            frmExportReport exportReportForm = new frmExportReport(reportDataList);
            exportReportForm.ShowDialog();
        }
    }
}
