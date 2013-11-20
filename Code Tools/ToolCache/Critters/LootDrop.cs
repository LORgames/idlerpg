using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.Windows.Forms;
using ToolCache.Items;
using ToolCache.Storage;

namespace ToolCache.Critters {
    public class LootDrop {
        short ItemID;
        short Minimum;
        short Maximum;
        float DropChance;
        byte SetID;

        internal static LootDrop Unpack(IStorage f) {
            LootDrop loot = new LootDrop();
            loot.ItemID = f.GetShort();
            loot.Minimum = f.GetShort();
            loot.Maximum = f.GetShort();
            loot.DropChance = f.GetFloat();
            loot.SetID = f.GetByte();

            return loot;
        }

        internal void Pack(IStorage f) {
            f.AddShort(ItemID);
            f.AddShort(Minimum);
            f.AddShort(Maximum);
            f.AddFloat(DropChance);
            f.AddByte(SetID);
        }

        public ListViewItem GetListViewItem() {
            ListViewItem lvi = new ListViewItem(ItemDatabase.Get(ItemID).Name);

            lvi.SubItems.Add(Minimum.ToString());
            lvi.SubItems.Add(Maximum.ToString());
            lvi.SubItems.Add(DropChance.ToString("F2"));
            lvi.SubItems.Add(SetID.ToString());

            lvi.Tag = this;

            return lvi;
        }

        public string UpdateFromListView(ListViewItem myListView, int subitem, string newValue) {
            switch (subitem) {
                case 1:
                    Minimum = short.Parse(newValue);
                    if (Minimum > Maximum) Minimum = Maximum;
                    if (Minimum < 1) Minimum = 1;
                    return Minimum.ToString();
                case 2:
                    Maximum = short.Parse(newValue);
                    if (Minimum > Maximum) Minimum = Maximum; myListView.SubItems[2].Text = Minimum.ToString();
                    if (Maximum < 1) Maximum = 1;
                    return Maximum.ToString();
                case 3:
                    DropChance = float.Parse(newValue);
                    return DropChance.ToString("F2");
                case 4:
                    SetID = byte.Parse(newValue);
                    return SetID.ToString();
            }

            return "";
        }

        public static LootDrop GenerateEmpty(Item item) {
            LootDrop ret = new LootDrop();

            ret.ItemID = item.ID;
            ret.Minimum = 1;
            ret.Maximum = 1;
            ret.DropChance = 100;
            ret.SetID = 0;

            return ret;
        }
    }
}
