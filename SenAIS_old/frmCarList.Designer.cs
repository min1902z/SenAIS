namespace SenAIS
{
    partial class frmCarList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CarListPanel = new System.Windows.Forms.Panel();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dgVehicleList = new System.Windows.Forms.DataGridView();
            this.CarListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicleList)).BeginInit();
            this.SuspendLayout();
            // 
            // CarListPanel
            // 
            this.CarListPanel.Controls.Add(this.dgVehicleList);
            this.CarListPanel.Controls.Add(this.btnLoadData);
            this.CarListPanel.Controls.Add(this.btnSelectPath);
            this.CarListPanel.Controls.Add(this.txtFilePath);
            this.CarListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CarListPanel.Location = new System.Drawing.Point(0, 0);
            this.CarListPanel.Name = "CarListPanel";
            this.CarListPanel.Size = new System.Drawing.Size(800, 450);
            this.CarListPanel.TabIndex = 0;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFilePath.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilePath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtFilePath.Location = new System.Drawing.Point(12, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(557, 27);
            this.txtFilePath.TabIndex = 0;
            this.txtFilePath.Text = "Excel Files|*.xls;*.xlsx";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectPath.AutoSize = true;
            this.btnSelectPath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectPath.Location = new System.Drawing.Point(603, 12);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(79, 29);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "Chọn File";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadData.AutoSize = true;
            this.btnLoadData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadData.Location = new System.Drawing.Point(700, 12);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(79, 29);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Đọc File";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dgVehicleList
            // 
            this.dgVehicleList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgVehicleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgVehicleList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgVehicleList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgVehicleList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVehicleList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVehicleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVehicleList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgVehicleList.Location = new System.Drawing.Point(13, 59);
            this.dgVehicleList.Name = "dgVehicleList";
            this.dgVehicleList.ReadOnly = true;
            this.dgVehicleList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgVehicleList.Size = new System.Drawing.Size(775, 370);
            this.dgVehicleList.TabIndex = 3;
            this.dgVehicleList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVehicleList_CellClick);
            // 
            // frmCarList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CarListPanel);
            this.Name = "frmCarList";
            this.ShowIcon = false;
            this.Text = "Danh sách xe mới";
            this.CarListPanel.ResumeLayout(false);
            this.CarListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicleList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CarListPanel;
        private System.Windows.Forms.DataGridView dgVehicleList;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtFilePath;
    }
}