namespace SenAIS
{
    partial class frmInspector
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
            this.InspectorPanel = new System.Windows.Forms.Panel();
            this.lbStandardTitle = new System.Windows.Forms.Label();
            this.dgInspector = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.InspectorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInspector)).BeginInit();
            this.SuspendLayout();
            // 
            // InspectorPanel
            // 
            this.InspectorPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.InspectorPanel.Controls.Add(this.btnDelete);
            this.InspectorPanel.Controls.Add(this.btnSave);
            this.InspectorPanel.Controls.Add(this.dgInspector);
            this.InspectorPanel.Controls.Add(this.lbStandardTitle);
            this.InspectorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InspectorPanel.Location = new System.Drawing.Point(0, 0);
            this.InspectorPanel.Name = "InspectorPanel";
            this.InspectorPanel.Size = new System.Drawing.Size(800, 450);
            this.InspectorPanel.TabIndex = 0;
            // 
            // lbStandardTitle
            // 
            this.lbStandardTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStandardTitle.AutoSize = true;
            this.lbStandardTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandardTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbStandardTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbStandardTitle.Location = new System.Drawing.Point(123, 9);
            this.lbStandardTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStandardTitle.Name = "lbStandardTitle";
            this.lbStandardTitle.Size = new System.Drawing.Size(563, 97);
            this.lbStandardTitle.TabIndex = 2;
            this.lbStandardTitle.Text = "Người Kiểm Tra";
            this.lbStandardTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgInspector
            // 
            this.dgInspector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgInspector.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInspector.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgInspector.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgInspector.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInspector.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgInspector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInspector.Location = new System.Drawing.Point(140, 138);
            this.dgInspector.Name = "dgInspector";
            this.dgInspector.RowHeadersWidth = 51;
            this.dgInspector.RowTemplate.Height = 24;
            this.dgInspector.Size = new System.Drawing.Size(520, 279);
            this.dgInspector.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.Location = new System.Drawing.Point(679, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 44);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDelete.Location = new System.Drawing.Point(679, 220);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 44);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InspectorPanel);
            this.Name = "frmInspector";
            this.Text = "Người Kiểm Tra";
            this.InspectorPanel.ResumeLayout(false);
            this.InspectorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInspector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InspectorPanel;
        private System.Windows.Forms.Label lbStandardTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgInspector;
    }
}