using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SenAIS
{
    public partial class frmDieselEmission : Form
    {
        private Form parentForm;
        private OPCItem opcItemT99;
        public frmDieselEmission(Form parent, OPCItem opcItemT99)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.opcItemT99 = opcItemT99;
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị T99 và mở form trước
            try
            {
                opcItemT99.Write(11); // Giá trị cho form chờ hoặc giá trị tương ứng
                ((frmInspection)parentForm).ProcessMeasurement(11);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Thay đổi giá trị T99 và mở form tiếp theo
            try
            {
                opcItemT99.Write(13); // Giá trị cho form tiếp theo hoặc giá trị tương ứng
                ((frmInspection)parentForm).ProcessMeasurement(13);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi giá trị T99: " + ex.Message);
            }
        }
    }
}
