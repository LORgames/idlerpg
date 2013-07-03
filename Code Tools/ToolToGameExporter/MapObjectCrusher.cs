using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Objects;
using ToolCache.General;
using System.Drawing;
using System.Drawing.Imaging;
using ToolCache.Scripting;

namespace ToolToGameExporter {
    internal class MapObjectCrusher {

        public static Dictionary<short, short> RealignedItemIndexes = new Dictionary<short, short>();

        public static void Go() {
            RealignedItemIndexes.Clear();

            short highestIndex = 0;

            BinaryIO f = new BinaryIO();
            f.AddShort((short)MapObjectCache.ObjectTypes.Count);

            int i = 0;

            foreach (MapObject t in MapObjectCache.ObjectTypes.Values) {
                RealignedItemIndexes.Add(t.ObjectID, highestIndex);
                f.AddString(t.ObjectName);

                f.AddByte((byte)t.Animation.Frames.Count);

                f.AddShort((short)t.OffsetY);

                ScriptInfo info = new ScriptInfo(t.ObjectName, ScriptTypes.Object);
                ScriptCrusher.ProcessScript(info, t.Script, f);

                f.AddByte((byte)t.Blocks.Count);
                i = t.Blocks.Count;

                while (--i > -1) {
                    f.AddShort((short)(t.Blocks[i].X));
                    f.AddShort((short)(t.Blocks[i].Y));
                    f.AddShort((short)(t.Blocks[i].Width));
                    f.AddShort((short)(t.Blocks[i].Height));
                }

                f.AddByte(t.GetBooleanData());

                if (t.Animation.Frames.Count > 0) {
                    Image im = Image.FromFile(t.Animation.Frames[0]);
                    Bitmap bmp = new Bitmap(im.Width * t.Animation.Frames.Count, im.Height, PixelFormat.Format32bppPArgb);
                    Graphics gfx = Graphics.FromImage(bmp);

                    f.AddShort((short)im.Width);
                    f.AddShort((short)im.Height);
                    f.AddFloat(t.Animation.PlaybackSpeed);

                    im.Dispose();

                    gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    for (i = 0; i < t.Animation.Frames.Count; i++) {
                        im = Image.FromFile(t.Animation.Frames[i]);
                        gfx.DrawImage(im, new Rectangle(im.Width * i, 0, im.Width, im.Height));
                        im.Dispose();
                    }

                    bmp.Save(Global.EXPORT_DIRECTORY + "/Object_" + highestIndex + ".png");
                    bmp.Dispose();
                }
                
                highestIndex++;
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/ObjectInfo.bin");
        }

    }
}
