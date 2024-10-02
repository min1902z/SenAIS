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
        //private DataTable reportDataTable;
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
                CheckAndColorTextBox(txtRHLHorizontal, standard.Field<decimal?>("DiffHoriHLMin"), standard.Field<decimal?>("DiffHoriHLMax"));
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
                        txtBox.BackColor = Color.LightYellow; // Dưới mức chuẩn
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
                        txtBox.BackColor = Color.LightYellow; // Vượt quá mức chuẩn
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
                        txtBox.BackColor = Color.LightYellow; // Dưới mức chuẩn
                    }
                    else if (value > maxValue.Value)
                    {
                        txtBox.BackColor = Color.LightYellow; // Vượt quá mức chuẩn
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

            // Thêm các cột cho báo cáo
            reportDataTable.Columns.Add("SerialNumber", typeof(string));
            reportDataTable.Columns.Add("FrameNumber", typeof(string));
            reportDataTable.Columns.Add("VehicleType", typeof(string));
            reportDataTable.Columns.Add("Inspector", typeof(string));
            reportDataTable.Columns.Add("EngineNumber", typeof(string));
            reportDataTable.Columns.Add("InspectionDate", typeof(DateTime));

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
            reportDataTable.Columns.Add("DiffFrontBrakeMax", typeof(decimal));
            reportDataTable.Columns.Add("RearDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("DiffRearBrakeMax", typeof(decimal));
            reportDataTable.Columns.Add("HandSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinHandBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("DiffHandBrakeMax", typeof(decimal));

            reportDataTable.Columns.Add("LHLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("RHLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MinHLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("LHLVertical", typeof(decimal));
            reportDataTable.Columns.Add("RHLVertical", typeof(decimal));
            reportDataTable.Columns.Add("DiffVertiHLMin", typeof(decimal));
            reportDataTable.Columns.Add("DiffVertiHLMax", typeof(decimal));
            reportDataTable.Columns.Add("LHLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("RHLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("DiffHoriHLMin", typeof(decimal));
            reportDataTable.Columns.Add("DiffHoriHLMax", typeof(decimal));
            reportDataTable.Columns.Add("LLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("RLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MinLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("LLBVertical", typeof(decimal));
            reportDataTable.Columns.Add("RLBVertical", typeof(decimal));
            reportDataTable.Columns.Add("DiffVertiLBMin", typeof(decimal));
            reportDataTable.Columns.Add("DiffVertiLBMax", typeof(decimal));
            reportDataTable.Columns.Add("LLBHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("RLBHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("DiffHoriLBMin", typeof(decimal));
            reportDataTable.Columns.Add("DiffHoriLBMax", typeof(decimal));

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

            reportDataTable.Columns.Add("LightHeight", typeof(decimal));


            // Gọi hàm GetVehicleDetails để lấy thông tin xe theo serialNumber
            DataRow vehicleDetails = sqlHelper.GetVehicleDetails(serialNumber);

            if (vehicleDetails != null)
            {
                // Gọi hàm GetVehicleStandardsByTypeCar để lấy tiêu chuẩn theo loại xe
                string vehicleType = vehicleDetails["VehicleType"].ToString();
                DataTable vehicleStandards = sqlHelper.GetVehicleStandardsByTypeCar(vehicleType);
                DataRow standard = vehicleStandards.Rows[0];
                // Tính toán giá trị FrontSumWeight (tổng của FrontLeftWeight và FrontRightWeight)
                decimal frontLeftWeight = vehicleDetails.Field<decimal>("FrontLeftWeight");
                decimal frontRightWeight = vehicleDetails.Field<decimal>("FrontRightWeight");
                decimal frontSumWeight = frontLeftWeight + frontRightWeight;

                // Tính toán RearSumWeight (tổng của RearLeftWeight và RearRightWeight)
                decimal rearLeftWeight = vehicleDetails.Field<decimal>("RearLeftWeight");
                decimal rearRightWeight = vehicleDetails.Field<decimal>("RearRightWeight");
                decimal rearSumWeight = rearLeftWeight + rearRightWeight;

                decimal frontLeftBrake = vehicleDetails.Field<decimal>("FrontLeftBrake");
                decimal frontRightBrake = vehicleDetails.Field<decimal>("FrontRightBrake");
                decimal frontDiffBrake = Convert.ToDecimal(txtFrontDiffBrake.Text);
                decimal frontSumBrake = frontLeftBrake + frontRightBrake;

                decimal rearLeftBrake = vehicleDetails.Field<decimal>("RearLeftBrake");
                decimal rearRightBrake = vehicleDetails.Field<decimal>("RearRightBrake");
                decimal rearDiffBrake = Convert.ToDecimal(txtRearDiffBrake.Text);
                decimal rearSumBrake = rearLeftBrake + rearRightBrake;

                decimal handLeftBrake = vehicleDetails.Field<decimal>("HandBrakeLeft");
                decimal handRightBrake = vehicleDetails.Field<decimal>("HandBrakeRight");
                decimal handDiffBrake = Convert.ToDecimal(txtHandDiffBrake.Text);
                decimal handSumBrake = handLeftBrake + handRightBrake;

                decimal hsu1 = vehicleDetails.Field<decimal>("HSU1");
                decimal hsu2 = vehicleDetails.Field<decimal>("HSU2");
                decimal hsu3 = vehicleDetails.Field<decimal>("HSU3");
                decimal avgHSU = (hsu1+ hsu2+ hsu3) / 3;

                // Thêm dữ liệu vào DataTable
                DataRow reportRow = reportDataTable.NewRow();
                reportRow["SerialNumber"] = vehicleDetails["SerialNumber"].ToString();
                reportRow["FrameNumber"] = vehicleDetails["FrameNumber"].ToString();
                reportRow["VehicleType"] = vehicleDetails["VehicleType"].ToString();
                reportRow["Inspector"] = vehicleDetails["Inspector"].ToString();
                reportRow["EngineNumber"] = vehicleDetails["EngineNumber"].ToString();
                reportRow["InspectionDate"] = Convert.ToDateTime(vehicleDetails["InspectionDate"]).ToShortDateString();

                reportRow["Speed"] = Convert.ToDecimal(vehicleDetails["Speed"]).ToString("F1");
                reportRow["MinSpeed"] = Convert.ToDecimal(standard.Field<decimal>("MinSpeed")).ToString("F1");
                reportRow["MaxSpeed"] = Convert.ToDecimal(standard.Field<decimal>("MaxSpeed")).ToString("F1");

                reportRow["SideSlip"] = Convert.ToDecimal(vehicleDetails["SideSlip"]).ToString("F1");
                reportRow["MinSideSlip"] = Convert.ToDecimal(standard.Field<decimal>("MinSideSlip")).ToString("F1");
                reportRow["MaxSideSlip"] = Convert.ToDecimal(standard.Field<decimal>("MaxSideSlip")).ToString("F1");

                reportRow["Noise"] = Convert.ToDecimal(vehicleDetails["Noise"]).ToString("F1");
                reportRow["MaxNoise"] = Convert.ToDecimal(standard.Field<decimal>("MaxNoise")).ToString("F1");
                reportRow["Whistle"] = Convert.ToDecimal(vehicleDetails["Whistle"]).ToString("F1");
                reportRow["MinWhistle"] = Convert.ToDecimal(standard.Field<decimal>("MinWhistle")).ToString("F1");
                reportRow["MaxWhistle"] = Convert.ToDecimal(standard.Field<decimal>("MaxWhistle")).ToString("F1");

                reportRow["HC"] = Convert.ToDecimal(vehicleDetails["HC"]).ToString("F1");
                reportRow["MaxHC"] = Convert.ToDecimal(standard.Field<decimal>("MaxHC")).ToString("F1");
                reportRow["CO"] = Convert.ToDecimal(vehicleDetails["CO"]).ToString("F1");
                reportRow["MaxCO"] = Convert.ToDecimal(standard.Field<decimal>("MaxCO")).ToString("F1");
                reportRow["CO2"] = Convert.ToDecimal(vehicleDetails["CO2"]).ToString("F1");
                reportRow["MaxCO2"] = Convert.ToDecimal(standard.Field<decimal>("MaxCO2")).ToString("F1");
                reportRow["O2"] = Convert.ToDecimal(vehicleDetails["O2"]).ToString("F1");
                reportRow["MaxO2"] = Convert.ToDecimal(standard.Field<decimal>("MaxO2")).ToString("F1");
                reportRow["NO"] = Convert.ToDecimal(vehicleDetails["NO"]).ToString("F1");
                reportRow["MaxNO"] = Convert.ToDecimal(standard.Field<decimal>("MaxNO")).ToString("F1");
                reportRow["OilTemp"] = Convert.ToDecimal(vehicleDetails["OilTemp"]).ToString("F1");
                reportRow["RPM"] = Convert.ToDecimal(vehicleDetails["RPM"]).ToString("F1");

                reportRow["FrontLeftWeight"] = frontLeftWeight.ToString("F1");
                reportRow["FrontRightWeight"] = frontRightWeight.ToString("F1");
                reportRow["FrontSumWeight"] = frontSumWeight.ToString("F1");
                reportRow["RearLeftWeight"] = rearLeftWeight.ToString("F1");
                reportRow["RearRightWeight"] = rearRightWeight.ToString("F1");
                reportRow["RearSumWeight"] = rearSumWeight.ToString("F1");

                reportRow["FrontLeftBrake"] = frontLeftBrake.ToString("F1");
                reportRow["FrontRightBrake"] = frontRightBrake.ToString("F1");
                reportRow["FrontDiffBrake"] = frontDiffBrake.ToString("F1");
                reportRow["DiffFrontBrakeMax"] = Convert.ToDecimal(standard.Field<decimal>("DiffFrontBrakeMax")).ToString("F1");
                reportRow["FrontSumBrake"] = frontSumBrake.ToString("F1");
                reportRow["MinFrontBrake"] = Convert.ToDecimal(standard.Field<decimal>("MinFrontBrake")).ToString("F1");
                reportRow["RearLeftBrake"] = rearLeftBrake.ToString("F1");
                reportRow["RearRightBrake"] = rearRightBrake.ToString("F1");
                reportRow["RearDiffBrake"] = rearDiffBrake.ToString("F1");
                reportRow["DiffRearBrakeMax"] = Convert.ToDecimal(standard.Field<decimal>("DiffRearBrakeMax")).ToString("F1");
                reportRow["RearSumBrake"] = rearSumBrake.ToString("F1");
                reportRow["MinRearBrake"] = Convert.ToDecimal(standard.Field<decimal>("MinRearBrake")).ToString("F1");
                reportRow["HandLeftBrake"] = handLeftBrake.ToString("F1");
                reportRow["HandRightBrake"] = handRightBrake.ToString("F1");
                reportRow["HandDiffBrake"] = handDiffBrake.ToString("F1");
                reportRow["DiffHandBrakeMax"] = Convert.ToDecimal(standard.Field<decimal>("DiffHandBrakeMax")).ToString("F1");
                reportRow["HandSumBrake"] = rearSumBrake.ToString("F1");
                reportRow["MinHandBrake"] = Convert.ToDecimal(standard.Field<decimal>("MinHandBrake")).ToString("F1");

                reportRow["LHLIntensity"] = Convert.ToDecimal(vehicleDetails["LHLIntensity"]).ToString("F1");
                reportRow["RHLIntensity"] = Convert.ToDecimal(vehicleDetails["RHLIntensity"]).ToString("F1");
                reportRow["MinHLIntensity"] = Convert.ToDecimal(standard.Field<decimal>("MinHLIntensity")).ToString("F1");
                reportRow["LHLVertical"] = Convert.ToDecimal(vehicleDetails["LHLVertical"]).ToString("F1");
                reportRow["RHLVertical"] = Convert.ToDecimal(vehicleDetails["RHLVertical"]).ToString("F1");
                reportRow["DiffVertiHLMin"] = Convert.ToDecimal(standard.Field<decimal>("DiffVertiHLMin")).ToString("F1");
                reportRow["DiffVertiHLMax"] = Convert.ToDecimal(standard.Field<decimal>("DiffVertiHLMax")).ToString("F1");
                reportRow["LHLHorizontal"] = Convert.ToDecimal(vehicleDetails["LHLHorizontal"]).ToString("F1");
                reportRow["RHLHorizontal"] = Convert.ToDecimal(vehicleDetails["RHLHorizontal"]).ToString("F1");
                reportRow["DiffHoriHLMin"] = Convert.ToDecimal(standard.Field<decimal>("DiffHoriHLMin")).ToString("F1");
                reportRow["DiffHoriHLMax"] = Convert.ToDecimal(standard.Field<decimal>("DiffHoriHLMax")).ToString("F1");

                reportRow["LLBIntensity"] = Convert.ToDecimal(vehicleDetails["LLBIntensity"]).ToString("F1");
                reportRow["RLBIntensity"] = Convert.ToDecimal(vehicleDetails["RLBIntensity"]).ToString("F1");
                reportRow["MinLBIntensity"] = Convert.ToDecimal(standard.Field<decimal>("MinLBIntensity")).ToString("F1");
                reportRow["LLBVertical"] = Convert.ToDecimal(vehicleDetails["LLBVertical"]).ToString("F1");
                reportRow["RLBVertical"] = Convert.ToDecimal(vehicleDetails["RLBVertical"]).ToString("F1");
                reportRow["DiffVertiLBMin"] = Convert.ToDecimal(standard.Field<decimal>("DiffVertiLBMin")).ToString("F1");
                reportRow["DiffVertiLBMax"] = Convert.ToDecimal(standard.Field<decimal>("DiffVertiLBMax")).ToString("F1");
                reportRow["LLBHorizontal"] = Convert.ToDecimal(vehicleDetails["LLBHorizontal"]).ToString("F1");
                reportRow["RLBHorizontal"] = Convert.ToDecimal(vehicleDetails["RLBHorizontal"]).ToString("F1");
                reportRow["DiffHoriLBMin"] = Convert.ToDecimal(standard.Field<decimal>("DiffHoriLBMin")).ToString("F1");
                reportRow["DiffHoriLBMax"] = Convert.ToDecimal(standard.Field<decimal>("DiffHoriLBMax")).ToString("F1");

                reportRow["MinSpeed1"] = Convert.ToDecimal(vehicleDetails["MinSpeed1"]).ToString("F1");
                reportRow["MaxSpeed1"] = Convert.ToDecimal(vehicleDetails["MaxSpeed1"]).ToString("F1");
                reportRow["HSU1"] = hsu1.ToString("F1");
                reportRow["MinSpeed2"] = Convert.ToDecimal(vehicleDetails["MinSpeed2"]).ToString("F1");
                reportRow["MaxSpeed2"] = Convert.ToDecimal(vehicleDetails["MaxSpeed2"]).ToString("F1");
                reportRow["HSU2"] = hsu2.ToString("F1");
                reportRow["MinSpeed3"] = Convert.ToDecimal(vehicleDetails["MinSpeed3"]).ToString("F1");
                reportRow["MaxSpeed3"] = Convert.ToDecimal(vehicleDetails["MaxSpeed3"]).ToString("F1");
                reportRow["HSU3"] = hsu3.ToString("F1");
                reportRow["AvgHSU"] = avgHSU.ToString("F1");
                reportRow["MaxHSU"] = Convert.ToDecimal(standard.Field<decimal>("MaxHSU")).ToString("F1");
                reportRow["LightHeight"] = Convert.ToDecimal(standard.Field<decimal>("LightHeight")).ToString("F1");

                reportDataTable.Rows.Add(reportRow);
            }

            return reportDataTable;
        }
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            string serialNumber = txtSerialNum.Text; // Lấy số serial từ TextBox
            //List<VehicleReportData> reportDataList = GetVehicleReportData(serialNumber);
            DataTable reportDataList = GetVehicleReportData(serialNumber);
            TestReport exportReportForm = new TestReport(reportDataList);
            exportReportForm.Show();
        }
    }
}
