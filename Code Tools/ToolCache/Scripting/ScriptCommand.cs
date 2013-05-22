using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Equipment;
using ToolCache.Sound;

namespace ToolCache.Scripting {
    public class ScriptCommand {
        public string Trimmed = "";
        public string Default = "";
        public byte Indent = 0;

        public ushort CommandID = 0xFFFF;
        public string Parameters = "";
        
        public ScriptCommand(string line, ScriptInfo info) {
            string trimmedStart = line.TrimStart('\t');
            Indent = (byte)(line.Length - trimmedStart.Length);

            Default = line;
            Trimmed = line.Trim();

            if (Trimmed.Length > 2) {
                if (Indent == 0) {
                    //Process this as an Event
                    ProcessEvent(info);
                } else {
                    //Process this as something else
                }
            }
        }

        public void ProcessEvent(ScriptInfo info) {
            if (!ValidEventList.ValidEvents.Contains(Trimmed)) {
                info.Errors.Add("Invalid event: " + Trimmed);
            } else {
                info.EventFlags |= (0x1 << Array.IndexOf(ValidEventList.ValidEvents, Trimmed));
                info.EventCount++;
            }
        }

        public void ProcessAction(ScriptInfo info) {
            //Figure out what this command does...
            string action;

            if (Trimmed.IndexOf(' ') > -1) {
                action = Trimmed.Substring(0, Trimmed.IndexOf(' ')).ToLowerInvariant();
                Parameters = Trimmed.Substring(Trimmed.IndexOf(' ') + 1);
            } else {
                action = Trimmed.ToLowerInvariant();
                Parameters = "";
            }

            switch (action) {
                case "playsound":
                    CommandID = 0x1001;

                    if (!SoundDatabase.HasEffect(Parameters)) {
                        info.Errors.Add("Cannot find sound effect: '" + Parameters + "'");
                    } break;
                case "equip":
                    CommandID = 0x4001;

                    if (!EquipmentManager.Equipment.ContainsKey(Parameters)) {
                        info.Errors.Add("Cannot find equipment item: '" + Parameters + "'");
                    } break;
                default:
                    if (Parameters != "") {
                        info.Errors.Add("Unknown command: " + action + " & " + Parameters);
                    } else {
                        info.Errors.Add("Unknown command: " + action);
                    }

                    break;
            }
        }
    }
}