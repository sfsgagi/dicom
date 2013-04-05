using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DicomUtils;
using DicomViewer.Properties;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using log4net;
using System.Windows.Forms;
using System.Collections;

namespace DicomViewer.DicomUtils
{
    class ExportManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ExportManager));
        private List<DicomElement> elements;
        private ToolStripProgressBar toolStripProgressBar;
        private delegate void SetMaximumCallback(int maximum);


        public ExportManager(IList nodes, ToolStripProgressBar progressBar, 
            DicomViewer.MainForm.ToolStripProgressBarDelegate toolStripProgressBarDelegate)
        {
            this.elements = new List<DicomElement>();
            this.toolStripProgressBar = progressBar;
            foreach (var item in nodes)
            {
                TreeNode node = (TreeNode)item;
                parseNode(node);
            }

            toolStripProgressBarDelegate(0, countMaximum());
        }

        


        private void parseNode(TreeNode node)
        {
            bool isLeafParent = node.Nodes.Count > 0 && node.Nodes[0].Nodes.Count == 0;
            if (isLeafParent)
            {
                foreach (TreeNode leaf in node.Nodes)
                {
                    if (DicomElement.IsValid(leaf))
                    {
                        elements.Add(new DicomElement(leaf));
                    }
                }
            }
            else
            {
                foreach (TreeNode n in node.Nodes)
                {
                    parseNode(n);
                }
            }
        }

        public void doExporting(BackgroundWorker worker)
        {
            DateTime startTime = DateTime.Now;
            foreach (DicomElement element in elements)
            {
                if (worker.CancellationPending)
                {
                    break;
                }
                if (element.FrameCount > 1)
                {
                    int valueOnStart = toolStripProgressBar.Value;
                    try
                    {
                        new VideoExporter().exportTo(element, worker);
                    }
                    catch (Exception e)
                    {
                        log.Error("Error while exporting: " + element);
                        log.Error(e.StackTrace);
                        int remainder = valueOnStart + element.FrameCount - toolStripProgressBar.Value;
                        worker.ReportProgress(remainder);
                    }
                }
                else
                {
                    Bitmap bmp = element.GetBitmap(1);
                    string exportPath = Settings.Default.ExportPath;
                    string fileName = Path.GetFileNameWithoutExtension(element.FilePath);
                    
                    if (Settings.Default.ExportToBmp)
                    {
                        string bmpExportPath = exportPath + element.GetSubFolderPath("bmp");
                        Directory.CreateDirectory(bmpExportPath);
                        bmp.Save(bmpExportPath + fileName + ".bmp", ImageFormat.Bmp);
                    }

                    if (Settings.Default.ExportToJpg)
                    {
                        string jpgExportPath = exportPath + element.GetSubFolderPath("jpg");
                        Directory.CreateDirectory(jpgExportPath);
                        bmp.Save(jpgExportPath + fileName + ".jpg", ImageFormat.Jpeg);
                    }

                    if (Settings.Default.ExportToPng)
                    {
                        string pngExportPath = exportPath + element.GetSubFolderPath("png");
                        Directory.CreateDirectory(pngExportPath);
                        bmp.Save(pngExportPath + fileName + ".png", ImageFormat.Png);
                    }
                    worker.ReportProgress(1);
                }
            }
            TimeSpan elapsedTime = DateTime.Now - startTime;

            Console.WriteLine("Elapsed: {0}", elapsedTime);
        }

        public int countMaximum()
        {
            int nFrames = 0;
            bool isAnyImageFormatChecked = Settings.Default.ExportToBmp || Settings.Default.ExportToJpg || Settings.Default.ExportToPng;
            bool isAnyVideoFormatChecked = Settings.Default.ExportToAvi || Settings.Default.ExportToM4v || Settings.Default.ExportToMpg;
            foreach (DicomElement element in elements)
            {
                if (element.FrameCount > 1 && isAnyVideoFormatChecked)
                {
                    nFrames += element.FrameCount;
                }
                else if (element.FrameCount == 1 && isAnyImageFormatChecked)
                {
                    nFrames++;
                }
            }
            return nFrames;
        }
    }
}
