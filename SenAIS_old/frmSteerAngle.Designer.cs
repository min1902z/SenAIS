namespace SenAIS
{
    partial class frmSteerAngle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSteerAngle));
            this.SteerPanel = new System.Windows.Forms.Panel();
            this.cbPosTest = new System.Windows.Forms.CheckBox();
            this.tbSteerAngle = new System.Windows.Forms.TableLayoutPanel();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.lbRight = new System.Windows.Forms.Label();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.lbLeft = new System.Windows.Forms.Label();
            this.lbRightSteerRW = new System.Windows.Forms.Label();
            this.lbLeftSteerRW = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRightSteerLW = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLeftSteerLW = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lbSteerTitle = new System.Windows.Forms.Label();
            this.SteerPanel.SuspendLayout();
            this.tbSteerAngle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // SteerPanel
            // 
            this.SteerPanel.AutoSize = true;
            this.SteerPanel.Controls.Add(this.cbPosTest);
            this.SteerPanel.Controls.Add(this.tbSteerAngle);
            this.SteerPanel.Controls.Add(this.lbVinNumber);
            this.SteerPanel.Controls.Add(this.cbReady);
            this.SteerPanel.Controls.Add(this.btnNext);
            this.SteerPanel.Controls.Add(this.btnPre);
            this.SteerPanel.Controls.Add(this.lbSteerTitle);
            this.SteerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SteerPanel.Location = new System.Drawing.Point(0, 0);
            this.SteerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SteerPanel.Name = "SteerPanel";
            this.SteerPanel.Size = new System.Drawing.Size(1904, 1041);
            this.SteerPanel.TabIndex = 30;
            // 
            // cbPosTest
            // 
            this.cbPosTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPosTest.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbPosTest.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbPosTest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbPosTest.BackgroundImage")));
            this.cbPosTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbPosTest.Checked = true;
            this.cbPosTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPosTest.Enabled = false;
            this.cbPosTest.Location = new System.Drawing.Point(1780, 12);
            this.cbPosTest.Margin = new System.Windows.Forms.Padding(4);
            this.cbPosTest.Name = "cbPosTest";
            this.cbPosTest.Size = new System.Drawing.Size(112, 111);
            this.cbPosTest.TabIndex = 58;
            this.cbPosTest.UseVisualStyleBackColor = false;
            // 
            // tbSteerAngle
            // 
            this.tbSteerAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSteerAngle.ColumnCount = 4;
            this.tbSteerAngle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbSteerAngle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbSteerAngle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbSteerAngle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbSteerAngle.Controls.Add(this.pbRight, 3, 0);
            this.tbSteerAngle.Controls.Add(this.lbRight, 2, 0);
            this.tbSteerAngle.Controls.Add(this.pbLeft, 0, 0);
            this.tbSteerAngle.Controls.Add(this.lbLeft, 1, 0);
            this.tbSteerAngle.Controls.Add(this.lbRightSteerRW, 2, 2);
            this.tbSteerAngle.Controls.Add(this.lbLeftSteerRW, 2, 1);
            this.tbSteerAngle.Controls.Add(this.label4, 0, 2);
            this.tbSteerAngle.Controls.Add(this.lbRightSteerLW, 1, 2);
            this.tbSteerAngle.Controls.Add(this.label2, 1, 3);
            this.tbSteerAngle.Controls.Add(this.lbLeftSteerLW, 1, 1);
            this.tbSteerAngle.Controls.Add(this.label3, 2, 3);
            this.tbSteerAngle.Controls.Add(this.label1, 0, 1);
            this.tbSteerAngle.Location = new System.Drawing.Point(52, 123);
            this.tbSteerAngle.Margin = new System.Windows.Forms.Padding(4);
            this.tbSteerAngle.Name = "tbSteerAngle";
            this.tbSteerAngle.RowCount = 4;
            this.tbSteerAngle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbSteerAngle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbSteerAngle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbSteerAngle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbSteerAngle.Size = new System.Drawing.Size(1802, 905);
            this.tbSteerAngle.TabIndex = 50;
            this.tbSteerAngle.Visible = false;
            // 
            // pbRight
            // 
            this.pbRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbRight.BackgroundImage")));
            this.pbRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbRight.Location = new System.Drawing.Point(925, 2);
            this.pbRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(217, 210);
            this.pbRight.TabIndex = 54;
            this.pbRight.TabStop = false;
            this.pbRight.Visible = false;
            // 
            // lbRight
            // 
            this.lbRight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbRight.AutoSize = true;
            this.lbRight.Font = new System.Drawing.Font("Calibri", 109.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRight.Location = new System.Drawing.Point(579, 0);
            this.lbRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(329, 223);
            this.lbRight.TabIndex = 53;
            this.lbRight.Text = "0.0";
            this.lbRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLeft
            // 
            this.pbLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLeft.BackgroundImage")));
            this.pbLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLeft.Location = new System.Drawing.Point(8, 2);
            this.pbLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(217, 210);
            this.pbLeft.TabIndex = 50;
            this.pbLeft.TabStop = false;
            this.pbLeft.Visible = false;
            // 
            // lbLeft
            // 
            this.lbLeft.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbLeft.AutoSize = true;
            this.lbLeft.Font = new System.Drawing.Font("Calibri", 109.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLeft.Location = new System.Drawing.Point(232, 0);
            this.lbLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(329, 223);
            this.lbLeft.TabIndex = 52;
            this.lbLeft.Text = "0.0";
            this.lbLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRightSteerRW
            // 
            this.lbRightSteerRW.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbRightSteerRW.AutoSize = true;
            this.lbRightSteerRW.Font = new System.Drawing.Font("Calibri", 109.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRightSteerRW.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRightSteerRW.Location = new System.Drawing.Point(579, 446);
            this.lbRightSteerRW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRightSteerRW.Name = "lbRightSteerRW";
            this.lbRightSteerRW.Size = new System.Drawing.Size(329, 223);
            this.lbRightSteerRW.TabIndex = 50;
            this.lbRightSteerRW.Text = "0.0";
            this.lbRightSteerRW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLeftSteerRW
            // 
            this.lbLeftSteerRW.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbLeftSteerRW.AutoSize = true;
            this.lbLeftSteerRW.Font = new System.Drawing.Font("Calibri", 109.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeftSteerRW.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLeftSteerRW.Location = new System.Drawing.Point(579, 223);
            this.lbLeftSteerRW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLeftSteerRW.Name = "lbLeftSteerRW";
            this.lbLeftSteerRW.Size = new System.Drawing.Size(329, 223);
            this.lbLeftSteerRW.TabIndex = 50;
            this.lbLeftSteerRW.Text = "0.0";
            this.lbLeftSteerRW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(4, 521);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 73);
            this.label4.TabIndex = 50;
            this.label4.Text = "Lái Phải";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRightSteerLW
            // 
            this.lbRightSteerLW.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbRightSteerLW.AutoSize = true;
            this.lbRightSteerLW.Font = new System.Drawing.Font("Calibri", 109.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRightSteerLW.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRightSteerLW.Location = new System.Drawing.Point(232, 446);
            this.lbRightSteerLW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRightSteerLW.Name = "lbRightSteerLW";
            this.lbRightSteerLW.Size = new System.Drawing.Size(329, 223);
            this.lbRightSteerLW.TabIndex = 9;
            this.lbRightSteerLW.Text = "0.0";
            this.lbRightSteerLW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(232, 669);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 73);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bánh Trái (°)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLeftSteerLW
            // 
            this.lbLeftSteerLW.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbLeftSteerLW.AutoSize = true;
            this.lbLeftSteerLW.Font = new System.Drawing.Font("Calibri", 109.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeftSteerLW.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLeftSteerLW.Location = new System.Drawing.Point(232, 223);
            this.lbLeftSteerLW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLeftSteerLW.Name = "lbLeftSteerLW";
            this.lbLeftSteerLW.Size = new System.Drawing.Size(329, 223);
            this.lbLeftSteerLW.TabIndex = 8;
            this.lbLeftSteerLW.Text = "0.0";
            this.lbLeftSteerLW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(570, 669);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(348, 73);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bánh Phải (°)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(4, 298);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 73);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lái Trái";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(172, -16);
            this.lbVinNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVinNumber.Name = "lbVinNumber";
            this.lbVinNumber.Size = new System.Drawing.Size(417, 163);
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
            this.cbReady.Location = new System.Drawing.Point(16, 15);
            this.cbReady.Margin = new System.Windows.Forms.Padding(4);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(148, 108);
            this.cbReady.TabIndex = 45;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1777, 985);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 46);
            this.btnNext.TabIndex = 44;
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
            this.btnPre.Location = new System.Drawing.Point(12, 982);
            this.btnPre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(115, 46);
            this.btnPre.TabIndex = 43;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // lbSteerTitle
            // 
            this.lbSteerTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbSteerTitle.AutoSize = true;
            this.lbSteerTitle.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteerTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSteerTitle.Location = new System.Drawing.Point(727, 401);
            this.lbSteerTitle.Name = "lbSteerTitle";
            this.lbSteerTitle.Size = new System.Drawing.Size(466, 146);
            this.lbSteerTitle.TabIndex = 41;
            this.lbSteerTitle.Text = "GÓC LÁI";
            this.lbSteerTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmSteerAngle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.SteerPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSteerAngle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Góc Lái";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSteerAngle_FormClosing);
            this.Load += new System.EventHandler(this.frmSteerAngle_Load);
            this.SteerPanel.ResumeLayout(false);
            this.SteerPanel.PerformLayout();
            this.tbSteerAngle.ResumeLayout(false);
            this.tbSteerAngle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SteerPanel;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lbSteerTitle;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.TableLayoutPanel tbSteerAngle;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.Label lbRight;
        private System.Windows.Forms.Label lbLeft;
        private System.Windows.Forms.Label lbRightSteerRW;
        private System.Windows.Forms.Label lbLeftSteerRW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRightSteerLW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLeftSteerLW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.CheckBox cbPosTest;
    }
}