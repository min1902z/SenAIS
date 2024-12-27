using System.Windows.Forms;

namespace SenAIS
{
    partial class frmCalibration
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
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CalibrationPanel = new System.Windows.Forms.Panel();
            this.RightCalibPanel = new System.Windows.Forms.Panel();
            this.panelAfterCalibration = new System.Windows.Forms.Panel();
            this.lbAfterCalbTitle = new System.Windows.Forms.Label();
            this.lbCalibResult = new System.Windows.Forms.Label();
            this.LeftCalibPanel = new System.Windows.Forms.Panel();
            this.tbCalibration = new System.Windows.Forms.TableLayoutPanel();
            this.lbParaB = new System.Windows.Forms.Label();
            this.lbParaWeightLB = new System.Windows.Forms.Label();
            this.lbParaWeightLA = new System.Windows.Forms.Label();
            this.lbParaA = new System.Windows.Forms.Label();
            this.txtCalibrateInput2 = new System.Windows.Forms.TextBox();
            this.lbCalibWeightLB = new System.Windows.Forms.Label();
            this.lbCalibB = new System.Windows.Forms.Label();
            this.lbCalibWeightLA = new System.Windows.Forms.Label();
            this.btnSavePara = new System.Windows.Forms.Button();
            this.btnAcpCalibrate2 = new System.Windows.Forms.Button();
            this.lbCalibrateIput2 = new System.Windows.Forms.Label();
            this.txtBeforeCalib = new System.Windows.Forms.TextBox();
            this.lbCalibA = new System.Windows.Forms.Label();
            this.btnCalculateCalib = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAcpCalibrate1 = new System.Windows.Forms.Button();
            this.lbCalibrateIput1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCalibrateInput1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCalibrateTitle = new System.Windows.Forms.Label();
            this.CalibrationPanel.SuspendLayout();
            this.RightCalibPanel.SuspendLayout();
            this.panelAfterCalibration.SuspendLayout();
            this.LeftCalibPanel.SuspendLayout();
            this.tbCalibration.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 19);
            this.label13.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 19);
            this.label14.TabIndex = 52;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 19);
            this.label16.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 19);
            this.label15.TabIndex = 50;
            // 
            // CalibrationPanel
            // 
            this.CalibrationPanel.AutoScroll = true;
            this.CalibrationPanel.AutoSize = true;
            this.CalibrationPanel.Controls.Add(this.RightCalibPanel);
            this.CalibrationPanel.Controls.Add(this.LeftCalibPanel);
            this.CalibrationPanel.Controls.Add(this.lbCalibrateTitle);
            this.CalibrationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalibrationPanel.Location = new System.Drawing.Point(0, 0);
            this.CalibrationPanel.Name = "CalibrationPanel";
            this.CalibrationPanel.Size = new System.Drawing.Size(1443, 857);
            this.CalibrationPanel.TabIndex = 53;
            // 
            // RightCalibPanel
            // 
            this.RightCalibPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RightCalibPanel.Controls.Add(this.panelAfterCalibration);
            this.RightCalibPanel.Location = new System.Drawing.Point(736, 82);
            this.RightCalibPanel.Name = "RightCalibPanel";
            this.RightCalibPanel.Size = new System.Drawing.Size(709, 746);
            this.RightCalibPanel.TabIndex = 53;
            // 
            // panelAfterCalibration
            // 
            this.panelAfterCalibration.AutoSize = true;
            this.panelAfterCalibration.Controls.Add(this.lbAfterCalbTitle);
            this.panelAfterCalibration.Controls.Add(this.lbCalibResult);
            this.panelAfterCalibration.Location = new System.Drawing.Point(15, 5);
            this.panelAfterCalibration.Margin = new System.Windows.Forms.Padding(2);
            this.panelAfterCalibration.Name = "panelAfterCalibration";
            this.panelAfterCalibration.Size = new System.Drawing.Size(681, 305);
            this.panelAfterCalibration.TabIndex = 51;
            // 
            // lbAfterCalbTitle
            // 
            this.lbAfterCalbTitle.AutoSize = true;
            this.lbAfterCalbTitle.Font = new System.Drawing.Font("Calibri", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAfterCalbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbAfterCalbTitle.Location = new System.Drawing.Point(2, 2);
            this.lbAfterCalbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAfterCalbTitle.Name = "lbAfterCalbTitle";
            this.lbAfterCalbTitle.Size = new System.Drawing.Size(544, 59);
            this.lbAfterCalbTitle.TabIndex = 25;
            this.lbAfterCalbTitle.Text = "Thông Số Sau Kiểm Chuẩn";
            // 
            // lbCalibResult
            // 
            this.lbCalibResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCalibResult.AutoSize = true;
            this.lbCalibResult.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibResult.ForeColor = System.Drawing.Color.Red;
            this.lbCalibResult.Location = new System.Drawing.Point(148, 78);
            this.lbCalibResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCalibResult.Name = "lbCalibResult";
            this.lbCalibResult.Size = new System.Drawing.Size(239, 163);
            this.lbCalibResult.TabIndex = 26;
            this.lbCalibResult.Text = "0.0";
            // 
            // LeftCalibPanel
            // 
            this.LeftCalibPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftCalibPanel.AutoScroll = true;
            this.LeftCalibPanel.Controls.Add(this.tbCalibration);
            this.LeftCalibPanel.Location = new System.Drawing.Point(3, 80);
            this.LeftCalibPanel.Name = "LeftCalibPanel";
            this.LeftCalibPanel.Size = new System.Drawing.Size(727, 748);
            this.LeftCalibPanel.TabIndex = 52;
            // 
            // tbCalibration
            // 
            this.tbCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCalibration.AutoSize = true;
            this.tbCalibration.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tbCalibration.ColumnCount = 2;
            this.tbCalibration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbCalibration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbCalibration.Controls.Add(this.lbParaB, 0, 12);
            this.tbCalibration.Controls.Add(this.lbParaWeightLB, 1, 12);
            this.tbCalibration.Controls.Add(this.lbParaWeightLA, 1, 11);
            this.tbCalibration.Controls.Add(this.lbParaA, 0, 11);
            this.tbCalibration.Controls.Add(this.txtCalibrateInput2, 1, 4);
            this.tbCalibration.Controls.Add(this.lbCalibWeightLB, 1, 9);
            this.tbCalibration.Controls.Add(this.lbCalibB, 0, 9);
            this.tbCalibration.Controls.Add(this.lbCalibWeightLA, 1, 8);
            this.tbCalibration.Controls.Add(this.btnSavePara, 0, 10);
            this.tbCalibration.Controls.Add(this.btnAcpCalibrate2, 1, 6);
            this.tbCalibration.Controls.Add(this.lbCalibrateIput2, 1, 5);
            this.tbCalibration.Controls.Add(this.txtBeforeCalib, 1, 0);
            this.tbCalibration.Controls.Add(this.lbCalibA, 0, 8);
            this.tbCalibration.Controls.Add(this.btnCalculateCalib, 0, 7);
            this.tbCalibration.Controls.Add(this.label5, 0, 4);
            this.tbCalibration.Controls.Add(this.label3, 0, 1);
            this.tbCalibration.Controls.Add(this.btnAcpCalibrate1, 1, 3);
            this.tbCalibration.Controls.Add(this.lbCalibrateIput1, 1, 2);
            this.tbCalibration.Controls.Add(this.label6, 0, 5);
            this.tbCalibration.Controls.Add(this.txtCalibrateInput1, 1, 1);
            this.tbCalibration.Controls.Add(this.label4, 0, 2);
            this.tbCalibration.Controls.Add(this.label2, 0, 0);
            this.tbCalibration.Location = new System.Drawing.Point(228, 20);
            this.tbCalibration.Margin = new System.Windows.Forms.Padding(2);
            this.tbCalibration.Name = "tbCalibration";
            this.tbCalibration.RowCount = 13;
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbCalibration.Size = new System.Drawing.Size(497, 710);
            this.tbCalibration.TabIndex = 52;
            // 
            // lbParaB
            // 
            this.lbParaB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbParaB.AutoSize = true;
            this.lbParaB.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParaB.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbParaB.Location = new System.Drawing.Point(4, 662);
            this.lbParaB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbParaB.Name = "lbParaB";
            this.lbParaB.Size = new System.Drawing.Size(212, 33);
            this.lbParaB.TabIndex = 49;
            this.lbParaB.Text = "Para\\LeftWeightB";
            // 
            // lbParaWeightLB
            // 
            this.lbParaWeightLB.AutoSize = true;
            this.lbParaWeightLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbParaWeightLB.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParaWeightLB.ForeColor = System.Drawing.Color.Red;
            this.lbParaWeightLB.Location = new System.Drawing.Point(290, 649);
            this.lbParaWeightLB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbParaWeightLB.Name = "lbParaWeightLB";
            this.lbParaWeightLB.Size = new System.Drawing.Size(203, 59);
            this.lbParaWeightLB.TabIndex = 49;
            this.lbParaWeightLB.Text = "0.00";
            this.lbParaWeightLB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbParaWeightLA
            // 
            this.lbParaWeightLA.AutoSize = true;
            this.lbParaWeightLA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbParaWeightLA.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParaWeightLA.ForeColor = System.Drawing.Color.Red;
            this.lbParaWeightLA.Location = new System.Drawing.Point(290, 588);
            this.lbParaWeightLA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbParaWeightLA.Name = "lbParaWeightLA";
            this.lbParaWeightLA.Size = new System.Drawing.Size(203, 59);
            this.lbParaWeightLA.TabIndex = 49;
            this.lbParaWeightLA.Text = "1.00";
            this.lbParaWeightLA.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbParaA
            // 
            this.lbParaA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbParaA.AutoSize = true;
            this.lbParaA.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParaA.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbParaA.Location = new System.Drawing.Point(4, 601);
            this.lbParaA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbParaA.Name = "lbParaA";
            this.lbParaA.Size = new System.Drawing.Size(213, 33);
            this.lbParaA.TabIndex = 49;
            this.lbParaA.Text = "Para\\LeftWeightA";
            // 
            // txtCalibrateInput2
            // 
            this.txtCalibrateInput2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCalibrateInput2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCalibrateInput2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalibrateInput2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCalibrateInput2.Location = new System.Drawing.Point(290, 208);
            this.txtCalibrateInput2.Margin = new System.Windows.Forms.Padding(2);
            this.txtCalibrateInput2.Name = "txtCalibrateInput2";
            this.txtCalibrateInput2.Size = new System.Drawing.Size(203, 40);
            this.txtCalibrateInput2.TabIndex = 37;
            this.txtCalibrateInput2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbCalibWeightLB
            // 
            this.lbCalibWeightLB.AutoSize = true;
            this.lbCalibWeightLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCalibWeightLB.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibWeightLB.ForeColor = System.Drawing.Color.Red;
            this.lbCalibWeightLB.Location = new System.Drawing.Point(290, 476);
            this.lbCalibWeightLB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCalibWeightLB.Name = "lbCalibWeightLB";
            this.lbCalibWeightLB.Size = new System.Drawing.Size(203, 59);
            this.lbCalibWeightLB.TabIndex = 43;
            this.lbCalibWeightLB.Text = "0.00";
            this.lbCalibWeightLB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbCalibB
            // 
            this.lbCalibB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCalibB.AutoSize = true;
            this.lbCalibB.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibB.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCalibB.Location = new System.Drawing.Point(4, 489);
            this.lbCalibB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCalibB.Name = "lbCalibB";
            this.lbCalibB.Size = new System.Drawing.Size(219, 33);
            this.lbCalibB.TabIndex = 41;
            this.lbCalibB.Text = "Calib\\LeftWeightB";
            // 
            // lbCalibWeightLA
            // 
            this.lbCalibWeightLA.AutoSize = true;
            this.lbCalibWeightLA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCalibWeightLA.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibWeightLA.ForeColor = System.Drawing.Color.Red;
            this.lbCalibWeightLA.Location = new System.Drawing.Point(290, 415);
            this.lbCalibWeightLA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCalibWeightLA.Name = "lbCalibWeightLA";
            this.lbCalibWeightLA.Size = new System.Drawing.Size(203, 59);
            this.lbCalibWeightLA.TabIndex = 42;
            this.lbCalibWeightLA.Text = "1.00";
            this.lbCalibWeightLA.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSavePara
            // 
            this.btnSavePara.AutoSize = true;
            this.btnSavePara.BackColor = System.Drawing.SystemColors.Info;
            this.btnSavePara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSavePara.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePara.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSavePara.Location = new System.Drawing.Point(4, 539);
            this.btnSavePara.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePara.Name = "btnSavePara";
            this.btnSavePara.Size = new System.Drawing.Size(280, 45);
            this.btnSavePara.TabIndex = 47;
            this.btnSavePara.Text = "Lưu Thông Số";
            this.btnSavePara.UseVisualStyleBackColor = false;
            this.btnSavePara.Click += new System.EventHandler(this.btnSavePara_Click);
            // 
            // btnAcpCalibrate2
            // 
            this.btnAcpCalibrate2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAcpCalibrate2.AutoSize = true;
            this.btnAcpCalibrate2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcpCalibrate2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAcpCalibrate2.Location = new System.Drawing.Point(301, 315);
            this.btnAcpCalibrate2.Margin = new System.Windows.Forms.Padding(2);
            this.btnAcpCalibrate2.Name = "btnAcpCalibrate2";
            this.btnAcpCalibrate2.Size = new System.Drawing.Size(181, 45);
            this.btnAcpCalibrate2.TabIndex = 45;
            this.btnAcpCalibrate2.Text = "Xác định điểm đo 2";
            this.btnAcpCalibrate2.UseVisualStyleBackColor = true;
            this.btnAcpCalibrate2.TextChanged += new System.EventHandler(this.btnAcpCalibrate2_Click);
            this.btnAcpCalibrate2.Click += new System.EventHandler(this.btnAcpCalibrate2_Click);
            // 
            // lbCalibrateIput2
            // 
            this.lbCalibrateIput2.AutoSize = true;
            this.lbCalibrateIput2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCalibrateIput2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibrateIput2.ForeColor = System.Drawing.Color.Red;
            this.lbCalibrateIput2.Location = new System.Drawing.Point(290, 252);
            this.lbCalibrateIput2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCalibrateIput2.Name = "lbCalibrateIput2";
            this.lbCalibrateIput2.Size = new System.Drawing.Size(203, 59);
            this.lbCalibrateIput2.TabIndex = 39;
            this.lbCalibrateIput2.Text = "0.00";
            this.lbCalibrateIput2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBeforeCalib
            // 
            this.txtBeforeCalib.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBeforeCalib.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtBeforeCalib.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeforeCalib.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtBeforeCalib.Location = new System.Drawing.Point(290, 4);
            this.txtBeforeCalib.Margin = new System.Windows.Forms.Padding(2);
            this.txtBeforeCalib.Name = "txtBeforeCalib";
            this.txtBeforeCalib.Size = new System.Drawing.Size(203, 40);
            this.txtBeforeCalib.TabIndex = 31;
            this.txtBeforeCalib.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBeforeCalib.TextChanged += new System.EventHandler(this.txtBeforeCalib_TextChanged);
            // 
            // lbCalibA
            // 
            this.lbCalibA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCalibA.AutoSize = true;
            this.lbCalibA.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibA.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCalibA.Location = new System.Drawing.Point(4, 428);
            this.lbCalibA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCalibA.Name = "lbCalibA";
            this.lbCalibA.Size = new System.Drawing.Size(220, 33);
            this.lbCalibA.TabIndex = 40;
            this.lbCalibA.Text = "Calib\\LeftWeightA";
            // 
            // btnCalculateCalib
            // 
            this.btnCalculateCalib.AutoSize = true;
            this.btnCalculateCalib.BackColor = System.Drawing.SystemColors.Info;
            this.btnCalculateCalib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCalculateCalib.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculateCalib.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCalculateCalib.Location = new System.Drawing.Point(4, 366);
            this.btnCalculateCalib.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalculateCalib.Name = "btnCalculateCalib";
            this.btnCalculateCalib.Size = new System.Drawing.Size(280, 45);
            this.btnCalculateCalib.TabIndex = 46;
            this.btnCalculateCalib.Text = "Tính Toán";
            this.btnCalculateCalib.UseVisualStyleBackColor = false;
            this.btnCalculateCalib.TextChanged += new System.EventHandler(this.btnCalculateCalib_Click);
            this.btnCalculateCalib.Click += new System.EventHandler(this.btnCalculateCalib_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(4, 211);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 33);
            this.label5.TabIndex = 35;
            this.label5.Text = "Điểm Đo Chuẩn 2";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(4, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 33);
            this.label3.TabIndex = 32;
            this.label3.Text = "Điểm Đo Chuẩn 1";
            // 
            // btnAcpCalibrate1
            // 
            this.btnAcpCalibrate1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAcpCalibrate1.AutoSize = true;
            this.btnAcpCalibrate1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcpCalibrate1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAcpCalibrate1.Location = new System.Drawing.Point(301, 157);
            this.btnAcpCalibrate1.Margin = new System.Windows.Forms.Padding(2);
            this.btnAcpCalibrate1.Name = "btnAcpCalibrate1";
            this.btnAcpCalibrate1.Size = new System.Drawing.Size(181, 45);
            this.btnAcpCalibrate1.TabIndex = 44;
            this.btnAcpCalibrate1.Text = "Xác định điểm đo 1";
            this.btnAcpCalibrate1.UseVisualStyleBackColor = true;
            this.btnAcpCalibrate1.TextChanged += new System.EventHandler(this.btnAcpCalibrate1_Click);
            this.btnAcpCalibrate1.Click += new System.EventHandler(this.btnAcpCalibrate1_Click);
            // 
            // lbCalibrateIput1
            // 
            this.lbCalibrateIput1.AutoSize = true;
            this.lbCalibrateIput1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCalibrateIput1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibrateIput1.ForeColor = System.Drawing.Color.Red;
            this.lbCalibrateIput1.Location = new System.Drawing.Point(290, 94);
            this.lbCalibrateIput1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCalibrateIput1.Name = "lbCalibrateIput1";
            this.lbCalibrateIput1.Size = new System.Drawing.Size(203, 59);
            this.lbCalibrateIput1.TabIndex = 38;
            this.lbCalibrateIput1.Text = "0.00";
            this.lbCalibrateIput1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(4, 265);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 33);
            this.label6.TabIndex = 36;
            this.label6.Text = "Điểm Đo 2";
            // 
            // txtCalibrateInput1
            // 
            this.txtCalibrateInput1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCalibrateInput1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCalibrateInput1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalibrateInput1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCalibrateInput1.Location = new System.Drawing.Point(290, 50);
            this.txtCalibrateInput1.Margin = new System.Windows.Forms.Padding(2);
            this.txtCalibrateInput1.Name = "txtCalibrateInput1";
            this.txtCalibrateInput1.Size = new System.Drawing.Size(203, 40);
            this.txtCalibrateInput1.TabIndex = 33;
            this.txtCalibrateInput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(4, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 33);
            this.label4.TabIndex = 34;
            this.label4.Text = "Điểm Đo 1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 33);
            this.label2.TabIndex = 30;
            this.label2.Text = "Trước Kiểm Chuẩn";
            // 
            // lbCalibrateTitle
            // 
            this.lbCalibrateTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbCalibrateTitle.AutoSize = true;
            this.lbCalibrateTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibrateTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCalibrateTitle.Location = new System.Drawing.Point(201, 0);
            this.lbCalibrateTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCalibrateTitle.Name = "lbCalibrateTitle";
            this.lbCalibrateTitle.Size = new System.Drawing.Size(970, 78);
            this.lbCalibrateTitle.TabIndex = 49;
            this.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - T.Lượng Trái";
            this.lbCalibrateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.CalibrationPanel);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmCalibration";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCalibration_Load);
            this.CalibrationPanel.ResumeLayout(false);
            this.CalibrationPanel.PerformLayout();
            this.RightCalibPanel.ResumeLayout(false);
            this.RightCalibPanel.PerformLayout();
            this.panelAfterCalibration.ResumeLayout(false);
            this.panelAfterCalibration.PerformLayout();
            this.LeftCalibPanel.ResumeLayout(false);
            this.LeftCalibPanel.PerformLayout();
            this.tbCalibration.ResumeLayout(false);
            this.tbCalibration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private Panel CalibrationPanel;
        public Label lbCalibrateTitle;
        private Panel RightCalibPanel;
        private Panel panelAfterCalibration;
        private Label lbAfterCalbTitle;
        public Label lbCalibResult;
        private Panel LeftCalibPanel;
        private TableLayoutPanel tbCalibration;
        public Label lbParaB;
        public Label lbParaWeightLB;
        public Label lbParaWeightLA;
        public Label lbParaA;
        private TextBox txtCalibrateInput2;
        private Label lbCalibWeightLB;
        public Label lbCalibB;
        private Label lbCalibWeightLA;
        private Button btnSavePara;
        private Button btnAcpCalibrate2;
        private Label lbCalibrateIput2;
        private TextBox txtBeforeCalib;
        public Label lbCalibA;
        private Button btnCalculateCalib;
        private Label label5;
        private Label label3;
        private Button btnAcpCalibrate1;
        private Label lbCalibrateIput1;
        private Label label6;
        private TextBox txtCalibrateInput1;
        private Label label4;
        private Label label2;
    }
}