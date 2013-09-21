using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Tiles;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using ToolCache.General;

namespace ToolToGameExporter {
    internal class TileCrusher {

        public static Dictionary<short, short> RemappedTileIds = new Dictionary<short, short>();

        public static void Go() {
            if (!GlobalSettings.TilesEnabled) return;

            RemappedTileIds.Clear();
            List<string> tiles = new List<string>();

            short highestID = 0;

            Bitmap bmp = new Bitmap(1024, 1024, PixelFormat.Format32bppPArgb);
            Graphics gfx = Graphics.FromImage(bmp);

            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Point p = new Point();

            BinaryIO f = new BinaryIO();
            f.AddShort((short)TileCache.Tiles.Count);

            //Crush crush
            foreach (TileTemplate tt in TileCache.Tiles.Values) {
                RemappedTileIds.Add(tt.TileID, highestID);

                f.AddByte((byte)tt.Animation.Frames.Count);
                f.AddFloat(tt.movementCost);
                f.AddFloat(tt.Animation.PlaybackSpeed);

                f.AddByte((byte)tt.Collision.Count);
                foreach (Rectangle r in tt.Collision) {
                    f.AddShort((short)r.X);
                    f.AddShort((short)r.Y);
                    f.AddShort((short)r.Width);
                    f.AddShort((short)r.Height);
                }

                foreach (String s in tt.Animation.Frames) {
                    tiles.Add(s);
                }

                highestID++;
            }

            int totalPerRow = 1024 / GlobalSettings.TileSize;

            if (tiles.Count > (totalPerRow*totalPerRow)) {
                Processor.Errors.Add(new ProcessingError("Tiles", "ALL", "Can only fit: " + totalPerRow * totalPerRow + " total tiles."));
            }

            for (int i = 0; i < tiles.Count; i++) {
                //TODO: Calculate this stuff rather than magic numbers
                p.X = (int)(i % totalPerRow) * GlobalSettings.TileSize;
                p.Y = (int)(i / totalPerRow) * GlobalSettings.TileSize;

                Image im = Image.FromFile(tiles[i]);
                gfx.DrawImage(im, new Rectangle(p.X, p.Y, GlobalSettings.TileSize, GlobalSettings.TileSize));
                im.Dispose();
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/TileInfo.bin");
            bmp.Save(Global.EXPORT_DIRECTORY + "/TileSheet.png");
            bmp.Dispose();
        }

    }
}
