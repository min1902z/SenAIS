using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OPCAutomation;
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
        private OPCServer opcServer;
        private OPCGroup opcGroup;
        private OPCItem opcCounterSpeed;
        private OPCItem opcCounterSideSlip;
        private OPCItem opcCounterBrake;
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
            //InitializeOPC();
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
            //InitializeOPC();
        }
        public string GetVinNumber()
        {
            return txtVinNum.Text;
        }
        private void StartMonitoringCounters()
        {
            if (opcCancellationTokenSource != null)
                return; // Đã chạy rồi thì không khởi chạy lại

            opcCancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = opcCancellationTokenSource.Token;

            int lastSpeed = 0, lastSS = 0, lastBrake = 0;
            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        if (!opcManager.IsConnected)
                        {
                            await Task.Delay(1000, token); // Nếu không kết nối OPC, chờ lâu hơn
                            continue;
                        }
                        var values = opcManager.GetMultipleOPCValues(new List<string>
                        {
                            opcSpeedCounter, opcSSCounter, opcBrakeFCounter
                        });

                        int speed = (int)(values.ContainsKey(opcSpeedCounter) ? values[opcSpeedCounter] : 0);
                        int ss = (int)(values.ContainsKey(opcSSCounter) ? values[opcSSCounter] : 0);
                        int brake = (int)(values.ContainsKey(opcBrakeFCounter) ? values[opcBrakeFCounter] : 0);

                        if (speed == 1 && lastSpeed != 1)
                        {
                            lastSpeed = 1;
                            this.BeginInvoke((MethodInvoker)(() =>
                            {
                                if (!Application.OpenForms.OfType<frmSpeed>().Any())
                                    OpenNewForm(new frmSpeed(serialNumber));
                            }));
                        }
                        else if (speed != 1)
                        {
                            lastSpeed = speed;
                        }

                        if (ss == 1 && lastSS != 1)
                        {
                            lastSS = 1;
                            this.BeginInvoke((MethodInvoker)(() =>
                            {
                                if (!Application.OpenForms.OfType<frmSideSlip>().Any())
                                    OpenNewForm(new frmSideSlip(serialNumber));
                            }));
                        }
                        else if (ss != 1)
                        {
                            lastSS = ss;
                        }

                        if (brake == 1 && lastBrake != 1)
                        {
                            lastBrake = 1;
                            this.BeginInvoke((MethodInvoker)(() =>
                            {
                                if (!Application.OpenForms.OfType<frmFrontBrake>().Any())
                                    OpenNewForm(new frmFrontBrake(serialNumber));
                            }));
                        }
                        else if (brake != 1)
                        {
                            lastBrake = brake;
                        }
                    }
                    catch
                    {
                        // Bỏ qua lỗi, không làm sập form
                    }

                    await Task.Delay(500, token); // Delay giữa các lần kiểm tra
                }
            }, token);
        }
        private void InitializeOPC()
        {
            try
            {
                opcServer = new OPCServer();
                opcServer.Connect("Kepware.KEPServerEX.V6", "");

                opcGroup = opcServer.OPCGroups.Add("OPCGroup1");
                opcGroup.IsActive = true;
                opcGroup.IsSubscribed = true;
                opcGroup.UpdateRate = 500;

                // Thêm các OPCItems tương ứng với các Counter
                opcCounterSpeed = opcGroup.OPCItems.AddItem(opcSpeedCounter, 1);
                opcCounterSideSlip = opcGroup.OPCItems.AddItem(opcSSCounter, 2);
                opcCounterBrake = opcGroup.OPCItems.AddItem(opcBrakeFCounter, 3);

                opcGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(OnDataChange);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra dữ liệu từ OPC Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void OnDataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;
            this.serialNumber = txtVinNum.Text;
            if (string.IsNullOrEmpty(serialNumber))
            {
                return;
            }
            for (int i = 1; i <= NumItems; i++)
            {
                int itemValue = ItemValues.GetValue(i) != null ? Convert.ToInt32(ItemValues.GetValue(i)) : 0;
                // Kiểm tra từng Counter và xử lý nếu giá trị bằng 1
                if ((ClientHandles.GetValue(i)?.Equals(opcCounterSpeed?.ClientHandle) ?? false))
                {
                    if (itemValue == 1)
                    {
                        var speedForm = Application.OpenForms.OfType<frmSpeed>().FirstOrDefault();
                        if (speedForm == null) // Chỉ mở nếu chưa có
                        {
                            this.BeginInvoke(new Action(() => OpenNewForm(new frmSpeed(this.serialNumber))));
                        }
                    }
                }
                else if ((ClientHandles.GetValue(i)?.Equals(opcCounterSideSlip?.ClientHandle) ?? false))
                {
                    if (itemValue == 1)
                    {
                        var speedForm = Application.OpenForms.OfType<frmSpeed>().FirstOrDefault();
                        if (speedForm == null) // Chỉ mở nếu chưa có
                        {
                            this.BeginInvoke(new Action(() => OpenNewForm(new frmSideSlip(this.serialNumber))));
                        }
                    }
                }
                if ((ClientHandles.GetValue(i)?.Equals(opcCounterBrake?.ClientHandle) ?? false))
                {
                    if (itemValue == 1)
                    {
                        var brakeForm = Application.OpenForms.OfType<frmFrontBrake>().FirstOrDefault();
                        if (brakeForm == null) // Chỉ mở nếu chưa có
                        {
                            this.BeginInvoke(new Action(() => OpenNewForm(new frmFrontBrake(this.serialNumber))));
                        }
                    }
                }
            }
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
                                }
                            }
                            catch { /* Bỏ qua lỗi xử lý JSON hoặc update UI */ }
                        }));
                    }
                }
                catch { /* Bỏ qua lỗi khi listener ngắt kết nối hoặc form đóng */ }
            });
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
                dgVehicleInfo.Visible = false;
            }
            else
            {
                tbMenuControl.Visible = false;
                dgVehicleInfo.Visible = true;
            }

            // Lưu lại cấu hình
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["DefaultMainUI"].Value = newUI;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
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
                dgVehicleInfo.Visible = false;
            }
            else
            {
                tbMenuControl.Visible = false;
                dgVehicleInfo.Visible = true;
            }
            LoadAllVehicleInfo();
            StartListeningForVehicleInfo();
            StartMonitoringCounters();
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
    }
}
