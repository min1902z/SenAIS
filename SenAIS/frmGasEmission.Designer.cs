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
            this.tbEmission2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbLamdaValue = new System.Windows.Forms.Label();
            this.lbLamda = new System.Windows.Forms.Label();
            this.cbPass = new System.Windows.Forms.CheckBox();
            this.lbNOValue = new System.Windows.Forms.Label();
            this.lbOTValue = new System.Windows.Forms.Label();
            this.lbNO = new System.Windows.Forms.Label();
            this.lbOT = new System.Windows.Forms.Label();
            this.lbRPM = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbRPMValue = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.btnReMeasure = new System.Windows.Forms.Button();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.tbGasEmission = new System.Windows.Forms.TableLayoutPanel();
            this.lbO2Value = new System.Windows.Forms.Label();
            this.lbCO2Value = new System.Windows.Forms.Label();
            this.lbCOValue = new System.Windows.Forms.Label();
            this.lbHCValue = new System.Windows.Forms.Label();
            this.lbCO = new System.Windows.Forms.Label();
            this.lbCO2 = new System.Windows.Forms.Label();
            this.lbO2 = new System.Windows.Forms.Label();
            this.lbHC = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbEmissionTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EmissionPanel.SuspendLayout();
            this.tbEmission2.SuspendLayout();
            this.tbGasEmission.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(12, 1174);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Quay Lại";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(2292, 1174);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "Tiệp Tục";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // EmissionPanel
            // 
            this.EmissionPanel.AutoSize = true;
            this.EmissionPanel.Controls.Add(this.tbEmission2);
            this.EmissionPanel.Controls.Add(this.btnExit);
            this.EmissionPanel.Controls.Add(this.lbVinNumber);
            this.EmissionPanel.Controls.Add(this.btnReMeasure);
            this.EmissionPanel.Controls.Add(this.cbReady);
            this.EmissionPanel.Controls.Add(this.btnNext);
            this.EmissionPanel.Controls.Add(this.btnPre);
            this.EmissionPanel.Controls.Add(this.tbGasEmission);
            this.EmissionPanel.Controls.Add(this.lbEmissionTitle);
            this.EmissionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmissionPanel.Location = new System.Drawing.Point(0, 0);
            this.EmissionPanel.Margin = new System.Windows.Forms.Padding(4);
            this.EmissionPanel.Name = "EmissionPanel";
            this.EmissionPanel.Size = new System.Drawing.Size(1924, 1055);
            this.EmissionPanel.TabIndex = 5;
            // 
            // tbEmission2
            // 
            this.tbEmission2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmission2.AutoSize = true;
            this.tbEmission2.ColumnCount = 3;
            this.tbEmission2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbEmission2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbEmission2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbEmission2.Controls.Add(this.lbLamdaValue, 1, 3);
            this.tbEmission2.Controls.Add(this.lbLamda, 0, 3);
            this.tbEmission2.Controls.Add(this.cbPass, 2, 3);
            this.tbEmission2.Controls.Add(this.lbNOValue, 1, 0);
            this.tbEmission2.Controls.Add(this.lbOTValue, 1, 1);
            this.tbEmission2.Controls.Add(this.lbNO, 0, 0);
            this.tbEmission2.Controls.Add(this.lbOT, 0, 1);
            this.tbEmission2.Controls.Add(this.lbRPM, 0, 2);
            this.tbEmission2.Controls.Add(this.label13, 2, 0);
            this.tbEmission2.Controls.Add(this.label14, 2, 1);
            this.tbEmission2.Controls.Add(this.label15, 2, 2);
            this.tbEmission2.Controls.Add(this.lbRPMValue, 1, 2);
            this.tbEmission2.Location = new System.Drawing.Point(871, 129);
            this.tbEmission2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbEmission2.Name = "tbEmission2";
            this.tbEmission2.RowCount = 4;
            this.tbEmission2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbEmission2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbEmission2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbEmission2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbEmission2.Size = new System.Drawing.Size(1022, 855);
            this.tbEmission2.TabIndex = 53;
            this.tbEmission2.Visible = false;
            // 
            // lbLamdaValue
            // 
            this.lbLamdaValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbLamdaValue.AutoSize = true;
            this.lbLamdaValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLamdaValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLamdaValue.Location = new System.Drawing.Point(260, 645);
            this.lbLamdaValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLamdaValue.Name = "lbLamdaValue";
            this.lbLamdaValue.Size = new System.Drawing.Size(382, 204);
            this.lbLamdaValue.TabIndex = 58;
            this.lbLamdaValue.Text = "0.00";
            // 
            // lbLamda
            // 
            this.lbLamda.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbLamda.AutoSize = true;
            this.lbLamda.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLamda.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLamda.Location = new System.Drawing.Point(4, 710);
            this.lbLamda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLamda.Name = "lbLamda";
            this.lbLamda.Size = new System.Drawing.Size(60, 73);
            this.lbLamda.TabIndex = 57;
            this.lbLamda.Text = "λ";
            this.lbLamda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbPass
            // 
            this.cbPass.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbPass.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbPass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbPass.BackgroundImage")));
            this.cbPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbPass.Checked = true;
            this.cbPass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPass.Enabled = false;
            this.cbPass.Location = new System.Drawing.Point(650, 693);
            this.cbPass.Margin = new System.Windows.Forms.Padding(4);
            this.cbPass.Name = "cbPass";
            this.cbPass.Size = new System.Drawing.Size(148, 108);
            this.cbPass.TabIndex = 56;
            this.cbPass.UseVisualStyleBackColor = false;
            // 
            // lbNOValue
            // 
            this.lbNOValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNOValue.AutoSize = true;
            this.lbNOValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNOValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbNOValue.Location = new System.Drawing.Point(260, 4);
            this.lbNOValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNOValue.Name = "lbNOValue";
            this.lbNOValue.Size = new System.Drawing.Size(382, 204);
            this.lbNOValue.TabIndex = 8;
            this.lbNOValue.Text = "0.00";
            // 
            // lbOTValue
            // 
            this.lbOTValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbOTValue.AutoSize = true;
            this.lbOTValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOTValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbOTValue.Location = new System.Drawing.Point(260, 217);
            this.lbOTValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOTValue.Name = "lbOTValue";
            this.lbOTValue.Size = new System.Drawing.Size(382, 204);
            this.lbOTValue.TabIndex = 8;
            this.lbOTValue.Text = "0.00";
            // 
            // lbNO
            // 
            this.lbNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbNO.AutoSize = true;
            this.lbNO.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbNO.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNO.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbNO.Location = new System.Drawing.Point(4, 70);
            this.lbNO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNO.Name = "lbNO";
            this.lbNO.Size = new System.Drawing.Size(111, 73);
            this.lbNO.TabIndex = 9;
            this.lbNO.Text = "NO";
            this.lbNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOT
            // 
            this.lbOT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbOT.AutoSize = true;
            this.lbOT.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbOT.Location = new System.Drawing.Point(4, 283);
            this.lbOT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOT.Name = "lbOT";
            this.lbOT.Size = new System.Drawing.Size(248, 73);
            this.lbOT.TabIndex = 10;
            this.lbOT.Text = "Oil Temp";
            this.lbOT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRPM
            // 
            this.lbRPM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbRPM.AutoSize = true;
            this.lbRPM.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPM.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRPM.Location = new System.Drawing.Point(4, 496);
            this.lbRPM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRPM.Name = "lbRPM";
            this.lbRPM.Size = new System.Drawing.Size(147, 73);
            this.lbRPM.TabIndex = 11;
            this.lbRPM.Text = "RPM";
            this.lbRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(650, 70);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 73);
            this.label13.TabIndex = 14;
            this.label13.Text = "%";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(650, 283);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 73);
            this.label14.TabIndex = 15;
            this.label14.Text = "℃";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(650, 496);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 73);
            this.label15.TabIndex = 16;
            this.label15.Text = "rpm";
            // 
            // lbRPMValue
            // 
            this.lbRPMValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRPMValue.AutoSize = true;
            this.lbRPMValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPMValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRPMValue.Location = new System.Drawing.Point(260, 430);
            this.lbRPMValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRPMValue.Name = "lbRPMValue";
            this.lbRPMValue.Size = new System.Drawing.Size(382, 204);
            this.lbRPMValue.TabIndex = 8;
            this.lbRPMValue.Text = "0.00";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExit.Location = new System.Drawing.Point(1795, 9);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 103);
            this.btnExit.TabIndex = 55;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(172, 0);
            this.lbVinNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVinNumber.Name = "lbVinNumber";
            this.lbVinNumber.Size = new System.Drawing.Size(375, 146);
            this.lbVinNumber.TabIndex = 52;
            this.lbVinNumber.Text = "Số Vin";
            // 
            // btnReMeasure
            // 
            this.btnReMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReMeasure.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReMeasure.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReMeasure.BackgroundImage")));
            this.btnReMeasure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReMeasure.Font = new System.Drawing.Font("Calibri", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReMeasure.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnReMeasure.Location = new System.Drawing.Point(1668, 11);
            this.btnReMeasure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReMeasure.Name = "btnReMeasure";
            this.btnReMeasure.Size = new System.Drawing.Size(117, 103);
            this.btnReMeasure.TabIndex = 54;
            this.btnReMeasure.UseVisualStyleBackColor = false;
            this.btnReMeasure.Click += new System.EventHandler(this.btnReMeasure_Click);
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
            this.cbReady.TabIndex = 51;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1799, 999);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 46);
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
            this.btnPre.Location = new System.Drawing.Point(13, 999);
            this.btnPre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(115, 46);
            this.btnPre.TabIndex = 39;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            // 
            // tbGasEmission
            // 
            this.tbGasEmission.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbGasEmission.ColumnCount = 3;
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbGasEmission.Controls.Add(this.lbO2Value, 1, 3);
            this.tbGasEmission.Controls.Add(this.lbCO2Value, 1, 2);
            this.tbGasEmission.Controls.Add(this.lbCOValue, 1, 1);
            this.tbGasEmission.Controls.Add(this.lbHCValue, 1, 0);
            this.tbGasEmission.Controls.Add(this.lbCO, 0, 1);
            this.tbGasEmission.Controls.Add(this.lbCO2, 0, 2);
            this.tbGasEmission.Controls.Add(this.lbO2, 0, 3);
            this.tbGasEmission.Controls.Add(this.lbHC, 0, 0);
            this.tbGasEmission.Controls.Add(this.label9, 2, 0);
            this.tbGasEmission.Controls.Add(this.label10, 2, 1);
            this.tbGasEmission.Controls.Add(this.label11, 2, 2);
            this.tbGasEmission.Controls.Add(this.label12, 2, 3);
            this.tbGasEmission.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGasEmission.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbGasEmission.Location = new System.Drawing.Point(16, 130);
            this.tbGasEmission.Margin = new System.Windows.Forms.Padding(4);
            this.tbGasEmission.Name = "tbGasEmission";
            this.tbGasEmission.RowCount = 4;
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbGasEmission.Size = new System.Drawing.Size(864, 853);
            this.tbGasEmission.TabIndex = 38;
            this.tbGasEmission.Visible = false;
            // 
            // lbO2Value
            // 
            this.lbO2Value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbO2Value.AutoSize = true;
            this.lbO2Value.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbO2Value.Location = new System.Drawing.Point(135, 644);
            this.lbO2Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbO2Value.Name = "lbO2Value";
            this.lbO2Value.Size = new System.Drawing.Size(382, 204);
            this.lbO2Value.TabIndex = 8;
            this.lbO2Value.Text = "0.00";
            // 
            // lbCO2Value
            // 
            this.lbCO2Value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCO2Value.AutoSize = true;
            this.lbCO2Value.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCO2Value.Location = new System.Drawing.Point(135, 430);
            this.lbCO2Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCO2Value.Name = "lbCO2Value";
            this.lbCO2Value.Size = new System.Drawing.Size(382, 204);
            this.lbCO2Value.TabIndex = 8;
            this.lbCO2Value.Text = "0.00";
            // 
            // lbCOValue
            // 
            this.lbCOValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCOValue.AutoSize = true;
            this.lbCOValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCOValue.Location = new System.Drawing.Point(135, 217);
            this.lbCOValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCOValue.Name = "lbCOValue";
            this.lbCOValue.Size = new System.Drawing.Size(382, 204);
            this.lbCOValue.TabIndex = 8;
            this.lbCOValue.Text = "0.00";
            // 
            // lbHCValue
            // 
            this.lbHCValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHCValue.AutoSize = true;
            this.lbHCValue.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHCValue.Location = new System.Drawing.Point(135, 4);
            this.lbHCValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHCValue.Name = "lbHCValue";
            this.lbHCValue.Size = new System.Drawing.Size(382, 204);
            this.lbHCValue.TabIndex = 7;
            this.lbHCValue.Text = "0.00";
            // 
            // lbCO
            // 
            this.lbCO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCO.AutoSize = true;
            this.lbCO.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCO.Location = new System.Drawing.Point(4, 283);
            this.lbCO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCO.Name = "lbCO";
            this.lbCO.Size = new System.Drawing.Size(103, 73);
            this.lbCO.TabIndex = 6;
            this.lbCO.Text = "CO";
            this.lbCO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCO2
            // 
            this.lbCO2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCO2.AutoSize = true;
            this.lbCO2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCO2.Location = new System.Drawing.Point(4, 496);
            this.lbCO2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCO2.Name = "lbCO2";
            this.lbCO2.Size = new System.Drawing.Size(123, 73);
            this.lbCO2.TabIndex = 7;
            this.lbCO2.Text = "CO₂\r\n";
            this.lbCO2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbO2
            // 
            this.lbO2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbO2.AutoSize = true;
            this.lbO2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbO2.Location = new System.Drawing.Point(4, 709);
            this.lbO2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbO2.Name = "lbO2";
            this.lbO2.Size = new System.Drawing.Size(92, 73);
            this.lbO2.TabIndex = 8;
            this.lbO2.Text = "O₂";
            this.lbO2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHC
            // 
            this.lbHC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHC.AutoSize = true;
            this.lbHC.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHC.Location = new System.Drawing.Point(4, 70);
            this.lbHC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHC.Name = "lbHC";
            this.lbHC.Size = new System.Drawing.Size(101, 73);
            this.lbHC.TabIndex = 5;
            this.lbHC.Text = "HC";
            this.lbHC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(525, 70);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 73);
            this.label9.TabIndex = 7;
            this.label9.Text = "ppm";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(525, 283);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 73);
            this.label10.TabIndex = 7;
            this.label10.Text = "%";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(525, 496);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 73);
            this.label11.TabIndex = 12;
            this.label11.Text = "%";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(525, 709);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 73);
            this.label12.TabIndex = 13;
            this.label12.Text = "%";
            // 
            // lbEmissionTitle
            // 
            this.lbEmissionTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbEmissionTitle.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmissionTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbEmissionTitle.Location = new System.Drawing.Point(33, 304);
            this.lbEmissionTitle.Name = "lbEmissionTitle";
            this.lbEmissionTitle.Size = new System.Drawing.Size(1852, 361);
            this.lbEmissionTitle.TabIndex = 37;
            this.lbEmissionTitle.Text = "KHÍ XẢ - ĐỘNG CƠ XĂNG";
            this.lbEmissionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmGasEmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.EmissionPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGasEmission";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khí Xả Xăng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGasEmission_FormClosing);
            this.Load += new System.EventHandler(this.frmGasEmission_Load);
            this.EmissionPanel.ResumeLayout(false);
            this.EmissionPanel.PerformLayout();
            this.tbEmission2.ResumeLayout(false);
            this.tbEmission2.PerformLayout();
            this.tbGasEmission.ResumeLayout(false);
            this.tbGasEmission.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.TableLayoutPanel tbEmission2;
        private System.Windows.Forms.Button btnReMeasure;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox cbPass;
        private System.Windows.Forms.Label lbLamdaValue;
        private System.Windows.Forms.Label lbLamda;
    }
}