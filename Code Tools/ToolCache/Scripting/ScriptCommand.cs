using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Equipment;
using ToolCache.Sound;
using ToolCache.Critters;

namespace ToolCache.Scripting {
    public class ScriptCommand {
        public string Trimmed = "";
        public string Default = "";

        public byte Indent = 0;
        public byte ExpectedIndent = 0;

        public ushort CommandID = 0xFFFF;

        public string Action = "";
        public string Parameters = "";
        
        public ScriptCommand(string line, ScriptInfo info) {
            string trimmedStart = line.TrimStart('\t');
            Indent = (byte)(line.Length - trimmedStart.Length);

            Default = line;
            Trimmed = line.Trim();

            if (Trimmed.Length > 2) {
                if (Trimmed.Substring(0, 2) != "//") { //Make sure its not a comment
                    if (Indent == 0) {
                        //Process this as an Event
                        ProcessEvent(info);
                    } else {
                        //Process this as an action
                        ProcessAction(info);
                    }
                }
            }
        }

        public void ProcessEvent(ScriptInfo info) {
            if (!ValidEventList.ValidEvents.Contains(Trimmed)) {
                info.Errors.Add("Invalid event: " + Trimmed);
            } else {
                CommandID = (ushort)Array.IndexOf(ValidEventList.ValidEvents, Trimmed);
                info.EventFlags |= (0x1 << CommandID);
                info.EventCount++;
            }
        }

        public void ProcessAction(ScriptInfo info) {
            //Figure out what this command does...
            if (Trimmed.IndexOf(' ') > -1) {
                Action = Trimmed.Substring(0, Trimmed.IndexOf(' ')).ToLowerInvariant();
                Parameters = Trimmed.Substring(Trimmed.IndexOf(' ') + 1);
            } else {
                Action = Trimmed.ToLowerInvariant();
                Parameters = "";
            }

            
            switch (Action) {
                case "playsound":
                    CommandID = 0x1001;

                    if (!SoundDatabase.HasEffect(Parameters)) {
                        info.Errors.Add("Cannot find sound effect: '" + Parameters + "'");
                    } break;
                case "spawn":
                    CommandID = 0x1002;

                    if (!CritterManager.HasCritter(Parameters)) {
                        info.Errors.Add("Cannot find Critter: " + Parameters);
                    } break;
                case "equip":
                    CommandID = 0x4001;

                    if (!EquipmentManager.Equipment.ContainsKey(Parameters)) {
                        info.Errors.Add("Cannot find equipment item: '" + Parameters + "'");
                    } break;
                case "playanimation":
                    CommandID = 0x6000;

                    if (!info.AnimationNames.Contains(Parameters)) {
                        info.Errors.Add("Cannot find animation: " + Parameters);
                    } break;
                case "loopanimation":
                    CommandID = 0x6001;

                    if (!info.AnimationNames.Contains(Parameters)) {
                        info.Errors.Add("Cannot find animation: " + Parameters);
                    } break;
                case "else":
                    Parameters = ""; break;
                case "if":
                    break;
                default:
                    if (Parameters != "") {
                        info.Errors.Add("Unknown command: " + Action + " & " + Parameters);
                    } else {
                        info.Errors.Add("Unknown command: " + Action);
                    }

                    break;
            }
        }

        internal void Parse(ScriptInfo Info) {
            int index = Info.Commands.IndexOf(this);

            if (Indent != ExpectedIndent) {
                Info.Errors.Add("Unexpected Indent! " + Trimmed);
            }

            if (Action != "") {
                switch (Action) {
                    case "if":
                        int i2 = index+1;
                        while (Info.Commands.Count > i2 && Info.Commands[i2].Indent > Indent) {
                            Info.Commands[i2].ExpectedIndent = (byte)(Indent + 1);
                            i2++;
                        }
                        if (Info.Commands.Count > i2 && Info.Commands[i2].Action == "else") {
                            CommandID = 0x8001;
                            Info.Commands[i2].Parameters = "PAIRED";
                        } else {
                            CommandID = 0x8000;
                        } break;
                    case "else":
                        if (Parameters != "") Info.Errors.Add("Unpaired else!"); break;
                }
            } else if (Indent == 0) {
                int i2 = index + 1;
                while (Info.Commands.Count > i2 && Info.Commands[i2].Indent > 0) {
                    Info.Commands[i2].ExpectedIndent = (byte)1;
                    i2++;
                }
            }
        }
    }
}