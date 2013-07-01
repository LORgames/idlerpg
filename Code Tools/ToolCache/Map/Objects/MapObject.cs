using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using System.Drawing;
using ToolCache.General;

namespace ToolCache.Map.Objects {
    public class MapObject {
        public short ObjectID = -1;
        public string ObjectName = "Unknown";
        public string ObjectGroup = "Unknown";

        public string Script = "";

        public AnimatedObject Animation = new AnimatedObject();
        public List<Rectangle> Blocks = new List<Rectangle>();

        public int OffsetY = 0;

        public bool isSolid = true;
        public bool IndividualAnimations = false;

        public MapObject() {
            
        }

        internal static MapObject LoadFromBinaryIO(BinaryIO f) {
            MapObject m = new MapObject();

            m.ObjectID = f.GetShort();
            m.Animation = AnimatedObject.UnpackFromBinaryIO(f);

            m.ObjectName = f.GetString();
            m.ObjectGroup = f.GetString();

            m.Script = f.GetString();

            int totalRectangles = f.GetByte();

            while (--totalRectangles > -1) {
                int BaseLeft = f.GetShort();
                int BaseTop = f.GetShort();
                int BaseWidth = f.GetShort();
                int BaseHeight = f.GetShort();

                Rectangle _base = new Rectangle(BaseLeft, BaseTop, BaseWidth, BaseHeight);
                m.Blocks.Add(_base);
            }

            m.isSolid = f.GetByte() == 1;
            m.OffsetY = f.GetShort();

            return m;
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddShort(ObjectID);

            Animation.PackIntoBinaryIO(f);

            f.AddString(ObjectName);
            f.AddString(ObjectGroup);

            f.AddString(Script);

            f.AddByte((byte)Blocks.Count);

            foreach (Rectangle r in Blocks) {
                f.AddShort((short)r.Left);
                f.AddShort((short)r.Top);
                f.AddShort((short)r.Width);
                f.AddShort((short)r.Height);
            }

            f.AddByte((isSolid ? (byte)1 : (byte)0));
            f.AddShort((short)OffsetY);
        }
    }
}
