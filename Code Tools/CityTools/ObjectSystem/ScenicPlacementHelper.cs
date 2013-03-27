using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using CityTools.Core;
using ToolCache.Drawing;
using ToolCache.Map;
using ToolCache.Map.Objects;

namespace CityTools.ObjectSystem {
    class ScenicPlacementHelper {
        public static short object_index = 0;

        internal static bool UpdateMouse(MouseEventArgs e, LBuffer inputBuffer) {
            inputBuffer.gfx.Clear(Color.Transparent);
            MainWindow.instance.paintingAnimation.Draw(inputBuffer.gfx, e.X, e.Y, Camera.ZoomLevel);

            return false;
        }

        internal static bool MouseDown(MouseEventArgs e, LBuffer input_buffer) {
            MapPieceCache.CurrentPiece.Objects.Add(new BaseObject(object_index, new Point((int)((e.X + Camera.Offset.X) / Camera.ZoomLevel), (int)((e.Y + Camera.Offset.Y) / Camera.ZoomLevel))));
            MapPieceCache.CurrentPiece.Edited();

            return true;
        }
    }
}
