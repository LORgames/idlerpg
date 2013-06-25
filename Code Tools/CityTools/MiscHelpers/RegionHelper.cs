using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Regions;
using System.Drawing;
using CityTools.Core;
using System.Windows.Forms;
using ToolCache.Map;
using ToolCache.Drawing;

namespace CityTools.MiscHelpers {
    public class RegionHelper {
        public static SpawnRegion selectedRegion;

        public static bool DoingSomething = false;

        public static List<SpawnRegion> DrawList = new List<SpawnRegion>();

        private static Point p0 = Point.Empty;
        private static Point p1 = Point.Empty;

        Point p0a = new Point((int)(Math.Min(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left), (int)(Math.Min(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top));
        Point p1a = new Point((int)(Math.Max(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left), (int)(Math.Max(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top));

        public static void MouseDown(MouseEventArgs e) {
            if (selectedRegion != null) {
                p0.X = (int)(e.Location.X / Camera.ZoomLevel + Camera.ViewArea.Left);
                p0.Y = (int)(e.Location.Y / Camera.ZoomLevel + Camera.ViewArea.Top);
                p1 = p0;

                DoingSomething = true;
            }
        }

        public static void MouseUp(MouseEventArgs e) {
            if (DoingSomething && selectedRegion != null) {
                Point p0a = new Point(Math.Min(p0.X, p1.X), Math.Min(p0.Y, p1.Y));
                Point p1a = new Point(Math.Max(p0.X, p1.X), Math.Max(p0.Y, p1.Y));

                Rectangle Area = new Rectangle();
                Area.Location = p0a;
                Area.Width = p1a.X - p0a.X;
                Area.Height = p1a.Y - p0a.Y;

                selectedRegion.Areas.Add(Area);

                MapPieceCache.CurrentPiece.Edited();
            }

            DoingSomething = false;
        }

        internal static bool UpdateMouse(MouseEventArgs e, LBuffer inputBuffer) {
            inputBuffer.gfx.Clear(Color.Transparent);

            if (DoingSomething && selectedRegion != null && p0 != Point.Empty) {
                p1.X = (int)(e.Location.X / Camera.ZoomLevel + Camera.ViewArea.Left);
                p1.Y = (int)(e.Location.Y / Camera.ZoomLevel + Camera.ViewArea.Top);

                int x = (int)((Math.Min(p0.X, p1.X) - Camera.ViewArea.Left) * Camera.ZoomLevel);
                int y = (int)((Math.Min(p0.Y, p1.Y) - Camera.ViewArea.Top) * Camera.ZoomLevel);
                int w = Math.Abs(p0.X - p1.X);
                int h = Math.Abs(p0.Y - p1.Y);

                inputBuffer.gfx.DrawRectangle(Pens.Fuchsia, x, y, w, h);

                return true;
            }

            return false;
        }

        public static void Draw(LBuffer buffer) {
            foreach (SpawnRegion p in DrawList) {
                foreach (Rectangle Area in p.Areas) {
                    int x = (int)((Area.X - Camera.ViewArea.Left) * Camera.ZoomLevel);
                    int y = (int)((Area.Y - Camera.ViewArea.Top) * Camera.ZoomLevel);
                    int w = Area.Width;
                    int h = Area.Height;

                    buffer.gfx.DrawRectangle(Pens.Fuchsia, x, y, w, h);
                }
            }
        }
    }
}
