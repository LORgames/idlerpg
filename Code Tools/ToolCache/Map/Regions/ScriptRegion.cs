using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.Map.Regions {
    public class ScriptRegion : RegionBase {
        public string Script = "";

        public static ScriptRegion LoadFromBinaryIO(IStorage f) {
            ScriptRegion s = new ScriptRegion();

            UnpackNameAndAreas(f, s);
            s.Script = f.GetString();

            return s;
        }

        public void SaveToBinaryIO(IStorage f) {
            WriteNameAndAreas(f);
            f.AddString(Script);
        }
    }
}
