using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmInspection : Form
    {
        private OPCServer opcServer;
        private OPCGroup opcGroup;
        private OPCItem opcCounterPos;
        private SQLHelper sqlHelper;
        private Form currentMeasurementForm;
        private bool isMeasuring = false; // Cờ để xác định khi nào bắt đầu theo dõi
        private string vehicleType;
        private string inspector;
        private string frameNumber;
        private string engineNumber;
        public string serialNumber { get; set; }
        private DateTime inspectionDate;
        public frmInspection()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True");
            LoadVehicleInfo();
            InitializeOPC();
        }

        public frmInspection(SenAIS senAIS)
        {
            this.senAIS = senAIS;
        }

        private void InitializeOPC()
        {
            try
            {
                opcServer = new OPCServer();
                opcServer.Connect("Kepware.KEPServerEX.V4", "");

                opcGroup = opcServer.OPCGroups.Add("OPCGroup1");
                opcGroup.IsActive = true;
                opcGroup.IsSubscribed = true;
                opcGroup.UpdateRate = 1000;

                opcCounterPos = opcGroup.OPCItems.AddItem("Hyundai.OCS10.T99", 1);
                opcGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(OnDataChange);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới OPC Server: " + ex.Message);
            }
        }
        private void OnDataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            if (!isMeasuring) return; // Nếu chưa bắt đầu đo, bỏ qua

            for (int i = 1; i <= NumItems; i++)
            {
                if (ClientHandles.GetValue(i).Equals(opcCounterPos.ClientHandle))
                {
                    int counterPos = Convert.ToInt32(ItemValues.GetValue(i));
                    ProcessMeasurement(counterPos);
                }
            }
        }
        public void ProcessMeasurement(int counterPos)
        {
            if (currentMeasurementForm != null)
            {
                currentMeasurementForm.Close();
            }
            Form formToOpen = null;
            switch (counterPos)
            {
                case 0:
                    OpenNewForm(new frmWaiting());
                    break;
                case 1:
                    OpenNewForm(new frmSpeed(this, opcCounterPos, this.serialNumber));
                    break;
                case 2:
                    OpenNewForm(new frmSideSlip(this, opcCounterPos, this.serialNumber));
                    break;
                case 3:
                    OpenNewForm(new frmNoise(this, opcCounterPos, this.serialNumber));
                    break;
                case 4:
                    OpenNewForm(new frmFrontWeight(this, opcCounterPos, this.serialNumber));
                    break;
                case 5:
                    OpenNewForm(new frmRearWeight(this, opcCounterPos, this.serialNumber));
                    break;
                case 6:
                    OpenNewForm(new frmWhistle(this, opcCounterPos, this.serialNumber));
                    break;
                case 7:
                    OpenNewForm(new frmFrontBrake(this, opcCounterPos, this.serialNumber));
                    break;
                case 8:
                    OpenNewForm(new frmRearBrake(this, opcCounterPos, this.serialNumber));
                    break;
                case 9:
                    OpenNewForm(new frmHandBrake(this, opcCounterPos, this.serialNumber));
                    break;
                case 10:
                    OpenNewForm(new frmHeadLightL(this, opcCounterPos, this.serialNumber));
                    break;
                case 11:
                    OpenNewForm(new frmHeadLightR(this, opcCounterPos, this.serialNumber));
                    break;
                case 12:
                    OpenNewForm(new frmCosLightL(this, opcCounterPos, this.serialNumber));
                    break;
                case 13:
                    OpenNewForm(new frmCosLightR(this, opcCounterPos, this.serialNumber));
                    break;
                case 14:
                    OpenNewForm(new frmGasEmission(this, opcCounterPos, this.serialNumber));
                    break;
                case 15:
                    OpenNewForm(new frmDieselEmission(this, opcCounterPos, this.serialNumber));
                    break;
                default:
                    MessageBox.Show("Giá trị CounterPosition không hợp lệ.");
                    break;
            }
            if (formToOpen != null)
            {
                currentMeasurementForm = formToOpen;
                formToOpen.Show();
            }
        }
        private Form currentForm = null;
        private SenAIS senAIS;

        private void OpenNewForm(Form newForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = newForm;
            newForm.Show();
        }
        private void btnSpeed_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                OpenNewForm(new frmSpeed(this, opcCounterPos, this.serialNumber));
            }
        }

        private void btnSideSlip_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmSideSlip(this, opcCounterPos, this.serialNumber));
        }

        private void btnNoise_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
            {
                OpenNewForm(new frmNoise(this, opcCounterPos, this.serialNumber));
            }
        }

        private void btnFrontWeight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmFrontWeight(this, opcCounterPos, this.serialNumber));
        }

        private void btnWhistle_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmWhistle(this, opcCounterPos, this.serialNumber));
        }

        private void btnFrontBrake_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmFrontBrake(this, opcCounterPos, this.serialNumber));
        }

        private void btnLeftHeadLight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmHeadLightL(this, opcCounterPos, this.serialNumber));
        }

        private void btnLeftCosLight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmCosLightL(this, opcCounterPos, this.serialNumber));
        }

        private void btnEmission_Click(object sender, EventArgs e)
        {
            // Check the text of the button
            if (btnEmission.Text == "Khí Xả Xăng")
            {
                if (CheckSerialNumber())
                    // Open the Gas Emission form
                    OpenNewForm(new frmGasEmission(this, opcCounterPos, this.serialNumber));
            }
            else
            {
                if (CheckSerialNumber())
                    // Open the Diesel Emission form
                    OpenNewForm(new frmDieselEmission(this, opcCounterPos, this.serialNumber));
            }
        }

        private void chkToggleFuelType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToggleFuelType.Checked)
            {
                chkToggleFuelType.Text = "Nhiên Liệu: Dầu";
                btnEmission.Text = "Khí Xả Diesel";
            }
            else
            {
                chkToggleFuelType.Text = "Nhiên Liệu: Xăng";
                btnEmission.Text = "Khí Xả Xăng";
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmReport(this.serialNumber));
        }

        private void btnInspecProgress_Click(object sender, EventArgs e)
        {
            isMeasuring = true; // Bắt đầu theo dõi sự thay đổi
            if (!SaveDataToDB())
            {
                return; // Dừng lại nếu dữ liệu không đủ và không lưu được
            }
            try
            {
                if (opcCounterPos != null)
                {
                    object value;
                    opcCounterPos.Read((short)OPCDataSource.OPCDevice, out value, out _, out _);
                    int t99Value = Convert.ToInt32(value);
                    ProcessMeasurement(t99Value);
                }
                else
                {
                    MessageBox.Show("CounterPosition chưa được khởi tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc giá trị CounterPosition: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadVehicleInfo()
        {
            // Tải dữ liệu cho cbTypeCar
            DataTable typeCarTable = sqlHelper.GetTypeCarList();
            cbTypeCar.DataSource = typeCarTable;
            cbTypeCar.DisplayMember = "VehicleType"; // Hiển thị TypeCar trong ComboBox
            cbTypeCar.ValueMember = "VehicleType";   // Sử dụng TypeCar làm giá trị

            // Tải dữ liệu cho cbInspector
            DataTable inspectorTable = sqlHelper.GetInspectorList();
            cbInspector.DataSource = inspectorTable;
            cbInspector.DisplayMember = "InspectorName"; // Hiển thị InspectorName trong ComboBox
            cbInspector.ValueMember = "InspectorName";   // Sử dụng InspectorName làm giá trị
        }
        private bool SaveDataToDB()
        {
            vehicleType = cbTypeCar.SelectedValue.ToString();
            inspector = cbInspector.SelectedValue.ToString();
            frameNumber = txtFrameNum.Text;
            engineNumber = txtEngineNum.Text;
            serialNumber = txtSerialNum.Text;
            inspectionDate = dateInSpec.Value;

            if (string.IsNullOrEmpty(vehicleType) || string.IsNullOrEmpty(inspector) ||
                   string.IsNullOrEmpty(frameNumber) || string.IsNullOrEmpty(engineNumber) ||
                   string.IsNullOrEmpty(serialNumber))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường thông tin của phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            SQLHelper sqlHelper = new SQLHelper("Server=LAPTOP-MinhNCN\\MSSQLSERVER01;Database=SenAISDB;Trusted_Connection=True;");
            sqlHelper.SaveVehicleInfo(vehicleType, inspector, frameNumber, engineNumber, serialNumber, inspectionDate);
            return true;
        }
        private bool CheckSerialNumber()
        {
            if (string.IsNullOrWhiteSpace(txtSerialNum.Text))
            {
                MessageBox.Show("Vui lòng nhập Serial Number trước khi tiếp tục.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerialNum.Focus();
                return false;
            }
            this.serialNumber = txtSerialNum.Text;
            return true;
        }

        private void btnRearWeight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmRearWeight(this, opcCounterPos, this.serialNumber));
        }

        private void btnRearBrake_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmRearBrake(this, opcCounterPos, this.serialNumber));
        }

        private void btnHandBrake_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmHandBrake(this, opcCounterPos, this.serialNumber));
        }

        private void btnRightHeadLight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmHeadLightR(this, opcCounterPos, this.serialNumber));
        }

        private void btnRightCosLight_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmCosLightR(this, opcCounterPos, this.serialNumber));
        }
    }
}
