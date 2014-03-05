using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ToolCache.General {
    public class RectangleX {
        public int X;
        public int Y;
        public int W;
        public int H;
        public float Rotation;

        public RectangleX() {
            X = 0; Y = 0; W = 0; H = 0; Rotation = 0;
        }

        public RectangleX(int _x, int _y, int _w, int _h, float _r) {
            X = _x;
            Y = _y;
            W = _w;
            H = _h;
            Rotation = _r;
        }

        public bool Contains(RectangleX other) {
            if (Rotation == 0.0f && other.Rotation == 0.0f) {
                Rectangle r0 = new Rectangle(X, Y, W, H);
                Rectangle r1 = new Rectangle(other.X, other.Y, other.W, other.H);

                return r0.Contains(r1);
            } else {

            }

            return false;
        }

        public bool IntersectsWith(RectangleX other) {
            if (Rotation == 0.0f && other.Rotation == 0.0f) {
                Rectangle r0 = new Rectangle(X, Y, W, H);
                Rectangle r1 = new Rectangle(other.X, other.Y, other.W, other.H);

                return r0.IntersectsWith(r1);
            } else {

            }

            return false;
        }

        public void Draw(Graphics graphics, Pen pen, float ox = 0, float oy = 0) {
            if (Rotation == 0.0f) {
                graphics.DrawRectangle(pen, ox+X, oy+Y, W, H);
            } else {
                float x = (float)Math.Cos(Rotation);

                PointF _X = new PointF((float)Math.Cos(Rotation) * W, (float)Math.Sin(Rotation) * W);
                PointF _Y = new PointF((float)Math.Sin(Rotation) * H, -(float)Math.Cos(Rotation) * H);
                
                PointF p0 = new PointF(ox + X, oy + Y);
                PointF p1 = new PointF(ox + X + _X.X, oy + Y + _X.Y);
                PointF p2 = new PointF(ox + X + _Y.X, oy + Y + _Y.Y);
                PointF p3 = new PointF(ox + X + _X.X + _Y.X, oy + Y + _X.Y + _Y.Y);

                graphics.DrawLine(pen, p0, p1);
                graphics.DrawLine(pen, p0, p2);
                graphics.DrawLine(pen, p2, p3);
                graphics.DrawLine(pen, p1, p3);
            }
        }

        public void DrawFilled(Graphics graphics, Brush brush, float ox = 0, float oy = 0) {
            if (Rotation == 0.0f) {
                graphics.FillRectangle(brush, ox + X, oy + Y, W, H);
            } else {
                float x = (float)Math.Cos(Rotation);

                PointF _X = new PointF((float)Math.Cos(Rotation) * W, (float)Math.Sin(Rotation) * W);
                PointF _Y = new PointF((float)Math.Sin(Rotation) * H, -(float)Math.Cos(Rotation) * H);

                PointF p0 = new PointF(ox + X, oy + Y);
                PointF p1 = new PointF(ox + X + _X.X, oy + Y + _X.Y);
                PointF p2 = new PointF(ox + X + _Y.X, oy + Y + _Y.Y);
                PointF p3 = new PointF(ox + X + _X.X + _Y.X, oy + Y + _X.Y + _Y.Y);

                graphics.FillPolygon(brush, new PointF[] { p0, p1, p3, p2 });
            }
        }
    }
}
