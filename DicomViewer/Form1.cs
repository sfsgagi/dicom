using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.ImageViewer.StudyManagement;
using ClearCanvas.ImageViewer;
using AviFile;
using System.Drawing.Imaging;
using System.IO;
using DicomViewer.Properties;
using log4net;
using DicomUtils;
using System.Diagnostics;
using DicomViewer.DicomUtils;
using AForge.Imaging.Filters;
using System.Threading;
using ClearCanvas.Dicom;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Logging.config", Watch = true)]
namespace DicomViewer
{
    public partial class MainForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private SettingsForm settingsForm;
        private PickStudiesDialog pickStudiesDialog;
        private ExportManager exportManager;



        public Color currentColor = Color.Red;
        public bool isFreehandStarted;

        public bool isTextStarted;

        private TreeNode currentNode;
        public AnnotateTextForm annotateTextForm;
        private DicomPropertiesForm dicomPropertiesForm;
        private LayoutType currentLayout;
        private System.Timers.Timer timer;
        public delegate void ToolStripProgressBarDelegate(int currentValue, int maximum);
        private PictureView currentView;
        public int BrushSize;
        public MainForm()
        {

            InitializeComponent();
            InitializeBackgroundWorker1();
            InitializeBackgroundWorker2();
            InitializeBackgroundWorker3();
            InitializeContextMenu();
            settingsForm = new SettingsForm();
            pickStudiesDialog = new PickStudiesDialog();
            annotateTextForm = new AnnotateTextForm();
            dicomPropertiesForm = new DicomPropertiesForm();
            resetFilters();
            resetAnnotations();
            this.PostInitialize();

        }

        private void PostInitialize()
        {
            this.topLeft.MainForm = this;
            this.topRight.MainForm = this;
            this.bottomLeft.MainForm = this;
            this.bottomRight.MainForm = this;
            this.toolStripPenWidth.SelectedIndex = 0;
            this.toolStripComboBoxSeconds.SelectedIndex = 0;
            this.currentLayout = LayoutType.TwoVerticalPictures;
            this.currentView = this.topLeft;
            this.currentView.BorderStyle = BorderStyle.None;
            this.currentView.Padding = new Padding(2);
            this.chooseLayoutToolStripComboBox.Items.AddRange(new string[] {
            "One Picture ",
            "Two Horizontal Splited Pictures",
            "Two Vertical Splited  Pictures",
            "Four Pictures"});
            this.toolStripPenWidth.SelectedIndex = 2;
            this.BrushSize = 3;
            this.chooseLayoutToolStripComboBox.SelectedIndex = 2;
            this.PositionViews();

            string path = DriveInfo.GetDrives().First(x => x.DriveType == DriveType.Fixed).Name;
            if (string.IsNullOrEmpty(Settings.Default.ExportPath))
            {
                Settings.Default.ExportPath = Path.Combine(path, "export");
            }
            if (string.IsNullOrEmpty(Settings.Default.PublishPath))
            {
                Settings.Default.PublishPath = Path.Combine(path, "publish");
            }
        }

        private void PositionViews()
        {
            this.toolStripButtonSelect.Checked = false;
            this.toolStripButtonRuler.Checked = false;
            this.layoutPanel.Controls.Clear();
            this.layoutPanel.Invalidate();
            this.topLeft = new PictureView();
            this.topLeft.MainForm = this;
            this.topRight = new PictureView();
            this.topRight.MainForm = this;
            this.bottomLeft = new PictureView();
            this.bottomLeft.MainForm = this;
            this.bottomRight = new PictureView();
            this.bottomRight.MainForm = this;
            this.currentView = this.topLeft;
            this.currentView.BorderStyle = BorderStyle.None;
            this.currentView.Padding = new Padding(2);
            DoReposition();
            this.layoutPanel.Invalidate();
        }

        private void DoReposition()
        {
            if (this.currentLayout == LayoutType.FourPictures)
            {
                this.SuspendLayout();
                var width = (this.layoutPanel.Width - 10) / 2;
                var height = (this.layoutPanel.Height - 10) / 2;

                this.topLeft.Enabled = true;
                this.topLeft.Width = width;
                this.topLeft.Height = height;
                this.topLeft.Left = 0;
                this.topLeft.Top = 0;

                this.topRight.Enabled = true;
                this.topRight.Width = width;
                this.topRight.Height = height;
                this.topRight.Left = this.layoutPanel.Width - width; ;
                this.topRight.Top = 0;

                this.bottomLeft.Enabled = true;
                this.bottomLeft.Width = width;
                this.bottomLeft.Height = height;
                this.bottomLeft.Top = this.layoutPanel.Height - height;
                this.bottomLeft.Left = 0;

                this.bottomRight.Enabled = true;
                this.bottomRight.Width = width;
                this.bottomRight.Height = height;
                this.bottomRight.Left = this.layoutPanel.Width - width; ;
                this.bottomRight.Top = this.layoutPanel.Height - height;
                this.layoutPanel.Controls.AddRange(new Control[] { 
                    this.topLeft, this.topRight, this.bottomLeft, this.bottomRight });
                this.ResumeLayout();
            }
            else if (this.currentLayout == LayoutType.OnePicture)
            {
                this.SuspendLayout();
                var width = this.layoutPanel.Width;
                var height = this.layoutPanel.Height;

                this.topRight.Enabled = false;
                this.bottomLeft.Enabled = false;
                this.bottomRight.Enabled = false;

                this.topLeft.Enabled = true;
                this.topLeft.Width = width;
                this.topLeft.Height = height;
                this.topLeft.Left = 0;
                this.topLeft.Top = 0;

                this.layoutPanel.Controls.AddRange(new Control[] { 
                    this.topLeft});
                this.ResumeLayout();
            }
            else if (this.currentLayout == LayoutType.TwoHorizontalPictures)
            {
                this.SuspendLayout();
                var width = this.layoutPanel.ClientSize.Width;
                var height = (this.layoutPanel.ClientSize.Height - 10) / 2;
                this.topRight.Enabled = false;
                this.bottomRight.Enabled = false;

                this.topLeft.Enabled = true;
                this.topLeft.Width = width;
                this.topLeft.Height = height;
                this.topLeft.Left = 0;
                this.topLeft.Top = 0;



                this.bottomLeft.Enabled = true;
                this.bottomLeft.Width = width;
                this.bottomLeft.Height = height;
                this.bottomLeft.Top = this.layoutPanel.Height - height;
                this.bottomLeft.Left = 0;

                this.layoutPanel.Controls.AddRange(new Control[] { this.topLeft, this.bottomLeft });
                this.ResumeLayout();
            }
            else if (this.currentLayout == LayoutType.TwoVerticalPictures)
            {
                this.SuspendLayout();
                var width = (this.layoutPanel.Width - 10) / 2;
                var height = this.layoutPanel.Height;


                this.bottomLeft.Enabled = false;
                this.bottomRight.Enabled = false;

                this.topLeft.Enabled = true;
                this.topLeft.Width = width;
                this.topLeft.Height = height;
                this.topLeft.Left = 0;
                this.topLeft.Top = 0;

                this.topRight.Enabled = true;
                this.topRight.Width = width;
                this.topRight.Height = height;
                this.topRight.Left = this.layoutPanel.Width - width; ;
                this.topRight.Top = 0;

                this.layoutPanel.Controls.AddRange(new Control[] { this.topLeft, this.topRight });
                this.ResumeLayout();
            }
        }

        private void InitializeBackgroundWorker3()
        {
            backgroundWorker3 = new System.ComponentModel.BackgroundWorker();

            backgroundWorker3.DoWork +=
                new DoWorkEventHandler(backgroundWorker3_DoWork);
            backgroundWorker3.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker3_RunWorkerCompleted);
        }

        private void InitializeContextMenu()
        {
            contextMenu.Items.Add("Export");
            contextMenu.Items.Add("-");
            contextMenu.Items.Add("Remove");
        }



        private void InitializeBackgroundWorker1()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);
        }

        private void InitializeBackgroundWorker2()
        {
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
            backgroundWorker2.DoWork +=
                new DoWorkEventHandler(backgroundWorker2_DoWork);
            backgroundWorker2.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker2_RunWorkerCompleted);
            backgroundWorker2.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker2_ProgressChanged);
        }

        private void backgroundWorker1_DoWork(object sender,
            DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            exportManager = new ExportManager(treeViewDicomStudies.Nodes,
                toolStripProgressBar, new ToolStripProgressBarDelegate(UpdateToolStrip));
            exportManager.doExporting(worker);
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void backgroundWorker2_DoWork(object sender,
            DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            DirectoryInfo sourceDir = new DirectoryInfo(Settings.Default.ExportPath);
            DirectoryInfo destinationDir = new DirectoryInfo(Settings.Default.PublishPath);

            CopyFilesRecursively(sourceDir, destinationDir);

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void backgroundWorker3_DoWork(object sender,
            DoWorkEventArgs e)
        {

            while (currentNode.Nodes.Count > 0)
            {
                currentNode = currentNode.FirstNode;
            };
            if (DicomElement.IsValid(currentNode))
            {
                this.currentView.TreeNodeSelectionChanged(currentNode);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                lblStatus.Text = "Done!";
            }
            restoreInitialButtonState();

        }

        private void backgroundWorker2_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                lblStatus.Text = "Done!";
            }
            restoreInitialButtonState();
        }

        private void backgroundWorker3_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            updateImageAfterSelectionChanged();
            resetFilters();
            this.UseWaitCursor = false;
            this.currentView.AfterTreeNodeSelectCompleted(toolStripButtonShowProperties);
        }





        private void backgroundWorker1_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar.Value = this.toolStripProgressBar.Value + e.ProgressPercentage;
        }

        private void backgroundWorker2_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar.Value = this.toolStripProgressBar.Value + e.ProgressPercentage;
            lblStatus.Text = toolStripProgressBar.Value + "/" + toolStripProgressBar.Maximum;
        }

        private void UpdateToolStrip(int value, int maximum)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(
                    new Action<int, int>(UpdateToolStrip),  // calls itself, but on correct thread
                    new object[] { value, maximum });
            }
            else
            {
                toolStripProgressBar.Value = value;
                toolStripProgressBar.Maximum = maximum;
            }
        }


        private void updateImageAfterSelectionChanged()
        {
            string labelText = this.currentView.UpdateImageAfterSelectionChanged(true);
            if (!string.IsNullOrEmpty(labelText))
            {
                toolStripLabelCurrentFrame.Text = labelText;
            }
        }

        private void updateToOriginalImage()
        {
            string labelText = this.currentView.UpdateToOriginalImage();
            if (!string.IsNullOrEmpty(labelText))
            {
                toolStripLabelCurrentFrame.Text = labelText;
            }
        }

        private void updateImage()
        {
            string labelText = this.currentView.UpdateImage();
            if (!string.IsNullOrEmpty(labelText))
            {
                toolStripLabelCurrentFrame.Text = labelText;
            }
        }

        private void toolStripButtonPickFiles_Click(object sender, EventArgs e)
        {
            // TODO multiselect treeview
            //pickStudiesDialog.ShowDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                string studyPath = folderBrowserDialog1.SelectedPath;

                DirectoryInfo studyRoot = new DirectoryInfo(studyPath);
                TreeNode parentNode = new TreeNode();
                parentNode.Text = studyRoot.Name;
                parentNode.Tag = studyRoot;
                parentNode.ImageIndex = 0;
                parseDirectory(parentNode);

                treeViewDicomStudies.Nodes.Add(parentNode);

            }
        }

        private void parseDirectory(TreeNode node)
        {
            DirectoryInfo dir = (DirectoryInfo)node.Tag;
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                TreeNode folderNode = new TreeNode();
                folderNode.Text = di.Name;
                folderNode.Tag = di;
                folderNode.ImageIndex = 1;
                folderNode.SelectedImageIndex = 1;
                node.Nodes.Add(folderNode);
                parseDirectory(folderNode);
            }

            foreach (FileInfo file in dir.GetFiles())
            {
                TreeNode n = new TreeNode();
                n.Text = file.Name;
                n.Tag = file;
                //if (DicomElement.IsValid(n))
                //{
                n.ImageIndex = 2;
                n.SelectedImageIndex = 2;
                node.Nodes.Add(n);
                //}

            }


        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            treeViewDicomStudies.Nodes.Clear();
        }

        private void toolStripButtonPreviousFrame_Click(object sender, EventArgs e)
        {
            string labelText = this.currentView.PreviousFrameClicked();
            if (!string.IsNullOrEmpty(labelText))
            {
                this.SetCurrentFrameLabel(labelText);
            }
        }

        private void toolStripButtonNextFrame_Click(object sender, EventArgs e)
        {
            string labelText = this.currentView.NextFrameClicked();
            if (!string.IsNullOrEmpty(labelText))
            {
                this.SetCurrentFrameLabel(labelText);
            }
        }

        private void SetCurrentFrameLabel(string labelText)
        {
            if (toolStrip1.InvokeRequired)
            {
                SetCurrentFrameInvoker invoker = new SetCurrentFrameInvoker(this.SetCurrentFrame);
                toolStrip1.Invoke(invoker, labelText);
            }
            else
                toolStripLabelCurrentFrame.Text = labelText;
        }

        private void SetCurrentFrame(string labelText)
        {
            toolStripLabelCurrentFrame.Text = labelText;
        }

        private delegate void SetCurrentFrameInvoker(string labelText);

        void toolStripButtonPlay_Click(object sender, System.EventArgs e)
        {
            this.timer = new System.Timers.Timer();
            this.timer.Interval = 1000 / int.Parse(this.toolStripComboBoxSeconds.SelectedItem as string);
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.toolStripButtonNextFrame_Click);
            if (this.currentView.IsDicomElementSet())
            {
                this.timer.Start();
            }
        }

        void toolStripButtonStop_Click(object sender, System.EventArgs e)
        {

            this.timer.Stop();
        }

        private void toolStripButtonExportFiles_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Exporting, please wait...";
            enableOnly(toolStripButtonStopExporting);

            backgroundWorker1.RunWorkerAsync();
        }

        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void treeViewDicomStudies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.UseWaitCursor = true;
            this.currentView.ClearManagers();
            currentNode = treeViewDicomStudies.SelectedNode;
            backgroundWorker3.RunWorkerAsync();

        }

        private void toolStripButtonOriginalImage_Click(object sender, EventArgs e)
        {
            this.currentView.ClearManagers();
            this.updateToOriginalImage();
            this.resetFilters();
        }



        private void RepaintAnnotations()
        {
            this.currentView.RepaintAnnotations();

        }

        private void toolStripStopExportButton_Click(object sender, EventArgs e)
        {

            backgroundWorker1.CancelAsync();
            lblStatus.Text = "Export canceled!";

        }

        private void toolStripButtonStopPublishing_Click(object sender, EventArgs e)
        {
            backgroundWorker2.CancelAsync();
            lblStatus.Text = "Publish canceled!";
        }

        private void toolStripButtonPublish_Click(object sender, EventArgs e)
        {
            bool isPublishPathValid = true;
            if (Settings.Default.ExportPath.Equals(Settings.Default.PublishPath))
            {
                isPublishPathValid = false;
                if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.PublishPath = folderBrowserDialog2.SelectedPath;
                    Settings.Default.Save();
                }
                isPublishPathValid = !Settings.Default.ExportPath.Equals(Settings.Default.PublishPath);
            }
            if (isPublishPathValid)
            {
                lblStatus.Text = "Publishing, please wait...";
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Maximum = CountFiles(new DirectoryInfo(Settings.Default.ExportPath), 0);
                enableOnly(toolStripButtonStopPublishing);
                backgroundWorker2.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Publish and Export paths are the same!");
            }


        }

        private void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            // worker
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                if (!backgroundWorker2.CancellationPending)
                {
                    CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
                }
            }
            foreach (FileInfo file in source.GetFiles())
            {
                if (!backgroundWorker2.CancellationPending)
                {
                    file.CopyTo(Path.Combine(target.FullName, file.Name), true);
                    backgroundWorker2.ReportProgress(1);
                }
            }
        }

        private int CountFiles(DirectoryInfo directory, int cnt)
        {
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                cnt += CountFiles(dir, 0);
            }
            cnt += directory.GetFiles().Count();
            return cnt;

        }

        private void enableOnly(ToolStripButton button)
        {
            toolStripButtonSettings.Enabled = (button == toolStripButtonSettings) ? true : false;
            toolStripButtonStopPublishing.Enabled = (button == toolStripButtonStopPublishing) ? true : false; ;
            toolStripButtonPublish.Enabled = (button == toolStripButtonPublish) ? true : false; ;
            toolStripButtonExportFiles.Enabled = (button == toolStripButtonExportFiles) ? true : false; ;
            toolStripButtonStopExporting.Enabled = (button == toolStripButtonStopExporting) ? true : false; ;
        }

        private void restoreInitialButtonState()
        {
            toolStripButtonStopExporting.Enabled = false;
            toolStripButtonStopPublishing.Enabled = false;
            toolStripButtonSettings.Enabled = true;
            toolStripButtonExportFiles.Enabled = true;
            toolStripButtonPublish.Enabled = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void toolStripButtonExportFrame_Click(object sender, EventArgs e)
        {
            exportCurrent();
        }

        private void toolStripButtonIncreaseContrast_Click(object sender, EventArgs e)
        {
            this.currentView.IncreaseContrast();
        }

        private void toolStripButtonDecreaseContrast_Click(object sender, EventArgs e)
        {
            this.currentView.DecreaseContrast();

        }

        private void toolStripButtonIncreaseBrightness_Click(object sender, EventArgs e)
        {
            this.currentView.IncreaseBrightness();

        }

        private void toolStripButtonDecreaseBrightness_Click(object sender, EventArgs e)
        {
            this.currentView.DecreaseBrightness();
        }

        private void reapplyFilters()
        {
            this.currentView.ReapplyFilters();

        }

        internal void resetFilters()
        {
            if (this.currentView != null)
                this.currentView.ResetImageSettins();

        }

        private void resetAnnotations()
        {
            isFreehandStarted = false;
            isTextStarted = false;
            toolStripButtonStartHandwrite.Checked = false;
            toolStripButtonStartHandwrite.Enabled = true;
            toolStripButtonText.Enabled = true;
            toolStripButtonText.Checked = false;
            this.toolStripButtonZoomIn.Enabled = true;
            this.toolStripButtonZoomIn.Checked = false;
            this.toolStripButtonZoomOut.Enabled = true;
            this.toolStripButtonZoomOut.Checked = false;
            this.toolStripButtonSelect.Enabled = true;
            this.toolStripButtonSelect.Checked = false;
            this.toolStripButtonRuler.Enabled = true;
            this.toolStripButtonRuler.Checked = false;
            this.toolStripButtonStopAnnotating.Enabled = false;
            this.SelectToolStateChanged(false);
            this.RulerToolStateChanged(false);
            this.ZoomInToolStateChanged(false);
            this.ZoomOutToolStateChanged(false);
        }

        private void toolStripButtonPickColor_Click(object sender, EventArgs e)
        {

            colorDialog1.Color = currentColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog1.Color;
            }
        }

        private void toolStripButtonStartHandwrite_Click(object sender, EventArgs e)
        {
            this.isFreehandStarted = true;
            this.toolStripButtonStopAnnotating.Enabled = true;
            this.toolStripButtonStartHandwrite.Checked = true;
            this.toolStripButtonText.Enabled = false;
            this.toolStripButtonZoomIn.Enabled = false;
            this.toolStripButtonZoomOut.Enabled = false;
            this.toolStripButtonSelect.Enabled = false;
            this.toolStripButtonRuler.Enabled = false;
            this.currentView.RepaintPicture();

        }

        private void toolStripButtonText_Click(object sender, EventArgs e)
        {
            isTextStarted = true;
            this.toolStripButtonStopAnnotating.Enabled = true;
            this.toolStripButtonText.Checked = true;
            this.toolStripButtonStartHandwrite.Enabled = false;
            this.toolStripButtonZoomIn.Enabled = false;
            this.toolStripButtonZoomOut.Enabled = false;
            this.toolStripButtonSelect.Enabled = false;
            this.toolStripButtonRuler.Enabled = false;
            this.currentView.RepaintPicture();
        }

        private void toolStripButtonZoomIn_Click(object sender, EventArgs e)
        {
            this.Cursor = new Cursor("zoomin.cur");
            this.toolStripButtonStopAnnotating.Enabled = true;
            this.toolStripButtonZoomIn.Checked = true;
            this.toolStripButtonStartHandwrite.Enabled = false;
            this.toolStripButtonText.Enabled = false;
            this.toolStripButtonZoomOut.Enabled = false;
            this.toolStripButtonSelect.Enabled = false;
            this.toolStripButtonRuler.Enabled = false;
            this.ZoomInToolStateChanged(true);
        }

        private void toolStripButtonZoomOut_Click(object sender, EventArgs e)
        {
            this.Cursor = new Cursor("zoomout.cur");
            this.toolStripButtonStopAnnotating.Enabled = true;
            this.toolStripButtonZoomOut.Checked = true;
            this.toolStripButtonStartHandwrite.Enabled = false;
            this.toolStripButtonText.Enabled = false;
            this.toolStripButtonZoomIn.Enabled = false;
            this.toolStripButtonSelect.Enabled = false;
            this.toolStripButtonRuler.Enabled = false;
            this.ZoomOutToolStateChanged(true);
        }

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            this.toolStripButtonStopAnnotating.Enabled = true;
            this.toolStripButtonSelect.Checked = true;
            this.toolStripButtonStartHandwrite.Enabled = false;
            this.toolStripButtonText.Enabled = false;
            this.toolStripButtonZoomIn.Enabled = false;
            this.toolStripButtonZoomOut.Enabled = false;
            this.toolStripButtonRuler.Enabled = false;
            this.topLeft.SelectToolStateChanged(true);
            this.topRight.SelectToolStateChanged(true);
            this.bottomLeft.SelectToolStateChanged(true);
            this.bottomRight.SelectToolStateChanged(true);
        }

        private void toolStripButtonRuler_Click(object sender, EventArgs e)
        {

            this.toolStripButtonStopAnnotating.Enabled = true;
            this.toolStripButtonRuler.Checked = true;
            this.toolStripButtonStartHandwrite.Enabled = false;
            this.toolStripButtonText.Enabled = false;
            this.toolStripButtonZoomIn.Enabled = false;
            this.toolStripButtonZoomOut.Enabled = false;
            this.toolStripButtonSelect.Enabled = false;
            this.topLeft.RulerToolStateChanged(true);
            this.topRight.RulerToolStateChanged(true);
            this.bottomLeft.RulerToolStateChanged(true);
            this.bottomRight.RulerToolStateChanged(true);
        }

        private void toolStripButtonStopAnnotating_Click(object sender, EventArgs e)
        {
            this.Cursor = this.DefaultCursor;
            resetAnnotations();
        }

        private void SelectToolStateChanged(bool state)
        {
            this.topLeft.SelectToolStateChanged(state);
            this.topRight.SelectToolStateChanged(state);
            this.bottomLeft.SelectToolStateChanged(state);
            this.bottomRight.SelectToolStateChanged(state);
        }

        private void RulerToolStateChanged(bool state)
        {
            this.topLeft.RulerToolStateChanged(state);
            this.topRight.RulerToolStateChanged(state);
            this.bottomLeft.RulerToolStateChanged(state);
            this.bottomRight.RulerToolStateChanged(state);
        }

        private void ZoomInToolStateChanged(bool state)
        {
            this.topLeft.ZoomInToolStateChanged(state);
            this.topRight.ZoomInToolStateChanged(state);
            this.bottomLeft.ZoomInToolStateChanged(state);
            this.bottomRight.ZoomInToolStateChanged(state);
        }

        private void ZoomOutToolStateChanged(bool state)
        {
            this.topLeft.ZoomOutToolStateChanged(state);
            this.topRight.ZoomOutToolStateChanged(state);
            this.bottomLeft.ZoomOutToolStateChanged(state);
            this.bottomRight.ZoomOutToolStateChanged(state);
        }

        private void toolStripDeleteLastAnnotation_Click(object sender, EventArgs e)
        {
            this.currentView.DeleteLastAnotation();

        }

        private void toolStripButtonUndo_Click(object sender, EventArgs e)
        {
            this.currentView.Undo();

        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            this.currentView.Redo();

        }

        public void RefreshGui()
        {
            this.currentView.RefreshGui(toolStripButtonRedo, toolStripButtonUndo);

        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.ToString() == "Export")
            {
                // Do Nothing
                exportCurrent();
            }
            else
            {
                // remove
                treeViewDicomStudies.SelectedNode.Remove();
            }

        }

        private void treeViewDicomStudies_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                treeViewDicomStudies.SelectedNode = treeViewDicomStudies.GetNodeAt(e.X, e.Y);

                if (treeViewDicomStudies.SelectedNode != null)
                {
                    contextMenu.Show(treeViewDicomStudies, e.Location);
                }
            }
        }

        private void exportCurrent()
        {
            this.currentView.ExportCurrent();

        }

        private void toolStripButtonShowProperties_Click(object sender, EventArgs e)
        {
            //dicomPropertiesForm.Load(
            //dicomPropertiesForm.ShowDialog();
            //// Show dicom properties
            //FieldInfo[] fields = typeof(DicomTags).GetFields();

            //foreach(FieldInfo fi in fields) 
            //{
            //    Console.WriteLine("{0}: {1}", fi.Name, fi.GetValue(null));
            //}
            CustomClass properties = new CustomClass();

            FieldInfo[] fields = typeof(DicomTags).GetFields();
            int nonZeroFieldCount = 0;
            Console.WriteLine(currentView.Name);
            foreach (FieldInfo fi in fields)
            {
                String propertyValue = this.currentView.GetPropertyValue(fi);

                if (propertyValue != null && propertyValue.Length != 0)
                {
                    nonZeroFieldCount++;
                    //Console.WriteLine("{0}: {1}", fi.Name, propertyValue);
                    properties.Add(new CustomProperty(fi.Name, propertyValue, true, true));
                }
            }
            //Console.WriteLine("Broj ne null propertija: {0}", nonZeroFieldCount);
            dicomPropertiesForm.setMyProperties(properties);
            dicomPropertiesForm.ShowDialog();

            //MessageBox.Show(currentDicomElement.DicomFile.DataSet[DicomTags.PatientsName].GetString(0, ""));
            //MessageBox.Show(currentDicomElement.DicomFile.DataSet[DicomTags.CineRate].GetString(0, ""));
        }

        private enum LayoutType
        {
            OnePicture,
            TwoVerticalPictures,
            TwoHorizontalPictures,
            FourPictures
        }

        internal void CurrentViewChanged(PictureView pictureView)
        {
            if (this.currentView != pictureView)
            {
                if (this.timer != null)
                {
                    this.timer.Stop();
                }
                this.currentView.DisableSelecting();
                this.currentView.RepaintPicture();
                this.currentView.BorderStyle = BorderStyle.Fixed3D;
                this.currentView.Padding = new Padding(0);
                this.currentView = pictureView;
                this.currentView.BorderStyle = BorderStyle.None;
                this.currentView.Padding = new Padding(2);
                this.RefreshGui();
            }
        }

        private void chooseLayoutToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.chooseLayoutToolStripComboBox.SelectedIndex;
            string value = this.chooseLayoutToolStripComboBox.Items[selectedIndex] as string;
            switch (value)
            {
                case "One Picture ":
                    this.currentLayout = LayoutType.OnePicture;
                    break;
                case "Two Horizontal Splited Pictures":
                    this.currentLayout = LayoutType.TwoHorizontalPictures;
                    break;
                case "Two Vertical Splited  Pictures":
                    this.currentLayout = LayoutType.TwoVerticalPictures;
                    break;
                case "Four Pictures":
                    this.currentLayout = LayoutType.FourPictures;
                    break;
            }

            this.PositionViews();
        }

        private void toolStripPenWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.toolStripPenWidth.SelectedIndex;
            this.BrushSize = int.Parse(this.toolStripPenWidth.Items[selectedIndex] as string);
        }

        private void toolStripButtonCrop_Click(object sender, EventArgs e)
        {
            this.currentView.Crop();
            this.currentView.ClearManagers();
            this.resetFilters();
            this.RefreshGui();
        }

        private void toolStripComboBoxSeconds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.timer != null)
            {
                this.timer.Interval = 1000 / int.Parse(this.toolStripComboBoxSeconds.SelectedItem as string);
            }
        }

    }
}
