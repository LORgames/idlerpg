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
        public bool AnimateInTool = true;

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

            byte booleanData = f.GetByte();
            m.isSolid = (booleanData & (byte)0x1) == 0x1;
            m.IndividualAnimations = (booleanData & (byte)0x2) == 0x2;
            m.AnimateInTool = (booleanData & (byte)0x4) != 0x4; //Is backwards compared to the others, 0=true, 4=false

            m.Animation.Paused = m.AnimateInTool;

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

            f.AddByte(GetBooleanData());
            f.AddShort((short)OffsetY);
        }

        public byte GetBooleanData() {
            byte booleanData = 0;
            booleanData |= (isSolid ? (byte)1 : (byte)0);
            booleanData |= (IndividualAnimations ? (byte)2 : (byte)0);
            booleanData |= (AnimateInTool ? (byte)0 : (byte)4); //Is backwards compared to the others, 0=true, 4=false

            return booleanData;
        }
    }
}
