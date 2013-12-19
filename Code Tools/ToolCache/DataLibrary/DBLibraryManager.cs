using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ToolCache.General;
using System.IO;
using ToolCache.Storage;

namespace ToolCache.DataLibrary {
    public class DBLibraryManager {
        private const string DATABASE_FILENAME = "DBLibraries";

        private static List<DBLibrary> Libraries = new List<DBLibrary>();

        public static void Initialize() {
            Libraries.Clear();
            LoadDatabase();
        }

        private static void LoadDatabase() {
            IStorage f = StorageHelper.LoadStorage(DATABASE_FILENAME, StorageTypes.UTF);

            if (f != null) {
                short totalEffects = f.GetShort();

                while (--totalEffects > -1) {
                    string name = f.GetString();
                    DBLibrary x = AddLibrary(name);

                    x.ReadFromBinaryIO(f);
                }

                f.Dispose();
            }
        }

        public static void WriteDatabase() {
            IStorage f = StorageHelper.WriteStorage(StorageTypes.UTF);

            f.AddShort((short)Libraries.Count);

            for (int i = 0; i < Libraries.Count; i++) {
                f.AddString(Libraries[i].Name);
                Libraries[i].WriteToBinaryIO(f);
            }

            StorageHelper.Save(f, DATABASE_FILENAME);
        }

        public static DBLibrary AddLibrary(string name) {
            DBLibrary dbl = new DBLibrary(name);
            Libraries.Add(dbl);
            return dbl;
        }

        public static void DeleteLibrary(DBLibrary lib) {
            Libraries.Remove(lib);
        }

        public static DBLibrary[] GetLibraries() {
            return Libraries.ToArray();
        }

        internal static DBLibrary GetLibrary(string libraryName) {
            string comp = libraryName.ToLower();

            foreach(DBLibrary lib in Libraries) {
                if (lib.Name.ToLower() == comp) {
                    return lib;
                }
            }

            return null;
        }
    }
}
