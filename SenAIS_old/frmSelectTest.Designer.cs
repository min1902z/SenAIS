namespace SenAIS
{
    partial class frmSelectTest
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
            this.SelectTestPanel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.tbSelectTest = new System.Windows.Forms.TableLayoutPanel();
            this.cbResult = new System.Windows.Forms.CheckBox();
            this.cbTest4 = new System.Windows.Forms.CheckBox();
            this.cbTest3 = new System.Windows.Forms.CheckBox();
            this.cbTest2 = new System.Windows.Forms.CheckBox();
            this.cbTest1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTestAll = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.SelectTestPanel.SuspendLayout();
            this.tbSelectTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectTestPanel
            // 
            this.SelectTestPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SelectTestPanel.Controls.Add(this.btnCancel);
            this.SelectTestPanel.Controls.Add(this.btnStartTest);
            this.SelectTestPanel.Controls.Add(this.tbSelectTest);
            this.SelectTestPanel.Controls.Add(this.lbTitle);
            this.SelectTestPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectTestPanel.Location = new System.Drawing.Point(0, 0);
            this.SelectTestPanel.Name = "SelectTestPanel";
            this.SelectTestPanel.Size = new System.Drawing.Size(800, 450);
            this.SelectTestPanel.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(444, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 56);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStartTest.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTest.ForeColor = System.Drawing.Color.Blue;
            this.btnStartTest.Location = new System.Drawing.Point(170, 382);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(156, 56);
            this.btnStartTest.TabIndex = 2;
            this.btnStartTest.Text = "Bắt Đầu";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // tbSelectTest
            // 
            this.tbSelectTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSelectTest.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tbSelectTest.ColumnCount = 2;
            this.tbSelectTest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbSelectTest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbSelectTest.Controls.Add(this.cbResult, 1, 5);
            this.tbSelectTest.Controls.Add(this.cbTest4, 1, 4);
            this.tbSelectTest.Controls.Add(this.cbTest3, 1, 3);
            this.tbSelectTest.Controls.Add(this.cbTest2, 1, 2);
            this.tbSelectTest.Controls.Add(this.cbTest1, 1, 1);
            this.tbSelectTest.Controls.Add(this.label2, 0, 1);
            this.tbSelectTest.Controls.Add(this.label1, 0, 0);
            this.tbSelectTest.Controls.Add(this.cbTestAll, 1, 0);
            this.tbSelectTest.Controls.Add(this.label3, 0, 2);
            this.tbSelectTest.Controls.Add(this.label4, 0, 3);
            this.tbSelectTest.Controls.Add(this.label5, 0, 4);
            this.tbSelectTest.Controls.Add(this.label6, 0, 5);
            this.tbSelectTest.Location = new System.Drawing.Point(41, 69);
            this.tbSelectTest.Name = "tbSelectTest";
            this.tbSelectTest.RowCount = 6;
            this.tbSelectTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbSelectTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbSelectTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbSelectTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbSelectTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbSelectTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbSelectTest.Size = new System.Drawing.Size(705, 307);
            this.tbSelectTest.TabIndex = 1;
            // 
            // cbResult
            // 
            this.cbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbResult.AutoSize = true;
            this.cbResult.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbResult.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbResult.Location = new System.Drawing.Point(297, 270);
            this.cbResult.Name = "cbResult";
            this.cbResult.Size = new System.Drawing.Size(402, 17);
            this.cbResult.TabIndex = 11;
            this.cbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbResult.UseVisualStyleBackColor = true;
            // 
            // cbTest4
            // 
            this.cbTest4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTest4.AutoSize = true;
            this.cbTest4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTest4.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTest4.Location = new System.Drawing.Point(297, 218);
            this.cbTest4.Name = "cbTest4";
            this.cbTest4.Size = new System.Drawing.Size(402, 17);
            this.cbTest4.TabIndex = 10;
            this.cbTest4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTest4.UseVisualStyleBackColor = true;
            // 
            // cbTest3
            // 
            this.cbTest3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTest3.AutoSize = true;
            this.cbTest3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTest3.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTest3.Location = new System.Drawing.Point(297, 168);
            this.cbTest3.Name = "cbTest3";
            this.cbTest3.Size = new System.Drawing.Size(402, 17);
            this.cbTest3.TabIndex = 9;
            this.cbTest3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTest3.UseVisualStyleBackColor = true;
            // 
            // cbTest2
            // 
            this.cbTest2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTest2.AutoSize = true;
            this.cbTest2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTest2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTest2.Location = new System.Drawing.Point(297, 118);
            this.cbTest2.Name = "cbTest2";
            this.cbTest2.Size = new System.Drawing.Size(402, 17);
            this.cbTest2.TabIndex = 8;
            this.cbTest2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTest2.UseVisualStyleBackColor = true;
            // 
            // cbTest1
            // 
            this.cbTest1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTest1.AutoSize = true;
            this.cbTest1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTest1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTest1.Location = new System.Drawing.Point(297, 68);
            this.cbTest1.Name = "cbTest1";
            this.cbTest1.Size = new System.Drawing.Size(402, 17);
            this.cbTest1.TabIndex = 7;
            this.cbTest1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTest1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đèn/Trượt Ngang/Còi";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kiểm Tra Toàn Bộ";
            // 
            // cbTestAll
            // 
            this.cbTestAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTestAll.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTestAll.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTestAll.Location = new System.Drawing.Point(297, 14);
            this.cbTestAll.Name = "cbTestAll";
            this.cbTestAll.Size = new System.Drawing.Size(402, 24);
            this.cbTestAll.TabIndex = 1;
            this.cbTestAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTestAll.UseVisualStyleBackColor = true;
            this.cbTestAll.CheckedChanged += new System.EventHandler(this.cbTestAll_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "Góc Lái";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(6, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 37);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lực Phanh/ Khí Xả";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(6, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 37);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tốc Độ/ Độ ồn";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(6, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 37);
            this.label6.TabIndex = 6;
            this.label6.Text = "Trạm Kết Quả";
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbTitle.Location = new System.Drawing.Point(12, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(776, 53);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Chọn Trạm Kiểm Tra";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSelectTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectTestPanel);
            this.Name = "frmSelectTest";
            this.ShowIcon = false;
            this.Text = "Danh Mục Kiểm Tra";
            this.SelectTestPanel.ResumeLayout(false);
            this.tbSelectTest.ResumeLayout(false);
            this.tbSelectTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SelectTestPanel;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TableLayoutPanel tbSelectTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbTestAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbResult;
        private System.Windows.Forms.CheckBox cbTest4;
        private System.Windows.Forms.CheckBox cbTest3;
        private System.Windows.Forms.CheckBox cbTest2;
        private System.Windows.Forms.CheckBox cbTest1;
    }
}