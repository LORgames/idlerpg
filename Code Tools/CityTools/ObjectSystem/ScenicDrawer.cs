using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Box2CS;
using CityTools.Core;
using ToolCache.Map.Objects;
using ToolCache.Drawing;

namespace CityTools.ObjectSystem {
    public class BaseObjectDrawer {

        public static List<BaseObject> drawList = new List<BaseObject>();

        public static void DrawObjects(LBuffer buffer) {
            drawList.Clear();

            RectangleF drawArea = Camera.ViewArea;

            //Figure out what to draw again

            drawList.Sort();

            foreach (BaseObject obj in drawList) {
                //obj.Draw(buffer);

                //Draw things again
            }
        }
    }
}
