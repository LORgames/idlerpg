using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.Drawing;

namespace ToolCache.UI {
    public enum UIAnchorPoint {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    public class UIElement {
        public List<UILayer> Layers = new List<UILayer>();
        public string Name = "";
        public short OffsetX = 0;
        public short OffsetY = 0;
        public UIAnchorPoint AnchorPoint = UIAnchorPoint.TopLeft;
        public short SizeX = 0;
        public short SizeY = 0;
        public string Script = "";

        public static UIElement ReadFromBinaryIO(BinaryIO f) {
            UIElement ui = new UIElement();

            ui.Name = f.GetString();

            ui.OffsetX = f.GetShort();
            ui.OffsetY = f.GetShort();
            ui.SizeX = f.GetShort();
            ui.SizeY = f.GetShort();

            ui.AnchorPoint = (UIAnchorPoint)f.GetByte();

            ui.Script = f.GetString();

            short totalLayers = f.GetByte();
            while (--totalLayers > -1) {
                ui.Layers.Add(UILayer.ReadFromBinaryIO(f));
            }

            return ui;
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddString(Name);

            f.AddShort(OffsetX);
            f.AddShort(OffsetY);
            f.AddShort(SizeX);
            f.AddShort(SizeY);

            f.AddByte((byte)AnchorPoint);

            f.AddString(Script);

            f.AddByte((byte)Layers.Count);
            foreach (UILayer layer in Layers) {
                layer.WriteToBinaryIO(f);
            }
        }

        public void Draw(Graphics gfx, Rectangle canvasArea, float displayValue) {
            Rectangle thisArea = new Rectangle(0, 0, SizeX, SizeY);

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

            foreach (UILayer layer in Layers) {
                layer.Draw(gfx, thisArea, this, displayValue);
            }

            gfx.DrawRectangle(Pens.Blue, thisArea);
        }

        public override string ToString() {
            if (Name != "") {
                return Name;
            }

            return "[UNNAMED]";
        }
    }
}
