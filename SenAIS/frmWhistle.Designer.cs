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
            this.lbEnd = new System.Windows.Forms.Label();
            this.lbStandard = new System.Windows.Forms.Label();
            this.lbStandardTitle = new System.Windows.Forms.Label();
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
            this.WhistlePanel.AutoSize = true;
            this.WhistlePanel.Controls.Add(this.lbEnd);
            this.WhistlePanel.Controls.Add(this.lbStandard);
            this.WhistlePanel.Controls.Add(this.lbStandardTitle);
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
            this.WhistlePanel.Size = new System.Drawing.Size(1443, 857);
            this.WhistlePanel.TabIndex = 0;
            // 
            // lbEnd
            // 
            this.lbEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbEnd.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnd.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbEnd.Location = new System.Drawing.Point(37, 103);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(1361, 131);
            this.lbEnd.TabIndex = 58;
            this.lbEnd.Text = "Kết Thúc";
            this.lbEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbEnd.Visible = false;
            // 
            // lbStandard
            // 
            this.lbStandard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbStandard.AutoSize = true;
            this.lbStandard.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandard.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStandard.Location = new System.Drawing.Point(535, 768);
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
            this.lbStandardTitle.Location = new System.Drawing.Point(157, 772);
            this.lbStandardTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStandardTitle.Name = "lbStandardTitle";
            this.lbStandardTitle.Size = new System.Drawing.Size(361, 78);
            this.lbStandardTitle.TabIndex = 55;
            this.lbStandardTitle.Text = "Tiêu Chuẩn: ";
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbEngineNumber.Location = new System.Drawing.Point(129, -15);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(334, 131);
            this.lbEngineNumber.TabIndex = 49;
            this.lbEngineNumber.Text = "Số Vin";
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
            this.btnNext.Location = new System.Drawing.Point(1348, 809);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnPre.Location = new System.Drawing.Point(9, 809);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 28;
            this.btnPre.Text = "Quay Lại";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(1090, 704);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 163);
            this.label2.TabIndex = 27;
            this.label2.Text = "dB";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbWhistle
            // 
            this.lbWhistle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWhistle.Font = new System.Drawing.Font("Calibri", 300F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWhistle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbWhistle.Location = new System.Drawing.Point(39, 140);
            this.lbWhistle.Margin = new System.Windows.Forms.Padding(0);
            this.lbWhistle.Name = "lbWhistle";
            this.lbWhistle.Size = new System.Drawing.Size(1359, 577);
            this.lbWhistle.TabIndex = 26;
            this.lbWhistle.Text = "0.0";
            this.lbWhistle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbWhistle.Visible = false;
            // 
            // lbWhistleTitle
            // 
            this.lbWhistleTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbWhistleTitle.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWhistleTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbWhistleTitle.Location = new System.Drawing.Point(12, 281);
            this.lbWhistleTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWhistleTitle.Name = "lbWhistleTitle";
            this.lbWhistleTitle.Size = new System.Drawing.Size(1420, 243);
            this.lbWhistleTitle.TabIndex = 25;
            this.lbWhistleTitle.Text = "ÂM LƯỢNG CÒI";
            this.lbWhistleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmWhistle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.WhistlePanel);
            this.Name = "frmWhistle";
            this.ShowIcon = false;
            this.Text = "Âm Lượng Còi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWhistle_FormClosing);
            this.Load += new System.EventHandler(this.frmWhistle_Load);
            this.WhistlePanel.ResumeLayout(false);
            this.WhistlePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lbStandard;
        private System.Windows.Forms.Label lbStandardTitle;
        private System.Windows.Forms.Label lbEnd;
    }
}