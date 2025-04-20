using System;
using System.Configuration;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmMMSConfig : Form
    {
        public frmMMSConfig()
        {
            InitializeComponent();
        }

        private void frmMMSConfig_Load(object sender, EventArgs e)
        {
            txtLoginURL.Text = ConfigurationManager.AppSettings["ApiLoginUrl"];
            txtSaveURL.Text = ConfigurationManager.AppSettings["ApiSaveUrl"];
            txtUserMMS.Text = ConfigurationManager.AppSettings["UsernameMMS"];
            txtPassMMS.Text = ConfigurationManager.AppSettings["PasswordMMS"];
            // Load trạng thái checkbox từ App.config
            cbSpeedMMS.Checked = bool.Parse(ConfigurationManager.AppSettings["SpeedMMS"]);
            cbSideSlipMMS.Checked = bool.Parse(ConfigurationManager.AppSettings["SideSlipMMS"]);
            cbWhistleMMS.Checked = bool.Parse(ConfigurationManager.AppSettings["WhistleMMS"]);
            cbNoiseMMS.Checked = bool.Parse(ConfigurationManager.AppSettings["NoiseMMS"]);
            cbPetrolMMS.Checked = bool.Parse(ConfigurationManager.AppSettings["PetrolMMS"]);
            cbBrakeMMS.Checked = bool.Parse(ConfigurationManager.AppSettings["BrakeMMS"]);
            cbDieselMMS.Checked = bool.Parse(ConfigurationManager.AppSettings["DieselMMS"]);
            cbHLMMS.Checked = bool.Parse(ConfigurationManager.AppSettings["HeadlightsMMS"]);
            cbSteerMMS.Checked = bool.Parse(ConfigurationManager.AppSettings["SteeringAngleMMS"]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string password = Prompt.ShowDialog("Vui lòng nhập mật khẩu để lưu cấu hình:", "Xác nhận mật khẩu");
                // Mở App.config và cập nhật giá trị
                if (!string.IsNullOrEmpty(password))
                {
                    if (ValidatePassword(password))
                    {
                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["ApiLoginUrl"].Value = txtLoginURL.Text;
                        config.AppSettings.Settings["ApiSaveUrl"].Value = txtSaveURL.Text;
                        config.AppSettings.Settings["UsernameMMS"].Value = txtUserMMS.Text;
                        config.AppSettings.Settings["PasswordMMS"].Value = txtPassMMS.Text;
                        // Lưu trạng thái checkbox vào App.config
                        config.AppSettings.Settings["SpeedMMS"].Value = cbSpeedMMS.Checked.ToString().ToLower();
                        config.AppSettings.Settings["SideSlipMMS"].Value = cbSideSlipMMS.Checked.ToString().ToLower();
                        config.AppSettings.Settings["WhistleMMS"].Value = cbWhistleMMS.Checked.ToString().ToLower();
                        config.AppSettings.Settings["NoiseMMS"].Value = cbNoiseMMS.Checked.ToString().ToLower();
                        config.AppSettings.Settings["PetrolMMS"].Value = cbPetrolMMS.Checked.ToString().ToLower();
                        config.AppSettings.Settings["BrakeMMS"].Value = cbBrakeMMS.Checked.ToString().ToLower();
                        config.AppSettings.Settings["DieselMMS"].Value = cbDieselMMS.Checked.ToString().ToLower();
                        config.AppSettings.Settings["HeadlightsMMS"].Value = cbHLMMS.Checked.ToString().ToLower();
                        config.AppSettings.Settings["SteeringAngleMMS"].Value = cbSteerMMS.Checked.ToString().ToLower();

                        // Lưu lại file
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");

                        MessageBox.Show("Cấu hình đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lưu cấu hình đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidatePassword(string enteredPassword)
        {
            string adminPassword = ConfigurationManager.AppSettings["PasswordConfig"];
            return enteredPassword == adminPassword;
        }
    }
}
