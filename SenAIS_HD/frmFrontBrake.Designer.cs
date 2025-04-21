namespace SenAIS
{
    partial class frmFrontBrake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFrontBrake));
            this.FBrakePanel = new System.Windows.Forms.Panel();
            this.cbBrake = new System.Windows.Forms.CheckBox();
            this.tbRight = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRight_Brake = new System.Windows.Forms.Label();
            this.lbDiff_Brake = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbSum_Brake = new System.Windows.Forms.Label();
            this.lbLeft_Brake = new System.Windows.Forms.Label();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lbBrakeTitle = new System.Windows.Forms.Label();
            this.FBrakePanel.SuspendLayout();
            this.tbRight.SuspendLayout();
            this.tbLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // FBrakePanel
            // 
            this.FBrakePanel.AutoSize = true;
            this.FBrakePanel.Controls.Add(this.cbBrake);
            this.FBrakePanel.Controls.Add(this.tbRight);
            this.FBrakePanel.Controls.Add(this.tbLeft);
            this.FBrakePanel.Controls.Add(this.lbVinNumber);
            this.FBrakePanel.Controls.Add(this.cbReady);
            this.FBrakePanel.Controls.Add(this.btnNext);
            this.FBrakePanel.Controls.Add(this.btnPre);
            this.FBrakePanel.Controls.Add(this.lbBrakeTitle);
            this.FBrakePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FBrakePanel.ForeColor = System.Drawing.Color.Blue;
            this.FBrakePanel.Location = new System.Drawing.Point(0, 0);
            this.FBrakePanel.Margin = new System.Windows.Forms.Padding(4);
            this.FBrakePanel.Name = "FBrakePanel";
            this.FBrakePanel.Size = new System.Drawing.Size(1819, 922);
            this.FBrakePanel.TabIndex = 0;
            // 
            // cbBrake
            // 
            this.cbBrake.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbBrake.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbBrake.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbBrake.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbBrake.BackgroundImage")));
            this.cbBrake.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbBrake.Checked = true;
            this.cbBrake.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBrake.Enabled = false;
            this.cbBrake.Location = new System.Drawing.Point(621, 818);
            this.cbBrake.Margin = new System.Windows.Forms.Padding(4);
            this.cbBrake.Name = "cbBrake";
            this.cbBrake.Size = new System.Drawing.Size(475, 103);
            this.cbBrake.TabIndex = 55;
            this.cbBrake.UseVisualStyleBackColor = false;
            // 
            // tbRight
            // 
            this.tbRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRight.ColumnCount = 2;
            this.tbRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbRight.Controls.Add(this.label3, 1, 0);
            this.tbRight.Controls.Add(this.lbRight_Brake, 0, 0);
            this.tbRight.Controls.Add(this.lbDiff_Brake, 0, 1);
            this.tbRight.Controls.Add(this.label7, 1, 1);
            this.tbRight.Location = new System.Drawing.Point(855, 153);
            this.tbRight.Margin = new System.Windows.Forms.Padding(4);
            this.tbRight.Name = "tbRight";
            this.tbRight.RowCount = 2;
            this.tbRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbRight.Size = new System.Drawing.Size(948, 658);
            this.tbRight.TabIndex = 52;
            this.tbRight.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(828, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 118);
            this.label3.TabIndex = 7;
            this.label3.Text = "Phải \r\n(kgf)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRight_Brake
            // 
            this.lbRight_Brake.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRight_Brake.AutoSize = true;
            this.lbRight_Brake.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight_Brake.ForeColor = System.Drawing.Color.Blue;
            this.lbRight_Brake.Location = new System.Drawing.Point(4, 0);
            this.lbRight_Brake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRight_Brake.Name = "lbRight_Brake";
            this.lbRight_Brake.Size = new System.Drawing.Size(357, 244);
            this.lbRight_Brake.TabIndex = 9;
            this.lbRight_Brake.Text = "0.0";
            this.lbRight_Brake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDiff_Brake
            // 
            this.lbDiff_Brake.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDiff_Brake.AutoSize = true;
            this.lbDiff_Brake.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiff_Brake.ForeColor = System.Drawing.Color.Blue;
            this.lbDiff_Brake.Location = new System.Drawing.Point(4, 329);
            this.lbDiff_Brake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDiff_Brake.Name = "lbDiff_Brake";
            this.lbDiff_Brake.Size = new System.Drawing.Size(357, 244);
            this.lbDiff_Brake.TabIndex = 10;
            this.lbDiff_Brake.Text = "0.0";
            this.lbDiff_Brake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(756, 392);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 118);
            this.label7.TabIndex = 11;
            this.label7.Text = "Sai Lệch \r\n(%)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLeft
            // 
            this.tbLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbLeft.ColumnCount = 2;
            this.tbLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbLeft.Controls.Add(this.label2, 0, 0);
            this.tbLeft.Controls.Add(this.label8, 0, 1);
            this.tbLeft.Controls.Add(this.lbSum_Brake, 1, 1);
            this.tbLeft.Controls.Add(this.lbLeft_Brake, 1, 0);
            this.tbLeft.Location = new System.Drawing.Point(16, 153);
            this.tbLeft.Margin = new System.Windows.Forms.Padding(4);
            this.tbLeft.Name = "tbLeft";
            this.tbLeft.RowCount = 2;
            this.tbLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbLeft.Size = new System.Drawing.Size(793, 658);
            this.tbLeft.TabIndex = 51;
            this.tbLeft.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(4, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 118);
            this.label2.TabIndex = 6;
            this.label2.Text = "Trái\r\n(kgf)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(4, 392);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 118);
            this.label8.TabIndex = 31;
            this.label8.Text = "Tổng \r\n(kgf)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSum_Brake
            // 
            this.lbSum_Brake.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbSum_Brake.AutoSize = true;
            this.lbSum_Brake.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSum_Brake.ForeColor = System.Drawing.Color.Blue;
            this.lbSum_Brake.Location = new System.Drawing.Point(140, 329);
            this.lbSum_Brake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSum_Brake.Name = "lbSum_Brake";
            this.lbSum_Brake.Size = new System.Drawing.Size(357, 244);
            this.lbSum_Brake.TabIndex = 13;
            this.lbSum_Brake.Text = "0.0";
            this.lbSum_Brake.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLeft_Brake
            // 
            this.lbLeft_Brake.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbLeft_Brake.AutoSize = true;
            this.lbLeft_Brake.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft_Brake.ForeColor = System.Drawing.Color.Blue;
            this.lbLeft_Brake.Location = new System.Drawing.Point(140, 0);
            this.lbLeft_Brake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLeft_Brake.Name = "lbLeft_Brake";
            this.lbLeft_Brake.Size = new System.Drawing.Size(357, 244);
            this.lbLeft_Brake.TabIndex = 8;
            this.lbLeft_Brake.Text = "0.0";
            this.lbLeft_Brake.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(229, -20);
            this.lbVinNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVinNumber.Name = "lbVinNumber";
            this.lbVinNumber.Size = new System.Drawing.Size(334, 131);
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
            this.cbReady.Location = new System.Drawing.Point(16, 15);
            this.cbReady.Margin = new System.Windows.Forms.Padding(4);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(205, 129);
            this.cbReady.TabIndex = 44;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.AutoSize = true;
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Blue;
            this.btnNext.Location = new System.Drawing.Point(1587, 846);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(220, 65);
            this.btnNext.TabIndex = 38;
            this.btnNext.Text = "Trang chủ";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.AutoSize = true;
            this.btnPre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPre.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.Color.Blue;
            this.btnPre.Location = new System.Drawing.Point(12, 846);
            this.btnPre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(279, 65);
            this.btnPre.TabIndex = 37;
            this.btnPre.Text = "Trượt Ngang";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // lbBrakeTitle
            // 
            this.lbBrakeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbBrakeTitle.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBrakeTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbBrakeTitle.Location = new System.Drawing.Point(53, 325);
            this.lbBrakeTitle.Name = "lbBrakeTitle";
            this.lbBrakeTitle.Size = new System.Drawing.Size(1717, 262);
            this.lbBrakeTitle.TabIndex = 36;
            this.lbBrakeTitle.Text = "LỰC PHANH TRƯỚC";
            this.lbBrakeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFrontBrake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1819, 922);
            this.Controls.Add(this.FBrakePanel);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFrontBrake";
            this.ShowIcon = false;
            this.Text = "Lực Phanh Trước";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFrontBrake_FormClosing);
            this.FBrakePanel.ResumeLayout(false);
            this.FBrakePanel.PerformLayout();
            this.tbRight.ResumeLayout(false);
            this.tbRight.PerformLayout();
            this.tbLeft.ResumeLayout(false);
            this.tbLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FBrakePanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLeft_Brake;
        private System.Windows.Forms.Label lbDiff_Brake;
        private System.Windows.Forms.Label lbRight_Brake;
        private System.Windows.Forms.Label lbSum_Brake;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lbBrakeTitle;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.TableLayoutPanel tbLeft;
        private System.Windows.Forms.TableLayoutPanel tbRight;
        private System.Windows.Forms.CheckBox cbBrake;
    }
}