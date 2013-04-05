namespace DicomViewer
{
    partial class PictureView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picturePanel = new System.Windows.Forms.Panel();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.annotationList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picturePanel
            // 
            this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePanel.AutoScroll = true;
            this.picturePanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picturePanel.Controls.Add(this.previewBox);
            this.picturePanel.Location = new System.Drawing.Point(0, 0);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(151, 133);
            this.picturePanel.TabIndex = 0;
            this.picturePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.previewBox_MouseClick);
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(0, 0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(150, 133);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            this.previewBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.previewBox_MouseMove);
            this.previewBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.previewBox_MouseClick);
            this.previewBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.previewBox_MouseDown);
            this.previewBox.Paint += new System.Windows.Forms.PaintEventHandler(this.previewBox_Paint);
            this.previewBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.previewBox_MouseUp);
            // 
            // annotationList
            // 
            this.annotationList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.annotationList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.annotationList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.annotationList.LabelEdit = true;
            this.annotationList.Location = new System.Drawing.Point(0, 134);
            this.annotationList.Name = "annotationList";
            this.annotationList.Size = new System.Drawing.Size(150, 21);
            this.annotationList.TabIndex = 1;
            this.annotationList.UseCompatibleStateImageBehavior = false;
            this.annotationList.View = System.Windows.Forms.View.Details;
            this.annotationList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.annotationsBox_AfterLabelEdit);
            // 
            // PictureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.annotationList);
            this.Controls.Add(this.picturePanel);
            this.Name = "PictureView";
            this.Size = new System.Drawing.Size(151, 155);
            this.picturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.ListView annotationList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
