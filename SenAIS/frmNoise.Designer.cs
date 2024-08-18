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
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNoise = new System.Windows.Forms.Label();
            this.lbNoiseTitle = new System.Windows.Forms.Label();
            this.NoisePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NoisePanel
            // 
            this.NoisePanel.Controls.Add(this.cbReady);
            this.NoisePanel.Controls.Add(this.btnNext);
            this.NoisePanel.Controls.Add(this.btnPre);
            this.NoisePanel.Controls.Add(this.label2);
            this.NoisePanel.Controls.Add(this.lbNoise);
            this.NoisePanel.Controls.Add(this.lbNoiseTitle);
            this.NoisePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoisePanel.Location = new System.Drawing.Point(0, 0);
            this.NoisePanel.Name = "NoisePanel";
            this.NoisePanel.Size = new System.Drawing.Size(1904, 1041);
            this.NoisePanel.TabIndex = 0;
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
            this.cbReady.TabIndex = 47;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1807, 993);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
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
            this.btnPre.Location = new System.Drawing.Point(11, 993);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
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
            this.label2.Location = new System.Drawing.Point(1721, 632);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 131);
            this.label2.TabIndex = 22;
            this.label2.Text = "dB";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNoise
            // 
            this.lbNoise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNoise.AutoSize = true;
            this.lbNoise.Font = new System.Drawing.Font("Calibri", 300F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoise.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbNoise.Location = new System.Drawing.Point(366, 353);
            this.lbNoise.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNoise.Name = "lbNoise";
            this.lbNoise.Size = new System.Drawing.Size(807, 488);
            this.lbNoise.TabIndex = 21;
            this.lbNoise.Text = "0.0 ";
            this.lbNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNoiseTitle
            // 
            this.lbNoiseTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbNoiseTitle.AutoSize = true;
            this.lbNoiseTitle.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoiseTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbNoiseTitle.Location = new System.Drawing.Point(700, 0);
            this.lbNoiseTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNoiseTitle.Name = "lbNoiseTitle";
            this.lbNoiseTitle.Size = new System.Drawing.Size(452, 163);
            this.lbNoiseTitle.TabIndex = 20;
            this.lbNoiseTitle.Text = "ĐỘ ỒN";
            this.lbNoiseTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmNoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.NoisePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmNoise";
            this.Text = "Đo Độ Ồn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNoise_FormClosing);
            this.Load += new System.EventHandler(this.frmNoise_Load);
            this.NoisePanel.ResumeLayout(false);
            this.NoisePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NoisePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNoise;
        private System.Windows.Forms.Label lbNoiseTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.CheckBox cbReady;
    }
}