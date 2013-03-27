using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;
using ToolCache.Animation;
using System.Drawing;

namespace ToolCache.Map.Objects {
    public class ObjectCache {
        public const string RESOLVED_DATABASE_FILENAME = Settings.CACHE + "db_objects.bin";

        public static Dictionary<short, ObjectTemplate> ObjectTypes = new Dictionary<short, ObjectTemplate>();
        private static Dictionary<string, List<short>> GroupsToObjectUUIDS = new Dictionary<string, List<short>>();

        private static short nextObjectID = 0;

        public static void Initialize() {
            ObjectTypes.Clear();
            GroupsToObjectUUIDS.Clear();

            nextObjectID = 0;

            ReadDatabase();
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

                    string ObjectGroup = f.GetString();

                    int BaseLeft = f.GetInt();
                    int BaseTop = f.GetInt();
                    int BaseWidth = f.GetInt();
                    int BaseHeight = f.GetInt();

                    Rectangle _base = new Rectangle(BaseLeft, BaseTop, BaseWidth, BaseHeight);

                    ObjectTypes.Add(ObjectID, new ObjectTemplate(ObjectID, ObjectGroup, animation, _base));
                }
            }
        }

        internal static void WriteDatabase() {
            BinaryIO f = new BinaryIO();
            f.AddInt(ObjectTypes.Count);

            foreach (KeyValuePair<short, ObjectTemplate> kvp in ObjectTypes) {
                f.AddShort(kvp.Key);
                kvp.Value.Animation.PackIntoBinaryIO(f);

                f.AddInt(kvp.Value.Base.Left);
                f.AddInt(kvp.Value.Base.Top);
                f.AddInt(kvp.Value.Base.Width);
                f.AddInt(kvp.Value.Base.Height);
            }

            f.Encode(RESOLVED_DATABASE_FILENAME);
        }

        internal static void AddObject(ObjectTemplate t) {
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

        internal static void Delete(short objectID) {
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

        public static List<ObjectTemplate> GetObjectsInGroup(string p) {
            List<ObjectTemplate> retList = new List<ObjectTemplate>();

            if (GroupsToObjectUUIDS.ContainsKey(p)) {
                foreach (short id in GroupsToObjectUUIDS[p]) {
                    retList.Add(ObjectTypes[id]);
                }
            }

            return retList;
        }
    }
}
