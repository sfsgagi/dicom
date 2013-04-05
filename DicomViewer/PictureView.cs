using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DicomUtils;
using DicomViewer.DicomUtils;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Drawing.Drawing2D;
using DicomViewer.Properties;

namespace DicomViewer
{
    public partial class PictureView : UserControl
    {
        private int currentFrame { get; set; }
        private DicomElement currentDicomElement;
        private FreeHandAnnotation currentFreeHandAnnotation;
        private AnnotationManager annotationManager;
        private CommandManager commandManager;
        private MainForm mainForm;
        private ImageSettings imageSettings;
        private Bitmap originalImage;
        private Bitmap visibleImage;
        private double zoomFactor;

        public PictureView()
        {
            InitializeComponent();
            this.zoomFactor = 1;
            this.mainForm = mainForm as MainForm;
            this.currentFrame = 0;
            this.annotationManager = new AnnotationManager();
            this.BorderStyle = BorderStyle.Fixed3D;
            this.imageSettings = new ImageSettings();
            this.columnHeader1.Width = -2;
            this.annotationManager.AnnotationAdded += new AnnotationManager.CollectionChanged(annotationManager_AnnotationAdded);
            this.annotationManager.AnnotationDeleted += new AnnotationManager.CollectionChanged(annotationManager_AnnotationDeleted);
            this.annotationManager.AnnotationCleared += new AnnotationManager.CollectionCleared(annotationManager_AnnotationCleared);
        }

        public ImageSettings ImageSettings
        {
            get { return imageSettings; }
            set { imageSettings = value; }
        }

        public MainForm MainForm
        {
            get { return this.mainForm; }
            set
            {
                this.mainForm = value;
                this.commandManager = new CommandManager(this.mainForm);
            }
        }

        internal void TreeNodeSelectionChanged(TreeNode currentNode)
        {
            this.currentDicomElement = new DicomElement(currentNode);
            this.currentFrame = 1;
            this.selection.Size = new Size();
            this.endPoint = this.startPoint;
        }

        internal void AfterTreeNodeSelectCompleted(ToolStripButton toolStripButtonShowProperties)
        {
            if (this.currentDicomElement != null)
            {
                toolStripButtonShowProperties.Enabled = true;
            }
        }

        internal string UpdateImageAfterSelectionChanged(bool setSize)
        {
            if (this.currentDicomElement != null)
            {
                Bitmap bmp = this.currentDicomElement.GetBitmap(currentFrame);

                this.originalImage = bmp.Clone() as Bitmap;
                this.visibleImage = this.originalImage.Clone() as Bitmap;
                previewBox.Image = this.visibleImage;

                if (setSize || this.zoomFactor != 1)
                {
                    if (this.previewBox.InvokeRequired)
                    {
                        this.previewBox.Invoke(new SetPreviewBoxSizeDelegate(this.SetPreviewBoxSize), this.visibleImage.Size);
                    }
                    else
                    {
                        this.SetPreviewBoxSize(this.visibleImage.Size);
                    }

                }
                this.zoomFactor = 1;
                return currentFrame + "/" + this.currentDicomElement.FrameCount;
            }

            return string.Empty;
        }

        private delegate void SetPreviewBoxSizeDelegate(Size size);
        private void SetPreviewBoxSize(Size size)
        {
            this.previewBox.Width = size.Width;
            this.previewBox.Height = size.Height;
        }

        internal string UpdateToOriginalImage()
        {
            selection.Size = new Size();
            if (this.originalImage != null)
            {
                previewBox.Image = this.originalImage.Clone() as Bitmap;
                previewBox.Width = this.originalImage.Width;
                previewBox.Height = this.originalImage.Height;
                this.visibleImage = this.originalImage.Clone() as Bitmap;
                this.zoomFactor = 1;
                return currentFrame + "/" + this.currentDicomElement.FrameCount;
            }

            return string.Empty;
        }

        internal string UpdateImage()
        {
            this.selection.Size = new Size();
            this.endPoint = this.startPoint;
            if (this.originalImage != null)
            {
                if (this.zoomFactor != 1)
                {
                    Bitmap zommedImage = new Bitmap(this.originalImage, (int)(this.zoomFactor * this.originalImage.Size.Width),
                                            (int)(this.zoomFactor * this.originalImage.Size.Height));
                    this.visibleImage.Dispose();
                    this.visibleImage = zommedImage;
                }
                previewBox.Image = this.visibleImage;
                previewBox.Width = this.visibleImage.Width;
                previewBox.Height = this.visibleImage.Height;
                return currentFrame + "/" + this.currentDicomElement.FrameCount;
            }
            return string.Empty;
        }

        internal void RepaintAnnotations()
        {
            annotationManager.repaintAnnotations((Bitmap)previewBox.Image);
            previewBox.Invalidate();
        }


        internal string NextFrameClicked()
        {
            if (this.currentDicomElement != null)
            {
                if (this.currentFrame < this.currentDicomElement.FrameCount)
                {
                    currentFrame++;
                    this.UpdateImageAfterSelectionChanged(false);
                }
                else if (this.currentFrame == this.currentDicomElement.FrameCount && currentFrame != 1)
                {
                    currentFrame = 1;
                    this.UpdateImageAfterSelectionChanged(false);
                }
                this.RepaintAnnotations();
                return currentFrame + "/" + this.currentDicomElement.FrameCount;
            }

            return string.Empty;
        }

        internal string PreviousFrameClicked()
        {
            if (this.currentDicomElement != null)
            {
                if (this.currentFrame > 1)
                {
                    this.currentFrame--;
                    this.UpdateImageAfterSelectionChanged(false);
                }
                else if (currentFrame == 1 && currentFrame != this.currentDicomElement.FrameCount)
                {
                    currentFrame = this.currentDicomElement.FrameCount;
                    this.UpdateImageAfterSelectionChanged(false);
                }
                this.RepaintAnnotations();
                return currentFrame + "/" + this.currentDicomElement.FrameCount;
            }
            return string.Empty;
        }

        internal void ClearManagers()
        {
            annotationManager.Clear();
            commandManager.Clear();
        }

        internal void IncreaseContrast()
        {
            if (this.currentDicomElement != null)
            {
                ImageSettings oldImageSettings = imageSettings;
                imageSettings = imageSettings.IncreaseContrast();
                commandManager.Execute(
                    new ChangeImageCommand(this, oldImageSettings, imageSettings));
            }
        }

        internal void DecreaseContrast()
        {
            if (this.currentDicomElement != null)
            {
                ImageSettings oldImageSettings = imageSettings;
                imageSettings = imageSettings.DecreaseContrast();
                commandManager.Execute(
                    new ChangeImageCommand(this, oldImageSettings, imageSettings));
            }
        }

        internal void IncreaseBrightness()
        {
            if (this.currentDicomElement != null)
            {
                ImageSettings oldImageSettings = imageSettings;
                imageSettings = imageSettings.IncreaseBrightness();
                commandManager.Execute(
                    new ChangeImageCommand(this, oldImageSettings, imageSettings));
            }
        }

        internal void DecreaseBrightness()
        {
            if (this.currentDicomElement != null)
            {
                ImageSettings oldImageSettings = imageSettings;
                imageSettings = imageSettings.DecreaseBrightness();
                commandManager.Execute(
                    new ChangeImageCommand(this, oldImageSettings, imageSettings));
            }
        }

        internal void ReapplyFilters()
        {
            if (this.currentDicomElement != null)
            {
                Bitmap bmp = this.visibleImage.Clone() as Bitmap;
                if (!imageSettings.IsDefaultBrightness())
                {
                    BrightnessCorrection filter = new BrightnessCorrection(imageSettings.Brightness);
                    bmp = filter.Apply(bmp);
                }
                if (!imageSettings.IsDefaultContrast())
                {
                    ContrastCorrection filter = new ContrastCorrection(imageSettings.Contrast);
                    // apply filter
                    bmp = filter.Apply(bmp);
                }
                previewBox.Image = bmp;
            }
        }

        private bool selecting;
        private bool selectToolActive;
        private bool rulerToolActive;
        private bool zoomInToolActive;
        private bool zoomOutToolActive;
        private Rectangle selection;
        private Point startPoint;
        private Point endPoint;

        internal void SelectToolStateChanged(bool newState)
        {
            this.selectToolActive = newState;
            this.previewBox.Refresh();
        }

        internal void RulerToolStateChanged(bool newState)
        {
            if (Settings.Default.MonitorSize == 0 && newState)
            {
                MonitorSizeForm monitorSize = new MonitorSizeForm();
                bool validSize = false;
                DialogResult result = DialogResult.Cancel;
                do
                {
                    result = monitorSize.ShowDialog();
                    int size;
                    if (monitorSize.TryGetSize(out size))
                    {
                        Settings.Default.MonitorSize = size;
                        Settings.Default.Save();
                        validSize = true;
                    }

                } while (result != DialogResult.OK || !validSize);
            }
            this.rulerToolActive = newState;
            this.previewBox.Refresh();
        }

        internal void ZoomInToolStateChanged(bool newState)
        {
            this.zoomInToolActive = newState;
            this.previewBox.Refresh();
        }

        internal void ZoomOutToolStateChanged(bool newState)
        {
            this.zoomOutToolActive = newState;
            this.previewBox.Refresh();
        }

        private void previewBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.mainForm.CurrentViewChanged(this);
            if (currentDicomElement != null
                && !this.mainForm.isFreehandStarted
                && !this.mainForm.isTextStarted)
            {
                if (e.Button == MouseButtons.Left)
                {
                    selecting = true;
                    if (this.selectToolActive)
                    {
                        selection = new Rectangle(new Point(e.X, e.Y), new Size());
                    }
                    else if (this.rulerToolActive)
                    {
                        startPoint = endPoint = new Point(e.X, e.Y);
                    }
                }
            }
        }

        private void previewBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.currentDicomElement != null)
            {
                if (this.mainForm.isFreehandStarted)
                {
                    selecting = false;
                    if (System.Windows.Forms.MouseButtons.Left == e.Button)
                    {
                        if (currentFreeHandAnnotation == null)
                        {
                            currentFreeHandAnnotation = new FreeHandAnnotation(this.mainForm.currentColor);
                            currentFreeHandAnnotation.Width = this.mainForm.BrushSize;
                            annotationManager.AddAnnotation(currentFreeHandAnnotation);
                        }
                        currentFreeHandAnnotation.AddPoint(e.X, e.Y);

                        Bitmap bmp = (Bitmap)previewBox.Image;
                        currentFreeHandAnnotation.DrawLastSegment(bmp);
                        previewBox.Invalidate();
                    }
                }
                else
                {
                    if (selecting && selectToolActive)
                    {
                        selection.Width = e.X - selection.X;
                        selection.Height = e.Y - selection.Y;
                        if ((selection.X + selection.Width) > this.visibleImage.Width)
                            selection.Width = this.visibleImage.Width - selection.X;

                        if ((selection.Y + selection.Height) > this.visibleImage.Height)
                            selection.Height = this.visibleImage.Height - selection.Y;

                        this.previewBox.Refresh();
                    }
                    else if (selecting && rulerToolActive)
                    {
                        endPoint = new Point(e.X, e.Y);
                        this.previewBox.Refresh();
                    }
                }
            }
        }

        private void previewBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.currentDicomElement != null)
            {
                if (this.mainForm.isTextStarted)
                {
                    selecting = false;
                    this.mainForm.annotateTextForm.Clear();
                    if (this.mainForm.annotateTextForm.ShowDialog() == DialogResult.OK)
                    {
                        commandManager.Execute(
                            new AddAnnotationCommand(annotationManager,
                                new TextAnnotation(this.mainForm.annotateTextForm.GetAnnotationText(),
                            e.X, e.Y, this.mainForm.currentColor, this.mainForm.annotateTextForm.GetFont())));
                    }
                }
                else if (this.mainForm.isFreehandStarted)
                {
                    // insert freehandannotation
                    selecting = false;
                    commandManager.Execute(new AddAnnotationCommand(annotationManager, currentFreeHandAnnotation));
                    currentFreeHandAnnotation = null;
                }
                else
                {
                    selecting = false;
                }
            }
        }

        private void previewBox_Paint(object sender, PaintEventArgs e)
        {
            if (selecting && this.selectToolActive && selection.Size != new Size()
                && !this.mainForm.isFreehandStarted && !this.mainForm.isTextStarted)
            {
                Pen pen = Pens.GreenYellow;
                e.Graphics.DrawRectangle(pen, selection);
            }
            else if (selecting && this.rulerToolActive && endPoint != startPoint
                && !this.mainForm.isFreehandStarted && !this.mainForm.isTextStarted)
            {
                Pen pen = Pens.GreenYellow;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawLine(pen, startPoint, endPoint);
                Rectangle screen = new Rectangle(0, 0, 50, 50);
                screen = Screen.GetBounds(screen);
                double dpi = Math.Sqrt(Math.Pow(screen.Width, 2) + Math.Pow(screen.Height, 2));
                dpi = dpi / Settings.Default.MonitorSize;
                double x = (endPoint.X - startPoint.X);
                double y = (endPoint.Y - startPoint.Y);
                double lenght = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 2.54 / dpi;
                lenght = Math.Round(lenght * 10, 3);
                float xText = startPoint.X + (endPoint.X - startPoint.X) / 2;
                float yText = startPoint.Y + (endPoint.Y - startPoint.Y) / 2;
                string text = string.Format("{0} mm", lenght);
                e.Graphics.DrawString(text, new Font("New Ariel", 10),
                                    new SolidBrush(pen.Color), new PointF(xText, yText));
            }
        }

        void previewBox_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.mainForm.CurrentViewChanged(this);
            if (this.zoomInToolActive)
            {
                this.ZoomIn(e.Location);
            }
            else if (this.zoomOutToolActive)
            {
                this.ZoomOut(e.Location);
            }
        }

        internal void ZoomIn(Point point)
        {
            Size oldSize = this.visibleImage.Size;
            this.zoomFactor *= 1.25;
            this.UpdateImage();
            this.ClearManagers();
            this.mainForm.resetFilters();
            this.mainForm.RefreshGui();
            int verticalScroll = (int)(((float)point.Y / oldSize.Height) * this.visibleImage.Size.Height);
            int horizontalScroll = (int)(((float)point.X / oldSize.Width) * this.visibleImage.Size.Width);
            horizontalScroll -= this.picturePanel.Width / 2;
            verticalScroll -= this.picturePanel.Height / 2;
            this.picturePanel.AutoScrollPosition = new Point(0, 0);
            this.picturePanel.AutoScrollPosition = new Point(horizontalScroll, verticalScroll);
        }

        internal void ZoomOut(Point point)
        {
            Size oldSize = this.visibleImage.Size;
            this.zoomFactor *= 0.8;
            this.UpdateImage();
            this.ClearManagers();
            this.mainForm.resetFilters();
            this.mainForm.RefreshGui();
            int verticalScroll = (int)(((float)point.Y / oldSize.Height) * this.visibleImage.Size.Height);
            int horizontalScroll = (int)(((float)point.X / oldSize.Width) * this.visibleImage.Size.Width);
            horizontalScroll -= this.picturePanel.Width / 2;
            verticalScroll -= this.picturePanel.Height / 2;
            this.picturePanel.AutoScrollPosition = new Point(0, 0);
            this.picturePanel.AutoScrollPosition = new Point(horizontalScroll, verticalScroll);
        }

        internal void Crop()
        {
            if (selection.Size != new Size())
            {
                Bitmap croped = this.visibleImage.Clone(selection, this.visibleImage.PixelFormat);
                croped = this.Scale(croped, selection);
                this.originalImage.Dispose();
                this.visibleImage.Dispose();
                this.originalImage = croped.Clone() as Bitmap;
                this.visibleImage = croped.Clone() as Bitmap;
                croped.Dispose();
                this.zoomFactor = 1;
                this.UpdateImage();
            }
        }

        public Bitmap Scale(Bitmap image, Rectangle pictureBox)
        {
            Bitmap bitmap = null;
            Graphics graphics;

            double scaleY = (double)image.Width / pictureBox.Width;
            double scaleX = (double)image.Height / pictureBox.Height;
            double scale = scaleY < scaleX ? scaleX : scaleY;

            bitmap = new Bitmap((int)((double)image.Width / scale), (int)((double)image.Height / scale));
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            graphics = Graphics.FromImage(bitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            graphics.Dispose();
            image.Dispose();
            return bitmap;
        }

        internal void ExportCurrent()
        {
            if (this.currentDicomElement != null)
            {
                if (this.mainForm.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = (Bitmap)previewBox.Image;
                    ImageFormat format = ToImageFormat(Path.GetExtension(this.mainForm.saveFileDialog1.FileName));
                    bmp.Save(this.mainForm.saveFileDialog1.FileName, format);
                }

            }
        }

        private ImageFormat ToImageFormat(string extension)
        {
            if (extension.Equals(".jpg"))
            {
                return ImageFormat.Jpeg;
            }
            else if (extension.Equals(".png"))
            {
                return ImageFormat.Png;
            }
            else
            {
                return ImageFormat.Bmp;
            }

        }

        internal void DeleteLastAnotation()
        {
            if (this.currentDicomElement != null)
            {
                this.commandManager.Execute(new DeleteAnnotationCommand(this.annotationManager));
            }
        }

        internal void Undo()
        {
            commandManager.Undo();
        }

        internal void Redo()
        {
            commandManager.Redo();
        }

        internal void RefreshGui(ToolStripButton toolStripButtonRedo, ToolStripButton toolStripButtonUndo)
        {
            if (toolStripButtonRedo != null)
                toolStripButtonRedo.Enabled = this.commandManager.hasRedoCommand();
            if (toolStripButtonUndo != null)
                toolStripButtonUndo.Enabled = this.commandManager.hasUndoCommand();
            previewBox.Invalidate();
            this.UpdateImage();
            this.ReapplyFilters();
            this.RepaintAnnotations();
        }

        internal void DisableSelecting()
        {
            this.selecting = false;
        }

        void annotationManager_AnnotationAdded(Annotation annotation)
        {
            if (annotation is TextAnnotation)
            {
                ListViewItem item = new ListViewItem(annotation.ToString());
                item.Tag = annotation as TextAnnotation;
                this.annotationList.Items.Add(item);
            }
        }

        void annotationManager_AnnotationDeleted(Annotation annotation)
        {
            if (annotation is TextAnnotation)
            {
                ListViewItem toDelete = null;
                foreach (ListViewItem item in this.annotationList.Items)
                {
                    if (item.Tag == annotation)
                    {
                        toDelete = item;
                        break;
                    }
                }
                this.annotationList.Items.Remove(toDelete);
            }
        }

        void annotationManager_AnnotationCleared()
        {
            this.annotationList.Items.Clear();
        }

        void annotationsBox_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            (this.annotationList.Items[e.Item].Tag as TextAnnotation).Text = e.Label;
            this.RefreshGui(null, null);
        }

        internal string GetPropertyValue(FieldInfo fieldInfo)
        {
            return this.currentDicomElement.DicomFile.DataSet[(uint)fieldInfo.GetValue(null)].GetString(0, "");
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            this.mainForm.CurrentViewChanged(this);
        }

        internal void ResetImageSettins()
        {
            imageSettings = new ImageSettings();
        }

        internal void RepaintPicture()
        {
            this.previewBox.Refresh();
        }

        internal bool IsDicomElementSet()
        {
            return this.currentDicomElement != null;
        }
    }
}
