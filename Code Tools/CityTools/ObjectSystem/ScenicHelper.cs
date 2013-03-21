﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Box2CS;
using CityTools.Core;
using CityTools.MapPieces;

namespace CityTools.ObjectSystem {
    public class ScenicHelper {
        private static List<ScenicObject> selectedObjects = new List<ScenicObject>();

        private static PointF p0 = Point.Empty;
        private static PointF p1 = Point.Empty;

        private static float BASIC_MOVE = 1.0f;
        private static float SHIFT_MOVE = 5.0f;

        public static void MouseDown(MouseEventArgs e) {
            p0 = e.Location;
            p1 = e.Location;
        }

        public static void MouseUp(MouseEventArgs e) {
            foreach (ScenicObject s in selectedObjects) {
                s.selected = false;
            }

            selectedObjects.Clear();

            PointF p0a = new PointF(Math.Min(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left, Math.Min(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top);
            PointF p1a = new PointF(Math.Max(p0.X, p1.X) / Camera.ZoomLevel + Camera.ViewArea.Left, Math.Max(p0.Y, p1.Y) / Camera.ZoomLevel + Camera.ViewArea.Top);

            AABB aabb = new AABB(new Vec2(p0a.X, p0a.Y), new Vec2(p1a.X, p1a.Y));

            Box2D.B2System.world.QueryAABB(new Box2CS.World.QueryCallbackDelegate(ScenicHelper.QCBD), aabb);

            // If p0 and p1 are the same or the event was triggered by right clicking, only select the top object
            if (p0 == p1 || e.Button == MouseButtons.Right) {
                int highestIndex = -1; // Highest index 

                // Locate the highest index
                for (int i = 0; i < selectedObjects.Count; i++) {

                    // If current objects index is higher, store it as the highest index
                    if (selectedObjects[i].index > highestIndex) {
                        highestIndex = selectedObjects[i].index;
                    }
                }

                // Remove all other objects
                for (int i = 0; i < selectedObjects.Count; i++) {
                    if (selectedObjects[i].index != highestIndex) {
                        selectedObjects[i].selected = false;
                        selectedObjects.RemoveAt(i);
                        i--;
                    }
                }
            }

            // If right clicked, show context menu
            if (e.Button == MouseButtons.Right && selectedObjects.Count != 0) {
                MainWindow.instance.contextMenuStrip1.Show((int)p0.X, (int)p0.Y);
            }

            p0 = Point.Empty;
            p1 = Point.Empty;
        }

        public static bool QCBD(Fixture fix) {
            if (fix.UserData is ScenicObject) {
                selectedObjects.Add(fix.UserData as ScenicObject);
                (fix.UserData as ScenicObject).selected = true;
            }

            return true;
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

        internal static void MoveSelectedObjects(float x, float y) {
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
                MoveSelectedObjects(-(hasShift ? SHIFT_MOVE : BASIC_MOVE), 0.0f);

            } else if (noShift == Keys.Right) {
                // Right is positive
                MoveSelectedObjects((hasShift ? SHIFT_MOVE : BASIC_MOVE), 0.0f);

            } else if (noShift == Keys.Up) {
                // Up is negative, hence the -
                MoveSelectedObjects(0.0f, -(hasShift ? SHIFT_MOVE : BASIC_MOVE));

            } else if (noShift == Keys.Down) {
                // Down is positive
                MoveSelectedObjects(0.0f, (hasShift ? SHIFT_MOVE : BASIC_MOVE));

            } else if (keyData == Keys.Delete) {
                // Pass deleting on!
                DeleteSelectedObjects();
            }


            return true;
        }

        private static int FindObjectIndex() {
            int currentIndex = selectedObjects[0].index;
            int listIndex = -1;

            // Find selected objects index
            for (int i = 0; i < MapPieceCache.CurrentPiece.Scenary.Count; i++) {
                if (currentIndex == MapPieceCache.CurrentPiece.Scenary[i].index) {
                    listIndex = i;
                }
            }

            return listIndex;
        }

        internal static void SendBack() {
            MapPieceCache.CurrentPiece.Edited();

            // Sort draw list by index
            MapPieceCache.CurrentPiece.Scenary.Sort();

            int listIndex = FindObjectIndex();

            if (listIndex != 0) {
                // Swap values
                int temp = MapPieceCache.CurrentPiece.Scenary[listIndex].index;
                MapPieceCache.CurrentPiece.Scenary[listIndex].index = MapPieceCache.CurrentPiece.Scenary[listIndex - 1].index;
                MapPieceCache.CurrentPiece.Scenary[listIndex - 1].index = temp;

                // Resort draw list by index
                MapPieceCache.CurrentPiece.Scenary.Sort();
            }
        }

        internal static void BringForward() {
            MapPieceCache.CurrentPiece.Edited();

            // Sort draw list by index
            MapPieceCache.CurrentPiece.Scenary.Sort();

            int listIndex = FindObjectIndex();

            if (listIndex != MapPieceCache.CurrentPiece.Scenary.Count - 1) {
                // Swap values
                int temp = MapPieceCache.CurrentPiece.Scenary[listIndex].index;
                MapPieceCache.CurrentPiece.Scenary[listIndex].index = MapPieceCache.CurrentPiece.Scenary[listIndex + 1].index;
                MapPieceCache.CurrentPiece.Scenary[listIndex + 1].index = temp;

                // Resort draw list by index
                MapPieceCache.CurrentPiece.Scenary.Sort();
            }
        }

        internal static void SendToBack() {
            MapPieceCache.CurrentPiece.Edited();

            // Sort draw list by index
            MapPieceCache.CurrentPiece.Scenary.Sort();

            int listIndex = FindObjectIndex();

            // Swap values until we reach the bottom
            for (int i = listIndex; i > 0; i--) {
                int temp = MapPieceCache.CurrentPiece.Scenary[i].index;
                MapPieceCache.CurrentPiece.Scenary[i].index = MapPieceCache.CurrentPiece.Scenary[i - 1].index;
                MapPieceCache.CurrentPiece.Scenary[i - 1].index = temp;

                // Resort draw list by index
                MapPieceCache.CurrentPiece.Scenary.Sort();
            }
        }

        internal static void BringToFront() {
            MapPieceCache.CurrentPiece.Edited();

            // Sort draw list by index
            MapPieceCache.CurrentPiece.Scenary.Sort();

            int listIndex = FindObjectIndex();

            // Swap values until we reach the top
            for (int i = listIndex; i < MapPieceCache.CurrentPiece.Scenary.Count - 1; i++) {
                int temp = MapPieceCache.CurrentPiece.Scenary[i].index;
                MapPieceCache.CurrentPiece.Scenary[i].index = MapPieceCache.CurrentPiece.Scenary[i + 1].index;
                MapPieceCache.CurrentPiece.Scenary[i + 1].index = temp;

                // Resort draw list by index
                MapPieceCache.CurrentPiece.Scenary.Sort();
            }
        }
    }
}
