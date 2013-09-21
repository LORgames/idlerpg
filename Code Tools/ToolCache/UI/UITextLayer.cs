using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using ToolCache.Scripting;

namespace ToolCache.UI {
    public class UITextLayer : UILayer {
        public string Message = "";

        protected override void ReadFromBinaryIOX(General.BinaryIO f) {
            base.ReadFromBinaryIOX(f);
            Message = f.GetString();
        }

        internal override void WriteToBinaryIO(General.BinaryIO f) {
            base.WriteToBinaryIO(f);
            f.AddString(Message);
        }

        private string PrepareString() {
            Regex regex = new Regex("{("+ScriptCommand.VARIABLE_REGEX+")}");
            MatchCollection mc = regex.Matches(Message);

            if (mc.Count > 0) {
                string builder = "";
                int i = 0;
                int last_end = 0;

                for(i = 0; i < mc.Count; i++) {
                    builder = builder + Message.Substring(last_end, mc[i].Index-last_end);

                    if(GlobalVariables.Variables.ContainsKey(mc[i].Groups[1].Value)) {
                        builder = builder + GlobalVariables.Variables[mc[i].Groups[1].Value].InitialValue;
                    } else {
                        builder = builder + "<UNKNOWN VAR>";
                    }

                    last_end = mc[i].Index + mc[i].Length;
                }

                return builder;
            }

            return Message;
        }

        internal override void Draw(System.Drawing.Graphics gfx, System.Drawing.Rectangle canvasArea, UIElement owner, float displayValue) {
            if (this.Message != "") {
                string displayString = PrepareString();

                Font f = SystemFonts.DefaultFont;
                SizeF size = gfx.MeasureString(displayString, f);

                RectangleF r = new RectangleF(0, 0, size.Width, size.Height);

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

                r.X += canvasArea.X;
                r.Y += canvasArea.Y;

                if (MyType == UILayerType.PanX) r.X += (int)(SizeX * displayValue);
                if (MyType == UILayerType.PanY) r.Y += (int)(SizeY * displayValue);
                if (MyType == UILayerType.PanXNeg) r.X += (int)(SizeX * (1 - displayValue));
                if (MyType == UILayerType.PanYNeg) r.Y += (int)(SizeY * (1 - displayValue));

                gfx.DrawString(displayString, f, Brushes.White, r.Location);
            }
        }

        public override string ToString() {
            return base.ToString()+" [T]";
        }
    }
}
