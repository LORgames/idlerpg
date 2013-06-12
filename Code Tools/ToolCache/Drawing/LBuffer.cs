using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ToolCache.Drawing {
    public class LBuffer {
        public Bitmap bmp;
        public Graphics gfx;
        public Size size;

        public LBuffer(Size size) {
            if (size.Width == 0 || size.Height == 0) {
                size.Width = 1;
                size.Height = 1;
            }

            bmp = new Bitmap(size.Width, size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            gfx = Graphics.FromImage(bmp);

            this.size = size;

            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        public void Dispose() {
            gfx.Dispose();
            bmp.Dispose();

            bmp = null;
            gfx = null;
        }
    }
}
