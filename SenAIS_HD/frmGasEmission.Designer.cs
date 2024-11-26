namespace SenAIS
{
    partial class frmGasEmission
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGasEmission));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.EmissionPanel = new System.Windows.Forms.Panel();
            this.lbEngineNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.tbGasEmission = new System.Windows.Forms.TableLayoutPanel();
            this.lbOTValue = new System.Windows.Forms.Label();
            this.lbNOValue = new System.Windows.Forms.Label();
            this.lbO2Value = new System.Windows.Forms.Label();
            this.lbCO2Value = new System.Windows.Forms.Label();
            this.lbCOValue = new System.Windows.Forms.Label();
            this.lbHCValue = new System.Windows.Forms.Label();
            this.lbCO = new System.Windows.Forms.Label();
            this.lbCO2 = new System.Windows.Forms.Label();
            this.lbO2 = new System.Windows.Forms.Label();
            this.lbHC = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbNO = new System.Windows.Forms.Label();
            this.lbOT = new System.Windows.Forms.Label();
            this.lbRPM = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbRPMValue = new System.Windows.Forms.Label();
            this.lbEmissionTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EmissionPanel.SuspendLayout();
            this.tbGasEmission.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(9, 954);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Quay Lại";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(1719, 954);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 37);
            this.button2.TabIndex = 4;
            this.button2.Text = "Tiệp Tục";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // EmissionPanel
            // 
            this.EmissionPanel.Controls.Add(this.lbEngineNumber);
            this.EmissionPanel.Controls.Add(this.cbReady);
            this.EmissionPanel.Controls.Add(this.btnNext);
            this.EmissionPanel.Controls.Add(this.btnPre);
            this.EmissionPanel.Controls.Add(this.tbGasEmission);
            this.EmissionPanel.Controls.Add(this.lbEmissionTitle);
            this.EmissionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmissionPanel.Location = new System.Drawing.Point(0, 0);
            this.EmissionPanel.Name = "EmissionPanel";
            this.EmissionPanel.Size = new System.Drawing.Size(1443, 862);
            this.EmissionPanel.TabIndex = 5;
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.IndianRed;
            this.lbEngineNumber.Location = new System.Drawing.Point(129, 12);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(228, 78);
            this.lbEngineNumber.TabIndex = 52;
            this.lbEngineNumber.Text = "Số Máy";
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
            this.cbReady.TabIndex = 51;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1349, 817);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
            this.btnNext.TabIndex = 40;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPre.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(10, 817);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 39;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            // 
            // tbGasEmission
            // 
            this.tbGasEmission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGasEmission.AutoScroll = true;
            this.tbGasEmission.ColumnCount = 6;
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.40825F));
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.07555F));
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.05771F));
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.17715F));
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.03253F));
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.17209F));
            this.tbGasEmission.Controls.Add(this.lbOTValue, 4, 1);
            this.tbGasEmission.Controls.Add(this.lbNOValue, 4, 0);
            this.tbGasEmission.Controls.Add(this.lbO2Value, 1, 3);
            this.tbGasEmission.Controls.Add(this.lbCO2Value, 1, 2);
            this.tbGasEmission.Controls.Add(this.lbCOValue, 1, 1);
            this.tbGasEmission.Controls.Add(this.lbHCValue, 1, 0);
            this.tbGasEmission.Controls.Add(this.lbCO, 0, 1);
            this.tbGasEmission.Controls.Add(this.lbCO2, 0, 2);
            this.tbGasEmission.Controls.Add(this.lbO2, 0, 3);
            this.tbGasEmission.Controls.Add(this.lbHC, 0, 0);
            this.tbGasEmission.Controls.Add(this.label13, 5, 0);
            this.tbGasEmission.Controls.Add(this.label14, 5, 1);
            this.tbGasEmission.Controls.Add(this.label15, 5, 2);
            this.tbGasEmission.Controls.Add(this.lbNO, 3, 0);
            this.tbGasEmission.Controls.Add(this.lbOT, 3, 1);
            this.tbGasEmission.Controls.Add(this.lbRPM, 3, 2);
            this.tbGasEmission.Controls.Add(this.label9, 2, 0);
            this.tbGasEmission.Controls.Add(this.label10, 2, 1);
            this.tbGasEmission.Controls.Add(this.label11, 2, 2);
            this.tbGasEmission.Controls.Add(this.label12, 2, 3);
            this.tbGasEmission.Controls.Add(this.lbRPMValue, 4, 2);
            this.tbGasEmission.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGasEmission.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbGasEmission.Location = new System.Drawing.Point(-1, 115);
            this.tbGasEmission.Name = "tbGasEmission";
            this.tbGasEmission.RowCount = 4;
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbGasEmission.Size = new System.Drawing.Size(1445, 689);
            this.tbGasEmission.TabIndex = 38;
            // 
            // lbOTValue
            // 
            this.lbOTValue.AutoSize = true;
            this.lbOTValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOTValue.Location = new System.Drawing.Point(937, 172);
            this.lbOTValue.Name = "lbOTValue";
            this.lbOTValue.Size = new System.Drawing.Size(304, 163);
            this.lbOTValue.TabIndex = 8;
            this.lbOTValue.Text = "0.00";
            // 
            // lbNOValue
            // 
            this.lbNOValue.AutoSize = true;
            this.lbNOValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNOValue.Location = new System.Drawing.Point(937, 0);
            this.lbNOValue.Name = "lbNOValue";
            this.lbNOValue.Size = new System.Drawing.Size(304, 163);
            this.lbNOValue.TabIndex = 8;
            this.lbNOValue.Text = "0.00";
            // 
            // lbO2Value
            // 
            this.lbO2Value.AutoSize = true;
            this.lbO2Value.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbO2Value.Location = new System.Drawing.Point(124, 516);
            this.lbO2Value.Name = "lbO2Value";
            this.lbO2Value.Size = new System.Drawing.Size(304, 163);
            this.lbO2Value.TabIndex = 8;
            this.lbO2Value.Text = "0.00";
            // 
            // lbCO2Value
            // 
            this.lbCO2Value.AutoSize = true;
            this.lbCO2Value.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCO2Value.Location = new System.Drawing.Point(124, 344);
            this.lbCO2Value.Name = "lbCO2Value";
            this.lbCO2Value.Size = new System.Drawing.Size(304, 163);
            this.lbCO2Value.TabIndex = 8;
            this.lbCO2Value.Text = "0.00";
            // 
            // lbCOValue
            // 
            this.lbCOValue.AutoSize = true;
            this.lbCOValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCOValue.Location = new System.Drawing.Point(124, 172);
            this.lbCOValue.Name = "lbCOValue";
            this.lbCOValue.Size = new System.Drawing.Size(304, 163);
            this.lbCOValue.TabIndex = 8;
            this.lbCOValue.Text = "0.00";
            // 
            // lbHCValue
            // 
            this.lbHCValue.AutoSize = true;
            this.lbHCValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHCValue.Location = new System.Drawing.Point(124, 0);
            this.lbHCValue.Name = "lbHCValue";
            this.lbHCValue.Size = new System.Drawing.Size(304, 163);
            this.lbHCValue.TabIndex = 7;
            this.lbHCValue.Text = "0.00";
            // 
            // lbCO
            // 
            this.lbCO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCO.AutoSize = true;
            this.lbCO.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCO.Location = new System.Drawing.Point(3, 219);
            this.lbCO.Name = "lbCO";
            this.lbCO.Size = new System.Drawing.Size(108, 78);
            this.lbCO.TabIndex = 6;
            this.lbCO.Text = "CO";
            this.lbCO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCO2
            // 
            this.lbCO2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCO2.AutoSize = true;
            this.lbCO2.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCO2.Location = new System.Drawing.Point(3, 352);
            this.lbCO2.Name = "lbCO2";
            this.lbCO2.Size = new System.Drawing.Size(108, 156);
            this.lbCO2.TabIndex = 7;
            this.lbCO2.Text = "CO₂\r\n";
            this.lbCO2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbO2
            // 
            this.lbO2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbO2.AutoSize = true;
            this.lbO2.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbO2.Location = new System.Drawing.Point(3, 563);
            this.lbO2.Name = "lbO2";
            this.lbO2.Size = new System.Drawing.Size(97, 78);
            this.lbO2.TabIndex = 8;
            this.lbO2.Text = "O₂";
            this.lbO2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHC
            // 
            this.lbHC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHC.AutoSize = true;
            this.lbHC.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHC.Location = new System.Drawing.Point(3, 47);
            this.lbHC.Name = "lbHC";
            this.lbHC.Size = new System.Drawing.Size(107, 78);
            this.lbHC.TabIndex = 5;
            this.lbHC.Text = "HC";
            this.lbHC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1270, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 78);
            this.label13.TabIndex = 14;
            this.label13.Text = "%";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1270, 219);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 78);
            this.label14.TabIndex = 15;
            this.label14.Text = "℃";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1270, 352);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 156);
            this.label15.TabIndex = 16;
            this.label15.Text = "vg/ph";
            // 
            // lbNO
            // 
            this.lbNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbNO.AutoSize = true;
            this.lbNO.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNO.Location = new System.Drawing.Point(718, 47);
            this.lbNO.Name = "lbNO";
            this.lbNO.Size = new System.Drawing.Size(116, 78);
            this.lbNO.TabIndex = 9;
            this.lbNO.Text = "NO";
            this.lbNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOT
            // 
            this.lbOT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbOT.AutoSize = true;
            this.lbOT.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOT.Location = new System.Drawing.Point(718, 180);
            this.lbOT.Name = "lbOT";
            this.lbOT.Size = new System.Drawing.Size(175, 156);
            this.lbOT.TabIndex = 10;
            this.lbOT.Text = "Oil Temp";
            this.lbOT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRPM
            // 
            this.lbRPM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbRPM.AutoSize = true;
            this.lbRPM.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPM.Location = new System.Drawing.Point(718, 391);
            this.lbRPM.Name = "lbRPM";
            this.lbRPM.Size = new System.Drawing.Size(156, 78);
            this.lbRPM.TabIndex = 11;
            this.lbRPM.Text = "RPM";
            this.lbRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(501, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 78);
            this.label9.TabIndex = 7;
            this.label9.Text = "ppm";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(501, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 78);
            this.label10.TabIndex = 7;
            this.label10.Text = "%";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(501, 391);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 78);
            this.label11.TabIndex = 12;
            this.label11.Text = "%";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(501, 563);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 78);
            this.label12.TabIndex = 13;
            this.label12.Text = "%";
            // 
            // lbRPMValue
            // 
            this.lbRPMValue.AutoSize = true;
            this.lbRPMValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPMValue.Location = new System.Drawing.Point(937, 344);
            this.lbRPMValue.Name = "lbRPMValue";
            this.lbRPMValue.Size = new System.Drawing.Size(304, 163);
            this.lbRPMValue.TabIndex = 8;
            this.lbRPMValue.Text = "0.00";
            // 
            // lbEmissionTitle
            // 
            this.lbEmissionTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbEmissionTitle.AutoSize = true;
            this.lbEmissionTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmissionTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbEmissionTitle.Location = new System.Drawing.Point(491, 9);
            this.lbEmissionTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbEmissionTitle.Name = "lbEmissionTitle";
            this.lbEmissionTitle.Size = new System.Drawing.Size(696, 78);
            this.lbEmissionTitle.TabIndex = 37;
            this.lbEmissionTitle.Text = "KHÍ XẢ - ĐỘNG CƠ XĂNG";
            this.lbEmissionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmGasEmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1443, 862);
            this.Controls.Add(this.EmissionPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGasEmission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khí Xả Xăng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGasEmission_FormClosing);
            this.Load += new System.EventHandler(this.frmGasEmission_Load);
            this.EmissionPanel.ResumeLayout(false);
            this.EmissionPanel.PerformLayout();
            this.tbGasEmission.ResumeLayout(false);
            this.tbGasEmission.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel EmissionPanel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.TableLayoutPanel tbGasEmission;
        private System.Windows.Forms.Label lbOTValue;
        private System.Windows.Forms.Label lbNOValue;
        private System.Windows.Forms.Label lbO2Value;
        private System.Windows.Forms.Label lbCO2Value;
        private System.Windows.Forms.Label lbCOValue;
        private System.Windows.Forms.Label lbHCValue;
        private System.Windows.Forms.Label lbCO;
        private System.Windows.Forms.Label lbCO2;
        private System.Windows.Forms.Label lbO2;
        private System.Windows.Forms.Label lbHC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbNO;
        private System.Windows.Forms.Label lbOT;
        private System.Windows.Forms.Label lbRPM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbRPMValue;
        private System.Windows.Forms.Label lbEmissionTitle;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbEngineNumber;
    }
}