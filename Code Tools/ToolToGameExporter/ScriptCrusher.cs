﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Equipment;
using ToolCache.Scripting;

namespace ToolToGameExporter {
    public class ScriptCrusher {

        internal static void ProcessScript(ScriptInfo info, string script, BinaryIO f) {
            ///////////////////////////////////////////////////////////////////////////////////
            /////// PRECOMPILER
            ///////////////////////////////////////////////////////////////////////////////////

            List<ScriptCommand> Commands = Parser.CleanAndDivideScript(script, info);

            ///////////////////////////////////////////////////////////////////////////////////
            /////// COMPILER
            ///////////////////////////////////////////////////////////////////////////////////

            int expectedIndentation = 0;

            for(int i = 0; i < Commands.Count; i++) {
                //Get the next command?
                ScriptCommand command = Commands[i];

                if (command.Indent > expectedIndentation) {
                    info.Errors.Add("Unexpected Indentation.");
                } else if (command.Indent < expectedIndentation) {
                    while (expectedIndentation > command.Indent) {
                        f.AddUnsignedShort(0xF0FE);
                    }
                }

                //Is this an event, lets process it as such
                if (command.Indent == 0) {
                    f.AddUnsignedShort(command.CommandID);
                    f.AddUnsignedShort(0xF0FD);

                    expectedIndentation++;
                } else {
                    f.AddUnsignedShort(command.CommandID);

                    switch (command.CommandID) {
                        case 0x1001: //PlaySound
                            f.AddShort(SoundCrusher.EffectConversions[command.Parameters]); break;
                        case 0x4001: //PlaySound
                            f.AddShort((short)Array.IndexOf(EquipmentCrusher.equipmenttypes, EquipmentManager.Equipment[command.Parameters].Type));
                            f.AddShort(EquipmentCrusher.MappedEquipmentIDs[command.Parameters]); break;
                    }
                }
            }

            ErrorAddAll(info);
        }

        private static void ErrorAddAll(ScriptInfo info) {
            foreach (string error in info.Errors) {
                Processor.Errors.Add(new ProcessingError("Script", info.ScriptName, error));
            }
        }
    }
}
