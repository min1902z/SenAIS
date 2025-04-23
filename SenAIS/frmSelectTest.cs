using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public partial class frmSelectTest : Form
    {
        public List<string> SelectedIPs { get; private set; } = new List<string>();

        private string[] allClientIPs;
        public frmSelectTest(string[] clientIPs)
        {
            InitializeComponent();
            allClientIPs = clientIPs;
        }

        private void cbTestAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cbTestAll.Checked;

            // Check hoặc Uncheck tất cả các checkbox máy trạm
            cbTest2.Checked = isChecked;
            cbTest1.Checked = isChecked;
            cbTest3.Checked = isChecked;
            cbTest4.Checked = isChecked;
            cbResult.Checked = isChecked;
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            // Kiểm tra checkbox nào được chọn → Lưu IP
            if (cbTest1.Checked) SelectedIPs.Add(allClientIPs[0]);
            if (cbTest2.Checked) SelectedIPs.Add(allClientIPs[1]);
            if (cbTest3.Checked) SelectedIPs.Add(allClientIPs[2]);
            if (cbTest4.Checked) SelectedIPs.Add(allClientIPs[3]);
            if (cbResult.Checked) SelectedIPs.Add(allClientIPs[4]);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
