using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmInspection : Form
    {
        private SQLHelper sqlHelper;
        private OPCManager opcManager;
        private string currentUI;
        private string vehicleType;
        private string inspector;
        private string frameNumber;
        public string serialNumber { get; set; }
        private DateTime inspectionDate;
        private string fuelType;

        public class VehicleInfo
        {
            public string VehicleType { get; set; }
            public string Inspector { get; set; }
            public string FrameNumber { get; set; }
            public string SerialNumber { get; set; }
            public string InspectionDate { get; set; }
            public string FuelType { get; set; }
        }
        private UdpClient udpListener;
        private Task receiveTask;
        private string lastJsonData = string.Empty;
        private CancellationTokenSource opcCancellationTokenSource;

        private static readonly string opcSpeedCounter = ConfigurationManager.AppSettings["Speed_Counter"];
        private static readonly string opcSSCounter = ConfigurationManager.AppSettings["SideSlip_Counter"];
        private static readonly string opcBrakeFCounter = ConfigurationManager.AppSettings["BrakeF_Counter"];
        private static readonly string opcBrakeRCounter = ConfigurationManager.AppSettings["BrakeR_Counter"];
        private static readonly string opcBrakeHCounter = ConfigurationManager.AppSettings["BrakeH_Counter"];
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
        private void StartMonitoringCounters(string stationType)
        {
            if (opcCancellationTokenSource != null)
                return; // Đã chạy rồi thì không khởi chạy lại

            opcCancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = opcCancellationTokenSource.Token;

            int lastValue = 0;
            string opcCounter = string.Empty;

            // 🔹 Xác định counter cần kiểm tra theo stationType
            if (stationType == "SPEED")
            {
                opcCounter = opcSpeedCounter;
            }
            else if (stationType == "SIDESLIP")
            {
                opcCounter = opcSSCounter;
            }
            else if (stationType == "BRAKE")
            {
                opcCounter = opcBrakeFCounter;
            }
            else
            {
                return; // Không phải trạm hợp lệ
            }

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        if (!opcManager.IsConnected)
                        {
                            await Task.Delay(1000, token);
                            continue;
                        }

                        int intValue = (int)opcManager.GetOPCValue(opcCounter);

                        if (intValue == 1 && lastValue != 1)
                        {
                            lastValue = 1;

                            bool shouldOpen = false;

                            if (stationType == "SPEED" && !Application.OpenForms.OfType<frmSpeed>().Any())
                                shouldOpen = true;
                            else if (stationType == "SIDESLIP" && !Application.OpenForms.OfType<frmSideSlip>().Any())
                                shouldOpen = true;
                            else if (stationType == "BRAKE" && !Application.OpenForms.OfType<frmFrontBrake>().Any())
                                shouldOpen = true;

                            if (shouldOpen)
                            {
                                this.BeginInvoke((MethodInvoker)(() =>
                                {
                                    if (stationType == "SPEED")
                                        OpenNewForm(new frmSpeed(serialNumber));
                                    else if (stationType == "SIDESLIP")
                                        OpenNewForm(new frmSideSlip(serialNumber));
                                    else if (stationType == "BRAKE")
                                        OpenNewForm(new frmFrontBrake(serialNumber));
                                }));
                            }
                        }
                        else if (intValue != 1)
                        {
                            lastValue = intValue;
                        }
                    }
                    catch
                    {
                        // Bỏ qua lỗi
                    }

                    await Task.Delay(500, token);
                }
            }, token);
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
                OpenNewForm(new frmSideSlip(this.serialNumber));
                opcManager.SetOPCValue(opcSSCounter, 1);
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
            {
                LoadAllVehicleInfo();
                MessageBox.Show("Thông tin xe đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        private void SendVehicleInfoToNetwork()
        {
            try
            {
                var vehicleInfo = new
                {
                    VehicleType = cbTypeCar.SelectedValue?.ToString() ?? string.Empty,
                    Inspector = cbInspector.SelectedValue?.ToString() ?? string.Empty,
                    FrameNumber = txtEngineNum.Text,
                    SerialNumber = txtVinNum.Text,
                    InspectionDate = dateInSpec.Value.ToString(),
                    FuelType = cbFuel.SelectedItem?.ToString() ?? string.Empty,
                };

                string jsonData = JsonConvert.SerializeObject(vehicleInfo);
                byte[] data = Encoding.UTF8.GetBytes(jsonData);

                string[] clientIPs = ConfigurationManager.AppSettings["ClientIPs"].Split(';');
                int udpPort = int.Parse(ConfigurationManager.AppSettings["UdpPort"]);

                using (UdpClient udpClient = new UdpClient())
                {
                    foreach (var ip in clientIPs)
                    {
                        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), udpPort);
                        udpClient.Send(data, data.Length, endPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi thông tin xe, kiểm tra kết nối với máy trạm: " + ex.Message);
            }
        }
        private void StartListeningForVehicleInfo()
        {
            if (receiveTask != null && !receiveTask.IsCompleted) return;

            int port = int.Parse(ConfigurationManager.AppSettings["UdpPort"]);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);

            try
            {
                udpListener?.Close();
                udpListener = new UdpClient(port);
            }
            catch
            {
                return; // Nếu lỗi khởi tạo listener, không làm gì cả
            }
            receiveTask = Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        byte[] receivedBytes = udpListener.Receive(ref endPoint);
                        string receivedJson = Encoding.UTF8.GetString(receivedBytes);

                        if (receivedJson == lastJsonData)
                            continue;

                        lastJsonData = receivedJson;

                        this.Invoke(new Action(() =>
                        {
                            try
                            {
                                var vehicleInfo = JsonConvert.DeserializeObject<VehicleInfo>(receivedJson);
                                if (vehicleInfo != null)
                                {
                                    cbTypeCar.SelectedValue = vehicleInfo.VehicleType;
                                    cbInspector.SelectedValue = vehicleInfo.Inspector;
                                    txtEngineNum.Text = vehicleInfo.FrameNumber;
                                    txtVinNum.Text = vehicleInfo.SerialNumber;
                                    dateInSpec.Value = DateTime.Parse(vehicleInfo.InspectionDate);
                                    cbFuel.SelectedItem = vehicleInfo.FuelType;

                                    this.serialNumber = vehicleInfo.SerialNumber;
                                    OpenStationFormByConfig(vehicleInfo.SerialNumber);
                                }
                            }
                            catch { /* Bỏ qua lỗi xử lý JSON hoặc update UI */ }
                        }));
                    }
                }
                catch { /* Bỏ qua lỗi khi listener ngắt kết nối hoặc form đóng */ }
            });
        }
        private void OpenStationFormByConfig(string serialNumber)
        {
            string stationType = ConfigurationManager.AppSettings["StationType"];
            Form newForm = null;
            Type formType = null;

            switch (stationType)
            {
                case "SideSlip":
                    formType = typeof(frmSideSlip);
                    newForm = new frmSideSlip(serialNumber);
                    break;

                case "Brake":
                    formType = typeof(frmFrontBrake);
                    newForm = new frmFrontBrake(serialNumber);
                    break;

                case "Speed":
                    formType = typeof(frmSpeed);
                    newForm = new frmSpeed(serialNumber);
                    break;

                default:
                    return;
            }

            this.BeginInvoke(new Action(() =>
            {
                // 🔹 Nếu form trạm đang mở => đóng lại trước
                var openedForm = Application.OpenForms
                    .OfType<Form>()
                    .FirstOrDefault(f => f.GetType() == formType);

                if (openedForm != null && !openedForm.IsDisposed)
                {
                    openedForm.Close();
                }
                // 🔹 Mở form mới với SerialNumber mới
                newForm.Show();
            }));
        }
        private void StopListeningForVehicleInfo()
        {
            try
            {
                udpListener?.Close();
                udpListener = null;

                if (receiveTask != null && !receiveTask.IsCompleted)
                {
                    receiveTask.Dispose();
                    receiveTask = null;
                }

                lastJsonData = string.Empty;
            }
            catch { }
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
        private void LoadAllVehicleInfo()
        {
            DataTable results = sqlHelper.GetAllVehicleInfo(); // hoặc SearchVehicleInfo(từ khóa)
            if (results != null && results.Rows.Count > 0)
            {
                dgVehicleInfo.DataSource = results;
                dgVehicleInfo.Columns["SerialNumber"].HeaderText = "Số VIN";
                dgVehicleInfo.Columns["FrameNumber"].HeaderText = "Số máy";
                dgVehicleInfo.Columns["VehicleType"].HeaderText = "Loại xe";
                dgVehicleInfo.Columns["Inspector"].HeaderText = "Người kiểm tra";
                dgVehicleInfo.Columns["InspectionDate"].HeaderText = "Ngày kiểm tra";
                dgVehicleInfo.Columns["Fuel"].HeaderText = "Nhiên liệu";
            }
        }
        public void ToggleMainUI()
        {
            string currentUI = ConfigurationManager.AppSettings["DefaultMainUI"] ?? "Menu";
            string newUI = currentUI == "Menu" ? "Vehicle" : "Menu";

            // Cập nhật hiển thị
            if (newUI == "Menu")
            {
                tbMenuControl.Visible = true;
                VehicleListPanel.Visible = false;
            }
            else
            {
                tbMenuControl.Visible = false;
                VehicleListPanel.Visible = true;
            }

            // Lưu lại cấu hình
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["DefaultMainUI"].Value = newUI;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void BrakeUI()
        {
            string stationType = ConfigurationManager.AppSettings["StationType"];
            string brakeOption = ConfigurationManager.AppSettings["Brake_Option"] ?? "1";
            string brakeLock = ConfigurationManager.AppSettings["Brake_Lock"] ?? "0";

            // Xử lý hiển thị và text nút cầu
            if (stationType == "Brake")
            {
                btnSwitchBrake.Visible = true;
                btnSwitchBrake.Text = brakeOption == "2" ? "Chọn Cầu Sau" : "Chọn Cầu Trước";

                btnLockBack.Visible = true;
                btnLockBack.Text = brakeLock == "1" ? "Chặn Trục" : "Bỏ Chặn Trục";
            }
            else
            {
                btnSwitchBrake.Visible = false;
                btnLockBack.Visible = false;
            }
        }
        private void HideAllInspectionButtons()
        {
            btnHeadlights.Visible = false;
            btnWhistle.Visible = false;
            btnNoise.Visible = false;
            btnSideSlip.Visible = false;
            btnFrontWeight.Visible = false;
            btnFrontBrake.Visible = false;
            btnRearBrake.Visible = false;
            btnHandBrake.Visible = false;
            btnSpeed.Visible = false;
            btnSteerAngle.Visible = false;
            btnEmission.Visible = false;
            btnSpeedMoving.Visible = false;
            btnLockBack.Visible = false;
            btnSwitchBrake.Visible = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmInspection_Load(object sender, EventArgs e)
        {
            currentUI = ConfigurationManager.AppSettings["DefaultMainUI"] ?? "Menu";
            if (currentUI == "Menu")
            {
                tbMenuControl.Visible = true;
                VehicleListPanel.Visible = false;
            }
            else
            {
                tbMenuControl.Visible = false;
                VehicleListPanel.Visible = true;
            }
            HideAllInspectionButtons();
            //Xử lý hiển thị các nút theo StationType
            string stationType = ConfigurationManager.AppSettings["StationType"]?.Trim().ToUpper() ?? "";

            // Hiện các nút tùy theo loại trạm
            if (stationType == "BRAKE")
            {
                btnFrontBrake.Visible = true;
                btnRearBrake.Visible = true;
                btnHandBrake.Visible = true;
                btnLockBack.Visible = true;
                btnSwitchBrake.Visible = true;
            }
            else if (stationType == "SIDESLIP")
            {
                btnSideSlip.Visible = true;
            }
            else if (stationType == "SPEED")
            {
                btnSpeed.Visible = true;
            }
            else if (stationType == "REPORT")
            {
                btnEmission.Visible = true;
            }
            BrakeUI();
            LoadAllVehicleInfo();
            StartListeningForVehicleInfo();
            if (stationType == "BRAKE" || stationType == "SPEED" || stationType == "SIDESLIP")
            {
                StartMonitoringCounters(stationType); // Gọi kèm stationType
            }
        }

        private void btnStartProgress_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                SendVehicleInfoToNetwork();
        }

        private void frmInspection_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListeningForVehicleInfo();
            if (opcCancellationTokenSource != null)
            {
                opcCancellationTokenSource.Cancel();
                opcCancellationTokenSource.Dispose();
                opcCancellationTokenSource = null;
            }
        }

        private void dgVehicleInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var serialNumber = dgVehicleInfo.Rows[e.RowIndex].Cells["SerialNumber"].Value?.ToString();
                if (!string.IsNullOrEmpty(serialNumber))
                {
                    UpdateVehicleInfo(serialNumber);
                }
            }
        }
        private void UpdateAppSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null)
                config.AppSettings.Settings[key].Value = value;
            else
                config.AppSettings.Settings.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void btnSwitchBrake_Click(object sender, EventArgs e)
        {
            try
            {
                string opcItem = ConfigurationManager.AppSettings["Brake_Switch"];
                int valueToSet = btnSwitchBrake.Text == "Chọn Cầu Trước" ? 1 : 0;

                // Gửi giá trị
                opcManager.SetOPCValue(opcItem, valueToSet);

                // Nếu không lỗi thì mới đổi text
                if (btnSwitchBrake.Text == "Chọn Cầu Trước")
                {
                    btnSwitchBrake.Text = "Chọn Cầu Sau";
                    UpdateAppSetting("Brake_Option", "2");
                }
                else
                {
                    btnSwitchBrake.Text = "Chọn Cầu Trước";
                    UpdateAppSetting("Brake_Option", "1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đổi cầu Phanh: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLockBack_Click(object sender, EventArgs e)
        {
            try
            {
                string opcItem = ConfigurationManager.AppSettings["Brake_LockBack"];
                bool isUnlocking = btnLockBack.Text == "Bỏ Chặn Trục";
                int valueToSet = isUnlocking ? 1 : 0;

                // Gửi giá trị OPC
                opcManager.SetOPCValue(opcItem, valueToSet);

                // Đổi text nút
                btnLockBack.Text = isUnlocking ? "Chặn Trục" : "Bỏ Chặn Trục";

                // Lưu giá trị vào app.config
                UpdateAppSetting("Brake_Lock", isUnlocking ? "1" : "0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi bỏ chặn trục: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
