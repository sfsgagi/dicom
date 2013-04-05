using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DicomViewer.Properties;

namespace DicomViewer
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeValues()
        {
            chbAvi.Checked = Settings.Default.ExportToAvi;
            chbBmp.Checked = Settings.Default.ExportToBmp;
            chbM4v.Checked = Settings.Default.ExportToM4v;
            chbJpg.Checked = Settings.Default.ExportToJpg;
            chbMpg.Checked = Settings.Default.ExportToMpg;
            chbPng.Checked = Settings.Default.ExportToPng;
            lblExportDir.Text = Settings.Default.ExportPath;
            lblPublishDir.Text = Settings.Default.PublishPath;
            numericUpDownFps.Value = Settings.Default.Fps;
            numericUpDownQuality.Value = Settings.Default.Quality;
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Settings.Default.ExportPath = lblExportDir.Text;
            Settings.Default.PublishPath = lblPublishDir.Text;
            Settings.Default.ExportToAvi = chbAvi.Checked;
            Settings.Default.ExportToBmp = chbBmp.Checked;
            Settings.Default.ExportToJpg = chbJpg.Checked;
            Settings.Default.ExportToMpg = chbMpg.Checked;
            Settings.Default.ExportToM4v = chbM4v.Checked;
            Settings.Default.ExportToPng = chbPng.Checked;
            Settings.Default.Fps = (int)numericUpDownFps.Value;
            Settings.Default.Quality = (int)numericUpDownQuality.Value;
            Settings.Default.Save();
            Hide();
        }

        private void btnChangeExportDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Settings.Default.ExportPath;
            folderBrowserDialog1.ShowDialog();
            lblExportDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            InitializeValues();
        }

        private void btnChangePublish_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Settings.Default.PublishPath;
            folderBrowserDialog1.ShowDialog();
            lblPublishDir.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
