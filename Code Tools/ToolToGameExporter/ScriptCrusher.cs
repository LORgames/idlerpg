﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Equipment;
using ToolCache.Scripting;
using ToolCache.Scripting.Types;
using ToolCache.Storage;

namespace ToolToGameExporter {
    /// <summary>
    /// Responsible for compiling scripts.
    /// </summary>
    internal class ScriptCrusher {

        /// <summary>
        /// Compiles a script into bytecode.
        /// </summary>
        /// <param name="info">The script object</param>
        /// <param name="script">The raw human readable script</param>
        /// <param name="f">The binaryIO object to inject the bytecode into</param>
        internal static void ProcessScript(ScriptInfo info, string script, BinaryIO f) {
            ///////////////////////////////////////////////////////////////////////////////////
            /////// PRECOMPILER
            ///////////////////////////////////////////////////////////////////////////////////
            
            Parser.Parse(script, info);

            if (info.Errors.Count > 0) {
                f.AddUnsignedShort(0xFFFF);
                ErrorAddAll(info);
                return;
            }

            ///////////////////////////////////////////////////////////////////////////////////
            /////// VARIABLES
            ///////////////////////////////////////////////////////////////////////////////////

            if (info.ScriptType != ScriptTypes.Function) {
                //INTEGER VARIABLE
                List<ScriptVariable> iVars = info.IntegerVariables.Values.ToList();
                iVars.Sort((x, y) => x.Index.CompareTo(y.Index));

                int variableID = iVars.Count;
                f.AddShort((short)variableID);

                while (--variableID > -1) {
                    f.AddShort(iVars[variableID].InitialValue);
                }

                //FLOATING POINT VARIABLES
                List<FloatVariable> fVars = info.FloatingVariables.Values.ToList();
                fVars.Sort((x, y) => x.Index.CompareTo(y.Index));

                variableID = fVars.Count;
                f.AddShort((short)variableID);

                while (--variableID > -1) {
                    f.AddFloat(fVars[variableID].InitialValue);
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////
            /////// COMPILER
            ///////////////////////////////////////////////////////////////////////////////////

            int expectedIndentation = 0;

            for(int i = 0; i < info.Commands.Count; i++) {
                //Get the next command?
                ScriptCommand command = info.Commands[i];

                if (command.CommandID == 0xFFFF) continue;

                //Update the indentation
                expectedIndentation = UpdateIndentation(info, f, expectedIndentation, command);

                //Is this an event, lets process it as such
                if (command.Indent == 0 && info.ScriptType != ScriptTypes.Function) {
                    f.AddUnsignedShort(command.CommandID);
                    f.AddUnsignedShort(0xF0FD); //Start Block
                    expectedIndentation++;
                } else {
                    f.AddUnsignedShort(command.CommandID);
                    ProcessAdditionalBytesForCommands(info, f, command);

                    //Update the expected indentation if we're adding foreach, if etc
                    if (command.CommandID >= 0x8000 && command.CommandID < 0x8004) {
                        expectedIndentation++;

                        //Start the code block
                        f.AddUnsignedShort(0xF0FD);
                    } else if (command.vc.WillIndent) {
                        expectedIndentation++;
                        f.AddUnsignedShort(0xF0FD);
                    }
                }
            }

            //End the file by closing all the open blocks of code
            while (expectedIndentation > 0) {
                f.AddUnsignedShort(0xF0FE); //End Block
                expectedIndentation--;
            }

            //Add the end of file marker
            f.AddUnsignedShort(0xFFFF);

            //Dump any errors to the processing error list
            ErrorAddAll(info);
        }

        /// <summary>
        /// Updates the currently expected indentation.
        /// </summary>
        /// <param name="info">The script object</param>
        /// <param name="f">The binary IO in case we need to close blocks of code</param>
        /// <param name="expectedIndentation">The current expected indentation</param>
        /// <param name="command">The current command we're running</param>
        /// <returns>The new expected indentation.</returns>
        private static int UpdateIndentation(ScriptInfo info, BinaryIO f, int expectedIndentation, ScriptCommand command) {
            if (command.Indent > expectedIndentation) {
                info.Errors.Add("Unexpected Indentation.");
            } else if (command.Indent < expectedIndentation) {
                while (expectedIndentation > command.Indent) {
                    f.AddUnsignedShort(0xF0FE); //End Block
                    expectedIndentation--;
                }
            }

            return expectedIndentation;
        }

        /// <summary>
        /// Adds any additional information that might be required for the command
        /// </summary>
        /// <param name="info">The script infomation object for the current script.</param>
        /// <param name="f">The binaryIO object to inject bytecode into</param>
        /// <param name="command">The current command to process additional information for</param>
        private static void ProcessAdditionalBytesForCommands(ScriptInfo info, BinaryIO f, ScriptCommand command) {
            foreach (ushort s in command.AdditionalBytecode) {
                f.AddUnsignedShort(s);
            }
        }

        /// <summary>
        /// Pumps the scripting errors into the exporter error system.
        /// </summary>
        /// <param name="info"></param>
        private static void ErrorAddAll(ScriptInfo info) {
            foreach (string error in info.Errors) {
                Processor.Errors.Add(new ProcessingError("Script", info.ScriptName, error));
            }
        }
    }
}
