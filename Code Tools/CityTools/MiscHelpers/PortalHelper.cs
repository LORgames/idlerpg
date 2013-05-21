using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using CityTools.Core;
using ToolCache.Map.Objects;
using ToolCache.Drawing;
using ToolCache.Map;
using ToolCache.Map.Tiles;
using ToolCache.World;

namespace CityTools.MiscHelpers {
    public class PortalHelper {
        public static Portal selectedPortal;

        public static bool PlacingEntry = true;
        public static bool DoingSomething = false;

        public static List<Portal> DrawList = new List<Portal>();

        private static Point p0 = Point.Empty;
        private static Point p1 = Point.Empty;

        Point p0a = new Point((int)(Math.Min(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left), (int)(Math.Min(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top));
        Point p1a = new Point((int)(Math.Max(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left), (int)(Math.Max(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top));

        public static void MouseDown(MouseEventArgs e) {
            if (selectedPortal != null) {
                p0.X = (int)(e.Location.X / Camera.ZoomLevel + Camera.ViewArea.Left);
                p0.Y = (int)(e.Location.Y / Camera.ZoomLevel + Camera.ViewArea.Top);
                p1 = p0;

                if (!PlacingEntry) {
                    selectedPortal.ExitPoint = p0;
                    MapPieceCache.CurrentPiece.Edited();
                } else {
                    DoingSomething = true;
                }
            }
        }

        public static void MouseUp(MouseEventArgs e) {
            if (DoingSomething && PlacingEntry && selectedPortal != null) {
                Point p0a = new Point(Math.Min(p0.X, p1.X), Math.Min(p0.Y, p1.Y));
                Point p1a = new Point(Math.Max(p0.X, p1.X), Math.Max(p0.Y, p1.Y));

                selectedPortal.EntryPoint = p0a;
                selectedPortal.EntrySize.Width = p1a.X - p0a.X;
                selectedPortal.EntrySize.Height = p1a.Y - p0a.Y;
                MapPieceCache.CurrentPiece.Edited();
            }

            DoingSomething = false;
        }

        internal static bool UpdateMouse(MouseEventArgs e, LBuffer inputBuffer) {
            inputBuffer.gfx.Clear(Color.Transparent);

            if (DoingSomething && selectedPortal != null && p0 != Point.Empty) {
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
            foreach (Portal p in DrawList) {
                int x = (int)((p.EntryPoint.X - Camera.ViewArea.Left) * Camera.ZoomLevel);
                int y = (int)((p.EntryPoint.Y - Camera.ViewArea.Top) * Camera.ZoomLevel);
                int w = p.EntrySize.Width;
                int h = p.EntrySize.Height;

                buffer.gfx.DrawRectangle(Pens.Fuchsia, x, y, w, h);

                x = (int)((p.ExitPoint.X - Camera.ViewArea.Left) * Camera.ZoomLevel);
                y = (int)((p.ExitPoint.Y - Camera.ViewArea.Top) * Camera.ZoomLevel);
                buffer.gfx.FillEllipse(Brushes.CornflowerBlue, x - 10, y - 5, 20, 10);
            }
        }
    }
}
