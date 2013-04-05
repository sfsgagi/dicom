using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DicomViewer.DicomUtils
{
    interface Annotation
    {
        void Draw(Bitmap bmp);
    }
}
