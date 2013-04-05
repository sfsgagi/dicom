using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.ImageViewer.StudyManagement;
using System.IO;
using System.Drawing;
using ClearCanvas.ImageViewer;
using System.Windows.Forms;
using ClearCanvas.Dicom;

namespace DicomUtils
{
    class DicomElement
    {
        public static bool IsValid(TreeNode node)
        {
            try
            {
                LocalSopDataSource _dicomDataSource = new LocalSopDataSource(((FileInfo)node.Tag).FullName);
                ImageSop isop = new ImageSop(_dicomDataSource);
                //DicomFile dcf = new DicomFile(((FileInfo)node.Tag).FullName);
                //dcf.Load(DicomReadOptions.DoNotStorePixelDataInDataSet);
                //00:00:01.5625000
                //00:00:01.7625000
                //00:00:00.0468750
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private TreeNode treeNode;

        private string filePath;
        public string FilePath
        {
            get { return filePath; }
        }

        public int FrameCount
        {
            get
            {
                return ImageSop.Frames.Count;
            }
        }
        private ImageSop imageSop;
        public ImageSop ImageSop
        {
            get
            {
                if (imageSop == null)
                {
                    LocalSopDataSource _dicomDataSource = new LocalSopDataSource(filePath);
                    imageSop = new ImageSop(_dicomDataSource);
                }
                return imageSop;
            }
        }

        public DicomElement(TreeNode node)
        {
            this.filePath = ((FileInfo)node.Tag).FullName;
            this.treeNode = node;
        }

        public Bitmap GetBitmap(int n)
        {
            IPresentationImage presentationImage =
                PresentationImageFactory.Create(ImageSop.Frames[n]);

            int width = imageSop.Frames[n].Columns;
            int height = imageSop.Frames[n].Rows;

            return presentationImage.DrawToBitmap(width, height);
        }

        public override string ToString()
        {
            return Path.GetFileName(FilePath);
        }

        public string GetSubFolderPath(string subfolder)
        {
            //return "\\" + treeNode.Parent.FullPath + "\\" + subfolder + "\\";
            //return "\\" + treeNode.Parent.FullPath + "\\";
            string patientsName = DicomFile.DataSet[DicomTags.PatientsName].GetString(0, "");
            if (patientsName != null && patientsName.Length != 0)
            {
                return "\\" + patientsName + "\\";
            }
            return "\\" + treeNode.Parent.FullPath + "\\";
        }

        private DicomFile dicomFile;

        public DicomFile DicomFile
        {
            get 
            {
                if (dicomFile == null)
                {
                    dicomFile = new DicomFile(filePath);
                    dicomFile.Load(DicomReadOptions.DoNotStorePixelDataInDataSet);
                }
                return dicomFile; 
            }

            set { dicomFile = value; }
        }

    }
}
