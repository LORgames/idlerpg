﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Critters;
using ToolCache.General;
using ToolCache.Scripting;

namespace ToolToGameExporter {
    public class CritterCrusher {
        public static Dictionary<short, short> RemappedCritterIDs = new Dictionary<short, short>();
        public static Dictionary<string, short> NameToRemappedIDs = new Dictionary<string, short>();

        public static void Precrush() {
            RemappedCritterIDs.Clear();
            NameToRemappedIDs.Clear();

            short nextID = 0;

            foreach (Critter c in CritterManager.Critters.Values) {
                RemappedCritterIDs.Add(c.ID, nextID);
                NameToRemappedIDs.Add(c.Name, nextID);
                nextID++;
            }
        }

        public static void Go() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)CritterManager.Critters.Count);

            foreach (Critter c in CritterManager.Critters.Values) {
                f.AddByte((byte)c.CritterType);
                f.AddString(c.Name);

                f.AddInt(c.AIType);

                f.AddInt(c.ExperienceGain);
                f.AddInt(c.Health);

                ScriptCrusher.ProcessScript(new ScriptInfo("Critter:AI:" + c.Name, ScriptTypes.Critter), c.AICommands, f);

                if (c.CritterType == CritterTypes.Humanoid) {
                    CritterHuman ch = (c as CritterHuman);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Shadow]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Legs]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Body]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Face]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Headgear]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Weapon]);
                } else {
                    
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/CritterInfo.bin");
        }
    }
}
