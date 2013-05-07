﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.Windows.Forms;
using ToolCache.Items;

namespace ToolCache.Critters {
    public class LootDrop {
        short ItemID;
        short Minimum;
        short Maximum;
        float DropChance;

        internal static LootDrop Unpack(BinaryIO f) {
            LootDrop loot = new LootDrop();
            loot.ItemID = f.GetShort();
            loot.Minimum = f.GetShort();
            loot.Maximum = f.GetShort();
            loot.DropChance = f.GetFloat();

            return loot;
        }

        internal void Pack(BinaryIO f) {
            f.AddShort(ItemID);
            f.AddShort(Minimum);
            f.AddShort(Maximum);
            f.AddFloat(DropChance);
        }

        public ListViewItem GetListViewItem() {
            ListViewItem lvi = new ListViewItem();

            lvi.SubItems.Add(ItemDatabase.Get(ItemID).Name);
            lvi.SubItems.Add(Minimum.ToString());
            lvi.SubItems.Add(Maximum.ToString());
            lvi.SubItems.Add(DropChance.ToString());

            return lvi;
        }
    }
}
