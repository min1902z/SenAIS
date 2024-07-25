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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDangKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.TSTruyXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.TSHoTro = new System.Windows.Forms.ToolStripMenuItem();
            this.TSGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.TSReset = new System.Windows.Forms.ToolStripMenuItem();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSHeThong,
            this.TSDuLieu,
            this.TSHoTro});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1182, 31);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSHeThong
            // 
            this.TSHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDangKiem});
            this.TSHeThong.Name = "TSHeThong";
            this.TSHeThong.Size = new System.Drawing.Size(99, 27);
            this.TSHeThong.Text = "Hệ Thống";
            // 
            // TSDangKiem
            // 
            this.TSDangKiem.Name = "TSDangKiem";
            this.TSDangKiem.Size = new System.Drawing.Size(178, 28);
            this.TSDangKiem.Text = "Đăng Kiểm";
            this.TSDangKiem.Click += new System.EventHandler(this.TSDangKiem_Click);
            // 
            // TSDuLieu
            // 
            this.TSDuLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSTruyXuat});
            this.TSDuLieu.Name = "TSDuLieu";
            this.TSDuLieu.Size = new System.Drawing.Size(82, 27);
            this.TSDuLieu.Text = "Dữ Liệu";
            // 
            // TSTruyXuat
            // 
            this.TSTruyXuat.Name = "TSTruyXuat";
            this.TSTruyXuat.Size = new System.Drawing.Size(229, 28);
            this.TSTruyXuat.Text = "Truy Xuất Dữ Liệu";
            this.TSTruyXuat.Click += new System.EventHandler(this.TSTruyXuat_Click);
            // 
            // TSHoTro
            // 
            this.TSHoTro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSGioiThieu,
            this.TSReset});
            this.TSHoTro.Name = "TSHoTro";
            this.TSHoTro.Size = new System.Drawing.Size(75, 27);
            this.TSHoTro.Text = "Hỗ Trợ";
            this.TSHoTro.Click += new System.EventHandler(this.TSHoTro_Click);
            // 
            // TSGioiThieu
            // 
            this.TSGioiThieu.Name = "TSGioiThieu";
            this.TSGioiThieu.Size = new System.Drawing.Size(201, 28);
            this.TSGioiThieu.Text = "Giới Thiệu";
            // 
            // TSReset
            // 
            this.TSReset.Name = "TSReset";
            this.TSReset.Size = new System.Drawing.Size(201, 28);
            this.TSReset.Text = "Khởi Động Lại";
            // 
            // picQR
            // 
            this.picQR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picQR.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picQR.Image = ((System.Drawing.Image)(resources.GetObject("picQR.Image")));
            this.picQR.InitialImage = null;
            this.picQR.Location = new System.Drawing.Point(1070, 7);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(100, 100);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQR.TabIndex = 1;
            this.picQR.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(869, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Be Solution, Be Pioneer";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(976, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "SENTEK";
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.label2);
            this.panelFooter.Controls.Add(this.label1);
            this.panelFooter.Controls.Add(this.picQR);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 514);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1182, 119);
            this.panelFooter.TabIndex = 8;
            // 
            // panelBody
            // 
            this.panelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBody.Location = new System.Drawing.Point(0, 31);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1182, 484);
            this.panelBody.TabIndex = 7;
            // 
            // SenAIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1182, 633);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SenAIS";
            this.Text = "SenAIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSHeThong;
        private System.Windows.Forms.ToolStripMenuItem TSDangKiem;
        private System.Windows.Forms.ToolStripMenuItem TSDuLieu;
        private System.Windows.Forms.ToolStripMenuItem TSTruyXuat;
        private System.Windows.Forms.ToolStripMenuItem TSHoTro;
        private System.Windows.Forms.ToolStripMenuItem TSGioiThieu;
        private System.Windows.Forms.ToolStripMenuItem TSReset;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelBody;
    }
}

