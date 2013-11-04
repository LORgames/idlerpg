using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ToolCache.General;
using System.IO;

namespace ToolCache.DataLibrary {
    public class DBLibraryManager {
        private const string DATABASE_FILENAME = Settings.Database + "DBLibraries.bin";

        private static List<DBLibrary> Libraries = new List<DBLibrary>();

        public static void Initialize() {
            Libraries.Clear();
        }

        private static void LoadDatabase() {
            if (File.Exists(DATABASE_FILENAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(DATABASE_FILENAME));

                short totalEffects = f.GetShort();

                while (--totalEffects > -1) {
                    string name = f.GetString();
                    DBLibrary x = AddLibrary(name);

                    x.ReadFromBinaryIO(f);
                }
            }
        }

        public static void WriteDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)Libraries.Count);

            for (int i = 0; i < Libraries.Count; i++) {

            }

            f.Encode(DATABASE_FILENAME);
        }

        public static DBLibrary AddLibrary(string name) {
            DBLibrary dbl = new DBLibrary(name);

            Libraries.Add(dbl);

            return dbl;
        }
    }
}
