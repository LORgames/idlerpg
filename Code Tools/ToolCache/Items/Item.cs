using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Items {
    public class Item {
        short ID;
        string Category;
        string Name;
        short IconID;

        short MaxInStack;
        
        byte Rarity;
        int Value;
        int SellPrice;
        int BuyPrice;

        short LinkedItem; //GETS SET BY EQUIPMENT SYSTEM

        bool isQuestItem;

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddShort(ID);
            f.AddString(Category);
            f.AddString(Name);
            f.AddShort(IconID);

            f.AddShort(MaxInStack);

            f.AddByte(Rarity);

            f.AddInt(Value);
            f.AddInt(SellPrice);
            f.AddInt(BuyPrice);

            f.AddShort(LinkedItem);
            f.AddByte((byte)(isQuestItem ? 1 : 0));
        }

        internal static Item LoadFromBinaryIO(BinaryIO f) {
            Item t = new Item();

            t.ID = f.GetShort();
            t.Category = f.GetString();
            t.Name = f.GetString();
            t.IconID = f.GetShort();

            t.MaxInStack = f.GetShort();
            t.Rarity = f.GetByte();

            t.Value = f.GetInt();
            t.SellPrice = f.GetInt();
            t.BuyPrice = f.GetInt();

            t.LinkedItem = f.GetShort();
            t.isQuestItem = (f.GetByte() == 1);

            return t;
        }
    }
}
