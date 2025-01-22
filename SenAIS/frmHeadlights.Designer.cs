namespace SenAIS
{
    partial class frmHeadlights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHeadlights));
            this.CosLightPanel = new System.Windows.Forms.Panel();
            this.cbRight = new System.Windows.Forms.CheckBox();
            this.cbLeft = new System.Windows.Forms.CheckBox();
            this.lbEngineNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.tbHeadLights = new System.Windows.Forms.TableLayoutPanel();
            this.lbLBRHorizontalDeviation = new System.Windows.Forms.Label();
            this.lbLBRIntensity = new System.Windows.Forms.Label();
            this.lbLBLHorizontalDeviation = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLBLVerticalDeviation = new System.Windows.Forms.Label();
            this.lbHBRIntensity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbHBLVerticalDeviation = new System.Windows.Forms.Label();
            this.lbHBLHorizontalDeviation = new System.Windows.Forms.Label();
            this.lbHBLIntensity = new System.Windows.Forms.Label();
            this.lbLBRVerticalDeviation = new System.Windows.Forms.Label();
            this.lbLBLIntensity = new System.Windows.Forms.Label();
            this.lbHBRVerticalDeviation = new System.Windows.Forms.Label();
            this.lbHBRHorizontalDeviation = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.CosLightPanel.SuspendLayout();
            this.tbHeadLights.SuspendLayout();
            this.SuspendLayout();
            // 
            // CosLightPanel
            // 
            this.CosLightPanel.AutoSize = true;
            this.CosLightPanel.Controls.Add(this.cbRight);
            this.CosLightPanel.Controls.Add(this.cbLeft);
            this.CosLightPanel.Controls.Add(this.lbEngineNumber);
            this.CosLightPanel.Controls.Add(this.cbReady);
            this.CosLightPanel.Controls.Add(this.tbHeadLights);
            this.CosLightPanel.Controls.Add(this.btnNext);
            this.CosLightPanel.Controls.Add(this.btnPre);
            this.CosLightPanel.Controls.Add(this.lbTitle);
            this.CosLightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CosLightPanel.Location = new System.Drawing.Point(0, 0);
            this.CosLightPanel.Margin = new System.Windows.Forms.Padding(4);
            this.CosLightPanel.Name = "CosLightPanel";
            this.CosLightPanel.Size = new System.Drawing.Size(1924, 1055);
            this.CosLightPanel.TabIndex = 0;
            // 
            // cbRight
            // 
            this.cbRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRight.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbRight.BackgroundImage")));
            this.cbRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbRight.Checked = true;
            this.cbRight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRight.Enabled = false;
            this.cbRight.Location = new System.Drawing.Point(1762, 4);
            this.cbRight.Margin = new System.Windows.Forms.Padding(4);
            this.cbRight.Name = "cbRight";
            this.cbRight.Size = new System.Drawing.Size(158, 119);
            this.cbRight.TabIndex = 56;
            this.cbRight.UseVisualStyleBackColor = false;
            // 
            // cbLeft
            // 
            this.cbLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbLeft.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbLeft.BackgroundImage")));
            this.cbLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbLeft.Checked = true;
            this.cbLeft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLeft.Enabled = false;
            this.cbLeft.Location = new System.Drawing.Point(1589, 4);
            this.cbLeft.Margin = new System.Windows.Forms.Padding(4);
            this.cbLeft.Name = "cbLeft";
            this.cbLeft.Size = new System.Drawing.Size(165, 119);
            this.cbLeft.TabIndex = 55;
            this.cbLeft.UseVisualStyleBackColor = false;
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbEngineNumber.Location = new System.Drawing.Point(172, -13);
            this.lbEngineNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(417, 163);
            this.lbEngineNumber.TabIndex = 54;
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
            this.tbHeadLights.ColumnCount = 4;
            this.tbHeadLights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbHeadLights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbHeadLights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbHeadLights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbHeadLights.Controls.Add(this.lbLBRHorizontalDeviation, 3, 4);
            this.tbHeadLights.Controls.Add(this.lbLBRIntensity, 1, 4);
            this.tbHeadLights.Controls.Add(this.lbLBLHorizontalDeviation, 3, 2);
            this.tbHeadLights.Controls.Add(this.label5, 0, 3);
            this.tbHeadLights.Controls.Add(this.label7, 3, 0);
            this.tbHeadLights.Controls.Add(this.label2, 1, 0);
            this.tbHeadLights.Controls.Add(this.label3, 2, 0);
            this.tbHeadLights.Controls.Add(this.lbLBLVerticalDeviation, 2, 2);
            this.tbHeadLights.Controls.Add(this.lbHBRIntensity, 1, 3);
            this.tbHeadLights.Controls.Add(this.label4, 0, 1);
            this.tbHeadLights.Controls.Add(this.label1, 0, 2);
            this.tbHeadLights.Controls.Add(this.label6, 0, 4);
            this.tbHeadLights.Controls.Add(this.lbHBLVerticalDeviation, 2, 1);
            this.tbHeadLights.Controls.Add(this.lbHBLHorizontalDeviation, 3, 1);
            this.tbHeadLights.Controls.Add(this.lbHBLIntensity, 1, 1);
            this.tbHeadLights.Controls.Add(this.lbLBRVerticalDeviation, 2, 4);
            this.tbHeadLights.Controls.Add(this.lbLBLIntensity, 1, 2);
            this.tbHeadLights.Controls.Add(this.lbHBRVerticalDeviation, 2, 3);
            this.tbHeadLights.Controls.Add(this.lbHBRHorizontalDeviation, 3, 3);
            this.tbHeadLights.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHeadLights.Location = new System.Drawing.Point(39, 148);
            this.tbHeadLights.Margin = new System.Windows.Forms.Padding(4);
            this.tbHeadLights.Name = "tbHeadLights";
            this.tbHeadLights.RowCount = 5;
            this.tbHeadLights.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbHeadLights.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbHeadLights.Size = new System.Drawing.Size(1849, 848);
            this.tbHeadLights.TabIndex = 43;
            this.tbHeadLights.Visible = false;
            // 
            // lbLBRHorizontalDeviation
            // 
            this.lbLBRHorizontalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLBRHorizontalDeviation.AutoSize = true;
            this.lbLBRHorizontalDeviation.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLBRHorizontalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLBRHorizontalDeviation.Location = new System.Drawing.Point(1474, 665);
            this.lbLBRHorizontalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLBRHorizontalDeviation.Name = "lbLBRHorizontalDeviation";
            this.lbLBRHorizontalDeviation.Size = new System.Drawing.Size(216, 183);
            this.lbLBRHorizontalDeviation.TabIndex = 45;
            this.lbLBRHorizontalDeviation.Text = "0.0";
            this.lbLBRHorizontalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLBRIntensity
            // 
            this.lbLBRIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLBRIntensity.AutoSize = true;
            this.lbLBRIntensity.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLBRIntensity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLBRIntensity.Location = new System.Drawing.Point(410, 665);
            this.lbLBRIntensity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLBRIntensity.Name = "lbLBRIntensity";
            this.lbLBRIntensity.Size = new System.Drawing.Size(216, 183);
            this.lbLBRIntensity.TabIndex = 45;
            this.lbLBRIntensity.Text = "0.0";
            this.lbLBRIntensity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLBLHorizontalDeviation
            // 
            this.lbLBLHorizontalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLBLHorizontalDeviation.AutoSize = true;
            this.lbLBLHorizontalDeviation.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLBLHorizontalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLBLHorizontalDeviation.Location = new System.Drawing.Point(1474, 299);
            this.lbLBLHorizontalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLBLHorizontalDeviation.Name = "lbLBLHorizontalDeviation";
            this.lbLBLHorizontalDeviation.Size = new System.Drawing.Size(216, 183);
            this.lbLBLHorizontalDeviation.TabIndex = 45;
            this.lbLBLHorizontalDeviation.Text = "0.0";
            this.lbLBLHorizontalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(4, 537);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 73);
            this.label5.TabIndex = 46;
            this.label5.Text = "Pha Phải";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(1463, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(238, 116);
            this.label7.TabIndex = 31;
            this.label7.Text = "L. Trái/Phải\r\n(cm/dam)";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(404, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 116);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cường Độ \r\n(100xCd)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(918, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 116);
            this.label3.TabIndex = 7;
            this.label3.Text = "L. Trên/Dưới\r\n(cm/dam)";
            // 
            // lbLBLVerticalDeviation
            // 
            this.lbLBLVerticalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLBLVerticalDeviation.AutoSize = true;
            this.lbLBLVerticalDeviation.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLBLVerticalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLBLVerticalDeviation.Location = new System.Drawing.Point(942, 299);
            this.lbLBLVerticalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLBLVerticalDeviation.Name = "lbLBLVerticalDeviation";
            this.lbLBLVerticalDeviation.Size = new System.Drawing.Size(216, 183);
            this.lbLBLVerticalDeviation.TabIndex = 45;
            this.lbLBLVerticalDeviation.Text = "0.0";
            this.lbLBLVerticalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHBRIntensity
            // 
            this.lbHBRIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHBRIntensity.AutoSize = true;
            this.lbHBRIntensity.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHBRIntensity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHBRIntensity.Location = new System.Drawing.Point(410, 482);
            this.lbHBRIntensity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHBRIntensity.Name = "lbHBRIntensity";
            this.lbHBRIntensity.Size = new System.Drawing.Size(216, 183);
            this.lbHBRIntensity.TabIndex = 48;
            this.lbHBRIntensity.Text = "0.0";
            this.lbHBRIntensity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(4, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 73);
            this.label4.TabIndex = 45;
            this.label4.Text = "Pha Trái";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(4, 354);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 73);
            this.label1.TabIndex = 46;
            this.label1.Text = "Cốt Trái";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(4, 720);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 73);
            this.label6.TabIndex = 47;
            this.label6.Text = "Cốt Phải";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbHBLVerticalDeviation
            // 
            this.lbHBLVerticalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHBLVerticalDeviation.AutoSize = true;
            this.lbHBLVerticalDeviation.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHBLVerticalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHBLVerticalDeviation.Location = new System.Drawing.Point(942, 116);
            this.lbHBLVerticalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHBLVerticalDeviation.Name = "lbHBLVerticalDeviation";
            this.lbHBLVerticalDeviation.Size = new System.Drawing.Size(216, 183);
            this.lbHBLVerticalDeviation.TabIndex = 9;
            this.lbHBLVerticalDeviation.Text = "0.0";
            this.lbHBLVerticalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHBLHorizontalDeviation
            // 
            this.lbHBLHorizontalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHBLHorizontalDeviation.AutoSize = true;
            this.lbHBLHorizontalDeviation.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHBLHorizontalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHBLHorizontalDeviation.Location = new System.Drawing.Point(1474, 116);
            this.lbHBLHorizontalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHBLHorizontalDeviation.Name = "lbHBLHorizontalDeviation";
            this.lbHBLHorizontalDeviation.Size = new System.Drawing.Size(216, 183);
            this.lbHBLHorizontalDeviation.TabIndex = 10;
            this.lbHBLHorizontalDeviation.Text = "0.0";
            this.lbHBLHorizontalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHBLIntensity
            // 
            this.lbHBLIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHBLIntensity.AutoSize = true;
            this.lbHBLIntensity.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHBLIntensity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHBLIntensity.Location = new System.Drawing.Point(410, 116);
            this.lbHBLIntensity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHBLIntensity.Name = "lbHBLIntensity";
            this.lbHBLIntensity.Size = new System.Drawing.Size(216, 183);
            this.lbHBLIntensity.TabIndex = 8;
            this.lbHBLIntensity.Text = "0.0";
            this.lbHBLIntensity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLBRVerticalDeviation
            // 
            this.lbLBRVerticalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLBRVerticalDeviation.AutoSize = true;
            this.lbLBRVerticalDeviation.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLBRVerticalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLBRVerticalDeviation.Location = new System.Drawing.Point(942, 665);
            this.lbLBRVerticalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLBRVerticalDeviation.Name = "lbLBRVerticalDeviation";
            this.lbLBRVerticalDeviation.Size = new System.Drawing.Size(216, 183);
            this.lbLBRVerticalDeviation.TabIndex = 45;
            this.lbLBRVerticalDeviation.Text = "0.0";
            this.lbLBRVerticalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLBLIntensity
            // 
            this.lbLBLIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbLBLIntensity.AutoSize = true;
            this.lbLBLIntensity.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLBLIntensity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLBLIntensity.Location = new System.Drawing.Point(410, 299);
            this.lbLBLIntensity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLBLIntensity.Name = "lbLBLIntensity";
            this.lbLBLIntensity.Size = new System.Drawing.Size(216, 183);
            this.lbLBLIntensity.TabIndex = 45;
            this.lbLBLIntensity.Text = "0.0";
            this.lbLBLIntensity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHBRVerticalDeviation
            // 
            this.lbHBRVerticalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHBRVerticalDeviation.AutoSize = true;
            this.lbHBRVerticalDeviation.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHBRVerticalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHBRVerticalDeviation.Location = new System.Drawing.Point(942, 482);
            this.lbHBRVerticalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHBRVerticalDeviation.Name = "lbHBRVerticalDeviation";
            this.lbHBRVerticalDeviation.Size = new System.Drawing.Size(216, 183);
            this.lbHBRVerticalDeviation.TabIndex = 49;
            this.lbHBRVerticalDeviation.Text = "0.0";
            this.lbHBRVerticalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHBRHorizontalDeviation
            // 
            this.lbHBRHorizontalDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHBRHorizontalDeviation.AutoSize = true;
            this.lbHBRHorizontalDeviation.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHBRHorizontalDeviation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbHBRHorizontalDeviation.Location = new System.Drawing.Point(1474, 482);
            this.lbHBRHorizontalDeviation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHBRHorizontalDeviation.Name = "lbHBRHorizontalDeviation";
            this.lbHBRHorizontalDeviation.Size = new System.Drawing.Size(216, 183);
            this.lbHBRHorizontalDeviation.TabIndex = 45;
            this.lbHBRHorizontalDeviation.Text = "0.0";
            this.lbHBRHorizontalDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnPre.Location = new System.Drawing.Point(15, 996);
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
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTitle.Location = new System.Drawing.Point(570, 421);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(819, 163);
            this.lbTitle.TabIndex = 40;
            this.lbTitle.Text = "Đèn Pha - Cốt";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmHeadlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.CosLightPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHeadlights";
            this.ShowIcon = false;
            this.Text = "Dữ liệu đèn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCosLightL_FormClosing);
            this.Load += new System.EventHandler(this.frmCosLightL_Load);
            this.CosLightPanel.ResumeLayout(false);
            this.CosLightPanel.PerformLayout();
            this.tbHeadLights.ResumeLayout(false);
            this.tbHeadLights.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CosLightPanel;
        private System.Windows.Forms.TableLayoutPanel tbHeadLights;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbHBLIntensity;
        private System.Windows.Forms.Label lbHBLHorizontalDeviation;
        private System.Windows.Forms.Label lbHBLVerticalDeviation;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbLBRHorizontalDeviation;
        private System.Windows.Forms.Label lbLBLVerticalDeviation;
        private System.Windows.Forms.Label lbLBRIntensity;
        private System.Windows.Forms.Label lbLBLIntensity;
        private System.Windows.Forms.Label lbLBRVerticalDeviation;
        private System.Windows.Forms.Label lbLBLHorizontalDeviation;
        private System.Windows.Forms.Label lbHBRHorizontalDeviation;
        private System.Windows.Forms.Label lbHBRIntensity;
        private System.Windows.Forms.Label lbHBRVerticalDeviation;
        private System.Windows.Forms.Label lbEngineNumber;
        private System.Windows.Forms.CheckBox cbLeft;
        private System.Windows.Forms.CheckBox cbRight;
    }
}