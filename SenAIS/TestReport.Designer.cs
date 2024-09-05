namespace SenAIS
{
    partial class TestReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.vehicleDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vehicleDataSet = new VehicleDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vehicleDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDataSetBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // vehicleDataSetBindingSource
            // 
            this.vehicleDataSetBindingSource.DataSource = this.vehicleDataSet;
            this.vehicleDataSetBindingSource.Position = 0;
            // 
            // vehicleDataSet
            // 
            this.vehicleDataSet.DataSetName = "VehicleDataSet";
            this.vehicleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "VehicleDataSet";
            reportDataSource1.Value = this.vehicleDataSetBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SenAIS.Reports.VehicleReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // vehicleDataSetBindingSource1
            // 
            this.vehicleDataSetBindingSource1.DataSource = this.vehicleDataSet;
            this.vehicleDataSetBindingSource1.Position = 0;
            // 
            // TestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TestReport";
            this.Text = "TestReport";
            this.Load += new System.EventHandler(this.TestReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDataSetBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vehicleDataSetBindingSource;
        private VehicleDataSet vehicleDataSet;
        private System.Windows.Forms.BindingSource vehicleDataSetBindingSource1;
    }
}