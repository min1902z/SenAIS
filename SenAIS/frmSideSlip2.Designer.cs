namespace SenAIS
{
    partial class frmSideSlip2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSideSlip2));
            this.SideSlipPanel = new System.Windows.Forms.Panel();
            this.lbStandard = new System.Windows.Forms.Label();
            this.lbStandardTitle = new System.Windows.Forms.Label();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSideSlip = new System.Windows.Forms.Label();
            this.lbSideSlipTitle = new System.Windows.Forms.Label();
            this.SideSlipPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideSlipPanel
            // 
            this.SideSlipPanel.AutoSize = true;
            this.SideSlipPanel.Controls.Add(this.lbStandard);
            this.SideSlipPanel.Controls.Add(this.lbStandardTitle);
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
            this.SideSlipPanel.Size = new System.Drawing.Size(1284, 749);
            this.SideSlipPanel.TabIndex = 2;
            // 
            // lbStandard
            // 
            this.lbStandard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbStandard.AutoSize = true;
            this.lbStandard.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandard.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStandard.Location = new System.Drawing.Point(480, 659);
            this.lbStandard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStandard.Name = "lbStandard";
            this.lbStandard.Size = new System.Drawing.Size(189, 78);
            this.lbStandard.TabIndex = 56;
            this.lbStandard.Text = "--  -  --";
            // 
            // lbStandardTitle
            // 
            this.lbStandardTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbStandardTitle.AutoSize = true;
            this.lbStandardTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandardTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStandardTitle.Location = new System.Drawing.Point(100, 659);
            this.lbStandardTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStandardTitle.Name = "lbStandardTitle";
            this.lbStandardTitle.Size = new System.Drawing.Size(361, 78);
            this.lbStandardTitle.TabIndex = 55;
            this.lbStandardTitle.Text = "Tiêu Chuẩn: ";
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(128, -12);
            this.lbVinNumber.Name = "lbVinNumber";
            this.lbVinNumber.Size = new System.Drawing.Size(334, 131);
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
            this.btnNext.Location = new System.Drawing.Point(1189, 702);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
            this.btnNext.TabIndex = 44;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPre.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(9, 702);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 43;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(886, 629);
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
            this.lbSideSlip.Location = new System.Drawing.Point(234, 120);
            this.lbSideSlip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSideSlip.Name = "lbSideSlip";
            this.lbSideSlip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbSideSlip.Size = new System.Drawing.Size(807, 488);
            this.lbSideSlip.TabIndex = 11;
            this.lbSideSlip.Text = "0.0 ";
            this.lbSideSlip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSideSlip.Visible = false;
            // 
            // lbSideSlipTitle
            // 
            this.lbSideSlipTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbSideSlipTitle.AutoSize = true;
            this.lbSideSlipTitle.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSideSlipTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSideSlipTitle.Location = new System.Drawing.Point(36, 283);
            this.lbSideSlipTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSideSlipTitle.Name = "lbSideSlipTitle";
            this.lbSideSlipTitle.Size = new System.Drawing.Size(1185, 163);
            this.lbSideSlipTitle.TabIndex = 10;
            this.lbSideSlipTitle.Text = "TRƯỢT NGANG SAU";
            this.lbSideSlipTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmSideSlip2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1284, 749);
            this.Controls.Add(this.SideSlipPanel);
            this.Name = "frmSideSlip2";
            this.ShowIcon = false;
            this.Text = "Trượt Ngang Sau";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSideSlip2_FormClosing);
            this.SideSlipPanel.ResumeLayout(false);
            this.SideSlipPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SideSlipPanel;
        private System.Windows.Forms.Label lbStandard;
        private System.Windows.Forms.Label lbStandardTitle;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSideSlip;
        private System.Windows.Forms.Label lbSideSlipTitle;
    }
}