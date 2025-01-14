namespace SenAIS
{
    partial class frmNoise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoise));
            this.NoisePanel = new System.Windows.Forms.Panel();
            this.lbEngineNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNoise = new System.Windows.Forms.Label();
            this.lbNoiseTitle = new System.Windows.Forms.Label();
            this.lbStandard = new System.Windows.Forms.Label();
            this.lbStandardTitle = new System.Windows.Forms.Label();
            this.NoisePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NoisePanel
            // 
            this.NoisePanel.AutoSize = true;
            this.NoisePanel.Controls.Add(this.lbStandard);
            this.NoisePanel.Controls.Add(this.lbStandardTitle);
            this.NoisePanel.Controls.Add(this.lbEngineNumber);
            this.NoisePanel.Controls.Add(this.cbReady);
            this.NoisePanel.Controls.Add(this.btnNext);
            this.NoisePanel.Controls.Add(this.btnPre);
            this.NoisePanel.Controls.Add(this.label2);
            this.NoisePanel.Controls.Add(this.lbNoise);
            this.NoisePanel.Controls.Add(this.lbNoiseTitle);
            this.NoisePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoisePanel.Location = new System.Drawing.Point(0, 0);
            this.NoisePanel.Margin = new System.Windows.Forms.Padding(4);
            this.NoisePanel.Name = "NoisePanel";
            this.NoisePanel.Size = new System.Drawing.Size(1924, 1055);
            this.NoisePanel.TabIndex = 0;
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbEngineNumber.Location = new System.Drawing.Point(172, -6);
            this.lbEngineNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(477, 163);
            this.lbEngineNumber.TabIndex = 48;
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
            this.cbReady.Location = new System.Drawing.Point(16, 15);
            this.cbReady.Margin = new System.Windows.Forms.Padding(4);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(148, 108);
            this.cbReady.TabIndex = 47;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1795, 996);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 46);
            this.btnNext.TabIndex = 46;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPre.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(15, 996);
            this.btnPre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(115, 46);
            this.btnPre.TabIndex = 45;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(1680, 669);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 164);
            this.label2.TabIndex = 22;
            this.label2.Text = "dB";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNoise
            // 
            this.lbNoise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbNoise.AutoSize = true;
            this.lbNoise.Font = new System.Drawing.Font("Calibri", 300F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoise.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbNoise.Location = new System.Drawing.Point(217, 321);
            this.lbNoise.Name = "lbNoise";
            this.lbNoise.Size = new System.Drawing.Size(1008, 610);
            this.lbNoise.TabIndex = 21;
            this.lbNoise.Text = "0.0 ";
            this.lbNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNoiseTitle
            // 
            this.lbNoiseTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbNoiseTitle.AutoSize = true;
            this.lbNoiseTitle.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoiseTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbNoiseTitle.Location = new System.Drawing.Point(803, 11);
            this.lbNoiseTitle.Name = "lbNoiseTitle";
            this.lbNoiseTitle.Size = new System.Drawing.Size(407, 146);
            this.lbNoiseTitle.TabIndex = 20;
            this.lbNoiseTitle.Text = "ĐỘ ỒN";
            this.lbNoiseTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbStandard
            // 
            this.lbStandard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbStandard.AutoSize = true;
            this.lbStandard.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandard.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStandard.Location = new System.Drawing.Point(658, 958);
            this.lbStandard.Name = "lbStandard";
            this.lbStandard.Size = new System.Drawing.Size(239, 97);
            this.lbStandard.TabIndex = 56;
            this.lbStandard.Text = "--  -  --";
            // 
            // lbStandardTitle
            // 
            this.lbStandardTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbStandardTitle.AutoSize = true;
            this.lbStandardTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandardTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStandardTitle.Location = new System.Drawing.Point(156, 958);
            this.lbStandardTitle.Name = "lbStandardTitle";
            this.lbStandardTitle.Size = new System.Drawing.Size(454, 97);
            this.lbStandardTitle.TabIndex = 55;
            this.lbStandardTitle.Text = "Tiêu Chuẩn: ";
            // 
            // frmNoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.NoisePanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNoise";
            this.Text = "Đo Độ Ồn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNoise_FormClosing);
            this.Load += new System.EventHandler(this.frmNoise_Load);
            this.NoisePanel.ResumeLayout(false);
            this.NoisePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel NoisePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNoise;
        private System.Windows.Forms.Label lbNoiseTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Label lbEngineNumber;
        private System.Windows.Forms.Label lbStandard;
        private System.Windows.Forms.Label lbStandardTitle;
    }
}