﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Tiles;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using ToolCache.General;

namespace ToolToGameExporter {
    public class TileCrusher {

        public static Dictionary<short, short> RemappedTileIds = new Dictionary<short, short>();

        public static void Go() {
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
                f.AddByte((byte)(tt.isWalkable?1:0));
                f.AddFloat(tt.movementCost);
                f.AddByte(tt.directionalAccess);
                f.AddByte(tt.slidingDirection);
                
                f.AddShort(tt.damageElement);
                f.AddShort(tt.damagePerSecond);

                foreach (String s in tt.Animation.Frames) {
                    tiles.Add(s);
                }

                highestID++;
            }

            if (tiles.Count > 448) {
                MessageBox.Show("Too many tiles, alert Paul that the TileCrusher needs to be better.");
            }

            for (int i = 0; i < tiles.Count; i++) {
                p.X = (int)(i % 21) * 48;
                p.Y = (int)(i / 21) * 48;

                Image im = Image.FromFile(tiles[i]);
                gfx.DrawImage(im, new Rectangle(p.X, p.Y, 48, 48));

                //bmp.SetResolution(im.HorizontalResolution, im.VerticalResolution);
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/TileInfo.bin");
            bmp.Save(Global.EXPORT_DIRECTORY + "/TileSheet.png");
        }

    }
}