using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using ToolCache.Scripting;

namespace ToolCache.UI {
    public enum UILayerType {
        Static,
        Tile,
        Stretch,
        StretchToValueX,
        StretchToValueY,
        StretchToValueXNeg,
        StretchToValueYNeg,
        PanX,
        PanY,
        PanXNeg,
        PanYNeg,
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

        public UILayer() {

        }

        internal static UILayer ReadFromBinaryIO(BinaryIO f) {
            byte type = f.GetByte();

            UILayer ul;

            if (type == 0) {
                ul = new UIImageLayer();
            } else {
                ul = new UITextLayer();
            }

            ul.ReadFromBinaryIOX(f);
            return ul;
        }

        protected virtual void ReadFromBinaryIOX(BinaryIO f) {
            Name = f.GetString();

            MyType = (UILayerType)f.GetByte();
            AnchorPoint = (UIAnchorPoint)f.GetByte();

            SizeX = f.GetShort();
            SizeY = f.GetShort();
            OffsetX = f.GetShort();
            OffsetY = f.GetShort();
        }

        internal virtual void WriteToBinaryIO(BinaryIO f) {
            if (this is UIImageLayer) f.AddByte(0); //0 for UIImageLayer, 1 for UITextLayer
            if (this is UITextLayer) f.AddByte(1); //0 for UIImageLayer, 1 for UITextLayer

            f.AddString(Name);

            f.AddByte((byte)MyType);
            f.AddByte((byte)AnchorPoint);

            f.AddShort(SizeX);
            f.AddShort(SizeY);
            f.AddShort(OffsetX);
            f.AddShort(OffsetY);
        }

        public override string ToString() {
            if (Name != "") return Name;
            return "Unnamed";
        }

        internal virtual void Draw(Graphics gfx, Rectangle canvasArea, UIElement owner, float displayValue) {
            
        }
    }
}
