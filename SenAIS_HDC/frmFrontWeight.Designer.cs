namespace SenAIS
{
    partial class frmFrontWeight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFrontWeight));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.WeightPanel = new System.Windows.Forms.Panel();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbWeight = new System.Windows.Forms.TableLayoutPanel();
            this.lbRight_RWeight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLeft_FWeight = new System.Windows.Forms.Label();
            this.lbLeft_RWeight = new System.Windows.Forms.Label();
            this.lbRight_FWeight = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSum_FWeight = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbSum_RWeight = new System.Windows.Forms.Label();
            this.lbWeightTitle = new System.Windows.Forms.Label();
            this.WeightPanel.SuspendLayout();
            this.tbWeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(1717, 897);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 37);
            this.button2.TabIndex = 26;
            this.button2.Text = "Tiếp Tục";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(11, 897);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 37);
            this.button1.TabIndex = 25;
            this.button1.Text = "Trở Lại";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.AutoSize = true;
            this.button3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button3.Location = new System.Drawing.Point(1618, 899);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 37);
            this.button3.TabIndex = 28;
            this.button3.Text = "Tiếp Tục";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // WeightPanel
            // 
            this.WeightPanel.AutoSize = true;
            this.WeightPanel.Controls.Add(this.lbVinNumber);
            this.WeightPanel.Controls.Add(this.cbReady);
            this.WeightPanel.Controls.Add(this.btnNext);
            this.WeightPanel.Controls.Add(this.tbWeight);
            this.WeightPanel.Controls.Add(this.lbWeightTitle);
            this.WeightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeightPanel.Location = new System.Drawing.Point(0, 0);
            this.WeightPanel.Name = "WeightPanel";
            this.WeightPanel.Size = new System.Drawing.Size(1370, 749);
            this.WeightPanel.TabIndex = 30;
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(172, -8);
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
            this.cbReady.Location = new System.Drawing.Point(12, 12);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(154, 105);
            this.cbReady.TabIndex = 45;
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
            this.btnNext.Location = new System.Drawing.Point(1226, 693);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(133, 45);
            this.btnNext.TabIndex = 44;
            this.btnNext.Text = "Trang chủ";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbWeight
            // 
            this.tbWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWeight.ColumnCount = 4;
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbWeight.Controls.Add(this.lbRight_RWeight, 2, 2);
            this.tbWeight.Controls.Add(this.label3, 0, 2);
            this.tbWeight.Controls.Add(this.label2, 0, 1);
            this.tbWeight.Controls.Add(this.lbLeft_FWeight, 1, 1);
            this.tbWeight.Controls.Add(this.lbLeft_RWeight, 1, 2);
            this.tbWeight.Controls.Add(this.lbRight_FWeight, 2, 1);
            this.tbWeight.Controls.Add(this.label6, 1, 0);
            this.tbWeight.Controls.Add(this.lbSum_FWeight, 3, 1);
            this.tbWeight.Controls.Add(this.label7, 2, 0);
            this.tbWeight.Controls.Add(this.label8, 3, 0);
            this.tbWeight.Controls.Add(this.lbSum_RWeight, 3, 2);
            this.tbWeight.Location = new System.Drawing.Point(48, 123);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.RowCount = 3;
            this.tbWeight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbWeight.Size = new System.Drawing.Size(1284, 552);
            this.tbWeight.TabIndex = 42;
            this.tbWeight.Visible = false;
            // 
            // lbRight_RWeight
            // 
            this.lbRight_RWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbRight_RWeight.AutoSize = true;
            this.lbRight_RWeight.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight_RWeight.ForeColor = System.Drawing.Color.Blue;
            this.lbRight_RWeight.Location = new System.Drawing.Point(582, 368);
            this.lbRight_RWeight.Name = "lbRight_RWeight";
            this.lbRight_RWeight.Size = new System.Drawing.Size(190, 131);
            this.lbRight_RWeight.TabIndex = 51;
            this.lbRight_RWeight.Text = "0.0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(3, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 156);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cầu Sau\r\n(Kg)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(3, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 156);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cầu Trước\r\n(Kg)\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbLeft_FWeight
            // 
            this.lbLeft_FWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbLeft_FWeight.AutoSize = true;
            this.lbLeft_FWeight.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft_FWeight.ForeColor = System.Drawing.Color.Blue;
            this.lbLeft_FWeight.Location = new System.Drawing.Point(307, 131);
            this.lbLeft_FWeight.Name = "lbLeft_FWeight";
            this.lbLeft_FWeight.Size = new System.Drawing.Size(190, 131);
            this.lbLeft_FWeight.TabIndex = 8;
            this.lbLeft_FWeight.Text = "0.0";
            // 
            // lbLeft_RWeight
            // 
            this.lbLeft_RWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbLeft_RWeight.AutoSize = true;
            this.lbLeft_RWeight.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft_RWeight.ForeColor = System.Drawing.Color.Blue;
            this.lbLeft_RWeight.Location = new System.Drawing.Point(307, 368);
            this.lbLeft_RWeight.Name = "lbLeft_RWeight";
            this.lbLeft_RWeight.Size = new System.Drawing.Size(190, 131);
            this.lbLeft_RWeight.TabIndex = 31;
            this.lbLeft_RWeight.Text = "0.0";
            // 
            // lbRight_FWeight
            // 
            this.lbRight_FWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbRight_FWeight.AutoSize = true;
            this.lbRight_FWeight.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight_FWeight.ForeColor = System.Drawing.Color.Blue;
            this.lbRight_FWeight.Location = new System.Drawing.Point(582, 131);
            this.lbRight_FWeight.Name = "lbRight_FWeight";
            this.lbRight_FWeight.Size = new System.Drawing.Size(190, 131);
            this.lbRight_FWeight.TabIndex = 9;
            this.lbRight_FWeight.Text = "0.0";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(307, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 78);
            this.label6.TabIndex = 52;
            this.label6.Text = "Bánh trái";
            // 
            // lbSum_FWeight
            // 
            this.lbSum_FWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbSum_FWeight.AutoSize = true;
            this.lbSum_FWeight.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSum_FWeight.ForeColor = System.Drawing.Color.Blue;
            this.lbSum_FWeight.Location = new System.Drawing.Point(882, 131);
            this.lbSum_FWeight.Name = "lbSum_FWeight";
            this.lbSum_FWeight.Size = new System.Drawing.Size(190, 131);
            this.lbSum_FWeight.TabIndex = 51;
            this.lbSum_FWeight.Text = "0.0";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(582, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(294, 78);
            this.label7.TabIndex = 53;
            this.label7.Text = "Bánh Phải";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(882, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 78);
            this.label8.TabIndex = 54;
            this.label8.Text = "Tổng";
            // 
            // lbSum_RWeight
            // 
            this.lbSum_RWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbSum_RWeight.AutoSize = true;
            this.lbSum_RWeight.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSum_RWeight.ForeColor = System.Drawing.Color.Blue;
            this.lbSum_RWeight.Location = new System.Drawing.Point(882, 368);
            this.lbSum_RWeight.Name = "lbSum_RWeight";
            this.lbSum_RWeight.Size = new System.Drawing.Size(190, 131);
            this.lbSum_RWeight.TabIndex = 55;
            this.lbSum_RWeight.Text = "0.0";
            // 
            // lbWeightTitle
            // 
            this.lbWeightTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbWeightTitle.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWeightTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbWeightTitle.Location = new System.Drawing.Point(12, 320);
            this.lbWeightTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWeightTitle.Name = "lbWeightTitle";
            this.lbWeightTitle.Size = new System.Drawing.Size(1347, 193);
            this.lbWeightTitle.TabIndex = 41;
            this.lbWeightTitle.Text = "TRỌNG LƯỢNG XE";
            this.lbWeightTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFrontWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.WeightPanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmFrontWeight";
            this.ShowIcon = false;
            this.Text = "Trọng Lượng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFrontWeight_FormClosing);
            this.WeightPanel.ResumeLayout(false);
            this.WeightPanel.PerformLayout();
            this.tbWeight.ResumeLayout(false);
            this.tbWeight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel WeightPanel;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TableLayoutPanel tbWeight;
        private System.Windows.Forms.Label lbLeft_FWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRight_FWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbWeightTitle;
        private System.Windows.Forms.Label lbRight_RWeight;
        private System.Windows.Forms.Label lbLeft_RWeight;
        private System.Windows.Forms.Label lbSum_FWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbSum_RWeight;
    }
}