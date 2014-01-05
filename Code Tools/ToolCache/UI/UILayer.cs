using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using ToolCache.Scripting;
using ToolCache.Storage;

namespace ToolCache.UI {
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

        internal static UILayer ReadFromBinaryIO(IStorage f) {
            byte type = f.GetByte();

            UILayer ul;

            if (type == 0) {
                ul = new UILayerImage();
            } else if (type == 1) {
                ul = new UILayerText();
            } else if (type == 2) {
                ul = new UILayerLibrary();
            } else if (type == 3) {
                ul = new UILayerRoller();
            } else if (type == 4) {
                ul = new UILayerBlackout();
            } else {
                throw new Exception("Cannot find that type of layer!");
            }

            ul.ReadFromBinaryIOX(f);
            return ul;
        }

        protected virtual void ReadFromBinaryIOX(IStorage f) {
            Name = f.GetString();

            MyType = (UILayerType)f.GetByte();
            AnchorPoint = (UIAnchorPoint)f.GetByte();

            SizeX = f.GetShort();
            SizeY = f.GetShort();
            OffsetX = f.GetShort();
            OffsetY = f.GetShort();
        }

        internal virtual void WriteToBinaryIO(IStorage f) {
            if (this is UILayerImage) f.AddByte(0);         //0 for UILayerImage
            else if (this is UILayerText) f.AddByte(1);     //1 for UILayerText
            else if (this is UILayerLibrary) f.AddByte(2);  //2 for UILayerLibrary
            else if (this is UILayerRoller) f.AddByte(3);   //3 for UILayerRoller
            else if (this is UILayerBlackout) f.AddByte(4); //4 for UILayerBlackout
            else throw new Exception("Unknown Layer Type!");
            
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

        internal virtual void Draw(Graphics gfx, Rectangle canvasArea, UIElement owner, float displayValue, bool drawRect) {
            
        }
    }
}
