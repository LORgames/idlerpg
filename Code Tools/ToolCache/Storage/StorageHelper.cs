using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;

namespace ToolCache.Storage {
    public enum StorageTypes {
        Unknown,
        Binary,
        UTF
    }
    
    public class StorageHelper {

        public static IStorage LoadStorage(string filename, StorageTypes preference) {
            bool binaryStorage = File.Exists(Settings.Database + filename + ".bin");
            bool asciiStorage = File.Exists(Settings.Database + filename + ".utf");

            StorageTypes returnType = StorageTypes.Unknown;

            if (preference == StorageTypes.UTF && asciiStorage) {
                returnType = StorageTypes.UTF;
            } else if (preference == StorageTypes.Binary && binaryStorage) {
                returnType = StorageTypes.Binary;
            } else if (binaryStorage && asciiStorage) {
                DateTime dtb = File.GetLastWriteTime(Settings.Database + filename + ".bin");
                DateTime dtu = File.GetLastWriteTime(Settings.Database + filename + ".utf");

                if (dtb > dtu) {
                    returnType = StorageTypes.Binary;
                } else {
                    returnType = StorageTypes.UTF;
                }
            } else if (binaryStorage) {
                returnType = StorageTypes.Binary;
            } else if (asciiStorage) {
                returnType = StorageTypes.UTF;
            }

            System.Diagnostics.Debug.WriteLine("STORAGE {0} HasBinary={1} HasASCII={2} Prefered={3} Returned={4}", filename, binaryStorage, asciiStorage, preference, returnType);

            if (returnType == StorageTypes.Binary) {
                return new BinaryIO(File.ReadAllBytes(Settings.Database + filename + ".bin"));
            } else if (returnType == StorageTypes.UTF) {
                return new UTFIO(File.ReadAllText(Settings.Database + filename + ".utf"));
            }

            return null;
        }

        public static IStorage WriteStorage(StorageTypes preference) {
            if (preference == StorageTypes.Binary) {
                return new BinaryIO();
            } else if (preference == StorageTypes.UTF) {
                return new UTFIO();
            }

            System.Windows.Forms.MessageBox.Show("Not supposed to give you a write storage if you don't tell me what you want.");
            return null;
        }


        internal static void Save(IStorage f, string filename) {
            if (f is BinaryIO) {
                f.Encode(Settings.Database + filename + ".bin");
                return;
            } else if (f is UTFIO) {
                f.Encode(Settings.Database + filename + ".utf");
                return;
            }

            System.Windows.Forms.MessageBox.Show("Sorry, cannot figure out how to encode that format for " + filename);
        }
    }
}
