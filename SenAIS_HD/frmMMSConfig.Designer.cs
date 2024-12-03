namespace SenAIS
{
    partial class frmMMSConfig
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
            this.MMSConfigPanel = new System.Windows.Forms.Panel();
            this.lbMMSConfigTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbLoginURLTitle = new System.Windows.Forms.Label();
            this.txtLoginURL = new System.Windows.Forms.TextBox();
            this.lbSaveURLTitle = new System.Windows.Forms.Label();
            this.lbUserTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaveURL = new System.Windows.Forms.TextBox();
            this.txtUserMMS = new System.Windows.Forms.TextBox();
            this.txtPassMMS = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.MMSConfigPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MMSConfigPanel
            // 
            this.MMSConfigPanel.AutoScroll = true;
            this.MMSConfigPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MMSConfigPanel.Controls.Add(this.btnSave);
            this.MMSConfigPanel.Controls.Add(this.tableLayoutPanel1);
            this.MMSConfigPanel.Controls.Add(this.lbMMSConfigTitle);
            this.MMSConfigPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MMSConfigPanel.Location = new System.Drawing.Point(0, 0);
            this.MMSConfigPanel.Name = "MMSConfigPanel";
            this.MMSConfigPanel.Size = new System.Drawing.Size(800, 450);
            this.MMSConfigPanel.TabIndex = 0;
            // 
            // lbMMSConfigTitle
            // 
            this.lbMMSConfigTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbMMSConfigTitle.AutoSize = true;
            this.lbMMSConfigTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMMSConfigTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbMMSConfigTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMMSConfigTitle.Location = new System.Drawing.Point(182, 9);
            this.lbMMSConfigTitle.Name = "lbMMSConfigTitle";
            this.lbMMSConfigTitle.Size = new System.Drawing.Size(448, 78);
            this.lbMMSConfigTitle.TabIndex = 3;
            this.lbMMSConfigTitle.Text = "Tùy Chỉnh MMS";
            this.lbMMSConfigTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtPassMMS, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUserMMS, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSaveURL, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbSaveURLTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLoginURL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbLoginURLTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbUserTitle, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(195, 101);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(412, 156);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lbLoginURLTitle
            // 
            this.lbLoginURLTitle.AutoSize = true;
            this.lbLoginURLTitle.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.lbLoginURLTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbLoginURLTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbLoginURLTitle.Location = new System.Drawing.Point(5, 3);
            this.lbLoginURLTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLoginURLTitle.Name = "lbLoginURLTitle";
            this.lbLoginURLTitle.Size = new System.Drawing.Size(129, 26);
            this.lbLoginURLTitle.TabIndex = 5;
            this.lbLoginURLTitle.Text = "API Login URL";
            // 
            // txtLoginURL
            // 
            this.txtLoginURL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLoginURL.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.txtLoginURL.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtLoginURL.Location = new System.Drawing.Point(156, 5);
            this.txtLoginURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoginURL.Multiline = true;
            this.txtLoginURL.Name = "txtLoginURL";
            this.txtLoginURL.Size = new System.Drawing.Size(242, 30);
            this.txtLoginURL.TabIndex = 18;
            // 
            // lbSaveURLTitle
            // 
            this.lbSaveURLTitle.AutoSize = true;
            this.lbSaveURLTitle.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.lbSaveURLTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbSaveURLTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSaveURLTitle.Location = new System.Drawing.Point(5, 40);
            this.lbSaveURLTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSaveURLTitle.Name = "lbSaveURLTitle";
            this.lbSaveURLTitle.Size = new System.Drawing.Size(122, 26);
            this.lbSaveURLTitle.TabIndex = 19;
            this.lbSaveURLTitle.Text = "API Save URL";
            // 
            // lbUserTitle
            // 
            this.lbUserTitle.AutoSize = true;
            this.lbUserTitle.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.lbUserTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbUserTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbUserTitle.Location = new System.Drawing.Point(5, 71);
            this.lbUserTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUserTitle.Name = "lbUserTitle";
            this.lbUserTitle.Size = new System.Drawing.Size(101, 26);
            this.lbUserTitle.TabIndex = 20;
            this.lbUserTitle.Text = "User MMS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(5, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 26);
            this.label3.TabIndex = 21;
            this.label3.Text = "Password MMS";
            // 
            // txtSaveURL
            // 
            this.txtSaveURL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSaveURL.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.txtSaveURL.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSaveURL.Location = new System.Drawing.Point(156, 42);
            this.txtSaveURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtSaveURL.Name = "txtSaveURL";
            this.txtSaveURL.Size = new System.Drawing.Size(242, 31);
            this.txtSaveURL.TabIndex = 22;
            // 
            // txtUserMMS
            // 
            this.txtUserMMS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtUserMMS.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.txtUserMMS.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtUserMMS.Location = new System.Drawing.Point(156, 73);
            this.txtUserMMS.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserMMS.Name = "txtUserMMS";
            this.txtUserMMS.Size = new System.Drawing.Size(242, 31);
            this.txtUserMMS.TabIndex = 23;
            // 
            // txtPassMMS
            // 
            this.txtPassMMS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPassMMS.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.txtPassMMS.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPassMMS.Location = new System.Drawing.Point(156, 104);
            this.txtPassMMS.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassMMS.Name = "txtPassMMS";
            this.txtPassMMS.Size = new System.Drawing.Size(242, 31);
            this.txtPassMMS.TabIndex = 24;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.Location = new System.Drawing.Point(620, 101);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 46);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmMMSConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MMSConfigPanel);
            this.Name = "frmMMSConfig";
            this.ShowIcon = false;
            this.Text = "Tùy chỉnh MMS";
            this.Load += new System.EventHandler(this.frmMMSConfig_Load);
            this.MMSConfigPanel.ResumeLayout(false);
            this.MMSConfigPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MMSConfigPanel;
        private System.Windows.Forms.Label lbMMSConfigTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbLoginURLTitle;
        private System.Windows.Forms.TextBox txtLoginURL;
        private System.Windows.Forms.Label lbSaveURLTitle;
        private System.Windows.Forms.Label lbUserTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassMMS;
        private System.Windows.Forms.TextBox txtUserMMS;
        private System.Windows.Forms.TextBox txtSaveURL;
        private System.Windows.Forms.Button btnSave;
    }
}