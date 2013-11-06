using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.DataLibrary;
using ToolCache.General;
using ToolCache.Scripting.Types;

namespace ToolToGameExporter {
    public class DatabaseCrusher {
        public static Dictionary<String, short> DatabaseIDs = new Dictionary<string, short>();
        
        public static void Precrush() {
            DatabaseIDs.Clear();

            short i = 0;
            DBLibrary[] libs = DBLibraryManager.GetLibraries();

            for (i = 0; i < libs.Length; i++) {
                DatabaseIDs.Add(libs[i].Name, i);
                i++;
            }
        }

        public static void Go() {
            short i = 0;
            DBLibrary[] libs = DBLibraryManager.GetLibraries();

            BinaryIO f = new BinaryIO();

            f.AddShort((short)libs.Length);

            for (i = 0; i < libs.Length; i++) {
                //Pack column types into the binary
                string[] columns = libs[i].GetColumnNames();
                f.AddShort((short)columns.Length);
                f.AddShort((short)libs[i].Rows.Count);

                for (int j = 0; j < columns.Length; j++) {
                    byte _tid = 0; //Integer
                    Param _pid = libs[i].GetColumnType(j);

                    if(_pid == Param.String) {
                        _tid = 1; //String
                    } else if(_pid == Param.Number) {
                        _tid = 2; //Float
                    }

                    f.AddByte(_tid);

                    //Start packing the data
                    for (int k = 0; k < libs[i].Rows.Count; k++) {
                        DBRow row = libs[i].Rows[k];
                        row.Cells[j].PackIntoOptimized(f);
                    }
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/Databases.bin");
        }
    }
}
