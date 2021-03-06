﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using System.IO;
using ToolCache.Storage;

namespace ToolCache.UI {
    public class UILayerRoller : UILayer {
        public string LibraryName = "";
        public string DatabaseName = "";
        public byte ScrollDirection = 2; //0=Left, 1=Right, 2=Up, 3=Down

        protected override void ReadFromBinaryIOX(IStorage f) {
            //LIBRARIES WILL ALWAYS BE NULL AT THIS POINT, LIBRARIES ARE LOADED AFTER LAYERS.

            base.ReadFromBinaryIOX(f);
            LibraryName = f.GetString();
            DatabaseName = f.GetString();
            ScrollDirection = f.GetByte();
        }

        internal override void WriteToBinaryIO(IStorage f) {
            base.WriteToBinaryIO(f);

            f.AddString(LibraryName);
            f.AddString(DatabaseName);
            f.AddByte(ScrollDirection);
        }

        internal override void Draw(System.Drawing.Graphics gfx, System.Drawing.Rectangle canvasArea, UIElement owner, float displayValue, bool drawRect) {
            UILibrary lib = UIManager.GetLibrary(LibraryName);

            if (lib != null) {
                Rectangle thisArea = new Rectangle(0, 0, SizeX, SizeY);

                if (MyType == UILayerType.StretchToValueX || MyType == UILayerType.StretchToValueXNeg) {
                    thisArea.Width = (int)(displayValue * SizeX);
                } if (MyType == UILayerType.StretchToValueY || MyType == UILayerType.StretchToValueYNeg) {
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
                        thisArea.X = (canvasArea.Width - SizeX) / 2 + OffsetX;
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
                        thisArea.Y = (canvasArea.Height - SizeY) / 2 + OffsetY;
                        break;
                }

                thisArea.X += canvasArea.X;
                thisArea.Y += canvasArea.Y;

                if (MyType == UILayerType.StretchToValueXNeg) thisArea.X += (int)((1 - displayValue) * SizeX);
                if (MyType == UILayerType.StretchToValueYNeg) thisArea.Y += (int)((1 - displayValue) * SizeY);

                if (!File.Exists(lib.Images[0])) return;

                Image im = ImageCache.RequestImage(lib.Images[0]);
                if (im == null) return;

                if (MyType == UILayerType.Stretch || MyType == UILayerType.StretchToValueX || MyType == UILayerType.StretchToValueY || MyType == UILayerType.StretchToValueXNeg || MyType == UILayerType.StretchToValueYNeg) {
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
                } else if (MyType == UILayerType.PanX || MyType == UILayerType.PanY || MyType == UILayerType.PanXNeg || MyType == UILayerType.PanYNeg) {
                    Rectangle r = new Rectangle(thisArea.X, thisArea.Y, im.Width, im.Height);
                    if (MyType == UILayerType.PanX) r.X += (int)(SizeX * displayValue);
                    if (MyType == UILayerType.PanY) r.Y += (int)(SizeY * displayValue);
                    if (MyType == UILayerType.PanXNeg) r.X += (int)(SizeX * (1 - displayValue));
                    if (MyType == UILayerType.PanYNeg) r.Y += (int)(SizeY * (1 - displayValue));
                    gfx.DrawImageUnscaledAndClipped(im, r);
                }
            }
        }

        public override string ToString() {
            return base.ToString() + " [R]";
        }
    }
}
