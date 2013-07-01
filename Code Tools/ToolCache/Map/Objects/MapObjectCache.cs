using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;
using ToolCache.Animation;
using System.Drawing;

namespace ToolCache.Map.Objects {
    public class MapObjectCache {
        public const string RESOLVED_DATABASE_FILENAME = Settings.Database + "Objects.bin";

        public static Dictionary<short, MapObject> ObjectTypes = new Dictionary<short, MapObject>();
        private static Dictionary<string, List<short>> GroupsToObjectUUIDS = new Dictionary<string, List<short>>();

        private static short nextObjectID = 0;

        public static void Initialize() {
            ObjectTypes.Clear();
            GroupsToObjectUUIDS.Clear();

            nextObjectID = 0;

            ReadDatabase();
        }

        public static MapObject G(short id) {
            if (ObjectTypes.ContainsKey(id)) {
                return ObjectTypes[id];
            }

            return null;
        }

        private static void ReadDatabase() {
            // Load object types from file
            if (File.Exists(RESOLVED_DATABASE_FILENAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(RESOLVED_DATABASE_FILENAME));

                int totalObjects = f.GetInt();

                //This is where we load the BASIC information
                for (int i = 0; i < totalObjects; i++) {
                    short ObjectID = f.GetShort();
                    AnimatedObject animation = AnimatedObject.UnpackFromBinaryIO(f);

                    string ObjectName = f.GetString();
                    string ObjectGroup = f.GetString();

                    string Script = f.GetString();

                    int totalRectangles = f.GetByte();
                    List<Rectangle> _rects = new List<Rectangle>();

                    while (--totalRectangles > -1) {
                        int BaseLeft = f.GetShort();
                        int BaseTop = f.GetShort();
                        int BaseWidth = f.GetShort();
                        int BaseHeight = f.GetShort();

                        Rectangle _base = new Rectangle(BaseLeft, BaseTop, BaseWidth, BaseHeight);
                        _rects.Add(_base);
                    }

                    bool isSolid = f.GetByte() == 1;
                    int OffsetY = f.GetShort();

                    ObjectTypes.Add(ObjectID, new MapObject(ObjectID, ObjectName, ObjectGroup, animation, OffsetY, _rects, isSolid, Script));

                    if (!GroupsToObjectUUIDS.ContainsKey(ObjectGroup)) {
                        GroupsToObjectUUIDS.Add(ObjectGroup, new List<short>());
                    }

                    GroupsToObjectUUIDS[ObjectGroup].Add(ObjectID);

                    if (nextObjectID <= ObjectID) {
                        nextObjectID = ObjectID;
                        nextObjectID++;
                    }
                }
            }
        }

        public static void WriteDatabase() {
            BinaryIO f = new BinaryIO();
            f.AddInt(ObjectTypes.Count);

            foreach (KeyValuePair<short, MapObject> kvp in ObjectTypes) {
                f.AddShort(kvp.Key);

                kvp.Value.Animation.PackIntoBinaryIO(f);

                f.AddString(kvp.Value.ObjectName);
                f.AddString(kvp.Value.ObjectGroup);

                f.AddString(kvp.Value.Script);

                f.AddByte((byte)kvp.Value.Blocks.Count);

                foreach (Rectangle r in kvp.Value.Blocks) {
                    f.AddShort((short)r.Left);
                    f.AddShort((short)r.Top);
                    f.AddShort((short)r.Width);
                    f.AddShort((short)r.Height);
                }

                f.AddByte((kvp.Value.isSolid ? (byte)1 : (byte)0));
                f.AddShort((short)kvp.Value.OffsetY);
            }

            f.Encode(RESOLVED_DATABASE_FILENAME);
        }

        public static void AddObject(MapObject t) {
            if (ObjectTypes.ContainsKey(t.ObjectID)) {
                GroupsToObjectUUIDS[ObjectTypes[t.ObjectID].ObjectGroup].Remove(t.ObjectID);

                if (GroupsToObjectUUIDS[ObjectTypes[t.ObjectID].ObjectGroup].Count == 0) {
                    GroupsToObjectUUIDS.Remove(ObjectTypes[t.ObjectID].ObjectGroup);
                }
            }

            ObjectTypes.Add(t.ObjectID, t);

            if (!GroupsToObjectUUIDS.ContainsKey(t.ObjectGroup)) {
                GroupsToObjectUUIDS.Add(t.ObjectGroup, new List<short>());
            }

            GroupsToObjectUUIDS[t.ObjectGroup].Add(t.ObjectID);

            if (t.ObjectID >= nextObjectID) {
                nextObjectID = t.ObjectID;
                nextObjectID++;
            }
        }

        public static List<string> GetGroups() {
            return GroupsToObjectUUIDS.Keys.ToList<String>();
        }

        public static void Delete(short objectID) {
            if (ObjectTypes.ContainsKey(objectID)) {
                if (GroupsToObjectUUIDS.ContainsKey(ObjectTypes[objectID].ObjectGroup)) {
                    GroupsToObjectUUIDS[ObjectTypes[objectID].ObjectGroup].Remove(objectID);

                    if (GroupsToObjectUUIDS[ObjectTypes[objectID].ObjectGroup].Count == 0) {
                        GroupsToObjectUUIDS.Remove(ObjectTypes[objectID].ObjectGroup);
                    }
                }

                ObjectTypes.Remove(objectID);
            }
        }

        public static List<MapObject> GetObjectsInGroup(string p) {
            List<MapObject> retList = new List<MapObject>();

            if (GroupsToObjectUUIDS.ContainsKey(p)) {
                foreach (short id in GroupsToObjectUUIDS[p]) {
                    retList.Add(ObjectTypes[id]);
                }
            }

            return retList;
        }

        public static short NextID() {
            return nextObjectID;
        }
    }
}
