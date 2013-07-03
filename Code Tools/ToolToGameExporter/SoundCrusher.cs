using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Sound;
using System.IO;

namespace ToolToGameExporter {
    internal class SoundCrusher {

        internal static Dictionary<string, short> MusicConversions = new Dictionary<string, short>();
        internal static Dictionary<string, short> AmbienceConversions = new Dictionary<string, short>();
        internal static Dictionary<string, short> EffectConversions = new Dictionary<string, short>();

        internal static void Go() {
            MusicConversions.Clear();
            AmbienceConversions.Clear();
            EffectConversions.Clear();

            CrushList(SoundDatabase.Music, MusicConversions, "Sound/Music", "Music_");
            CrushList(SoundDatabase.Ambience, AmbienceConversions, "Sound/Ambience", "Ambience_");
            CrushList(SoundDatabase.Effects, EffectConversions, "Sound/Effects", "Effects_");
        }

        private static void CrushList(List<SoundData> sounds, Dictionary<string, short> indexing, string folder, string prefix) {
            short id = 0;

            foreach (SoundData s in sounds) {
                string truefn = folder + "/" + s.Filename;

                if (File.Exists(truefn)) {
                    File.Copy(truefn, Global.EXPORT_DIRECTORY + "/" + prefix + id + ".mp3");

                    indexing.Add(s.Name, id);
                    id++;
                }
            }
        }

    }
}
