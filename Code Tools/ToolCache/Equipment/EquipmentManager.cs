﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;

namespace ToolCache.Equipment {
    public enum Direction { Left, Right, Up, Down };
    public enum EquipmentTypes { Body, Legs, Weapon, Face, Hat };
    public enum States { Default, Walking, Attacking, Dancing };

    public class EquipmentManager {
        public static Dictionary<string, EquipmentItem> Equipment = new Dictionary<string, EquipmentItem>();
        internal static Dictionary<EquipmentTypes, List<EquipmentItem>> TypeLists = new Dictionary<EquipmentTypes, List<EquipmentItem>>();

        public static void Initialize() {
            Equipment.Clear();

            TypeLists.Clear();
            foreach (EquipmentTypes s in Enum.GetValues(typeof(EquipmentTypes))) {
                TypeLists.Add(s, new List<EquipmentItem>());
            }

            LoadFromDatabase();
        }

        private static void LoadFromDatabase() {
            if (File.Exists("cache/db_equipment.bin")) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes("cache/db_equipment.bin"));

                int totalItems = f.GetInt();

                for (int i = 0; i < totalItems; i++) {
                    EquipmentItem ei = EquipmentItem.UnpackFromBinaryIO(f);

                    if (!Equipment.ContainsKey(ei.Name)) { //Just throw it out if it already exists.
                        Equipment.Add(ei.Name, ei);
                    }
                }
            }
        }

        internal static void SaveDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddInt(Equipment.Count);

            foreach (EquipmentItem ei in Equipment.Values) {
                ei.PackIntoBinaryIO(f);
            }
        }

        internal static void AddEquipment(EquipmentItem currentEquipment) {
            string baseName = currentEquipment.Name;
            int nextTry = 1;
            
            while (Equipment.ContainsKey(currentEquipment.Name)) {
                currentEquipment.Name = baseName + "_" + nextTry;
                nextTry++;
            }

            Equipment.Add(currentEquipment.Name, currentEquipment);

            TypeLists[currentEquipment.Type].Add(currentEquipment);
            currentEquipment.OldType = currentEquipment.Type;
        }

        internal static void Updated(EquipmentItem currentEquipment) {
            if (currentEquipment.OldType != currentEquipment.Type && TypeLists[currentEquipment.OldType].Contains(currentEquipment)) {
                TypeLists[currentEquipment.OldType].Remove(currentEquipment);
                currentEquipment.OldType = currentEquipment.Type;

                if (!TypeLists[currentEquipment.Type].Contains(currentEquipment)) {
                    TypeLists[currentEquipment.Type].Add(currentEquipment);
                }
            }
        }
    }
}
