using Microsoft.Extensions.Logging;
using SenAIS.Core;
using SenAIS.Core.Logging;
using SenAIS.Core.Repositories;
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
        private readonly VehicleRepository vehicleRepo = new VehicleRepository();
        private readonly StandardRepository standardRepo = new StandardRepository();
        private readonly InspectionRepository inspectionRepo = new InspectionRepository();
        private VehicleStandard vehicleStandard;
        private string serialNumber;
        private static bool isEditButtonEnabled = false;
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
            if (!string.IsNullOrEmpty(serialNumber))
            {
                DisplayVehicleDetails(serialNumber);
            }
        }
        public frmReport()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                DataTable results = vehicleRepo.Search(searchTerm);
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
            ClearTextBoxes();
            var vehicle = vehicleRepo.GetVehicleDetails(serialNumber);
            if (vehicle != null)
            {
                txtSerialNum.Text = vehicle.SerialNumber;
                txtFrameNum.Text = vehicle.FrameNumber;
                txtTypeCar.Text = vehicle.VehicleType;
                txtInspector.Text = vehicle.Inspector;
                txtDateInspec.Text = vehicle.InspectionDate?.ToString("dd/MM/yyyy HH:mm");

                // Tốc độ & trượt ngang
                txtSpeed.Text = vehicle.Speeds?.FirstOrDefault()?.Speed1?.ToString();
                txtSideSlip.Text = vehicle.SideSlips?.FirstOrDefault()?.SideSlip1?.ToString();

                // Độ ồn
                var noise = vehicle.Noises?.FirstOrDefault();
                txtNoise.Text = noise?.Noise1?.ToString();
                txtWhistle.Text = noise?.Whistle?.ToString();

                // Khí xả xăng
                var petrol = vehicle.GasEmission_Petrol?.FirstOrDefault();
                txtHC.Text = petrol?.HC?.ToString();
                txtCO.Text = petrol?.CO?.ToString();
                txtCO2.Text = petrol?.CO2?.ToString();
                txtO2.Text = petrol?.O2?.ToString();
                txtNO.Text = petrol?.NO?.ToString();
                txtOT.Text = petrol?.OilTemp?.ToString();
                txtRPM.Text = petrol?.RPM?.ToString();

                // Trọng lượng
                var weight = vehicle.Weights?.FirstOrDefault();
                txtFrontLeftWeight.Text = weight?.FrontLeftWeight?.ToString();
                txtFrontRightWeight.Text = weight?.FrontRightWeight?.ToString();
                if (!string.IsNullOrWhiteSpace(txtFrontLeftWeight.Text) && !string.IsNullOrWhiteSpace(txtFrontRightWeight.Text))
                {
                    CalculateAndDisplaySum(txtFrontLeftWeight, txtFrontRightWeight, txtFrontSumWeight);
                }
                else
                {
                    txtFrontSumWeight.Text = string.Empty;
                }
                txtRearLeftWeight.Text = weight?.RearLeftWeight?.ToString();
                txtRearRightWeight.Text = weight?.RearRightWeight?.ToString();
                if (!string.IsNullOrWhiteSpace(txtRearLeftWeight.Text) && !string.IsNullOrWhiteSpace(txtRearRightWeight.Text))
                {
                    CalculateAndDisplaySum(txtRearLeftWeight, txtRearRightWeight, txtRearSumWeight);
                }
                else
                {
                    txtRearSumWeight.Text = string.Empty;
                }

                // Lực phanh
                var brake = vehicle.BrakeForces?.FirstOrDefault();
                txtFrontLeftBrake.Text = brake?.FrontLeftBrake?.ToString();
                txtFrontRightBrake.Text = brake?.FrontRightBrake?.ToString();
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
                txtRearLeftBrake.Text = brake?.RearLeftBrake?.ToString();
                txtRearRightBrake.Text = brake?.RearRightBrake?.ToString();
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
                txtHandLeftBrake.Text = brake?.HandBrakeLeft?.ToString();
                txtHandRightBrake.Text = brake?.HandBrakeRight?.ToString();
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

                // Đèn pha/cốt
                var hl = vehicle.Headlights?.FirstOrDefault();
                txtLHLIntensity.Text = hl?.LeftHBIntensity?.ToString();
                txtLHLVertical.Text = hl?.LeftHBVerticalDeviation?.ToString();
                txtLHLHorizontal.Text = hl?.LeftHBHorizontalDeviation?.ToString();
                txtRHLIntensity.Text = hl?.RightHBIntensity?.ToString();
                txtRHLVertical.Text = hl?.RightHBVerticalDeviation?.ToString();
                txtRHLHorizontal.Text = hl?.RightHBHorizontalDeviation?.ToString();
                txtLLBIntensity.Text = hl?.LeftLBIntensity?.ToString();
                txtLLBVertical.Text = hl?.LeftLBVerticalDeviation?.ToString();
                txtLLBHorizontal.Text = hl?.LeftLBHorizontalDeviation?.ToString();
                txtRLBIntensity.Text = hl?.RightLBIntensity?.ToString();
                txtRLBVertical.Text = hl?.RightLBVerticalDeviation?.ToString();
                txtRLBHorizontal.Text = hl?.RightLBHorizontalDeviation?.ToString();

                // Khói Diesel
                var diesel = vehicle.GasEmission_Diesel?.FirstOrDefault();
                txtMinSpeed1.Text = diesel?.MinSpeed1?.ToString();
                txtMaxSpeed1.Text = diesel?.MaxSpeed1?.ToString();
                txtMinSpeed2.Text = diesel?.MinSpeed2?.ToString();
                txtMaxSpeed2.Text = diesel?.MaxSpeed2?.ToString();
                txtMinSpeed3.Text = diesel?.MinSpeed3?.ToString();
                txtMaxSpeed3.Text = diesel?.MaxSpeed3?.ToString();
                txtHSU1.Text = diesel?.HSU1?.ToString();
                txtHSU2.Text = diesel?.HSU2?.ToString();
                txtHSU3.Text = diesel?.HSU3?.ToString();

                // Góc lái
                var steer = vehicle.SteerAngles?.FirstOrDefault();
                txtLeftSteerLW.Text = steer?.LeftSteerLW?.ToString();
                txtLeftSteerRW.Text = steer?.LeftSteerRW?.ToString();
                txtRightSteerLW.Text = steer?.RightSteerLW?.ToString();
                txtRightSteerRW.Text = steer?.RightSteerRW?.ToString();

                // Đánh giá
                EvaluateMeasurements();
                EvaluateBrakeEfficiencyAndColor();
            }
            else
            {
                // Xử lý khi không có dữ liệu trả về (có thể xóa sạch các TextBox nếu cần)
                ClearTextBoxes();
            }
        }
        private void EvaluateBrakeEfficiencyAndColor()
        {
            if (vehicleStandard == null)
                return;

            // Lấy giá trị tối thiểu từ entity VehicleStandard (nếu có), nếu không có thì mặc định 0
            decimal minFrontBrake = GetDecimalPropertyValue(vehicleStandard, "MinFrontBrake") ?? 0;
            decimal minRearBrake = GetDecimalPropertyValue(vehicleStandard, "MinRearBrake") ?? 0;
            decimal minHandBrake = GetDecimalPropertyValue(vehicleStandard, "MinHandBrake") ?? 0;

            // Đánh giá hiệu quả phanh riêng (không can thiệp vào CheckStandard đã dùng cho MinBrake)
            CheckBrakeEfficiencyOnly(txtFrontSumBrake, minFrontBrake);
            CheckBrakeEfficiencyOnly(txtRearSumBrake, minRearBrake);
            CheckBrakeEfficiencyOnly(txtHandSumBrake, minHandBrake);
        }
        private void CheckBrakeEfficiencyOnly(TextBox sumBrakeBox, decimal minBrake)
        {
            if (string.IsNullOrWhiteSpace(sumBrakeBox.Text) || minBrake <= 0)
            {
                return;
            }

            if (!decimal.TryParse(sumBrakeBox.Text, out decimal sumBrake))
            {
                return;
            }

            // Xác định hệ số và ngưỡng hiệu quả phù hợp
            decimal factor;
            decimal minEff;
            decimal maxEff = 100;

            if (sumBrakeBox.Name == "txtHandSumBrake")
            {
                factor = 0.16m;
                minEff = 16;
            }
            else
            {
                factor = 0.5m;
                minEff = 50;
            }

            // Tính hiệu quả phanh theo công thức: (SumBrake / (Min / hệ số)) * 100
            decimal efficiency = (sumBrake * factor / minBrake) * 100;

            // Đổi màu theo hiệu quả
            if (efficiency >= minEff && efficiency <= maxEff)
                sumBrakeBox.BackColor = Color.LightGreen;  // Đạt
            else
                sumBrakeBox.BackColor = Color.Gold;        // Không đạt
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

            // Lấy tiêu chuẩn từ DB thông qua Entity Framework
            vehicleStandard = standardRepo.GetVehicleStandardByTypeCar(txtTypeCar.Text);

            if (vehicleStandard != null)
            {
                foreach (var mapping in textBoxMappings)
                {
                    Control[] controls = this.Controls.Find(mapping.Key, true);
                    if (controls.Length > 0 && controls[0] is TextBox textBox)
                    {
                        decimal? minValue = mapping.Value.minField != null ? GetDecimalPropertyValue(vehicleStandard, mapping.Value.minField) : null;
                        decimal? maxValue = mapping.Value.maxField != null ? GetDecimalPropertyValue(vehicleStandard, mapping.Value.maxField) : null;

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
            reportDataTable.Columns.Add("MaxCO2", typeof(string));

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
            reportDataTable.Columns.Add("MainSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinSumBrake", typeof(decimal));

            reportDataTable.Columns.Add("FrontDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffFrontBrake", typeof(decimal));
            reportDataTable.Columns.Add("RearDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffRearBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinHandBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHandBrake", typeof(decimal));

            reportDataTable.Columns.Add("FrontBrakeEff", typeof(decimal));
            reportDataTable.Columns.Add("RearBrakeEff", typeof(decimal));
            reportDataTable.Columns.Add("SumBrakeEff", typeof(decimal));
            reportDataTable.Columns.Add("HandBrakeEff", typeof(decimal));

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
            reportDataTable.Columns.Add("HBIntensityRange", typeof(string));
            reportDataTable.Columns.Add("LBIntensityRange", typeof(string));
            reportDataTable.Columns.Add("DiffVertiHBRange", typeof(string));
            reportDataTable.Columns.Add("DiffHoriHBRange", typeof(string));
            reportDataTable.Columns.Add("DiffVertiLBRange", typeof(string));
            reportDataTable.Columns.Add("DiffHoriLBRange", typeof(string));


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
            var vehicle = vehicleRepo.GetVehicleDetails(serialNumber);

            if (vehicle != null)
            {
                // Gọi hàm GetVehicleStandardsByTypeCar để lấy tiêu chuẩn theo loại xe
                string vehicleType = vehicle.VehicleType;
                var standard = standardRepo.GetVehicleStandardByTypeCar(vehicleType);
                var weight = vehicle.Weights?.FirstOrDefault();
                var brake = vehicle.BrakeForces?.FirstOrDefault();
                var steer = vehicle.SteerAngles?.FirstOrDefault();
                var petrol = vehicle.GasEmission_Petrol?.FirstOrDefault();
                var diesel = vehicle.GasEmission_Diesel?.FirstOrDefault();
                var headlight = vehicle.Headlights?.FirstOrDefault();
                var noise = vehicle.Noises?.FirstOrDefault();
                var speed = vehicle.Speeds?.FirstOrDefault();
                var sideslip = vehicle.SideSlips?.FirstOrDefault();

                // Tính toán giá trị FrontSumWeight (tổng của FrontLeftWeight và FrontRightWeight)
                decimal frontLeftWeight = weight?.FrontLeftWeight ?? 0;
                decimal frontRightWeight = weight?.FrontRightWeight ?? 0;
                decimal frontSumWeight = frontLeftWeight + frontRightWeight;

                // Tính toán RearSumWeight (tổng của RearLeftWeight và RearRightWeight)
                decimal rearLeftWeight = weight?.RearLeftWeight ?? 0;
                decimal rearRightWeight = weight?.RearRightWeight ?? 0;
                decimal rearSumWeight = rearLeftWeight + rearRightWeight;

                decimal frontLeftBrake = brake?.FrontLeftBrake ?? 0;
                decimal frontRightBrake = brake?.FrontRightBrake ?? 0;
                decimal frontDiffBrake = ConvertToDecimal(txtFrontDiffBrake.Text);
                decimal frontSumBrake = frontLeftBrake + frontRightBrake;

                decimal rearLeftBrake = brake?.RearLeftBrake ?? 0;
                decimal rearRightBrake = brake?.RearRightBrake ?? 0;
                decimal rearDiffBrake = ConvertToDecimal(txtRearDiffBrake.Text);
                decimal rearSumBrake = rearLeftBrake + rearRightBrake;

                decimal handLeftBrake = brake?.HandBrakeLeft ?? 0;
                decimal handRightBrake = brake?.HandBrakeRight ?? 0;
                decimal handDiffBrake = ConvertToDecimal(txtHandDiffBrake.Text);
                decimal handSumBrake = handLeftBrake + handRightBrake;

                decimal mainBrake = frontSumBrake + rearSumBrake;

                // Min brake theo tiêu chuẩn
                decimal minFrontBrake = standard?.MinFrontBrake ?? 0;
                decimal minRearBrake = standard?.MinRearBrake ?? 0;
                decimal minHandBrake = standard?.MinHandBrake ?? 0;
                decimal minSumBrake = minFrontBrake + minRearBrake;

                // Brake efficiency: lực phanh chia trọng lượng
                decimal frontEfficiency = minFrontBrake != 0 ? (frontSumBrake * 0.5m / minFrontBrake) * 100 : 0;
                decimal rearEfficiency = minRearBrake != 0 ? (rearSumBrake * 0.5m / minRearBrake) * 100 : 0;
                decimal totalEfficiency = minSumBrake != 0 ? (mainBrake * 0.5m / minSumBrake) * 100 : 0;
                decimal handEfficiency = minSumBrake != 0 ? (handSumBrake * 0.16m / minHandBrake) * 100 : 0;

                // Lấy từ tiêu chuẩn
                decimal? minHB = standard?.MinHLIntensity;
                decimal? maxHB = standard?.MaxHBIntensity;
                decimal? minLB = standard?.MinLBIntensity;
                decimal? maxLB = standard?.MaxLBIntensity;

                decimal? minDiffVertiHB = standard?.MinDiffVertiHB;
                decimal? maxDiffVertiHB = standard?.MaxDiffVertiHB;
                decimal? minDiffHoriHB = standard?.MinDiffHoriHB;
                decimal? maxDiffHoriHB = standard?.MaxDiffHoriHB;
                decimal? minDiffVertiLB = standard?.MinDiffVertiLB;
                decimal? maxDiffVertiLB = standard?.MaxDiffVertiLB;
                decimal? minDiffHoriLB = standard?.MinDiffHoriLB;
                decimal? maxDiffHoriLB = standard?.MaxDiffHoriLB;

                decimal hsu1 = diesel?.HSU1 ?? 0;
                decimal hsu2 = diesel?.HSU2 ?? 0;
                decimal hsu3 = diesel?.HSU3 ?? 0;
                decimal avgHSU = (hsu1 + hsu2 + hsu3) / 3;

                // Tính toán kết quả cho các phần
                bool sideSlipResult = CheckStandard(vehicle.SideSlips?.FirstOrDefault()?.SideSlip1 ?? 0, standard?.MinSideSlip, standard?.MaxSideSlip);

                bool brakeResult = CheckStandard(frontSumBrake, standard?.MinFrontBrake, null)
                        && CheckStandard(rearSumBrake, standard?.MinRearBrake, null)
                        && CheckStandard(handSumBrake, standard?.MinHandBrake, null)
                        && CheckStandard(frontDiffBrake, null, standard?.MaxDiffFrontBrake)
                        && CheckStandard(rearDiffBrake, null, standard?.MaxDiffRearBrake)
                        && CheckStandard(handDiffBrake, null, standard?.MaxDiffHandBrake);

                bool steerAngleResult = CheckStandard(steer?.LeftSteerLW ?? 0, standard?.MinLeftSteer, standard?.MaxLeftSteer)
                    && CheckStandard(steer?.RightSteerLW ?? 0, standard?.MinRightSteer, standard?.MaxRightSteer);

                bool speedResult = CheckStandard(vehicle.Speeds?.FirstOrDefault()?.Speed1 ?? 0, standard?.MinSpeed, standard?.MaxSpeed);

                bool petrolResult = CheckStandard(petrol?.HC ?? 0, null, standard?.MaxHC)
                    && CheckStandard(petrol?.CO ?? 0, null, standard?.MaxCO);

                bool dieselResult = CheckStandard(avgHSU, null, standard?.MaxHSU);

                bool hlResult = CheckStandard(headlight?.LeftHBIntensity ?? 0, standard?.MinHLIntensity, standard?.MaxHBIntensity)
                    && CheckStandard(headlight?.RightHBIntensity ?? 0, standard?.MinHLIntensity, standard?.MaxHBIntensity)
                    && CheckStandard(headlight?.LeftHBHorizontalDeviation ?? 0, standard?.MinDiffHoriHB, standard?.MaxDiffHoriHB)
                    && CheckStandard(headlight?.RightHBHorizontalDeviation ?? 0, standard?.MinDiffHoriHB, standard?.MaxDiffHoriHB)
                    && CheckStandard(headlight?.LeftHBVerticalDeviation ?? 0, standard?.MinDiffVertiHB, standard?.MaxDiffVertiHB)
                    && CheckStandard(headlight?.RightHBVerticalDeviation ?? 0, standard?.MinDiffVertiHB, standard?.MaxDiffVertiHB)
                    && CheckStandard(headlight?.LeftLBIntensity ?? 0, standard?.MinLBIntensity, standard?.MaxLBIntensity)
                    && CheckStandard(headlight?.RightLBIntensity ?? 0, standard?.MinLBIntensity, standard?.MaxLBIntensity)
                    && CheckStandard(headlight?.LeftLBHorizontalDeviation ?? 0, standard?.MinDiffHoriLB, standard?.MaxDiffHoriLB)
                    && CheckStandard(headlight?.RightLBHorizontalDeviation ?? 0, standard?.MinDiffHoriLB, standard?.MaxDiffHoriLB)
                    && CheckStandard(headlight?.LeftLBVerticalDeviation ?? 0, standard?.MinDiffVertiLB, standard?.MaxDiffVertiLB)
                    && CheckStandard(headlight?.RightLBVerticalDeviation ?? 0, standard?.MinDiffVertiLB, standard?.MaxDiffVertiLB);

                bool noiseResult = CheckStandard(noise?.Noise1 ?? 0, null, standard?.MaxNoise);
                bool whistleResult = CheckStandard(noise?.Whistle ?? 0, standard?.MinWhistle, standard?.MaxWhistle);

                string engineType = vehicle.Fuel;
                bool engineResult = (engineType == "Xăng") ? petrolResult : (engineType == "Dầu") ? dieselResult : false;

                bool finalResult = sideSlipResult && brakeResult && speedResult && steerAngleResult &&
                                   engineResult && hlResult && noiseResult && whistleResult;

                // Thêm dữ liệu vào DataTable
                DataRow reportRow = reportDataTable.NewRow();

                reportRow["PublishSeri"] = ConfigurationManager.AppSettings["PublishSeri"];
                reportRow["PublishVer"] = ConfigurationManager.AppSettings["PublishVer"];
                reportRow["PublishDate"] = ConfigurationManager.AppSettings["PublishDate"];

                reportRow["SerialNumber"] = vehicle.SerialNumber;
                reportRow["FrameNumber"] = vehicle.FrameNumber;
                reportRow["VehicleType"] = vehicle.VehicleType;
                reportRow["Inspector"] = vehicle.Inspector;
                reportRow["InspectionDate"] = vehicle.InspectionDate?.ToShortDateString();
                reportRow["Fuel"] = vehicle.Fuel;

                reportRow["Speed"] = FormatOrDbNull(speed?.Speed1, 1);
                reportRow["MinSpeed"] = FormatOrDbNull(standard?.MinSpeed, 1);
                reportRow["MaxSpeed"] = FormatOrDbNull(standard?.MaxSpeed, 1);

                reportRow["SideSlip"] = FormatOrDbNull(sideslip?.SideSlip1, 1);
                reportRow["MinSideSlip"] = FormatOrDbNull(standard?.MinSideSlip, 1);
                reportRow["MaxSideSlip"] = FormatOrDbNull(standard?.MaxSideSlip, 1);

                reportRow["Noise"] = FormatOrDbNull(noise?.Noise1, 1);
                reportRow["MaxNoise"] = FormatOrDbNull(standard?.MaxNoise, 1);
                reportRow["Whistle"] = FormatOrDbNull(noise?.Whistle, 1);
                reportRow["MinWhistle"] = FormatOrDbNull(standard?.MinWhistle, 1);
                reportRow["MaxWhistle"] = FormatOrDbNull(standard?.MaxWhistle, 1);

                reportRow["HC"] = FormatOrDbNull(petrol?.HC, 1);
                reportRow["MaxHC"] = FormatOrDbNull(standard?.MaxHC, 1);
                reportRow["CO"] = FormatOrDbNull(petrol?.CO, 2);
                reportRow["MaxCO"] = FormatOrDbNull(standard?.MaxCO, 2);
                reportRow["CO2"] = FormatOrDbNull(petrol?.CO2, 2);
                reportRow["MaxCO2"] = FormatOrDbNull(standard?.MaxCO2, 2);
                reportRow["O2"] = FormatOrDbNull(petrol?.O2, 2);
                reportRow["MaxO2"] = FormatOrDbNull(standard?.MaxO2, 2);
                reportRow["NO"] = FormatOrDbNull(petrol?.NO, 2);
                reportRow["MaxNO"] = FormatOrDbNull(standard?.MaxNO, 2);
                reportRow["OilTemp"] = FormatOrDbNull(petrol?.OilTemp, 1);
                reportRow["RPM"] = FormatOrDbNull(petrol?.RPM, 1);

                reportRow["FrontLeftWeight"] = FormatOrDbNull(weight?.FrontLeftWeight, 1);
                reportRow["FrontRightWeight"] = FormatOrDbNull(weight?.FrontRightWeight, 1);
                reportRow["FrontSumWeight"] = FormatOrDbNull(
                    (weight?.FrontLeftWeight ?? 0) + (weight?.FrontRightWeight ?? 0), 1);
                reportRow["RearLeftWeight"] = FormatOrDbNull(weight?.RearLeftWeight, 1);
                reportRow["RearRightWeight"] = FormatOrDbNull(weight?.RearRightWeight, 1);
                reportRow["RearSumWeight"] = FormatOrDbNull(
                    (weight?.RearLeftWeight ?? 0) + (weight?.RearRightWeight ?? 0), 1);

                reportRow["FrontLeftBrake"] = FormatOrDbNull(frontLeftBrake, 1);
                reportRow["FrontRightBrake"] = FormatOrDbNull(frontRightBrake, 1);
                reportRow["FrontDiffBrake"] = FormatOrDbNull(frontDiffBrake, 2);
                reportRow["MaxDiffFrontBrake"] = FormatOrDbNull(standard?.MaxDiffFrontBrake, 1);
                reportRow["FrontSumBrake"] = FormatOrDbNull(frontSumBrake, 1);
                reportRow["MinFrontBrake"] = FormatOrDbNull(standard?.MinFrontBrake, 1);

                reportRow["RearLeftBrake"] = FormatOrDbNull(rearLeftBrake, 1);
                reportRow["RearRightBrake"] = FormatOrDbNull(rearRightBrake, 1);
                reportRow["RearDiffBrake"] = FormatOrDbNull(rearDiffBrake, 2);
                reportRow["MaxDiffRearBrake"] = FormatOrDbNull(standard?.MaxDiffRearBrake, 1);
                reportRow["RearSumBrake"] = FormatOrDbNull(rearSumBrake, 1);
                reportRow["MinRearBrake"] = FormatOrDbNull(standard?.MinRearBrake, 1);

                reportRow["HandLeftBrake"] = FormatOrDbNull(handLeftBrake, 1);
                reportRow["HandRightBrake"] = FormatOrDbNull(handRightBrake, 1);
                reportRow["HandDiffBrake"] = FormatOrDbNull(handDiffBrake, 2);
                reportRow["MaxDiffHandBrake"] = FormatOrDbNull(standard?.MaxDiffHandBrake, 1);
                reportRow["HandSumBrake"] = FormatOrDbNull(handSumBrake, 1);
                reportRow["MinHandBrake"] = FormatOrDbNull(standard?.MinHandBrake, 1);

                reportRow["MainSumBrake"] = FormatOrDbNull(mainBrake, 1);
                reportRow["MinSumBrake"] = FormatOrDbNull(minSumBrake, 1);
                reportRow["FrontBrakeEff"] = FormatOrDbNull(frontEfficiency, 2);
                reportRow["RearBrakeEff"] = FormatOrDbNull(rearEfficiency, 2);
                reportRow["SumBrakeEff"] = FormatOrDbNull(totalEfficiency, 2);
                reportRow["HandBrakeEff"] = FormatOrDbNull(handEfficiency, 2);

                reportRow["LHLIntensity"] = FormatOrDbNull(headlight?.LeftHBIntensity, 1);
                reportRow["RHLIntensity"] = FormatOrDbNull(headlight?.RightHBIntensity, 1);
                reportRow["MinHLIntensity"] = FormatOrDbNull(standard?.MinHLIntensity, 1);
                reportRow["MaxHBIntensity"] = FormatOrDbNull(standard?.MaxHBIntensity, 1);

                reportRow["LHLVertical"] = FormatOrDbNull(headlight?.LeftHBVerticalDeviation, 2);
                reportRow["RHLVertical"] = FormatOrDbNull(headlight?.RightHBVerticalDeviation, 2);
                reportRow["MinDiffVertiHB"] = FormatOrDbNull(standard?.MinDiffVertiHB, 2);
                reportRow["MaxDiffVertiHB"] = FormatOrDbNull(standard?.MaxDiffVertiHB, 2);

                reportRow["LHLHorizontal"] = FormatOrDbNull(headlight?.LeftHBHorizontalDeviation, 2);
                reportRow["RHLHorizontal"] = FormatOrDbNull(headlight?.RightHBHorizontalDeviation, 2);
                reportRow["MinDiffHoriHB"] = FormatOrDbNull(standard?.MinDiffHoriHB, 2);
                reportRow["MaxDiffHoriHB"] = FormatOrDbNull(standard?.MaxDiffHoriHB, 2);

                reportRow["LLBIntensity"] = FormatOrDbNull(headlight?.LeftLBIntensity, 1);
                reportRow["RLBIntensity"] = FormatOrDbNull(headlight?.RightLBIntensity, 1);
                reportRow["MinLBIntensity"] = FormatOrDbNull(standard?.MinLBIntensity, 1);
                reportRow["MaxLBIntensity"] = FormatOrDbNull(standard?.MaxLBIntensity, 1);

                reportRow["LLBVertical"] = FormatOrDbNull(headlight?.LeftLBVerticalDeviation, 2);
                reportRow["RLBVertical"] = FormatOrDbNull(headlight?.RightLBVerticalDeviation, 2);
                reportRow["MinDiffVertiLB"] = FormatOrDbNull(standard?.MinDiffVertiLB, 2);
                reportRow["MaxDiffVertiLB"] = FormatOrDbNull(standard?.MaxDiffVertiLB, 2);

                reportRow["LLBHorizontal"] = FormatOrDbNull(headlight?.LeftLBHorizontalDeviation, 2);
                reportRow["RLBHorizontal"] = FormatOrDbNull(headlight?.RightLBHorizontalDeviation, 2);
                reportRow["MinDiffHoriLB"] = FormatOrDbNull(standard?.MinDiffHoriLB, 2);
                reportRow["MaxDiffHoriLB"] = FormatOrDbNull(standard?.MaxDiffHoriLB, 2);

                reportRow["HBIntensityRange"] = FormatRange(minHB, maxHB, "F0");
                reportRow["LBIntensityRange"] = FormatRange(minLB, maxLB, "F0");
                reportRow["DiffVertiHBRange"] = FormatRange(minDiffVertiHB, maxDiffVertiHB, "F2");
                reportRow["DiffHoriHBRange"] = FormatRange(minDiffHoriHB, maxDiffHoriHB, "F2");
                reportRow["DiffVertiLBRange"] = FormatRange(minDiffVertiLB, maxDiffVertiLB, "F2");
                reportRow["DiffHoriLBRange"] = FormatRange(minDiffHoriLB, maxDiffHoriLB, "F2");

                reportRow["MinSpeed1"] = FormatOrDbNull(diesel?.MinSpeed1, 0);
                reportRow["MaxSpeed1"] = FormatOrDbNull(diesel?.MaxSpeed1, 0);
                reportRow["HSU1"] = FormatOrDbNull(diesel?.HSU1, 2);

                reportRow["MinSpeed2"] = FormatOrDbNull(diesel?.MinSpeed2, 0);
                reportRow["MaxSpeed2"] = FormatOrDbNull(diesel?.MaxSpeed2, 0);
                reportRow["HSU2"] = FormatOrDbNull(diesel?.HSU2, 2);

                reportRow["MinSpeed3"] = FormatOrDbNull(diesel?.MinSpeed3, 0);
                reportRow["MaxSpeed3"] = FormatOrDbNull(diesel?.MaxSpeed3, 0);
                reportRow["HSU3"] = FormatOrDbNull(diesel?.HSU3, 2);

                reportRow["AvgHSU"] = FormatOrDbNull(avgHSU, 2);
                reportRow["MaxHSU"] = FormatOrDbNull(standard?.MaxHSU, 2);

                reportRow["LeftSteerLW"] = FormatOrDbNull(steer?.LeftSteerLW, 2);
                reportRow["LeftSteerRW"] = FormatOrDbNull(steer?.LeftSteerRW, 2);
                reportRow["MinLeftSteer"] = FormatOrDbNull(standard?.MinLeftSteer, 2);
                reportRow["MaxLeftSteer"] = FormatOrDbNull(standard?.MaxLeftSteer, 2);

                reportRow["RightSteerLW"] = FormatOrDbNull(steer?.RightSteerLW, 2);
                reportRow["RightSteerRW"] = FormatOrDbNull(steer?.RightSteerRW, 2);
                reportRow["MinRightSteer"] = FormatOrDbNull(standard?.MinRightSteer, 2);
                reportRow["MaxRightSteer"] = FormatOrDbNull(standard?.MaxRightSteer, 2);

                reportRow["MinLightHeight"] = FormatOrDbNull(standard?.MinLightHeight, 1);

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
        private object FormatOrDbNull(decimal? value, int digits = 1)
        {
            return value.HasValue ? (object)Math.Round(value.Value, digits) : DBNull.Value;
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
                return $"[ {min.Value.ToString(format)} ÷ {max.Value.ToString(format)} ]";
            else if (min.HasValue)
                return $"≥ {min.Value.ToString(format)}";
            else if (max.HasValue)
                return $"≤ {max.Value.ToString(format)}";
            else
                return "[    ÷    ]";
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
                    inspectionRepo.UpdateSpeed(serialNumber, speed);
                    inspectionRepo.UpdateSideSlip(serialNumber, sideSlip);
                    inspectionRepo.UpdateWeight(serialNumber, frontLeftWeight, frontRightWeight, rearLeftWeight, rearRightWeight);
                    inspectionRepo.UpdateSteerAngle(serialNumber, leftSteerLW, leftSteerRW, rightSteerLW, rightSteerRW);
                    inspectionRepo.UpdateBrakeForce(serialNumber, frontLeftBrake, frontRightBrake, rearLeftBrake, rearRightBrake, handBrakeLeft, handBrakeRight);
                    inspectionRepo.UpdateNoise(serialNumber, noise, whistle);
                    inspectionRepo.UpdateHeadlights(serialNumber, lhlIntensity, lhlVertical, lhlHorizontal, rhlIntensity, rhlVertical, rhlHorizontal, llbIntensity, llbVertical, llbHorizontal, rlbIntensity, rlbVertical, rlbHorizontal);
                    inspectionRepo.UpdateGasEmissionPetrol(serialNumber, hc, co, co2, o2, no, oilTemp, rpm);
                    inspectionRepo.UpdateGasEmissionDiesel(serialNumber, minSpeed1, maxSpeed1, hsu1, minSpeed2, maxSpeed2, hsu2, minSpeed3, maxSpeed3, hsu3);

                    MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEditSave.Text = "Chỉnh sửa";
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
                if (vehicleStandard == null)
                {
                    vehicleStandard = standardRepo.GetVehicleStandardByTypeCar(txtTypeCar.Text);
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
                        if (vehicleStandard != null)
                        {
                            decimal minFrontBrake = vehicleStandard.MinFrontBrake ?? 0;
                            CheckBrakeEfficiencyOnly(txtFrontSumBrake, minFrontBrake);
                        }
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
                        if (vehicleStandard != null)
                        {
                            decimal minRearBrake = vehicleStandard.MinRearBrake ?? 0;
                            CheckBrakeEfficiencyOnly(txtRearSumBrake, minRearBrake); // kiểm tra hiệu quả riêng
                        }
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
                        if (vehicleStandard != null)
                        {
                            decimal minHandBrake = vehicleStandard.MinHandBrake ?? 0;
                            CheckBrakeEfficiencyOnly(txtHandSumBrake, minHandBrake); // kiểm tra hiệu quả phanh tay
                        }
                        CheckStandard(txtHandDiffBrake);
                    }
                }
                else
                {
                    // Kiểm tra bình thường với các TextBox còn lại
                    if (vehicleStandard != null && textBoxMappings.TryGetValue(txtBox.Name, out var mapping))
                    {
                        decimal? minValue = mapping.minField != null ? GetDecimalPropertyValue(vehicleStandard, mapping.minField) : null;
                        decimal? maxValue = mapping.maxField != null ? GetDecimalPropertyValue(vehicleStandard, mapping.maxField) : null;

                        CheckAndColorTextBox(txtBox, minValue, maxValue);
                    }
                }
            }
        }
        private decimal? GetDecimalPropertyValue(VehicleStandard standard, string propertyName)
        {
            var prop = typeof(VehicleStandard).GetProperty(propertyName);
            if (prop != null)
            {
                var value = prop.GetValue(standard);
                return value != null ? (decimal?)Convert.ToDecimal(value) : null;
            }
            return null;
        }
        private void CheckStandard(TextBox txtBox)
        {
            if (vehicleStandard != null && textBoxMappings.TryGetValue(txtBox.Name, out var mapping))
            {
                decimal? minValue = mapping.minField != null ? GetDecimalPropertyValue(vehicleStandard, mapping.minField) : null;
                decimal? maxValue = mapping.maxField != null ? GetDecimalPropertyValue(vehicleStandard, mapping.maxField) : null;

                CheckAndColorTextBox(txtBox, minValue, maxValue);
            }
        }
        public void EnableEditButton()
        {
            btnEditSave.Visible = true; // Hiển thị nút "Chỉnh sửa"
            isEditButtonEnabled = true; // Ghi nhớ trạng thái
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (isEditButtonEnabled)
                EnableEditButton();
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
                var vehicle = vehicleRepo.GetVehicleDetails(vin);
                if (vehicle == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Tạo danh sách testDetails
                var testDetails = BuildTestDetails(vehicle);

                // Tổng hợp dữ liệu gửi MMS
                string inspectionDate = vehicle.InspectionDate?.ToString();
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
        private List<object> BuildTestDetails(VehicleInfo vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
            var standard = standardRepo.GetVehicleStandardByTypeCar(vehicle.VehicleType);
            if (standard == null)
                throw new Exception("Không tìm thấy tiêu chuẩn kiểm tra cho xe này.");

            List<object> testDetails = new List<object>();
            void AddIfEnabled(string key, object testDetail)
            {
                if (ConfigurationManager.AppSettings[key] == "true")
                {
                    testDetails.Add(testDetail);
                }
            }
            // Lấy dữ liệu phụ
            var speed = vehicle.Speeds?.FirstOrDefault();
            var sideslip = vehicle.SideSlips?.FirstOrDefault();
            var noise = vehicle.Noises?.FirstOrDefault();
            var petrol = vehicle.GasEmission_Petrol?.FirstOrDefault();
            var diesel = vehicle.GasEmission_Diesel?.FirstOrDefault();
            var brake = vehicle.BrakeForces?.FirstOrDefault();
            var steer = vehicle.SteerAngles?.FirstOrDefault();
            var headlight = vehicle.Headlights?.FirstOrDefault();

            // SpeedMMS
            AddIfEnabled("SpeedMMS", new
            {
                TestTypeCode = "SPEED",
                TestDtlCode = "SPEED_S",
                MeasureValue = speed?.Speed1?.ToString("F1") ?? "",
                StandardValue = FormatRange(standard.MinSpeed, standard.MaxSpeed, "F1"),
                TestDtlResult = CheckStandard(speed?.Speed1 ?? 0, standard.MinSpeed, standard.MaxSpeed) ? "1" : "0"
            });

            // SideSlipMMS
            AddIfEnabled("SideSlipMMS", new
            {
                TestTypeCode = "SIDESLIP",
                TestDtlCode = "SIDESLIP_F",
                MeasureValue = sideslip?.SideSlip1?.ToString("F1") ?? "",
                StandardValue = FormatRange(standard.MinSideSlip, standard.MaxSideSlip, "F1"),
                TestDtlResult = CheckStandard(sideslip?.SideSlip1 ?? 0, standard.MinSideSlip, standard.MaxSideSlip) ? "1" : "0"
            });

            // WhistleMMS
            AddIfEnabled("WhistleMMS", new
            {
                TestTypeCode = "HORNLOADNESS",
                TestDtlCode = "HORNLOADNESS_H",
                MeasureValue = noise?.Whistle?.ToString("F1") ?? "",
                LimitValue = FormatRange(standard.MinWhistle, standard.MaxWhistle, "F1"),
                TestDtlResult = CheckStandard(noise?.Whistle ?? 0, standard.MinWhistle, standard.MaxWhistle) ? "1" : "0"
            });

            // NoiseMMS
            AddIfEnabled("NoiseMMS", new
            {
                TestTypeCode = "SOUND",
                TestDtlCode = "SOUND_S",
                MeasureValue = noise?.Noise1?.ToString("F1") ?? "",
                LimitValue = FormatRange(null, standard.MaxNoise, "F1"),
                TestDtlResult = CheckStandard(noise?.Noise1 ?? 0, null, standard.MaxNoise) ? "1" : "0"
            });


            // Giá trị Brake Force
            decimal frontLeftBrake = brake.FrontLeftBrake ?? 0;
            decimal frontRightBrake = brake.FrontRightBrake ?? 0;
            decimal frontDiffBrake = ConvertToDecimal(txtFrontDiffBrake.Text);
            decimal frontSumBrake = frontLeftBrake + frontRightBrake;
            decimal minFrontBrake = vehicleStandard?.MinFrontBrake ?? 0;
            decimal maxDiffFrontBrake = vehicleStandard?.MaxDiffFrontBrake ?? 0;
            decimal frontEfficiencyBrake = minFrontBrake != 0 ? (frontSumBrake * 0.5m / minFrontBrake) * 100 : 0;
            string frontBrakeResult = (txtFrontSumBrake.BackColor == Color.LightGreen && txtFrontDiffBrake.BackColor == Color.LightGreen) ? "1" : "0";
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
                BrakeEfficiencyValue = frontEfficiencyBrake.ToString("F2"),
                TestDtlResult = frontBrakeResult
            });

            decimal rearLeftBrake = brake.RearLeftBrake ?? 0;
            decimal rearRightBrake = brake.RearRightBrake ?? 0;
            decimal rearDiffBrake = ConvertToDecimal(txtRearDiffBrake.Text);
            decimal rearSumBrake = rearLeftBrake + rearRightBrake;
            decimal minRearBrake = vehicleStandard?.MinRearBrake ?? 0;
            decimal maxDiffRearBrake = vehicleStandard?.MaxDiffRearBrake ?? 0;
            decimal rearEfficiencyBrake = minRearBrake != 0 ? (rearSumBrake * 0.5m / minRearBrake) * 100 : 0;
            string rearBrakeResult = (txtRearSumBrake.BackColor == Color.LightGreen && txtRearDiffBrake.BackColor == Color.LightGreen) ? "1" : "0";
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
                BrakeEfficiencyValue = rearEfficiencyBrake.ToString("F2"),
                TestDtlResult = rearBrakeResult
            });

            decimal mainSumBrake = frontSumBrake + rearSumBrake;
            decimal minMainSum = minFrontBrake + minRearBrake;
            decimal mainEfficiencyBrake = minMainSum != 0 ? (mainSumBrake * 0.5m / minMainSum) * 100 : 0;
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
                BrakeEfficiencyValue = mainEfficiencyBrake.ToString("F2"),
                TestDtlResult = mainBrakeResult
            });

            decimal handLeftBrake = brake.HandBrakeLeft ?? 0;
            decimal handRightBrake = brake.HandBrakeRight ?? 0;
            decimal handDiffBrake = ConvertToDecimal(txtHandDiffBrake.Text);
            decimal handSumBrake = handLeftBrake + handRightBrake;
            decimal minHandBrake = vehicleStandard?.MinHandBrake ?? 0;
            decimal maxDiffHandBrake = vehicleStandard?.MaxDiffHandBrake ?? 0;
            decimal handEfficiencyBrake = minHandBrake != 0 ? (handSumBrake * 0.16m / minHandBrake) * 100 : 0;
            string handBrakeResult = (txtHandSumBrake.BackColor == Color.LightGreen && txtHandDiffBrake.BackColor == Color.LightGreen) ? "1" : "0";
            AddIfEnabled("BrakeMMS", new
            {
                TestTypeCode = "BRAKEFORCE",
                TestDtlCode = "BRAKEFORCE_H",
                LeftValue = handLeftBrake.ToString("F1"),
                RightValue = handRightBrake.ToString("F1"),
                TotalValue = handSumBrake.ToString("F1"),
                TotalLimitValue = minHandBrake.ToString("F1"),
                BrakeEfficiencyValue = handEfficiencyBrake.ToString("F2"),
                TestDtlResult = handBrakeResult
            });

            // Giá trị Petrol Emision
            if (vehicle.Fuel?.Trim() == "Xăng")
            {
                AddIfEnabled("PetrolMMS", new
                {
                    TestTypeCode = "EXHAUSTGA",
                    TestDtlCode = "EXHAUSTGA_CO",
                    MeasureValue = petrol?.CO?.ToString("F2") ?? "",
                    LimitValue = standard.MaxCO?.ToString("F2") ?? "",
                    TestDtlResult = CheckStandard(petrol?.CO ?? 0, null, standard.MaxCO) ? "1" : "0"
                });
                AddIfEnabled("PetrolMMS", new
                {
                    TestTypeCode = "EXHAUSTGA",
                    TestDtlCode = "EXHAUSTGA_HC",
                    MeasureValue = petrol?.HC?.ToString("F1") ?? "",
                    LimitValue = standard.MaxHC?.ToString("F1") ?? "",
                    TestDtlResult = CheckStandard(petrol?.HC ?? 0, null, standard.MaxHC) ? "1" : "0"
                });
                AddIfEnabled("PetrolMMS", new
                {
                    TestTypeCode = "EXHAUSTGA",
                    TestDtlCode = "EXHAUSTGA_E",
                    MeasureValue = petrol?.RPM?.ToString("F1") ?? "",
                    TestDtlResult = "1"
                });
                AddIfEnabled("PetrolMMS", new
                {
                    TestTypeCode = "EXHAUSTGA",
                    TestDtlCode = "EXHAUSTGA_O",
                    MeasureValue = petrol?.OilTemp?.ToString("F1") ?? "",
                    TestDtlResult = "1"
                });
            }
            // Giá trị Diesel Emission
            else if (vehicle.Fuel?.Trim() == "Dầu")
            {
                var hsu1 = diesel?.HSU1 ?? 0;
                var hsu2 = diesel?.HSU2 ?? 0;
                var hsu3 = diesel?.HSU3 ?? 0;
                var avgHSU = (hsu1 + hsu2 + hsu3) / 3;
                AddIfEnabled("DieselMMS", new { TestTypeCode = "DIESELOPACITY", TestDtlCode = "RPMMIN_1", MeasureValue = diesel?.MinSpeed1?.ToString("F0") ?? "", TestDtlResult = "0" });
                AddIfEnabled("DieselMMS", new { TestTypeCode = "DIESELOPACITY", TestDtlCode = "RPMMIN_2", MeasureValue = diesel?.MinSpeed2?.ToString("F0") ?? "", TestDtlResult = "0" });
                AddIfEnabled("DieselMMS", new { TestTypeCode = "DIESELOPACITY", TestDtlCode = "RPMMIN_3", MeasureValue = diesel?.MinSpeed3?.ToString("F0") ?? "", TestDtlResult = "0" });

                AddIfEnabled("DieselMMS", new { TestTypeCode = "DIESELOPACITY", TestDtlCode = "RPMMAX_1", MeasureValue = diesel?.MaxSpeed1?.ToString("F0") ?? "", TestDtlResult = "0" });
                AddIfEnabled("DieselMMS", new { TestTypeCode = "DIESELOPACITY", TestDtlCode = "RPMMAX_2", MeasureValue = diesel?.MaxSpeed2?.ToString("F0") ?? "", TestDtlResult = "0" });
                AddIfEnabled("DieselMMS", new { TestTypeCode = "DIESELOPACITY", TestDtlCode = "RPMMAX_3", MeasureValue = diesel?.MaxSpeed3?.ToString("F0") ?? "", TestDtlResult = "0" });

                AddIfEnabled("DieselMMS", new { TestTypeCode = "DIESELOPACITY", TestDtlCode = "OPACITY_1", MeasureValue = hsu1.ToString("F2"), TestDtlResult = "0" });
                AddIfEnabled("DieselMMS", new { TestTypeCode = "DIESELOPACITY", TestDtlCode = "OPACITY_2", MeasureValue = hsu2.ToString("F2"), TestDtlResult = "0" });
                AddIfEnabled("DieselMMS", new { TestTypeCode = "DIESELOPACITY", TestDtlCode = "OPACITY_3", MeasureValue = hsu3.ToString("F2"), TestDtlResult = "0" });

                AddIfEnabled("DieselMMS", new
                {
                    TestTypeCode = "DIESELOPACITY",
                    TestDtlCode = "DIESELOPACITY_A",
                    MeasureValue = $"{avgHSU.ToString("F2")} %",
                    TestDtlResult = CheckStandard(avgHSU, null, standard.MaxHSU) ? "1" : "0"
                });
                AddIfEnabled("DieselMMS", new
                {
                    TestTypeCode = "DIESELOPACITY",
                    TestDtlCode = "DIESELOPACITY_L",
                    MeasureValue = FormatRange(null, standard.MaxHSU, "F2"),
                    TestDtlResult = CheckStandard(avgHSU, null, standard.MaxHSU) ? "1" : "0"
                });
            }

            // Đèn chiếu sáng
            AddIfEnabled("HeadLightsMMS", new
            {
                TestTypeCode = "HEADLIGHT",
                TestDtlCode = "HEADLIGHT_H_L",
                MeasureValue = $"{headlight?.LeftHBIntensity?.ToString("F0") ?? ""} / {headlight?.RightHBIntensity?.ToString("F0") ?? ""}",
                LimitValue = FormatRange(standard?.MinHLIntensity, standard?.MaxHBIntensity, "F0"),
                TestDtlResult = (
                                                CheckStandard(headlight?.LeftHBIntensity ?? 0, standard?.MinHLIntensity, standard?.MaxHBIntensity) &&
                                                CheckStandard(headlight?.RightHBIntensity ?? 0, standard?.MinHLIntensity, standard?.MaxHBIntensity)
                                            ) ? "1" : "0"
            });

            AddIfEnabled("HeadLightsMMS", new
            {
                TestTypeCode = "HEADLIGHT",
                TestDtlCode = "HEADLIGHT_H_LR",
                MeasureValue = $"{headlight?.LeftHBHorizontalDeviation?.ToString("F2") ?? ""} / {headlight?.RightHBHorizontalDeviation?.ToString("F2") ?? ""}",
                LimitValue = FormatRange(standard?.MinDiffHoriHB, standard?.MaxDiffHoriHB, "F2"),
                TestDtlResult = (
                                                CheckStandard(headlight?.LeftHBHorizontalDeviation ?? 0, standard?.MinDiffHoriHB, standard?.MaxDiffHoriHB) &&
                                                CheckStandard(headlight?.RightHBHorizontalDeviation ?? 0, standard?.MinDiffHoriHB, standard?.MaxDiffHoriHB)
                                            ) ? "1" : "0"
            });

            AddIfEnabled("HeadLightsMMS", new
            {
                TestTypeCode = "HEADLIGHT",
                TestDtlCode = "HEADLIGHT_H_UD",
                MeasureValue = $"{headlight?.LeftHBVerticalDeviation?.ToString("F2") ?? ""} / {headlight?.RightHBVerticalDeviation?.ToString("F2") ?? ""}",
                LimitValue = FormatRange(standard?.MinDiffVertiHB, standard?.MaxDiffVertiHB, "F2"),
                TestDtlResult = (
                                                CheckStandard(headlight?.LeftHBVerticalDeviation ?? 0, standard?.MinDiffVertiHB, standard?.MaxDiffVertiHB) &&
                                                CheckStandard(headlight?.RightHBVerticalDeviation ?? 0, standard?.MinDiffVertiHB, standard?.MaxDiffVertiHB)
                                            ) ? "1" : "0"
            });

            AddIfEnabled("HeadLightsMMS", new
            {
                TestTypeCode = "HEADLIGHT",
                TestDtlCode = "HEADLIGHT_L_LR",
                MeasureValue = $"{headlight?.LeftLBHorizontalDeviation?.ToString("F2") ?? ""} / {headlight?.RightLBHorizontalDeviation?.ToString("F2") ?? ""}",
                LimitValue = FormatRange(standard?.MinDiffHoriLB, standard?.MaxDiffHoriLB, "F2"),
                TestDtlResult = (
                                                CheckStandard(headlight?.LeftLBHorizontalDeviation ?? 0, standard?.MinDiffHoriLB, standard?.MaxDiffHoriLB) &&
                                                CheckStandard(headlight?.RightLBHorizontalDeviation ?? 0, standard?.MinDiffHoriLB, standard?.MaxDiffHoriLB)
                                            ) ? "1" : "0"
            });

            AddIfEnabled("HeadLightsMMS", new
            {
                TestTypeCode = "HEADLIGHT",
                TestDtlCode = "HEADLIGHT_L_UD",
                MeasureValue = $"{headlight?.LeftLBVerticalDeviation?.ToString("F2") ?? ""} / {headlight?.RightLBVerticalDeviation?.ToString("F2") ?? ""}",
                LimitValue = FormatRange(standard?.MinDiffVertiLB, standard?.MaxDiffVertiLB, "F2"),
                TestDtlResult = (
                                                CheckStandard(headlight?.LeftLBVerticalDeviation ?? 0, standard?.MinDiffVertiLB, standard?.MaxDiffVertiLB) &&
                                                CheckStandard(headlight?.RightLBVerticalDeviation ?? 0, standard?.MinDiffVertiLB, standard?.MaxDiffVertiLB)
                                            ) ? "1" : "0"
            });

            AddIfEnabled("HeadLightsMMS", new
            {
                TestTypeCode = "HEADLIGHT",
                TestDtlCode = "HEADLIGHT_L",
                MeasureValue = $"{headlight?.LeftLBIntensity?.ToString("F0") ?? ""} / {headlight?.RightLBIntensity?.ToString("F0") ?? ""}",
                LimitValue = FormatRange(standard?.MinLBIntensity, standard?.MaxLBIntensity, "F0"),
                TestDtlResult = (
                                                CheckStandard(headlight?.LeftLBIntensity ?? 0, standard?.MinLBIntensity, standard?.MaxLBIntensity) &&
                                                CheckStandard(headlight?.RightLBIntensity ?? 0, standard?.MinLBIntensity, standard?.MaxLBIntensity)
                                            ) ? "1" : "0"
            });

            // Góc Lái
            AddIfEnabled("SteeringAngleMMS", new
            {
                TestTypeCode = "STEERINGANGLE",
                TestDtlCode = "STEERINGANGLE_L",
                MeasureValue = steer?.LeftSteerLW?.ToString("F2") ?? "",
                LimitValue = FormatRange(standard.MinLeftSteer, standard.MaxLeftSteer, "F2"),
                TestDtlResult = CheckStandard(steer?.LeftSteerLW ?? 0, standard.MinLeftSteer, standard.MaxLeftSteer) ? "1" : "0"
            });

            AddIfEnabled("SteeringAngleMMS", new
            {
                TestTypeCode = "STEERINGANGLE",
                TestDtlCode = "STEERINGANGLE_R",
                MeasureValue = steer?.RightSteerLW?.ToString("F2") ?? "",
                LimitValue = FormatRange(standard.MinRightSteer, standard.MaxRightSteer, "F2"),
                TestDtlResult = CheckStandard(steer?.RightSteerLW ?? 0, standard.MinRightSteer, standard.MaxRightSteer) ? "1" : "0"
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
