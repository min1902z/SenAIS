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

namespace SenAIS
{
    public partial class frmWaiting : Form
    {
        private Form parentForm;
        private OPCItem opcItemT99;
        public frmWaiting()
        {
            InitializeComponent();
        }       
        private void btnPre_Click(object sender, EventArgs e)
        {
            object value;
            opcItemT99.Read((short)OPCDataSource.OPCDevice, out value, out _, out _);
            int t99Value = Convert.ToInt32(value);
            ((frmInspection)parentForm).ProcessMeasurement(t99Value - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            object value;
            opcItemT99.Read((short)OPCDataSource.OPCDevice, out value, out _, out _);
            int t99Value = Convert.ToInt32(value);
            ((frmInspection)parentForm).ProcessMeasurement(t99Value + 1);
        }
    }
}
