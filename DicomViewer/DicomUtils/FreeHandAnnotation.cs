using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace DicomViewer.DicomUtils
{
    class FreeHandAnnotation : Annotation
    {
        private Color color;

        List<Point> points = new List<Point>();

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public FreeHandAnnotation(Color color)
        {
            this.color = color;
            this.Width = 3;
        }

        public int Width;

        #region Annotation Members

        public void Draw(Bitmap bmp)
        {
            
            if (points.Count > 2)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                for(int i = 0; i < points.Count - 1; i++) 
                {
                    g.DrawLine(new Pen(new SolidBrush(color), this.Width), points[i], points[i + 1]);
                }
            }
            
        }

        #endregion

        public void AddPoint(int x, int y)
        {
            points.Add(new Point(x, y));     
        }

        public void DrawLastSegment(Bitmap bmp)
        {
            if (points.Count > 2)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                int i = points.Count - 1;

                g.DrawLine(new Pen(new SolidBrush(color), 3), points[i], points[i - 1]);
            }
        }
    }
}
