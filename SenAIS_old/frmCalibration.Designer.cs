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
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 52;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 23);
            this.label16.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 50;
            // 
            // CalibrationPanel
            // 
            this.CalibrationPanel.AutoSize = true;
            this.CalibrationPanel.Controls.Add(this.RightCalibPanel);
            this.CalibrationPanel.Controls.Add(this.LeftCalibPanel);
            this.CalibrationPanel.Controls.Add(this.lbCalibrateTitle);
            this.CalibrationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalibrationPanel.Location = new System.Drawing.Point(0, 0);
            this.CalibrationPanel.Margin = new System.Windows.Forms.Padding(4);
            this.CalibrationPanel.Name = "CalibrationPanel";
            this.CalibrationPanel.Size = new System.Drawing.Size(1827, 922);
            this.CalibrationPanel.TabIndex = 53;
            // 
            // RightCalibPanel
            // 
            this.RightCalibPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RightCalibPanel.Controls.Add(this.panelAfterCalibration);
            this.RightCalibPanel.Location = new System.Drawing.Point(935, 101);
            this.RightCalibPanel.Margin = new System.Windows.Forms.Padding(4);
            this.RightCalibPanel.Name = "RightCalibPanel";
            this.RightCalibPanel.Size = new System.Drawing.Size(889, 806);
            this.RightCalibPanel.TabIndex = 53;
            // 
            // panelAfterCalibration
            // 
            this.panelAfterCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAfterCalibration.Controls.Add(this.lbAfterCalbTitle);
            this.panelAfterCalibration.Controls.Add(this.lbCalibResult);
            this.panelAfterCalibration.Location = new System.Drawing.Point(20, 6);
            this.panelAfterCalibration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAfterCalibration.Name = "panelAfterCalibration";
            this.panelAfterCalibration.Size = new System.Drawing.Size(866, 375);
            this.panelAfterCalibration.TabIndex = 51;
            // 
            // lbAfterCalbTitle
            // 
            this.lbAfterCalbTitle.AutoSize = true;
            this.lbAfterCalbTitle.Font = new System.Drawing.Font("Calibri", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAfterCalbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbAfterCalbTitle.Location = new System.Drawing.Point(3, 2);
            this.lbAfterCalbTitle.Name = "lbAfterCalbTitle";
            this.lbAfterCalbTitle.Size = new System.Drawing.Size(677, 73);
            this.lbAfterCalbTitle.TabIndex = 25;
            this.lbAfterCalbTitle.Text = "Thông Số Sau Kiểm Chuẩn";
            // 
            // lbCalibResult
            // 
            this.lbCalibResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCalibResult.Font = new System.Drawing.Font("Calibri", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibResult.ForeColor = System.Drawing.Color.Red;
            this.lbCalibResult.Location = new System.Drawing.Point(16, 96);
            this.lbCalibResult.Name = "lbCalibResult";
            this.lbCalibResult.Size = new System.Drawing.Size(792, 219);
            this.lbCalibResult.TabIndex = 26;
            this.lbCalibResult.Text = "0.0";
            // 
            // LeftCalibPanel
            // 
            this.LeftCalibPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftCalibPanel.AutoScroll = true;
            this.LeftCalibPanel.Controls.Add(this.tbCalibration);
            this.LeftCalibPanel.Location = new System.Drawing.Point(4, 98);
            this.LeftCalibPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LeftCalibPanel.Name = "LeftCalibPanel";
            this.LeftCalibPanel.Size = new System.Drawing.Size(923, 809);
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
            this.tbCalibration.Location = new System.Drawing.Point(215, 25);
            this.tbCalibration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.tbCalibration.Size = new System.Drawing.Size(663, 907);
            this.tbCalibration.TabIndex = 52;
            // 
            // lbParaB
            // 
            this.lbParaB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbParaB.AutoSize = true;
            this.lbParaB.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParaB.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbParaB.Location = new System.Drawing.Point(5, 825);
            this.lbParaB.Name = "lbParaB";
            this.lbParaB.Size = new System.Drawing.Size(268, 41);
            this.lbParaB.TabIndex = 49;
            this.lbParaB.Text = "Para\\LeftWeightB";
            // 
            // lbParaWeightLB
            // 
            this.lbParaWeightLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbParaWeightLB.AutoSize = true;
            this.lbParaWeightLB.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParaWeightLB.ForeColor = System.Drawing.Color.Red;
            this.lbParaWeightLB.Location = new System.Drawing.Point(386, 809);
            this.lbParaWeightLB.Name = "lbParaWeightLB";
            this.lbParaWeightLB.Size = new System.Drawing.Size(272, 73);
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
            this.lbParaWeightLA.Location = new System.Drawing.Point(386, 711);
            this.lbParaWeightLA.Name = "lbParaWeightLA";
            this.lbParaWeightLA.Size = new System.Drawing.Size(272, 73);
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
            this.lbParaA.Location = new System.Drawing.Point(5, 727);
            this.lbParaA.Name = "lbParaA";
            this.lbParaA.Size = new System.Drawing.Size(270, 41);
            this.lbParaA.TabIndex = 49;
            this.lbParaA.Text = "Para\\LeftWeightA";
            // 
            // txtCalibrateInput2
            // 
            this.txtCalibrateInput2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCalibrateInput2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCalibrateInput2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalibrateInput2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCalibrateInput2.Location = new System.Drawing.Point(387, 250);
            this.txtCalibrateInput2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCalibrateInput2.Name = "txtCalibrateInput2";
            this.txtCalibrateInput2.Size = new System.Drawing.Size(269, 49);
            this.txtCalibrateInput2.TabIndex = 37;
            this.txtCalibrateInput2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbCalibWeightLB
            // 
            this.lbCalibWeightLB.AutoSize = true;
            this.lbCalibWeightLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCalibWeightLB.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibWeightLB.ForeColor = System.Drawing.Color.Red;
            this.lbCalibWeightLB.Location = new System.Drawing.Point(386, 575);
            this.lbCalibWeightLB.Name = "lbCalibWeightLB";
            this.lbCalibWeightLB.Size = new System.Drawing.Size(272, 73);
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
            this.lbCalibB.Location = new System.Drawing.Point(5, 591);
            this.lbCalibB.Name = "lbCalibB";
            this.lbCalibB.Size = new System.Drawing.Size(275, 41);
            this.lbCalibB.TabIndex = 41;
            this.lbCalibB.Text = "Calib\\LeftWeightB";
            // 
            // lbCalibWeightLA
            // 
            this.lbCalibWeightLA.AutoSize = true;
            this.lbCalibWeightLA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCalibWeightLA.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibWeightLA.ForeColor = System.Drawing.Color.Red;
            this.lbCalibWeightLA.Location = new System.Drawing.Point(386, 500);
            this.lbCalibWeightLA.Name = "lbCalibWeightLA";
            this.lbCalibWeightLA.Size = new System.Drawing.Size(272, 73);
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
            this.btnSavePara.Location = new System.Drawing.Point(5, 652);
            this.btnSavePara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSavePara.Name = "btnSavePara";
            this.btnSavePara.Size = new System.Drawing.Size(373, 55);
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
            this.btnAcpCalibrate2.Location = new System.Drawing.Point(401, 380);
            this.btnAcpCalibrate2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAcpCalibrate2.Name = "btnAcpCalibrate2";
            this.btnAcpCalibrate2.Size = new System.Drawing.Size(241, 55);
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
            this.lbCalibrateIput2.Location = new System.Drawing.Point(386, 303);
            this.lbCalibrateIput2.Name = "lbCalibrateIput2";
            this.lbCalibrateIput2.Size = new System.Drawing.Size(272, 73);
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
            this.txtBeforeCalib.Location = new System.Drawing.Point(387, 4);
            this.txtBeforeCalib.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBeforeCalib.Name = "txtBeforeCalib";
            this.txtBeforeCalib.Size = new System.Drawing.Size(269, 49);
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
            this.lbCalibA.Location = new System.Drawing.Point(5, 516);
            this.lbCalibA.Name = "lbCalibA";
            this.lbCalibA.Size = new System.Drawing.Size(277, 41);
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
            this.btnCalculateCalib.Location = new System.Drawing.Point(5, 441);
            this.btnCalculateCalib.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalculateCalib.Name = "btnCalculateCalib";
            this.btnCalculateCalib.Size = new System.Drawing.Size(373, 55);
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
            this.label5.Location = new System.Drawing.Point(5, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 41);
            this.label5.TabIndex = 35;
            this.label5.Text = "Điểm Đo Chuẩn 2";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(5, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 41);
            this.label3.TabIndex = 32;
            this.label3.Text = "Điểm Đo Chuẩn 1";
            // 
            // btnAcpCalibrate1
            // 
            this.btnAcpCalibrate1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAcpCalibrate1.AutoSize = true;
            this.btnAcpCalibrate1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcpCalibrate1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAcpCalibrate1.Location = new System.Drawing.Point(401, 189);
            this.btnAcpCalibrate1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAcpCalibrate1.Name = "btnAcpCalibrate1";
            this.btnAcpCalibrate1.Size = new System.Drawing.Size(241, 55);
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
            this.lbCalibrateIput1.Location = new System.Drawing.Point(386, 112);
            this.lbCalibrateIput1.Name = "lbCalibrateIput1";
            this.lbCalibrateIput1.Size = new System.Drawing.Size(272, 73);
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
            this.label6.Location = new System.Drawing.Point(5, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 41);
            this.label6.TabIndex = 36;
            this.label6.Text = "Điểm Đo 2";
            // 
            // txtCalibrateInput1
            // 
            this.txtCalibrateInput1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCalibrateInput1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCalibrateInput1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalibrateInput1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCalibrateInput1.Location = new System.Drawing.Point(387, 59);
            this.txtCalibrateInput1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCalibrateInput1.Name = "txtCalibrateInput1";
            this.txtCalibrateInput1.Size = new System.Drawing.Size(269, 49);
            this.txtCalibrateInput1.TabIndex = 33;
            this.txtCalibrateInput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(5, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 41);
            this.label4.TabIndex = 34;
            this.label4.Text = "Điểm Đo 1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 41);
            this.label2.TabIndex = 30;
            this.label2.Text = "Trước Kiểm Chuẩn";
            // 
            // lbCalibrateTitle
            // 
            this.lbCalibrateTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbCalibrateTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalibrateTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCalibrateTitle.Location = new System.Drawing.Point(4, 0);
            this.lbCalibrateTitle.Name = "lbCalibrateTitle";
            this.lbCalibrateTitle.Size = new System.Drawing.Size(1811, 97);
            this.lbCalibrateTitle.TabIndex = 49;
            this.lbCalibrateTitle.Text = "Kiểm Chuẩn Tham Số - T.Lượng Trái";
            this.lbCalibrateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1827, 922);
            this.Controls.Add(this.CalibrationPanel);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmCalibration";
            this.ShowIcon = false;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCalibration_Load);
            this.CalibrationPanel.ResumeLayout(false);
            this.RightCalibPanel.ResumeLayout(false);
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