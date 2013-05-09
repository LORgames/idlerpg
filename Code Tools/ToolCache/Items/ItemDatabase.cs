using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;

namespace ToolCache.Items {
    public class ItemDatabase {
        private const string FILENAME = Settings.Database + "Items.bin";

        private static Dictionary<short, Item> items = new Dictionary<short, Item>();
        private static Dictionary<string, List<Item>> itemsPerCategory = new Dictionary<string, List<Item>>();

        private static short NextID = 0;

        public static List<Item> Items {
            get { return items.Values.ToList<Item>(); }
        }

        public static List<String> Categories {
            get { return itemsPerCategory.Keys.ToList<string>(); }
        }

        public static short NextItemID {
            get { return NextID; }
        }

        public static void Initialize() {
            itemsPerCategory.Clear();
            items.Clear();
            NextID = 0;

            LoadDatabase();
        }

        private static void LoadDatabase() {
            if (File.Exists(FILENAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(FILENAME));

                short totalItems = f.GetShort();

                for (int i = 0; i < totalItems; i++) {
                    AddItem(Item.LoadFromBinaryIO(f));
                }

                f.Dispose();
            }
        }

        public static void AddItem(Item t) {
            items.Add(t.ID, t);

            if (NextID <= t.ID) {
                NextID = t.ID;
                NextID++;
            }

            if (!itemsPerCategory.ContainsKey(t.Category)) {
                itemsPerCategory.Add(t.Category, new List<Item>());
            }

            itemsPerCategory[t.Category].Add(t);
        }

        public static void SaveDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)items.Count);

            foreach (KeyValuePair<short, Item> kvp in items) {
                kvp.Value.WriteToBinaryIO(f);
            }

            f.Encode(FILENAME);
            f.Dispose();
        }

        public static Item Get(short itemID) {
            if (items.ContainsKey(itemID)) {
                return items[itemID];
            }

            Item t = new Item();
            t.ID = NextID;
            return t;
        }

        public static void UpdatedItem(Item item) {
            if (item.Category != item.OldCategory && itemsPerCategory.ContainsKey(item.OldCategory) && itemsPerCategory[item.OldCategory].Contains(item)) {
                itemsPerCategory[item.OldCategory].Remove(item);

                if (itemsPerCategory[item.OldCategory].Count == 0) {
                    itemsPerCategory.Remove(item.OldCategory);
                }

                item.OldCategory = item.Category;
            }

            if (!itemsPerCategory.ContainsKey(item.Category)) {
                itemsPerCategory.Add(item.Category, new List<Item>());
            }

            if (!itemsPerCategory[item.Category].Contains(item)) {
                itemsPerCategory[item.Category].Add(item);
            }
        }
    }
}
