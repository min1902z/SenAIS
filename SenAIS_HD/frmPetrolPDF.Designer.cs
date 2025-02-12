namespace SenAIS
{
    partial class frmPetrolPDF
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
            this.EmissionPanel = new System.Windows.Forms.Panel();
            this.SelectFilePanel = new System.Windows.Forms.Panel();
            this.btnSaveEmission = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnReadPDF = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lbEngineNumber = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.tbGasEmission = new System.Windows.Forms.TableLayoutPanel();
            this.lbCO = new System.Windows.Forms.Label();
            this.lbCOValue = new System.Windows.Forms.Label();
            this.lbHC = new System.Windows.Forms.Label();
            this.lbHCValue = new System.Windows.Forms.Label();
            this.lbRPM = new System.Windows.Forms.Label();
            this.lbOTValue = new System.Windows.Forms.Label();
            this.lbOT = new System.Windows.Forms.Label();
            this.lbRPMValue = new System.Windows.Forms.Label();
            this.lbEmissionTitle = new System.Windows.Forms.Label();
            this.EmissionPanel.SuspendLayout();
            this.SelectFilePanel.SuspendLayout();
            this.tbGasEmission.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmissionPanel
            // 
            this.EmissionPanel.AutoScroll = true;
            this.EmissionPanel.Controls.Add(this.SelectFilePanel);
            this.EmissionPanel.Controls.Add(this.lbEngineNumber);
            this.EmissionPanel.Controls.Add(this.btnNext);
            this.EmissionPanel.Controls.Add(this.btnPre);
            this.EmissionPanel.Controls.Add(this.tbGasEmission);
            this.EmissionPanel.Controls.Add(this.lbEmissionTitle);
            this.EmissionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmissionPanel.Location = new System.Drawing.Point(0, 0);
            this.EmissionPanel.Margin = new System.Windows.Forms.Padding(4);
            this.EmissionPanel.Name = "EmissionPanel";
            this.EmissionPanel.Size = new System.Drawing.Size(1827, 922);
            this.EmissionPanel.TabIndex = 6;
            // 
            // SelectFilePanel
            // 
            this.SelectFilePanel.AutoSize = true;
            this.SelectFilePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SelectFilePanel.Controls.Add(this.btnSaveEmission);
            this.SelectFilePanel.Controls.Add(this.btnSelectFile);
            this.SelectFilePanel.Controls.Add(this.btnReadPDF);
            this.SelectFilePanel.Controls.Add(this.txtFilePath);
            this.SelectFilePanel.Location = new System.Drawing.Point(324, 111);
            this.SelectFilePanel.Margin = new System.Windows.Forms.Padding(4);
            this.SelectFilePanel.Name = "SelectFilePanel";
            this.SelectFilePanel.Size = new System.Drawing.Size(964, 50);
            this.SelectFilePanel.TabIndex = 57;
            // 
            // btnSaveEmission
            // 
            this.btnSaveEmission.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveEmission.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveEmission.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEmission.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSaveEmission.Location = new System.Drawing.Point(756, 2);
            this.btnSaveEmission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveEmission.Name = "btnSaveEmission";
            this.btnSaveEmission.Size = new System.Drawing.Size(115, 46);
            this.btnSaveEmission.TabIndex = 57;
            this.btnSaveEmission.Text = "Lưu ";
            this.btnSaveEmission.UseVisualStyleBackColor = false;
            this.btnSaveEmission.Click += new System.EventHandler(this.btnSaveEmission_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSelectFile.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFile.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectFile.Location = new System.Drawing.Point(3, 2);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(115, 46);
            this.btnSelectFile.TabIndex = 53;
            this.btnSelectFile.Text = "Chọn File";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnReadPDF
            // 
            this.btnReadPDF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadPDF.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReadPDF.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadPDF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnReadPDF.Location = new System.Drawing.Point(636, 2);
            this.btnReadPDF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReadPDF.Name = "btnReadPDF";
            this.btnReadPDF.Size = new System.Drawing.Size(115, 46);
            this.btnReadPDF.TabIndex = 55;
            this.btnReadPDF.Text = "Đọc File";
            this.btnReadPDF.UseVisualStyleBackColor = false;
            this.btnReadPDF.Click += new System.EventHandler(this.btnReadPDF_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(124, 9);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(504, 30);
            this.txtFilePath.TabIndex = 54;
            // 
            // lbEngineNumber
            // 
            this.lbEngineNumber.AutoSize = true;
            this.lbEngineNumber.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.lbEngineNumber.Location = new System.Drawing.Point(4, 9);
            this.lbEngineNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEngineNumber.Name = "lbEngineNumber";
            this.lbEngineNumber.Size = new System.Drawing.Size(188, 73);
            this.lbEngineNumber.TabIndex = 52;
            this.lbEngineNumber.Text = "Số Vin";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNext.Location = new System.Drawing.Point(1697, 863);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 46);
            this.btnNext.TabIndex = 40;
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
            this.btnPre.Location = new System.Drawing.Point(15, 863);
            this.btnPre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(115, 46);
            this.btnPre.TabIndex = 39;
            this.btnPre.Text = "Trở Lại";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // tbGasEmission
            // 
            this.tbGasEmission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGasEmission.AutoScroll = true;
            this.tbGasEmission.ColumnCount = 2;
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbGasEmission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbGasEmission.Controls.Add(this.lbCO, 0, 2);
            this.tbGasEmission.Controls.Add(this.lbCOValue, 1, 2);
            this.tbGasEmission.Controls.Add(this.lbHC, 0, 1);
            this.tbGasEmission.Controls.Add(this.lbHCValue, 1, 1);
            this.tbGasEmission.Controls.Add(this.lbRPM, 0, 0);
            this.tbGasEmission.Controls.Add(this.lbOTValue, 1, 3);
            this.tbGasEmission.Controls.Add(this.lbOT, 0, 3);
            this.tbGasEmission.Controls.Add(this.lbRPMValue, 1, 0);
            this.tbGasEmission.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGasEmission.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbGasEmission.Location = new System.Drawing.Point(300, 169);
            this.tbGasEmission.Margin = new System.Windows.Forms.Padding(4);
            this.tbGasEmission.Name = "tbGasEmission";
            this.tbGasEmission.RowCount = 4;
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbGasEmission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbGasEmission.Size = new System.Drawing.Size(1261, 662);
            this.tbGasEmission.TabIndex = 38;
            // 
            // lbCO
            // 
            this.lbCO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCO.AutoSize = true;
            this.lbCO.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCO.Location = new System.Drawing.Point(4, 316);
            this.lbCO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCO.Name = "lbCO";
            this.lbCO.Size = new System.Drawing.Size(260, 97);
            this.lbCO.TabIndex = 6;
            this.lbCO.Text = "CO (%)";
            this.lbCO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCOValue
            // 
            this.lbCOValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbCOValue.AutoSize = true;
            this.lbCOValue.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCOValue.Location = new System.Drawing.Point(808, 292);
            this.lbCOValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCOValue.Name = "lbCOValue";
            this.lbCOValue.Size = new System.Drawing.Size(275, 146);
            this.lbCOValue.TabIndex = 8;
            this.lbCOValue.Text = "0.00";
            this.lbCOValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHC
            // 
            this.lbHC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbHC.AutoSize = true;
            this.lbHC.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHC.Location = new System.Drawing.Point(4, 170);
            this.lbHC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHC.Name = "lbHC";
            this.lbHC.Size = new System.Drawing.Size(349, 97);
            this.lbHC.TabIndex = 5;
            this.lbHC.Text = "HC (ppm)";
            this.lbHC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHCValue
            // 
            this.lbHCValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbHCValue.AutoSize = true;
            this.lbHCValue.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHCValue.Location = new System.Drawing.Point(808, 146);
            this.lbHCValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHCValue.Name = "lbHCValue";
            this.lbHCValue.Size = new System.Drawing.Size(275, 146);
            this.lbHCValue.TabIndex = 7;
            this.lbHCValue.Text = "0.00";
            this.lbHCValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRPM
            // 
            this.lbRPM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbRPM.AutoSize = true;
            this.lbRPM.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPM.Location = new System.Drawing.Point(4, 24);
            this.lbRPM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRPM.Name = "lbRPM";
            this.lbRPM.Size = new System.Drawing.Size(622, 97);
            this.lbRPM.TabIndex = 11;
            this.lbRPM.Text = "RPM  (vòng/phút)";
            this.lbRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOTValue
            // 
            this.lbOTValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbOTValue.AutoSize = true;
            this.lbOTValue.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOTValue.Location = new System.Drawing.Point(808, 438);
            this.lbOTValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOTValue.Name = "lbOTValue";
            this.lbOTValue.Size = new System.Drawing.Size(275, 224);
            this.lbOTValue.TabIndex = 8;
            this.lbOTValue.Text = "0.00";
            this.lbOTValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOT
            // 
            this.lbOT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbOT.AutoSize = true;
            this.lbOT.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOT.Location = new System.Drawing.Point(4, 501);
            this.lbOT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOT.Name = "lbOT";
            this.lbOT.Size = new System.Drawing.Size(464, 97);
            this.lbOT.TabIndex = 10;
            this.lbOT.Text = "Oil Temp (℃)";
            this.lbOT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRPMValue
            // 
            this.lbRPMValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbRPMValue.AutoSize = true;
            this.lbRPMValue.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPMValue.Location = new System.Drawing.Point(808, 0);
            this.lbRPMValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRPMValue.Name = "lbRPMValue";
            this.lbRPMValue.Size = new System.Drawing.Size(275, 146);
            this.lbRPMValue.TabIndex = 8;
            this.lbRPMValue.Text = "0.00";
            this.lbRPMValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbEmissionTitle
            // 
            this.lbEmissionTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbEmissionTitle.AutoSize = true;
            this.lbEmissionTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmissionTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbEmissionTitle.Location = new System.Drawing.Point(549, 11);
            this.lbEmissionTitle.Name = "lbEmissionTitle";
            this.lbEmissionTitle.Size = new System.Drawing.Size(871, 97);
            this.lbEmissionTitle.TabIndex = 37;
            this.lbEmissionTitle.Text = "KHÍ XẢ - ĐỘNG CƠ XĂNG";
            this.lbEmissionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmPetrolPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 922);
            this.Controls.Add(this.EmissionPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPetrolPDF";
            this.ShowIcon = false;
            this.Text = "Khí Xả Động Cơ Xăng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.EmissionPanel.ResumeLayout(false);
            this.EmissionPanel.PerformLayout();
            this.SelectFilePanel.ResumeLayout(false);
            this.SelectFilePanel.PerformLayout();
            this.tbGasEmission.ResumeLayout(false);
            this.tbGasEmission.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel EmissionPanel;
        private System.Windows.Forms.Label lbEngineNumber;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.TableLayoutPanel tbGasEmission;
        private System.Windows.Forms.Label lbOTValue;
        private System.Windows.Forms.Label lbCOValue;
        private System.Windows.Forms.Label lbHCValue;
        private System.Windows.Forms.Label lbCO;
        private System.Windows.Forms.Label lbHC;
        private System.Windows.Forms.Label lbOT;
        private System.Windows.Forms.Label lbRPM;
        private System.Windows.Forms.Label lbRPMValue;
        private System.Windows.Forms.Label lbEmissionTitle;
        private System.Windows.Forms.Panel SelectFilePanel;
        private System.Windows.Forms.Button btnSaveEmission;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnReadPDF;
        private System.Windows.Forms.TextBox txtFilePath;
    }
}