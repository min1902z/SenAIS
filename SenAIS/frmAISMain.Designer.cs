namespace SenAIS
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
            this.TSDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.TSTruyXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.điềuChỉnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCalibration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLWeightCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRWeightCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSpeedCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSideSlipCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBrakeCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLBrakeCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRBrakeCalib = new System.Windows.Forms.ToolStripMenuItem();
            this.TSHoTro = new System.Windows.Forms.ToolStripMenuItem();
            this.TSAuboutMe = new System.Windows.Forms.ToolStripMenuItem();
            this.TSReset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBody = new System.Windows.Forms.Panel();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
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
            this.TSDangKiem});
            this.TSHeThong.Name = "TSHeThong";
            this.TSHeThong.Size = new System.Drawing.Size(81, 23);
            this.TSHeThong.Text = "Hệ Thống";
            // 
            // TSDangKiem
            // 
            this.TSDangKiem.Name = "TSDangKiem";
            this.TSDangKiem.Size = new System.Drawing.Size(145, 24);
            this.TSDangKiem.Text = "Đăng Kiểm";
            this.TSDangKiem.Click += new System.EventHandler(this.TSDangKiem_Click);
            // 
            // TSDuLieu
            // 
            this.TSDuLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSTruyXuat});
            this.TSDuLieu.Name = "TSDuLieu";
            this.TSDuLieu.Size = new System.Drawing.Size(68, 23);
            this.TSDuLieu.Text = "Dữ Liệu";
            this.TSDuLieu.Click += new System.EventHandler(this.TSDuLieu_Click);
            // 
            // TSTruyXuat
            // 
            this.TSTruyXuat.Name = "TSTruyXuat";
            this.TSTruyXuat.Size = new System.Drawing.Size(187, 24);
            this.TSTruyXuat.Text = "Truy Xuất Dữ Liệu";
            this.TSTruyXuat.Click += new System.EventHandler(this.TSTruyXuat_Click);
            // 
            // điềuChỉnhToolStripMenuItem
            // 
            this.điềuChỉnhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCalibration,
            this.tsSpeedCalib,
            this.tsSideSlipCalib,
            this.tsBrakeCalib});
            this.điềuChỉnhToolStripMenuItem.Name = "điềuChỉnhToolStripMenuItem";
            this.điềuChỉnhToolStripMenuItem.Size = new System.Drawing.Size(89, 23);
            this.điềuChỉnhToolStripMenuItem.Text = "Điều Chỉnh";
            // 
            // tsCalibration
            // 
            this.tsCalibration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLWeightCalib,
            this.tsRWeightCalib});
            this.tsCalibration.Name = "tsCalibration";
            this.tsCalibration.Size = new System.Drawing.Size(228, 24);
            this.tsCalibration.Text = "Hiệu Chỉnh Trọng Lượng";
            // 
            // tsLWeightCalib
            // 
            this.tsLWeightCalib.Name = "tsLWeightCalib";
            this.tsLWeightCalib.Size = new System.Drawing.Size(186, 24);
            this.tsLWeightCalib.Text = "Trọng Lượng Trái";
            this.tsLWeightCalib.Click += new System.EventHandler(this.tsLWeightCalib_Click);
            // 
            // tsRWeightCalib
            // 
            this.tsRWeightCalib.Name = "tsRWeightCalib";
            this.tsRWeightCalib.Size = new System.Drawing.Size(186, 24);
            this.tsRWeightCalib.Text = "Trọng Lượng Phải";
            this.tsRWeightCalib.Click += new System.EventHandler(this.tsRWeightCalib_Click);
            // 
            // tsSpeedCalib
            // 
            this.tsSpeedCalib.Name = "tsSpeedCalib";
            this.tsSpeedCalib.Size = new System.Drawing.Size(228, 24);
            this.tsSpeedCalib.Text = "Hiệu Chỉnh Tốc Độ";
            this.tsSpeedCalib.Click += new System.EventHandler(this.tsSpeedCalib_Click);
            // 
            // tsSideSlipCalib
            // 
            this.tsSideSlipCalib.Name = "tsSideSlipCalib";
            this.tsSideSlipCalib.Size = new System.Drawing.Size(228, 24);
            this.tsSideSlipCalib.Text = "Hiệu Chỉnh Trượt Ngang";
            this.tsSideSlipCalib.Click += new System.EventHandler(this.tsSideSlipCalib_Click);
            // 
            // tsBrakeCalib
            // 
            this.tsBrakeCalib.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLBrakeCalib,
            this.tsRBrakeCalib});
            this.tsBrakeCalib.Name = "tsBrakeCalib";
            this.tsBrakeCalib.Size = new System.Drawing.Size(228, 24);
            this.tsBrakeCalib.Text = "Hiệu Chinh Lực Phanh";
            // 
            // tsLBrakeCalib
            // 
            this.tsLBrakeCalib.Name = "tsLBrakeCalib";
            this.tsLBrakeCalib.Size = new System.Drawing.Size(172, 24);
            this.tsLBrakeCalib.Text = "Lực Phanh Trái";
            this.tsLBrakeCalib.Click += new System.EventHandler(this.tsLBrakeCalib_Click);
            // 
            // tsRBrakeCalib
            // 
            this.tsRBrakeCalib.Name = "tsRBrakeCalib";
            this.tsRBrakeCalib.Size = new System.Drawing.Size(172, 24);
            this.tsRBrakeCalib.Text = "Lực Phanh Phải";
            this.tsRBrakeCalib.Click += new System.EventHandler(this.tsRBrakeCalib_Click);
            // 
            // TSHoTro
            // 
            this.TSHoTro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSAuboutMe,
            this.TSReset,
            this.tsExit});
            this.TSHoTro.Name = "TSHoTro";
            this.TSHoTro.Size = new System.Drawing.Size(62, 23);
            this.TSHoTro.Text = "Hỗ Trợ";
            this.TSHoTro.Click += new System.EventHandler(this.TSHoTro_Click);
            // 
            // TSAuboutMe
            // 
            this.TSAuboutMe.Name = "TSAuboutMe";
            this.TSAuboutMe.Size = new System.Drawing.Size(180, 24);
            this.TSAuboutMe.Text = "Giới Thiệu";
            this.TSAuboutMe.Click += new System.EventHandler(this.TSAuboutMe_Click);
            // 
            // TSReset
            // 
            this.TSReset.Name = "TSReset";
            this.TSReset.Size = new System.Drawing.Size(180, 24);
            this.TSReset.Text = "Khởi Động Lại";
            this.TSReset.Click += new System.EventHandler(this.TSReset_Click);
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(180, 24);
            this.tsExit.Text = "Thoát ";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // panelBody
            // 
            this.panelBody.AutoScroll = true;
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 27);
            this.panelBody.Margin = new System.Windows.Forms.Padding(2);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SenAIS";
            this.Text = "SenAIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SenAIS_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel panelBody;
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
    }
}

