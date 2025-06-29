﻿namespace SenAIS
{
    partial class frmDieselPDF
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.lbDieselTitle = new System.Windows.Forms.Label();
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
            this.lbEngineNumber = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DieselPanel = new System.Windows.Forms.Panel();
            this.SelectFilePanel = new System.Windows.Forms.Panel();
            this.btnSaveEmission = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnReadPDF = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.DieselPanel.SuspendLayout();
            this.SelectFilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1273, 702);
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
            this.btnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPre.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(11, 702);
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
            this.lbDieselTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbDieselTitle.AutoSize = true;
            this.lbDieselTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDieselTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbDieselTitle.Location = new System.Drawing.Point(400, 0);
            this.lbDieselTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDieselTitle.Name = "lbDieselTitle";
            this.lbDieselTitle.Size = new System.Drawing.Size(714, 78);
            this.lbDieselTitle.TabIndex = 46;
            this.lbDieselTitle.Text = "KHÍ XẢ - ĐỘNG CƠ DIESEL";
            this.lbDieselTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbHsuAvg
            // 
            this.lbHsuAvg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbHsuAvg.AutoSize = true;
            this.lbHsuAvg.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHsuAvg.ForeColor = System.Drawing.Color.Blue;
            this.lbHsuAvg.Location = new System.Drawing.Point(1055, 433);
            this.lbHsuAvg.Name = "lbHsuAvg";
            this.lbHsuAvg.Size = new System.Drawing.Size(108, 117);
            this.lbHsuAvg.TabIndex = 51;
            this.lbHsuAvg.Text = "--";
            this.lbHsuAvg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMinAvg
            // 
            this.lbMinAvg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMinAvg.AutoSize = true;
            this.lbMinAvg.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinAvg.ForeColor = System.Drawing.Color.Blue;
            this.lbMinAvg.Location = new System.Drawing.Point(1055, 87);
            this.lbMinAvg.Name = "lbMinAvg";
            this.lbMinAvg.Size = new System.Drawing.Size(108, 117);
            this.lbMinAvg.TabIndex = 51;
            this.lbMinAvg.Text = "--";
            this.lbMinAvg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAvg
            // 
            this.lbAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAvg.AutoSize = true;
            this.lbAvg.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAvg.ForeColor = System.Drawing.Color.Blue;
            this.lbAvg.Location = new System.Drawing.Point(931, 0);
            this.lbAvg.Name = "lbAvg";
            this.lbAvg.Size = new System.Drawing.Size(232, 59);
            this.lbAvg.TabIndex = 51;
            this.lbAvg.Text = "Trung bình";
            // 
            // lbHSU3
            // 
            this.lbHSU3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHSU3.AutoSize = true;
            this.lbHSU3.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHSU3.ForeColor = System.Drawing.Color.Blue;
            this.lbHSU3.Location = new System.Drawing.Point(610, 405);
            this.lbHSU3.Name = "lbHSU3";
            this.lbHSU3.Size = new System.Drawing.Size(172, 174);
            this.lbHSU3.TabIndex = 51;
            this.lbHSU3.Text = "0.0";
            this.lbHSU3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMaxSpeedTitle
            // 
            this.lbMaxSpeedTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMaxSpeedTitle.AutoSize = true;
            this.lbMaxSpeedTitle.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxSpeedTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbMaxSpeedTitle.Location = new System.Drawing.Point(3, 259);
            this.lbMaxSpeedTitle.Name = "lbMaxSpeedTitle";
            this.lbMaxSpeedTitle.Size = new System.Drawing.Size(244, 118);
            this.lbMaxSpeedTitle.TabIndex = 23;
            this.lbMaxSpeedTitle.Text = "Tốc độ max\r\n(rpm)";
            this.lbMaxSpeedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHSU1
            // 
            this.lbHSU1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHSU1.AutoSize = true;
            this.lbHSU1.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHSU1.ForeColor = System.Drawing.Color.Blue;
            this.lbHSU1.Location = new System.Drawing.Point(254, 405);
            this.lbHSU1.Name = "lbHSU1";
            this.lbHSU1.Size = new System.Drawing.Size(172, 174);
            this.lbHSU1.TabIndex = 21;
            this.lbHSU1.Text = "0.0";
            this.lbHSU1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHSU2
            // 
            this.lbHSU2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHSU2.AutoSize = true;
            this.lbHSU2.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHSU2.ForeColor = System.Drawing.Color.Blue;
            this.lbHSU2.Location = new System.Drawing.Point(432, 405);
            this.lbHSU2.Name = "lbHSU2";
            this.lbHSU2.Size = new System.Drawing.Size(172, 174);
            this.lbHSU2.TabIndex = 20;
            this.lbHSU2.Text = "0.0";
            this.lbHSU2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMaxSpeed3
            // 
            this.lbMaxSpeed3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbMaxSpeed3.AutoSize = true;
            this.lbMaxSpeed3.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxSpeed3.ForeColor = System.Drawing.Color.Blue;
            this.lbMaxSpeed3.Location = new System.Drawing.Point(610, 232);
            this.lbMaxSpeed3.Name = "lbMaxSpeed3";
            this.lbMaxSpeed3.Size = new System.Drawing.Size(172, 173);
            this.lbMaxSpeed3.TabIndex = 18;
            this.lbMaxSpeed3.Text = "0.0";
            this.lbMaxSpeed3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMaxSpeed2
            // 
            this.lbMaxSpeed2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbMaxSpeed2.AutoSize = true;
            this.lbMaxSpeed2.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxSpeed2.ForeColor = System.Drawing.Color.Blue;
            this.lbMaxSpeed2.Location = new System.Drawing.Point(432, 232);
            this.lbMaxSpeed2.Name = "lbMaxSpeed2";
            this.lbMaxSpeed2.Size = new System.Drawing.Size(172, 173);
            this.lbMaxSpeed2.TabIndex = 17;
            this.lbMaxSpeed2.Text = "0.0";
            this.lbMaxSpeed2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMinSpeed3
            // 
            this.lbMinSpeed3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbMinSpeed3.AutoSize = true;
            this.lbMinSpeed3.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinSpeed3.ForeColor = System.Drawing.Color.Blue;
            this.lbMinSpeed3.Location = new System.Drawing.Point(610, 59);
            this.lbMinSpeed3.Name = "lbMinSpeed3";
            this.lbMinSpeed3.Size = new System.Drawing.Size(172, 173);
            this.lbMinSpeed3.TabIndex = 16;
            this.lbMinSpeed3.Text = "0.0";
            this.lbMinSpeed3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMinSpeed2
            // 
            this.lbMinSpeed2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbMinSpeed2.AutoSize = true;
            this.lbMinSpeed2.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinSpeed2.ForeColor = System.Drawing.Color.Blue;
            this.lbMinSpeed2.Location = new System.Drawing.Point(432, 59);
            this.lbMinSpeed2.Name = "lbMinSpeed2";
            this.lbMinSpeed2.Size = new System.Drawing.Size(172, 173);
            this.lbMinSpeed2.TabIndex = 15;
            this.lbMinSpeed2.Text = "0.0";
            this.lbMinSpeed2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbL3
            // 
            this.lbL3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbL3.AutoSize = true;
            this.lbL3.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL3.ForeColor = System.Drawing.Color.Blue;
            this.lbL3.Location = new System.Drawing.Point(632, 0);
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
            this.lbL2.ForeColor = System.Drawing.Color.Blue;
            this.lbL2.Location = new System.Drawing.Point(454, 0);
            this.lbL2.Name = "lbL2";
            this.lbL2.Size = new System.Drawing.Size(128, 59);
            this.lbL2.TabIndex = 13;
            this.lbL2.Text = "Lần 2";
            // 
            // lbMaxSpeed1
            // 
            this.lbMaxSpeed1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbMaxSpeed1.AutoSize = true;
            this.lbMaxSpeed1.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxSpeed1.ForeColor = System.Drawing.Color.Blue;
            this.lbMaxSpeed1.Location = new System.Drawing.Point(254, 232);
            this.lbMaxSpeed1.Name = "lbMaxSpeed1";
            this.lbMaxSpeed1.Size = new System.Drawing.Size(172, 173);
            this.lbMaxSpeed1.TabIndex = 12;
            this.lbMaxSpeed1.Text = "0.0";
            this.lbMaxSpeed1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMinSpeed1
            // 
            this.lbMinSpeed1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbMinSpeed1.AutoSize = true;
            this.lbMinSpeed1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbMinSpeed1.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinSpeed1.ForeColor = System.Drawing.Color.Blue;
            this.lbMinSpeed1.Location = new System.Drawing.Point(254, 59);
            this.lbMinSpeed1.Name = "lbMinSpeed1";
            this.lbMinSpeed1.Size = new System.Drawing.Size(172, 173);
            this.lbMinSpeed1.TabIndex = 7;
            this.lbMinSpeed1.Text = "0.0";
            this.lbMinSpeed1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbL1
            // 
            this.lbL1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbL1.AutoSize = true;
            this.lbL1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL1.ForeColor = System.Drawing.Color.Blue;
            this.lbL1.Location = new System.Drawing.Point(276, 0);
            this.lbL1.Name = "lbL1";
            this.lbL1.Size = new System.Drawing.Size(128, 59);
            this.lbL1.TabIndex = 7;
            this.lbL1.Text = "Lần 1";
            // 
            // lbMinTitle
            // 
            this.lbMinTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMinTitle.AutoSize = true;
            this.lbMinTitle.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbMinTitle.Location = new System.Drawing.Point(3, 86);
            this.lbMinTitle.Name = "lbMinTitle";
            this.lbMinTitle.Size = new System.Drawing.Size(236, 118);
            this.lbMinTitle.TabIndex = 5;
            this.lbMinTitle.Text = "Tốc độ min\r\n(rpm)";
            this.lbMinTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHsuTitle
            // 
            this.lbHsuTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHsuTitle.AutoSize = true;
            this.lbHsuTitle.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHsuTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbHsuTitle.Location = new System.Drawing.Point(3, 462);
            this.lbHsuTitle.Name = "lbHsuTitle";
            this.lbHsuTitle.Size = new System.Drawing.Size(245, 59);
            this.lbHsuTitle.TabIndex = 22;
            this.lbHsuTitle.Text = "Hệ số K (%)";
            this.lbHsuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMaxAvg
            // 
            this.lbMaxAvg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMaxAvg.AutoSize = true;
            this.lbMaxAvg.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxAvg.ForeColor = System.Drawing.Color.Blue;
            this.lbMaxAvg.Location = new System.Drawing.Point(1055, 260);
            this.lbMaxAvg.Name = "lbMaxAvg";
            this.lbMaxAvg.Size = new System.Drawing.Size(108, 117);
            this.lbMaxAvg.TabIndex = 51;
            this.lbMaxAvg.Text = "--";
            this.lbMaxAvg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.Red;
            this.lbEngineNumber.Location = new System.Drawing.Point(3, 7);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(151, 59);
            this.lbEngineNumber.TabIndex = 52;
            this.lbEngineNumber.Text = "Số Vin";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbHsuAvg, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbMinAvg, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbAvg, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbHSU3, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbHSU1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbHSU2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbMaxSpeed3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbMaxSpeed2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbMinSpeed3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbMinSpeed2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbL3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbL2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbMaxSpeed1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbMinSpeed1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbL1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbMinTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbHsuTitle, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbMaxAvg, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbMaxSpeedTitle, 0, 2);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Calibri", 200.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(102, 138);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1166, 579);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // DieselPanel
            // 
            this.DieselPanel.AutoSize = true;
            this.DieselPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DieselPanel.Controls.Add(this.SelectFilePanel);
            this.DieselPanel.Controls.Add(this.lbEngineNumber);
            this.DieselPanel.Controls.Add(this.tableLayoutPanel1);
            this.DieselPanel.Controls.Add(this.btnNext);
            this.DieselPanel.Controls.Add(this.btnPre);
            this.DieselPanel.Controls.Add(this.lbDieselTitle);
            this.DieselPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DieselPanel.Location = new System.Drawing.Point(0, 0);
            this.DieselPanel.Name = "DieselPanel";
            this.DieselPanel.Size = new System.Drawing.Size(1370, 749);
            this.DieselPanel.TabIndex = 1;
            // 
            // SelectFilePanel
            // 
            this.SelectFilePanel.AutoSize = true;
            this.SelectFilePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SelectFilePanel.Controls.Add(this.btnSaveEmission);
            this.SelectFilePanel.Controls.Add(this.btnSelectFile);
            this.SelectFilePanel.Controls.Add(this.btnReadPDF);
            this.SelectFilePanel.Controls.Add(this.txtFilePath);
            this.SelectFilePanel.Location = new System.Drawing.Point(130, 94);
            this.SelectFilePanel.Name = "SelectFilePanel";
            this.SelectFilePanel.Size = new System.Drawing.Size(723, 41);
            this.SelectFilePanel.TabIndex = 56;
            // 
            // btnSaveEmission
            // 
            this.btnSaveEmission.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveEmission.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveEmission.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEmission.ForeColor = System.Drawing.Color.Blue;
            this.btnSaveEmission.Location = new System.Drawing.Point(567, 2);
            this.btnSaveEmission.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveEmission.Name = "btnSaveEmission";
            this.btnSaveEmission.Size = new System.Drawing.Size(86, 37);
            this.btnSaveEmission.TabIndex = 57;
            this.btnSaveEmission.Text = "Lưu ";
            this.btnSaveEmission.UseVisualStyleBackColor = false;
            this.btnSaveEmission.Click += new System.EventHandler(this.btnSaveEmission_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSelectFile.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFile.ForeColor = System.Drawing.Color.Blue;
            this.btnSelectFile.Location = new System.Drawing.Point(2, 2);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(86, 37);
            this.btnSelectFile.TabIndex = 53;
            this.btnSelectFile.Text = "Chọn File";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnReadPDF
            // 
            this.btnReadPDF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadPDF.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReadPDF.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadPDF.ForeColor = System.Drawing.Color.Blue;
            this.btnReadPDF.Location = new System.Drawing.Point(477, 2);
            this.btnReadPDF.Margin = new System.Windows.Forms.Padding(2);
            this.btnReadPDF.Name = "btnReadPDF";
            this.btnReadPDF.Size = new System.Drawing.Size(86, 37);
            this.btnReadPDF.TabIndex = 55;
            this.btnReadPDF.Text = "Đọc File";
            this.btnReadPDF.UseVisualStyleBackColor = false;
            this.btnReadPDF.Click += new System.EventHandler(this.btnReadPDF_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(93, 7);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(379, 26);
            this.txtFilePath.TabIndex = 54;
            // 
            // frmDieselPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.DieselPanel);
            this.Name = "frmDieselPDF";
            this.ShowIcon = false;
            this.Text = "Khí xả - Động cơ Diesel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.DieselPanel.ResumeLayout(false);
            this.DieselPanel.PerformLayout();
            this.SelectFilePanel.ResumeLayout(false);
            this.SelectFilePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label lbDieselTitle;
        private System.Windows.Forms.Label lbHsuAvg;
        private System.Windows.Forms.Label lbMinAvg;
        private System.Windows.Forms.Label lbAvg;
        private System.Windows.Forms.Label lbHSU3;
        private System.Windows.Forms.Label lbMaxSpeedTitle;
        private System.Windows.Forms.Label lbHSU1;
        private System.Windows.Forms.Label lbHSU2;
        private System.Windows.Forms.Label lbMaxSpeed3;
        private System.Windows.Forms.Label lbMaxSpeed2;
        private System.Windows.Forms.Label lbMinSpeed3;
        private System.Windows.Forms.Label lbMinSpeed2;
        private System.Windows.Forms.Label lbL3;
        private System.Windows.Forms.Label lbL2;
        private System.Windows.Forms.Label lbMaxSpeed1;
        private System.Windows.Forms.Label lbMinSpeed1;
        private System.Windows.Forms.Label lbL1;
        private System.Windows.Forms.Label lbMinTitle;
        private System.Windows.Forms.Label lbHsuTitle;
        private System.Windows.Forms.Label lbMaxAvg;
        private System.Windows.Forms.Label lbEngineNumber;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel DieselPanel;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnReadPDF;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Panel SelectFilePanel;
        private System.Windows.Forms.Button btnSaveEmission;
    }
}