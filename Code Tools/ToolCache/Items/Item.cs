using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Items {
    public class Item {
        public short ID = (short)-1;
        public string Name = "Unknown";
        public string IconName = "";

        public string Category = "Unknown";
        internal string OldCategory = "Unknown";

        public string Description = "";

        public short MaxInStack = 1000;

        public byte Rarity = 0;
        public int Value = 0;
        public int SellPrice = 0;
        public int BuyPrice = 0;

        public short EffectID = 0;
        public short EffectValue = 0;

        public bool isQuestItem = false;

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddShort(ID);
            f.AddString(Category);
            f.AddString(Name);
            f.AddString(IconName);
            f.AddString(Description);

            f.AddShort(MaxInStack);
            f.AddByte(Rarity);

            f.AddInt(Value);
            f.AddInt(SellPrice);
            f.AddInt(BuyPrice);

            f.AddShort(EffectID);
            f.AddShort(EffectValue);

            f.AddByte((byte)(isQuestItem ? 1 : 0));
        }

        internal static Item LoadFromBinaryIO(BinaryIO f) {
            Item t = new Item();

            t.ID = f.GetShort();
            t.Category = f.GetString();
            t.Name = f.GetString();
            t.IconName = f.GetString();
            t.Description = f.GetString();

            t.MaxInStack = f.GetShort();
            t.Rarity = f.GetByte();

            t.Value = f.GetInt();
            t.SellPrice = f.GetInt();
            t.BuyPrice = f.GetInt();

            t.EffectID = f.GetShort();
            t.EffectValue = f.GetShort();

            t.isQuestItem = (f.GetByte() == 1);

            return t;
        }
    }
}
