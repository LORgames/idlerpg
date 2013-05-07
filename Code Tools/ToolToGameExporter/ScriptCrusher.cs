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

            for(int i = 0; i < commands.Length; i++) {
                string command = commands[i];

                if (command.Length < 2) continue;
                command = command.Trim();

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
                        Error("Cannot find sound effect: '" + paras + "'", scriptname);
                    }
                } else if(action == "equip") {
                    if (EquipmentManager.Equipment.ContainsKey(paras)) {
                        f.AddUnsignedShort(2);
                        f.AddByte((byte)Array.IndexOf(EquipmentCrusher.equipmenttypes, EquipmentManager.Equipment[paras].Type));
                        f.AddShort(EquipmentCrusher.MappedEquipmentIDs[paras]);
                    } else {
                        f.AddUnsignedShort(0);
                        Error("Cannot find equipment item: '" + paras + "'", scriptname);
                    }
                } else {
                    Error("Unknown command: " + command, scriptname);
                    f.AddUnsignedShort(0);
                }
            }

            f.AddUnsignedShort(0xFFFF);
        }

        private static void Error(string message, string scriptname) {
            Processor.Errors.Add("Script:" + scriptname + " " + message);
        }

    }
}
