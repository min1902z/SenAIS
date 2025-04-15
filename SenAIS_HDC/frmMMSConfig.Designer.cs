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
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbSteerMMS = new System.Windows.Forms.CheckBox();
            this.cbHLMMS = new System.Windows.Forms.CheckBox();
            this.cbDieselMMS = new System.Windows.Forms.CheckBox();
            this.cbPetrolMMS = new System.Windows.Forms.CheckBox();
            this.cbBrakeMMS = new System.Windows.Forms.CheckBox();
            this.cbNoiseMMS = new System.Windows.Forms.CheckBox();
            this.cbWhistleMMS = new System.Windows.Forms.CheckBox();
            this.cbSideSlipMMS = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassMMS = new System.Windows.Forms.TextBox();
            this.txtUserMMS = new System.Windows.Forms.TextBox();
            this.txtSaveURL = new System.Windows.Forms.TextBox();
            this.lbSaveURLTitle = new System.Windows.Forms.Label();
            this.txtLoginURL = new System.Windows.Forms.TextBox();
            this.lbLoginURLTitle = new System.Windows.Forms.Label();
            this.lbUserTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSpeedMMS = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbMMSConfigTitle = new System.Windows.Forms.Label();
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
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Blue;
            this.btnSave.Location = new System.Drawing.Point(636, 97);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 46);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.tableLayoutPanel1.Controls.Add(this.cbSteerMMS, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.cbHLMMS, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.cbDieselMMS, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.cbPetrolMMS, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbBrakeMMS, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbNoiseMMS, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbWhistleMMS, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbSideSlipMMS, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPassMMS, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUserMMS, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSaveURL, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbSaveURLTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLoginURL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbLoginURLTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbUserTitle, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbSpeedMMS, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 12);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(195, 101);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(435, 311);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // cbSteerMMS
            // 
            this.cbSteerMMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSteerMMS.AutoSize = true;
            this.cbSteerMMS.Location = new System.Drawing.Point(283, 392);
            this.cbSteerMMS.Name = "cbSteerMMS";
            this.cbSteerMMS.Size = new System.Drawing.Size(15, 14);
            this.cbSteerMMS.TabIndex = 44;
            this.cbSteerMMS.UseVisualStyleBackColor = true;
            // 
            // cbHLMMS
            // 
            this.cbHLMMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbHLMMS.AutoSize = true;
            this.cbHLMMS.Location = new System.Drawing.Point(283, 363);
            this.cbHLMMS.Name = "cbHLMMS";
            this.cbHLMMS.Size = new System.Drawing.Size(15, 14);
            this.cbHLMMS.TabIndex = 43;
            this.cbHLMMS.UseVisualStyleBackColor = true;
            // 
            // cbDieselMMS
            // 
            this.cbDieselMMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbDieselMMS.AutoSize = true;
            this.cbDieselMMS.Location = new System.Drawing.Point(283, 334);
            this.cbDieselMMS.Name = "cbDieselMMS";
            this.cbDieselMMS.Size = new System.Drawing.Size(15, 14);
            this.cbDieselMMS.TabIndex = 42;
            this.cbDieselMMS.UseVisualStyleBackColor = true;
            // 
            // cbPetrolMMS
            // 
            this.cbPetrolMMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbPetrolMMS.AutoSize = true;
            this.cbPetrolMMS.Location = new System.Drawing.Point(283, 305);
            this.cbPetrolMMS.Name = "cbPetrolMMS";
            this.cbPetrolMMS.Size = new System.Drawing.Size(15, 14);
            this.cbPetrolMMS.TabIndex = 41;
            this.cbPetrolMMS.UseVisualStyleBackColor = true;
            // 
            // cbBrakeMMS
            // 
            this.cbBrakeMMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbBrakeMMS.AutoSize = true;
            this.cbBrakeMMS.Location = new System.Drawing.Point(283, 276);
            this.cbBrakeMMS.Name = "cbBrakeMMS";
            this.cbBrakeMMS.Size = new System.Drawing.Size(15, 14);
            this.cbBrakeMMS.TabIndex = 39;
            this.cbBrakeMMS.UseVisualStyleBackColor = true;
            // 
            // cbNoiseMMS
            // 
            this.cbNoiseMMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbNoiseMMS.AutoSize = true;
            this.cbNoiseMMS.Location = new System.Drawing.Point(283, 247);
            this.cbNoiseMMS.Name = "cbNoiseMMS";
            this.cbNoiseMMS.Size = new System.Drawing.Size(15, 14);
            this.cbNoiseMMS.TabIndex = 38;
            this.cbNoiseMMS.UseVisualStyleBackColor = true;
            // 
            // cbWhistleMMS
            // 
            this.cbWhistleMMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbWhistleMMS.AutoSize = true;
            this.cbWhistleMMS.Location = new System.Drawing.Point(283, 218);
            this.cbWhistleMMS.Name = "cbWhistleMMS";
            this.cbWhistleMMS.Size = new System.Drawing.Size(15, 14);
            this.cbWhistleMMS.TabIndex = 37;
            this.cbWhistleMMS.UseVisualStyleBackColor = true;
            // 
            // cbSideSlipMMS
            // 
            this.cbSideSlipMMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSideSlipMMS.AutoSize = true;
            this.cbSideSlipMMS.Location = new System.Drawing.Point(283, 189);
            this.cbSideSlipMMS.Name = "cbSideSlipMMS";
            this.cbSideSlipMMS.Size = new System.Drawing.Size(15, 14);
            this.cbSideSlipMMS.TabIndex = 36;
            this.cbSideSlipMMS.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(5, 183);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 26);
            this.label2.TabIndex = 27;
            this.label2.Text = "SideSlip MMS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(5, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 25;
            this.label1.Text = "Speed MMS";
            // 
            // txtPassMMS
            // 
            this.txtPassMMS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPassMMS.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.txtPassMMS.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPassMMS.Location = new System.Drawing.Point(169, 118);
            this.txtPassMMS.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassMMS.Name = "txtPassMMS";
            this.txtPassMMS.Size = new System.Drawing.Size(242, 31);
            this.txtPassMMS.TabIndex = 24;
            // 
            // txtUserMMS
            // 
            this.txtUserMMS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtUserMMS.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.txtUserMMS.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtUserMMS.Location = new System.Drawing.Point(169, 80);
            this.txtUserMMS.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserMMS.Name = "txtUserMMS";
            this.txtUserMMS.Size = new System.Drawing.Size(242, 31);
            this.txtUserMMS.TabIndex = 23;
            // 
            // txtSaveURL
            // 
            this.txtSaveURL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSaveURL.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.txtSaveURL.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSaveURL.Location = new System.Drawing.Point(169, 42);
            this.txtSaveURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtSaveURL.Name = "txtSaveURL";
            this.txtSaveURL.Size = new System.Drawing.Size(242, 31);
            this.txtSaveURL.TabIndex = 22;
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
            // txtLoginURL
            // 
            this.txtLoginURL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLoginURL.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.txtLoginURL.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtLoginURL.Location = new System.Drawing.Point(169, 5);
            this.txtLoginURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoginURL.Multiline = true;
            this.txtLoginURL.Name = "txtLoginURL";
            this.txtLoginURL.Size = new System.Drawing.Size(242, 30);
            this.txtLoginURL.TabIndex = 18;
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
            // lbUserTitle
            // 
            this.lbUserTitle.AutoSize = true;
            this.lbUserTitle.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.lbUserTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbUserTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbUserTitle.Location = new System.Drawing.Point(5, 78);
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
            this.label3.Location = new System.Drawing.Point(5, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 26);
            this.label3.TabIndex = 21;
            this.label3.Text = "Password MMS";
            // 
            // cbSpeedMMS
            // 
            this.cbSpeedMMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSpeedMMS.AutoSize = true;
            this.cbSpeedMMS.Location = new System.Drawing.Point(283, 160);
            this.cbSpeedMMS.Name = "cbSpeedMMS";
            this.cbSpeedMMS.Size = new System.Drawing.Size(15, 14);
            this.cbSpeedMMS.TabIndex = 26;
            this.cbSpeedMMS.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(5, 212);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 26);
            this.label4.TabIndex = 28;
            this.label4.Text = "Whistle MMS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(5, 241);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 26);
            this.label5.TabIndex = 29;
            this.label5.Text = "Noise MMS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(5, 270);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 26);
            this.label6.TabIndex = 30;
            this.label6.Text = "BrakeForce MMS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(5, 299);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 26);
            this.label8.TabIndex = 32;
            this.label8.Text = "Petrol MMS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(5, 328);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 26);
            this.label9.TabIndex = 33;
            this.label9.Text = "Diesel MMS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(5, 357);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 26);
            this.label10.TabIndex = 34;
            this.label10.Text = "Headlights MMS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(5, 386);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 26);
            this.label11.TabIndex = 35;
            this.label11.Text = "SteerAngle MMS";
            // 
            // lbMMSConfigTitle
            // 
            this.lbMMSConfigTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbMMSConfigTitle.AutoSize = true;
            this.lbMMSConfigTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMMSConfigTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbMMSConfigTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMMSConfigTitle.Location = new System.Drawing.Point(182, 9);
            this.lbMMSConfigTitle.Name = "lbMMSConfigTitle";
            this.lbMMSConfigTitle.Size = new System.Drawing.Size(448, 78);
            this.lbMMSConfigTitle.TabIndex = 3;
            this.lbMMSConfigTitle.Text = "Tùy Chỉnh MMS";
            this.lbMMSConfigTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSpeedMMS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbSteerMMS;
        private System.Windows.Forms.CheckBox cbHLMMS;
        private System.Windows.Forms.CheckBox cbDieselMMS;
        private System.Windows.Forms.CheckBox cbPetrolMMS;
        private System.Windows.Forms.CheckBox cbBrakeMMS;
        private System.Windows.Forms.CheckBox cbNoiseMMS;
        private System.Windows.Forms.CheckBox cbWhistleMMS;
        private System.Windows.Forms.CheckBox cbSideSlipMMS;
    }
}