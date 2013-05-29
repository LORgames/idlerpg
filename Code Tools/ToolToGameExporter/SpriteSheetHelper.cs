using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ToolToGameExporter {
    public class SpriteSheetHelper {

        public static Size GetFrameSizeOf(List<String> frames) {
            Size s = Size.Empty;

            foreach (String frame in frames) {
                Image im = Image.FromFile(frame);

                if (s.Width < im.Width) s.Width = im.Width;
                if (s.Height < im.Height) s.Height = im.Height;

                im.Dispose();
            }

            return s;
        }

        public static void PackAnimationsLinear(List<String> Frames, Size size, Size textureSize, string filename) {
            Bitmap bmp = new Bitmap(textureSize.Width, textureSize.Height, PixelFormat.Format32bppPArgb);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Image im;

            int cols = (int)(textureSize.Width / size.Width);

            int i = 0;
            int j = 0;

            foreach (String s in Frames) {
                im = Image.FromFile(s);

                int xPos = size.Width * i;
                int yPos = size.Height * j;

                if (size.Width > im.Width) xPos += (size.Width - im.Width) / 2;
                if (size.Height > im.Height) yPos += (size.Height - im.Height) / 2;

                gfx.DrawImage(im, new Rectangle(xPos, yPos, im.Width, im.Height));

                im.Dispose();

                i++;
                if (i == cols) {
                    i = 0;
                    j++;
                }
            }

            bmp.Save(Global.EXPORT_DIRECTORY + "/" + filename + ".png");
            bmp.Dispose();
        }
    }
}
