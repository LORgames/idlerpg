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
                ToolCache.Map.Objects.TemplateCache.G(obj.ObjectType).Animation.Draw(buffer.gfx, obj.Location.X * Camera.ZoomLevel - Camera.Offset.X, obj.Location.Y * Camera.ZoomLevel - Camera.Offset.Y, Camera.ZoomLevel);
            }
        }
    }
}
