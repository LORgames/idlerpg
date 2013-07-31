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

namespace CityTools.ObjectSystem {
    public class ScenicHelper {
        private static List<BaseObject> selectedObjects = new List<BaseObject>();
        public static List<BaseObject> drawList = new List<BaseObject>();

        private static Point p0 = Point.Empty;
        private static Point p1 = Point.Empty;

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

            Point p0a = new Point((int)(Math.Min(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left), (int)(Math.Min(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top));
            Point p1a = new Point((int)(Math.Max(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left), (int)(Math.Max(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top));

            //Figure out which objects are in that bounding box
            Rectangle selectBox = new Rectangle(p0a.X, p0a.Y, p1a.X - p0a.X, p1a.Y - p0a.Y);

            List<TileInstance> tiles = MapPieceCache.CurrentPiece.Tiles.GetTilesFromWorldRectangle(p0a.X, p0a.Y, p1a.X - p0a.X, p1a.Y - p0a.Y);

            if (MapPieceCache.CurrentPiece.WorldRectangle.Contains(selectBox)) {
                foreach (TileInstance tile in tiles) {
                    List<BaseObject> objects = tile.EXOB;
                    for (int k = 0; k < objects.Count; k++) {
                        foreach (Rectangle r in objects[k].ActualBases) {
                            if (selectBox.IntersectsWith(r)) {
                                if (!selectedObjects.Contains(objects[k])) {
                                    selectedObjects.Add(objects[k]);
                                }
                            }
                        }
                    }
                }
            } else {
                foreach (BaseObject obj in MapPieceCache.CurrentPiece.Objects) {
                    foreach (Rectangle r in obj.ActualBases) {
                        if (selectBox.IntersectsWith(r)) {
                            selectedObjects.Add(obj);
                        }
                    }
                }
            }

            selectedObjects.Sort();

            if (selectedObjects.Count > 0) {
                // If p0 and p1 are the same or the event was triggered by right clicking, only select the top object
                if (p0 == p1 || e.Button == MouseButtons.Right) {
                    selectedObjects.RemoveRange(0, selectedObjects.Count - 1);
                }
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

            if (selectedObjects.Count > 0) MapPieceCache.CurrentPiece.Edited();
        }

        internal static void DeleteSelectedObjects() {
            MapPieceCache.CurrentPiece.Edited();

            // Iterate over each selected object and delete it
            for (int i = 0; i < selectedObjects.Count; i++) {
                selectedObjects[i].Delete();
            }

            if (selectedObjects.Count > 0) MapPieceCache.CurrentPiece.Edited();

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

        public static void DrawObjects(LBuffer buffer) {
            //Commented this out 
            //drawList.Clear();

            //TODO: Figure out what to draw instead of just drawing everything

            drawList = MapPieceCache.CurrentPiece.Objects;
            drawList.Sort();

            foreach (BaseObject obj in drawList) {
                //obj.Draw(buffer);
                float x = (obj.Location.X - Camera.Offset.X) * Camera.ZoomLevel;
                float y = (obj.Location.Y - Camera.Offset.Y) * Camera.ZoomLevel;

                if (MainWindow.instance.ckbShowObjectBases.Checked) {
                    foreach (Rectangle b in MapObjectCache.G(obj.ObjectType).Blocks) {
                        Rectangle r = new Rectangle();

                        r.X = (int)(x + b.X * Camera.ZoomLevel);
                        r.Y = (int)(y + b.Y * Camera.ZoomLevel);
                        r.Width = (int)(b.Width * Camera.ZoomLevel);
                        r.Height = (int)(b.Height * Camera.ZoomLevel);

                        if (!selectedObjects.Contains(obj)) {
                            buffer.gfx.FillRectangle(Brushes.Magenta, r);
                        } else {
                            buffer.gfx.FillRectangle(Brushes.Yellow, r);
                        }
                    }

                    MapObjectCache.G(obj.ObjectType).Animations["Default"].Draw(buffer.gfx, x, y, Camera.ZoomLevel, 0.33f);
                } else {
                    MapObjectCache.G(obj.ObjectType).Animations["Default"].Draw(buffer.gfx, x, y, Camera.ZoomLevel);
                }

                
            }
        }
    }
}
