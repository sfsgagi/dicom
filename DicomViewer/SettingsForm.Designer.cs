namespace DicomViewer
{
    partial class SettingsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeExportDirectory = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblQualityHint = new System.Windows.Forms.Label();
            this.chbM4v = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownQuality = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFps = new System.Windows.Forms.NumericUpDown();
            this.chbMpg = new System.Windows.Forms.CheckBox();
            this.chbAvi = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbBmp = new System.Windows.Forms.CheckBox();
            this.chbJpg = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExportDir = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.btnChangePublish = new System.Windows.Forms.Button();
            this.lblPublishDir = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chbPng = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFps)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnChangeExportDirectory, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblExportDir, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnChangePublish, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPublishDir, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(438, 211);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Export dir:";
            // 
            // btnChangeExportDirectory
            // 
            this.btnChangeExportDirectory.Location = new System.Drawing.Point(360, 3);
            this.btnChangeExportDirectory.Name = "btnChangeExportDirectory";
            this.btnChangeExportDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnChangeExportDirectory.TabIndex = 2;
            this.btnChangeExportDirectory.Text = "Change...";
            this.btnChangeExportDirectory.UseVisualStyleBackColor = true;
            this.btnChangeExportDirectory.Click += new System.EventHandler(this.btnChangeExportDirectory_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(360, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(279, 185);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.chbPng);
            this.groupBox1.Controls.Add(this.lblQualityHint);
            this.groupBox1.Controls.Add(this.chbM4v);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDownQuality);
            this.groupBox1.Controls.Add(this.numericUpDownFps);
            this.groupBox1.Controls.Add(this.chbMpg);
            this.groupBox1.Controls.Add(this.chbAvi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chbBmp);
            this.groupBox1.Controls.Add(this.chbJpg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 118);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export parameters";
            // 
            // lblQualityHint
            // 
            this.lblQualityHint.AutoSize = true;
            this.lblQualityHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualityHint.Location = new System.Drawing.Point(265, 95);
            this.lblQualityHint.Name = "lblQualityHint";
            this.lblQualityHint.Size = new System.Drawing.Size(70, 13);
            this.lblQualityHint.TabIndex = 11;
            this.lblQualityHint.Text = "[1 is the best]";
            // 
            // chbM4v
            // 
            this.chbM4v.AutoSize = true;
            this.chbM4v.Location = new System.Drawing.Point(127, 95);
            this.chbM4v.Name = "chbM4v";
            this.chbM4v.Size = new System.Drawing.Size(49, 17);
            this.chbM4v.TabIndex = 10;
            this.chbM4v.Text = ".m4v";
            this.chbM4v.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Quality:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Compression options (ignored for .m4v):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "FPS:";
            // 
            // numericUpDownQuality
            // 
            this.numericUpDownQuality.Location = new System.Drawing.Point(267, 72);
            this.numericUpDownQuality.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDownQuality.Name = "numericUpDownQuality";
            this.numericUpDownQuality.Size = new System.Drawing.Size(156, 20);
            this.numericUpDownQuality.TabIndex = 6;
            this.numericUpDownQuality.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // numericUpDownFps
            // 
            this.numericUpDownFps.Location = new System.Drawing.Point(267, 47);
            this.numericUpDownFps.Name = "numericUpDownFps";
            this.numericUpDownFps.Size = new System.Drawing.Size(156, 20);
            this.numericUpDownFps.TabIndex = 6;
            this.numericUpDownFps.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // chbMpg
            // 
            this.chbMpg.AutoSize = true;
            this.chbMpg.Location = new System.Drawing.Point(127, 72);
            this.chbMpg.Name = "chbMpg";
            this.chbMpg.Size = new System.Drawing.Size(49, 17);
            this.chbMpg.TabIndex = 5;
            this.chbMpg.Text = ".mpg";
            this.chbMpg.UseVisualStyleBackColor = true;
            // 
            // chbAvi
            // 
            this.chbAvi.AutoSize = true;
            this.chbAvi.Location = new System.Drawing.Point(127, 48);
            this.chbAvi.Name = "chbAvi";
            this.chbAvi.Size = new System.Drawing.Size(43, 17);
            this.chbAvi.TabIndex = 4;
            this.chbAvi.Text = ".avi";
            this.chbAvi.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Video formats:";
            // 
            // chbBmp
            // 
            this.chbBmp.AutoSize = true;
            this.chbBmp.Location = new System.Drawing.Point(13, 72);
            this.chbBmp.Name = "chbBmp";
            this.chbBmp.Size = new System.Drawing.Size(49, 17);
            this.chbBmp.TabIndex = 2;
            this.chbBmp.Text = ".bmp";
            this.chbBmp.UseVisualStyleBackColor = true;
            // 
            // chbJpg
            // 
            this.chbJpg.AutoSize = true;
            this.chbJpg.Location = new System.Drawing.Point(13, 48);
            this.chbJpg.Name = "chbJpg";
            this.chbJpg.Size = new System.Drawing.Size(43, 17);
            this.chbJpg.TabIndex = 1;
            this.chbJpg.Text = ".jpg";
            this.chbJpg.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Image formats:";
            // 
            // lblExportDir
            // 
            this.lblExportDir.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExportDir.AutoSize = true;
            this.lblExportDir.Location = new System.Drawing.Point(67, 8);
            this.lblExportDir.Name = "lblExportDir";
            this.lblExportDir.Size = new System.Drawing.Size(0, 13);
            this.lblExportDir.TabIndex = 1;
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(3, 37);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(58, 13);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "Publish dir:";
            // 
            // btnChangePublish
            // 
            this.btnChangePublish.Location = new System.Drawing.Point(360, 32);
            this.btnChangePublish.Name = "btnChangePublish";
            this.btnChangePublish.Size = new System.Drawing.Size(75, 23);
            this.btnChangePublish.TabIndex = 6;
            this.btnChangePublish.Text = "Change...";
            this.btnChangePublish.UseVisualStyleBackColor = true;
            this.btnChangePublish.Click += new System.EventHandler(this.btnChangePublish_Click);
            // 
            // lblPublishDir
            // 
            this.lblPublishDir.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPublishDir.AutoSize = true;
            this.lblPublishDir.Location = new System.Drawing.Point(67, 37);
            this.lblPublishDir.Name = "lblPublishDir";
            this.lblPublishDir.Size = new System.Drawing.Size(0, 13);
            this.lblPublishDir.TabIndex = 7;
            // 
            // chbPng
            // 
            this.chbPng.AutoSize = true;
            this.chbPng.Location = new System.Drawing.Point(13, 95);
            this.chbPng.Name = "chbPng";
            this.chbPng.Size = new System.Drawing.Size(47, 17);
            this.chbPng.TabIndex = 12;
            this.chbPng.Text = ".png";
            this.chbPng.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblExportDir;
        private System.Windows.Forms.Button btnChangeExportDirectory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbBmp;
        private System.Windows.Forms.CheckBox chbJpg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownFps;
        private System.Windows.Forms.CheckBox chbMpg;
        private System.Windows.Forms.CheckBox chbAvi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownQuality;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chbM4v;
        private System.Windows.Forms.Label lblQualityHint;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnChangePublish;
        private System.Windows.Forms.Label lblPublishDir;
        private System.Windows.Forms.CheckBox chbPng;
    }
}