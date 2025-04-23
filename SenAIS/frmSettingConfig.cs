using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSettingConfig : Form
    {
        public frmSettingConfig()
        {
            InitializeComponent();
            LoadConfigValues();
        }
        private void LoadConfigValues()
        {
            txtPubSeri.Text = ConfigurationManager.AppSettings["PublishSeri"];
            txtPubVer.Text = ConfigurationManager.AppSettings["PublishVer"];
            txtPubDate.Text = ConfigurationManager.AppSettings["PublishDate"];
        }
        private bool ValidatePassword(string inputPassword)
        {
            string adminPassword = ConfigurationManager.AppSettings["PasswordConfig"];
            return inputPassword == adminPassword;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string password = Prompt.ShowDialog("Vui lòng nhập mật khẩu để lưu cấu hình:", "Xác nhận mật khẩu");

                if (!string.IsNullOrEmpty(password))
                {
                    if (ValidatePassword(password))
                    {
                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                        config.AppSettings.Settings["PublishSeri"].Value = txtPubSeri.Text.Trim();
                        config.AppSettings.Settings["PublishVer"].Value = txtPubVer.Text.Trim();
                        config.AppSettings.Settings["PublishDate"].Value = txtPubDate.Text.Trim();

                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");

                        MessageBox.Show("Đã lưu thông tin ban hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lưu bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
