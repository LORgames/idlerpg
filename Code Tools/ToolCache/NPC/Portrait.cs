using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.NPC {
    public class Portrait {
        public string Name = "";
        public string Filename = "";

        public static Portrait LoadFromBinaryIO(IStorage f) {
            Portrait p = new Portrait();

            p.Name = f.GetString();
            p.Filename = f.GetString();

            return p;
        }

        internal void SaveToBinaryIO(IStorage f) {
            f.AddString(Name);
            f.AddString(Filename);
        }

        public override string ToString() {
            if (Name.Length == 0) return "Unnamed";
            return Name;
        }
    }
}
