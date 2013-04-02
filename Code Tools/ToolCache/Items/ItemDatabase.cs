using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;

namespace ToolCache.Items {
    public class ItemDatabase {
        private static Dictionary<short, Item> items = new Dictionary<short, Item>();
        private static Dictionary<string, List<Item>> itemsPerCategory = new Dictionary<string, List<Item>>();

        private static short NextID = 0;
        internal static short NextItemID {
            get { return NextID; }
        }

        internal static void Initialize() {
            itemsPerCategory.Clear();
            items.Clear();
            NextID = 0;

            LoadDatabase();
        }

        private static void LoadDatabase() {
            if (File.Exists("cache/db_items.bin")) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes("cache/db_items.bin"));

                short totalItems = f.GetShort();

                for (int i = 0; i < totalItems; i++) {
                    AddItem(Item.LoadFromBinaryIO(f));
                }

                f.Dispose();
            }
        }

        internal static void AddItem(Item t) {
            items.Add(t.ID, t);

            if (NextID <= t.ID) {
                NextID = t.ID;
                NextID++;
            }
        }

        internal static void SaveDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)items.Count);

            foreach (KeyValuePair<short, Item> kvp in items) {
                kvp.Value.WriteToBinaryIO(f);
            }

            f.Encode("cache/db_items.bin");
            f.Dispose();
        }

        internal static Item Get(short itemID) {
            if (items.ContainsKey(itemID)) {
                return items[itemID];
            }

            Item t = new Item();
            t.ID = NextID;
            return t;
        }

        public static List<Item> Items {
            get { return items.Values.ToList<Item>(); }
        }
    }
}
