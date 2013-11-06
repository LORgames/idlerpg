using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.DataLibrary;

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

        }
    }
}
