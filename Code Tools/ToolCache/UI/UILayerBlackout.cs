using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using System.IO;
using ToolCache.Storage;

namespace ToolCache.UI {
    public class UILayerBlackout : UILayer {
        public int Colour = unchecked((int)0xB0000000); //Full 32 bit, ARGB

        private Brush myBrush;

        public void CreateBrush() {
            myBrush = new SolidBrush(Color.FromArgb(Colour));
            System.Diagnostics.Debug.WriteLine("BlkOutColor=" + Colour.ToString("X8"));
        }

        protected override void ReadFromBinaryIOX(IStorage f) {
            base.ReadFromBinaryIOX(f);
            Colour = f.GetInt();

            CreateBrush();
        }

        internal override void WriteToBinaryIO(IStorage f) {
            base.WriteToBinaryIO(f);
            f.AddInt(Colour);
        }

        internal override void Draw(Graphics gfx, Rectangle canvasArea, UIElement owner, float displayValue, bool drawRect) {
            Rectangle thisArea = new Rectangle(0, 0, SizeX, SizeY);

            //Calculate X
            switch (AnchorPoint) {
                case UIAnchorPoint.BottomLeft: case UIAnchorPoint.MiddleLeft: case UIAnchorPoint.TopLeft:
                    thisArea.X = OffsetX; break;
                case UIAnchorPoint.BottomRight: case UIAnchorPoint.MiddleRight: case UIAnchorPoint.TopRight:
                    thisArea.X = canvasArea.Width - SizeX - OffsetX; break;
                default:
                    thisArea.X = (canvasArea.Width - SizeX) / 2 + OffsetX; break;
            }

            //Calculate Y
            switch (AnchorPoint) {
                case UIAnchorPoint.BottomLeft: case UIAnchorPoint.BottomCenter: case UIAnchorPoint.BottomRight:
                    thisArea.Y = canvasArea.Height - SizeY - OffsetY; break;
                case UIAnchorPoint.TopLeft: case UIAnchorPoint.TopCenter: case UIAnchorPoint.TopRight:
                    thisArea.Y = OffsetY; break;
                default:
                    thisArea.Y = (canvasArea.Height - SizeY) / 2 + OffsetY; break;
            }

            thisArea.X += canvasArea.X;
            thisArea.Y += canvasArea.Y;

            int L = thisArea.X;
            int R = thisArea.X + thisArea.Width;
            int T = thisArea.Y;
            int B = thisArea.Y + thisArea.Height;
            int W = (int)gfx.ClipBounds.Width;
            int H = (int)gfx.ClipBounds.Height;

            if (myBrush == null) CreateBrush();

            gfx.FillRectangle(myBrush, new Rectangle(0, 0, L, H));
            gfx.FillRectangle(myBrush, new Rectangle(R, 0, W-R, H));
            gfx.FillRectangle(myBrush, new Rectangle(L, 0, R-L, T));
            gfx.FillRectangle(myBrush, new Rectangle(L, B, R-L, H-B));
        }

        public override string ToString() {
            return base.ToString() + " [B]";
        }
    }
}
