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
    public partial class SenAIS : Form
    {

        public SenAIS()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            // Đóng form con hiện tại nếu có
            if (panelBody.Controls.Count > 0)
                panelBody.Controls[0].Dispose();

            // Thiết lập form con mới
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Show();
        }
        private void TSHoTro_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Form2());
        }

        private void TSDangKiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInspection());
        }

        private void TSTruyXuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInspection());
        }
    }
}
