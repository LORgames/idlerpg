﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using ToolCache.Scripting;
using ToolCache.Scripting.Extensions;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.UI {
    public class UILayerText : UILayer {
        public string Message = "";

        public UIAnchorPoint Align = UIAnchorPoint.TopLeft;
        public int FontFamily = 0;          //Font family ID
        public int FontSize = 20;           //Font size in pixels
        
        public bool WordWrap = false;       //Is this a box or just a line
        public byte InputType = 0;          //Is this box an input field or not

        public Color Colour = Color.White;  //Font colour for the text

        protected override void ReadFromBinaryIOX(IStorage f) {
            base.ReadFromBinaryIOX(f);
            Message = f.GetString();

            Align = (UIAnchorPoint)f.GetByte();
            FontFamily = f.GetByte();
            FontSize = f.GetByte();

            byte info = f.GetByte();

            WordWrap = (info & 1) == 1;
            InputType = (byte)(info>>1);

            Colour = Color.FromArgb(f.GetInt());
        }

        internal override void WriteToBinaryIO(IStorage f) {
            base.WriteToBinaryIO(f);
            f.AddString(Message);

            f.AddByte((byte)Align);
            f.AddByte((byte)FontFamily);
            f.AddByte((byte)FontSize);

            byte info = (byte)((WordWrap ? 1 : 0) | (InputType<<1));
            f.AddByte(info);

            f.AddInt(Colour.ToArgb());
        }

        internal override void Draw(System.Drawing.Graphics gfx, System.Drawing.Rectangle canvasArea, UIElement owner, float displayValue, bool drawRect) {
            if (this.Message != "") {
                string displayString = StringMagic.PrepareString(Message);

                Font f = new Font(UIManager.Fonts[FontFamily], (int)(FontSize*0.75));
                SizeF size = gfx.MeasureString(displayString, f, WordWrap?SizeX:0);

                RectangleF r = new RectangleF(0, 0, WordWrap?SizeX:size.Width, size.Height);
                StringFormat format = new StringFormat();

                //Calculate X
                switch (AnchorPoint) {
                    case UIAnchorPoint.BottomLeft:
                    case UIAnchorPoint.MiddleLeft:
                    case UIAnchorPoint.TopLeft:
                        r.X = OffsetX;
                        break;
                    case UIAnchorPoint.BottomRight:
                    case UIAnchorPoint.MiddleRight:
                    case UIAnchorPoint.TopRight:
                        r.X = canvasArea.Width - SizeX - OffsetX;
                        break;
                    default:
                        r.X = (canvasArea.Width - SizeX) / 2 + OffsetX;
                        break;
                }

                //Calculate Y
                switch (AnchorPoint) {
                    case UIAnchorPoint.BottomLeft:
                    case UIAnchorPoint.BottomCenter:
                    case UIAnchorPoint.BottomRight:
                        r.Y = canvasArea.Height - SizeY - OffsetY;
                        break;
                    case UIAnchorPoint.TopLeft:
                    case UIAnchorPoint.TopCenter:
                    case UIAnchorPoint.TopRight:
                        r.Y = OffsetY;
                        break;
                    default:
                        r.Y = (canvasArea.Height - SizeY) / 2 + OffsetY;
                        break;
                }

                //Calculate X
                switch (Align) {
                    case UIAnchorPoint.BottomCenter:
                    case UIAnchorPoint.MiddleCenter:
                    case UIAnchorPoint.TopCenter:
                        if (WordWrap) {
                            format.Alignment = StringAlignment.Center;
                        } else {
                            r.X -= size.Width / 2;
                        }
                        break;
                    case UIAnchorPoint.BottomRight:
                    case UIAnchorPoint.MiddleRight:
                    case UIAnchorPoint.TopRight:
                        if (WordWrap) {
                            format.Alignment = StringAlignment.Far;
                        } else {
                            r.X -= size.Width;
                        }
                        break;
                }

                //Calculate Y
                switch (Align) {
                    case UIAnchorPoint.BottomLeft:
                    case UIAnchorPoint.BottomCenter:
                    case UIAnchorPoint.BottomRight:
                        r.Y -= size.Height;
                        break;
                    case UIAnchorPoint.MiddleLeft:
                    case UIAnchorPoint.MiddleCenter:
                    case UIAnchorPoint.MiddleRight:
                        r.Y -= size.Height / 2;
                        break;
                }

                r.X += canvasArea.X;
                r.Y += canvasArea.Y;

                //if (MyType == UILayerType.PanX) r.X += (int)(SizeX * displayValue);
                //if (MyType == UILayerType.PanY) r.Y += (int)(SizeY * displayValue);
                //if (MyType == UILayerType.PanXNeg) r.X += (int)(SizeX * (1 - displayValue));
                //if (MyType == UILayerType.PanYNeg) r.Y += (int)(SizeY * (1 - displayValue));

                if(drawRect) gfx.DrawRectangle(new Pen(Colour), new Rectangle((int)r.X, (int)r.Y, (int)r.Width, (int)r.Height));
                gfx.DrawString(displayString, f, new SolidBrush(Colour), r, format);
            }
        }

        public override string ToString() {
            return base.ToString()+" [T]";
        }
    }
}