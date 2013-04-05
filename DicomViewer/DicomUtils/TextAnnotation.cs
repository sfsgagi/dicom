using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DicomViewer.DicomUtils
{
    class TextAnnotation : Annotation
    {
        #region Properties
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private Color color;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private Font font;

        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        #endregion 

        #region Annotation Members
        public TextAnnotation(string text, int x, int y, Color color, Font font)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            this.color = color;
            this.font = font;
        }

        public void Draw(Bitmap bmp)
        {
            
            Graphics g = Graphics.FromImage(bmp);
            Font newFont = new Font(font.FontFamily, 14);
            g.DrawString(text, newFont,
                new SolidBrush(color), x, y);
        }

        #endregion

        public override string ToString()
        {
            return this.Text;
        }
    }
}
