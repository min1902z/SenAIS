using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmInspection : Form
    {
        private OPCServer opcServer;
        private OPCGroup opcGroup;
        private OPCItem opcCounterPos;
        private SQLHelper sqlHelper;
        private bool isMeasuring = false; // Cờ để xác định khi nào bắt đầu theo dõi
        private string vehicleType;
        private string inspector;
        private string frameNumber;
        public string serialNumber { get; set; }
        private DateTime inspectionDate;
        private string fuelType;
        public frmInspection()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper();
            LoadVehicleInfo();
            InitializeOPC();
        }

        //public frmInspection(SenAIS senAIS)
        //{
        //    this.senAIS = senAIS;
        //}

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
            // Select the form to open based on the counter position
            Form formToOpen = null;
            switch (counterPos)
            {
                case 0:
                    formToOpen = new frmWaiting();
                    break;
                case 1:
                    formToOpen = new frmSpeed(this, opcCounterPos, this.serialNumber);
                    break;
                case 2:
                    formToOpen = new frmSideSlip(this, opcCounterPos, this.serialNumber);
                    break;
                case 3:
                    formToOpen = new frmNoise(this, opcCounterPos, this.serialNumber);
                    break;
                case 4:
                    formToOpen = new frmFrontWeight(this, opcCounterPos, this.serialNumber);
                    break;
                case 5:
                    formToOpen = new frmRearWeight(this, opcCounterPos, this.serialNumber);
                    break;
                case 6:
                    formToOpen = new frmWhistle(this, opcCounterPos, this.serialNumber);
                    break;
                case 7:
                    formToOpen = new frmFrontBrake(this, opcCounterPos, this.serialNumber);
                    break;
                case 8:
                    formToOpen = new frmRearBrake(this, opcCounterPos, this.serialNumber);
                    break;
                case 9:
                    formToOpen = new frmHandBrake(this, opcCounterPos, this.serialNumber);
                    break;
                case 10:
                    formToOpen = new frmHeadlights(this, opcCounterPos, this.serialNumber);
                    break;
                case 14:
                    formToOpen = new frmGasEmission(this, opcCounterPos, this.serialNumber);
                    break;
                case 15:
                    formToOpen = new frmDieselEmission(this, opcCounterPos, this.serialNumber);
                    break;
                default:
                    MessageBox.Show("Invalid counter position.");
                    break;
            }

            // If a form was determined to open, show it
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
            var openedForm = openForms.FirstOrDefault(f => f.GetType() == newForm.GetType());
            if (openedForm != null)
            {
                // Nếu form đã mở, đưa nó lên trước
                openedForm.BringToFront();  // Đưa form lên đầu
                openedForm.Activate();      // Kích hoạt form để nhận focus
            }
            else
            {
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

        private void btnHeadlights_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmHeadlights(this, opcCounterPos, this.serialNumber));
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
            //try
            //{
            //    if (opcCounterPos != null)
            //    {
            //        object value;
            //        opcCounterPos.Read((short)OPCDataSource.OPCDevice, out value, out _, out _);
            //        int t99Value = Convert.ToInt32(value);
            //        ProcessMeasurement(t99Value);
            //    }
            //    else
            //    {
            //        MessageBox.Show("CounterPosition chưa được khởi tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi đọc giá trị CounterPosition: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
            serialNumber = txtSerialNum.Text;
            inspectionDate = dateInSpec.Value;
            fuelType = cbFuel.SelectedItem.ToString();

            if (string.IsNullOrEmpty(vehicleType) || string.IsNullOrEmpty(inspector) ||
                   string.IsNullOrEmpty(frameNumber) || string.IsNullOrEmpty(fuelType) ||
                   string.IsNullOrEmpty(serialNumber))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các trường thông tin của phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            SQLHelper sqlHelper = new SQLHelper();
            sqlHelper.SaveVehicleInfo(vehicleType, inspector, frameNumber, serialNumber, inspectionDate, fuelType);
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

        private void btnSteerAngle_Click(object sender, EventArgs e)
        {
            if (CheckSerialNumber())
                OpenNewForm(new frmSteerAngle(this, opcCounterPos, this.serialNumber));
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
    }
}
