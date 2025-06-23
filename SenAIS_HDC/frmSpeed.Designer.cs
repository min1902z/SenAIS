namespace SenAIS
{
    partial class frmSpeed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpeed));
            this.SpeedPanel = new System.Windows.Forms.Panel();
            this.lbEnd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbStandard = new System.Windows.Forms.Label();
            this.lbStandardTitle = new System.Windows.Forms.Label();
            this.lbVinNumber = new System.Windows.Forms.Label();
            this.cbReady = new System.Windows.Forms.CheckBox();
            this.btnNextSpeed = new System.Windows.Forms.Button();
            this.btnPreSpeed = new System.Windows.Forms.Button();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbTitleSpeed = new System.Windows.Forms.Label();
            this.cbSensor = new System.Windows.Forms.CheckBox();
            this.SpeedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpeedPanel
            // 
            resources.ApplyResources(this.SpeedPanel, "SpeedPanel");
            this.SpeedPanel.Controls.Add(this.cbSensor);
            this.SpeedPanel.Controls.Add(this.lbEnd);
            this.SpeedPanel.Controls.Add(this.label1);
            this.SpeedPanel.Controls.Add(this.lbStandard);
            this.SpeedPanel.Controls.Add(this.lbStandardTitle);
            this.SpeedPanel.Controls.Add(this.lbVinNumber);
            this.SpeedPanel.Controls.Add(this.cbReady);
            this.SpeedPanel.Controls.Add(this.btnNextSpeed);
            this.SpeedPanel.Controls.Add(this.btnPreSpeed);
            this.SpeedPanel.Controls.Add(this.lbSpeed);
            this.SpeedPanel.Controls.Add(this.lbTitleSpeed);
            this.SpeedPanel.Name = "SpeedPanel";
            // 
            // lbEnd
            // 
            resources.ApplyResources(this.lbEnd, "lbEnd");
            this.lbEnd.ForeColor = System.Drawing.Color.Blue;
            this.lbEnd.Name = "lbEnd";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Name = "label1";
            // 
            // lbStandard
            // 
            resources.ApplyResources(this.lbStandard, "lbStandard");
            this.lbStandard.ForeColor = System.Drawing.Color.Red;
            this.lbStandard.Name = "lbStandard";
            // 
            // lbStandardTitle
            // 
            resources.ApplyResources(this.lbStandardTitle, "lbStandardTitle");
            this.lbStandardTitle.ForeColor = System.Drawing.Color.Red;
            this.lbStandardTitle.Name = "lbStandardTitle";
            // 
            // lbVinNumber
            // 
            resources.ApplyResources(this.lbVinNumber, "lbVinNumber");
            this.lbVinNumber.ForeColor = System.Drawing.Color.Red;
            this.lbVinNumber.Name = "lbVinNumber";
            // 
            // cbReady
            // 
            resources.ApplyResources(this.cbReady, "cbReady");
            this.cbReady.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbReady.Checked = true;
            this.cbReady.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReady.Name = "cbReady";
            this.cbReady.UseVisualStyleBackColor = false;
            // 
            // btnNextSpeed
            // 
            resources.ApplyResources(this.btnNextSpeed, "btnNextSpeed");
            this.btnNextSpeed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNextSpeed.ForeColor = System.Drawing.Color.Blue;
            this.btnNextSpeed.Name = "btnNextSpeed";
            this.btnNextSpeed.UseVisualStyleBackColor = false;
            this.btnNextSpeed.Click += new System.EventHandler(this.btnNextSpeed_Click);
            // 
            // btnPreSpeed
            // 
            resources.ApplyResources(this.btnPreSpeed, "btnPreSpeed");
            this.btnPreSpeed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPreSpeed.ForeColor = System.Drawing.Color.Blue;
            this.btnPreSpeed.Name = "btnPreSpeed";
            this.btnPreSpeed.UseVisualStyleBackColor = false;
            this.btnPreSpeed.Click += new System.EventHandler(this.btnPreSpeed_Click);
            // 
            // lbSpeed
            // 
            resources.ApplyResources(this.lbSpeed, "lbSpeed");
            this.lbSpeed.ForeColor = System.Drawing.Color.Blue;
            this.lbSpeed.Name = "lbSpeed";
            // 
            // lbTitleSpeed
            // 
            resources.ApplyResources(this.lbTitleSpeed, "lbTitleSpeed");
            this.lbTitleSpeed.ForeColor = System.Drawing.Color.Blue;
            this.lbTitleSpeed.Name = "lbTitleSpeed";
            // 
            // cbSensor
            // 
            resources.ApplyResources(this.cbSensor, "cbSensor");
            this.cbSensor.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbSensor.Checked = true;
            this.cbSensor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSensor.Name = "cbSensor";
            this.cbSensor.UseVisualStyleBackColor = false;
            // 
            // frmSpeed
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.SpeedPanel);
            this.Name = "frmSpeed";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSpeed_FormClosing);
            this.SpeedPanel.ResumeLayout(false);
            this.SpeedPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SpeedPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbStandard;
        private System.Windows.Forms.Label lbStandardTitle;
        private System.Windows.Forms.Label lbVinNumber;
        private System.Windows.Forms.CheckBox cbReady;
        private System.Windows.Forms.Button btnNextSpeed;
        private System.Windows.Forms.Button btnPreSpeed;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbTitleSpeed;
        private System.Windows.Forms.Label lbEnd;
        private System.Windows.Forms.CheckBox cbSensor;
    }
}