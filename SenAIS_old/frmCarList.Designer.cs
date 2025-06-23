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
            this.dgVehicleList = new System.Windows.Forms.DataGridView();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CarListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicleList)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CarListPanel
            // 
            this.CarListPanel.Controls.Add(this.tabControl1);
            this.CarListPanel.Controls.Add(this.dgVehicleList);
            this.CarListPanel.Controls.Add(this.btnLoadData);
            this.CarListPanel.Controls.Add(this.btnSelectPath);
            this.CarListPanel.Controls.Add(this.txtFilePath);
            this.CarListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CarListPanel.Location = new System.Drawing.Point(0, 0);
            this.CarListPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CarListPanel.Name = "CarListPanel";
            this.CarListPanel.Size = new System.Drawing.Size(1067, 554);
            this.CarListPanel.TabIndex = 0;
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
            this.dgVehicleList.Location = new System.Drawing.Point(17, 73);
            this.dgVehicleList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgVehicleList.Name = "dgVehicleList";
            this.dgVehicleList.ReadOnly = true;
            this.dgVehicleList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgVehicleList.Size = new System.Drawing.Size(1033, 455);
            this.dgVehicleList.TabIndex = 3;
            this.dgVehicleList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVehicleList_CellClick);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadData.AutoSize = true;
            this.btnLoadData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadData.Location = new System.Drawing.Point(933, 15);
            this.btnLoadData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(113, 42);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Đọc File";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectPath.AutoSize = true;
            this.btnSelectPath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectPath.Location = new System.Drawing.Point(804, 15);
            this.btnSelectPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(131, 42);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "Chọn File";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFilePath.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilePath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtFilePath.Location = new System.Drawing.Point(16, 15);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(741, 32);
            this.txtFilePath.TabIndex = 0;
            this.txtFilePath.Text = "Excel Files|*.xls;*.xlsx";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(103, 198);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(8, 8);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(0, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmCarList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.CarListPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCarList";
            this.ShowIcon = false;
            this.Text = "Danh sách xe mới";
            this.CarListPanel.ResumeLayout(false);
            this.CarListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicleList)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CarListPanel;
        private System.Windows.Forms.DataGridView dgVehicleList;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}