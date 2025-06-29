﻿namespace SenAIS
{
    partial class frmSteerAngle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSteerAngle));
            this.SteerPanel = new System.Windows.Forms.Panel();
            this.lbEngineNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.tbSteerAngle = new System.Windows.Forms.TableLayoutPanel();
            this.lbRightSteerRW = new System.Windows.Forms.Label();
            this.lbLeftSteerRW = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRightSteerLW = new System.Windows.Forms.Label();
            this.lbLeftSteerLW = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSteerTitle = new System.Windows.Forms.Label();
            this.SteerPanel.SuspendLayout();
            this.tbSteerAngle.SuspendLayout();
            this.SuspendLayout();
            // 
            // SteerPanel
            // 
            this.SteerPanel.AutoScroll = true;
            this.SteerPanel.AutoSize = true;
            this.SteerPanel.Controls.Add(this.lbEngineNumber);
            this.SteerPanel.Controls.Add(this.cbReady);
            this.SteerPanel.Controls.Add(this.btnNext);
            this.SteerPanel.Controls.Add(this.btnPre);
            this.SteerPanel.Controls.Add(this.tbSteerAngle);
            this.SteerPanel.Controls.Add(this.lbSteerTitle);
            this.SteerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SteerPanel.Location = new System.Drawing.Point(0, 0);
            this.SteerPanel.Name = "SteerPanel";
            this.SteerPanel.Size = new System.Drawing.Size(1428, 846);
            this.SteerPanel.TabIndex = 30;
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.IndianRed;
            this.lbEngineNumber.Location = new System.Drawing.Point(129, 12);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(228, 78);
            this.lbEngineNumber.TabIndex = 49;
            this.lbEngineNumber.Text = "Số Máy";
            // 
            // cbReady
            // 
            this.cbReady.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbReady.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbReady.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbReady.BackgroundImage")));
            this.cbReady.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cbReady.Checked = true;
            this.cbReady.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReady.Enabled = false;
            this.cbReady.Location = new System.Drawing.Point(12, 12);
            this.cbReady.Name = "cbReady";
            this.cbReady.Size = new System.Drawing.Size(111, 88);
            this.cbReady.TabIndex = 45;
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1330, 798);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
            this.btnNext.TabIndex = 44;
            this.btnNext.Text = "Tiếp Tục";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPre.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPre.Location = new System.Drawing.Point(11, 798);
            this.btnPre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(86, 37);
            this.btnPre.TabIndex = 43;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // tbSteerAngle
            // 
            this.tbSteerAngle.AutoScroll = true;
            this.tbSteerAngle.AutoSize = true;
            this.tbSteerAngle.ColumnCount = 3;
            this.tbSteerAngle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbSteerAngle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbSteerAngle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbSteerAngle.Controls.Add(this.lbRightSteerRW, 2, 2);
            this.tbSteerAngle.Controls.Add(this.lbLeftSteerRW, 2, 1);
            this.tbSteerAngle.Controls.Add(this.label4, 0, 2);
            this.tbSteerAngle.Controls.Add(this.lbRightSteerLW, 1, 2);
            this.tbSteerAngle.Controls.Add(this.lbLeftSteerLW, 1, 1);
            this.tbSteerAngle.Controls.Add(this.label2, 1, 0);
            this.tbSteerAngle.Controls.Add(this.label1, 0, 1);
            this.tbSteerAngle.Controls.Add(this.label3, 2, 0);
            this.tbSteerAngle.Location = new System.Drawing.Point(193, 171);
            this.tbSteerAngle.Name = "tbSteerAngle";
            this.tbSteerAngle.RowCount = 3;
            this.tbSteerAngle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbSteerAngle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbSteerAngle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbSteerAngle.Size = new System.Drawing.Size(981, 566);
            this.tbSteerAngle.TabIndex = 42;
            this.tbSteerAngle.Resize += new System.EventHandler(this.tbSteerAngle_Resize);
            // 
            // lbRightSteerRW
            // 
            this.lbRightSteerRW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRightSteerRW.AutoSize = true;
            this.lbRightSteerRW.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRightSteerRW.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRightSteerRW.Location = new System.Drawing.Point(624, 322);
            this.lbRightSteerRW.Name = "lbRightSteerRW";
            this.lbRightSteerRW.Size = new System.Drawing.Size(354, 244);
            this.lbRightSteerRW.TabIndex = 50;
            this.lbRightSteerRW.Text = "0.0";
            this.lbRightSteerRW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLeftSteerRW
            // 
            this.lbLeftSteerRW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLeftSteerRW.AutoSize = true;
            this.lbLeftSteerRW.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeftSteerRW.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLeftSteerRW.Location = new System.Drawing.Point(624, 78);
            this.lbLeftSteerRW.Name = "lbLeftSteerRW";
            this.lbLeftSteerRW.Size = new System.Drawing.Size(354, 244);
            this.lbLeftSteerRW.TabIndex = 50;
            this.lbLeftSteerRW.Text = "0.0";
            this.lbLeftSteerRW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(3, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 78);
            this.label4.TabIndex = 50;
            this.label4.Text = "Lái Phải";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRightSteerLW
            // 
            this.lbRightSteerLW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRightSteerLW.AutoSize = true;
            this.lbRightSteerLW.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRightSteerLW.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRightSteerLW.Location = new System.Drawing.Point(253, 322);
            this.lbRightSteerLW.Name = "lbRightSteerLW";
            this.lbRightSteerLW.Size = new System.Drawing.Size(354, 244);
            this.lbRightSteerLW.TabIndex = 9;
            this.lbRightSteerLW.Text = "0.0";
            this.lbRightSteerLW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLeftSteerLW
            // 
            this.lbLeftSteerLW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLeftSteerLW.AutoSize = true;
            this.lbLeftSteerLW.Font = new System.Drawing.Font("Calibri", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeftSteerLW.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLeftSteerLW.Location = new System.Drawing.Point(253, 78);
            this.lbLeftSteerLW.Name = "lbLeftSteerLW";
            this.lbLeftSteerLW.Size = new System.Drawing.Size(354, 244);
            this.lbLeftSteerLW.TabIndex = 8;
            this.lbLeftSteerLW.Text = "0.0";
            this.lbLeftSteerLW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(332, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 78);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bánh Trái";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(3, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 78);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lái Trái";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(684, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 78);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bánh Phải";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSteerTitle
            // 
            this.lbSteerTitle.AutoSize = true;
            this.lbSteerTitle.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteerTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSteerTitle.Location = new System.Drawing.Point(656, 5);
            this.lbSteerTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSteerTitle.Name = "lbSteerTitle";
            this.lbSteerTitle.Size = new System.Drawing.Size(374, 117);
            this.lbSteerTitle.TabIndex = 41;
            this.lbSteerTitle.Text = "GÓC LÁI";
            this.lbSteerTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmSteerAngle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1428, 846);
            this.Controls.Add(this.SteerPanel);
            this.Name = "frmSteerAngle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Góc Lái";
            this.SteerPanel.ResumeLayout(false);
            this.SteerPanel.PerformLayout();
            this.tbSteerAngle.ResumeLayout(false);
            this.tbSteerAngle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SteerPanel;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.TableLayoutPanel tbSteerAngle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRightSteerLW;
        private System.Windows.Forms.Label lbLeftSteerLW;
        private System.Windows.Forms.Label lbSteerTitle;
        private System.Windows.Forms.Label lbEngineNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRightSteerRW;
        private System.Windows.Forms.Label lbLeftSteerRW;
    }
}