using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ToolToGameExporter {
    internal class SpriteSheetHelper {
        public static Size GetFrameSizeOf(List<String> frames) {
            Size s = Size.Empty;

            foreach (String frame in frames) {
                try {
                    Image im = Image.FromFile(frame);

                    if (s.Width < im.Width) s.Width = im.Width;
                    if (s.Height < im.Height) s.Height = im.Height;

                    im.Dispose();
                    im = null;
                } catch {
                    throw new Exception("Could not open file. (" + frame + ") Image may be corrupt. Or the system is out of memory.");
                }
            }

            return s;
        }

        public static void PackAnimationsLinear(List<String> Frames, Size size, Size textureSize, string filename, Boolean InvertedList) {
            Bitmap bmp = new Bitmap(textureSize.Width, textureSize.Height, PixelFormat.Format32bppPArgb);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Image im;

            int cols = (int)(textureSize.Width / size.Width);

            int i = 0;
            int j = 0;

            if (InvertedList) {
                i = (Frames.Count-1) % cols;
                j = (Frames.Count-1) / cols;
            }

            foreach (String s in Frames) {
                im = Image.FromFile(s);

                int xPos = size.Width * i;
                int yPos = size.Height * j;

                if (size.Width > im.Width) xPos += (size.Width - im.Width) / 2;
                if (size.Height > im.Height) yPos += (size.Height - im.Height) / 2;

                gfx.DrawImage(im, new Rectangle(xPos, yPos, im.Width, im.Height));

                im.Dispose();

                if (!InvertedList) {
                    i++;
                    if (i == cols) {
                        i = 0;
                        j++;
                    }
                } else {
                    i--;
                    if (i == -1) {
                        i = cols - 1;
                        j--;
                    }
                }
            }

            bmp.Save(Global.EXPORT_DIRECTORY + "/" + filename + ".png");
            bmp.Dispose();
        }

        internal static Size GetTextureSizeFor(Size frameSize, int totalFrames) {
            int nextSize = 7;
            Size s = new Size();

            while (true) {
                s.Width = (int)Math.Pow(2, nextSize);

                int totalColumns = (s.Width / frameSize.Width);

                if (totalColumns > 0) {
                    int requiredRows = (int)Math.Ceiling(1.0 * totalFrames / totalColumns);

                    int totalHeight = frameSize.Height * requiredRows;

                    if (s.Width >= totalHeight) {
                        s.Height = s.Width;
                        if (s.Width / 2 >= totalHeight) s.Height = s.Width / 2;
                        break;
                    }
                }

                nextSize++;
            }

            return s;
        }
    }
}
