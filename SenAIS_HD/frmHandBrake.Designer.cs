namespace SenAIS
{
    partial class frmHandBrake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHandBrake));
            this.HandBrakePanel = new System.Windows.Forms.Panel();
            this.lbEngineNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.tbHandBrake = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLeft_Brake = new System.Windows.Forms.Label();
            this.lbDiff_Brake = new System.Windows.Forms.Label();
            this.lbRight_Brake = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbSum_Brake = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lbHandBrakeTitle = new System.Windows.Forms.Label();
            this.HandBrakePanel.SuspendLayout();
            this.tbHandBrake.SuspendLayout();
            this.SuspendLayout();
            // 
            // HandBrakePanel
            // 
            this.HandBrakePanel.AutoScroll = true;
            this.HandBrakePanel.Controls.Add(this.lbEngineNumber);
            this.HandBrakePanel.Controls.Add(this.cbReady);
            this.HandBrakePanel.Controls.Add(this.tbHandBrake);
            this.HandBrakePanel.Controls.Add(this.btnNext);
            this.HandBrakePanel.Controls.Add(this.btnPre);
            this.HandBrakePanel.Controls.Add(this.lbHandBrakeTitle);
            this.HandBrakePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HandBrakePanel.Location = new System.Drawing.Point(0, 0);
            this.HandBrakePanel.Name = "HandBrakePanel";
            this.HandBrakePanel.Size = new System.Drawing.Size(1443, 857);
            this.HandBrakePanel.TabIndex = 0;
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.IndianRed;
            this.lbEngineNumber.Location = new System.Drawing.Point(127, 11);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(199, 78);
            this.lbEngineNumber.TabIndex = 53;
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
            this.cbReady.Location = new System.Drawing.Point(10, 11);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(111, 88);
            this.cbReady.TabIndex = 50;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // tbHandBrake
            // 
            this.tbHandBrake.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHandBrake.AutoScroll = true;
            this.tbHandBrake.ColumnCount = 3;
            this.tbHandBrake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbHandBrake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbHandBrake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbHandBrake.Controls.Add(this.label8, 0, 3);
            this.tbHandBrake.Controls.Add(this.label12, 2, 2);
            this.tbHandBrake.Controls.Add(this.label11, 2, 1);
            this.tbHandBrake.Controls.Add(this.label7, 0, 2);
            this.tbHandBrake.Controls.Add(this.label2, 0, 0);
            this.tbHandBrake.Controls.Add(this.label3, 0, 1);
            this.tbHandBrake.Controls.Add(this.lbLeft_Brake, 1, 0);
            this.tbHandBrake.Controls.Add(this.lbDiff_Brake, 1, 2);
            this.tbHandBrake.Controls.Add(this.lbRight_Brake, 1, 1);
            this.tbHandBrake.Controls.Add(this.label10, 2, 0);
            this.tbHandBrake.Controls.Add(this.lbSum_Brake, 1, 3);
            this.tbHandBrake.Controls.Add(this.label13, 2, 3);
            this.tbHandBrake.Location = new System.Drawing.Point(124, 147);
            this.tbHandBrake.Name = "tbHandBrake";
            this.tbHandBrake.RowCount = 4;
            this.tbHandBrake.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbHandBrake.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbHandBrake.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbHandBrake.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbHandBrake.Size = new System.Drawing.Size(1216, 700);
            this.tbHandBrake.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(3, 624);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 117);
            this.label8.TabIndex = 31;
            this.label8.Text = "Tổng";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(691, 448);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 78);
            this.label12.TabIndex = 30;
            this.label12.Text = "N";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(691, 253);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 78);
            this.label11.TabIndex = 29;
            this.label11.Text = "N";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(3, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(363, 117);
            this.label7.TabIndex = 11;
            this.label7.Text = "Sai Lệch";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(3, 39);
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
            this.label3.Location = new System.Drawing.Point(3, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(390, 117);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bên Phải";
            // 
            // lbLeft_Brake
            // 
            this.lbLeft_Brake.AutoSize = true;
            this.lbLeft_Brake.Font = new System.Drawing.Font("Calibri", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft_Brake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLeft_Brake.Location = new System.Drawing.Point(399, 0);
            this.lbLeft_Brake.Name = "lbLeft_Brake";
            this.lbLeft_Brake.Size = new System.Drawing.Size(287, 195);
            this.lbLeft_Brake.TabIndex = 8;
            this.lbLeft_Brake.Text = "0.0";
            // 
            // lbDiff_Brake
            // 
            this.lbDiff_Brake.AutoSize = true;
            this.lbDiff_Brake.Font = new System.Drawing.Font("Calibri", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiff_Brake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDiff_Brake.Location = new System.Drawing.Point(399, 390);
            this.lbDiff_Brake.Name = "lbDiff_Brake";
            this.lbDiff_Brake.Size = new System.Drawing.Size(287, 195);
            this.lbDiff_Brake.TabIndex = 10;
            this.lbDiff_Brake.Text = "0.0";
            // 
            // lbRight_Brake
            // 
            this.lbRight_Brake.AutoSize = true;
            this.lbRight_Brake.Font = new System.Drawing.Font("Calibri", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight_Brake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRight_Brake.Location = new System.Drawing.Point(399, 195);
            this.lbRight_Brake.Name = "lbRight_Brake";
            this.lbRight_Brake.Size = new System.Drawing.Size(287, 195);
            this.lbRight_Brake.TabIndex = 9;
            this.lbRight_Brake.Text = "0.0";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(691, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 78);
            this.label10.TabIndex = 28;
            this.label10.Text = "N";
            // 
            // lbSum_Brake
            // 
            this.lbSum_Brake.AutoSize = true;
            this.lbSum_Brake.Font = new System.Drawing.Font("Calibri", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSum_Brake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSum_Brake.Location = new System.Drawing.Point(399, 585);
            this.lbSum_Brake.Name = "lbSum_Brake";
            this.lbSum_Brake.Size = new System.Drawing.Size(287, 195);
            this.lbSum_Brake.TabIndex = 13;
            this.lbSum_Brake.Text = "0.0";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(691, 643);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 78);
            this.label13.TabIndex = 32;
            this.label13.Text = "N";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1346, 809);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
            this.btnNext.TabIndex = 48;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPre.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(11, 809);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 47;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // lbHandBrakeTitle
            // 
            this.lbHandBrakeTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbHandBrakeTitle.AutoSize = true;
            this.lbHandBrakeTitle.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHandBrakeTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHandBrakeTitle.Location = new System.Drawing.Point(454, 7);
            this.lbHandBrakeTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbHandBrakeTitle.Name = "lbHandBrakeTitle";
            this.lbHandBrakeTitle.Size = new System.Drawing.Size(689, 117);
            this.lbHandBrakeTitle.TabIndex = 46;
            this.lbHandBrakeTitle.Text = "LỰC PHANH TAY";
            this.lbHandBrakeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmHandBrake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.HandBrakePanel);
            this.Name = "frmHandBrake";
            this.Text = "Lực Phanh Tay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.HandBrakePanel.ResumeLayout(false);
            this.HandBrakePanel.PerformLayout();
            this.tbHandBrake.ResumeLayout(false);
            this.tbHandBrake.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HandBrakePanel;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.TableLayoutPanel tbHandBrake;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLeft_Brake;
        private System.Windows.Forms.Label lbDiff_Brake;
        private System.Windows.Forms.Label lbRight_Brake;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbSum_Brake;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lbHandBrakeTitle;
        private System.Windows.Forms.Label lbEngineNumber;
    }
}