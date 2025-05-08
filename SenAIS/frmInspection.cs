using Newtonsoft.Json;
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
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
        private OPCItem opcCounterHL;
        private OPCItem opcCounterHL2;
        private OPCItem opcCounterSteer;
        private OPCItem opcPos1;

        private SQLHelper sqlHelper;
        private OPCUtility opcManager;
        private string currentUI;
        private string vehicleType;
        private string inspector;
        private string frameNumber;
        public string serialNumber { get; set; }
        private DateTime inspectionDate;
        private string fuelType;
        private string color;
        public class VehicleInfo
        {
            public string VehicleType { get; set; }
            public string Inspector { get; set; }
            public string FrameNumber { get; set; }
            public string SerialNumber { get; set; }
            public string InspectionDate { get; set; }
            public string FuelType { get; set; }
            public string Color { get; set; }
        }
        private UdpClient udpListener;
        private Task receiveTask;
        private string lastJsonData = string.Empty;
        private CancellationTokenSource opcCancellationTokenSource;
        private StationType stationType;
        public enum StationType
        {
            None,
            Speed,
            Brake,
            Headlights,
            Steer
        }

        private static readonly string opcSpeedCounter = ConfigurationManager.AppSettings["Speed_Counter"];
        private static readonly string opcSSCounter = ConfigurationManager.AppSettings["SideSlip_Counter"];
        private static readonly string opcBrakeFCounter = ConfigurationManager.AppSettings["BrakeF_Counter"];
        private static readonly string opcBrakeRCounter = ConfigurationManager.AppSettings["BrakeR_Counter"];
        private static readonly string opcBrakeHCounter = ConfigurationManager.AppSettings["BrakeH_Counter"];
        private static readonly string opcHLCounter = ConfigurationManager.AppSettings["Headlights_Counter"];
        private static readonly string opcHLPos1 = ConfigurationManager.AppSettings["HL_InSen"];
        private static readonly string opcHLPos2 = ConfigurationManager.AppSettings["HL_OutSen"];
        private static readonly string opcWhistleCounter = ConfigurationManager.AppSettings["Whistle_Counter"];
        private static readonly string opcSteerCounter = ConfigurationManager.AppSettings["Steering_Counter"];
        private static readonly string opcGLPos1 = ConfigurationManager.AppSettings["GL_Pos1"];
        private static readonly string opcGLPos2 = ConfigurationManager.AppSettings["GL_Pos2"];
        public frmInspection()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper();
            opcManager = new OPCUtility();
            this.serialNumber = txtVinNum.Text;
            //InitializeOPC();
        }
        public frmInspection(string serialNumber)
        {
            InitializeComponent();
            sqlHelper = new SQLHelper();
            opcManager = new OPCUtility();
            this.serialNumber = serialNumber;
            txtVinNum.Text = serialNumber;
            UpdateVehicleInfo(serialNumber);
            //InitializeOPC();
        }
        public string GetVinNumber()
        {
            return txtVinNum.Text;
        }
        private void StartMonitoringByStationType()
        {
            if (opcCancellationTokenSource != null)
                return; // Đã chạy rồi thì không khởi động lại nữa

            opcCancellationTokenSource = new CancellationTokenSource();
            var token = opcCancellationTokenSource.Token;

            Task.Run(async () =>
            {
                // Các biến nhớ giá trị cũ
                int lastSpeed = -1, lastBrake = -1, lastHL = -1, lastSteer = -1;
                int lastHLPos1 = -1, lastHLPos2 = -1, lastGLPos1 = -1, lastGLPos2 = -1;

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        switch (stationType)
                        {
                            case StationType.Speed:
                                int speed = opcManager.GetOPCValue(opcSpeedCounter);
                                if (speed == 1 && lastSpeed != 1)
                                {
                                    lastSpeed = speed;
                                    BeginInvoke((MethodInvoker)(() =>
                                    {
                                        if (!Application.OpenForms.OfType<frmSpeed>().Any())
                                            OpenNewForm(new frmSpeed(serialNumber));
                                    }));
                                }
                                else if (speed != 1) lastSpeed = speed;
                                break;

                            case StationType.Brake:
                                int brake = opcManager.GetOPCValue(opcBrakeFCounter);
                                if (brake == 1 && lastBrake != 1)
                                {
                                    lastBrake = brake;
                                    BeginInvoke((MethodInvoker)(() =>
                                    {
                                        if (!Application.OpenForms.OfType<frmFrontBrake>().Any())
                                            OpenNewForm(new frmFrontBrake(serialNumber));
                                    }));
                                }
                                else if (brake != 1) lastBrake = brake;
                                break;

                            case StationType.Headlights:
                                int hl = opcManager.GetOPCValue(opcHLCounter);
                                int hlPos1 = opcManager.GetOPCValue(opcHLPos1);
                                int hlPos2 = opcManager.GetOPCValue(opcHLPos2);

                                if ((hl == 1 || hl == 2) && hl != lastHL)
                                {
                                    lastHL = hl;
                                    BeginInvoke((MethodInvoker)(() =>
                                    {
                                        if (!Application.OpenForms.OfType<frmHeadlights>().Any())
                                            OpenNewForm(new frmHeadlights(serialNumber));
                                    }));
                                }

                                if (hlPos1 != lastHLPos1)
                                {
                                    lastHLPos1 = hlPos1;
                                    BeginInvoke((MethodInvoker)(() => cbPos1.BackColor = hlPos1 == 1 ? Color.Green : SystemColors.Control));
                                }

                                if (hlPos2 != lastHLPos2)
                                {
                                    lastHLPos2 = hlPos2;
                                    BeginInvoke((MethodInvoker)(() => cbPos2.BackColor = hlPos2 == 1 ? Color.Green : SystemColors.Control));
                                }
                                break;

                            case StationType.Steer:
                                int steer = opcManager.GetOPCValue(opcSteerCounter);
                                int glPos1 = opcManager.GetOPCValue(opcGLPos1);
                                int glPos2 = opcManager.GetOPCValue(opcGLPos2);

                                if ((steer == 1 || steer == 2) && steer != lastSteer)
                                {
                                    lastSteer = steer;
                                    BeginInvoke((MethodInvoker)(() =>
                                    {
                                        if (!Application.OpenForms.OfType<frmSteerAngle>().Any())
                                            OpenNewForm(new frmSteerAngle(this.serialNumber));
                                    }));
                                }

                                if (glPos1 != lastGLPos1)
                                {
                                    lastGLPos1 = glPos1;
                                    BeginInvoke((MethodInvoker)(() => cbPos1.BackColor = glPos1 == 1 ? Color.Green : SystemColors.Control));
                                }

                                if (glPos2 != lastGLPos2)
                                {
                                    lastGLPos2 = glPos2;
                                    BeginInvoke((MethodInvoker)(() => cbPos2.BackColor = glPos2 == 1 ? Color.Green : SystemColors.Control));
                                }
                                break;
                        }
                    }
                    catch
                    {
                        // Bỏ qua lỗi
                    }

                    await Task.Delay(100, token);
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
                opcGroup.UpdateRate = 1000;

                // Thêm các OPCItems tương ứng với các Counter
                //opcCounterSpeed = opcGroup.OPCItems.AddItem(opcSpeedCounter, 1);
                //opcCounterSideSlip = opcGroup.OPCItems.AddItem(opcSSCounter, 2);
                opcCounterBrake = opcGroup.OPCItems.AddItem(opcBrakeFCounter, 1);
                //opcCounterHL = opcGroup.OPCItems.AddItem(opcHL1Counter, 1);
                //opcCounterHL2 = opcGroup.OPCItems.AddItem(opcHL2Counter, 1);
                //opcCounterSteer = opcGroup.OPCItems.AddItem(opcSteerCounter, 1);
                //opcPos1 = opcGroup.OPCItems.AddItem(opcGLPos1, 2);
                opcGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(OnDataChange);
            }
            catch
            {
                MessageBox.Show($"Vui lòng kiểm tra dữ liệu từ OPC Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                //if ((ClientHandles.GetValue(i)?.Equals(opcCounterSpeed?.ClientHandle) ?? false))
                //{
                //    if (itemValue == 1)
                //    {
                //        var speedForm = Application.OpenForms.OfType<frmSpeed>().FirstOrDefault();
                //        if (speedForm == null) // Chỉ mở nếu chưa có
                //        {
                //            this.BeginInvoke(new Action(() => OpenNewForm(new frmSpeed(this.serialNumber))));
                //        }
                //    }
                //}
                //else if ((ClientHandles.GetValue(i)?.Equals(opcCounterSideSlip?.ClientHandle) ?? false) && itemValue == 1)
                //{
                //    OpenNewForm(new frmSideSlip(this.serialNumber));
                //}
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
                //if ((ClientHandles.GetValue(i)?.Equals(opcCounterHL?.ClientHandle) ?? false))
                //{
                //    if (itemValue == 1 || itemValue == 2)
                //    {
                //        var headlightsForm = Application.OpenForms.OfType<frmHeadlights>().FirstOrDefault();
                //        if (headlightsForm == null) // Chỉ mở nếu chưa có
                //        {
                //            this.BeginInvoke(new Action(() => OpenNewForm(new frmHeadlights(this.serialNumber))));
                //        }
                //    }
                //}
                //if ((ClientHandles.GetValue(i)?.Equals(opcCounterSteer?.ClientHandle) ?? false))
                //{
                //    if (itemValue == 1 || itemValue == 2)
                //    {
                //        var steerAngleForm = Application.OpenForms.OfType<frmSteerAngle>().FirstOrDefault();
                //        if (steerAngleForm == null) // Chỉ mở nếu chưa có
                //        {
                //            this.BeginInvoke(new Action(() => OpenNewForm(new frmSteerAngle(this.serialNumber))));
                //        }
                //    }
                //}
                //if ((ClientHandles.GetValue(i)?.Equals(opcPos1?.ClientHandle) ?? false))
                //{
                //    if (cbPos1.BackColor != (itemValue == 1 ? Color.Green : SystemColors.Control))
                //    {
                //        this.BeginInvoke(new Action(() =>
                //        {
                //            cbPos1.BackColor = itemValue == 1 ? Color.Green : SystemColors.Control;
                //        }));
                //    }
                //}
            }
        }

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
                OpenNewForm(new frmNoise(this.serialNumber));
            }
        }

        private void btnFrontWeight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmFrontWeight(this.serialNumber));
        }

        private void btnWhistle_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                OpenNewForm(new frmWhistle(this.serialNumber));
                opcManager.SetOPCValue(opcWhistleCounter, 1);
            }
        }

        private void btnFrontBrake_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmFrontBrake(this.serialNumber));
        }

        private void btnHeadlights_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmHeadlights(this.serialNumber));
        }

        private void btnEmission_Click(object sender, EventArgs e)
        {
            bool isManualMode = cbManualMode.Checked;
            // Check the text of the button
            if (btnEmission.Text == "Khí Xả Xăng")
            {
                if (CheckSerialNumber())
                    // Open the Gas Emission form
                    OpenNewForm(new frmGasEmission(this.serialNumber, isManualMode));
            }
            else
            {
                if (CheckSerialNumber())
                    // Open the Diesel Emission form
                    OpenNewForm(new frmDieselEmission(this.serialNumber));
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
            color = txtColor.Text;

            if (string.IsNullOrEmpty(vehicleType) || string.IsNullOrEmpty(inspector) ||
                   string.IsNullOrEmpty(frameNumber) || string.IsNullOrEmpty(fuelType) ||
                   string.IsNullOrEmpty(serialNumber) || string.IsNullOrEmpty(color))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường thông tin của phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            sqlHelper.SaveVehicleInfo(vehicleType, inspector, frameNumber, serialNumber, inspectionDate, fuelType, color);
            return true;
        }
        private bool CheckSerialNumber()
        {
            if (string.IsNullOrWhiteSpace(txtVinNum.Text))
            {
                txtVinNum.Focus();
                return false;
            }
            this.serialNumber = txtVinNum.Text;
            return true;
        }

        private void btnRearWeight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmRearWeight(this.serialNumber));
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
            if (CheckSerialNumber())
                OpenNewForm(new frmSteerAngle(this.serialNumber));
        }

        private void cbFuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFuel.SelectedItem.ToString() == "Xăng")
            {
                btnEmission.Text = "Khí Xả Xăng";
                cbManualMode.Visible = true;
            }
            else if (cbFuel.SelectedItem.ToString() == "Dầu")
            {
                btnEmission.Text = "Khí Xả Diesel";
                cbManualMode.Visible = false;
            }
        }

        private void txtVinNum_TextChanged(object sender, EventArgs e)
        {
            txtVinShow.Text = txtVinNum.Text;
        }

        public void UpdateCarInfo(string vin, string engine, string model, string color)
        {
            txtVinNum.Text = vin;
            txtEngineNum.Text = engine;
            int index = cbTypeCar.FindStringExact(model);
            if (index != -1)
            {
                cbTypeCar.SelectedIndex = index;
            }
            else
            {
                cbTypeCar.SelectedIndex = -1;  // Không chọn gì cả
            }
            txtColor.Text = color;
        }
        private void btnAddList_Click(object sender, EventArgs e)
        {
            frmCarList carListForm = new frmCarList(this);
            carListForm.ShowDialog();
        }

        private void btnFoglights_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                OpenNewForm(new frmFogLights(this.serialNumber));
            }
        }

        private void StopMonitoring()
        {
            try
            {
                if (opcCancellationTokenSource != null)
                {
                    opcCancellationTokenSource.Cancel();  // Báo huỷ task
                    opcCancellationTokenSource.Dispose(); // Giải phóng tài nguyên
                    opcCancellationTokenSource = null;
                }
            }
            catch
            {
                // Bỏ qua lỗi dừng
            }
        }
        private void frmInspection_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListeningForVehicleInfo();
            StopMonitoring();
        }

        private void txtVinNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string vin = txtVinNum.Text.Trim();
                DataRow vehicleData = sqlHelper.GetVehicleStandardByVin(vin);

                if (vehicleData != null)
                {
                    // Lấy dữ liệu từ SampleVin
                    txtEngineNum.Text = vehicleData["SampleEngine"].ToString();
                    cbTypeCar.SelectedValue = vehicleData["VehicleType"].ToString();
                }
                else
                {
                    // Không có dữ liệu trong DB, không điền thông tin
                    txtEngineNum.Text = "";
                    cbTypeCar.SelectedIndex = -1; // Bỏ chọn combobox
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                string[] clientIPs = ConfigurationManager.AppSettings["ClientIPs"].Split(';');

                frmSelectTest selectForm = new frmSelectTest(clientIPs);
                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    List<string> selectedIPs = selectForm.SelectedIPs;
                    if (selectedIPs.Any())
                    {
                        SendVehicleInfoToSelectedClients(selectedIPs);
                    }
                }
            }
        }
        private void SendVehicleInfoToSelectedClients(List<string> selectedIPs)
        {
            try
            {
                var vehicleInfo = new
                {
                    VehicleType = cbTypeCar.SelectedValue?.ToString() ?? string.Empty,
                    Inspector = cbInspector.SelectedValue?.ToString() ?? string.Empty,
                    FrameNumber = txtEngineNum.Text,
                    SerialNumber = txtVinNum.Text,
                    InspectionDate = dateInSpec.Value.ToString("yyyy-MM-dd"),
                    FuelType = cbFuel.SelectedItem?.ToString() ?? string.Empty,
                    Color = txtColor.Text
                };

                string jsonData = JsonConvert.SerializeObject(vehicleInfo);
                byte[] data = Encoding.UTF8.GetBytes(jsonData);

                int udpPort = int.Parse(ConfigurationManager.AppSettings["UdpPort"]);

                using (UdpClient udpClient = new UdpClient())
                {
                    foreach (var ip in selectedIPs)
                    {
                        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), udpPort);
                        udpClient.Send(data, data.Length, endPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi thông tin xe, kiểm tra kết nối với các máy trạm: " + ex.Message);
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
                                    this.serialNumber = txtVinNum.Text;
                                    dateInSpec.Value = DateTime.Parse(vehicleInfo.InspectionDate);
                                    cbFuel.SelectedItem = vehicleInfo.FuelType;
                                    txtColor.Text = vehicleInfo.Color;
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
                txtColor.Text = string.Empty;
                return;
            }
            var vehicleInfo = sqlHelper.GetVehicleDetails(serialNumber);
            if (vehicleInfo != null)
            {
                cbTypeCar.SelectedValue = vehicleInfo["VehicleType"]?.ToString();
                cbInspector.SelectedValue = vehicleInfo["Inspector"]?.ToString();
                txtEngineNum.Text = vehicleInfo["FrameNumber"]?.ToString();
                txtVinNum.Text = vehicleInfo["SerialNumber"]?.ToString();
                this.serialNumber = txtVinNum.Text;
                dateInSpec.Value = vehicleInfo["InspectionDate"] != DBNull.Value
                                   ? Convert.ToDateTime(vehicleInfo["InspectionDate"])
                                   : DateTime.Now;
                cbFuel.SelectedItem = vehicleInfo["Fuel"]?.ToString();
                txtColor.Text = vehicleInfo["Color"]?.ToString();
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
                dgVehicleInfo.Columns["Color"].HeaderText = "Màu xe";
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
        private void frmInspection_Load(object sender, EventArgs e)
        {
            this.serialNumber = txtVinNum.Text;
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
            LoadVehicleInfo();
            StartListeningForVehicleInfo();
            string configStation = ConfigurationManager.AppSettings["StationType"];

            switch (configStation)
            {
                case "Speed":
                    stationType = StationType.Speed;
                    break;

                case "Brake":
                    stationType = StationType.Brake;
                    break;

                case "Headlights":
                    stationType = StationType.Headlights;
                    break;

                case "Steer":
                    stationType = StationType.Steer;
                    break;

                default:
                    stationType = StationType.None;
                    break;
            }

            StartMonitoringByStationType();
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

        private void btnResetMain_Click(object sender, EventArgs e)
        {
            RestartApplication();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
