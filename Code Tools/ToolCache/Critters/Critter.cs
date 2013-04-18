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

        public byte Size = (byte)1;

        public int ExperienceGain = 0;
        public int Health = 0;
        public bool OneOfAKind = false;

        public List<LootDrop> Loot = new List<LootDrop>();

        public List<String> Groups = new List<string>();
        public List<String> Types = new List<string>();

        internal virtual void PackIntoBinaryIO(BinaryIO f) {
            
        }

        public virtual void Draw(LBuffer buffer) {

        }

        ///////////////////////Statics
        internal static Critter Load(BinaryIO f) {
            Critter c = new Critter();

            c.ID = f.GetShort();
            c.Name = f.GetString();

            c.AIType = f.GetInt();
            c.Size = f.GetByte();

            c.ExperienceGain = f.GetInt();
            c.Health = f.GetInt();
            c.OneOfAKind = f.GetByte()==1;

            short Total = f.GetShort();
            while (--Total > -1) {
                c.Loot.Add(LootDrop.Unpack(f));
            }

            Total = f.GetShort();
            while (--Total > -1) {
                c.Groups.Add(f.GetString());
            }

            Total = f.GetShort();
            while (--Total > -1) {
                c.Types.Add(f.GetString());
            }

            return c;
        }
    }
}
