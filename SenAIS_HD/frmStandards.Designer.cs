namespace SenAIS
{
    partial class frmStandards
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
            this.StandardPanel = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbStandardTitle = new System.Windows.Forms.Label();
            this.dgStandards = new System.Windows.Forms.DataGridView();
            this.StandardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStandards)).BeginInit();
            this.SuspendLayout();
            // 
            // StandardPanel
            // 
            this.StandardPanel.AutoScroll = true;
            this.StandardPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.StandardPanel.Controls.Add(this.btnDelete);
            this.StandardPanel.Controls.Add(this.btnSave);
            this.StandardPanel.Controls.Add(this.lbStandardTitle);
            this.StandardPanel.Controls.Add(this.dgStandards);
            this.StandardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StandardPanel.Location = new System.Drawing.Point(0, 0);
            this.StandardPanel.Name = "StandardPanel";
            this.StandardPanel.Size = new System.Drawing.Size(1443, 857);
            this.StandardPanel.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDelete.Location = new System.Drawing.Point(160, 141);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 41);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.Location = new System.Drawing.Point(13, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 41);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbStandardTitle
            // 
            this.lbStandardTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStandardTitle.AutoSize = true;
            this.lbStandardTitle.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold);
            this.lbStandardTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbStandardTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbStandardTitle.Location = new System.Drawing.Point(73, 0);
            this.lbStandardTitle.Name = "lbStandardTitle";
            this.lbStandardTitle.Size = new System.Drawing.Size(1446, 117);
            this.lbStandardTitle.TabIndex = 1;
            this.lbStandardTitle.Text = "Điều Chỉnh Tiêu Chuẩn Chất Lượng";
            this.lbStandardTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgStandards
            // 
            this.dgStandards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStandards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgStandards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStandards.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgStandards.Location = new System.Drawing.Point(13, 202);
            this.dgStandards.Name = "dgStandards";
            this.dgStandards.RowHeadersWidth = 51;
            this.dgStandards.Size = new System.Drawing.Size(1418, 573);
            this.dgStandards.TabIndex = 0;
            // 
            // frmStandards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.StandardPanel);
            this.Name = "frmStandards";
            this.Text = "Tiêu Chuẩn Chất Lượng Xe";
            this.StandardPanel.ResumeLayout(false);
            this.StandardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStandards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StandardPanel;
        private System.Windows.Forms.DataGridView dgStandards;
        private System.Windows.Forms.Label lbStandardTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
    }
}