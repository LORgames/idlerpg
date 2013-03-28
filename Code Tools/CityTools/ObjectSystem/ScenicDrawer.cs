using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Box2CS;
using CityTools.Core;
using ToolCache.Map.Objects;
using ToolCache.Drawing;
using ToolCache.Map;

namespace CityTools.ObjectSystem {
    public class BaseObjectDrawer {

        public static List<BaseObject> drawList = new List<BaseObject>();

        public static void DrawObjects(LBuffer buffer) {
            //drawList.Clear();

            //TODO: Figure out what to draw again

            drawList = MapPieceCache.CurrentPiece.Objects;
            drawList.Sort();

            foreach (BaseObject obj in drawList) {
                //obj.Draw(buffer);
                float x = (obj.Location.X - Camera.Offset.X) * Camera.ZoomLevel;
                float y = (obj.Location.Y - Camera.Offset.Y) * Camera.ZoomLevel;

                if (MainWindow.instance.chkShowObjectBases.Checked) {
                    Rectangle b = TemplateCache.G(obj.ObjectType).Base;

                    Rectangle r = new Rectangle();

                    r.X = (int)(x + b.X * Camera.ZoomLevel);
                    r.Y = (int)(y + b.Y * Camera.ZoomLevel);
                    r.Width = (int)(b.Width * Camera.ZoomLevel);
                    r.Height = (int)(b.Height * Camera.ZoomLevel);

                    buffer.gfx.FillRectangle(Brushes.Magenta, r);

                    TemplateCache.G(obj.ObjectType).Animation.Draw(buffer.gfx, x, y, Camera.ZoomLevel, 0.33f);
                } else {
                    TemplateCache.G(obj.ObjectType).Animation.Draw(buffer.gfx, x, y, Camera.ZoomLevel);
                }

                
            }
        }
    }
}
