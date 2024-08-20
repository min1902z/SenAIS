namespace SenAIS
{
    partial class frmDieselEmission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieselEmission));
            this.DieselPanel = new System.Windows.Forms.Panel();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbHSU = new System.Windows.Forms.Label();
            this.lbMaxSpeed = new System.Windows.Forms.Label();
            this.lbMinTitle = new System.Windows.Forms.Label();
            this.lbMaxTitle = new System.Windows.Forms.Label();
            this.lbHSUTitle = new System.Windows.Forms.Label();
            this.lbMinSpeed = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lbDieselTitle = new System.Windows.Forms.Label();
            this.DieselPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DieselPanel
            // 
            this.DieselPanel.Controls.Add(this.cbReady);
            this.DieselPanel.Controls.Add(this.tableLayoutPanel1);
            this.DieselPanel.Controls.Add(this.btnNext);
            this.DieselPanel.Controls.Add(this.btnPre);
            this.DieselPanel.Controls.Add(this.lbDieselTitle);
            this.DieselPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DieselPanel.Location = new System.Drawing.Point(0, 0);
            this.DieselPanel.Name = "DieselPanel";
            this.DieselPanel.Size = new System.Drawing.Size(1904, 1041);
            this.DieselPanel.TabIndex = 0;
            // 
            // cbReady
            // 
            this.cbReady.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbReady.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbReady.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbReady.BackgroundImage")));
            this.cbReady.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbReady.Checked = true;
            this.cbReady.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReady.Enabled = false;
            this.cbReady.Location = new System.Drawing.Point(11, 13);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(111, 88);
            this.cbReady.TabIndex = 50;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.08716F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.91285F));
            this.tableLayoutPanel1.Controls.Add(this.lbHSU, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbMaxSpeed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbMinTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbMaxTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbHSUTitle, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbMinSpeed, 1, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Calibri", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(130, 129);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1675, 832);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // lbHSU
            // 
            this.lbHSU.AutoSize = true;
            this.lbHSU.Font = new System.Drawing.Font("Calibri", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHSU.Location = new System.Drawing.Point(1126, 554);
            this.lbHSU.Name = "lbHSU";
            this.lbHSU.Size = new System.Drawing.Size(474, 278);
            this.lbHSU.TabIndex = 12;
            this.lbHSU.Text = "0.0";
            // 
            // lbMaxSpeed
            // 
            this.lbMaxSpeed.AutoSize = true;
            this.lbMaxSpeed.Font = new System.Drawing.Font("Calibri", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxSpeed.Location = new System.Drawing.Point(1126, 277);
            this.lbMaxSpeed.Name = "lbMaxSpeed";
            this.lbMaxSpeed.Size = new System.Drawing.Size(474, 277);
            this.lbMaxSpeed.TabIndex = 7;
            this.lbMaxSpeed.Text = "0.0";
            // 
            // lbMinTitle
            // 
            this.lbMinTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMinTitle.AutoSize = true;
            this.lbMinTitle.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinTitle.Location = new System.Drawing.Point(3, 73);
            this.lbMinTitle.Name = "lbMinTitle";
            this.lbMinTitle.Size = new System.Drawing.Size(527, 131);
            this.lbMinTitle.TabIndex = 5;
            this.lbMinTitle.Text = "Tốc độ min";
            this.lbMinTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMaxTitle
            // 
            this.lbMaxTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMaxTitle.AutoSize = true;
            this.lbMaxTitle.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxTitle.Location = new System.Drawing.Point(3, 350);
            this.lbMaxTitle.Name = "lbMaxTitle";
            this.lbMaxTitle.Size = new System.Drawing.Size(542, 131);
            this.lbMaxTitle.TabIndex = 6;
            this.lbMaxTitle.Text = "Tốc độ max";
            this.lbMaxTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHSUTitle
            // 
            this.lbHSUTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHSUTitle.AutoSize = true;
            this.lbHSUTitle.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHSUTitle.Location = new System.Drawing.Point(3, 627);
            this.lbHSUTitle.Name = "lbHSUTitle";
            this.lbHSUTitle.Size = new System.Drawing.Size(240, 131);
            this.lbHSUTitle.TabIndex = 7;
            this.lbHSUTitle.Text = "HSU";
            this.lbHSUTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMinSpeed
            // 
            this.lbMinSpeed.AutoSize = true;
            this.lbMinSpeed.Font = new System.Drawing.Font("Calibri", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinSpeed.Location = new System.Drawing.Point(1126, 0);
            this.lbMinSpeed.Name = "lbMinSpeed";
            this.lbMinSpeed.Size = new System.Drawing.Size(474, 277);
            this.lbMinSpeed.TabIndex = 7;
            this.lbMinSpeed.Text = "0.0";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1807, 994);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
            this.btnNext.TabIndex = 48;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(11, 994);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 47;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            // 
            // lbDieselTitle
            // 
            this.lbDieselTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbDieselTitle.AutoSize = true;
            this.lbDieselTitle.Font = new System.Drawing.Font("Calibri", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDieselTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDieselTitle.Location = new System.Drawing.Point(521, 0);
            this.lbDieselTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDieselTitle.Name = "lbDieselTitle";
            this.lbDieselTitle.Size = new System.Drawing.Size(895, 97);
            this.lbDieselTitle.TabIndex = 46;
            this.lbDieselTitle.Text = "KHÍ XẢ - ĐỘNG CƠ DIESEL";
            this.lbDieselTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmDieselEmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.DieselPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDieselEmission";
            this.Text = "Khí xả - Động cơ Diesel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDieselEmission_FormClosing);
            this.Load += new System.EventHandler(this.frmDieselEmission_Load);
            this.DieselPanel.ResumeLayout(false);
            this.DieselPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DieselPanel;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbHSU;
        private System.Windows.Forms.Label lbMaxSpeed;
        private System.Windows.Forms.Label lbMinTitle;
        private System.Windows.Forms.Label lbMaxTitle;
        private System.Windows.Forms.Label lbHSUTitle;
        private System.Windows.Forms.Label lbMinSpeed;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lbDieselTitle;
    }
}