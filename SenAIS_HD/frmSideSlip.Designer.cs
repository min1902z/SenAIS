namespace SenAIS
{
    partial class frmSideSlip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSideSlip));
            this.SideSlipPanel = new System.Windows.Forms.Panel();
            this.lbNotice = new System.Windows.Forms.Label();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSideSlip = new System.Windows.Forms.Label();
            this.lbSideSlipTitle = new System.Windows.Forms.Label();
            this.lbStandard = new System.Windows.Forms.Label();
            this.lbStandardTitle = new System.Windows.Forms.Label();
            this.SideSlipPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideSlipPanel
            // 
            this.SideSlipPanel.AutoScroll = true;
            this.SideSlipPanel.Controls.Add(this.lbStandard);
            this.SideSlipPanel.Controls.Add(this.lbStandardTitle);
            this.SideSlipPanel.Controls.Add(this.lbNotice);
            this.SideSlipPanel.Controls.Add(this.lbVinNumber);
            this.SideSlipPanel.Controls.Add(this.cbReady);
            this.SideSlipPanel.Controls.Add(this.btnNext);
            this.SideSlipPanel.Controls.Add(this.btnPre);
            this.SideSlipPanel.Controls.Add(this.label2);
            this.SideSlipPanel.Controls.Add(this.lbSideSlip);
            this.SideSlipPanel.Controls.Add(this.lbSideSlipTitle);
            this.SideSlipPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideSlipPanel.Location = new System.Drawing.Point(0, 0);
            this.SideSlipPanel.Name = "SideSlipPanel";
            this.SideSlipPanel.Size = new System.Drawing.Size(1443, 857);
            this.SideSlipPanel.TabIndex = 0;
            // 
            // lbNotice
            // 
            this.lbNotice.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbNotice.AutoSize = true;
            this.lbNotice.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotice.ForeColor = System.Drawing.Color.DarkRed;
            this.lbNotice.Location = new System.Drawing.Point(249, 797);
            this.lbNotice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new System.Drawing.Size(182, 45);
            this.lbNotice.TabIndex = 52;
            this.lbNotice.Text = "Thông báo";
            this.lbNotice.Visible = false;
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(128, 12);
            this.lbVinNumber.Name = "lbVinNumber";
            this.lbVinNumber.Size = new System.Drawing.Size(199, 78);
            this.lbVinNumber.TabIndex = 49;
            this.lbVinNumber.Text = "Số Vin";
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
            this.cbReady.Location = new System.Drawing.Point(11, 12);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(111, 88);
            this.cbReady.TabIndex = 45;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1346, 809);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
            this.btnNext.TabIndex = 44;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPre.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(11, 809);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 43;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(1040, 678);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 117);
            this.label2.TabIndex = 12;
            this.label2.Text = "m/Km";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSideSlip
            // 
            this.lbSideSlip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbSideSlip.AutoSize = true;
            this.lbSideSlip.Font = new System.Drawing.Font("Calibri", 300F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSideSlip.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSideSlip.Location = new System.Drawing.Point(352, 169);
            this.lbSideSlip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSideSlip.Name = "lbSideSlip";
            this.lbSideSlip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbSideSlip.Size = new System.Drawing.Size(807, 488);
            this.lbSideSlip.TabIndex = 11;
            this.lbSideSlip.Text = "0.0 ";
            this.lbSideSlip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSideSlipTitle
            // 
            this.lbSideSlipTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSideSlipTitle.AutoSize = true;
            this.lbSideSlipTitle.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSideSlipTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSideSlipTitle.Location = new System.Drawing.Point(472, 9);
            this.lbSideSlipTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSideSlipTitle.Name = "lbSideSlipTitle";
            this.lbSideSlipTitle.Size = new System.Drawing.Size(669, 117);
            this.lbSideSlipTitle.TabIndex = 10;
            this.lbSideSlipTitle.Text = "TRƯỢT NGANG";
            this.lbSideSlipTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbStandard
            // 
            this.lbStandard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStandard.AutoSize = true;
            this.lbStandard.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandard.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStandard.Location = new System.Drawing.Point(535, 708);
            this.lbStandard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStandard.Name = "lbStandard";
            this.lbStandard.Size = new System.Drawing.Size(189, 78);
            this.lbStandard.TabIndex = 56;
            this.lbStandard.Text = "--  -  --";
            // 
            // lbStandardTitle
            // 
            this.lbStandardTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStandardTitle.AutoSize = true;
            this.lbStandardTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandardTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStandardTitle.Location = new System.Drawing.Point(158, 708);
            this.lbStandardTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStandardTitle.Name = "lbStandardTitle";
            this.lbStandardTitle.Size = new System.Drawing.Size(361, 78);
            this.lbStandardTitle.TabIndex = 55;
            this.lbStandardTitle.Text = "Tiêu Chuẩn: ";
            // 
            // frmSideSlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.SideSlipPanel);
            this.Name = "frmSideSlip";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trượt Ngang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSideSlip_FormClosing);
            this.SideSlipPanel.ResumeLayout(false);
            this.SideSlipPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SideSlipPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSideSlip;
        private System.Windows.Forms.Label lbSideSlipTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.Label lbNotice;
        private System.Windows.Forms.Label lbStandard;
        private System.Windows.Forms.Label lbStandardTitle;
    }
}