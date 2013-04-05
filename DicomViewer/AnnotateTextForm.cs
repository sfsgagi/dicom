using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DicomViewer
{
    public partial class AnnotateTextForm : Form
    {
        Font font;
        public AnnotateTextForm()
        {
            InitializeComponent();
            font = fontDialog.Font;
        }

        public string GetAnnotationText()
        {
            return textBoxText.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
               font = fontDialog.Font;
            }
        }

        public Font GetFont()
        {
            return font;
        }



        internal void Clear()
        {
            this.textBoxText.Text = string.Empty;
        }
    }
}
