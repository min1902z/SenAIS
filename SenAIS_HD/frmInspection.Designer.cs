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
            this.tbVehicleInfo = new System.Windows.Forms.TableLayoutPanel();
            this.cbFuel = new System.Windows.Forms.ComboBox();
            this.lbFuelTitle = new System.Windows.Forms.Label();
            this.lbInspecDateTitle = new System.Windows.Forms.Label();
            this.dateInSpec = new System.Windows.Forms.DateTimePicker();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.lbInspectorTitle = new System.Windows.Forms.Label();
            this.lbSerialNumTitle = new System.Windows.Forms.Label();
            this.cbInspector = new System.Windows.Forms.ComboBox();
            this.lbFrameNumTitle = new System.Windows.Forms.Label();
            this.txtFrameNum = new System.Windows.Forms.TextBox();
            this.lbTypeCarTitle = new System.Windows.Forms.Label();
            this.cbTypeCar = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHeadlights = new System.Windows.Forms.Button();
            this.btnWhistle = new System.Windows.Forms.Button();
            this.btnSideSlip = new System.Windows.Forms.Button();
            this.btnFrontBrake = new System.Windows.Forms.Button();
            this.btnHandBrake = new System.Windows.Forms.Button();
            this.btnRearBrake = new System.Windows.Forms.Button();
            this.btnSteerAngle = new System.Windows.Forms.Button();
            this.btnNoise = new System.Windows.Forms.Button();
            this.btnFrontWeight = new System.Windows.Forms.Button();
            this.btnRearWeight = new System.Windows.Forms.Button();
            this.btnSpeed = new System.Windows.Forms.Button();
            this.btnEmission = new System.Windows.Forms.Button();
            this.btnInspecProgress = new System.Windows.Forms.Button();
            this.InspectionPanel = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.tbVehicleInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.InspectionPanel.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbVehicleInfo
            // 
            this.tbVehicleInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbVehicleInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tbVehicleInfo.ColumnCount = 2;
            this.tbVehicleInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbVehicleInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tbVehicleInfo.Controls.Add(this.cbFuel, 1, 5);
            this.tbVehicleInfo.Controls.Add(this.lbFuelTitle, 0, 5);
            this.tbVehicleInfo.Controls.Add(this.lbInspecDateTitle, 0, 4);
            this.tbVehicleInfo.Controls.Add(this.dateInSpec, 1, 4);
            this.tbVehicleInfo.Controls.Add(this.txtSerialNum, 1, 0);
            this.tbVehicleInfo.Controls.Add(this.lbInspectorTitle, 0, 3);
            this.tbVehicleInfo.Controls.Add(this.lbSerialNumTitle, 0, 0);
            this.tbVehicleInfo.Controls.Add(this.cbInspector, 1, 3);
            this.tbVehicleInfo.Controls.Add(this.lbFrameNumTitle, 0, 1);
            this.tbVehicleInfo.Controls.Add(this.txtFrameNum, 1, 1);
            this.tbVehicleInfo.Controls.Add(this.lbTypeCarTitle, 0, 2);
            this.tbVehicleInfo.Controls.Add(this.cbTypeCar, 1, 2);
            this.tbVehicleInfo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVehicleInfo.Location = new System.Drawing.Point(40, 166);
            this.tbVehicleInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tbVehicleInfo.Name = "tbVehicleInfo";
            this.tbVehicleInfo.RowCount = 6;
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbVehicleInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbVehicleInfo.Size = new System.Drawing.Size(434, 346);
            this.tbVehicleInfo.TabIndex = 3;
            // 
            // cbFuel
            // 
            this.cbFuel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuel.FormattingEnabled = true;
            this.cbFuel.Items.AddRange(new object[] {
            "Xăng",
            "Dầu"});
            this.cbFuel.Location = new System.Drawing.Point(204, 289);
            this.cbFuel.Margin = new System.Windows.Forms.Padding(2);
            this.cbFuel.Name = "cbFuel";
            this.cbFuel.Size = new System.Drawing.Size(223, 37);
            this.cbFuel.TabIndex = 19;
            this.cbFuel.SelectedIndexChanged += new System.EventHandler(this.cbFuel_SelectedIndexChanged);
            // 
            // lbFuelTitle
            // 
            this.lbFuelTitle.AutoSize = true;
            this.lbFuelTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFuelTitle.Location = new System.Drawing.Point(4, 287);
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
            this.lbInspecDateTitle.Location = new System.Drawing.Point(4, 230);
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
            this.dateInSpec.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateInSpec.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInSpec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInSpec.Location = new System.Drawing.Point(205, 233);
            this.dateInSpec.Name = "dateInSpec";
            this.dateInSpec.Size = new System.Drawing.Size(222, 37);
            this.dateInSpec.TabIndex = 8;
            this.dateInSpec.Value = new System.DateTime(2025, 2, 19, 0, 0, 0, 0);
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSerialNum.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNum.ForeColor = System.Drawing.Color.IndianRed;
            this.txtSerialNum.Location = new System.Drawing.Point(204, 4);
            this.txtSerialNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(223, 37);
            this.txtSerialNum.TabIndex = 17;
            this.txtSerialNum.Text = "VIN1234";
            // 
            // lbInspectorTitle
            // 
            this.lbInspectorTitle.AutoSize = true;
            this.lbInspectorTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInspectorTitle.Location = new System.Drawing.Point(4, 173);
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
            this.cbInspector.FormattingEnabled = true;
            this.cbInspector.Location = new System.Drawing.Point(204, 175);
            this.cbInspector.Margin = new System.Windows.Forms.Padding(2);
            this.cbInspector.Name = "cbInspector";
            this.cbInspector.Size = new System.Drawing.Size(223, 37);
            this.cbInspector.TabIndex = 19;
            // 
            // lbFrameNumTitle
            // 
            this.lbFrameNumTitle.AutoSize = true;
            this.lbFrameNumTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFrameNumTitle.Location = new System.Drawing.Point(4, 59);
            this.lbFrameNumTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFrameNumTitle.Name = "lbFrameNumTitle";
            this.lbFrameNumTitle.Size = new System.Drawing.Size(95, 33);
            this.lbFrameNumTitle.TabIndex = 2;
            this.lbFrameNumTitle.Text = "Số Máy";
            // 
            // txtFrameNum
            // 
            this.txtFrameNum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtFrameNum.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrameNum.Location = new System.Drawing.Point(204, 61);
            this.txtFrameNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtFrameNum.Name = "txtFrameNum";
            this.txtFrameNum.Size = new System.Drawing.Size(223, 37);
            this.txtFrameNum.TabIndex = 15;
            // 
            // lbTypeCarTitle
            // 
            this.lbTypeCarTitle.AutoSize = true;
            this.lbTypeCarTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTypeCarTitle.Location = new System.Drawing.Point(4, 116);
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
            this.cbTypeCar.FormattingEnabled = true;
            this.cbTypeCar.Location = new System.Drawing.Point(204, 118);
            this.cbTypeCar.Margin = new System.Windows.Forms.Padding(2);
            this.cbTypeCar.Name = "cbTypeCar";
            this.cbTypeCar.Size = new System.Drawing.Size(223, 37);
            this.cbTypeCar.TabIndex = 18;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(40, 619);
            this.btnReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(125, 50);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Xem Dữ Liệu";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnHeadlights, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnWhistle, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSideSlip, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnFrontBrake, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnHandBrake, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnRearBrake, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnFrontWeight, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnRearWeight, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnSpeed, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnEmission, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnSteerAngle, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnNoise, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(111, 47);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(560, 572);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnHeadlights
            // 
            this.btnHeadlights.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnHeadlights.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeadlights.Location = new System.Drawing.Point(2, 30);
            this.btnHeadlights.Margin = new System.Windows.Forms.Padding(2);
            this.btnHeadlights.Name = "btnHeadlights";
            this.btnHeadlights.Size = new System.Drawing.Size(129, 53);
            this.btnHeadlights.TabIndex = 10;
            this.btnHeadlights.Text = "Đèn Pha-Cốt";
            this.btnHeadlights.UseVisualStyleBackColor = true;
            this.btnHeadlights.Visible = false;
            this.btnHeadlights.Click += new System.EventHandler(this.btnHeadlights_Click);
            // 
            // btnWhistle
            // 
            this.btnWhistle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnWhistle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhistle.Location = new System.Drawing.Point(188, 30);
            this.btnWhistle.Margin = new System.Windows.Forms.Padding(2);
            this.btnWhistle.Name = "btnWhistle";
            this.btnWhistle.Size = new System.Drawing.Size(129, 53);
            this.btnWhistle.TabIndex = 11;
            this.btnWhistle.Text = "Còi";
            this.btnWhistle.UseVisualStyleBackColor = true;
            this.btnWhistle.Visible = false;
            this.btnWhistle.Click += new System.EventHandler(this.btnWhistle_Click);
            // 
            // btnSideSlip
            // 
            this.btnSideSlip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSideSlip.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSideSlip.Location = new System.Drawing.Point(2, 144);
            this.btnSideSlip.Margin = new System.Windows.Forms.Padding(2);
            this.btnSideSlip.Name = "btnSideSlip";
            this.btnSideSlip.Size = new System.Drawing.Size(129, 53);
            this.btnSideSlip.TabIndex = 5;
            this.btnSideSlip.Text = "Trượt Ngang";
            this.btnSideSlip.UseVisualStyleBackColor = true;
            this.btnSideSlip.Click += new System.EventHandler(this.btnSideSlip_Click);
            // 
            // btnFrontBrake
            // 
            this.btnFrontBrake.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFrontBrake.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrontBrake.Location = new System.Drawing.Point(2, 258);
            this.btnFrontBrake.Margin = new System.Windows.Forms.Padding(2);
            this.btnFrontBrake.Name = "btnFrontBrake";
            this.btnFrontBrake.Size = new System.Drawing.Size(129, 53);
            this.btnFrontBrake.TabIndex = 8;
            this.btnFrontBrake.Text = "Phanh Trước";
            this.btnFrontBrake.UseVisualStyleBackColor = true;
            this.btnFrontBrake.Click += new System.EventHandler(this.btnFrontBrake_Click);
            // 
            // btnHandBrake
            // 
            this.btnHandBrake.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnHandBrake.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHandBrake.Location = new System.Drawing.Point(374, 258);
            this.btnHandBrake.Margin = new System.Windows.Forms.Padding(2);
            this.btnHandBrake.Name = "btnHandBrake";
            this.btnHandBrake.Size = new System.Drawing.Size(129, 53);
            this.btnHandBrake.TabIndex = 17;
            this.btnHandBrake.Text = "Phanh Tay";
            this.btnHandBrake.UseVisualStyleBackColor = true;
            this.btnHandBrake.Click += new System.EventHandler(this.btnHandBrake_Click);
            // 
            // btnRearBrake
            // 
            this.btnRearBrake.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRearBrake.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRearBrake.Location = new System.Drawing.Point(188, 258);
            this.btnRearBrake.Margin = new System.Windows.Forms.Padding(2);
            this.btnRearBrake.Name = "btnRearBrake";
            this.btnRearBrake.Size = new System.Drawing.Size(129, 53);
            this.btnRearBrake.TabIndex = 16;
            this.btnRearBrake.Text = "Phanh Sau";
            this.btnRearBrake.UseVisualStyleBackColor = true;
            this.btnRearBrake.Click += new System.EventHandler(this.btnRearBrake_Click);
            // 
            // btnSteerAngle
            // 
            this.btnSteerAngle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSteerAngle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerAngle.Location = new System.Drawing.Point(188, 144);
            this.btnSteerAngle.Margin = new System.Windows.Forms.Padding(2);
            this.btnSteerAngle.Name = "btnSteerAngle";
            this.btnSteerAngle.Size = new System.Drawing.Size(129, 53);
            this.btnSteerAngle.TabIndex = 18;
            this.btnSteerAngle.Text = "Góc Lái";
            this.btnSteerAngle.UseVisualStyleBackColor = true;
            this.btnSteerAngle.Visible = false;
            this.btnSteerAngle.Click += new System.EventHandler(this.btnSteerAngle_Click);
            // 
            // btnNoise
            // 
            this.btnNoise.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNoise.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoise.Location = new System.Drawing.Point(374, 30);
            this.btnNoise.Margin = new System.Windows.Forms.Padding(2);
            this.btnNoise.Name = "btnNoise";
            this.btnNoise.Size = new System.Drawing.Size(129, 53);
            this.btnNoise.TabIndex = 6;
            this.btnNoise.Text = "Độ Ồn";
            this.btnNoise.UseVisualStyleBackColor = true;
            this.btnNoise.Visible = false;
            this.btnNoise.Click += new System.EventHandler(this.btnNoise_Click);
            // 
            // btnFrontWeight
            // 
            this.btnFrontWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFrontWeight.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrontWeight.Location = new System.Drawing.Point(2, 487);
            this.btnFrontWeight.Margin = new System.Windows.Forms.Padding(2);
            this.btnFrontWeight.Name = "btnFrontWeight";
            this.btnFrontWeight.Size = new System.Drawing.Size(144, 53);
            this.btnFrontWeight.TabIndex = 7;
            this.btnFrontWeight.Text = "Trọng Lượng T";
            this.btnFrontWeight.UseVisualStyleBackColor = true;
            this.btnFrontWeight.Visible = false;
            this.btnFrontWeight.Click += new System.EventHandler(this.btnFrontWeight_Click);
            // 
            // btnRearWeight
            // 
            this.btnRearWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRearWeight.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRearWeight.Location = new System.Drawing.Point(188, 487);
            this.btnRearWeight.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSpeed.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeed.Location = new System.Drawing.Point(2, 372);
            this.btnSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpeed.Name = "btnSpeed";
            this.btnSpeed.Size = new System.Drawing.Size(129, 53);
            this.btnSpeed.TabIndex = 4;
            this.btnSpeed.Text = "Tốc Độ";
            this.btnSpeed.UseVisualStyleBackColor = true;
            this.btnSpeed.Click += new System.EventHandler(this.btnSpeed_Click);
            // 
            // btnEmission
            // 
            this.btnEmission.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEmission.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmission.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEmission.Location = new System.Drawing.Point(188, 372);
            this.btnEmission.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmission.Name = "btnEmission";
            this.btnEmission.Size = new System.Drawing.Size(125, 53);
            this.btnEmission.TabIndex = 12;
            this.btnEmission.Text = "Khí Xả Xăng";
            this.btnEmission.UseVisualStyleBackColor = true;
            this.btnEmission.Click += new System.EventHandler(this.btnEmission_Click);
            // 
            // btnInspecProgress
            // 
            this.btnInspecProgress.AutoSize = true;
            this.btnInspecProgress.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnInspecProgress.FlatAppearance.BorderSize = 2;
            this.btnInspecProgress.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInspecProgress.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnInspecProgress.Location = new System.Drawing.Point(40, 11);
            this.btnInspecProgress.Margin = new System.Windows.Forms.Padding(2);
            this.btnInspecProgress.Name = "btnInspecProgress";
            this.btnInspecProgress.Size = new System.Drawing.Size(233, 60);
            this.btnInspecProgress.TabIndex = 1;
            this.btnInspecProgress.Text = "Nhập Thông Tin Xe";
            this.btnInspecProgress.UseVisualStyleBackColor = true;
            this.btnInspecProgress.Click += new System.EventHandler(this.btnInspecProgress_Click);
            // 
            // InspectionPanel
            // 
            this.InspectionPanel.AutoScroll = true;
            this.InspectionPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.InspectionPanel.Controls.Add(this.panelButton);
            this.InspectionPanel.Controls.Add(this.btnInspecProgress);
            this.InspectionPanel.Controls.Add(this.btnReport);
            this.InspectionPanel.Controls.Add(this.tbVehicleInfo);
            this.InspectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InspectionPanel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InspectionPanel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.InspectionPanel.Location = new System.Drawing.Point(0, 0);
            this.InspectionPanel.Margin = new System.Windows.Forms.Padding(2);
            this.InspectionPanel.Name = "InspectionPanel";
            this.InspectionPanel.Size = new System.Drawing.Size(1200, 680);
            this.InspectionPanel.TabIndex = 1;
            // 
            // panelButton
            // 
            this.panelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelButton.AutoScroll = true;
            this.panelButton.Controls.Add(this.tableLayoutPanel2);
            this.panelButton.Location = new System.Drawing.Point(494, 0);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(706, 680);
            this.panelButton.TabIndex = 7;
            // 
            // frmInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1200, 680);
            this.Controls.Add(this.InspectionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInspection";
            this.Text = "Inspection";
            this.tbVehicleInfo.ResumeLayout(false);
            this.tbVehicleInfo.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.InspectionPanel.ResumeLayout(false);
            this.InspectionPanel.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbVehicleInfo;
        private System.Windows.Forms.ComboBox cbFuel;
        private System.Windows.Forms.Label lbFuelTitle;
        private System.Windows.Forms.ComboBox cbInspector;
        private System.Windows.Forms.TextBox txtFrameNum;
        private System.Windows.Forms.Label lbTypeCarTitle;
        private System.Windows.Forms.Label lbFrameNumTitle;
        private System.Windows.Forms.Label lbInspectorTitle;
        private System.Windows.Forms.ComboBox cbTypeCar;
        private System.Windows.Forms.Label lbSerialNumTitle;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.Label lbInspecDateTitle;
        private System.Windows.Forms.DateTimePicker dateInSpec;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
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
        private System.Windows.Forms.Panel panelButton;
    }
}