using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Critters;
using ToolCache.General;
using ToolCache.Scripting;
using ToolCache.Storage;
using ToolCache.Scripting.Types;

namespace ToolToGameExporter {
    public class BuffCrusher {

        public static Dictionary<String, short> RemappedBuffIDs = new Dictionary<string, short>();

        public static void Precrush() {
            RemappedBuffIDs.Clear();

            for (int i = 0; i < BuffManager.Buffs.Count; i++) {
                RemappedBuffIDs.Add(BuffManager.Buffs[i].Name, (short)i);
                System.Diagnostics.Debug.WriteLine("Mapped " + BuffManager.Buffs[i].Name + " to " + i);
            }

            ExportCrushers.MappedBuffIDs = RemappedBuffIDs;
        }

        public static void Go() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)BuffManager.Buffs.Count);

            for(int i = 0; i < BuffManager.Buffs.Count; i++) {
                Buff b = BuffManager.Buffs[i];
                f.AddString(b.Name);
                f.AddShort(b.IconID);
                f.AddByte((byte)(b.showsIcon?1:0));
                f.AddByte((byte)(b.isDebuff?1:0));
                f.AddFloat(b.Duration);

                ScriptInfo info = new ScriptInfo("Buff>" + b.Name, ScriptTypes.Buff);
                ScriptCrusher.ProcessScript(info, b.Script, f);
            }

            f.Encode(Global.EXPORT_DIRECTORY + "\\CritterBuffs.bin");
        }
    }
}
