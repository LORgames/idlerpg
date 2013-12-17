using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ToolCache.Scripting.Extensions;

namespace ToolCache.General {
    public class StringMagic {
        public static string PrepareString(string Message, bool rawID = false) {
            Regex regex = new Regex("{((~|!|@)?[A-Za-z0-9_>]+):?([0-9]+)?}");
            MatchCollection mc = regex.Matches(Message);

            if (mc.Count > 0) {
                string builder = "";
                int i = 0;
                int last_end = 0;

                for(i = 0; i < mc.Count; i++) {
                    builder = builder + Message.Substring(last_end, mc[i].Index-last_end);

                    int paddingLength = 0;
                    if (mc[i].Groups[3].Success) {
                        int.TryParse(mc[i].Groups[3].Value, out paddingLength);
                    }

                    if (!mc[i].Groups[2].Success) { //hopefully a variable?
                        if (Variables.GlobalVariables.ContainsKey(mc[i].Groups[1].Value)) {
                            if (!rawID) {
                                builder = builder + Variables.GlobalVariables[mc[i].Groups[1].Value].InitialValue.ToString().PadLeft(paddingLength, '0');
                            } else {
                                builder = builder + "{" + Variables.GlobalVariables[mc[i].Groups[1].Value].Index + (paddingLength != 0 ? (":" + paddingLength) : "") + "}";
                            }
                        } else {
                            builder = builder + "<UNKNOWN VAR>";
                        }
                    } else { //Some type of other input
                        if (mc[i].Groups[2].Value == "~") { //Database entry
                            try {
                                if (!rawID) {
                                    builder = builder + LinkDatabase(mc[i].Groups[1].Value.Substring(1), rawID).PadLeft(paddingLength, '0');
                                } else {
                                    builder = builder + "{" + LinkDatabase(mc[i].Groups[1].Value.Substring(1), rawID) + (paddingLength!=0?(":" + paddingLength):"") + "}";
                                }
                            } catch (Exception e) {
                                if (rawID) {
                                    throw e;
                                } else {
                                    builder = builder + e.Message;
                                }
                            }
                        } else if (mc[i].Groups[2].Value == "@") { //String table entry
                            if (Variables.StringTable.ContainsKey(mc[i].Groups[1].Value.Substring(1))) {
                                if (!rawID) {
                                    builder = builder + PrepareString(Variables.StringTable[mc[i].Groups[1].Value.Substring(1)]);
                                } else {
                                    //TODO: Compress into strings :)
                                    if (ExportCrushers.MappedStringTable != null) {
                                        builder = builder + "{@" + ExportCrushers.MappedStringTable[mc[i].Groups[1].Value.Substring(1)] + "}";
                                    } else {
                                        throw new Exception("String Table is not mapped!");
                                    }
                                }
                            } else {
                                builder = builder + "<UNKNOWN STRING CONSTANT>";
                            }
                        } else if (mc[i].Groups[2].Value == "!") { //String Variable entry
                            if (Variables.StringVariables.ContainsKey(mc[i].Groups[1].Value.Substring(1))) {
                                if (!rawID) {
                                    builder = builder + PrepareString(Variables.StringVariables[mc[i].Groups[1].Value.Substring(1)].InitialValue);
                                } else {
                                    //TODO: Compress into strings :)
                                    builder = builder + "{!" + Variables.StringVariables[mc[i].Groups[1].Value.Substring(1)].Index + "}";
                                }
                            } else {
                                builder = builder + "<UNKNOWN STRING VARIABLE>";
                            }
                        }
                    }

                    last_end = mc[i].Index + mc[i].Length;
                }

                builder = builder + Message.Substring(last_end);

                return builder;
            }

            return Message;
        }

        private static string LinkDatabase(string databaseIdentifier, bool isRaw) {
            if (databaseIdentifier.Length < 5) {
                throw new Exception("A database identification should be at least 5 characters...");
            }

            string[] subParamBits = databaseIdentifier.Split('>');
            short colID;
            short rowID;

            bool useVar;

            string retString = "";

            if (subParamBits.Length == 3) {
                string database = subParamBits[0];
                string column = subParamBits[1];
                string row = subParamBits[2];

                DataLibrary.DBLibrary lib = DataLibrary.DBLibraryManager.GetLibrary(database);

                if (lib == null) {
                    throw new Exception("Cannot find a database named '" + database + "'");
                }

                if (isRaw && ExportCrushers.MappedDatabaseNames != null) {
                    if (ExportCrushers.MappedDatabaseNames.ContainsKey(database)) {
                        retString += ExportCrushers.MappedDatabaseNames[database] + ":";
                    } else {
                        throw new Exception("The database was not compiled for exporting. Perhaps it is empty?");
                    }
                }

                colID = 0;
                useVar = false;

                //Now find the column
                if (!short.TryParse(column, out colID)) {
                    if (!Variables.GlobalVariables.ContainsKey(column)) {
                        colID = (short)lib.GetColumnID(column);
                        if (colID == -1) {
                            throw new Exception("Cannot find a column called '" + column + "'");
                        }
                    } else {
                        useVar = true;
                        if (isRaw) {
                            colID = (short)Variables.GlobalVariables[column].Index;
                        } else {
                            colID = (short)Variables.GlobalVariables[column].InitialValue;
                        }
                    }
                }

                if (!useVar && lib.Column_Names.Count <= colID) {
                    throw new Exception("Database '" + database + "' does not have " + colID + " columns!");
                } else {
                    retString += (useVar ? "b" : "a") + colID + ":";
                }

                //Now find the row
                rowID = 0;
                useVar = false;

                if (!short.TryParse(row, out rowID)) {
                    if (!Variables.GlobalVariables.ContainsKey(row)) {
                        throw new Exception("Sorry, we don't (yet?) support named rows!");
                    } else {
                        useVar = true;
                        if (isRaw) {
                            rowID = (short)Variables.GlobalVariables[row].Index;
                        } else {
                            rowID = (short)Variables.GlobalVariables[row].InitialValue;
                        }
                    }
                }

                if (!useVar && lib.Rows.Count <= rowID) {
                    throw new Exception("Database '" + database + "' does not have " + rowID + " rows!");
                } else {
                    retString += (useVar ? "b" : "a") + rowID;
                }

                if (isRaw) {
                    return retString;
                } else {
                    return lib.Rows[rowID].Cells[colID].ToString();
                }
            } else {
                return "You need 3 parts for a database ID!";
            }
        }

    }
}
