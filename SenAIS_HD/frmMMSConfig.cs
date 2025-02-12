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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở App.config và cập nhật giá trị
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ApiLoginUrl"].Value = txtLoginURL.Text;
                config.AppSettings.Settings["ApiSaveUrl"].Value = txtSaveURL.Text;
                config.AppSettings.Settings["UsernameMMS"].Value = txtUserMMS.Text;
                config.AppSettings.Settings["PasswordMMS"].Value = txtPassMMS.Text;

                // Lưu lại file
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Cấu hình đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
