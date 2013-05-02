using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Equipment;

namespace ToolToGameExporter {
    public class ScriptCrusher {

        internal static void ProcessScript(string scriptname, string s, BinaryIO f) {
            string[] commands = s.Split(';');

            foreach (string command in commands) {
                if (command.Length < 2) continue;

                string action = command.Substring(0, command.IndexOf(' '));
                string paras = command.Substring(command.IndexOf(' ')+1);

                if (action == "end") {
                    f.AddUnsignedShort(0);
                } else if (action == "playsound") {
                    if (SoundCrusher.EffectConversions.ContainsKey(paras)) {
                        f.AddUnsignedShort(1);
                        f.AddShort(SoundCrusher.EffectConversions[paras]);
                    } else {
                        f.AddUnsignedShort(0);
                        Processor.Errors.Add("Script:" + scriptname + " cannot find sound effect: '" + paras + "'");
                    }
                } else if(action == "equip") {
                    if (EquipmentManager.Equipment.ContainsKey(paras)) {
                        f.AddUnsignedShort(2);
                        f.AddByte((byte)Array.IndexOf(EquipmentCrusher.equipmenttypes, EquipmentManager.Equipment[paras].Type));
                        f.AddShort(EquipmentCrusher.MappedEquipmentIDs[paras]);
                    } else {
                        f.AddUnsignedShort(0);
                        Processor.Errors.Add("Script:" + scriptname + " cannot find equipment item: '" + paras + "'");
                    }
                } else {
                    Processor.Errors.Add("Script:" + scriptname + " unknown command: " + command);
                    f.AddUnsignedShort(0);
                }
            }

            f.AddUnsignedShort(0xFFFF);
        }

    }
}
