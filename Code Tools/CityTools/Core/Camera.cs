using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CityTools.Core {
    public class Camera {
        public static PointF Offset = Point.Empty;
        public static RectangleF ViewArea = new Rectangle();
        public static float ZoomLevel = 1.0f;

        public static void FixViewArea(Size drawArea) {
            Offset.X = (float)Math.Round(Offset.X);
            Offset.Y = (float)Math.Round(Offset.Y);

            ViewArea = new RectangleF(Offset, new Size((int)(drawArea.Width / ZoomLevel), (int)(drawArea.Height / ZoomLevel)));
        }

        public static bool ProcessKeys(Keys keyData) {
            if (keyData == Keys.W || keyData == Keys.A || keyData == Keys.S || keyData == Keys.D || keyData == Keys.Subtract || keyData == Keys.Add) {
                if (keyData == Keys.W) {
                    Offset.Y -= 100 / ZoomLevel;
                } else if (keyData == Keys.A) {
                    Offset.X -= 100 / ZoomLevel;
                } else if (keyData == Keys.S) {
                    Offset.Y += 100 / ZoomLevel;
                } else if (keyData == Keys.D) {
                    Offset.X += 100 / ZoomLevel;
                } else if (keyData == Keys.Subtract) {
                    ZoomLevel *= 0.98f;
                } else if (keyData == Keys.Add) {
                    ZoomLevel *= 1.02f;
                }

                if (ZoomLevel < 0.01f) ZoomLevel = 0.01f;
                if (ZoomLevel > 1.0f) ZoomLevel = 1.0f;

                return true;
            }

            return false;
        }

        public static float[] Pack() {
            float[] values = new float[7];

            values[0] = Offset.X;
            values[1] = Offset.Y;
            values[2] = ViewArea.X;
            values[3] = ViewArea.Y;
            values[4] = ViewArea.Width;
            values[5] = ViewArea.Height;
            values[6] = ZoomLevel;

            return values;
        }

        public static void Unpack(float[] values) {
            Offset.X = values[0];
            Offset.Y = values[1];
            ViewArea.X = values[2];
            ViewArea.Y = values[3];
            ViewArea.Width = values[4];
            ViewArea.Height = values[5];
            ZoomLevel = values[6];
        }
    }
}
