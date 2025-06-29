﻿namespace SenAIS
{
    partial class SenAIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SenAIS));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.TSHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDangKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSTruyCapAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMMSConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.TSTruyXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVehicleStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInspector = new System.Windows.Forms.ToolStripMenuItem();
            this.điềuChỉnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCalibration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLWeightCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRWeightCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSpeedCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSideSlipCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBrakeCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLBrakeCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRBrakeCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSteerAngleCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLeftSteerCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRightSteerCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSpeedAxis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLeftAxisCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRightAxisCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSpeedMovingCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.hiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFront_LBrake = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFront_RBrake = new System.Windows.Forms.ToolStripMenuItem();
            this.TSHoTro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSwitchMainUI = new System.Windows.Forms.ToolStripMenuItem();
            this.TSAuboutMe = new System.Windows.Forms.ToolStripMenuItem();
            this.TSReset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBody = new System.Windows.Forms.Panel();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.AutoSize = false;
            this.msMain.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSHeThong,
            this.TSDuLieu,
            this.điềuChỉnhToolStripMenuItem,
            this.TSHoTro});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.msMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.msMain.Size = new System.Drawing.Size(886, 27);
            this.msMain.TabIndex = 6;
            this.msMain.Text = "menuStrip1";
            // 
            // TSHeThong
            // 
            this.TSHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDangKiem,
            this.TSTruyCapAdmin,
            this.tsMMSConfig});
            this.TSHeThong.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSHeThong.Name = "TSHeThong";
            this.TSHeThong.Size = new System.Drawing.Size(83, 23);
            this.TSHeThong.Text = "Hệ Thống";
            // 
            // TSDangKiem
            // 
            this.TSDangKiem.Name = "TSDangKiem";
            this.TSDangKiem.Size = new System.Drawing.Size(200, 24);
            this.TSDangKiem.Text = "Kiểm Tra Xe";
            this.TSDangKiem.Click += new System.EventHandler(this.TSDangKiem_Click);
            // 
            // TSTruyCapAdmin
            // 
            this.TSTruyCapAdmin.Name = "TSTruyCapAdmin";
            this.TSTruyCapAdmin.Size = new System.Drawing.Size(200, 24);
            this.TSTruyCapAdmin.Text = "Truy Cập Hệ Thống";
            this.TSTruyCapAdmin.Click += new System.EventHandler(this.TSTruyCapAdmin_Click);
            // 
            // tsMMSConfig
            // 
            this.tsMMSConfig.Name = "tsMMSConfig";
            this.tsMMSConfig.Size = new System.Drawing.Size(200, 24);
            this.tsMMSConfig.Text = "Tùy Chỉnh MMS";
            this.tsMMSConfig.Click += new System.EventHandler(this.tsMMSConfig_Click);
            // 
            // TSDuLieu
            // 
            this.TSDuLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSTruyXuat,
            this.tsVehicleStandard,
            this.tsInspector});
            this.TSDuLieu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSDuLieu.Name = "TSDuLieu";
            this.TSDuLieu.Size = new System.Drawing.Size(72, 23);
            this.TSDuLieu.Text = "Dữ Liệu";
            this.TSDuLieu.Click += new System.EventHandler(this.TSDuLieu_Click);
            // 
            // TSTruyXuat
            // 
            this.TSTruyXuat.Name = "TSTruyXuat";
            this.TSTruyXuat.Size = new System.Drawing.Size(251, 24);
            this.TSTruyXuat.Text = "Truy Xuất Dữ Liệu";
            this.TSTruyXuat.Click += new System.EventHandler(this.TSTruyXuat_Click);
            // 
            // tsVehicleStandard
            // 
            this.tsVehicleStandard.Name = "tsVehicleStandard";
            this.tsVehicleStandard.Size = new System.Drawing.Size(251, 24);
            this.tsVehicleStandard.Text = "Tiêu Chuẩn Chất Lượng Xe";
            this.tsVehicleStandard.Click += new System.EventHandler(this.tsVehicleStandard_Click);
            // 
            // tsInspector
            // 
            this.tsInspector.Name = "tsInspector";
            this.tsInspector.Size = new System.Drawing.Size(251, 24);
            this.tsInspector.Text = "Người Kiểm Tra";
            this.tsInspector.Click += new System.EventHandler(this.tsInspector_Click);
            // 
            // điềuChỉnhToolStripMenuItem
            // 
            this.điềuChỉnhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCalibration,
            this.tsSpeedCalib,
            this.tsSideSlipCalib,
            this.tsBrakeCalib,
            this.tsSteerAngleCalib,
            this.tsSpeedAxis,
            this.tsSpeedMovingCalib,
            this.hiToolStripMenuItem});
            this.điềuChỉnhToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.điềuChỉnhToolStripMenuItem.Name = "điềuChỉnhToolStripMenuItem";
            this.điềuChỉnhToolStripMenuItem.Size = new System.Drawing.Size(103, 23);
            this.điềuChỉnhToolStripMenuItem.Text = "Chỉnh Chuẩn";
            // 
            // tsCalibration
            // 
            this.tsCalibration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLWeightCalib,
            this.tsRWeightCalib});
            this.tsCalibration.Name = "tsCalibration";
            this.tsCalibration.Size = new System.Drawing.Size(266, 24);
            this.tsCalibration.Text = "Hiệu Chỉnh Trọng Lượng";
            this.tsCalibration.Visible = false;
            // 
            // tsLWeightCalib
            // 
            this.tsLWeightCalib.Name = "tsLWeightCalib";
            this.tsLWeightCalib.Size = new System.Drawing.Size(192, 24);
            this.tsLWeightCalib.Text = "Trọng Lượng Trái";
            this.tsLWeightCalib.Click += new System.EventHandler(this.tsLWeightCalib_Click);
            // 
            // tsRWeightCalib
            // 
            this.tsRWeightCalib.Name = "tsRWeightCalib";
            this.tsRWeightCalib.Size = new System.Drawing.Size(192, 24);
            this.tsRWeightCalib.Text = "Trọng Lượng Phải";
            this.tsRWeightCalib.Click += new System.EventHandler(this.tsRWeightCalib_Click);
            // 
            // tsSpeedCalib
            // 
            this.tsSpeedCalib.Name = "tsSpeedCalib";
            this.tsSpeedCalib.Size = new System.Drawing.Size(266, 24);
            this.tsSpeedCalib.Text = "Hiệu Chỉnh Tốc Độ";
            this.tsSpeedCalib.Click += new System.EventHandler(this.tsSpeedCalib_Click);
            // 
            // tsSideSlipCalib
            // 
            this.tsSideSlipCalib.Name = "tsSideSlipCalib";
            this.tsSideSlipCalib.Size = new System.Drawing.Size(266, 24);
            this.tsSideSlipCalib.Text = "Hiệu Chỉnh Trượt Ngang";
            this.tsSideSlipCalib.Click += new System.EventHandler(this.tsSideSlipCalib_Click);
            // 
            // tsBrakeCalib
            // 
            this.tsBrakeCalib.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLBrakeCalib,
            this.tsRBrakeCalib});
            this.tsBrakeCalib.Name = "tsBrakeCalib";
            this.tsBrakeCalib.Size = new System.Drawing.Size(266, 24);
            this.tsBrakeCalib.Text = "Hiệu Chỉnh Trục Phanh Sau";
            // 
            // tsLBrakeCalib
            // 
            this.tsLBrakeCalib.Name = "tsLBrakeCalib";
            this.tsLBrakeCalib.Size = new System.Drawing.Size(208, 24);
            this.tsLBrakeCalib.Text = "Trục Phanh Sau Trái";
            this.tsLBrakeCalib.Click += new System.EventHandler(this.tsLBrakeCalib_Click);
            // 
            // tsRBrakeCalib
            // 
            this.tsRBrakeCalib.Name = "tsRBrakeCalib";
            this.tsRBrakeCalib.Size = new System.Drawing.Size(208, 24);
            this.tsRBrakeCalib.Text = "Trục Phanh Sau Phải";
            this.tsRBrakeCalib.Click += new System.EventHandler(this.tsRBrakeCalib_Click);
            // 
            // tsSteerAngleCalib
            // 
            this.tsSteerAngleCalib.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLeftSteerCalib,
            this.tsRightSteerCalib});
            this.tsSteerAngleCalib.Name = "tsSteerAngleCalib";
            this.tsSteerAngleCalib.Size = new System.Drawing.Size(266, 24);
            this.tsSteerAngleCalib.Text = "Hiệu Chỉnh Góc Lái";
            this.tsSteerAngleCalib.Visible = false;
            // 
            // tsLeftSteerCalib
            // 
            this.tsLeftSteerCalib.Name = "tsLeftSteerCalib";
            this.tsLeftSteerCalib.Size = new System.Drawing.Size(158, 24);
            this.tsLeftSteerCalib.Text = "Góc Lái Trái";
            this.tsLeftSteerCalib.Click += new System.EventHandler(this.tsLeftSteerCalib_Click);
            // 
            // tsRightSteerCalib
            // 
            this.tsRightSteerCalib.Name = "tsRightSteerCalib";
            this.tsRightSteerCalib.Size = new System.Drawing.Size(158, 24);
            this.tsRightSteerCalib.Text = "Góc Lái Phải";
            this.tsRightSteerCalib.Click += new System.EventHandler(this.tsRightSteerCalib_Click);
            // 
            // tsSpeedAxis
            // 
            this.tsSpeedAxis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLeftAxisCalib,
            this.tsRightAxisCalib});
            this.tsSpeedAxis.Name = "tsSpeedAxis";
            this.tsSpeedAxis.Size = new System.Drawing.Size(266, 24);
            this.tsSpeedAxis.Text = "Hiệu Chỉnh Trục Tốc Độ";
            this.tsSpeedAxis.Visible = false;
            // 
            // tsLeftAxisCalib
            // 
            this.tsLeftAxisCalib.Name = "tsLeftAxisCalib";
            this.tsLeftAxisCalib.Size = new System.Drawing.Size(212, 24);
            this.tsLeftAxisCalib.Text = "Hiệu Chỉnh Trục Trái";
            this.tsLeftAxisCalib.Click += new System.EventHandler(this.tsLeftAxisCalib_Click);
            // 
            // tsRightAxisCalib
            // 
            this.tsRightAxisCalib.Name = "tsRightAxisCalib";
            this.tsRightAxisCalib.Size = new System.Drawing.Size(212, 24);
            this.tsRightAxisCalib.Text = "Hiệu Chỉnh Trục Phải";
            this.tsRightAxisCalib.Click += new System.EventHandler(this.tsRightAxisCalib_Click);
            // 
            // tsSpeedMovingCalib
            // 
            this.tsSpeedMovingCalib.Name = "tsSpeedMovingCalib";
            this.tsSpeedMovingCalib.Size = new System.Drawing.Size(266, 24);
            this.tsSpeedMovingCalib.Text = "Điều Chỉnh Trục Sau";
            this.tsSpeedMovingCalib.Visible = false;
            this.tsSpeedMovingCalib.Click += new System.EventHandler(this.tsSpeedMovingCalib_Click);
            // 
            // hiToolStripMenuItem
            // 
            this.hiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFront_LBrake,
            this.tsFront_RBrake});
            this.hiToolStripMenuItem.Name = "hiToolStripMenuItem";
            this.hiToolStripMenuItem.Size = new System.Drawing.Size(266, 24);
            this.hiToolStripMenuItem.Text = "Hiệu Chỉnh Trục Phanh Trước";
            // 
            // tsFront_LBrake
            // 
            this.tsFront_LBrake.Name = "tsFront_LBrake";
            this.tsFront_LBrake.Size = new System.Drawing.Size(223, 24);
            this.tsFront_LBrake.Text = "Trục Phanh Trước Trái";
            this.tsFront_LBrake.Click += new System.EventHandler(this.tsFront_LBrake_Click);
            // 
            // tsFront_RBrake
            // 
            this.tsFront_RBrake.Name = "tsFront_RBrake";
            this.tsFront_RBrake.Size = new System.Drawing.Size(223, 24);
            this.tsFront_RBrake.Text = "Trục Phanh Trước Phải";
            this.tsFront_RBrake.Click += new System.EventHandler(this.tsFront_RBrake_Click);
            // 
            // TSHoTro
            // 
            this.TSHoTro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSwitchMainUI,
            this.TSAuboutMe,
            this.TSReset,
            this.tsExit});
            this.TSHoTro.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSHoTro.Name = "TSHoTro";
            this.TSHoTro.Size = new System.Drawing.Size(64, 23);
            this.TSHoTro.Text = "Hỗ Trợ";
            this.TSHoTro.Click += new System.EventHandler(this.TSHoTro_Click);
            // 
            // tsSwitchMainUI
            // 
            this.tsSwitchMainUI.Name = "tsSwitchMainUI";
            this.tsSwitchMainUI.Size = new System.Drawing.Size(229, 24);
            this.tsSwitchMainUI.Text = "Đổi Bảng Danh Sách Xe";
            this.tsSwitchMainUI.Click += new System.EventHandler(this.tsSwitchMainUI_Click);
            // 
            // TSAuboutMe
            // 
            this.TSAuboutMe.Name = "TSAuboutMe";
            this.TSAuboutMe.Size = new System.Drawing.Size(229, 24);
            this.TSAuboutMe.Text = "Giới Thiệu";
            this.TSAuboutMe.Click += new System.EventHandler(this.TSAuboutMe_Click);
            // 
            // TSReset
            // 
            this.TSReset.Name = "TSReset";
            this.TSReset.Size = new System.Drawing.Size(229, 24);
            this.TSReset.Text = "Khởi Động Lại";
            this.TSReset.Click += new System.EventHandler(this.TSReset_Click);
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(229, 24);
            this.tsExit.Text = "Thoát ";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // panelBody
            // 
            this.panelBody.AutoScroll = true;
            this.panelBody.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 27);
            this.panelBody.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(886, 487);
            this.panelBody.TabIndex = 7;
            // 
            // SenAIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(886, 514);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SenAIS";
            this.Text = "SenAIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SenAIS_FormClosing);
            this.Load += new System.EventHandler(this.SenAIS_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem TSHeThong;
        private System.Windows.Forms.ToolStripMenuItem TSDangKiem;
        private System.Windows.Forms.ToolStripMenuItem TSDuLieu;
        private System.Windows.Forms.ToolStripMenuItem TSTruyXuat;
        private System.Windows.Forms.ToolStripMenuItem TSHoTro;
        private System.Windows.Forms.ToolStripMenuItem TSAuboutMe;
        private System.Windows.Forms.ToolStripMenuItem TSReset;
        public System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.ToolStripMenuItem điềuChỉnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsCalibration;
        private System.Windows.Forms.ToolStripMenuItem tsLWeightCalib;
        private System.Windows.Forms.ToolStripMenuItem tsRWeightCalib;
        private System.Windows.Forms.ToolStripMenuItem tsSpeedCalib;
        private System.Windows.Forms.ToolStripMenuItem tsSideSlipCalib;
        private System.Windows.Forms.ToolStripMenuItem tsBrakeCalib;
        private System.Windows.Forms.ToolStripMenuItem tsLBrakeCalib;
        private System.Windows.Forms.ToolStripMenuItem tsRBrakeCalib;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem tsVehicleStandard;
        private System.Windows.Forms.ToolStripMenuItem tsInspector;
        private System.Windows.Forms.ToolStripMenuItem TSTruyCapAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsSteerAngleCalib;
        private System.Windows.Forms.ToolStripMenuItem tsLeftSteerCalib;
        private System.Windows.Forms.ToolStripMenuItem tsRightSteerCalib;
        private System.Windows.Forms.ToolStripMenuItem tsMMSConfig;
        private System.Windows.Forms.ToolStripMenuItem tsSpeedMovingCalib;
        private System.Windows.Forms.ToolStripMenuItem tsSpeedAxis;
        private System.Windows.Forms.ToolStripMenuItem tsLeftAxisCalib;
        private System.Windows.Forms.ToolStripMenuItem tsRightAxisCalib;
        private System.Windows.Forms.ToolStripMenuItem tsSwitchMainUI;
        private System.Windows.Forms.ToolStripMenuItem hiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsFront_LBrake;
        private System.Windows.Forms.ToolStripMenuItem tsFront_RBrake;
    }
}

