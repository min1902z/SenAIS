﻿namespace SenAIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInspection));
            this.tbVehicleInfo = new System.Windows.Forms.TableLayoutPanel();
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
            this.btnReport = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHeadlights = new System.Windows.Forms.Button();
            this.btnWhistle = new System.Windows.Forms.Button();
            this.btnFrontBrake = new System.Windows.Forms.Button();
            this.btnHandBrake = new System.Windows.Forms.Button();
            this.btnRearBrake = new System.Windows.Forms.Button();
            this.btnSpeed = new System.Windows.Forms.Button();
            this.btnEmission = new System.Windows.Forms.Button();
            this.btnNoise = new System.Windows.Forms.Button();
            this.btnFrontWeight = new System.Windows.Forms.Button();
            this.btnSideSlip = new System.Windows.Forms.Button();
            this.btnSteerAngle = new System.Windows.Forms.Button();
            this.btnSpeedMoving = new System.Windows.Forms.Button();
            this.btnInspecProgress = new System.Windows.Forms.Button();
            this.InspectionPanel = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnResetMain = new System.Windows.Forms.Button();
            this.panelButton = new System.Windows.Forms.Panel();
            this.txtVinShow = new System.Windows.Forms.TextBox();
            this.tbVehicleInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.InspectionPanel.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbVehicleInfo
            // 
            resources.ApplyResources(this.tbVehicleInfo, "tbVehicleInfo");
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
            this.tbVehicleInfo.Name = "tbVehicleInfo";
            // 
            // cbFuel
            // 
            this.cbFuel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuel.FormattingEnabled = true;
            this.cbFuel.Items.AddRange(new object[] {
            resources.GetString("cbFuel.Items"),
            resources.GetString("cbFuel.Items1")});
            resources.ApplyResources(this.cbFuel, "cbFuel");
            this.cbFuel.Name = "cbFuel";
            this.cbFuel.SelectedIndexChanged += new System.EventHandler(this.cbFuel_SelectedIndexChanged);
            // 
            // lbFuelTitle
            // 
            resources.ApplyResources(this.lbFuelTitle, "lbFuelTitle");
            this.lbFuelTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbFuelTitle.Name = "lbFuelTitle";
            // 
            // lbInspecDateTitle
            // 
            resources.ApplyResources(this.lbInspecDateTitle, "lbInspecDateTitle");
            this.lbInspecDateTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbInspecDateTitle.Name = "lbInspecDateTitle";
            // 
            // dateInSpec
            // 
            this.dateInSpec.CalendarForeColor = System.Drawing.SystemColors.HotTrack;
            this.dateInSpec.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption;
            this.dateInSpec.CalendarTitleForeColor = System.Drawing.SystemColors.HotTrack;
            this.dateInSpec.CalendarTrailingForeColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.dateInSpec, "dateInSpec");
            this.dateInSpec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInSpec.Name = "dateInSpec";
            this.dateInSpec.Value = new System.DateTime(2025, 2, 19, 0, 0, 0, 0);
            // 
            // txtVinNum
            // 
            this.txtVinNum.BackColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.txtVinNum, "txtVinNum");
            this.txtVinNum.ForeColor = System.Drawing.Color.Red;
            this.txtVinNum.Name = "txtVinNum";
            this.txtVinNum.TextChanged += new System.EventHandler(this.txtVinNum_TextChanged);
            this.txtVinNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVinNum_KeyDown);
            // 
            // lbInspectorTitle
            // 
            resources.ApplyResources(this.lbInspectorTitle, "lbInspectorTitle");
            this.lbInspectorTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbInspectorTitle.Name = "lbInspectorTitle";
            // 
            // lbSerialNumTitle
            // 
            resources.ApplyResources(this.lbSerialNumTitle, "lbSerialNumTitle");
            this.lbSerialNumTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbSerialNumTitle.Name = "lbSerialNumTitle";
            // 
            // cbInspector
            // 
            this.cbInspector.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbInspector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInspector.FormattingEnabled = true;
            resources.ApplyResources(this.cbInspector, "cbInspector");
            this.cbInspector.Name = "cbInspector";
            // 
            // lbFrameNumTitle
            // 
            resources.ApplyResources(this.lbFrameNumTitle, "lbFrameNumTitle");
            this.lbFrameNumTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbFrameNumTitle.Name = "lbFrameNumTitle";
            // 
            // txtEngineNum
            // 
            this.txtEngineNum.BackColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.txtEngineNum, "txtEngineNum");
            this.txtEngineNum.Name = "txtEngineNum";
            // 
            // lbTypeCarTitle
            // 
            resources.ApplyResources(this.lbTypeCarTitle, "lbTypeCarTitle");
            this.lbTypeCarTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbTypeCarTitle.Name = "lbTypeCarTitle";
            // 
            // cbTypeCar
            // 
            this.cbTypeCar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbTypeCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeCar.DropDownWidth = 500;
            this.cbTypeCar.FormattingEnabled = true;
            resources.ApplyResources(this.cbTypeCar, "cbTypeCar");
            this.cbTypeCar.Name = "cbTypeCar";
            // 
            // btnReport
            // 
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.ForeColor = System.Drawing.Color.Blue;
            this.btnReport.Name = "btnReport";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btnHeadlights, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnWhistle, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnFrontBrake, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnHandBrake, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnRearBrake, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnSpeed, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnEmission, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnNoise, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnFrontWeight, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSideSlip, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSteerAngle, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnSpeedMoving, 2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // btnHeadlights
            // 
            resources.ApplyResources(this.btnHeadlights, "btnHeadlights");
            this.btnHeadlights.ForeColor = System.Drawing.Color.Blue;
            this.btnHeadlights.Name = "btnHeadlights";
            this.btnHeadlights.UseVisualStyleBackColor = true;
            this.btnHeadlights.Click += new System.EventHandler(this.btnHeadlights_Click);
            // 
            // btnWhistle
            // 
            resources.ApplyResources(this.btnWhistle, "btnWhistle");
            this.btnWhistle.ForeColor = System.Drawing.Color.Blue;
            this.btnWhistle.Name = "btnWhistle";
            this.btnWhistle.UseVisualStyleBackColor = true;
            this.btnWhistle.Click += new System.EventHandler(this.btnWhistle_Click);
            // 
            // btnFrontBrake
            // 
            resources.ApplyResources(this.btnFrontBrake, "btnFrontBrake");
            this.btnFrontBrake.ForeColor = System.Drawing.Color.Blue;
            this.btnFrontBrake.Name = "btnFrontBrake";
            this.btnFrontBrake.UseVisualStyleBackColor = true;
            this.btnFrontBrake.Click += new System.EventHandler(this.btnFrontBrake_Click);
            // 
            // btnHandBrake
            // 
            resources.ApplyResources(this.btnHandBrake, "btnHandBrake");
            this.btnHandBrake.ForeColor = System.Drawing.Color.Blue;
            this.btnHandBrake.Name = "btnHandBrake";
            this.btnHandBrake.UseVisualStyleBackColor = true;
            this.btnHandBrake.Click += new System.EventHandler(this.btnHandBrake_Click);
            // 
            // btnRearBrake
            // 
            resources.ApplyResources(this.btnRearBrake, "btnRearBrake");
            this.btnRearBrake.ForeColor = System.Drawing.Color.Blue;
            this.btnRearBrake.Name = "btnRearBrake";
            this.btnRearBrake.UseVisualStyleBackColor = true;
            this.btnRearBrake.Click += new System.EventHandler(this.btnRearBrake_Click);
            // 
            // btnSpeed
            // 
            resources.ApplyResources(this.btnSpeed, "btnSpeed");
            this.btnSpeed.ForeColor = System.Drawing.Color.Blue;
            this.btnSpeed.Name = "btnSpeed";
            this.btnSpeed.UseVisualStyleBackColor = true;
            this.btnSpeed.Click += new System.EventHandler(this.btnSpeed_Click);
            // 
            // btnEmission
            // 
            resources.ApplyResources(this.btnEmission, "btnEmission");
            this.btnEmission.ForeColor = System.Drawing.Color.Blue;
            this.btnEmission.Name = "btnEmission";
            this.btnEmission.UseVisualStyleBackColor = true;
            this.btnEmission.Click += new System.EventHandler(this.btnEmission_Click);
            // 
            // btnNoise
            // 
            resources.ApplyResources(this.btnNoise, "btnNoise");
            this.btnNoise.ForeColor = System.Drawing.Color.Blue;
            this.btnNoise.Name = "btnNoise";
            this.btnNoise.UseVisualStyleBackColor = true;
            this.btnNoise.Click += new System.EventHandler(this.btnNoise_Click);
            // 
            // btnFrontWeight
            // 
            resources.ApplyResources(this.btnFrontWeight, "btnFrontWeight");
            this.btnFrontWeight.ForeColor = System.Drawing.Color.Blue;
            this.btnFrontWeight.Name = "btnFrontWeight";
            this.btnFrontWeight.UseVisualStyleBackColor = true;
            this.btnFrontWeight.Click += new System.EventHandler(this.btnFrontWeight_Click);
            // 
            // btnSideSlip
            // 
            resources.ApplyResources(this.btnSideSlip, "btnSideSlip");
            this.btnSideSlip.ForeColor = System.Drawing.Color.Blue;
            this.btnSideSlip.Name = "btnSideSlip";
            this.btnSideSlip.UseVisualStyleBackColor = true;
            this.btnSideSlip.Click += new System.EventHandler(this.btnSideSlip_Click);
            // 
            // btnSteerAngle
            // 
            resources.ApplyResources(this.btnSteerAngle, "btnSteerAngle");
            this.btnSteerAngle.ForeColor = System.Drawing.Color.Blue;
            this.btnSteerAngle.Name = "btnSteerAngle";
            this.btnSteerAngle.UseVisualStyleBackColor = true;
            this.btnSteerAngle.Click += new System.EventHandler(this.btnSteerAngle_Click);
            // 
            // btnSpeedMoving
            // 
            resources.ApplyResources(this.btnSpeedMoving, "btnSpeedMoving");
            this.btnSpeedMoving.ForeColor = System.Drawing.Color.Red;
            this.btnSpeedMoving.Name = "btnSpeedMoving";
            this.btnSpeedMoving.UseVisualStyleBackColor = true;
            this.btnSpeedMoving.Click += new System.EventHandler(this.btnSpeedMoving_Click);
            // 
            // btnInspecProgress
            // 
            resources.ApplyResources(this.btnInspecProgress, "btnInspecProgress");
            this.btnInspecProgress.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnInspecProgress.FlatAppearance.BorderSize = 2;
            this.btnInspecProgress.ForeColor = System.Drawing.Color.Blue;
            this.btnInspecProgress.Name = "btnInspecProgress";
            this.btnInspecProgress.UseVisualStyleBackColor = true;
            this.btnInspecProgress.Click += new System.EventHandler(this.btnInspecProgress_Click);
            // 
            // InspectionPanel
            // 
            resources.ApplyResources(this.InspectionPanel, "InspectionPanel");
            this.InspectionPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.InspectionPanel.Controls.Add(this.btnExit);
            this.InspectionPanel.Controls.Add(this.btnResetMain);
            this.InspectionPanel.Controls.Add(this.panelButton);
            this.InspectionPanel.Controls.Add(this.btnInspecProgress);
            this.InspectionPanel.Controls.Add(this.btnReport);
            this.InspectionPanel.Controls.Add(this.tbVehicleInfo);
            this.InspectionPanel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.InspectionPanel.Name = "InspectionPanel";
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.ForeColor = System.Drawing.Color.Blue;
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnResetMain
            // 
            resources.ApplyResources(this.btnResetMain, "btnResetMain");
            this.btnResetMain.ForeColor = System.Drawing.Color.Blue;
            this.btnResetMain.Name = "btnResetMain";
            this.btnResetMain.UseVisualStyleBackColor = true;
            this.btnResetMain.Click += new System.EventHandler(this.btnResetMain_Click);
            // 
            // panelButton
            // 
            resources.ApplyResources(this.panelButton, "panelButton");
            this.panelButton.Controls.Add(this.txtVinShow);
            this.panelButton.Controls.Add(this.tableLayoutPanel2);
            this.panelButton.Name = "panelButton";
            // 
            // txtVinShow
            // 
            resources.ApplyResources(this.txtVinShow, "txtVinShow");
            this.txtVinShow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtVinShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVinShow.ForeColor = System.Drawing.Color.Red;
            this.txtVinShow.Name = "txtVinShow";
            this.txtVinShow.ReadOnly = true;
            // 
            // frmInspection
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.InspectionPanel);
            this.MinimizeBox = false;
            this.Name = "frmInspection";
            this.ShowIcon = false;
            this.tbVehicleInfo.ResumeLayout(false);
            this.tbVehicleInfo.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.InspectionPanel.ResumeLayout(false);
            this.InspectionPanel.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbVehicleInfo;
        private System.Windows.Forms.ComboBox cbFuel;
        private System.Windows.Forms.Label lbFuelTitle;
        private System.Windows.Forms.ComboBox cbInspector;
        private System.Windows.Forms.TextBox txtEngineNum;
        private System.Windows.Forms.Label lbTypeCarTitle;
        private System.Windows.Forms.Label lbFrameNumTitle;
        private System.Windows.Forms.Label lbInspectorTitle;
        private System.Windows.Forms.ComboBox cbTypeCar;
        private System.Windows.Forms.Label lbSerialNumTitle;
        private System.Windows.Forms.TextBox txtVinNum;
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
        private System.Windows.Forms.Button btnRearBrake;
        private System.Windows.Forms.Button btnInspecProgress;
        private System.Windows.Forms.Panel InspectionPanel;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.TextBox txtVinShow;
        private System.Windows.Forms.Button btnSpeedMoving;
        private System.Windows.Forms.Button btnResetMain;
        private System.Windows.Forms.Button btnExit;
    }
}