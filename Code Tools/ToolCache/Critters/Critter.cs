using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Drawing;

namespace ToolCache.Critters {
    public enum CritterTypes { Humanoid, NonHumanoid }

    public class Critter {
        public CritterTypes CritterType;

        public short ID = 0;
        public string Name = "MONSTAR!";
        public int AIType = 0;

        public int ExperienceGain = 0;
        public int Health = 0;
        public bool OneOfAKind = false;

        public List<LootDrop> Loot = new List<LootDrop>();

        public List<String> Groups = new List<string>();
        public List<String> Types = new List<string>();

        internal virtual void PackIntoBinaryIO(BinaryIO f) {
            f.AddByte((byte)CritterType);

            f.AddShort(ID);
            f.AddString(Name);

            f.AddInt(AIType);

            f.AddInt(ExperienceGain);
            f.AddInt(Health);
            f.AddByte(OneOfAKind ? (byte)1 : (byte)0);

            f.AddShort((short)Loot.Count);
            foreach (LootDrop l in Loot) l.Pack(f);

            f.AddShort((short)Groups.Count);
            foreach (String s in Groups) f.AddString(s);

            f.AddShort((short)Types.Count);
            foreach (String s in Types) f.AddString(s);
        }

        public virtual void Draw(LBuffer buffer) { } //Does nothing by design

        ///////////////////////Statics
        internal void BaseLoad(BinaryIO f) {
            ID = f.GetShort();
            Name = f.GetString();

            AIType = f.GetInt();

            ExperienceGain = f.GetInt();
            Health = f.GetInt();
            OneOfAKind = f.GetByte()==1;

            short Total = f.GetShort();
            while (--Total > -1) {
                Loot.Add(LootDrop.Unpack(f));
            }

            Total = f.GetShort();
            while (--Total > -1) {
                Groups.Add(f.GetString());
            }

            Total = f.GetShort();
            while (--Total > -1) {
                Types.Add(f.GetString());
            }
        }
    }
}
