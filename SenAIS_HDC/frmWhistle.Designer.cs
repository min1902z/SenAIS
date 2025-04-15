namespace SenAIS
{
    partial class frmWhistle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWhistle));
            this.WhistlePanel = new System.Windows.Forms.Panel();
            this.lbEngineNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbWhistle = new System.Windows.Forms.Label();
            this.lbWhistleTitle = new System.Windows.Forms.Label();
            this.WhistlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WhistlePanel
            // 
            this.WhistlePanel.Controls.Add(this.lbEngineNumber);
            this.WhistlePanel.Controls.Add(this.cbReady);
            this.WhistlePanel.Controls.Add(this.btnNext);
            this.WhistlePanel.Controls.Add(this.btnPre);
            this.WhistlePanel.Controls.Add(this.label2);
            this.WhistlePanel.Controls.Add(this.lbWhistle);
            this.WhistlePanel.Controls.Add(this.lbWhistleTitle);
            this.WhistlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WhistlePanel.Location = new System.Drawing.Point(0, 0);
            this.WhistlePanel.Name = "WhistlePanel";
            this.WhistlePanel.Size = new System.Drawing.Size(1443, 862);
            this.WhistlePanel.TabIndex = 0;
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.IndianRed;
            this.lbEngineNumber.Location = new System.Drawing.Point(129, 12);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(228, 78);
            this.lbEngineNumber.TabIndex = 49;
            this.lbEngineNumber.Text = "Số Máy";
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
            this.cbReady.Location = new System.Drawing.Point(12, 12);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(111, 88);
            this.cbReady.TabIndex = 44;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1346, 814);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
            this.btnNext.TabIndex = 29;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(11, 814);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 28;
            this.btnPre.Text = "Quay Lại";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(1300, 473);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 163);
            this.label2.TabIndex = 27;
            this.label2.Text = "dB";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbWhistle
            // 
            this.lbWhistle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbWhistle.AutoSize = true;
            this.lbWhistle.Font = new System.Drawing.Font("Calibri", 300F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWhistle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbWhistle.Location = new System.Drawing.Point(229, 266);
            this.lbWhistle.Margin = new System.Windows.Forms.Padding(0);
            this.lbWhistle.Name = "lbWhistle";
            this.lbWhistle.Size = new System.Drawing.Size(920, 488);
            this.lbWhistle.TabIndex = 26;
            this.lbWhistle.Text = "00.0";
            this.lbWhistle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbWhistleTitle
            // 
            this.lbWhistleTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbWhistleTitle.AutoSize = true;
            this.lbWhistleTitle.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWhistleTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbWhistleTitle.Location = new System.Drawing.Point(532, 0);
            this.lbWhistleTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWhistleTitle.Name = "lbWhistleTitle";
            this.lbWhistleTitle.Size = new System.Drawing.Size(678, 117);
            this.lbWhistleTitle.TabIndex = 25;
            this.lbWhistleTitle.Text = "ÂM LƯỢNG CÒI";
            this.lbWhistleTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmWhistle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1443, 862);
            this.Controls.Add(this.WhistlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmWhistle";
            this.Text = "Âm Lượng Còi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWhistle_FormClosing);
            this.Load += new System.EventHandler(this.frmWhistle_Load);
            this.WhistlePanel.ResumeLayout(false);
            this.WhistlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WhistlePanel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbWhistle;
        private System.Windows.Forms.Label lbWhistleTitle;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Label lbEngineNumber;
    }
}