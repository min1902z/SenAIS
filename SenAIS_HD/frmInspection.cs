using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmInspection : Form
    {
        private SQLHelper sqlHelper;
        private OPCManager opcManager;
        private string vehicleType;
        private string inspector;
        private string frameNumber;
        public string serialNumber { get; set; }
        private DateTime inspectionDate;
        private string fuelType;
        private static readonly string opcSpeedCounter = ConfigurationManager.AppSettings["Speed_Counter"];
        private static readonly string opcSSCounter = ConfigurationManager.AppSettings["SideSlip_Counter"];
        private static readonly string opcBrakeFCounter = ConfigurationManager.AppSettings["BrakeF_Counter"];
        private static readonly string opcBrakeRCounter = ConfigurationManager.AppSettings["BrakeR_Counter"];
        private static readonly string opcBrakeHCounter = ConfigurationManager.AppSettings["BrakeH_Counter"];
        private static readonly string opcWeightFCounter = ConfigurationManager.AppSettings["WeightF_Counter"];
        private static readonly string opcWeightRCounter = ConfigurationManager.AppSettings["WeightR_Counter"];
        public frmInspection()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper();
            this.serialNumber = txtVinNum.Text;
            LoadVehicleInfo();
            opcManager = new OPCManager();
        }
        public frmInspection(string serialNumber)
        {
            InitializeComponent();
            sqlHelper = new SQLHelper();
            this.serialNumber = serialNumber;
            txtVinNum.Text = serialNumber;
            LoadVehicleInfo();
            UpdateVehicleInfo(serialNumber);
            opcManager = new OPCManager();
        }
        public string GetVinNumber()
        {
            return txtVinNum.Text;
        }
        // Hàm mở form và đưa lên đầu
        private List<Form> openForms = new List<Form>();
        private void OpenNewForm(Form newForm)
        {
            // Kiểm tra nếu form đã mở hay chưa
            var openedForm = Application.OpenForms.OfType<Form>()
        .FirstOrDefault(f => f.GetType() == newForm.GetType());
            if (openedForm != null)
            {
                // Nếu form đã mở, đưa nó lên trước
                openedForm.BringToFront();  // Đưa form lên đầu
                openedForm.Activate();      // Kích hoạt form để nhận focus
            }
            else
            {
                foreach (var form in openForms.ToList())
                {
                    if (form != null && !form.IsDisposed)
                    {
                        form.Close();
                    }
                    openForms.Remove(form);
                }
                // Nếu form chưa mở, mở form mới
                openForms.Add(newForm);  // Thêm form vào danh sách
                newForm.FormClosed += (s, e) => openForms.Remove(newForm);  // Gỡ form khỏi danh sách khi đóng
                newForm.Show();  // Hiển thị form mới
            }

        }
        private void btnSpeed_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                var frmSpeed = new frmSpeed(serialNumber);
                OpenNewForm(frmSpeed);
                opcManager.SetOPCValue(opcSpeedCounter, 1);
            }
        }

        private void btnSideSlip_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                opcManager.SetOPCValue(opcSSCounter, 1);
                OpenNewForm(new frmSideSlip(this.serialNumber));
            }
        }

        private void btnNoise_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
            }
        }

        private void btnFrontWeight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                opcManager.SetOPCValue(opcWeightFCounter, 1);
                OpenNewForm(new frmFrontWeight(this.serialNumber));
            }
        }

        private void btnWhistle_Click(object sender, EventArgs e)
        {
        }

        private void btnFrontBrake_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                OpenNewForm(new frmFrontBrake(this.serialNumber));
                opcManager.SetOPCValue(opcBrakeFCounter, 1);
            }
        }

        private void btnHeadlights_Click(object sender, EventArgs e)
        {
        }

        private void btnEmission_Click(object sender, EventArgs e)
        {
            // Check the text of the button
            if (btnEmission.Text == "Khí Xả Xăng")
            {
                if (CheckSerialNumber())
                    // Open the Gas Emission form
                    OpenNewForm(new frmPetrolPDF(this, this.serialNumber));
            }
            else
            {
                if (CheckSerialNumber())
                    // Open the Diesel Emission form
                    OpenNewForm(new frmDieselPDF(this, this.serialNumber));
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmReport(this.serialNumber));
        }

        private void btnInspecProgress_Click(object sender, EventArgs e)
        {
            if (!SaveDataToDB())
            {
                tbVehicleInfo.Focus();
            }
            else
                MessageBox.Show("Thông tin xe đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LoadVehicleInfo()
        {
            try
            {
                txtVinShow.Text = this.serialNumber;
                // Tải dữ liệu cho cbTypeCar
                DataTable typeCarTable = sqlHelper.GetTypeCarList();
                if (typeCarTable != null && typeCarTable.Rows.Count > 0)
                {
                    cbTypeCar.DataSource = typeCarTable;
                    cbTypeCar.DisplayMember = "VehicleType"; // Hiển thị TypeCar trong ComboBox
                    cbTypeCar.ValueMember = "VehicleType";   // Sử dụng TypeCar làm giá trị
                }
                else
                {
                    // Thêm giá trị mặc định nếu không có dữ liệu
                    cbTypeCar.DataSource = null;
                    cbTypeCar.Items.Clear();
                    cbTypeCar.Items.Add(" ");
                    cbTypeCar.SelectedIndex = 0;
                }

                // Tải dữ liệu cho cbInspector
                DataTable inspectorTable = sqlHelper.GetInspectorList();
                if (inspectorTable != null && inspectorTable.Rows.Count > 0)
                {
                    cbInspector.DataSource = inspectorTable;
                    cbInspector.DisplayMember = "InspectorName"; // Hiển thị InspectorName trong ComboBox
                    cbInspector.ValueMember = "InspectorName";   // Sử dụng InspectorName làm giá trị
                }
                else
                {
                    // Thêm giá trị mặc định nếu không có dữ liệu
                    cbInspector.DataSource = null;
                    cbInspector.Items.Clear();
                    cbInspector.Items.Add(" ");
                    cbInspector.SelectedIndex = 0;
                }

                // Kiểm tra nếu có SerialNumber, tải thông tin về FuelType
                if (!string.IsNullOrEmpty(txtVinNum.Text))
                {
                    DataTable result = sqlHelper.GetFuelTypeBySerialNumber(txtVinNum.Text);
                    if (result != null && result.Rows.Count > 0)
                    {
                        cbFuel.SelectedItem = result.Rows[0]["Fuel"].ToString();
                    }
                    else
                    {
                        cbFuel.SelectedIndex = -1; // Không chọn gì nếu không tìm thấy SerialNumber
                    }
                }
                else
                {
                    cbFuel.SelectedIndex = -1; // Reset nếu SerialNumber bị xóa
                }
                dateInSpec.Value = DateTime.Now;
            }
            catch (Exception)
            {
                // Xử lý lỗi DB và đặt giá trị mặc định
                MessageBox.Show("Lỗi khi tải dữ liệu: Vui lòng kiểm tra lại cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cbTypeCar.DataSource = null;
                cbTypeCar.Items.Clear();
                cbTypeCar.Items.Add(" ");
                cbTypeCar.SelectedIndex = 0;

                cbInspector.DataSource = null;
                cbInspector.Items.Clear();
                cbInspector.Items.Add(" ");
                cbInspector.SelectedIndex = 0;

                cbFuel.SelectedIndex = -1;
                dateInSpec.Value = DateTime.Now;
            }
        }
        private bool SaveDataToDB()
        {
            vehicleType = cbTypeCar.SelectedValue?.ToString() ?? string.Empty;
            inspector = cbInspector.SelectedValue?.ToString() ?? string.Empty;
            frameNumber = txtEngineNum.Text;
            serialNumber = txtVinNum.Text;
            inspectionDate = dateInSpec.Value;
            fuelType = cbFuel.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(vehicleType) || string.IsNullOrEmpty(inspector) ||
                   string.IsNullOrEmpty(frameNumber) || string.IsNullOrEmpty(fuelType) ||
                   string.IsNullOrEmpty(serialNumber))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường thông tin của phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            sqlHelper.SaveVehicleInfo(vehicleType, inspector, frameNumber, serialNumber, inspectionDate, fuelType);
            return true;
        }
        private bool CheckSerialNumber()
        {
            if (string.IsNullOrWhiteSpace(txtVinNum.Text))
            {
                MessageBox.Show("Vui lòng nhập Serial Number trước khi tiếp tục.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVinNum.Focus();
                return false;
            }
            this.serialNumber = txtVinNum.Text;
            return true;
        }

        private void btnRearWeight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                opcManager.SetOPCValue(opcWeightRCounter, 1);
                OpenNewForm(new frmRearWeight(this.serialNumber));
            }
        }

        private void btnRearBrake_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                OpenNewForm(new frmRearBrake(this.serialNumber));
                opcManager.SetOPCValue(opcBrakeRCounter, 1);
            }
        }

        private void btnHandBrake_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                OpenNewForm(new frmHandBrake(this.serialNumber));
                opcManager.SetOPCValue(opcBrakeHCounter, 1);
            }
        }

        private void btnSteerAngle_Click(object sender, EventArgs e)
        {
        }

        private void cbFuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFuel.SelectedItem.ToString() == "Xăng")
            {
                btnEmission.Text = "Khí Xả Xăng";
            }
            else if (cbFuel.SelectedItem.ToString() == "Dầu")
            {
                btnEmission.Text = "Khí Xả Diesel";
            }
        }

        private void txtVinNum_TextChanged(object sender, EventArgs e)
        {
            txtVinShow.Text = txtVinNum.Text;
        }

        private void txtVinNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string inputVin = txtVinNum.Text.Trim();
                string vehicleType = sqlHelper.GetVehicleTypeBySampleVin(inputVin);

                if (!string.IsNullOrEmpty(vehicleType))
                {
                    cbTypeCar.SelectedValue = vehicleType;
                }
                else
                {
                    cbTypeCar.SelectedIndex = -1;
                }
            }
        }
        public void UpdateVehicleInfo(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber))
            {
                cbTypeCar.SelectedIndex = -1;
                cbInspector.SelectedIndex = -1;
                txtEngineNum.Text = string.Empty;
                txtVinNum.Text = string.Empty;
                dateInSpec.Value = DateTime.Now;
                cbFuel.SelectedIndex = -1;
                return;
            }
            var vehicleInfo = sqlHelper.GetVehicleDetails(serialNumber);
            if (vehicleInfo != null)
            {
                cbTypeCar.SelectedValue = vehicleInfo["VehicleType"]?.ToString();
                cbInspector.SelectedValue = vehicleInfo["Inspector"]?.ToString();
                txtEngineNum.Text = vehicleInfo["FrameNumber"]?.ToString();
                txtVinNum.Text = vehicleInfo["SerialNumber"]?.ToString();
                dateInSpec.Value = vehicleInfo["InspectionDate"] != DBNull.Value
                                   ? Convert.ToDateTime(vehicleInfo["InspectionDate"])
                                   : DateTime.Now;
                cbFuel.SelectedItem = vehicleInfo["Fuel"]?.ToString();
            }
        }

        private void btnSpeedMoving_Click(object sender, EventArgs e)
        {
            var speedMoving = new frmSpeedMoving();
            speedMoving.Show();
        }

        private void btnResetMain_Click(object sender, EventArgs e)
        {
            RestartApplication();
        }
        private void RestartApplication()
        {
            try
            {
                // Lấy đường dẫn của ứng dụng hiện tại
                var applicationPath = Application.ExecutablePath;

                // Khởi động lại ứng dụng
                System.Diagnostics.Process.Start(applicationPath);

                // Thoát ứng dụng hiện tại
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể khởi động lại ứng dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
