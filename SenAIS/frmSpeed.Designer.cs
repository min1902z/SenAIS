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
            this.lbEnd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbStandard = new System.Windows.Forms.Label();
            this.lbStandardTitle = new System.Windows.Forms.Label();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNextSpeed = new System.Windows.Forms.Button();
            this.btnPreSpeed = new System.Windows.Forms.Button();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbTitleSpeed = new System.Windows.Forms.Label();
            this.SpeedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpeedPanel
            // 
            this.SpeedPanel.AutoSize = true;
            this.SpeedPanel.Controls.Add(this.lbEnd);
            this.SpeedPanel.Controls.Add(this.label1);
            this.SpeedPanel.Controls.Add(this.lbStandard);
            this.SpeedPanel.Controls.Add(this.lbStandardTitle);
            this.SpeedPanel.Controls.Add(this.lbVinNumber);
            this.SpeedPanel.Controls.Add(this.cbReady);
            this.SpeedPanel.Controls.Add(this.btnNextSpeed);
            this.SpeedPanel.Controls.Add(this.btnPreSpeed);
            this.SpeedPanel.Controls.Add(this.lbSpeed);
            this.SpeedPanel.Controls.Add(this.lbTitleSpeed);
            this.SpeedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpeedPanel.Location = new System.Drawing.Point(0, 0);
            this.SpeedPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SpeedPanel.Name = "SpeedPanel";
            this.SpeedPanel.Size = new System.Drawing.Size(1924, 1055);
            this.SpeedPanel.TabIndex = 38;
            // 
            // lbEnd
            // 
            this.lbEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbEnd.AutoSize = true;
            this.lbEnd.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnd.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbEnd.Location = new System.Drawing.Point(673, 129);
            this.lbEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(549, 164);
            this.lbEnd.TabIndex = 56;
            this.lbEnd.Text = "Kết Thúc";
            this.lbEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbEnd.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(1377, 911);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 146);
            this.label1.TabIndex = 55;
            this.label1.Text = "Km/h";
            // 
            // lbStandard
            // 
            this.lbStandard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbStandard.AutoSize = true;
            this.lbStandard.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandard.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStandard.Location = new System.Drawing.Point(701, 948);
            this.lbStandard.Name = "lbStandard";
            this.lbStandard.Size = new System.Drawing.Size(239, 97);
            this.lbStandard.TabIndex = 54;
            this.lbStandard.Text = "--  -  --";
            // 
            // lbStandardTitle
            // 
            this.lbStandardTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbStandardTitle.AutoSize = true;
            this.lbStandardTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStandardTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStandardTitle.Location = new System.Drawing.Point(199, 948);
            this.lbStandardTitle.Name = "lbStandardTitle";
            this.lbStandardTitle.Size = new System.Drawing.Size(454, 97);
            this.lbStandardTitle.TabIndex = 53;
            this.lbStandardTitle.Text = "Tiêu Chuẩn: ";
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(168, -15);
            this.lbVinNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVinNumber.Name = "lbVinNumber";
            this.lbVinNumber.Size = new System.Drawing.Size(418, 164);
            this.lbVinNumber.TabIndex = 50;
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
            this.cbReady.Location = new System.Drawing.Point(12, 14);
            this.cbReady.Margin = new System.Windows.Forms.Padding(4);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(148, 108);
            this.cbReady.TabIndex = 43;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNextSpeed
            // 
            this.btnNextSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextSpeed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNextSpeed.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextSpeed.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNextSpeed.Location = new System.Drawing.Point(1797, 998);
            this.btnNextSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNextSpeed.Name = "btnNextSpeed";
            this.btnNextSpeed.Size = new System.Drawing.Size(115, 46);
            this.btnNextSpeed.TabIndex = 42;
            this.btnNextSpeed.Text = "Tiếp Tục";
            this.btnNextSpeed.UseVisualStyleBackColor = false;
            // 
            // btnPreSpeed
            // 
            this.btnPreSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreSpeed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPreSpeed.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreSpeed.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPreSpeed.Location = new System.Drawing.Point(12, 998);
            this.btnPreSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreSpeed.Name = "btnPreSpeed";
            this.btnPreSpeed.Size = new System.Drawing.Size(115, 46);
            this.btnPreSpeed.TabIndex = 41;
            this.btnPreSpeed.Text = "Trở Lại";
            this.btnPreSpeed.UseVisualStyleBackColor = false;
            // 
            // lbSpeed
            // 
            this.lbSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSpeed.Font = new System.Drawing.Font("Calibri", 300F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeed.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSpeed.Location = new System.Drawing.Point(49, 168);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbSpeed.Size = new System.Drawing.Size(1823, 660);
            this.lbSpeed.TabIndex = 40;
            this.lbSpeed.Text = "0.0";
            this.lbSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSpeed.Visible = false;
            // 
            // lbTitleSpeed
            // 
            this.lbTitleSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbTitleSpeed.AutoSize = true;
            this.lbTitleSpeed.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleSpeed.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTitleSpeed.Location = new System.Drawing.Point(480, 331);
            this.lbTitleSpeed.Name = "lbTitleSpeed";
            this.lbTitleSpeed.Size = new System.Drawing.Size(932, 305);
            this.lbTitleSpeed.TabIndex = 37;
            this.lbTitleSpeed.Text = "TỐC ĐỘ";
            this.lbTitleSpeed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.SpeedPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1599, 798);
            this.Name = "frmSpeed";
            this.ShowIcon = false;
            this.Text = "Tốc Độ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSpeed_FormClosing);
            this.SpeedPanel.ResumeLayout(false);
            this.SpeedPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SpeedPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbStandard;
        private System.Windows.Forms.Label lbStandardTitle;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Button btnNextSpeed;
        private System.Windows.Forms.Button btnPreSpeed;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbTitleSpeed;
        private System.Windows.Forms.Label lbEnd;
    }
}