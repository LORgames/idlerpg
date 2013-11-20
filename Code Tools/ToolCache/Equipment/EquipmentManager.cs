using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;
using ToolCache.Storage;

namespace ToolCache.Equipment {
    public enum Direction { Left, Right, Up, Down };
    public enum EquipmentTypes { Body, Legs, Weapon, Head, Headgear, Shadow };

    public class EquipmentManager {
        private const string DATABASE_FILENAME = "Equipment";

        public static Dictionary<string, EquipmentItem> Equipment = new Dictionary<string, EquipmentItem>();
        public static Dictionary<EquipmentTypes, List<EquipmentItem>> TypeLists = new Dictionary<EquipmentTypes, List<EquipmentItem>>();

        public static void Initialize() {
            Equipment.Clear();

            TypeLists.Clear();
            foreach (EquipmentTypes s in Enum.GetValues(typeof(EquipmentTypes))) {
                TypeLists.Add(s, new List<EquipmentItem>());
            }

            LoadFromDatabase();
        }

        private static void LoadFromDatabase() {
            IStorage f = StorageHelper.LoadStorage(DATABASE_FILENAME, StorageTypes.UTF);

            if (f != null) {
                int totalItems = f.GetInt();

                for (int i = 0; i < totalItems; i++) {
                    EquipmentItem ei = EquipmentItem.UnpackFromBinaryIO(f);
                    AddEquipment(ei);
                }

                f.Dispose();
            }
        }

        public static void SaveDatabase() {
            IStorage f = StorageHelper.WriteStorage(StorageTypes.UTF);

            f.AddInt(Equipment.Count);

            foreach (EquipmentItem ei in Equipment.Values) {
                ei.PackIntoBinaryIO(f);
            }

            StorageHelper.Save(f, DATABASE_FILENAME);

            f.Dispose();
        }

        public static void AddEquipment(EquipmentItem currentEquipment) {
            string baseName = currentEquipment.Name;
            int nextTry = 1;
            
            while (Equipment.ContainsKey(currentEquipment.Name)) {
                currentEquipment.Name = baseName + "_" + nextTry;
                nextTry++;
            }

            currentEquipment.OldName = currentEquipment.Name;
            Equipment.Add(currentEquipment.Name, currentEquipment);

            TypeLists[currentEquipment.Type].Add(currentEquipment);
            currentEquipment.OldType = currentEquipment.Type;
        }

        public static void Updated(EquipmentItem currentEquipment) {
            if (currentEquipment.OldType != currentEquipment.Type && TypeLists[currentEquipment.OldType].Contains(currentEquipment)) {
                TypeLists[currentEquipment.OldType].Remove(currentEquipment);
                currentEquipment.OldType = currentEquipment.Type;

                if (!TypeLists[currentEquipment.Type].Contains(currentEquipment)) {
                    TypeLists[currentEquipment.Type].Add(currentEquipment);
                }
            }

            if (currentEquipment.Name != currentEquipment.OldName) {
                if (Equipment.ContainsKey(currentEquipment.Name)) {
                    currentEquipment.Name = currentEquipment.OldName;
                } else {
                    Equipment.Remove(currentEquipment.OldName);
                    Equipment.Add(currentEquipment.Name, currentEquipment);
                    currentEquipment.OldName = currentEquipment.Name;
                }
            }
        }

        public static EquipmentItem Get(string equipmentName) {
            if (Equipment.ContainsKey(equipmentName)) {
                return Equipment[equipmentName];
            }

            return null;
        }
    }
}
