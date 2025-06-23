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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.StandardPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StandardPanel.Name = "StandardPanel";
            this.StandardPanel.Size = new System.Drawing.Size(1371, 750);
            this.StandardPanel.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDelete.Location = new System.Drawing.Point(213, 174);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 50);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.Location = new System.Drawing.Point(17, 174);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 50);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbStandardTitle
            // 
            this.lbStandardTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStandardTitle.AutoSize = true;
            this.lbStandardTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandardTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbStandardTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbStandardTitle.Location = new System.Drawing.Point(72, 11);
            this.lbStandardTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStandardTitle.Name = "lbStandardTitle";
            this.lbStandardTitle.Size = new System.Drawing.Size(1201, 97);
            this.lbStandardTitle.TabIndex = 1;
            this.lbStandardTitle.Text = "Điều Chỉnh Tiêu Chuẩn Chất Lượng";
            this.lbStandardTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgStandards
            // 
            this.dgStandards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStandards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgStandards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStandards.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgStandards.Location = new System.Drawing.Point(17, 249);
            this.dgStandards.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgStandards.Name = "dgStandards";
            this.dgStandards.RowHeadersWidth = 51;
            this.dgStandards.Size = new System.Drawing.Size(1337, 471);
            this.dgStandards.TabIndex = 0;
            // 
            // frmStandards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.StandardPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmStandards";
            this.ShowIcon = false;
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