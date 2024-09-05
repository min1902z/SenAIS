using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmExportReport : Form
    {
        //private List<VehicleReportData> reportDataList;
        //private string serialNumber;
        private DataTable reportData;
        public frmExportReport(DataTable data)
        {
            InitializeComponent();
            reportData = data;
        }

        private void frmExportReport_Load(object sender, EventArgs e)
        {
            // Tạo instance của báo cáo
            ReportDocument cryRpt = new ReportDocument();

            // Đường dẫn đến file Crystal Report (.rpt)
            string reportPath = "VehicleReports.rpt";
            cryRpt.Load(reportPath);

            // Nạp dữ liệu từ DataTable vào báo cáo
            cryRpt.SetDataSource(reportData);

            // Gán báo cáo cho CrystalReportViewer
            crystalReportViewer1.ReportSource = cryRpt;

            // Làm mới CrystalReportViewer
            crystalReportViewer1.Refresh();
        }
        
    }
}
