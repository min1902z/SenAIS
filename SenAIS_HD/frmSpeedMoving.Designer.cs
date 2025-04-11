namespace SenAIS
{
    partial class frmSpeedMoving
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpeedMoving));
            this.WaitingPanel = new System.Windows.Forms.Panel();
            this.SpeedMovingPanel = new System.Windows.Forms.Panel();
            this.btnBackMain = new System.Windows.Forms.Button();
            this.ManualPanel = new System.Windows.Forms.Panel();
            this.pbMotor = new System.Windows.Forms.PictureBox();
            this.btnDownLeftDistance = new System.Windows.Forms.Button();
            this.btnUpLeftDistance = new System.Windows.Forms.Button();
            this.btnDownRightDistance = new System.Windows.Forms.Button();
            this.btnUpRightDistance = new System.Windows.Forms.Button();
            this.btnStartMotor = new System.Windows.Forms.Button();
            this.AutoPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRightDistance = new System.Windows.Forms.TextBox();
            this.txtLeftDistance = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtDistanceValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDistance4 = new System.Windows.Forms.Button();
            this.btnDistance3 = new System.Windows.Forms.Button();
            this.btnDistance2 = new System.Windows.Forms.Button();
            this.btnDistance1 = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.WaitingPanel.SuspendLayout();
            this.SpeedMovingPanel.SuspendLayout();
            this.ManualPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor)).BeginInit();
            this.AutoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WaitingPanel
            // 
            this.WaitingPanel.Controls.Add(this.SpeedMovingPanel);
            this.WaitingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaitingPanel.Location = new System.Drawing.Point(0, 0);
            this.WaitingPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WaitingPanel.Name = "WaitingPanel";
            this.WaitingPanel.Size = new System.Drawing.Size(1845, 937);
            this.WaitingPanel.TabIndex = 0;
            // 
            // SpeedMovingPanel
            // 
            this.SpeedMovingPanel.AutoScroll = true;
            this.SpeedMovingPanel.AutoSize = true;
            this.SpeedMovingPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SpeedMovingPanel.Controls.Add(this.btnBackMain);
            this.SpeedMovingPanel.Controls.Add(this.ManualPanel);
            this.SpeedMovingPanel.Controls.Add(this.AutoPanel);
            this.SpeedMovingPanel.Controls.Add(this.btnMode);
            this.SpeedMovingPanel.Controls.Add(this.lbTitle);
            this.SpeedMovingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpeedMovingPanel.Location = new System.Drawing.Point(0, 0);
            this.SpeedMovingPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SpeedMovingPanel.Name = "SpeedMovingPanel";
            this.SpeedMovingPanel.Size = new System.Drawing.Size(1845, 937);
            this.SpeedMovingPanel.TabIndex = 46;
            // 
            // btnBackMain
            // 
            this.btnBackMain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBackMain.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackMain.ForeColor = System.Drawing.Color.DarkRed;
            this.btnBackMain.Location = new System.Drawing.Point(889, 804);
            this.btnBackMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBackMain.Name = "btnBackMain";
            this.btnBackMain.Size = new System.Drawing.Size(152, 54);
            this.btnBackMain.TabIndex = 49;
            this.btnBackMain.Text = "Trang chủ";
            this.btnBackMain.UseVisualStyleBackColor = true;
            this.btnBackMain.Click += new System.EventHandler(this.btnBackMain_Click);
            // 
            // ManualPanel
            // 
            this.ManualPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ManualPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ManualPanel.Controls.Add(this.pbMotor);
            this.ManualPanel.Controls.Add(this.btnDownLeftDistance);
            this.ManualPanel.Controls.Add(this.btnUpLeftDistance);
            this.ManualPanel.Controls.Add(this.btnDownRightDistance);
            this.ManualPanel.Controls.Add(this.btnUpRightDistance);
            this.ManualPanel.Controls.Add(this.btnStartMotor);
            this.ManualPanel.Location = new System.Drawing.Point(143, 572);
            this.ManualPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ManualPanel.Name = "ManualPanel";
            this.ManualPanel.Size = new System.Drawing.Size(1573, 223);
            this.ManualPanel.TabIndex = 48;
            // 
            // pbMotor
            // 
            this.pbMotor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMotor.BackgroundImage")));
            this.pbMotor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbMotor.Location = new System.Drawing.Point(744, 91);
            this.pbMotor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbMotor.Name = "pbMotor";
            this.pbMotor.Size = new System.Drawing.Size(152, 114);
            this.pbMotor.TabIndex = 59;
            this.pbMotor.TabStop = false;
            // 
            // btnDownLeftDistance
            // 
            this.btnDownLeftDistance.AutoSize = true;
            this.btnDownLeftDistance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownLeftDistance.ForeColor = System.Drawing.Color.Blue;
            this.btnDownLeftDistance.Location = new System.Drawing.Point(403, 138);
            this.btnDownLeftDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDownLeftDistance.Name = "btnDownLeftDistance";
            this.btnDownLeftDistance.Size = new System.Drawing.Size(279, 68);
            this.btnDownLeftDistance.TabIndex = 58;
            this.btnDownLeftDistance.Text = "Giảm Khoảng Cách";
            this.btnDownLeftDistance.UseVisualStyleBackColor = true;
            this.btnDownLeftDistance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnHoldDown_MouseDown);
            this.btnDownLeftDistance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnHoldDown_MouseUp);
            // 
            // btnUpLeftDistance
            // 
            this.btnUpLeftDistance.AutoSize = true;
            this.btnUpLeftDistance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpLeftDistance.ForeColor = System.Drawing.Color.Blue;
            this.btnUpLeftDistance.Location = new System.Drawing.Point(403, 43);
            this.btnUpLeftDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpLeftDistance.Name = "btnUpLeftDistance";
            this.btnUpLeftDistance.Size = new System.Drawing.Size(269, 68);
            this.btnUpLeftDistance.TabIndex = 57;
            this.btnUpLeftDistance.Text = "Tăng Khoảng Cách";
            this.btnUpLeftDistance.UseVisualStyleBackColor = true;
            this.btnUpLeftDistance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnHoldDown_MouseDown);
            this.btnUpLeftDistance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnHoldDown_MouseUp);
            // 
            // btnDownRightDistance
            // 
            this.btnDownRightDistance.AutoSize = true;
            this.btnDownRightDistance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownRightDistance.ForeColor = System.Drawing.Color.Blue;
            this.btnDownRightDistance.Location = new System.Drawing.Point(1055, 138);
            this.btnDownRightDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDownRightDistance.Name = "btnDownRightDistance";
            this.btnDownRightDistance.Size = new System.Drawing.Size(279, 68);
            this.btnDownRightDistance.TabIndex = 56;
            this.btnDownRightDistance.Text = "Giảm Khoảng Cách";
            this.btnDownRightDistance.UseVisualStyleBackColor = true;
            this.btnDownRightDistance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnHoldDown_MouseDown);
            this.btnDownRightDistance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnHoldDown_MouseUp);
            // 
            // btnUpRightDistance
            // 
            this.btnUpRightDistance.AutoSize = true;
            this.btnUpRightDistance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpRightDistance.ForeColor = System.Drawing.Color.Blue;
            this.btnUpRightDistance.Location = new System.Drawing.Point(1055, 43);
            this.btnUpRightDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpRightDistance.Name = "btnUpRightDistance";
            this.btnUpRightDistance.Size = new System.Drawing.Size(269, 68);
            this.btnUpRightDistance.TabIndex = 55;
            this.btnUpRightDistance.Text = "Tăng Khoảng Cách";
            this.btnUpRightDistance.UseVisualStyleBackColor = true;
            this.btnUpRightDistance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnHoldDown_MouseDown);
            this.btnUpRightDistance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnHoldDown_MouseUp);
            // 
            // btnStartMotor
            // 
            this.btnStartMotor.AutoSize = true;
            this.btnStartMotor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMotor.ForeColor = System.Drawing.Color.Blue;
            this.btnStartMotor.Location = new System.Drawing.Point(744, 15);
            this.btnStartMotor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartMotor.Name = "btnStartMotor";
            this.btnStartMotor.Size = new System.Drawing.Size(167, 69);
            this.btnStartMotor.TabIndex = 54;
            this.btnStartMotor.Text = "Bật Motor";
            this.btnStartMotor.UseVisualStyleBackColor = true;
            this.btnStartMotor.Click += new System.EventHandler(this.btnStartMotor_ClickAsync);
            // 
            // AutoPanel
            // 
            this.AutoPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AutoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AutoPanel.Controls.Add(this.label4);
            this.AutoPanel.Controls.Add(this.label3);
            this.AutoPanel.Controls.Add(this.txtRightDistance);
            this.AutoPanel.Controls.Add(this.txtLeftDistance);
            this.AutoPanel.Controls.Add(this.btnStop);
            this.AutoPanel.Controls.Add(this.btnStart);
            this.AutoPanel.Controls.Add(this.btnAccept);
            this.AutoPanel.Controls.Add(this.txtDistanceValue);
            this.AutoPanel.Controls.Add(this.label2);
            this.AutoPanel.Controls.Add(this.btnDistance4);
            this.AutoPanel.Controls.Add(this.btnDistance3);
            this.AutoPanel.Controls.Add(this.btnDistance2);
            this.AutoPanel.Controls.Add(this.btnDistance1);
            this.AutoPanel.Location = new System.Drawing.Point(143, 171);
            this.AutoPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AutoPanel.Name = "AutoPanel";
            this.AutoPanel.Size = new System.Drawing.Size(1573, 393);
            this.AutoPanel.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(1143, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(348, 33);
            this.label4.TabIndex = 53;
            this.label4.Text = "Khoảng cách Roller phải (mm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(85, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 33);
            this.label3.TabIndex = 52;
            this.label3.Text = "Khoảng cách Roller trái (mm)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRightDistance
            // 
            this.txtRightDistance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRightDistance.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRightDistance.ForeColor = System.Drawing.Color.Blue;
            this.txtRightDistance.Location = new System.Drawing.Point(1149, 169);
            this.txtRightDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRightDistance.Name = "txtRightDistance";
            this.txtRightDistance.Size = new System.Drawing.Size(331, 154);
            this.txtRightDistance.TabIndex = 51;
            this.txtRightDistance.Text = "2700";
            this.txtRightDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeftDistance
            // 
            this.txtLeftDistance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtLeftDistance.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftDistance.ForeColor = System.Drawing.Color.Blue;
            this.txtLeftDistance.Location = new System.Drawing.Point(92, 169);
            this.txtLeftDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLeftDistance.Name = "txtLeftDistance";
            this.txtLeftDistance.Size = new System.Drawing.Size(335, 154);
            this.txtLeftDistance.TabIndex = 50;
            this.txtLeftDistance.Text = "2700";
            this.txtLeftDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.DarkRed;
            this.btnStop.Location = new System.Drawing.Point(877, 322);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(137, 55);
            this.btnStop.TabIndex = 49;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseDown);
            this.btnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseUp);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Blue;
            this.btnStart.Location = new System.Drawing.Point(608, 322);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(137, 55);
            this.btnStart.TabIndex = 48;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseDown);
            this.btnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseUp);
            // 
            // btnAccept
            // 
            this.btnAccept.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.Blue;
            this.btnAccept.Location = new System.Drawing.Point(697, 246);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(231, 69);
            this.btnAccept.TabIndex = 47;
            this.btnAccept.Text = "Xác nhận";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtDistanceValue
            // 
            this.txtDistanceValue.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistanceValue.ForeColor = System.Drawing.Color.Blue;
            this.txtDistanceValue.Location = new System.Drawing.Point(649, 133);
            this.txtDistanceValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDistanceValue.Name = "txtDistanceValue";
            this.txtDistanceValue.Size = new System.Drawing.Size(324, 105);
            this.txtDistanceValue.TabIndex = 5;
            this.txtDistanceValue.Text = "2700";
            this.txtDistanceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(92, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1412, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhập Khoảng cách 2 trục (mm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDistance4
            // 
            this.btnDistance4.AutoSize = true;
            this.btnDistance4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistance4.ForeColor = System.Drawing.Color.Blue;
            this.btnDistance4.Location = new System.Drawing.Point(1277, 9);
            this.btnDistance4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDistance4.Name = "btnDistance4";
            this.btnDistance4.Size = new System.Drawing.Size(175, 84);
            this.btnDistance4.TabIndex = 3;
            this.btnDistance4.Text = "LX2\r\n2950 mm";
            this.btnDistance4.UseVisualStyleBackColor = true;
            this.btnDistance4.Click += new System.EventHandler(this.btnDistance4_Click);
            // 
            // btnDistance3
            // 
            this.btnDistance3.AutoSize = true;
            this.btnDistance3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistance3.ForeColor = System.Drawing.Color.Blue;
            this.btnDistance3.Location = new System.Drawing.Point(877, 9);
            this.btnDistance3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDistance3.Name = "btnDistance3";
            this.btnDistance3.Size = new System.Drawing.Size(175, 84);
            this.btnDistance3.TabIndex = 2;
            this.btnDistance3.Text = "KU\r\n2850 mm";
            this.btnDistance3.UseVisualStyleBackColor = true;
            this.btnDistance3.Click += new System.EventHandler(this.btnDistance3_Click);
            // 
            // btnDistance2
            // 
            this.btnDistance2.AutoSize = true;
            this.btnDistance2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistance2.ForeColor = System.Drawing.Color.Blue;
            this.btnDistance2.Location = new System.Drawing.Point(485, 9);
            this.btnDistance2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDistance2.Name = "btnDistance2";
            this.btnDistance2.Size = new System.Drawing.Size(175, 84);
            this.btnDistance2.TabIndex = 1;
            this.btnDistance2.Text = "TM\r\n2750 mm";
            this.btnDistance2.UseVisualStyleBackColor = true;
            this.btnDistance2.Click += new System.EventHandler(this.btnDistance2_Click);
            // 
            // btnDistance1
            // 
            this.btnDistance1.AutoSize = true;
            this.btnDistance1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistance1.ForeColor = System.Drawing.Color.Blue;
            this.btnDistance1.Location = new System.Drawing.Point(103, 9);
            this.btnDistance1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDistance1.Name = "btnDistance1";
            this.btnDistance1.Size = new System.Drawing.Size(175, 84);
            this.btnDistance1.TabIndex = 0;
            this.btnDistance1.Text = "NX4\r\n2650 mm";
            this.btnDistance1.UseVisualStyleBackColor = true;
            this.btnDistance1.Click += new System.EventHandler(this.btnDistance1_Click);
            // 
            // btnMode
            // 
            this.btnMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMode.AutoSize = true;
            this.btnMode.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMode.ForeColor = System.Drawing.Color.DarkRed;
            this.btnMode.Location = new System.Drawing.Point(795, 101);
            this.btnMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(377, 68);
            this.btnMode.TabIndex = 46;
            this.btnMode.Text = "Chế độ: Tự động";
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbTitle.Location = new System.Drawing.Point(143, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1611, 97);
            this.lbTitle.TabIndex = 45;
            this.lbTitle.Text = "Điều khiển vị trí Trục sau";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmSpeedMoving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1845, 937);
            this.Controls.Add(this.WaitingPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSpeedMoving";
            this.ShowIcon = false;
            this.Text = "Trục tốc độ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSpeedMoving_FormClosing);
            this.WaitingPanel.ResumeLayout(false);
            this.WaitingPanel.PerformLayout();
            this.SpeedMovingPanel.ResumeLayout(false);
            this.SpeedMovingPanel.PerformLayout();
            this.ManualPanel.ResumeLayout(false);
            this.ManualPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor)).EndInit();
            this.AutoPanel.ResumeLayout(false);
            this.AutoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WaitingPanel;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel SpeedMovingPanel;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Button btnBackMain;
        private System.Windows.Forms.Panel ManualPanel;
        private System.Windows.Forms.Panel AutoPanel;
        private System.Windows.Forms.Button btnDownLeftDistance;
        private System.Windows.Forms.Button btnUpLeftDistance;
        private System.Windows.Forms.Button btnDownRightDistance;
        private System.Windows.Forms.Button btnUpRightDistance;
        private System.Windows.Forms.Button btnStartMotor;
        private System.Windows.Forms.PictureBox pbMotor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRightDistance;
        private System.Windows.Forms.TextBox txtLeftDistance;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtDistanceValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDistance4;
        private System.Windows.Forms.Button btnDistance3;
        private System.Windows.Forms.Button btnDistance2;
        private System.Windows.Forms.Button btnDistance1;
    }
}