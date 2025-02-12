namespace SenAIS
{
    partial class frmRearWeight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRearWeight));
            this.BWeightPanel = new System.Windows.Forms.Panel();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.tbWeight = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLeft_Weight = new System.Windows.Forms.Label();
            this.lbSum_Weight = new System.Windows.Forms.Label();
            this.lbRight_Weight = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lbWeightTitle = new System.Windows.Forms.Label();
            this.BWeightPanel.SuspendLayout();
            this.tbWeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // BWeightPanel
            // 
            this.BWeightPanel.Controls.Add(this.lbVinNumber);
            this.BWeightPanel.Controls.Add(this.cbReady);
            this.BWeightPanel.Controls.Add(this.tbWeight);
            this.BWeightPanel.Controls.Add(this.btnNext);
            this.BWeightPanel.Controls.Add(this.btnPre);
            this.BWeightPanel.Controls.Add(this.lbWeightTitle);
            this.BWeightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BWeightPanel.Location = new System.Drawing.Point(0, 0);
            this.BWeightPanel.Name = "BWeightPanel";
            this.BWeightPanel.Size = new System.Drawing.Size(1904, 1041);
            this.BWeightPanel.TabIndex = 0;
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(129, -7);
            this.lbVinNumber.Name = "lbVinNumber";
            this.lbVinNumber.Size = new System.Drawing.Size(334, 131);
            this.lbVinNumber.TabIndex = 55;
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
            this.cbReady.Size = new System.Drawing.Size(111, 88);
            this.cbReady.TabIndex = 44;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // tbWeight
            // 
            this.tbWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWeight.ColumnCount = 3;
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.86467F));
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.55653F));
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.51054F));
            this.tbWeight.Controls.Add(this.label12, 2, 2);
            this.tbWeight.Controls.Add(this.label11, 2, 1);
            this.tbWeight.Controls.Add(this.label7, 0, 2);
            this.tbWeight.Controls.Add(this.label2, 0, 0);
            this.tbWeight.Controls.Add(this.label3, 0, 1);
            this.tbWeight.Controls.Add(this.lbLeft_Weight, 1, 0);
            this.tbWeight.Controls.Add(this.lbSum_Weight, 1, 2);
            this.tbWeight.Controls.Add(this.lbRight_Weight, 1, 1);
            this.tbWeight.Controls.Add(this.label10, 2, 0);
            this.tbWeight.Location = new System.Drawing.Point(98, 127);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.RowCount = 3;
            this.tbWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbWeight.Size = new System.Drawing.Size(1707, 861);
            this.tbWeight.TabIndex = 35;
            this.tbWeight.Visible = false;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(1426, 678);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 78);
            this.label12.TabIndex = 30;
            this.label12.Text = "Kg";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(1426, 391);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 78);
            this.label11.TabIndex = 29;
            this.label11.Text = "Kg";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(3, 659);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 117);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tổng";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(3, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(362, 117);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bên Trái";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(3, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(390, 117);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bên Phải";
            // 
            // lbLeft_Weight
            // 
            this.lbLeft_Weight.AutoSize = true;
            this.lbLeft_Weight.Font = new System.Drawing.Font("Calibri", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft_Weight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLeft_Weight.Location = new System.Drawing.Point(564, 0);
            this.lbLeft_Weight.Name = "lbLeft_Weight";
            this.lbLeft_Weight.Size = new System.Drawing.Size(474, 287);
            this.lbLeft_Weight.TabIndex = 8;
            this.lbLeft_Weight.Text = "0.0";
            // 
            // lbSum_Weight
            // 
            this.lbSum_Weight.AutoSize = true;
            this.lbSum_Weight.Font = new System.Drawing.Font("Calibri", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSum_Weight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSum_Weight.Location = new System.Drawing.Point(564, 574);
            this.lbSum_Weight.Name = "lbSum_Weight";
            this.lbSum_Weight.Size = new System.Drawing.Size(474, 287);
            this.lbSum_Weight.TabIndex = 10;
            this.lbSum_Weight.Text = "0.0";
            // 
            // lbRight_Weight
            // 
            this.lbRight_Weight.AutoSize = true;
            this.lbRight_Weight.Font = new System.Drawing.Font("Calibri", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight_Weight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRight_Weight.Location = new System.Drawing.Point(564, 287);
            this.lbRight_Weight.Name = "lbRight_Weight";
            this.lbRight_Weight.Size = new System.Drawing.Size(474, 287);
            this.lbRight_Weight.TabIndex = 9;
            this.lbRight_Weight.Text = "0.0";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(1426, 104);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 78);
            this.label10.TabIndex = 28;
            this.label10.Text = "Kg";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1807, 996);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
            this.btnNext.TabIndex = 34;
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
            this.btnPre.Location = new System.Drawing.Point(11, 996);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 33;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // lbWeightTitle
            // 
            this.lbWeightTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbWeightTitle.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWeightTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbWeightTitle.Location = new System.Drawing.Point(27, 414);
            this.lbWeightTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWeightTitle.Name = "lbWeightTitle";
            this.lbWeightTitle.Size = new System.Drawing.Size(1837, 144);
            this.lbWeightTitle.TabIndex = 32;
            this.lbWeightTitle.Text = "TRỌNG LƯỢNG SAU";
            this.lbWeightTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRearWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.BWeightPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRearWeight";
            this.ShowIcon = false;
            this.Text = "Trọng Lượng Sau";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRearWeight_FormClosing);
            this.BWeightPanel.ResumeLayout(false);
            this.BWeightPanel.PerformLayout();
            this.tbWeight.ResumeLayout(false);
            this.tbWeight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BWeightPanel;
        private System.Windows.Forms.TableLayoutPanel tbWeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLeft_Weight;
        private System.Windows.Forms.Label lbSum_Weight;
        private System.Windows.Forms.Label lbRight_Weight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lbWeightTitle;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Label lbVinNumber;
    }
}