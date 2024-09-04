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
        private List<VehicleReportData> reportDataList;
        public frmExportReport(List<VehicleReportData> data)
        {
            InitializeComponent();
            reportDataList = data;
        }

        private void frmExportReport_Load(object sender, EventArgs e)
        {
            LoadReport();
            this.rpvVehicleReport.RefreshReport();
        }
        private void LoadReport()
        {
            // Tạo ReportDataSource từ DataTable và gán nó vào ReportViewer
            ReportDataSource rds = new ReportDataSource("VehicleDataSet", reportDataList);
            rpvVehicleReport.LocalReport.DataSources.Clear();
            rpvVehicleReport.LocalReport.DataSources.Add(rds);

            // Đặt đường dẫn tới tệp RDLC
            rpvVehicleReport.LocalReport.ReportPath = "VehicleReport.rdlc";

            // Làm mới ReportViewer để hiển thị báo cáo
            rpvVehicleReport.RefreshReport();
        }
    }
}
