namespace SenAIS
{
    partial class frmAboutUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAboutUs));
            this.AboutUsPanel = new System.Windows.Forms.Panel();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.AboutUsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // AboutUsPanel
            // 
            this.AboutUsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AboutUsPanel.BackgroundImage = global::SenAIS.Properties.Resources.sentek_NoBG;
            this.AboutUsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AboutUsPanel.Controls.Add(this.picQR);
            this.AboutUsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutUsPanel.Location = new System.Drawing.Point(0, 0);
            this.AboutUsPanel.Name = "AboutUsPanel";
            this.AboutUsPanel.Size = new System.Drawing.Size(1904, 1041);
            this.AboutUsPanel.TabIndex = 0;
            // 
            // picQR
            // 
            this.picQR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picQR.BackColor = System.Drawing.SystemColors.Control;
            this.picQR.BackgroundImage = global::SenAIS.Properties.Resources.QR_Sentek;
            this.picQR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picQR.InitialImage = ((System.Drawing.Image)(resources.GetObject("picQR.InitialImage")));
            this.picQR.Location = new System.Drawing.Point(1792, 929);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(100, 100);
            this.picQR.TabIndex = 0;
            this.picQR.TabStop = false;
            // 
            // frmAboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.AboutUsPanel);
            this.Name = "frmAboutUs";
            this.Text = "Sentek.vn";
            this.AboutUsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AboutUsPanel;
        private System.Windows.Forms.PictureBox picQR;
    }
}