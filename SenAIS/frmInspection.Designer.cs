namespace SenAIS
{
    partial class frmInspection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInspection));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReport = new System.Windows.Forms.Button();
            this.tbMenuControl = new System.Windows.Forms.TableLayoutPanel();
            this.btnFoglights = new System.Windows.Forms.Button();
            this.btnHeadlights = new System.Windows.Forms.Button();
            this.btnSideSlip = new System.Windows.Forms.Button();
            this.btnFrontBrake = new System.Windows.Forms.Button();
            this.btnEmission = new System.Windows.Forms.Button();
            this.btnNoise = new System.Windows.Forms.Button();
            this.btnHandBrake = new System.Windows.Forms.Button();
            this.btnRearBrake = new System.Windows.Forms.Button();
            this.cbManualMode = new System.Windows.Forms.CheckBox();
            this.btnRearWeight = new System.Windows.Forms.Button();
            this.btnSpeed = new System.Windows.Forms.Button();
            this.btnFrontWeight = new System.Windows.Forms.Button();
            this.btnSteerAngle = new System.Windows.Forms.Button();
            this.btnWhistle = new System.Windows.Forms.Button();
            this.btnInspecProgress = new System.Windows.Forms.Button();
            this.InspectionPanel = new System.Windows.Forms.Panel();
<<<<<<< HEAD
=======
            this.VehicleListPanel = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgVehicleInfo = new System.Windows.Forms.DataGridView();
>>>>>>> SenAIS_DH
            this.cbPos2 = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnResetMain = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbPos1 = new System.Windows.Forms.CheckBox();
            this.btnAddList = new System.Windows.Forms.Button();
            this.txtVinShow = new System.Windows.Forms.TextBox();
            this.tbVehicleInfo = new System.Windows.Forms.TableLayoutPanel();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.cbFuel = new System.Windows.Forms.ComboBox();
            this.lbFuelTitle = new System.Windows.Forms.Label();
            this.lbInspecDateTitle = new System.Windows.Forms.Label();
            this.dateInSpec = new System.Windows.Forms.DateTimePicker();
            this.txtVinNum = new System.Windows.Forms.TextBox();
            this.lbInspectorTitle = new System.Windows.Forms.Label();
            this.lbSerialNumTitle = new System.Windows.Forms.Label();
            this.cbInspector = new System.Windows.Forms.ComboBox();
            this.lbFrameNumTitle = new System.Windows.Forms.Label();
            this.txtEngineNum = new System.Windows.Forms.TextBox();
            this.lbTypeCarTitle = new System.Windows.Forms.Label();
            this.cbTypeCar = new System.Windows.Forms.ComboBox();
<<<<<<< HEAD
            this.VehicleListPanel = new System.Windows.Forms.Panel();
            this.dgVehicleInfo = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
=======
>>>>>>> SenAIS_DH
            this.tbMenuControl.SuspendLayout();
            this.InspectionPanel.SuspendLayout();
            this.VehicleListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicleInfo)).BeginInit();
            this.tbVehicleInfo.SuspendLayout();
            this.VehicleListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicleInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.AutoSize = true;
            this.btnReport.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(40, 754);
<<<<<<< HEAD
            this.btnReport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnReport.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(150, 50);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Xem Dữ Liệu";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tbMenuControl
            // 
            this.tbMenuControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbMenuControl.ColumnCount = 3;
            this.tbMenuControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbMenuControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbMenuControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tbMenuControl.Controls.Add(this.btnFoglights, 1, 0);
            this.tbMenuControl.Controls.Add(this.btnHeadlights, 0, 0);
            this.tbMenuControl.Controls.Add(this.btnSideSlip, 0, 1);
            this.tbMenuControl.Controls.Add(this.btnFrontBrake, 0, 2);
            this.tbMenuControl.Controls.Add(this.btnEmission, 0, 3);
            this.tbMenuControl.Controls.Add(this.btnNoise, 1, 4);
            this.tbMenuControl.Controls.Add(this.btnHandBrake, 2, 2);
            this.tbMenuControl.Controls.Add(this.btnRearBrake, 1, 2);
            this.tbMenuControl.Controls.Add(this.cbManualMode, 1, 3);
            this.tbMenuControl.Controls.Add(this.btnRearWeight, 2, 4);
            this.tbMenuControl.Controls.Add(this.btnSpeed, 0, 4);
            this.tbMenuControl.Controls.Add(this.btnFrontWeight, 2, 3);
            this.tbMenuControl.Controls.Add(this.btnSteerAngle, 2, 1);
            this.tbMenuControl.Controls.Add(this.btnWhistle, 1, 1);
            this.tbMenuControl.Location = new System.Drawing.Point(535, 106);
            this.tbMenuControl.Name = "tbMenuControl";
            this.tbMenuControl.RowCount = 5;
            this.tbMenuControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbMenuControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbMenuControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbMenuControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbMenuControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbMenuControl.Size = new System.Drawing.Size(539, 740);
            this.tbMenuControl.TabIndex = 6;
            // 
            // btnFoglights
            // 
            this.btnFoglights.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoglights.Location = new System.Drawing.Point(181, 2);
<<<<<<< HEAD
            this.btnFoglights.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnFoglights.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnFoglights.Name = "btnFoglights";
            this.btnFoglights.Size = new System.Drawing.Size(138, 53);
            this.btnFoglights.TabIndex = 19;
            this.btnFoglights.Text = "Đèn Sương Mù";
            this.btnFoglights.UseVisualStyleBackColor = true;
            this.btnFoglights.Click += new System.EventHandler(this.btnFoglights_Click);
            // 
            // btnHeadlights
            // 
            this.btnHeadlights.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeadlights.Location = new System.Drawing.Point(2, 2);
<<<<<<< HEAD
            this.btnHeadlights.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnHeadlights.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnHeadlights.Name = "btnHeadlights";
            this.btnHeadlights.Size = new System.Drawing.Size(129, 53);
            this.btnHeadlights.TabIndex = 10;
            this.btnHeadlights.Text = "Đèn Pha-Cốt";
            this.btnHeadlights.UseVisualStyleBackColor = true;
            this.btnHeadlights.Click += new System.EventHandler(this.btnHeadlights_Click);
            // 
            // btnSideSlip
            // 
            this.btnSideSlip.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSideSlip.Location = new System.Drawing.Point(2, 150);
<<<<<<< HEAD
            this.btnSideSlip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnSideSlip.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnSideSlip.Name = "btnSideSlip";
            this.btnSideSlip.Size = new System.Drawing.Size(129, 53);
            this.btnSideSlip.TabIndex = 5;
            this.btnSideSlip.Text = "Trượt Ngang";
            this.btnSideSlip.UseVisualStyleBackColor = true;
            this.btnSideSlip.Click += new System.EventHandler(this.btnSideSlip_Click);
            // 
            // btnFrontBrake
            // 
            this.btnFrontBrake.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrontBrake.Location = new System.Drawing.Point(2, 298);
<<<<<<< HEAD
            this.btnFrontBrake.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnFrontBrake.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnFrontBrake.Name = "btnFrontBrake";
            this.btnFrontBrake.Size = new System.Drawing.Size(129, 53);
            this.btnFrontBrake.TabIndex = 8;
            this.btnFrontBrake.Text = "Phanh Trước";
            this.btnFrontBrake.UseVisualStyleBackColor = true;
            this.btnFrontBrake.Click += new System.EventHandler(this.btnFrontBrake_Click);
            // 
            // btnEmission
            // 
            this.btnEmission.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmission.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEmission.Location = new System.Drawing.Point(2, 446);
<<<<<<< HEAD
            this.btnEmission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnEmission.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnEmission.Name = "btnEmission";
            this.btnEmission.Size = new System.Drawing.Size(125, 53);
            this.btnEmission.TabIndex = 12;
            this.btnEmission.Text = "Khí Xả Xăng";
            this.btnEmission.UseVisualStyleBackColor = true;
            this.btnEmission.Click += new System.EventHandler(this.btnEmission_Click);
            // 
            // btnNoise
            // 
            this.btnNoise.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoise.Location = new System.Drawing.Point(181, 594);
<<<<<<< HEAD
            this.btnNoise.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnNoise.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnNoise.Name = "btnNoise";
            this.btnNoise.Size = new System.Drawing.Size(129, 53);
            this.btnNoise.TabIndex = 6;
            this.btnNoise.Text = "Độ Ồn";
            this.btnNoise.UseVisualStyleBackColor = true;
            this.btnNoise.Click += new System.EventHandler(this.btnNoise_Click);
            // 
            // btnHandBrake
            // 
            this.btnHandBrake.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHandBrake.Location = new System.Drawing.Point(360, 298);
<<<<<<< HEAD
            this.btnHandBrake.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnHandBrake.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnHandBrake.Name = "btnHandBrake";
            this.btnHandBrake.Size = new System.Drawing.Size(129, 53);
            this.btnHandBrake.TabIndex = 17;
            this.btnHandBrake.Text = "Phanh Tay";
            this.btnHandBrake.UseVisualStyleBackColor = true;
            this.btnHandBrake.Click += new System.EventHandler(this.btnHandBrake_Click);
            // 
            // btnRearBrake
            // 
            this.btnRearBrake.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRearBrake.Location = new System.Drawing.Point(181, 298);
<<<<<<< HEAD
            this.btnRearBrake.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnRearBrake.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnRearBrake.Name = "btnRearBrake";
            this.btnRearBrake.Size = new System.Drawing.Size(129, 53);
            this.btnRearBrake.TabIndex = 16;
            this.btnRearBrake.Text = "Phanh Sau";
            this.btnRearBrake.UseVisualStyleBackColor = true;
            this.btnRearBrake.Click += new System.EventHandler(this.btnRearBrake_Click);
            // 
            // cbManualMode
            // 
            this.cbManualMode.AutoSize = true;
            this.cbManualMode.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManualMode.Location = new System.Drawing.Point(181, 446);
<<<<<<< HEAD
            this.cbManualMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.cbManualMode.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.cbManualMode.Name = "cbManualMode";
            this.cbManualMode.Size = new System.Drawing.Size(151, 33);
            this.cbManualMode.TabIndex = 20;
            this.cbManualMode.Text = "Đo thủ công";
            this.cbManualMode.UseVisualStyleBackColor = true;
            // 
            // btnRearWeight
            // 
            this.btnRearWeight.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRearWeight.Location = new System.Drawing.Point(360, 594);
<<<<<<< HEAD
            this.btnRearWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnRearWeight.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnRearWeight.Name = "btnRearWeight";
            this.btnRearWeight.Size = new System.Drawing.Size(138, 53);
            this.btnRearWeight.TabIndex = 13;
            this.btnRearWeight.Text = "Trọng Lượng S";
            this.btnRearWeight.UseVisualStyleBackColor = true;
            this.btnRearWeight.Visible = false;
            this.btnRearWeight.Click += new System.EventHandler(this.btnRearWeight_Click);
            // 
            // btnSpeed
            // 
            this.btnSpeed.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeed.Location = new System.Drawing.Point(2, 594);
<<<<<<< HEAD
            this.btnSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnSpeed.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnSpeed.Name = "btnSpeed";
            this.btnSpeed.Size = new System.Drawing.Size(129, 53);
            this.btnSpeed.TabIndex = 4;
            this.btnSpeed.Text = "Tốc Độ";
            this.btnSpeed.UseVisualStyleBackColor = true;
            this.btnSpeed.Click += new System.EventHandler(this.btnSpeed_Click);
            // 
            // btnFrontWeight
            // 
            this.btnFrontWeight.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrontWeight.Location = new System.Drawing.Point(360, 446);
<<<<<<< HEAD
            this.btnFrontWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnFrontWeight.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnFrontWeight.Name = "btnFrontWeight";
            this.btnFrontWeight.Size = new System.Drawing.Size(144, 53);
            this.btnFrontWeight.TabIndex = 7;
            this.btnFrontWeight.Text = "Trọng Lượng T";
            this.btnFrontWeight.UseVisualStyleBackColor = true;
            this.btnFrontWeight.Visible = false;
            this.btnFrontWeight.Click += new System.EventHandler(this.btnFrontWeight_Click);
            // 
            // btnSteerAngle
            // 
            this.btnSteerAngle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerAngle.Location = new System.Drawing.Point(360, 150);
<<<<<<< HEAD
            this.btnSteerAngle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnSteerAngle.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnSteerAngle.Name = "btnSteerAngle";
            this.btnSteerAngle.Size = new System.Drawing.Size(129, 53);
            this.btnSteerAngle.TabIndex = 18;
            this.btnSteerAngle.Text = "Góc Lái";
            this.btnSteerAngle.UseVisualStyleBackColor = true;
            this.btnSteerAngle.Click += new System.EventHandler(this.btnSteerAngle_Click);
            // 
            // btnWhistle
            // 
            this.btnWhistle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhistle.Location = new System.Drawing.Point(181, 150);
<<<<<<< HEAD
            this.btnWhistle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnWhistle.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnWhistle.Name = "btnWhistle";
            this.btnWhistle.Size = new System.Drawing.Size(129, 53);
            this.btnWhistle.TabIndex = 11;
            this.btnWhistle.Text = "Còi";
            this.btnWhistle.UseVisualStyleBackColor = true;
            this.btnWhistle.Click += new System.EventHandler(this.btnWhistle_Click);
            // 
            // btnInspecProgress
            // 
            this.btnInspecProgress.AutoSize = true;
            this.btnInspecProgress.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnInspecProgress.FlatAppearance.BorderSize = 2;
            this.btnInspecProgress.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInspecProgress.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnInspecProgress.Location = new System.Drawing.Point(40, 32);
<<<<<<< HEAD
            this.btnInspecProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnInspecProgress.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnInspecProgress.Name = "btnInspecProgress";
            this.btnInspecProgress.Size = new System.Drawing.Size(292, 58);
            this.btnInspecProgress.TabIndex = 1;
            this.btnInspecProgress.Text = "Nhập Thông Tin Xe";
            this.btnInspecProgress.UseVisualStyleBackColor = true;
            this.btnInspecProgress.Click += new System.EventHandler(this.btnInspecProgress_Click);
            // 
            // InspectionPanel
            // 
            this.InspectionPanel.AutoScroll = true;
            this.InspectionPanel.AutoSize = true;
            this.InspectionPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.InspectionPanel.Controls.Add(this.VehicleListPanel);
            this.InspectionPanel.Controls.Add(this.cbPos2);
            this.InspectionPanel.Controls.Add(this.btnExit);
            this.InspectionPanel.Controls.Add(this.btnResetMain);
            this.InspectionPanel.Controls.Add(this.btnStart);
            this.InspectionPanel.Controls.Add(this.cbPos1);
            this.InspectionPanel.Controls.Add(this.btnAddList);
            this.InspectionPanel.Controls.Add(this.txtVinShow);
            this.InspectionPanel.Controls.Add(this.tbVehicleInfo);
            this.InspectionPanel.Controls.Add(this.btnInspecProgress);
            this.InspectionPanel.Controls.Add(this.tbMenuControl);
            this.InspectionPanel.Controls.Add(this.btnReport);
            this.InspectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InspectionPanel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InspectionPanel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.InspectionPanel.Location = new System.Drawing.Point(0, 0);
<<<<<<< HEAD
            this.InspectionPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.InspectionPanel.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.InspectionPanel.Name = "InspectionPanel";
            this.InspectionPanel.Size = new System.Drawing.Size(1440, 857);
            this.InspectionPanel.TabIndex = 1;
            // 
<<<<<<< HEAD
=======
            // VehicleListPanel
            // 
            this.VehicleListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VehicleListPanel.Controls.Add(this.btnSearch);
            this.VehicleListPanel.Controls.Add(this.txtSearch);
            this.VehicleListPanel.Controls.Add(this.dgVehicleInfo);
            this.VehicleListPanel.Location = new System.Drawing.Point(512, 128);
            this.VehicleListPanel.Name = "VehicleListPanel";
            this.VehicleListPanel.Size = new System.Drawing.Size(787, 621);
            this.VehicleListPanel.TabIndex = 64;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(383, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 33);
            this.btnSearch.TabIndex = 63;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(374, 33);
            this.txtSearch.TabIndex = 62;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // dgVehicleInfo
            // 
            this.dgVehicleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVehicleInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgVehicleInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgVehicleInfo.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgVehicleInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgVehicleInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVehicleInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVehicleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVehicleInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgVehicleInfo.Location = new System.Drawing.Point(3, 53);
            this.dgVehicleInfo.Name = "dgVehicleInfo";
            this.dgVehicleInfo.ReadOnly = true;
            this.dgVehicleInfo.RowHeadersVisible = false;
            this.dgVehicleInfo.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgVehicleInfo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgVehicleInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVehicleInfo.Size = new System.Drawing.Size(775, 565);
            this.dgVehicleInfo.TabIndex = 61;
            this.dgVehicleInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVehicleInfo_CellClick);
            // 
>>>>>>> SenAIS_DH
            // cbPos2
            // 
            this.cbPos2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPos2.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbPos2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbPos2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbPos2.BackgroundImage")));
            this.cbPos2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbPos2.Checked = true;
            this.cbPos2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPos2.Enabled = false;
            this.cbPos2.Location = new System.Drawing.Point(1322, 200);
            this.cbPos2.Name = "cbPos2";
            this.cbPos2.Size = new System.Drawing.Size(115, 109);
            this.cbPos2.TabIndex = 63;
            this.cbPos2.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.AutoSize = true;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(349, 754);
<<<<<<< HEAD
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 50);
            this.btnExit.TabIndex = 62;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnResetMain
            // 
            this.btnResetMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetMain.AutoSize = true;
            this.btnResetMain.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetMain.Location = new System.Drawing.Point(194, 754);
<<<<<<< HEAD
            this.btnResetMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnResetMain.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnResetMain.Name = "btnResetMain";
            this.btnResetMain.Size = new System.Drawing.Size(150, 50);
            this.btnResetMain.TabIndex = 61;
            this.btnResetMain.Text = "Reset Hệ Thống";
            this.btnResetMain.UseVisualStyleBackColor = true;
            this.btnResetMain.Click += new System.EventHandler(this.btnResetMain_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnStart.AutoSize = true;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnStart.FlatAppearance.BorderSize = 2;
            this.btnStart.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnStart.Location = new System.Drawing.Point(109, 197);
<<<<<<< HEAD
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(138, 51);
            this.btnStart.TabIndex = 59;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbPos1
            // 
            this.cbPos1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPos1.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbPos1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbPos1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbPos1.BackgroundImage")));
            this.cbPos1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbPos1.Checked = true;
            this.cbPos1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPos1.Enabled = false;
            this.cbPos1.Location = new System.Drawing.Point(1322, 361);
            this.cbPos1.Name = "cbPos1";
            this.cbPos1.Size = new System.Drawing.Size(115, 109);
            this.cbPos1.TabIndex = 58;
            this.cbPos1.UseVisualStyleBackColor = false;
            // 
            // btnAddList
            // 
            this.btnAddList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddList.BackgroundImage")));
            this.btnAddList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddList.Location = new System.Drawing.Point(40, 197);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(52, 45);
            this.btnAddList.TabIndex = 19;
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // txtVinShow
            // 
            this.txtVinShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVinShow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtVinShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVinShow.Font = new System.Drawing.Font("Calibri", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVinShow.ForeColor = System.Drawing.Color.DarkRed;
            this.txtVinShow.Location = new System.Drawing.Point(512, 2);
<<<<<<< HEAD
            this.txtVinShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.txtVinShow.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.txtVinShow.Name = "txtVinShow";
            this.txtVinShow.ReadOnly = true;
            this.txtVinShow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVinShow.Size = new System.Drawing.Size(916, 98);
            this.txtVinShow.TabIndex = 18;
            this.txtVinShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbVehicleInfo
            // 
            this.tbVehicleInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbVehicleInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tbVehicleInfo.ColumnCount = 2;
            this.tbVehicleInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
<<<<<<< HEAD
            this.tbVehicleInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 364F));
=======
            this.tbVehicleInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 374F));
>>>>>>> SenAIS_DH
            this.tbVehicleInfo.Controls.Add(this.txtColor, 1, 6);
            this.tbVehicleInfo.Controls.Add(this.lbColor, 0, 6);
            this.tbVehicleInfo.Controls.Add(this.cbFuel, 1, 5);
            this.tbVehicleInfo.Controls.Add(this.lbFuelTitle, 0, 5);
            this.tbVehicleInfo.Controls.Add(this.lbInspecDateTitle, 0, 4);
            this.tbVehicleInfo.Controls.Add(this.dateInSpec, 1, 4);
            this.tbVehicleInfo.Controls.Add(this.txtVinNum, 1, 0);
            this.tbVehicleInfo.Controls.Add(this.lbInspectorTitle, 0, 3);
            this.tbVehicleInfo.Controls.Add(this.lbSerialNumTitle, 0, 0);
            this.tbVehicleInfo.Controls.Add(this.cbInspector, 1, 3);
            this.tbVehicleInfo.Controls.Add(this.lbFrameNumTitle, 0, 1);
            this.tbVehicleInfo.Controls.Add(this.txtEngineNum, 1, 1);
            this.tbVehicleInfo.Controls.Add(this.lbTypeCarTitle, 0, 2);
            this.tbVehicleInfo.Controls.Add(this.cbTypeCar, 1, 2);
            this.tbVehicleInfo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVehicleInfo.Location = new System.Drawing.Point(40, 259);
<<<<<<< HEAD
            this.tbVehicleInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.tbVehicleInfo.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.tbVehicleInfo.Name = "tbVehicleInfo";
            this.tbVehicleInfo.RowCount = 7;
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tbVehicleInfo.Size = new System.Drawing.Size(434, 346);
            this.tbVehicleInfo.TabIndex = 7;
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtColor.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColor.Location = new System.Drawing.Point(204, 298);
<<<<<<< HEAD
            this.txtColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(223, 37);
            this.txtColor.TabIndex = 21;
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColor.Location = new System.Drawing.Point(4, 296);
            this.lbColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(97, 33);
            this.lbColor.TabIndex = 20;
            this.lbColor.Text = "Màu Xe";
            // 
            // cbFuel
            // 
            this.cbFuel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuel.FormattingEnabled = true;
            this.cbFuel.Items.AddRange(new object[] {
            "Xăng",
            "Dầu"});
            this.cbFuel.Location = new System.Drawing.Point(204, 249);
<<<<<<< HEAD
            this.cbFuel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.cbFuel.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.cbFuel.Name = "cbFuel";
            this.cbFuel.Size = new System.Drawing.Size(223, 37);
            this.cbFuel.TabIndex = 19;
            this.cbFuel.SelectedIndexChanged += new System.EventHandler(this.cbFuel_SelectedIndexChanged);
            // 
            // lbFuelTitle
            // 
            this.lbFuelTitle.AutoSize = true;
            this.lbFuelTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFuelTitle.Location = new System.Drawing.Point(4, 247);
            this.lbFuelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFuelTitle.Name = "lbFuelTitle";
            this.lbFuelTitle.Size = new System.Drawing.Size(129, 33);
            this.lbFuelTitle.TabIndex = 8;
            this.lbFuelTitle.Text = "Nhiên Liệu";
            // 
            // lbInspecDateTitle
            // 
            this.lbInspecDateTitle.AutoSize = true;
            this.lbInspecDateTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInspecDateTitle.Location = new System.Drawing.Point(4, 198);
            this.lbInspecDateTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbInspecDateTitle.Name = "lbInspecDateTitle";
            this.lbInspecDateTitle.Size = new System.Drawing.Size(167, 33);
            this.lbInspecDateTitle.TabIndex = 5;
            this.lbInspecDateTitle.Text = "Ngày Kiểm Tra";
            // 
            // dateInSpec
            // 
            this.dateInSpec.CalendarForeColor = System.Drawing.SystemColors.HotTrack;
            this.dateInSpec.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption;
            this.dateInSpec.CalendarTitleForeColor = System.Drawing.SystemColors.HotTrack;
            this.dateInSpec.CalendarTrailingForeColor = System.Drawing.SystemColors.HotTrack;
            this.dateInSpec.CustomFormat = "dd/MM/yyyy";
            this.dateInSpec.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInSpec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInSpec.Location = new System.Drawing.Point(205, 201);
            this.dateInSpec.Name = "dateInSpec";
            this.dateInSpec.Size = new System.Drawing.Size(222, 37);
            this.dateInSpec.TabIndex = 8;
            this.dateInSpec.Value = new System.DateTime(2025, 2, 19, 0, 0, 0, 0);
            // 
            // txtVinNum
            // 
            this.txtVinNum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtVinNum.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVinNum.ForeColor = System.Drawing.Color.IndianRed;
            this.txtVinNum.Location = new System.Drawing.Point(204, 4);
<<<<<<< HEAD
            this.txtVinNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.txtVinNum.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.txtVinNum.Name = "txtVinNum";
            this.txtVinNum.Size = new System.Drawing.Size(223, 37);
            this.txtVinNum.TabIndex = 17;
            this.txtVinNum.TextChanged += new System.EventHandler(this.txtVinNum_TextChanged);
            this.txtVinNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVinNum_KeyDown);
            // 
            // lbInspectorTitle
            // 
            this.lbInspectorTitle.AutoSize = true;
            this.lbInspectorTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInspectorTitle.Location = new System.Drawing.Point(4, 149);
            this.lbInspectorTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbInspectorTitle.Name = "lbInspectorTitle";
            this.lbInspectorTitle.Size = new System.Drawing.Size(194, 33);
            this.lbInspectorTitle.TabIndex = 1;
            this.lbInspectorTitle.Text = "Người Phụ Trách";
            // 
            // lbSerialNumTitle
            // 
            this.lbSerialNumTitle.AutoSize = true;
            this.lbSerialNumTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSerialNumTitle.Location = new System.Drawing.Point(4, 2);
            this.lbSerialNumTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSerialNumTitle.Name = "lbSerialNumTitle";
            this.lbSerialNumTitle.Size = new System.Drawing.Size(86, 33);
            this.lbSerialNumTitle.TabIndex = 4;
            this.lbSerialNumTitle.Text = "Số Vin";
            // 
            // cbInspector
            // 
            this.cbInspector.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbInspector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInspector.DropDownWidth = 300;
            this.cbInspector.FormattingEnabled = true;
<<<<<<< HEAD
            this.cbInspector.Location = new System.Drawing.Point(204, 151);
            this.cbInspector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.cbInspector.IntegralHeight = false;
            this.cbInspector.Location = new System.Drawing.Point(204, 151);
            this.cbInspector.Margin = new System.Windows.Forms.Padding(2);
            this.cbInspector.MaxDropDownItems = 10;
>>>>>>> SenAIS_DH
            this.cbInspector.Name = "cbInspector";
            this.cbInspector.Size = new System.Drawing.Size(223, 37);
            this.cbInspector.TabIndex = 19;
            // 
            // lbFrameNumTitle
            // 
            this.lbFrameNumTitle.AutoSize = true;
            this.lbFrameNumTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFrameNumTitle.Location = new System.Drawing.Point(4, 51);
            this.lbFrameNumTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFrameNumTitle.Name = "lbFrameNumTitle";
            this.lbFrameNumTitle.Size = new System.Drawing.Size(95, 33);
            this.lbFrameNumTitle.TabIndex = 2;
            this.lbFrameNumTitle.Text = "Số Máy";
            // 
            // txtEngineNum
            // 
            this.txtEngineNum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtEngineNum.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEngineNum.Location = new System.Drawing.Point(204, 53);
<<<<<<< HEAD
            this.txtEngineNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.txtEngineNum.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.txtEngineNum.Name = "txtEngineNum";
            this.txtEngineNum.Size = new System.Drawing.Size(223, 37);
            this.txtEngineNum.TabIndex = 15;
            // 
            // lbTypeCarTitle
            // 
            this.lbTypeCarTitle.AutoSize = true;
            this.lbTypeCarTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTypeCarTitle.Location = new System.Drawing.Point(4, 100);
            this.lbTypeCarTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTypeCarTitle.Name = "lbTypeCarTitle";
            this.lbTypeCarTitle.Size = new System.Drawing.Size(91, 33);
            this.lbTypeCarTitle.TabIndex = 0;
            this.lbTypeCarTitle.Text = "Loại Xe";
            // 
            // cbTypeCar
            // 
            this.cbTypeCar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbTypeCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeCar.DropDownWidth = 300;
            this.cbTypeCar.FormattingEnabled = true;
<<<<<<< HEAD
            this.cbTypeCar.Location = new System.Drawing.Point(204, 102);
            this.cbTypeCar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.cbTypeCar.IntegralHeight = false;
            this.cbTypeCar.Location = new System.Drawing.Point(204, 102);
            this.cbTypeCar.Margin = new System.Windows.Forms.Padding(2);
            this.cbTypeCar.MaxDropDownItems = 10;
>>>>>>> SenAIS_DH
            this.cbTypeCar.Name = "cbTypeCar";
            this.cbTypeCar.Size = new System.Drawing.Size(223, 37);
            this.cbTypeCar.Sorted = true;
            this.cbTypeCar.TabIndex = 18;
            // 
            // VehicleListPanel
            // 
            this.VehicleListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VehicleListPanel.Controls.Add(this.btnSearch);
            this.VehicleListPanel.Controls.Add(this.txtSearch);
            this.VehicleListPanel.Controls.Add(this.dgVehicleInfo);
            this.VehicleListPanel.Location = new System.Drawing.Point(512, 128);
            this.VehicleListPanel.Name = "VehicleListPanel";
            this.VehicleListPanel.Size = new System.Drawing.Size(787, 621);
            this.VehicleListPanel.TabIndex = 64;
            // 
            // dgVehicleInfo
            // 
            this.dgVehicleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVehicleInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgVehicleInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgVehicleInfo.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgVehicleInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgVehicleInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVehicleInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVehicleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVehicleInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgVehicleInfo.Location = new System.Drawing.Point(3, 53);
            this.dgVehicleInfo.Name = "dgVehicleInfo";
            this.dgVehicleInfo.ReadOnly = true;
            this.dgVehicleInfo.RowHeadersVisible = false;
            this.dgVehicleInfo.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgVehicleInfo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgVehicleInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVehicleInfo.Size = new System.Drawing.Size(775, 565);
            this.dgVehicleInfo.TabIndex = 61;
            this.dgVehicleInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVehicleInfo_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(383, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 33);
            this.btnSearch.TabIndex = 63;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(374, 33);
            this.txtSearch.TabIndex = 62;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // frmInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1440, 857);
            this.Controls.Add(this.InspectionPanel);
<<<<<<< HEAD
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
=======
            this.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> SenAIS_DH
            this.Name = "frmInspection";
            this.ShowIcon = false;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInspection_FormClosing);
            this.Load += new System.EventHandler(this.frmInspection_Load);
            this.tbMenuControl.ResumeLayout(false);
            this.tbMenuControl.PerformLayout();
            this.InspectionPanel.ResumeLayout(false);
            this.InspectionPanel.PerformLayout();
            this.VehicleListPanel.ResumeLayout(false);
            this.VehicleListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicleInfo)).EndInit();
            this.tbVehicleInfo.ResumeLayout(false);
            this.tbVehicleInfo.PerformLayout();
            this.VehicleListPanel.ResumeLayout(false);
            this.VehicleListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicleInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TableLayoutPanel tbMenuControl;
        private System.Windows.Forms.Button btnHeadlights;
        private System.Windows.Forms.Button btnWhistle;
        private System.Windows.Forms.Button btnEmission;
        private System.Windows.Forms.Button btnNoise;
        private System.Windows.Forms.Button btnSideSlip;
        private System.Windows.Forms.Button btnSteerAngle;
        private System.Windows.Forms.Button btnFrontWeight;
        private System.Windows.Forms.Button btnFrontBrake;
        private System.Windows.Forms.Button btnSpeed;
        private System.Windows.Forms.Button btnHandBrake;
        private System.Windows.Forms.Button btnRearWeight;
        private System.Windows.Forms.Button btnRearBrake;
        private System.Windows.Forms.Button btnInspecProgress;
        private System.Windows.Forms.Panel InspectionPanel;
        private System.Windows.Forms.TableLayoutPanel tbVehicleInfo;
        private System.Windows.Forms.ComboBox cbFuel;
        private System.Windows.Forms.Label lbFuelTitle;
        private System.Windows.Forms.Label lbInspecDateTitle;
        private System.Windows.Forms.DateTimePicker dateInSpec;
        private System.Windows.Forms.TextBox txtVinNum;
        private System.Windows.Forms.Label lbInspectorTitle;
        private System.Windows.Forms.Label lbSerialNumTitle;
        private System.Windows.Forms.ComboBox cbInspector;
        private System.Windows.Forms.Label lbFrameNumTitle;
        private System.Windows.Forms.TextBox txtEngineNum;
        private System.Windows.Forms.Label lbTypeCarTitle;
        private System.Windows.Forms.ComboBox cbTypeCar;
        private System.Windows.Forms.TextBox txtVinShow;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnFoglights;
        private System.Windows.Forms.CheckBox cbManualMode;
        private System.Windows.Forms.CheckBox cbPos1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnResetMain;
        private System.Windows.Forms.CheckBox cbPos2;
        private System.Windows.Forms.Panel VehicleListPanel;
        private System.Windows.Forms.DataGridView dgVehicleInfo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}