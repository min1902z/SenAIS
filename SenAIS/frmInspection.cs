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
        private string vehicleType;
        private string inspector;
        private string frameNumber;
        public string serialNumber { get; set; }
        private DateTime inspectionDate;
        private string fuelType;
        private string color;

        private UdpClient udpListener;
        private const int udpPort = 8888;
        private Task receiveTask;

        private static readonly string opcSpeedCounter = ConfigurationManager.AppSettings["Speed_Counter"];
        private static readonly string opcSSCounter = ConfigurationManager.AppSettings["SideSlip_Counter"];
        private static readonly string opcBrakeFCounter = ConfigurationManager.AppSettings["BrakeF_Counter"];
        private static readonly string opcBrakeRCounter = ConfigurationManager.AppSettings["BrakeR_Counter"];
        private static readonly string opcBrakeHCounter = ConfigurationManager.AppSettings["BrakeH_Counter"];
        private static readonly string opcHL1Counter = ConfigurationManager.AppSettings["HL_LeftSen"];
        private static readonly string opcHL2Counter = ConfigurationManager.AppSettings["HL_RightSen"];
        private static readonly string opcWhistleCounter = ConfigurationManager.AppSettings["Whistle_Counter"];
        private static readonly string opcSteerCounter = ConfigurationManager.AppSettings["Steering_Counter"];
        private static readonly string opcGLPos1 = ConfigurationManager.AppSettings["Main_Pos"];
        public frmInspection()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper();
            this.serialNumber = txtVinNum.Text;
            LoadVehicleInfo();
            InitializeOPC();
            StartListeningForVin();
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
                //if ((ClientHandles.GetValue(i)?.Equals(opcCounterSpeed?.ClientHandle) ?? false) && itemValue == 1)
                //{
                //    OpenNewForm(new frmSpeed(this.serialNumber));
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

        // Hàm mở form và đưa lên đầu
        private void OpenForm(Form formToOpen)
        {
            if (formToOpen != null)
            {
                formToOpen.Show();
                formToOpen.BringToFront();  // Bring the new form to the front
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
                OPCUtility.SetOPCValue(opcSSCounter, 1);
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
                OPCUtility.SetOPCValue(opcWhistleCounter, 1);
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
                MessageBox.Show("Thông tin xe đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SendVinToNetwork(string vin)
        {
            try
            {
                UdpClient udpClient = new UdpClient();
                udpClient.EnableBroadcast = true;
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, udpPort);

                byte[] data = Encoding.UTF8.GetBytes(vin);
                udpClient.Send(data, data.Length, endPoint);
                //string[] ipAddresses = { "192.168.1.2", "192.168.1.3", "192.168.1.4", "192.168.1.5", "192.168.1.19" };
                //foreach (string ip in ipAddresses)
                //{
                //    udpClient.Send(data, data.Length, ip, udpPort);
                //}
                udpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi số VIN : " + ex.Message);
            }
        }
        private void StartListeningForVin()
        {
            if (udpListener != null) return; // Đảm bảo chỉ chạy 1 lần

            receiveTask = Task.Run(() =>
            {
                try
                {
                    udpListener = new UdpClient(udpPort);
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, udpPort);

                    while (true) // Luôn lắng nghe VIN mới
                    {
                        byte[] receivedBytes = udpListener.Receive(ref endPoint);
                        string receivedVin = Encoding.UTF8.GetString(receivedBytes);

                        this.Invoke(new Action(() =>
                        {
                            txtVinNum.Text = receivedVin;
                        }));
                    }
                }
                catch (Exception) { /* Không cần báo lỗi cho máy trạm */ }
            });
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
                OPCUtility.SetOPCValue(opcBrakeRCounter, 1);
            }
        }

        private void btnHandBrake_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                OpenNewForm(new frmHandBrake(this.serialNumber));
                OPCUtility.SetOPCValue(opcBrakeHCounter, 1);
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

        private void frmInspection_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                udpListener?.Close();
                receiveTask?.Dispose();
            }
            catch (Exception) { /* Không cần thông báo lỗi */ }
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
            string vin = txtVinNum.Text.Trim();
            if (!string.IsNullOrEmpty(vin))
            {
                SendVinToNetwork(vin);
            }
        }
    }
}
