using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using System.Drawing;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.Map.Objects {
    public class MapObject {
        public short ObjectID = -1;
        public string ObjectName = "Unknown";
        public string ObjectGroup = "Unknown";

        public string Script = "";

        public Dictionary<String, AnimatedObject> Animations = new Dictionary<String, AnimatedObject>();
        public List<Rectangle> Blocks = new List<Rectangle>();

        public int OffsetY = 0;

        public bool isSolid = true;
        public bool IndividualAnimations = false;

        public MapObject() {
            Animations["Default"] = new AnimatedObject();
        }

        internal static MapObject LoadFromBinaryIO(IStorage f) {
            MapObject m = new MapObject();

            m.ObjectID = f.GetShort();

            m.Animations["Default"] = AnimatedObject.UnpackFromBinaryIO(f);

            short totalOtherAnimations = f.GetShort();
            for (int i = 0; i < totalOtherAnimations; i++) {
                string animName = f.GetString();
                AnimatedObject ao = AnimatedObject.UnpackFromBinaryIO(f);
                m.Animations.Add(animName, ao);
            }

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
            
            m.OffsetY = f.GetShort();

            return m;
        }

        internal void WriteToBinaryIO(IStorage f) {
            CleanUpAnimations();

            f.AddShort(ObjectID);

            Animations["Default"].PackIntoBinaryIO(f);

            f.AddShort((short)(Animations.Count-1)); //Default is stored differently
            foreach (KeyValuePair<String, AnimatedObject> kvp in Animations) {
                if (kvp.Key != "Default") {
                    f.AddString(kvp.Key);
                    kvp.Value.PackIntoBinaryIO(f);
                }
            }

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

        public List<String> CleanUpAnimations() {
            List<String> DudAnimations = new List<string>();
            foreach (KeyValuePair<String, AnimatedObject> kvp in Animations) {
                if (kvp.Key != "Default" && kvp.Value.Frames.Count == 0) {
                    DudAnimations.Add(kvp.Key);
                }
            }

            foreach (String s in DudAnimations) {
                Animations.Remove(s);
            }

            return DudAnimations;
        }

        public byte GetBooleanData() {
            byte booleanData = 0;
            booleanData |= (isSolid ? (byte)1 : (byte)0);
            booleanData |= (IndividualAnimations ? (byte)2 : (byte)0);
            
            return booleanData;
        }
    }
}
