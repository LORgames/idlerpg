﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;

namespace CityTools.Components.GIFSupport {
    internal class GIFImageHelper {
        public static Image RequestGIFSuitableImage(string name) {
            Image im = ImageCache.RequestImage(name);

            Bitmap bmp = new Bitmap(im);
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.Clear(GlobalSettings.GIFColour);

                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.DrawImage(im, Point.Empty);
            }

            return bmp;
        }
    }
}
