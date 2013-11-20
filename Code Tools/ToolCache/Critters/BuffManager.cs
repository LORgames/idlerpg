using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.ComponentModel;
using System.IO;
using ToolCache.UI;
using ToolCache.Storage;

namespace ToolCache.Critters {
    public class BuffManager {
        private const string RESOLVED_DATABASE_FILENAME = "Buffs";

        public static BindingList<Buff> Buffs = new BindingList<Buff>();

        public static void Initialize() {
            Buffs.Clear();
            LoadDatabase();

            if (UIManager.GetLibrary("Buff Icons") == null) {
                UIManager.AddLibrary(new UILibrary("Buff Icons"));
            }
        }

        private static void LoadDatabase() {
            IStorage f = StorageHelper.LoadStorage(RESOLVED_DATABASE_FILENAME, StorageTypes.UTF);

            if (f != null) {
                short totalBuffs = f.GetShort();

                while (--totalBuffs > -1) {
                    Buffs.Add(Buff.ReadFromBinaryIO(f));
                }

                f.Dispose();
            }
        }

        public static void SaveDatabase() {
            IStorage f = StorageHelper.WriteStorage(StorageTypes.UTF);

            f.AddShort((short)Buffs.Count);

            foreach (Buff b in Buffs) {
                b.WriteToBinaryIO(f);
            }

            StorageHelper.Save(f, RESOLVED_DATABASE_FILENAME);

            f.Dispose();
        }

        internal static bool HasBuff(string p) {
            string lookup = p.ToLower();

            for (int i = 0; i < Buffs.Count; i++) {
                if (Buffs[i].Name.ToLower() == lookup) return true;
            }

            return false;
        }
    }

    public class Buff {
        public string Name = "Unnamed";

        public short IconID = 0;
        public float Duration = 0;
        public bool isDebuff = false;
        public bool showsIcon = false;

        public string Script = "";

        public Buff() {
            Name = "Unnamed";
        }

        public static Buff ReadFromBinaryIO(IStorage f) {
            Buff b = new Buff();

            b.Name = f.GetString();
            b.IconID = f.GetShort();

            b.Duration = f.GetFloat();

            byte s = f.GetByte();

            b.isDebuff = ((s&1) == 1);
            b.showsIcon = ((s & 2) == 2);

            b.Script = f.GetString();

            return b;
        }

        public void WriteToBinaryIO(IStorage f) {
            f.AddString(Name);
            f.AddShort(IconID);

            f.AddFloat(Duration);
            f.AddByte((byte)((isDebuff ? 1 : 0)+(showsIcon? 2 : 0)));
            f.AddString(Script);
        }

        public override string ToString() {
            return Name;
        }

        public Buff Clone() {
            Buff b = new Buff();

            b.Name = Name + " Clone";
            b.IconID = IconID;

            b.Duration = Duration;
            b.isDebuff = isDebuff;
            b.Script = Script+"";

            return b;
        }
    }
}
