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
            this.WeightPanel = new System.Windows.Forms.Panel();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.tbWeight = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbLeft_Weight = new System.Windows.Forms.Label();
            this.lbSum_Weight = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRight_Weight = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbWeightTitle = new System.Windows.Forms.Label();
            this.WeightPanel.SuspendLayout();
            this.tbWeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // WeightPanel
            // 
            this.WeightPanel.AutoSize = true;
            this.WeightPanel.Controls.Add(this.lbVinNumber);
            this.WeightPanel.Controls.Add(this.cbReady);
            this.WeightPanel.Controls.Add(this.btnNext);
            this.WeightPanel.Controls.Add(this.btnPre);
            this.WeightPanel.Controls.Add(this.tbWeight);
            this.WeightPanel.Controls.Add(this.lbWeightTitle);
            this.WeightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeightPanel.Location = new System.Drawing.Point(0, 0);
            this.WeightPanel.Margin = new System.Windows.Forms.Padding(4);
            this.WeightPanel.Name = "WeightPanel";
            this.WeightPanel.Size = new System.Drawing.Size(1924, 1055);
            this.WeightPanel.TabIndex = 31;
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.Red;
            this.lbVinNumber.Location = new System.Drawing.Point(230, -10);
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
            this.cbReady.Location = new System.Drawing.Point(16, 15);
            this.cbReady.Margin = new System.Windows.Forms.Padding(4);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(206, 129);
            this.cbReady.TabIndex = 45;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1794, 996);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 46);
            this.btnNext.TabIndex = 44;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = false;
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
            this.btnPre.TabIndex = 43;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            // 
            // tbWeight
            // 
            this.tbWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWeight.ColumnCount = 3;
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.72161F));
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.27839F));
            this.tbWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbWeight.Controls.Add(this.label12, 2, 2);
            this.tbWeight.Controls.Add(this.label7, 0, 2);
            this.tbWeight.Controls.Add(this.lbLeft_Weight, 1, 0);
            this.tbWeight.Controls.Add(this.lbSum_Weight, 1, 2);
            this.tbWeight.Controls.Add(this.label10, 2, 0);
            this.tbWeight.Controls.Add(this.label2, 0, 0);
            this.tbWeight.Controls.Add(this.lbRight_Weight, 1, 1);
            this.tbWeight.Controls.Add(this.label11, 2, 1);
            this.tbWeight.Controls.Add(this.label3, 0, 1);
            this.tbWeight.Location = new System.Drawing.Point(135, 158);
            this.tbWeight.Margin = new System.Windows.Forms.Padding(4);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.RowCount = 3;
            this.tbWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tbWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tbWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tbWeight.Size = new System.Drawing.Size(1653, 834);
            this.tbWeight.TabIndex = 42;
            this.tbWeight.Visible = false;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(1464, 621);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(185, 146);
            this.label12.TabIndex = 30;
            this.label12.Text = "Kg";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(4, 646);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 97);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tổng";
            // 
            // lbLeft_Weight
            // 
            this.lbLeft_Weight.AutoSize = true;
            this.lbLeft_Weight.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft_Weight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLeft_Weight.Location = new System.Drawing.Point(540, 0);
            this.lbLeft_Weight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLeft_Weight.Name = "lbLeft_Weight";
            this.lbLeft_Weight.Size = new System.Drawing.Size(445, 277);
            this.lbLeft_Weight.TabIndex = 8;
            this.lbLeft_Weight.Text = "0.0";
            // 
            // lbSum_Weight
            // 
            this.lbSum_Weight.AutoSize = true;
            this.lbSum_Weight.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSum_Weight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSum_Weight.Location = new System.Drawing.Point(540, 555);
            this.lbSum_Weight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSum_Weight.Name = "lbSum_Weight";
            this.lbSum_Weight.Size = new System.Drawing.Size(445, 279);
            this.lbSum_Weight.TabIndex = 10;
            this.lbSum_Weight.Text = "0.0";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(1464, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 146);
            this.label10.TabIndex = 28;
            this.label10.Text = "Kg";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(4, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 97);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bên Trái";
            // 
            // lbRight_Weight
            // 
            this.lbRight_Weight.AutoSize = true;
            this.lbRight_Weight.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight_Weight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRight_Weight.Location = new System.Drawing.Point(540, 277);
            this.lbRight_Weight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRight_Weight.Name = "lbRight_Weight";
            this.lbRight_Weight.Size = new System.Drawing.Size(445, 278);
            this.lbRight_Weight.TabIndex = 9;
            this.lbRight_Weight.Text = "0.0";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(1464, 343);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(185, 146);
            this.label11.TabIndex = 29;
            this.label11.Text = "Kg";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(4, 367);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(325, 97);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bên Phải";
            // 
            // lbWeightTitle
            // 
            this.lbWeightTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbWeightTitle.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWeightTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbWeightTitle.Location = new System.Drawing.Point(65, 378);
            this.lbWeightTitle.Name = "lbWeightTitle";
            this.lbWeightTitle.Size = new System.Drawing.Size(1796, 345);
            this.lbWeightTitle.TabIndex = 41;
            this.lbWeightTitle.Text = "TRỌNG LƯỢNG SAU";
            this.lbWeightTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRearWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.WeightPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRearWeight";
            this.Text = "Trọng Lượng Sau";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRearWeight_FormClosing);
            this.WeightPanel.ResumeLayout(false);
            this.WeightPanel.PerformLayout();
            this.tbWeight.ResumeLayout(false);
            this.tbWeight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel WeightPanel;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.TableLayoutPanel tbWeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbLeft_Weight;
        private System.Windows.Forms.Label lbSum_Weight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRight_Weight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbWeightTitle;
    }
}