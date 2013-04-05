using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DicomViewer.DicomUtils
{
    public class ImageSettings
    {
        private const double DEFAULT_CONTRAST = 1.0;
        private const double DEFAULT_BRIGHTNESS = 0.0;
        private double contrast;

        public double Contrast
        {
            get { return contrast; }
            set { contrast = value; }
        }
        private double brightness;

        public double Brightness
        {
            get { return brightness; }
            set { brightness = value; }
        }

        public ImageSettings()
        {
            this.brightness = DEFAULT_BRIGHTNESS;
            this.contrast = DEFAULT_CONTRAST;
        }

        public ImageSettings(double contrast, double brightness)
        {
            this.contrast = contrast;
            this.brightness = brightness;
        }

        public ImageSettings IncreaseContrast()
        {
            return new ImageSettings(contrast + 0.5, brightness);
        }

        public ImageSettings DecreaseContrast()
        {
            return new ImageSettings(contrast - 0.5, brightness);
        }

        public ImageSettings IncreaseBrightness()
        {
            return new ImageSettings(contrast, brightness + 0.1);
        }

        public ImageSettings DecreaseBrightness()
        {
            return new ImageSettings(contrast, brightness - 0.1);
        }

        internal bool IsDefaultBrightness()
        {
            return brightness == DEFAULT_BRIGHTNESS;
        }

        internal bool IsDefaultContrast()
        {
            return contrast == DEFAULT_CONTRAST;
        }
    }
}
