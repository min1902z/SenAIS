using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmReport : Form
    {
        private SQLHelper sqlHelper;
        private string serialNumber;
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
                    dgVehicleInfo.Columns["Color"].HeaderText = "Màu xe";
                    //dgVehicleInfo.Columns["EngineType"].HeaderText = "Loại động cơ";
                    // Thêm Màu xe
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
                string vehicleType = vehicleDetails["VehicleType"].ToString();
                txtTypeCar.Text = vehicleType;
                txtColor.Text = vehicleDetails["Color"]?.ToString();
                txtInspector.Text = vehicleDetails["Inspector"].ToString();
                txtFuel.Text = vehicleDetails["Fuel"].ToString();
                DateTime inspectionDate;
                if (DateTime.TryParse(vehicleDetails["InspectionDate"].ToString(), out inspectionDate))
                {
                    txtDateInspec.Text = inspectionDate.ToString("dd/MM/yyyy"); // Định dạng ngày thành dd/MM/yyyy
                }
                else
                {
                    txtDateInspec.Text = string.Empty; // Để trống nếu không parse được ngày
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
                txtLamda.Text = vehicleDetails["Lambda"]?.ToString();
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
                txtLHLHeight.Text = vehicleDetails["LHBHeight"]?.ToString();
                txtRHLIntensity.Text = vehicleDetails["RHLIntensity"]?.ToString();
                txtRHLVertical.Text = vehicleDetails["RHLVertical"]?.ToString();
                txtRHLHorizontal.Text = vehicleDetails["RHLHorizontal"]?.ToString();
                txtRHLHeight.Text = vehicleDetails["RHBHeight"]?.ToString();
                txtLLBIntensity.Text = vehicleDetails["LLBIntensity"]?.ToString();
                txtLLBVertical.Text = vehicleDetails["LLBVertical"]?.ToString();
                txtLLBHorizontal.Text = vehicleDetails["LLBHorizontal"]?.ToString();
                txtLLBHeight.Text = vehicleDetails["LLBHeight"]?.ToString();
                txtRLBIntensity.Text = vehicleDetails["RLBIntensity"]?.ToString();
                txtRLBVertical.Text = vehicleDetails["RLBVertical"]?.ToString();
                txtRLBHorizontal.Text = vehicleDetails["RLBHorizontal"]?.ToString();
                txtRLBHeight.Text = vehicleDetails["RLBHeight"]?.ToString();

                txtLFLIntensity.Text = vehicleDetails["LFLIntensity"]?.ToString();
                txtLFLVertical.Text = vehicleDetails["LFLVertical"]?.ToString();
                txtLFLHorizontal.Text = vehicleDetails["LFLHorizontal"]?.ToString();
                txtLFLHeight.Text = vehicleDetails["LFLHeight"]?.ToString();
                txtRFLIntensity.Text = vehicleDetails["RFLIntensity"]?.ToString();
                txtRFLVertical.Text = vehicleDetails["RFLVertical"]?.ToString();
                txtRFLHorizontal.Text = vehicleDetails["RFLHorizontal"]?.ToString();
                txtRFLHeight.Text = vehicleDetails["RFLHeight"]?.ToString();

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

                EvaluateMeasurements(vehicleType);
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
        private void EvaluateMeasurements(string vehicleType)
        {
            // Lấy dữ liệu tiêu chuẩn từ DB
            DataTable standardsTable = sqlHelper.GetVehicleStandardsByTypeCar(vehicleType);

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

                CheckAndColorTextBox(txtFrontDiffBrake, null, standard.Field<decimal?>("MaxDiffFrontBrake"));
                CheckAndColorTextBox(txtRearDiffBrake, null, standard.Field<decimal?>("MaxDiffRearBrake"));
                CheckAndColorTextBox(txtHandDiffBrake, null, standard.Field<decimal?>("MaxDiffHandBrake"));

                CheckAndColorTextBox(txtNoise, null, standard.Field<decimal?>("MaxNoise"));
                CheckAndColorTextBox(txtWhistle, standard.Field<decimal?>("MinWhistle"), standard.Field<decimal?>("MaxWhistle"));
                CheckAndColorTextBox(txtSideSlip, standard.Field<decimal?>("MinSideSlip"), standard.Field<decimal?>("MaxSideSlip"));
                CheckAndColorTextBox(txtHC, null, standard.Field<decimal?>("MaxHC"));
                CheckAndColorTextBox(txtCO, null, standard.Field<decimal?>("MaxCO"));
                CheckAndColorTextBox(txtCO2, null, standard.Field<decimal?>("MaxCO2"));
                CheckAndColorTextBox(txtO2, null, standard.Field<decimal?>("MaxO2"));
                CheckAndColorTextBox(txtNO, null, standard.Field<decimal?>("MaxNO"));
                CheckAndColorTextBox(txtLamda, standard.Field<decimal?>("MinLamda"), standard.Field<decimal?>("MaxLamda"));
                CheckAndColorTextBox(txtHSU1, null, standard.Field<decimal?>("MaxHSU"));
                CheckAndColorTextBox(txtHSU2, null, standard.Field<decimal?>("MaxHSU"));
                CheckAndColorTextBox(txtHSU3, null, standard.Field<decimal?>("MaxHSU"));
                CheckAndColorTextBox(txtLHLIntensity, standard.Field<decimal?>("MinHLIntensity"), null);
                CheckAndColorTextBox(txtRHLIntensity, standard.Field<decimal?>("MinHLIntensity"), null);
                CheckAndColorTextBox(txtLHLHorizontal, standard.Field<decimal?>("MinDiffHoriHB"), standard.Field<decimal?>("MaxDiffHoriHB"));
                CheckAndColorTextBox(txtRHLHorizontal, standard.Field<decimal?>("MinDiffHoriHB"), standard.Field<decimal?>("MaxDiffHoriHB"));
                CheckAndColorTextBox(txtLHLVertical, standard.Field<decimal?>("MinDiffVertiHB"), standard.Field<decimal?>("MaxDiffVertiHB"));
                CheckAndColorTextBox(txtRHLVertical, standard.Field<decimal?>("MinDiffVertiHB"), standard.Field<decimal?>("MaxDiffVertiHB"));
                CheckAndColorTextBox(txtLHLHeight, standard.Field<decimal?>("MinLightHeight"), standard.Field<decimal?>("MaxLightHeight"));
                CheckAndColorTextBox(txtRHLHeight, standard.Field<decimal?>("MinLightHeight"), standard.Field<decimal?>("MaxLightHeight"));
                CheckAndColorTextBox(txtLLBIntensity, standard.Field<decimal?>("MinLBIntensity"), null);
                CheckAndColorTextBox(txtRLBIntensity, standard.Field<decimal?>("MinLBIntensity"), null);
                CheckAndColorTextBox(txtLLBHorizontal, standard.Field<decimal?>("MinDiffHoriLB"), standard.Field<decimal?>("MaxDiffHoriLB"));
                CheckAndColorTextBox(txtRLBHorizontal, standard.Field<decimal?>("MinDiffHoriLB"), standard.Field<decimal?>("MaxDiffHoriLB"));
                CheckAndColorTextBox(txtLLBVertical, standard.Field<decimal?>("MinDiffVertiLB"), standard.Field<decimal?>("MaxDiffVertiLB"));
                CheckAndColorTextBox(txtRLBVertical, standard.Field<decimal?>("MinDiffVertiLB"), standard.Field<decimal?>("MaxDiffVertiLB"));

                CheckAndColorTextBox(txtLFLIntensity, standard.Field<decimal?>("MinFLIntensity"), standard.Field<decimal?>("MaxFLIntensity"));
                CheckAndColorTextBox(txtRFLIntensity, standard.Field<decimal?>("MinFLIntensity"), standard.Field<decimal?>("MaxFLIntensity"));
                CheckAndColorTextBox(txtLFLHorizontal, standard.Field<decimal?>("MinDiffHoriFL"), standard.Field<decimal?>("MaxDiffHoriFL"));
                CheckAndColorTextBox(txtRFLHorizontal, standard.Field<decimal?>("MinDiffHoriFL"), standard.Field<decimal?>("MaxDiffHoriFL"));
                CheckAndColorTextBox(txtLFLVertical, standard.Field<decimal?>("MinDiffHoriFL"), standard.Field<decimal?>("MaxDiffHoriFL"));
                CheckAndColorTextBox(txtRFLVertical, standard.Field<decimal?>("MinDiffHoriFL"), standard.Field<decimal?>("MaxDiffHoriFL"));

                CheckAndColorTextBox(txtLeftSteerLW, standard.Field<decimal?>("MinLeftSteer"), standard.Field<decimal?>("MaxLeftSteer"));
                //CheckAndColorTextBox(txtLeftSteerRW, standard.Field<decimal?>("MinLeftSteer"), standard.Field<decimal?>("MaxLeftSteer"));
                //CheckAndColorTextBox(txtRightSteerLW, standard.Field<decimal?>("MinRightSteer"), standard.Field<decimal?>("MaxRightSteer"));
                CheckAndColorTextBox(txtRightSteerRW, standard.Field<decimal?>("MinRightSteer"), standard.Field<decimal?>("MaxRightSteer"));
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

            reportDataTable.Columns.Add("ReportTitle", typeof(string));
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
            reportDataTable.Columns.Add("Color", typeof(string));
            reportDataTable.Columns.Add("EngineType", typeof(string));

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
            reportDataTable.Columns.Add("Lambda", typeof(decimal));
            reportDataTable.Columns.Add("MinLamda", typeof(decimal));
            reportDataTable.Columns.Add("MaxLamda", typeof(decimal));

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
            reportDataTable.Columns.Add("LHLVertical", typeof(decimal));
            reportDataTable.Columns.Add("RHLVertical", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffVertiHB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffVertiHB", typeof(decimal));
            reportDataTable.Columns.Add("LHLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("RHLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffHoriHB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHoriHB", typeof(decimal));
            reportDataTable.Columns.Add("RHBHeight", typeof(decimal));
            reportDataTable.Columns.Add("LHBHeight", typeof(decimal));

            reportDataTable.Columns.Add("LLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("RLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MinLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("LLBVertical", typeof(decimal));
            reportDataTable.Columns.Add("RLBVertical", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffVertiLB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffVertiLB", typeof(decimal));
            reportDataTable.Columns.Add("LLBHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("RLBHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffHoriLB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHoriLB", typeof(decimal));

            reportDataTable.Columns.Add("LFLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("RFLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MinFLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MaxFLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("LFLVertical", typeof(decimal));
            reportDataTable.Columns.Add("RFLVertical", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffVertiFL", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffVertiFL", typeof(decimal));
            reportDataTable.Columns.Add("LFLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("RFLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffHoriFL", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHoriFL", typeof(decimal));
            reportDataTable.Columns.Add("DiffVertiFLRange", typeof(string));
            reportDataTable.Columns.Add("DiffHoriFLRange", typeof(string));

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
            reportDataTable.Columns.Add("MaxLightHeight", typeof(decimal));

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
                if (vehicleStandards == null || vehicleStandards.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy tiêu chuẩn chất lượng cho phương tiện loại: " + vehicleType +
                                    ".\nVui lòng kiểm tra lại cấu hình tiêu chuẩn.",
                                    "Lỗi Tiêu Chuẩn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return reportDataTable;
                }
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

                decimal? minDiffVertiFL = TryParseDecimal(standard["MinDiffVertiFL"]);
                decimal? maxDiffVertiFL = TryParseDecimal(standard["MaxDiffVertiFL"]);

                decimal? minDiffHoriFL = TryParseDecimal(standard["MinDiffHoriFL"]);
                decimal? maxDiffHoriFL = TryParseDecimal(standard["MaxDiffHoriFL"]);

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
                                   //&& CheckStandard(ConvertToDecimal(vehicleDetails["LeftSteerRW"]),
                                   //                 standard.Field<decimal?>("MinLeftSteer"), standard.Field<decimal?>("MaxLeftSteer"))
                                   //&& CheckStandard(ConvertToDecimal(vehicleDetails["RightSteerLW"]),
                                   //                 standard.Field<decimal?>("MinRightSteer"), standard.Field<decimal?>("MaxRightSteer"))
                                   && CheckStandard(ConvertToDecimal(vehicleDetails["RightSteerRW"]),
                                                    standard.Field<decimal?>("MinRightSteer"), standard.Field<decimal?>("MaxRightSteer"));

                bool speedResult = CheckStandard(ConvertToDecimal(vehicleDetails["Speed"]),
                                                 standard.Field<decimal?>("MinSpeed"),
                                                 standard.Field<decimal?>("MaxSpeed"));

                bool petrolResult = CheckStandard(ConvertToDecimal(vehicleDetails["HC"]), null,
                                                  standard.Field<decimal?>("MaxHC"))
                                     && CheckStandard(ConvertToDecimal(vehicleDetails["Lambda"]), standard.Field<decimal?>("MinLamda"),
                                                  standard.Field<decimal?>("MaxLamda"))
                                    && CheckStandard(ConvertToDecimal(vehicleDetails["CO"]), null,
                                                     standard.Field<decimal?>("MaxCO"));

                bool dieselResult = CheckStandard(avgHSU, null,
                                                  standard.Field<decimal?>("MaxHSU"));

                bool hlResult = CheckStandard(ConvertToDecimal(vehicleDetails["LHLIntensity"]),
                                              standard.Field<decimal?>("MinHLIntensity"), null)
                                && CheckStandard(ConvertToDecimal(vehicleDetails["RHLIntensity"]),
                                                 standard.Field<decimal?>("MinHLIntensity"), null)
                                && CheckStandard(ConvertToDecimal(vehicleDetails["RFLIntensity"]),
                                                 standard.Field<decimal?>("MinFLIntensity"), standard.Field<decimal?>("MaxFLIntensity"))
                                && CheckStandard(ConvertToDecimal(vehicleDetails["LFLIntensity"]),
                                                 standard.Field<decimal?>("MinFLIntensity"), standard.Field<decimal?>("MaxFLIntensity"))
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
                                                 standard.Field<decimal?>("MinLBIntensity"), null)
                                && CheckStandard(ConvertToDecimal(vehicleDetails["LLBIntensity"]),
                                                 standard.Field<decimal?>("MinLBIntensity"), null)
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

                reportRow["ReportTitle"] = ConfigurationManager.AppSettings["ReportTitle"];
                reportRow["PublishSeri"] = ConfigurationManager.AppSettings["PublishSeri"];
                reportRow["PublishVer"] = ConfigurationManager.AppSettings["PublishVer"];
                reportRow["PublishDate"] = ConfigurationManager.AppSettings["PublishDate"];

                reportRow["SerialNumber"] = vehicleDetails["SerialNumber"].ToString();
                reportRow["FrameNumber"] = vehicleDetails["FrameNumber"].ToString();
                reportRow["VehicleType"] = vehicleDetails["VehicleType"].ToString();
                reportRow["Inspector"] = vehicleDetails["Inspector"].ToString();
                reportRow["InspectionDate"] = Convert.ToDateTime(vehicleDetails["InspectionDate"]).ToShortDateString();
                reportRow["Fuel"] = vehicleDetails["Fuel"].ToString();
                reportRow["Color"] = vehicleDetails["Color"].ToString();
                reportRow["EngineType"] = vehicleDetails["EngineType"].ToString();

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
                reportRow["Lambda"] = ConvertToDecimal(vehicleDetails["Lambda"]).ToString("F3");
                reportRow["MinLamda"] = ConvertToDecimal(standard["MinLamda"]).ToString("F3");
                reportRow["MaxLamda"] = ConvertToDecimal(standard["MaxLamda"]).ToString("F3");

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
                reportRow["LHLVertical"] = ConvertToDecimal(vehicleDetails["LHLVertical"]).ToString("F1");
                reportRow["RHLVertical"] = ConvertToDecimal(vehicleDetails["RHLVertical"]).ToString("F1");
                reportRow["MinDiffVertiHB"] = ConvertToDecimal(standard["MinDiffVertiHB"]).ToString("F1");
                reportRow["MaxDiffVertiHB"] = ConvertToDecimal(standard["MaxDiffVertiHB"]).ToString("F1");
                reportRow["LHLHorizontal"] = ConvertToDecimal(vehicleDetails["LHLHorizontal"]).ToString("F1");
                reportRow["RHLHorizontal"] = ConvertToDecimal(vehicleDetails["RHLHorizontal"]).ToString("F1");
                reportRow["MinDiffHoriHB"] = ConvertToDecimal(standard["MinDiffHoriHB"]).ToString("F1");
                reportRow["MaxDiffHoriHB"] = ConvertToDecimal(standard["MaxDiffHoriHB"]).ToString("F1");
                reportRow["LHBHeight"] = ConvertToDecimal(vehicleDetails["LHBHeight"]).ToString("F0");
                reportRow["RHBHeight"] = ConvertToDecimal(vehicleDetails["RHBHeight"]).ToString("F0");

                reportRow["LLBIntensity"] = ConvertToDecimal(vehicleDetails["LLBIntensity"]).ToString("F0");
                reportRow["RLBIntensity"] = ConvertToDecimal(vehicleDetails["RLBIntensity"]).ToString("F0");
                reportRow["MinLBIntensity"] = ConvertToDecimal(standard["MinLBIntensity"]).ToString("F0");
                reportRow["LLBVertical"] = ConvertToDecimal(vehicleDetails["LLBVertical"]).ToString("F1");
                reportRow["RLBVertical"] = ConvertToDecimal(vehicleDetails["RLBVertical"]).ToString("F1");
                reportRow["MinDiffVertiLB"] = ConvertToDecimal(standard["MinDiffVertiLB"]).ToString("F1");
                reportRow["MaxDiffVertiLB"] = ConvertToDecimal(standard["MaxDiffVertiLB"]).ToString("F1");
                reportRow["LLBHorizontal"] = ConvertToDecimal(vehicleDetails["LLBHorizontal"]).ToString("F1");
                reportRow["RLBHorizontal"] = ConvertToDecimal(vehicleDetails["RLBHorizontal"]).ToString("F1");
                reportRow["MinDiffHoriLB"] = ConvertToDecimal(standard["MinDiffHoriLB"]).ToString("F1");
                reportRow["MaxDiffHoriLB"] = ConvertToDecimal(standard["MaxDiffHoriLB"]).ToString("F1");

                reportRow["LFLIntensity"] = ConvertToDecimal(vehicleDetails["LFLIntensity"]).ToString("F1");
                reportRow["RFLIntensity"] = ConvertToDecimal(vehicleDetails["RFLIntensity"]).ToString("F1");
                reportRow["MinFLIntensity"] = ConvertToDecimal(standard["MinFLIntensity"]).ToString("F3");
                reportRow["MaxFLIntensity"] = ConvertToDecimal(standard["MaxFLIntensity"]).ToString("F1");
                reportRow["LFLVertical"] = ConvertToDecimal(vehicleDetails["LFLVertical"]).ToString("F1");
                reportRow["RFLVertical"] = ConvertToDecimal(vehicleDetails["RFLVertical"]).ToString("F1");
                reportRow["MinDiffVertiFL"] = ConvertToDecimal(standard["MinDiffVertiFL"]).ToString("F1");
                reportRow["MaxDiffVertiFL"] = ConvertToDecimal(standard["MaxDiffVertiFL"]).ToString("F1");
                reportRow["LFLHorizontal"] = ConvertToDecimal(vehicleDetails["LFLHorizontal"]).ToString("F1");
                reportRow["RFLHorizontal"] = ConvertToDecimal(vehicleDetails["RFLHorizontal"]).ToString("F1");
                reportRow["MinDiffHoriFL"] = ConvertToDecimal(standard["MinDiffHoriFL"]).ToString("F1");
                reportRow["MaxDiffHoriFL"] = ConvertToDecimal(standard["MaxDiffHoriFL"]).ToString("F1");
                reportRow["DiffVertiFLRange"] = FormatRange(minDiffVertiFL, maxDiffVertiFL, "F1");
                reportRow["DiffHoriFLRange"] = FormatRange(minDiffHoriFL, maxDiffHoriFL, "F1");

                reportRow["MinSpeed1"] = ConvertToDecimal(vehicleDetails["MinSpeed1"]).ToString("F1");
                reportRow["MaxSpeed1"] = ConvertToDecimal(vehicleDetails["MaxSpeed1"]).ToString("F1");
                reportRow["HSU1"] = ConvertToDecimal(hsu1).ToString("F2");
                reportRow["MinSpeed2"] = ConvertToDecimal(vehicleDetails["MinSpeed2"]).ToString("F1");
                reportRow["MaxSpeed2"] = ConvertToDecimal(vehicleDetails["MaxSpeed2"]).ToString("F1");
                reportRow["HSU2"] = ConvertToDecimal(hsu2).ToString("F2");
                reportRow["MinSpeed3"] = ConvertToDecimal(vehicleDetails["MinSpeed3"]).ToString("F1");
                reportRow["MaxSpeed3"] = ConvertToDecimal(vehicleDetails["MaxSpeed3"]).ToString("F1");
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

                reportRow["MinLightHeight"] = ConvertToDecimal(standard["MinLightHeight"]).ToString("F0");
                reportRow["MaxLightHeight"] = ConvertToDecimal(standard["MaxLightHeight"]).ToString("F0");

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
        private decimal? TryParseDecimal(object value)
        {
            if (value != null && decimal.TryParse(value.ToString(), out decimal result))
                return result;
            return null;
        }
        private string FormatRange(decimal? min, decimal? max, string format = "F0")
        {
            if (min.HasValue && max.HasValue)
                return $"{min.Value.ToString(format)} ÷ {max.Value.ToString(format)}";
            else if (min.HasValue)
                return $"≥ {min.Value.ToString(format)}";
            else if (max.HasValue)
                return $"≤ {max.Value.ToString(format)}";
            else
                return "    ÷    ";
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
                    decimal? lhlHeight = GetDecimalFromTextBox(txtLHLHeight);
                    decimal? rhlIntensity = GetDecimalFromTextBox(txtRHLIntensity);
                    decimal? rhlVertical = GetDecimalFromTextBox(txtRHLVertical);
                    decimal? rhlHorizontal = GetDecimalFromTextBox(txtRHLHorizontal);
                    decimal? rhlHeight = GetDecimalFromTextBox(txtRHLHeight);
                    decimal? llbIntensity = GetDecimalFromTextBox(txtLLBIntensity);
                    decimal? llbVertical = GetDecimalFromTextBox(txtLLBVertical);
                    decimal? llbHorizontal = GetDecimalFromTextBox(txtLLBHorizontal);
                    decimal? llbHeight = GetDecimalFromTextBox(txtLLBHeight);
                    decimal? rlbIntensity = GetDecimalFromTextBox(txtRLBIntensity);
                    decimal? rlbVertical = GetDecimalFromTextBox(txtRLBVertical);
                    decimal? rlbHorizontal = GetDecimalFromTextBox(txtRLBHorizontal);
                    decimal? rlbHeight = GetDecimalFromTextBox(txtRLBHeight);
                    decimal? lflIntensity = GetDecimalFromTextBox(txtLFLIntensity);
                    decimal? lflVertical = GetDecimalFromTextBox(txtLFLVertical);
                    decimal? lflHorizontal = GetDecimalFromTextBox(txtLFLHorizontal);
                    decimal? lflHeight = GetDecimalFromTextBox(txtLFLHeight);
                    decimal? rflIntensity = GetDecimalFromTextBox(txtRFLIntensity);
                    decimal? rflVertical = GetDecimalFromTextBox(txtRFLVertical);
                    decimal? rflHorizontal = GetDecimalFromTextBox(txtRFLHorizontal);
                    decimal? rflHeight = GetDecimalFromTextBox(txtRFLHeight);
                    decimal? hc = GetDecimalFromTextBox(txtHC);
                    decimal? co = GetDecimalFromTextBox(txtCO);
                    decimal? co2 = GetDecimalFromTextBox(txtCO2);
                    decimal? o2 = GetDecimalFromTextBox(txtO2);
                    decimal? no = GetDecimalFromTextBox(txtNO);
                    decimal? oilTemp = GetDecimalFromTextBox(txtOT);
                    decimal? rpm = GetDecimalFromTextBox(txtRPM);
                    decimal? lambda = GetDecimalFromTextBox(txtLamda);
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
                    sqlHelper.UpdateSteerAngle(serialNumber, leftSteerLW, leftSteerRW, rightSteerLW, rightSteerRW);
                    sqlHelper.UpdateBrakeForce(serialNumber, frontLeftBrake, frontRightBrake, rearLeftBrake, rearRightBrake, handBrakeLeft, handBrakeRight);
                    sqlHelper.UpdateNoise(serialNumber, noise, whistle);
                    sqlHelper.UpdateHeadlights(serialNumber, lhlIntensity, lhlVertical, lhlHorizontal, lhlHeight,
                        rhlIntensity, rhlVertical, rhlHorizontal, lhlHeight,
                        llbIntensity, llbVertical, llbHorizontal, llbHeight,
                        rlbIntensity, rlbVertical, rlbHorizontal, rlbHeight,
                    lflIntensity, lflVertical, lflHorizontal, lflHeight,
                    rflIntensity, rflVertical, rflHorizontal, rflHeight);
                    sqlHelper.UpdateGasEmissionPetrol(serialNumber, hc, co, co2, o2, no, oilTemp, rpm, lambda);
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
            txtSpeed.ReadOnly = !enable;
            txtSideSlip.ReadOnly = !enable;
            txtNoise.ReadOnly = !enable;
            txtWhistle.ReadOnly = !enable;
            txtHC.ReadOnly = !enable;
            txtCO.ReadOnly = !enable;
            txtCO2.ReadOnly = !enable;
            txtO2.ReadOnly = !enable;
            txtNO.ReadOnly = !enable;
            txtOT.ReadOnly = !enable;
            txtRPM.ReadOnly = !enable;
            txtLamda.ReadOnly = !enable;
            txtLeftSteerLW.ReadOnly = !enable;
            txtLeftSteerRW.ReadOnly = !enable;
            txtRightSteerLW.ReadOnly = !enable;
            txtRightSteerRW.ReadOnly = !enable;
            txtFrontLeftBrake.ReadOnly = !enable;
            txtFrontRightBrake.ReadOnly = !enable;
            txtRearLeftBrake.ReadOnly = !enable;
            txtRearRightBrake.ReadOnly = !enable;
            txtHandLeftBrake.ReadOnly = !enable;
            txtHandRightBrake.ReadOnly = !enable;
            txtLHLIntensity.ReadOnly = !enable;
            txtLHLVertical.ReadOnly = !enable;
            txtLHLHorizontal.ReadOnly = !enable;
            txtLHLHeight.ReadOnly = !enable;
            txtRHLIntensity.ReadOnly = !enable;
            txtRHLVertical.ReadOnly = !enable;
            txtRHLHorizontal.ReadOnly = !enable;
            txtRHLHeight.ReadOnly = !enable;
            txtLLBIntensity.ReadOnly = !enable;
            txtLLBVertical.ReadOnly = !enable;
            txtLLBHorizontal.ReadOnly = !enable;
            txtLLBHeight.ReadOnly = !enable;
            txtRLBIntensity.ReadOnly = !enable;
            txtRLBVertical.ReadOnly = !enable;
            txtRLBHorizontal.ReadOnly = !enable;
            txtRLBHeight.ReadOnly = !enable;
            txtLFLIntensity.ReadOnly = !enable;
            txtLFLVertical.ReadOnly = !enable;
            txtLFLHorizontal.ReadOnly = !enable;
            txtLFLHeight.ReadOnly = !enable;
            txtRFLIntensity.ReadOnly = !enable;
            txtRFLVertical.ReadOnly = !enable;
            txtRFLHorizontal.ReadOnly = !enable;
            txtRFLHeight.ReadOnly = !enable;
            txtMinSpeed1.ReadOnly = !enable;
            txtMaxSpeed1.ReadOnly = !enable;
            txtMinSpeed2.ReadOnly = !enable;
            txtMaxSpeed2.ReadOnly = !enable;
            txtMinSpeed3.ReadOnly = !enable;
            txtMaxSpeed3.ReadOnly = !enable;
            txtHSU1.ReadOnly = !enable;
            txtHSU2.ReadOnly = !enable;
            txtHSU3.ReadOnly = !enable;
        }
        public void EnableEditButton()
        {
            btnEditSave.Visible = true; // Hiển thị nút "Chỉnh sửa"
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            btnEditSave.Visible = false; // Ẩn nút "Chỉnh sửa" khi mở form
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
