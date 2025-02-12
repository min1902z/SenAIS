namespace SenAIS
{
    partial class frmDieselEmission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieselEmission));
            this.DieselPanel = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReMeasure = new System.Windows.Forms.Button();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.lbNotice = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.tbEmission = new System.Windows.Forms.TableLayoutPanel();
            this.lbHsuAvg = new System.Windows.Forms.Label();
            this.lbMinAvg = new System.Windows.Forms.Label();
            this.lbAvg = new System.Windows.Forms.Label();
            this.lbHSU3 = new System.Windows.Forms.Label();
            this.lbMaxSpeedTitle = new System.Windows.Forms.Label();
            this.lbHSU1 = new System.Windows.Forms.Label();
            this.lbHSU2 = new System.Windows.Forms.Label();
            this.lbMaxSpeed3 = new System.Windows.Forms.Label();
            this.lbMaxSpeed2 = new System.Windows.Forms.Label();
            this.lbMinSpeed3 = new System.Windows.Forms.Label();
            this.lbMinSpeed2 = new System.Windows.Forms.Label();
            this.lbL3 = new System.Windows.Forms.Label();
            this.lbL2 = new System.Windows.Forms.Label();
            this.lbMaxSpeed1 = new System.Windows.Forms.Label();
            this.lbMinSpeed1 = new System.Windows.Forms.Label();
            this.lbL1 = new System.Windows.Forms.Label();
            this.lbMinTitle = new System.Windows.Forms.Label();
            this.lbHsuTitle = new System.Windows.Forms.Label();
            this.lbMaxAvg = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lbDieselTitle = new System.Windows.Forms.Label();
            this.DieselPanel.SuspendLayout();
            this.tbEmission.SuspendLayout();
            this.SuspendLayout();
            // 
            // DieselPanel
            // 
            this.DieselPanel.AutoSize = true;
            this.DieselPanel.Controls.Add(this.btnExit);
            this.DieselPanel.Controls.Add(this.btnReMeasure);
            this.DieselPanel.Controls.Add(this.lbVinNumber);
            this.DieselPanel.Controls.Add(this.lbNotice);
            this.DieselPanel.Controls.Add(this.cbReady);
            this.DieselPanel.Controls.Add(this.tbEmission);
            this.DieselPanel.Controls.Add(this.btnNext);
            this.DieselPanel.Controls.Add(this.btnPre);
            this.DieselPanel.Controls.Add(this.lbDieselTitle);
            this.DieselPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DieselPanel.Location = new System.Drawing.Point(0, 0);
            this.DieselPanel.Name = "DieselPanel";
            this.DieselPanel.Size = new System.Drawing.Size(1443, 857);
            this.DieselPanel.TabIndex = 0;
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
            this.btnExit.Location = new System.Drawing.Point(1346, 6);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 84);
            this.btnExit.TabIndex = 57;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnReMeasure.Location = new System.Drawing.Point(1251, 8);
            this.btnReMeasure.Margin = new System.Windows.Forms.Padding(2);
            this.btnReMeasure.Name = "btnReMeasure";
            this.btnReMeasure.Size = new System.Drawing.Size(88, 84);
            this.btnReMeasure.TabIndex = 56;
            this.btnReMeasure.UseVisualStyleBackColor = false;
            this.btnReMeasure.Click += new System.EventHandler(this.btnReMeasure_Click);
            // 
            // lbVinNumber
            // 
            this.lbVinNumber.AutoSize = true;
            this.lbVinNumber.Font = new System.Drawing.Font("Calibri", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbVinNumber.Location = new System.Drawing.Point(128, -11);
            this.lbVinNumber.Name = "lbVinNumber";
            this.lbVinNumber.Size = new System.Drawing.Size(334, 131);
            this.lbVinNumber.TabIndex = 52;
            this.lbVinNumber.Text = "Số Vin";
            // 
            // lbNotice
            // 
            this.lbNotice.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbNotice.AutoSize = true;
            this.lbNotice.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotice.ForeColor = System.Drawing.Color.IndianRed;
            this.lbNotice.Location = new System.Drawing.Point(101, 743);
            this.lbNotice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new System.Drawing.Size(475, 117);
            this.lbNotice.TabIndex = 51;
            this.lbNotice.Text = "Thông Báo";
            this.lbNotice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbNotice.Visible = false;
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
            this.cbReady.Location = new System.Drawing.Point(11, 13);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(111, 88);
            this.cbReady.TabIndex = 50;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // tbEmission
            // 
            this.tbEmission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmission.ColumnCount = 5;
            this.tbEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbEmission.Controls.Add(this.lbHsuAvg, 4, 3);
            this.tbEmission.Controls.Add(this.lbMinAvg, 4, 1);
            this.tbEmission.Controls.Add(this.lbAvg, 4, 0);
            this.tbEmission.Controls.Add(this.lbHSU3, 3, 3);
            this.tbEmission.Controls.Add(this.lbMaxSpeedTitle, 0, 2);
            this.tbEmission.Controls.Add(this.lbHSU1, 1, 3);
            this.tbEmission.Controls.Add(this.lbHSU2, 2, 3);
            this.tbEmission.Controls.Add(this.lbMaxSpeed3, 3, 2);
            this.tbEmission.Controls.Add(this.lbMaxSpeed2, 2, 2);
            this.tbEmission.Controls.Add(this.lbMinSpeed3, 3, 1);
            this.tbEmission.Controls.Add(this.lbMinSpeed2, 2, 1);
            this.tbEmission.Controls.Add(this.lbL3, 3, 0);
            this.tbEmission.Controls.Add(this.lbL2, 2, 0);
            this.tbEmission.Controls.Add(this.lbMaxSpeed1, 1, 2);
            this.tbEmission.Controls.Add(this.lbMinSpeed1, 1, 1);
            this.tbEmission.Controls.Add(this.lbL1, 1, 0);
            this.tbEmission.Controls.Add(this.lbMinTitle, 0, 1);
            this.tbEmission.Controls.Add(this.lbHsuTitle, 0, 3);
            this.tbEmission.Controls.Add(this.lbMaxAvg, 4, 2);
            this.tbEmission.Font = new System.Drawing.Font("Calibri", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmission.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbEmission.Location = new System.Drawing.Point(26, 107);
            this.tbEmission.Name = "tbEmission";
            this.tbEmission.RowCount = 4;
            this.tbEmission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbEmission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbEmission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbEmission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbEmission.Size = new System.Drawing.Size(1396, 639);
            this.tbEmission.TabIndex = 49;
            this.tbEmission.Visible = false;
            // 
            // lbHsuAvg
            // 
            this.lbHsuAvg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbHsuAvg.AutoSize = true;
            this.lbHsuAvg.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHsuAvg.Location = new System.Drawing.Point(1242, 431);
            this.lbHsuAvg.Name = "lbHsuAvg";
            this.lbHsuAvg.Size = new System.Drawing.Size(151, 164);
            this.lbHsuAvg.TabIndex = 51;
            this.lbHsuAvg.Text = "--";
            // 
            // lbMinAvg
            // 
            this.lbMinAvg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMinAvg.AutoSize = true;
            this.lbMinAvg.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinAvg.Location = new System.Drawing.Point(1242, 59);
            this.lbMinAvg.Name = "lbMinAvg";
            this.lbMinAvg.Size = new System.Drawing.Size(151, 164);
            this.lbMinAvg.TabIndex = 51;
            this.lbMinAvg.Text = "--";
            // 
            // lbAvg
            // 
            this.lbAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAvg.AutoSize = true;
            this.lbAvg.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAvg.Location = new System.Drawing.Point(1161, 0);
            this.lbAvg.Name = "lbAvg";
            this.lbAvg.Size = new System.Drawing.Size(232, 59);
            this.lbAvg.TabIndex = 51;
            this.lbAvg.Text = "Trung bình";
            // 
            // lbHSU3
            // 
            this.lbHSU3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHSU3.AutoSize = true;
            this.lbHSU3.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHSU3.Location = new System.Drawing.Point(860, 431);
            this.lbHSU3.Name = "lbHSU3";
            this.lbHSU3.Size = new System.Drawing.Size(239, 164);
            this.lbHSU3.TabIndex = 51;
            this.lbHSU3.Text = "0.0";
            // 
            // lbMaxSpeedTitle
            // 
            this.lbMaxSpeedTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMaxSpeedTitle.AutoSize = true;
            this.lbMaxSpeedTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxSpeedTitle.Location = new System.Drawing.Point(3, 266);
            this.lbMaxSpeedTitle.Name = "lbMaxSpeedTitle";
            this.lbMaxSpeedTitle.Size = new System.Drawing.Size(325, 78);
            this.lbMaxSpeedTitle.TabIndex = 23;
            this.lbMaxSpeedTitle.Text = "Tốc độ max";
            this.lbMaxSpeedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHSU1
            // 
            this.lbHSU1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHSU1.AutoSize = true;
            this.lbHSU1.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHSU1.Location = new System.Drawing.Point(370, 431);
            this.lbHSU1.Name = "lbHSU1";
            this.lbHSU1.Size = new System.Drawing.Size(239, 164);
            this.lbHSU1.TabIndex = 21;
            this.lbHSU1.Text = "0.0";
            // 
            // lbHSU2
            // 
            this.lbHSU2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHSU2.AutoSize = true;
            this.lbHSU2.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHSU2.Location = new System.Drawing.Point(615, 431);
            this.lbHSU2.Name = "lbHSU2";
            this.lbHSU2.Size = new System.Drawing.Size(239, 164);
            this.lbHSU2.TabIndex = 20;
            this.lbHSU2.Text = "0.0";
            // 
            // lbMaxSpeed3
            // 
            this.lbMaxSpeed3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMaxSpeed3.AutoSize = true;
            this.lbMaxSpeed3.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxSpeed3.Location = new System.Drawing.Point(860, 223);
            this.lbMaxSpeed3.Name = "lbMaxSpeed3";
            this.lbMaxSpeed3.Size = new System.Drawing.Size(239, 164);
            this.lbMaxSpeed3.TabIndex = 18;
            this.lbMaxSpeed3.Text = "0.0";
            // 
            // lbMaxSpeed2
            // 
            this.lbMaxSpeed2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMaxSpeed2.AutoSize = true;
            this.lbMaxSpeed2.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxSpeed2.Location = new System.Drawing.Point(615, 223);
            this.lbMaxSpeed2.Name = "lbMaxSpeed2";
            this.lbMaxSpeed2.Size = new System.Drawing.Size(239, 164);
            this.lbMaxSpeed2.TabIndex = 17;
            this.lbMaxSpeed2.Text = "0.0";
            // 
            // lbMinSpeed3
            // 
            this.lbMinSpeed3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMinSpeed3.AutoSize = true;
            this.lbMinSpeed3.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinSpeed3.Location = new System.Drawing.Point(860, 59);
            this.lbMinSpeed3.Name = "lbMinSpeed3";
            this.lbMinSpeed3.Size = new System.Drawing.Size(239, 164);
            this.lbMinSpeed3.TabIndex = 16;
            this.lbMinSpeed3.Text = "0.0";
            // 
            // lbMinSpeed2
            // 
            this.lbMinSpeed2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMinSpeed2.AutoSize = true;
            this.lbMinSpeed2.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinSpeed2.Location = new System.Drawing.Point(615, 59);
            this.lbMinSpeed2.Name = "lbMinSpeed2";
            this.lbMinSpeed2.Size = new System.Drawing.Size(239, 164);
            this.lbMinSpeed2.TabIndex = 15;
            this.lbMinSpeed2.Text = "0.0";
            // 
            // lbL3
            // 
            this.lbL3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbL3.AutoSize = true;
            this.lbL3.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL3.Location = new System.Drawing.Point(915, 0);
            this.lbL3.Name = "lbL3";
            this.lbL3.Size = new System.Drawing.Size(128, 59);
            this.lbL3.TabIndex = 14;
            this.lbL3.Text = "Lần 3";
            // 
            // lbL2
            // 
            this.lbL2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbL2.AutoSize = true;
            this.lbL2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL2.Location = new System.Drawing.Point(670, 0);
            this.lbL2.Name = "lbL2";
            this.lbL2.Size = new System.Drawing.Size(128, 59);
            this.lbL2.TabIndex = 13;
            this.lbL2.Text = "Lần 2";
            // 
            // lbMaxSpeed1
            // 
            this.lbMaxSpeed1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMaxSpeed1.AutoSize = true;
            this.lbMaxSpeed1.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxSpeed1.Location = new System.Drawing.Point(370, 223);
            this.lbMaxSpeed1.Name = "lbMaxSpeed1";
            this.lbMaxSpeed1.Size = new System.Drawing.Size(239, 164);
            this.lbMaxSpeed1.TabIndex = 12;
            this.lbMaxSpeed1.Text = "0.0";
            // 
            // lbMinSpeed1
            // 
            this.lbMinSpeed1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMinSpeed1.AutoSize = true;
            this.lbMinSpeed1.BackColor = System.Drawing.SystemColors.Control;
            this.lbMinSpeed1.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinSpeed1.Location = new System.Drawing.Point(370, 59);
            this.lbMinSpeed1.Name = "lbMinSpeed1";
            this.lbMinSpeed1.Size = new System.Drawing.Size(239, 164);
            this.lbMinSpeed1.TabIndex = 7;
            this.lbMinSpeed1.Text = "0.0";
            // 
            // lbL1
            // 
            this.lbL1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbL1.AutoSize = true;
            this.lbL1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL1.Location = new System.Drawing.Point(425, 0);
            this.lbL1.Name = "lbL1";
            this.lbL1.Size = new System.Drawing.Size(128, 59);
            this.lbL1.TabIndex = 7;
            this.lbL1.Text = "Lần 1";
            // 
            // lbMinTitle
            // 
            this.lbMinTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMinTitle.AutoSize = true;
            this.lbMinTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinTitle.Location = new System.Drawing.Point(3, 102);
            this.lbMinTitle.Name = "lbMinTitle";
            this.lbMinTitle.Size = new System.Drawing.Size(361, 78);
            this.lbMinTitle.TabIndex = 5;
            this.lbMinTitle.Text = "Tốc độ (rpm)";
            this.lbMinTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHsuTitle
            // 
            this.lbHsuTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHsuTitle.AutoSize = true;
            this.lbHsuTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHsuTitle.Location = new System.Drawing.Point(3, 474);
            this.lbHsuTitle.Name = "lbHsuTitle";
            this.lbHsuTitle.Size = new System.Drawing.Size(241, 78);
            this.lbHsuTitle.TabIndex = 22;
            this.lbHsuTitle.Text = "HSU (%)";
            this.lbHsuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMaxAvg
            // 
            this.lbMaxAvg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMaxAvg.AutoSize = true;
            this.lbMaxAvg.Font = new System.Drawing.Font("Calibri", 100.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxAvg.Location = new System.Drawing.Point(1242, 223);
            this.lbMaxAvg.Name = "lbMaxAvg";
            this.lbMaxAvg.Size = new System.Drawing.Size(151, 164);
            this.lbMaxAvg.TabIndex = 51;
            this.lbMaxAvg.Text = "--";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1346, 810);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnPre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(11, 810);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 47;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // lbDieselTitle
            // 
            this.lbDieselTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbDieselTitle.Font = new System.Drawing.Font("Calibri", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDieselTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDieselTitle.Location = new System.Drawing.Point(11, 258);
            this.lbDieselTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDieselTitle.Name = "lbDieselTitle";
            this.lbDieselTitle.Size = new System.Drawing.Size(1420, 197);
            this.lbDieselTitle.TabIndex = 46;
            this.lbDieselTitle.Text = "KHÍ XẢ - ĐỘNG CƠ DIESEL";
            this.lbDieselTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDieselEmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.DieselPanel);
            this.Name = "frmDieselEmission";
            this.ShowIcon = false;
            this.Text = "Khí xả - Động cơ Diesel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDieselEmission_FormClosing);
            this.Load += new System.EventHandler(this.frmDieselEmission_LoadAsync);
            this.DieselPanel.ResumeLayout(false);
            this.DieselPanel.PerformLayout();
            this.tbEmission.ResumeLayout(false);
            this.tbEmission.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel DieselPanel;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.TableLayoutPanel tbEmission;
        private System.Windows.Forms.Label lbMaxSpeed1;
        private System.Windows.Forms.Label lbMinSpeed1;
        private System.Windows.Forms.Label lbMinTitle;
        private System.Windows.Forms.Label lbL1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lbDieselTitle;
        private System.Windows.Forms.Label lbMaxSpeed3;
        private System.Windows.Forms.Label lbMaxSpeed2;
        private System.Windows.Forms.Label lbMinSpeed3;
        private System.Windows.Forms.Label lbMinSpeed2;
        private System.Windows.Forms.Label lbL3;
        private System.Windows.Forms.Label lbL2;
        private System.Windows.Forms.Label lbHSU3;
        private System.Windows.Forms.Label lbMaxSpeedTitle;
        private System.Windows.Forms.Label lbHsuTitle;
        private System.Windows.Forms.Label lbHSU1;
        private System.Windows.Forms.Label lbHSU2;
        private System.Windows.Forms.Label lbHsuAvg;
        private System.Windows.Forms.Label lbMaxAvg;
        private System.Windows.Forms.Label lbMinAvg;
        private System.Windows.Forms.Label lbAvg;
        private System.Windows.Forms.Label lbNotice;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReMeasure;
    }
}