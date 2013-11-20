using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;
using System.Drawing;
using ToolCache.Storage;

namespace ToolCache.NPC {
    public class PortraitManager {
        private const string DATABASE_FILENAME = "Portraits";

        public static DictionaryEx<string, Portrait> Portraits = new DictionaryEx<string, Portrait>();

        public static decimal MarginLeft = 0;
        public static decimal MarginRight = 0;
        public static decimal MarginBottom = 0;
        public static decimal Height = 200;
        
        public static Color BackgroundColour = Color.Blue;
        public static decimal Transparency = 50;

        internal static void Initialize() {
            Portraits.Clear();
            LoadFromBinaryIO();
        }

        private static void LoadFromBinaryIO() {
            IStorage f = StorageHelper.LoadStorage(DATABASE_FILENAME, StorageTypes.UTF);

            if (f != null) {
                MarginLeft = f.GetShort();
                MarginRight = f.GetByte();
                MarginBottom = f.GetByte();
                Height = f.GetByte();
                BackgroundColour = Color.FromArgb(f.GetByte(), f.GetByte(), f.GetByte());
                Transparency = f.GetByte();

                short totalPortraits = f.GetShort();

                while (--totalPortraits > -1) {
                    Portrait p = Portrait.LoadFromBinaryIO(f);
                    Portraits.Add(p.Name, p);
                }

                f.Dispose();
            }
        }

        public static void SaveToBinaryIO() {
            IStorage f = StorageHelper.WriteStorage(StorageTypes.UTF);

            f.AddShort((short)MarginLeft);
            f.AddByte((byte)MarginRight);
            f.AddByte((byte)MarginBottom);
            f.AddByte((byte)Height);
            f.AddByte(BackgroundColour.R);
            f.AddByte(BackgroundColour.G);
            f.AddByte(BackgroundColour.B);
            f.AddByte((byte)Transparency);

            f.AddShort((short)Portraits.Count);

            foreach (Portrait p in Portraits.Values) {
                p.SaveToBinaryIO(f);
            }

            StorageHelper.Save(f, DATABASE_FILENAME);

            f.Dispose();
        }
    }
}
