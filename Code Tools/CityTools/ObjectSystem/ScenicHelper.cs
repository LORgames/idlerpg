using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Box2CS;
using CityTools.Core;
using ToolCache.Map.Objects;
using ToolCache.Drawing;
using ToolCache.Map;

namespace CityTools.ObjectSystem {
    public class ScenicHelper {
        private static List<BaseObject> selectedObjects = new List<BaseObject>();

        private static PointF p0 = Point.Empty;
        private static PointF p1 = Point.Empty;

        private static int BASIC_MOVE = 1;
        private static int SHIFT_MOVE = 5;

        public static void MouseDown(MouseEventArgs e) {
            p0 = e.Location;
            p1 = e.Location;
        }

        public static void MouseUp(MouseEventArgs e) {
            foreach (BaseObject s in selectedObjects) {
                s.selected = false;
            }

            selectedObjects.Clear();

            PointF p0a = new PointF(Math.Min(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left, Math.Min(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top);
            PointF p1a = new PointF(Math.Max(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left, Math.Max(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top);

            //TODO: Figure out which objects MIGHT have been selected

            selectedObjects.Sort();

            // If p0 and p1 are the same or the event was triggered by right clicking, only select the top object
            if (p0 == p1 || e.Button == MouseButtons.Right) {
                selectedObjects.RemoveRange(0, selectedObjects.Count - 1);
            }

            p0 = Point.Empty;
            p1 = Point.Empty;
        }

        internal static bool UpdateMouse(MouseEventArgs e, LBuffer inputBuffer) {
            if (p0 != Point.Empty) {
                p1 = e.Location;

                inputBuffer.gfx.Clear(Color.Transparent);

                inputBuffer.gfx.FillRectangle(new SolidBrush(Color.FromArgb(32, Color.Fuchsia)), Math.Min(p0.X, p1.X), Math.Min(p0.Y, p1.Y), Math.Abs(p1.X - p0.X), Math.Abs(p1.Y - p0.Y));
                inputBuffer.gfx.DrawRectangle(new Pen(Color.Fuchsia), Math.Min(p0.X, p1.X), Math.Min(p0.Y, p1.Y), Math.Abs(p1.X - p0.X), Math.Abs(p1.Y - p0.Y));

                return true;
            }

            return false;
        }

        internal static void MoveSelectedObjects(int x, int y) {
            // Iterate over each selected object and move it
            for (int i = 0; i < selectedObjects.Count; i++) {
                selectedObjects[i].Move(x, y);
            }
        }

        internal static void DeleteSelectedObjects() {
            MapPieceCache.CurrentPiece.Edited();

            // Iterate over each selected object and delete it
            for (int i = 0; i < selectedObjects.Count; i++) {
                selectedObjects[i].Delete();
            }

            // Clear the list of selected objects, they should all be deleted now.
            selectedObjects.Clear();
        }

        public static bool ProcessCmdKey(ref Message msg, Keys keyData) {
            // Ignore shift, only use actual keys
            Keys noShift = (Keys)keyData & ~Keys.Shift;

            // Is shift held?
            bool hasShift = ((Keys)keyData & Keys.Shift) == Keys.Shift;

            if (noShift == Keys.Left) {
                // Left is negative, hence the -
                MoveSelectedObjects(-(hasShift ? SHIFT_MOVE : BASIC_MOVE), 0);

            } else if (noShift == Keys.Right) {
                // Right is positive
                MoveSelectedObjects((hasShift ? SHIFT_MOVE : BASIC_MOVE), 0);

            } else if (noShift == Keys.Up) {
                // Up is negative, hence the -
                MoveSelectedObjects(0, -(hasShift ? SHIFT_MOVE : BASIC_MOVE));

            } else if (noShift == Keys.Down) {
                // Down is positive
                MoveSelectedObjects(0, (hasShift ? SHIFT_MOVE : BASIC_MOVE));

            } else if (keyData == Keys.Delete) {
                // Pass deleting on!
                DeleteSelectedObjects();
            }


            return true;
        }
    }
}
