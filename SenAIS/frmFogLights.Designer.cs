namespace SenAIS
{
    partial class frmFogLights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFogLights));
            this.LightPanel = new System.Windows.Forms.Panel();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.tbHeadLights = new System.Windows.Forms.TableLayoutPanel();
            this.lbLFLHeight = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbRFLHorizontalDeviation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRFLHeight = new System.Windows.Forms.Label();
            this.lbRFLVerticalDeviation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLFLVerticalDeviation = new System.Windows.Forms.Label();
            this.lbLFLHorizontalDeviation = new System.Windows.Forms.Label();
            this.lbLFLIntensity = new System.Windows.Forms.Label();
            this.lbRFLIntensity = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.LightPanel.SuspendLayout();
            this.tbHeadLights.SuspendLayout();
            this.SuspendLayout();
            // 
            // LightPanel
            // 
            this.LightPanel.AutoSize = true;
            this.LightPanel.Controls.Add(this.lbVinNumber);
            this.LightPanel.Controls.Add(this.cbReady);
            this.LightPanel.Controls.Add(this.tbHeadLights);
            this.LightPanel.Controls.Add(this.btnNext);
            this.LightPanel.Controls.Add(this.btnPre);
            this.LightPanel.Controls.Add(this.lbTitle);
            this.LightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightPanel.Location = new System.Drawing.Point(0, 0);
            this.LightPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LightPanel.Name = "LightPanel";
            this.LightPanel.Size = new System.Drawing.Size(1902, 1033);
            this.LightPanel.TabIndex = 1;
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(172, -14);
            this.lbVinNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVinNumber.Name = "lbVinNumber";
            this.lbVinNumber.Size = new System.Drawing.Size(417, 163);
            this.lbVinNumber.TabIndex = 54;
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
            this.cbReady.TabIndex = 44;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // tbHeadLights
            // 
            this.tbHeadLights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHeadLights.AutoSize = true;
            this.tbHeadLights.ColumnCount = 5;
            this.tbHeadLights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbHeadLights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.Controls.Add(this.lbLFLHeight, 4, 1);
            this.tbHeadLights.Controls.Add(this.label8, 4, 0);
            this.tbHeadLights.Controls.Add(this.lbRFLHorizontalDeviation, 3, 2);
            this.tbHeadLights.Controls.Add(this.label2, 1, 0);
            this.tbHeadLights.Controls.Add(this.label3, 2, 0);
            this.tbHeadLights.Controls.Add(this.lbRFLHeight, 4, 2);
            this.tbHeadLights.Controls.Add(this.lbRFLVerticalDeviation, 2, 2);
            this.tbHeadLights.Controls.Add(this.label4, 0, 1);
            this.tbHeadLights.Controls.Add(this.label1, 0, 2);
            this.tbHeadLights.Controls.Add(this.lbLFLVerticalDeviation, 2, 1);
            this.tbHeadLights.Controls.Add(this.lbLFLHorizontalDeviation, 3, 1);
            this.tbHeadLights.Controls.Add(this.lbLFLIntensity, 1, 1);
            this.tbHeadLights.Controls.Add(this.lbRFLIntensity, 1, 2);
            this.tbHeadLights.Controls.Add(this.label7, 3, 0);
            this.tbHeadLights.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHeadLights.Location = new System.Drawing.Point(39, 148);
            this.tbHeadLights.Margin = new System.Windows.Forms.Padding(4);
            this.tbHeadLights.Name = "tbHeadLights";
            this.tbHeadLights.RowCount = 3;
            this.tbHeadLights.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbHeadLights.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.Size = new System.Drawing.Size(1801, 826);
            this.tbHeadLights.TabIndex = 43;
            this.tbHeadLights.Visible = false;
            // 
            // lbLFLHeight
            // 
            this.lbLFLHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLFLHeight.AutoSize = true;
            this.lbLFLHeight.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLFLHeight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLFLHeight.Location = new System.Drawing.Point(1494, 116);
            this.lbLFLHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLFLHeight.Name = "lbLFLHeight";
            this.lbLFLHeight.Size = new System.Drawing.Size(239, 355);
            this.lbLFLHeight.TabIndex = 51;
            this.lbLFLHeight.Text = "0.0";
            this.lbLFLHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(1507, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 116);
            this.label8.TabIndex = 50;
            this.label8.Text = "Chiều cao\r\n(mm)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbRFLHorizontalDeviation
            // 
            this.lbRFLHorizontalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbRFLHorizontalDeviation.AutoSize = true;
            this.lbRFLHorizontalDeviation.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRFLHorizontalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRFLHorizontalDeviation.Location = new System.Drawing.Point(1120, 471);
            this.lbRFLHorizontalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRFLHorizontalDeviation.Name = "lbRFLHorizontalDeviation";
            this.lbRFLHorizontalDeviation.Size = new System.Drawing.Size(239, 355);
            this.lbRFLHorizontalDeviation.TabIndex = 45;
            this.lbRFLHorizontalDeviation.Text = "0.0";
            this.lbRFLHorizontalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(382, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 116);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cường Độ \r\n(kcd)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(736, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 116);
            this.label3.TabIndex = 7;
            this.label3.Text = "L. Trên/Dưới\r\n(%)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbRFLHeight
            // 
            this.lbRFLHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbRFLHeight.AutoSize = true;
            this.lbRFLHeight.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRFLHeight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRFLHeight.Location = new System.Drawing.Point(1494, 471);
            this.lbRFLHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRFLHeight.Name = "lbRFLHeight";
            this.lbRFLHeight.Size = new System.Drawing.Size(239, 355);
            this.lbRFLHeight.TabIndex = 58;
            this.lbRFLHeight.Text = "0.0";
            this.lbRFLHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRFLVerticalDeviation
            // 
            this.lbRFLVerticalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbRFLVerticalDeviation.AutoSize = true;
            this.lbRFLVerticalDeviation.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRFLVerticalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRFLVerticalDeviation.Location = new System.Drawing.Point(748, 471);
            this.lbRFLVerticalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRFLVerticalDeviation.Name = "lbRFLVerticalDeviation";
            this.lbRFLVerticalDeviation.Size = new System.Drawing.Size(239, 355);
            this.lbRFLVerticalDeviation.TabIndex = 45;
            this.lbRFLVerticalDeviation.Text = "0.0";
            this.lbRFLVerticalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(4, 220);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 146);
            this.label4.TabIndex = 45;
            this.label4.Text = "Sương Mù\r\n Trái";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(4, 575);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 146);
            this.label1.TabIndex = 46;
            this.label1.Text = "Sương Mù \r\nPhải";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLFLVerticalDeviation
            // 
            this.lbLFLVerticalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLFLVerticalDeviation.AutoSize = true;
            this.lbLFLVerticalDeviation.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLFLVerticalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLFLVerticalDeviation.Location = new System.Drawing.Point(748, 116);
            this.lbLFLVerticalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLFLVerticalDeviation.Name = "lbLFLVerticalDeviation";
            this.lbLFLVerticalDeviation.Size = new System.Drawing.Size(239, 355);
            this.lbLFLVerticalDeviation.TabIndex = 9;
            this.lbLFLVerticalDeviation.Text = "0.0";
            this.lbLFLVerticalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLFLHorizontalDeviation
            // 
            this.lbLFLHorizontalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLFLHorizontalDeviation.AutoSize = true;
            this.lbLFLHorizontalDeviation.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLFLHorizontalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLFLHorizontalDeviation.Location = new System.Drawing.Point(1120, 116);
            this.lbLFLHorizontalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLFLHorizontalDeviation.Name = "lbLFLHorizontalDeviation";
            this.lbLFLHorizontalDeviation.Size = new System.Drawing.Size(239, 355);
            this.lbLFLHorizontalDeviation.TabIndex = 10;
            this.lbLFLHorizontalDeviation.Text = "0.0";
            this.lbLFLHorizontalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLFLIntensity
            // 
            this.lbLFLIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLFLIntensity.AutoSize = true;
            this.lbLFLIntensity.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLFLIntensity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLFLIntensity.Location = new System.Drawing.Point(376, 116);
            this.lbLFLIntensity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLFLIntensity.Name = "lbLFLIntensity";
            this.lbLFLIntensity.Size = new System.Drawing.Size(239, 355);
            this.lbLFLIntensity.TabIndex = 8;
            this.lbLFLIntensity.Text = "0.0";
            this.lbLFLIntensity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRFLIntensity
            // 
            this.lbRFLIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbRFLIntensity.AutoSize = true;
            this.lbRFLIntensity.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRFLIntensity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRFLIntensity.Location = new System.Drawing.Point(376, 471);
            this.lbRFLIntensity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRFLIntensity.Name = "lbRFLIntensity";
            this.lbRFLIntensity.Size = new System.Drawing.Size(239, 355);
            this.lbRFLIntensity.TabIndex = 45;
            this.lbRFLIntensity.Text = "0.0";
            this.lbRFLIntensity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(1121, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(238, 116);
            this.label7.TabIndex = 31;
            this.label7.Text = "L. Trái/Phải\r\n(%)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1773, 974);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 46);
            this.btnNext.TabIndex = 42;
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
            this.btnPre.Location = new System.Drawing.Point(15, 974);
            this.btnPre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(115, 46);
            this.btnPre.TabIndex = 41;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTitle.Location = new System.Drawing.Point(16, 311);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1872, 351);
            this.lbTitle.TabIndex = 40;
            this.lbTitle.Text = "Đèn Sương Mù";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmFogLights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.LightPanel);
            this.Name = "frmFogLights";
            this.ShowIcon = false;
            this.Text = "Dự liệu đèn sương mù";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFogLights_FormClosing);
            this.Load += new System.EventHandler(this.frmFogLights_Load);
            this.LightPanel.ResumeLayout(false);
            this.LightPanel.PerformLayout();
            this.tbHeadLights.ResumeLayout(false);
            this.tbHeadLights.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LightPanel;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.TableLayoutPanel tbHeadLights;
        private System.Windows.Forms.Label lbLFLHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbRFLHorizontalDeviation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRFLHeight;
        private System.Windows.Forms.Label lbRFLVerticalDeviation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbLFLVerticalDeviation;
        private System.Windows.Forms.Label lbLFLHorizontalDeviation;
        private System.Windows.Forms.Label lbLFLIntensity;
        private System.Windows.Forms.Label lbRFLIntensity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lbTitle;
    }
}