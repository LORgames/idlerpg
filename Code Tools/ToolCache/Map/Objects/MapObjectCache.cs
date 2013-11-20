using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;
using ToolCache.Animation;
using System.Drawing;
using ToolCache.Storage;

namespace ToolCache.Map.Objects {
    public class MapObjectCache {
        private const string DATABASE_FILENAME = "Objects";

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

        public static bool HasObjectByName(string name) {
            foreach (MapObject obj in ObjectTypes.Values) {
                if (obj.ObjectName == name) {
                    return true;
                }
            }

            return false;
        }

        private static void ReadDatabase() {
            // Load object types from file
            IStorage f = StorageHelper.LoadStorage(DATABASE_FILENAME, StorageTypes.UTF);

            if (f != null) {
                int totalObjects = f.GetInt();

                //This is where we load the BASIC information
                for (int i = 0; i < totalObjects; i++) {
                    MapObject m = MapObject.LoadFromBinaryIO(f);
                    AddObject(m);
                }

                f.Dispose();
            }
        }

        public static void WriteDatabase() {
            IStorage f = StorageHelper.WriteStorage(StorageTypes.UTF);

            f.AddInt(ObjectTypes.Count);

            foreach (KeyValuePair<short, MapObject> kvp in ObjectTypes) {
                kvp.Value.WriteToBinaryIO(f);
            }

            StorageHelper.Save(f, DATABASE_FILENAME);

            f.Dispose();
        }

        public static void AddObject(MapObject m) {
            if (ObjectTypes.ContainsKey(m.ObjectID)) {
                GroupsToObjectUUIDS[ObjectTypes[m.ObjectID].ObjectGroup].Remove(m.ObjectID);

                if (GroupsToObjectUUIDS[ObjectTypes[m.ObjectID].ObjectGroup].Count == 0) {
                    GroupsToObjectUUIDS.Remove(ObjectTypes[m.ObjectID].ObjectGroup);
                }
            }

            ObjectTypes.Add(m.ObjectID, m);

            if (!GroupsToObjectUUIDS.ContainsKey(m.ObjectGroup)) {
                GroupsToObjectUUIDS.Add(m.ObjectGroup, new List<short>());
            }

            GroupsToObjectUUIDS[m.ObjectGroup].Add(m.ObjectID);

            if (m.ObjectID >= nextObjectID) {
                nextObjectID = m.ObjectID;
                nextObjectID++;
            }
        }

        public static List<string> GetGroups() {
            return GroupsToObjectUUIDS.Keys.ToList<String>();
        }

        public static void Delete(MapObject mapObject) {
            if (ObjectTypes.ContainsKey(mapObject.ObjectID)) {
                if (GroupsToObjectUUIDS.ContainsKey(ObjectTypes[mapObject.ObjectID].ObjectGroup)) {
                    GroupsToObjectUUIDS[ObjectTypes[mapObject.ObjectID].ObjectGroup].Remove(mapObject.ObjectID);

                    if (GroupsToObjectUUIDS[ObjectTypes[mapObject.ObjectID].ObjectGroup].Count == 0) {
                        GroupsToObjectUUIDS.Remove(ObjectTypes[mapObject.ObjectID].ObjectGroup);
                    }
                }

                ObjectTypes.Remove(mapObject.ObjectID);
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
