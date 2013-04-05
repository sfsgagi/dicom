using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using ClearCanvas.ImageViewer.StudyManagement;
using ClearCanvas.ImageViewer;
using AviFile;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using DicomViewer.Properties;
using System.Diagnostics;
using System.Windows.Forms;
using ClearCanvas.Dicom;

namespace DicomUtils
{
    public enum VideoFormat { AVI, MPEG, M4V };

    class VideoExporter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(VideoExporter));
        

        public void exportTo(DicomElement dicomElement, BackgroundWorker worker)
        {
            string tmpAviFilePath = Path.Combine(Settings.Default.ExportPath, dicomElement + "-tmp.avi");
            if (File.Exists(tmpAviFilePath))
            {
                tmpAviFilePath = renameToNonExistentFileName(tmpAviFilePath);
            }
            doExporting(tmpAviFilePath, dicomElement, worker);
            

            List<VideoFormat> videoFormats = getCheckedFormats();
            foreach (VideoFormat videoFormat in videoFormats)
            {
                log.Debug("Exporting to ." + videoFormat.ToString().ToLower());
                doCompression(videoFormat, tmpAviFilePath, dicomElement);
            }

            File.Delete(tmpAviFilePath);
        }

        private string renameToNonExistentFileName(string filePath)
        {
            int cnt = 0;
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string folderPath = Path.GetDirectoryName(filePath);
            string newFileName = fileName + cnt + extension;

            while(File.Exists(Path.Combine(folderPath, newFileName))){
                cnt++;
                newFileName = fileName + cnt + extension;
            }
            return Path.Combine(folderPath, newFileName);
        }

        public List<VideoFormat> getCheckedFormats()
        {
            List<VideoFormat> videoFormats = new List<VideoFormat>();
            if (Settings.Default.ExportToAvi)
            {
                videoFormats.Add(VideoFormat.AVI);
            }
            if (Settings.Default.ExportToMpg)
            {
                videoFormats.Add(VideoFormat.MPEG);
            }
            if (Settings.Default.ExportToM4v)
            {
                videoFormats.Add(VideoFormat.M4V);
            }
            return videoFormats;
        }

        private void doCompression(VideoFormat videoFormat,string tmpAviFilePath, DicomElement dicomElement)
        {
            string format = videoFormat.ToString().ToLower();
            string outputFileName = Path.GetFileNameWithoutExtension(dicomElement.FilePath) + "." + format;
            string outputFolderPath = Settings.Default.ExportPath + dicomElement.GetSubFolderPath(format);
            Directory.CreateDirectory(outputFolderPath);
            string outputFilePath = Path.Combine(outputFolderPath, outputFileName);
            if (File.Exists(outputFilePath))
            {
                outputFilePath = renameToNonExistentFileName(outputFilePath);
            }

            if (videoFormat == VideoFormat.M4V)
            {
                executeMultiPassesCommandsForM4v(tmpAviFilePath, outputFilePath);
               
            }
            else
            {
                executeFFmpegCommand(createDefaultArguments(videoFormat, tmpAviFilePath, outputFilePath, dicomElement));
            }
            
        }

        private void executeFFmpegCommand(string arguments)
        {
            ProcessStartInfo start = new ProcessStartInfo();

            start.FileName = @"ffmpeg.exe"; // Specify exe name.
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.Arguments = arguments;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardError)
                {
                    string result = reader.ReadToEnd();
                    // MessageBox.Show(result);
                }
            }
        }

        private string createDefaultArguments(VideoFormat videoFormat, string inputFilePath, string outputFilePath, DicomElement dicomElement)
        {
            // for ffmpeg testing
            //ffmpeg -i test-video.avi -r 2 -qscale 31 -f m4v m5.mpg
            // mpeg1 supports only specific fps values, see mpeg12data.c from ffmpeg source
            string format = videoFormat.ToString().ToLower();

            int originalFps;
            string strOriginalFps = dicomElement.DicomFile.DataSet[DicomTags.CineRate].GetString(0, "");
            if (int.TryParse(strOriginalFps, out originalFps) == false)
            {
                originalFps = Settings.Default.Fps;
            }
            
            int fps = (videoFormat == VideoFormat.MPEG) ? 24 : originalFps;

            return @"-i " + inputFilePath
                + " -r " + fps
                + " -qscale " + Settings.Default.Quality
                + " -f " + format
                + " \"" + outputFilePath + "\"";
        }

        private void executeMultiPassesCommandsForM4v(string inputFilePath, string outputFilePath) 
        {
            //ffmpeg -i test-video.avi -acodec libfaac -vcodec libx264 -fpre libx264-veryslow.ffpreset -fpre libx264-ipod320.ffpreset -metadata "title=Test Video" -threads 0 -f ipod aaaa0.m4v
            string zeroPassPath = outputFilePath + "0";
            string zeroPassArguments = @"-i " + inputFilePath
                + " -s 426x320 -acodec libfaac -vcodec libx264 -fpre ffpresets/libx264-slow.ffpreset -fpre ffpresets/libx264-ipod320.ffpreset -b 768k"
                + " -metadata \"title=" + Path.GetFileNameWithoutExtension(outputFilePath) + "\" "
                + " -threads 0 -f ipod "
                + " \"" + zeroPassPath + "\"";
            executeFFmpegCommand(zeroPassArguments);

            string onePassPath = outputFilePath + "1";
            string onePassArguments = @"-i " + inputFilePath
                + " -an -pass 1 -s 426x320 -vcodec libx264 -fpre ffpresets/libx264-slow_firstpass.ffpreset -fpre ffpresets/libx264-ipod320.ffpreset -b 768k"
                + " -metadata \"title=" + Path.GetFileNameWithoutExtension(outputFilePath) + "\" "
                + " -threads 0 -f ipod "
                + " \"" + onePassPath + "\"";
            executeFFmpegCommand(onePassArguments);

            string finalPassArguments = @"-i " + inputFilePath
                + " -acodec libfaac -ab 128k -pass 2 -s 426x320 -vcodec libx264 -fpre ffpresets/libx264-slow.ffpreset -fpre ffpresets/libx264-ipod320.ffpreset -b 768k"
                + " -metadata \"title=" + Path.GetFileNameWithoutExtension(outputFilePath) + "\" "
                + " -threads 0 -f ipod "
                + " \"" + outputFilePath + "\"";
            executeFFmpegCommand(finalPassArguments);
           
        }

        private void doExporting(string tmpFilePath, DicomElement dicomElement, BackgroundWorker worker)
        {
            //create a new AVI file
            AviManager aviManager = new AviManager(tmpFilePath, false);
            //add a new video stream and one frame to the new file
            // todo mozda ce moci drugaciji konstruktor...
            Bitmap bitmap = dicomElement.GetBitmap(1);
            VideoStream aviStream = aviManager.AddVideoStream(createCompressedOptions(), Settings.Default.Fps, bitmap);
            bitmap.Dispose();
            worker.ReportProgress(1);
            
            for (int n = 2; n <= dicomElement.FrameCount; n++)
            {
                bitmap = dicomElement.GetBitmap(n);
                aviStream.AddFrame(bitmap);
                bitmap.Dispose();
                worker.ReportProgress(1);
            }

            aviManager.Close();
        }

        private Avi.AVICOMPRESSOPTIONS createCompressedOptions()
        {
            Avi.AVICOMPRESSOPTIONS opts = new Avi.AVICOMPRESSOPTIONS();
            opts.fccType = (UInt32)Avi.mmioStringToFOURCC("vids", 0);
            opts.fccHandler = (UInt32)Avi.mmioStringToFOURCC("CVID", 0);
            opts.dwKeyFrameEvery = 0;
            opts.dwQuality = 0;  // 0 .. 10000
            opts.dwFlags = Avi.AVICOMPRESSF_DATARATE;  // AVICOMRPESSF_KEYFRAMES = 4
            opts.dwBytesPerSecond = 0;
            opts.lpFormat = new IntPtr(0);
            opts.cbFormat = 0;
            opts.lpParms = new IntPtr(0);
            opts.cbParms = 0;
            opts.dwInterleaveEvery = 0;

            return opts;
        }
    }
}
