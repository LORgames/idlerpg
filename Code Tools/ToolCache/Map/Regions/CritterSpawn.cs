using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.Windows.Forms;
using ToolCache.Critters;

namespace ToolCache.Map.Regions {
    public class CritterSpawn {
        public short critterID = -1;
        public float spawnChance = 100.0f;

        public CritterSpawn() {}

        public CritterSpawn(short id) {
            critterID = id;
        }

        internal static CritterSpawn LoadFromBinaryIO(BinaryIO f) {
            CritterSpawn c = new CritterSpawn();

            c.critterID = f.GetShort();
            c.spawnChance = f.GetFloat();

            return c;
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddShort(critterID);
            f.AddFloat(spawnChance);
        }

        public ListViewItem GetListViewItem() {
            ListViewItem lvi = new ListViewItem(CritterManager.Critters[critterID].Name);

            lvi.SubItems.Add(spawnChance.ToString());

            lvi.Tag = this;

            return lvi;
        }

        public string UpdateFromListView(ListViewItem myListView, int subitem, string newValue) {
            switch (subitem) {
                case 1:
                    spawnChance = float.Parse(newValue);
                    return spawnChance.ToString();
            }

            return "";
        }
    }
}
