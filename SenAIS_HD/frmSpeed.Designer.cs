namespace SenAIS
{
    partial class frmSpeed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpeed));
            this.SpeedPanel = new System.Windows.Forms.Panel();
            this.lbEngineNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNextSpeed = new System.Windows.Forms.Button();
            this.btnPreSpeed = new System.Windows.Forms.Button();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbKmh = new System.Windows.Forms.Label();
            this.lbTitleSpeed = new System.Windows.Forms.Label();
            this.SpeedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpeedPanel
            // 
            this.SpeedPanel.AutoScroll = true;
            this.SpeedPanel.Controls.Add(this.lbEngineNumber);
            this.SpeedPanel.Controls.Add(this.cbReady);
            this.SpeedPanel.Controls.Add(this.btnNextSpeed);
            this.SpeedPanel.Controls.Add(this.btnPreSpeed);
            this.SpeedPanel.Controls.Add(this.lbSpeed);
            this.SpeedPanel.Controls.Add(this.lbKmh);
            this.SpeedPanel.Controls.Add(this.lbTitleSpeed);
            this.SpeedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpeedPanel.Location = new System.Drawing.Point(0, 0);
            this.SpeedPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SpeedPanel.Name = "SpeedPanel";
            this.SpeedPanel.Size = new System.Drawing.Size(1443, 857);
            this.SpeedPanel.TabIndex = 37;
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.IndianRed;
            this.lbEngineNumber.Location = new System.Drawing.Point(126, 11);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(199, 78);
            this.lbEngineNumber.TabIndex = 50;
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
            this.cbReady.Location = new System.Drawing.Point(9, 11);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(111, 88);
            this.cbReady.TabIndex = 43;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNextSpeed
            // 
            this.btnNextSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextSpeed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNextSpeed.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextSpeed.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNextSpeed.Location = new System.Drawing.Point(1348, 811);
            this.btnNextSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNextSpeed.Name = "btnNextSpeed";
            this.btnNextSpeed.Size = new System.Drawing.Size(86, 37);
            this.btnNextSpeed.TabIndex = 42;
            this.btnNextSpeed.Text = "Tiếp Tục";
            this.btnNextSpeed.UseVisualStyleBackColor = false;
            this.btnNextSpeed.Click += new System.EventHandler(this.btnNextSpeed_Click);
            // 
            // btnPreSpeed
            // 
            this.btnPreSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreSpeed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPreSpeed.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreSpeed.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPreSpeed.Location = new System.Drawing.Point(9, 811);
            this.btnPreSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPreSpeed.Name = "btnPreSpeed";
            this.btnPreSpeed.Size = new System.Drawing.Size(86, 37);
            this.btnPreSpeed.TabIndex = 41;
            this.btnPreSpeed.Text = "Trở Lại";
            this.btnPreSpeed.UseVisualStyleBackColor = false;
            this.btnPreSpeed.Click += new System.EventHandler(this.btnPreSpeed_Click);
            // 
            // lbSpeed
            // 
            this.lbSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Font = new System.Drawing.Font("Calibri", 300F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeed.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSpeed.Location = new System.Drawing.Point(191, 206);
            this.lbSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbSpeed.Size = new System.Drawing.Size(807, 488);
            this.lbSpeed.TabIndex = 40;
            this.lbSpeed.Text = "0.0 ";
            this.lbSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbKmh
            // 
            this.lbKmh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbKmh.AutoSize = true;
            this.lbKmh.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKmh.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbKmh.Location = new System.Drawing.Point(1064, 462);
            this.lbKmh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbKmh.Name = "lbKmh";
            this.lbKmh.Size = new System.Drawing.Size(377, 163);
            this.lbKmh.TabIndex = 38;
            this.lbKmh.Text = "Km/h";
            this.lbKmh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitleSpeed
            // 
            this.lbTitleSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitleSpeed.AutoSize = true;
            this.lbTitleSpeed.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleSpeed.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTitleSpeed.Location = new System.Drawing.Point(590, 7);
            this.lbTitleSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitleSpeed.Name = "lbTitleSpeed";
            this.lbTitleSpeed.Size = new System.Drawing.Size(359, 117);
            this.lbTitleSpeed.TabIndex = 37;
            this.lbTitleSpeed.Text = "TỐC ĐỘ";
            this.lbTitleSpeed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.SpeedPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(1203, 656);
            this.Name = "frmSpeed";
            this.ShowIcon = false;
            this.Text = "Tốc Độ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSpeed_FormClosing);
            this.SpeedPanel.ResumeLayout(false);
            this.SpeedPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel SpeedPanel;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbKmh;
        private System.Windows.Forms.Label lbTitleSpeed;
        private System.Windows.Forms.Button btnNextSpeed;
        private System.Windows.Forms.Button btnPreSpeed;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Label lbEngineNumber;
    }
}