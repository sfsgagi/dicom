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
    public partial class MonitorSizeForm : Form
    {
        public MonitorSizeForm()
        {
            InitializeComponent();
        }

        public bool TryGetSize(out int size)
        {
            if (!int.TryParse(this.textBoxText.Text, out size))
                return false;
            else
                return true;
        }
    }
}
