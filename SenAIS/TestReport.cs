using Microsoft.Reporting.WinForms;
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
    public partial class TestReport : Form
    {
        private List<VehicleReportData> reportDataList;
        private DataTable reportData;
        public TestReport(DataTable data)
        {
            InitializeComponent();
            reportData = data;
        }

        private void TestReport_Load(object sender, EventArgs e)
        {
            LoadReport();
            this.reportViewer1.RefreshReport();
        }
        private void LoadReport()
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "SenAIS.Reports.VehicleReport.rdlc";
            ReportDataSource rds = new ReportDataSource("VehicleDataSet", reportData);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}
