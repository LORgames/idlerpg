using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;

namespace ToolCache.UI {
    public enum UILayerType {
        Static,
        Tile,
        Stretch,
        StretchToValueX,
        StretchToValueY,
        PanX,
        PanY,
        Radial
    }

    public class UILayer {
        public UILayerType MyType = UILayerType.Static;
        public UIAnchorPoint AnchorPoint = UIAnchorPoint.TopLeft;

        public string Name = "";

        public short SizeX = 0;
        public short SizeY = 0;
        public short OffsetX = 0;
        public short OffsetY = 0;

        public string ImageFilename = "";

        public UILayer() {

        }

        internal static UILayer ReadFromBinaryIO(BinaryIO f) {
            UILayer ul = new UILayer();

            ul.Name = f.GetString();

            ul.MyType = (UILayerType)f.GetByte();
            ul.AnchorPoint = (UIAnchorPoint)f.GetByte();

            ul.SizeX = f.GetShort();
            ul.SizeY = f.GetShort();
            ul.OffsetX = f.GetShort();
            ul.OffsetY = f.GetShort();

            ul.ImageFilename = f.GetString();

            return ul;
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddString(Name);

            f.AddByte((byte)MyType);
            f.AddByte((byte)AnchorPoint);

            f.AddShort(SizeX);
            f.AddShort(SizeY);
            f.AddShort(OffsetX);
            f.AddShort(OffsetY);

            f.AddString(ImageFilename);
        }

        public override string ToString() {
            if (Name != "") return Name;
            return "Unnamed";
        }

        internal void Draw(Graphics gfx, Rectangle canvasArea, UIElement owner, float displayValue) {
            if (this.ImageFilename != "") {
                Rectangle thisArea = new Rectangle(0, 0, SizeX, SizeY);

                if (MyType == UILayerType.StretchToValueX) {
                    thisArea.Width = (int)(displayValue * SizeX);
                } if (MyType == UILayerType.StretchToValueY) {
                    thisArea.Height = (int)(displayValue * SizeY);
                }

                //Calculate X
                switch (AnchorPoint) {
                    case UIAnchorPoint.BottomLeft:
                    case UIAnchorPoint.MiddleLeft:
                    case UIAnchorPoint.TopLeft:
                        thisArea.X = OffsetX;
                        break;
                    case UIAnchorPoint.BottomRight:
                    case UIAnchorPoint.MiddleRight:
                    case UIAnchorPoint.TopRight:
                        thisArea.X = canvasArea.Width - SizeX - OffsetX;
                        break;
                    default:
                        thisArea.X = (canvasArea.Width - SizeX) / 2;
                        break;
                }

                //Calculate Y
                switch (AnchorPoint) {
                    case UIAnchorPoint.BottomLeft:
                    case UIAnchorPoint.BottomCenter:
                    case UIAnchorPoint.BottomRight:
                        thisArea.Y = canvasArea.Height - SizeY - OffsetY;
                        break;
                    case UIAnchorPoint.TopLeft:
                    case UIAnchorPoint.TopCenter:
                    case UIAnchorPoint.TopRight:
                        thisArea.Y = OffsetY;
                        break;
                    default:
                        thisArea.Y = (canvasArea.Height - SizeY) / 2;
                        break;
                }

                thisArea.X += canvasArea.X;
                thisArea.Y += canvasArea.Y;

                Image im = ImageCache.RequestImage(ImageFilename);

                if (MyType == UILayerType.Stretch || MyType == UILayerType.StretchToValueX || MyType == UILayerType.StretchToValueY) {
                    gfx.DrawImage(im, thisArea);
                } else if (MyType == UILayerType.Static) {
                    gfx.DrawImageUnscaledAndClipped(im, thisArea);
                } else if (MyType == UILayerType.Tile) {
                    int xPos = 0;
                    int yPos = 0;

                    while (yPos < thisArea.Height) {
                        xPos = 0;

                        while (xPos < thisArea.Width) {

                            Rectangle thisTile = new Rectangle(xPos+thisArea.X, yPos+thisArea.Y, im.Width, im.Height);

                            if (yPos + im.Height > thisArea.Height) {
                                thisTile.Height = thisArea.Height - yPos;
                            }

                            if (xPos + im.Width > thisArea.Width) {
                                thisTile.Width = thisArea.Width - xPos;
                            }

                            gfx.DrawImageUnscaledAndClipped(im, thisTile);
                            xPos += im.Width;
                        }

                        yPos += im.Height;
                    }
                }
            }
        }
    }
}
