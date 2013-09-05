using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Sound;
using System.IO;
using ToolCache.General;

namespace ToolToGameExporter {
    internal class SoundCrusher {

        internal static Dictionary<string, short> MusicConversions = new Dictionary<string, short>();
        internal static Dictionary<string, short> AmbienceConversions = new Dictionary<string, short>();
        internal static Dictionary<string, short> EffectConversions = new Dictionary<string, short>();
        internal static Dictionary<string, short> GroupConversions = new Dictionary<string, short>();

        internal static void Go() {
            MusicConversions.Clear();
            AmbienceConversions.Clear();
            EffectConversions.Clear();

            CrushList(SoundDatabase.Music, MusicConversions, "Sound/Music", "Music_");
            CrushList(SoundDatabase.Ambience, AmbienceConversions, "Sound/Ambience", "Ambience_");
            CrushList(SoundDatabase.Effects, EffectConversions, "Sound/Effects", "Effects_");

            CrushGroup(SoundDatabase.EffectGroups, GroupConversions, EffectConversions, "EffectGroups");
        }

        private static void CrushList(List<SoundData> sounds, Dictionary<string, short> indexing, string folder, string prefix) {
            short id = 0;

            foreach (SoundData s in sounds) {
                string truefn = folder + "/" + s.Filename;

                if (File.Exists(truefn)) {
                    File.Copy(truefn, Global.EXPORT_DIRECTORY + "/" + prefix + id + ".mp3");

                    try {
                        indexing.Add(s.Name, id);
                    } catch {
                        Processor.Errors.Add(new ProcessingError(folder, s.Name, "There are multiple sounds named the same. This is not allowed. Please rename one of them and try again."));
                    }
                    id++;
                }
            }
        }

        private static void CrushGroup(Dictionary<string, List<SoundData>> groupDict, Dictionary<String, short> indexing, Dictionary<string, short> crushedGroupData, string filename) {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)groupDict.Count);

            short i = 0;

            foreach (KeyValuePair<string, List<SoundData>> kvp in groupDict) {
                f.AddShort((short)kvp.Value.Count);

                foreach (SoundData s in kvp.Value) {
                    f.AddShort(crushedGroupData[s.Name]);
                }

                indexing.Add(kvp.Key, i);
                i++;
            }

            f.Encode(Global.EXPORT_DIRECTORY +  "/" + filename + ".bin");
        }
    }
}
