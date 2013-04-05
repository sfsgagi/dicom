using System.Windows.Forms;
using System.Collections.Generic;
namespace DicomViewer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            DicomViewer.DicomUtils.ImageSettings imageSettings1 = new DicomViewer.DicomUtils.ImageSettings();
            DicomViewer.DicomUtils.ImageSettings imageSettings2 = new DicomViewer.DicomUtils.ImageSettings();
            DicomViewer.DicomUtils.ImageSettings imageSettings3 = new DicomViewer.DicomUtils.ImageSettings();
            DicomViewer.DicomUtils.ImageSettings imageSettings4 = new DicomViewer.DicomUtils.ImageSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.layoutPanel = new System.Windows.Forms.Panel();
            this.topLeft = new DicomViewer.PictureView();
            this.topRight = new DicomViewer.PictureView();
            this.bottomLeft = new DicomViewer.PictureView();
            this.bottomRight = new DicomViewer.PictureView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPickFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPreviousFrame = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelCurrentFrame = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonNextFrame = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxSeconds = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelSeconds = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.layoutToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.chooseLayoutToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.chooseLayoutToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonShowProperties = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOriginalImage = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.undoRedoOriginalToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonIncreaseContrast = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecreaseContrast = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonIncreaseBrightness = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecreaseBrightness = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonPickColor = new System.Windows.Forms.ToolStripButton();
            this.brushSizeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripPenWidth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonStartHandwrite = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonText = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStopAnnotating = new System.Windows.Forms.ToolStripButton();
            this.toolStripDeleteLastAnnotation = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCrop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonExportFrame = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonExportFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStopExporting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPublish = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStopPublishing = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSettings = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewDicomStudies = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.layoutPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // layoutPanel
            // 
            this.layoutPanel.Controls.Add(this.topLeft);
            this.layoutPanel.Controls.Add(this.topRight);
            this.layoutPanel.Controls.Add(this.bottomLeft);
            this.layoutPanel.Controls.Add(this.bottomRight);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(253, 113);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(771, 542);
            this.layoutPanel.TabIndex = 16;
            this.layoutPanel.SizeChanged += new System.EventHandler(this.layoutPanel_SizeChanged);
            // 
            // topLeft
            // 
            this.topLeft.AutoScroll = true;
            this.topLeft.BackColor = System.Drawing.SystemColors.ControlText;
            this.topLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            imageSettings1.Brightness = 0;
            imageSettings1.Contrast = 1;
            this.topLeft.ImageSettings = imageSettings1;
            this.topLeft.Location = new System.Drawing.Point(0, 0);
            this.topLeft.MainForm = null;
            this.topLeft.Name = "topLeft";
            this.topLeft.Size = new System.Drawing.Size(151, 155);
            this.topLeft.TabIndex = 0;
            // 
            // topRight
            // 
            this.topRight.AutoScroll = true;
            this.topRight.BackColor = System.Drawing.SystemColors.ControlText;
            this.topRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            imageSettings2.Brightness = 0;
            imageSettings2.Contrast = 1;
            this.topRight.ImageSettings = imageSettings2;
            this.topRight.Location = new System.Drawing.Point(0, 0);
            this.topRight.MainForm = null;
            this.topRight.Name = "topRight";
            this.topRight.Size = new System.Drawing.Size(151, 155);
            this.topRight.TabIndex = 1;
            // 
            // bottomLeft
            // 
            this.bottomLeft.AutoScroll = true;
            this.bottomLeft.BackColor = System.Drawing.SystemColors.ControlText;
            this.bottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            imageSettings3.Brightness = 0;
            imageSettings3.Contrast = 1;
            this.bottomLeft.ImageSettings = imageSettings3;
            this.bottomLeft.Location = new System.Drawing.Point(0, 0);
            this.bottomLeft.MainForm = null;
            this.bottomLeft.Name = "bottomLeft";
            this.bottomLeft.Size = new System.Drawing.Size(151, 155);
            this.bottomLeft.TabIndex = 2;
            // 
            // bottomRight
            // 
            this.bottomRight.AutoScroll = true;
            this.bottomRight.BackColor = System.Drawing.SystemColors.ControlText;
            this.bottomRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            imageSettings4.Brightness = 0;
            imageSettings4.Contrast = 1;
            this.bottomRight.ImageSettings = imageSettings4;
            this.bottomRight.Location = new System.Drawing.Point(0, 0);
            this.bottomRight.MainForm = null;
            this.bottomRight.Name = "bottomRight";
            this.bottomRight.Size = new System.Drawing.Size(151, 155);
            this.bottomRight.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1027, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(244, 16);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.layoutPanel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.treeViewDicomStudies, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1027, 700);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 80);
            this.panel1.TabIndex = 16;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPickFiles,
            this.toolStripButtonClear,
            this.toolStripSeparator1,
            this.toolStripButtonPreviousFrame,
            this.toolStripLabelCurrentFrame,
            this.toolStripButtonNextFrame,
            this.toolStripButtonPlay,
            this.toolStripComboBoxSeconds,
            this.toolStripLabelSeconds,
            this.toolStripButtonStop,
            this.layoutToolStripSeparator,
            this.chooseLayoutToolStripLabel,
            this.chooseLayoutToolStripComboBox,
            this.toolStripButtonShowProperties,
            this.toolStripSeparator6,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripButtonOriginalImage});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1021, 39);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonPickFiles
            // 
            this.toolStripButtonPickFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPickFiles.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPickFiles.Image")));
            this.toolStripButtonPickFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPickFiles.Name = "toolStripButtonPickFiles";
            this.toolStripButtonPickFiles.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonPickFiles.Text = "Pick dicom files...";
            this.toolStripButtonPickFiles.Click += new System.EventHandler(this.toolStripButtonPickFiles_Click);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClear.Image")));
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonClear.Text = "Clear list...";
            this.toolStripButtonClear.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonPreviousFrame
            // 
            this.toolStripButtonPreviousFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPreviousFrame.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPreviousFrame.Image")));
            this.toolStripButtonPreviousFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPreviousFrame.Name = "toolStripButtonPreviousFrame";
            this.toolStripButtonPreviousFrame.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonPreviousFrame.Text = "Previous frame";
            this.toolStripButtonPreviousFrame.ToolTipText = "Previous frame";
            this.toolStripButtonPreviousFrame.Click += new System.EventHandler(this.toolStripButtonPreviousFrame_Click);
            // 
            // toolStripLabelCurrentFrame
            // 
            this.toolStripLabelCurrentFrame.AutoSize = false;
            this.toolStripLabelCurrentFrame.Name = "toolStripLabelCurrentFrame";
            this.toolStripLabelCurrentFrame.Size = new System.Drawing.Size(36, 36);
            this.toolStripLabelCurrentFrame.Text = "0/0";
            // 
            // toolStripButtonNextFrame
            // 
            this.toolStripButtonNextFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNextFrame.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNextFrame.Image")));
            this.toolStripButtonNextFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNextFrame.Name = "toolStripButtonNextFrame";
            this.toolStripButtonNextFrame.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonNextFrame.Text = "Next frame";
            this.toolStripButtonNextFrame.ToolTipText = "Next frame";
            this.toolStripButtonNextFrame.Click += new System.EventHandler(this.toolStripButtonNextFrame_Click);
            // 
            // toolStripButtonPlay
            // 
            this.toolStripButtonPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPlay.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlay.Image")));
            this.toolStripButtonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlay.Name = "toolStripButtonPlay";
            this.toolStripButtonPlay.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonPlay.Text = "Play";
            this.toolStripButtonPlay.ToolTipText = "Play";
            this.toolStripButtonPlay.Click += new System.EventHandler(this.toolStripButtonPlay_Click);
            // 
            // toolStripComboBoxSeconds
            // 
            this.toolStripComboBoxSeconds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxSeconds.DropDownWidth = 42;
            this.toolStripComboBoxSeconds.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "20",
            "25",
            "30"});
            this.toolStripComboBoxSeconds.Name = "toolStripComboBoxSeconds";
            this.toolStripComboBoxSeconds.Size = new System.Drawing.Size(75, 39);
            this.toolStripComboBoxSeconds.ToolTipText = "Frame Change Interval";
            this.toolStripComboBoxSeconds.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxSeconds_SelectedIndexChanged);
            // 
            // toolStripLabelSeconds
            // 
            this.toolStripLabelSeconds.Name = "toolStripLabelSeconds";
            this.toolStripLabelSeconds.Size = new System.Drawing.Size(22, 36);
            this.toolStripLabelSeconds.Text = "fps";
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.ToolTipText = "Stop";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // layoutToolStripSeparator
            // 
            this.layoutToolStripSeparator.Name = "layoutToolStripSeparator";
            this.layoutToolStripSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // chooseLayoutToolStripLabel
            // 
            this.chooseLayoutToolStripLabel.Name = "chooseLayoutToolStripLabel";
            this.chooseLayoutToolStripLabel.Size = new System.Drawing.Size(40, 36);
            this.chooseLayoutToolStripLabel.Text = "Layout";
            // 
            // chooseLayoutToolStripComboBox
            // 
            this.chooseLayoutToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseLayoutToolStripComboBox.Name = "chooseLayoutToolStripComboBox";
            this.chooseLayoutToolStripComboBox.Size = new System.Drawing.Size(121, 39);
            this.chooseLayoutToolStripComboBox.ToolTipText = "Choose Layout";
            this.chooseLayoutToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseLayoutToolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripButtonShowProperties
            // 
            this.toolStripButtonShowProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowProperties.Enabled = false;
            this.toolStripButtonShowProperties.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowProperties.Image")));
            this.toolStripButtonShowProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowProperties.Name = "toolStripButtonShowProperties";
            this.toolStripButtonShowProperties.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonShowProperties.Text = "Show properties";
            this.toolStripButtonShowProperties.Click += new System.EventHandler(this.toolStripButtonShowProperties_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Enabled = false;
            this.toolStripButtonUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndo.Image")));
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonUndo.Text = "Undo";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Enabled = false;
            this.toolStripButtonRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRedo.Image")));
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRedo.Text = "Redo";
            this.toolStripButtonRedo.Click += new System.EventHandler(this.toolStripButtonRedo_Click);
            // 
            // toolStripButtonOriginalImage
            // 
            this.toolStripButtonOriginalImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOriginalImage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOriginalImage.Image")));
            this.toolStripButtonOriginalImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOriginalImage.Name = "toolStripButtonOriginalImage";
            this.toolStripButtonOriginalImage.Size = new System.Drawing.Size(80, 36);
            this.toolStripButtonOriginalImage.Text = "Original Image";
            this.toolStripButtonOriginalImage.Click += new System.EventHandler(this.toolStripButtonOriginalImage_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoRedoOriginalToolStripSeparator,
            this.toolStripLabel1,
            this.toolStripButtonIncreaseContrast,
            this.toolStripButtonDecreaseContrast,
            this.toolStripButtonIncreaseBrightness,
            this.toolStripButtonDecreaseBrightness,
            this.toolStripLabel2,
            this.toolStripButtonPickColor,
            this.brushSizeToolStripLabel,
            this.toolStripPenWidth,
            this.toolStripButtonStartHandwrite,
            this.toolStripButtonText,
            this.toolStripButtonSelect,
            this.toolStripButtonRuler,
            this.toolStripButtonZoomIn,
            this.toolStripButtonZoomOut,
            this.toolStripButtonStopAnnotating,
            this.toolStripDeleteLastAnnotation,
            this.toolStripButtonCrop,
            this.toolStripSeparator5,
            this.toolStripButtonExportFrame,
            this.toolStripSeparator2,
            this.toolStripButtonExportFiles,
            this.toolStripButtonStopExporting,
            this.toolStripSeparator4,
            this.toolStripButtonPublish,
            this.toolStripButtonStopPublishing,
            this.toolStripSeparator3,
            this.toolStripButtonSettings});
            this.toolStrip2.Location = new System.Drawing.Point(0, 41);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1021, 39);
            this.toolStrip2.TabIndex = 17;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // undoRedoOriginalToolStripSeparator
            // 
            this.undoRedoOriginalToolStripSeparator.Name = "undoRedoOriginalToolStripSeparator";
            this.undoRedoOriginalToolStripSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 36);
            this.toolStripLabel1.Text = "Filters:";
            // 
            // toolStripButtonIncreaseContrast
            // 
            this.toolStripButtonIncreaseContrast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIncreaseContrast.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonIncreaseContrast.Image")));
            this.toolStripButtonIncreaseContrast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIncreaseContrast.Name = "toolStripButtonIncreaseContrast";
            this.toolStripButtonIncreaseContrast.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonIncreaseContrast.Text = "Increase contrast";
            this.toolStripButtonIncreaseContrast.Click += new System.EventHandler(this.toolStripButtonIncreaseContrast_Click);
            // 
            // toolStripButtonDecreaseContrast
            // 
            this.toolStripButtonDecreaseContrast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDecreaseContrast.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDecreaseContrast.Image")));
            this.toolStripButtonDecreaseContrast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecreaseContrast.Name = "toolStripButtonDecreaseContrast";
            this.toolStripButtonDecreaseContrast.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonDecreaseContrast.Text = "Reduce contrast";
            this.toolStripButtonDecreaseContrast.Click += new System.EventHandler(this.toolStripButtonDecreaseContrast_Click);
            // 
            // toolStripButtonIncreaseBrightness
            // 
            this.toolStripButtonIncreaseBrightness.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIncreaseBrightness.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonIncreaseBrightness.Image")));
            this.toolStripButtonIncreaseBrightness.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIncreaseBrightness.Name = "toolStripButtonIncreaseBrightness";
            this.toolStripButtonIncreaseBrightness.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonIncreaseBrightness.Text = "Increase brightness";
            this.toolStripButtonIncreaseBrightness.Click += new System.EventHandler(this.toolStripButtonIncreaseBrightness_Click);
            // 
            // toolStripButtonDecreaseBrightness
            // 
            this.toolStripButtonDecreaseBrightness.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDecreaseBrightness.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDecreaseBrightness.Image")));
            this.toolStripButtonDecreaseBrightness.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecreaseBrightness.Name = "toolStripButtonDecreaseBrightness";
            this.toolStripButtonDecreaseBrightness.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonDecreaseBrightness.Text = "Decrease brightness";
            this.toolStripButtonDecreaseBrightness.Click += new System.EventHandler(this.toolStripButtonDecreaseBrightness_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 36);
            this.toolStripLabel2.Text = "Annotate:";
            // 
            // toolStripButtonPickColor
            // 
            this.toolStripButtonPickColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPickColor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPickColor.Image")));
            this.toolStripButtonPickColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPickColor.Name = "toolStripButtonPickColor";
            this.toolStripButtonPickColor.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonPickColor.Text = "Pick annotation color";
            this.toolStripButtonPickColor.Click += new System.EventHandler(this.toolStripButtonPickColor_Click);
            // 
            // brushSizeToolStripLabel
            // 
            this.brushSizeToolStripLabel.Name = "brushSizeToolStripLabel";
            this.brushSizeToolStripLabel.Size = new System.Drawing.Size(56, 36);
            this.brushSizeToolStripLabel.Text = "Brush Size";
            this.brushSizeToolStripLabel.ToolTipText = "Brush Size";
            // 
            // toolStripPenWidth
            // 
            this.toolStripPenWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripPenWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.toolStripPenWidth.Name = "toolStripPenWidth";
            this.toolStripPenWidth.Size = new System.Drawing.Size(75, 39);
            this.toolStripPenWidth.ToolTipText = "Brush Size";
            this.toolStripPenWidth.SelectedIndexChanged += new System.EventHandler(this.toolStripPenWidth_SelectedIndexChanged);
            // 
            // toolStripButtonStartHandwrite
            // 
            this.toolStripButtonStartHandwrite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStartHandwrite.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStartHandwrite.Image")));
            this.toolStripButtonStartHandwrite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartHandwrite.Name = "toolStripButtonStartHandwrite";
            this.toolStripButtonStartHandwrite.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonStartHandwrite.Text = "Start handwrite annotations";
            this.toolStripButtonStartHandwrite.Click += new System.EventHandler(this.toolStripButtonStartHandwrite_Click);
            // 
            // toolStripButtonText
            // 
            this.toolStripButtonText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonText.Image")));
            this.toolStripButtonText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonText.Name = "toolStripButtonText";
            this.toolStripButtonText.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonText.Text = "Start text annotations";
            this.toolStripButtonText.Click += new System.EventHandler(this.toolStripButtonText_Click);
            // 
            // toolStripButtonSelect
            // 
            this.toolStripButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelect.Image")));
            this.toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelect.Name = "toolStripButtonSelect";
            this.toolStripButtonSelect.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSelect.Text = "Select";
            this.toolStripButtonSelect.Click += new System.EventHandler(this.toolStripButtonSelect_Click);
            // 
            // toolStripButtonRuler
            // 
            this.toolStripButtonRuler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRuler.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRuler.Image")));
            this.toolStripButtonRuler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRuler.Name = "toolStripButtonRuler";
            this.toolStripButtonRuler.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRuler.Text = "Ruller";
            this.toolStripButtonRuler.Click += new System.EventHandler(this.toolStripButtonRuler_Click);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomIn.Image")));
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonZoomIn.Text = "toolStripButton1";
            this.toolStripButtonZoomIn.ToolTipText = "Zoom In";
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripButtonZoomIn_Click);
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomOut.Image")));
            this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonZoomOut.Text = "Zoom Out";
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.toolStripButtonZoomOut_Click);
            // 
            // toolStripButtonStopAnnotating
            // 
            this.toolStripButtonStopAnnotating.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStopAnnotating.Enabled = false;
            this.toolStripButtonStopAnnotating.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStopAnnotating.Image")));
            this.toolStripButtonStopAnnotating.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStopAnnotating.Name = "toolStripButtonStopAnnotating";
            this.toolStripButtonStopAnnotating.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonStopAnnotating.Text = "Stop";
            this.toolStripButtonStopAnnotating.Click += new System.EventHandler(this.toolStripButtonStopAnnotating_Click);
            // 
            // toolStripDeleteLastAnnotation
            // 
            this.toolStripDeleteLastAnnotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDeleteLastAnnotation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleteLastAnnotation.Image")));
            this.toolStripDeleteLastAnnotation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeleteLastAnnotation.Name = "toolStripDeleteLastAnnotation";
            this.toolStripDeleteLastAnnotation.Size = new System.Drawing.Size(36, 36);
            this.toolStripDeleteLastAnnotation.Text = "Delete last annotation";
            this.toolStripDeleteLastAnnotation.Click += new System.EventHandler(this.toolStripDeleteLastAnnotation_Click);
            // 
            // toolStripButtonCrop
            // 
            this.toolStripButtonCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCrop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCrop.Image")));
            this.toolStripButtonCrop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCrop.Name = "toolStripButtonCrop";
            this.toolStripButtonCrop.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonCrop.Text = "Crop Image";
            this.toolStripButtonCrop.Click += new System.EventHandler(this.toolStripButtonCrop_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonExportFrame
            // 
            this.toolStripButtonExportFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportFrame.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExportFrame.Image")));
            this.toolStripButtonExportFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportFrame.Name = "toolStripButtonExportFrame";
            this.toolStripButtonExportFrame.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonExportFrame.Text = "Export current frame";
            this.toolStripButtonExportFrame.Click += new System.EventHandler(this.toolStripButtonExportFrame_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonExportFiles
            // 
            this.toolStripButtonExportFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportFiles.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExportFiles.Image")));
            this.toolStripButtonExportFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportFiles.Name = "toolStripButtonExportFiles";
            this.toolStripButtonExportFiles.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonExportFiles.Text = "Export files from list";
            this.toolStripButtonExportFiles.Click += new System.EventHandler(this.toolStripButtonExportFiles_Click);
            // 
            // toolStripButtonStopExporting
            // 
            this.toolStripButtonStopExporting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStopExporting.Enabled = false;
            this.toolStripButtonStopExporting.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStopExporting.Image")));
            this.toolStripButtonStopExporting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStopExporting.Name = "toolStripButtonStopExporting";
            this.toolStripButtonStopExporting.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonStopExporting.Text = "Stop export";
            this.toolStripButtonStopExporting.Click += new System.EventHandler(this.toolStripStopExportButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonPublish
            // 
            this.toolStripButtonPublish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPublish.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPublish.Image")));
            this.toolStripButtonPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPublish.Name = "toolStripButtonPublish";
            this.toolStripButtonPublish.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonPublish.Text = "Publish export directory";
            this.toolStripButtonPublish.Click += new System.EventHandler(this.toolStripButtonPublish_Click);
            // 
            // toolStripButtonStopPublishing
            // 
            this.toolStripButtonStopPublishing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStopPublishing.Enabled = false;
            this.toolStripButtonStopPublishing.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStopPublishing.Image")));
            this.toolStripButtonStopPublishing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStopPublishing.Name = "toolStripButtonStopPublishing";
            this.toolStripButtonStopPublishing.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonStopPublishing.Text = "Stop publishing";
            this.toolStripButtonStopPublishing.Click += new System.EventHandler(this.toolStripButtonStopPublishing_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonSettings
            // 
            this.toolStripButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSettings.Image")));
            this.toolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSettings.Name = "toolStripButtonSettings";
            this.toolStripButtonSettings.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSettings.Text = "Open settings dialog";
            this.toolStripButtonSettings.Click += new System.EventHandler(this.toolStripButtonSettings_Click);
            // 
            // menuStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip1, 2);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1027, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonPickFiles_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // treeViewDicomStudies
            // 
            this.treeViewDicomStudies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDicomStudies.ImageIndex = 0;
            this.treeViewDicomStudies.ImageList = this.imageList1;
            this.treeViewDicomStudies.Location = new System.Drawing.Point(3, 113);
            this.treeViewDicomStudies.Name = "treeViewDicomStudies";
            this.treeViewDicomStudies.SelectedImageIndex = 0;
            this.treeViewDicomStudies.Size = new System.Drawing.Size(244, 542);
            this.treeViewDicomStudies.TabIndex = 16;
            this.treeViewDicomStudies.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewDicomStudies_MouseUp);
            this.treeViewDicomStudies.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDicomStudies_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "lreminder.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "image.png");
            this.imageList1.Images.SetKeyName(3, "video.png");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DicomViewer";
            this.layoutPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }




        void layoutPanel_SizeChanged(object sender, System.EventArgs e)
        {
            this.DoReposition();
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel layoutPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPickFiles;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPreviousFrame;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCurrentFrame;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextFrame;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlay;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonSettings;
        private System.Windows.Forms.TreeView treeViewDicomStudies;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStopExporting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonPublish;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStripButton toolStripButtonStopPublishing;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportFrame;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButtonIncreaseContrast;
        private System.Windows.Forms.ToolStripButton toolStripButtonDecreaseContrast;
        private System.Windows.Forms.ToolStripButton toolStripButtonIncreaseBrightness;
        private System.Windows.Forms.ToolStripButton toolStripButtonDecreaseBrightness;
        private System.Windows.Forms.ToolStripButton toolStripButtonPickColor;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartHandwrite;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonStopAnnotating;
        private System.Windows.Forms.ToolStripButton toolStripDeleteLastAnnotation;
        private ToolStripComboBox toolStripPenWidth;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;

        private System.Windows.Forms.ToolStripButton toolStripButtonShowProperties;
        private PictureView topLeft;
        private PictureView topRight;
        private PictureView bottomLeft;
        private PictureView bottomRight;
        private ToolStripLabel toolStripLabelSeconds;
        private ToolStripComboBox toolStripComboBoxSeconds;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripButtonUndo;
        private ToolStripButton toolStripButtonRedo;
        private ToolStripButton toolStripButtonOriginalImage;
        private ToolStripSeparator undoRedoOriginalToolStripSeparator;
        private ToolStripSeparator layoutToolStripSeparator;
        private ToolStripLabel chooseLayoutToolStripLabel;
        private ToolStripComboBox chooseLayoutToolStripComboBox;
        private ToolStripLabel brushSizeToolStripLabel;
        private ToolStripButton toolStripButtonCrop;
        private ToolStripButton toolStripButtonZoomIn;
        private ToolStripButton toolStripButtonZoomOut;
        private ToolStripButton toolStripButtonSelect;
        private ToolStripButton toolStripButtonRuler;
        private ToolStrip toolStrip2;
        private Panel panel1;
        private ToolStripButton toolStripButton1;

    }
}

