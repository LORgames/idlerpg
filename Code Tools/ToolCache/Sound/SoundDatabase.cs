using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;

namespace ToolCache.Sound {
    public class SoundDatabase {
        private const string FILENAME = Settings.Database + "Sounds.bin";

        public static List<SoundData> Music = new List<SoundData>();
        public static List<SoundData> Ambience = new List<SoundData>();
        public static List<SoundData> Effects = new List<SoundData>();

        public static Dictionary<string, List<SoundData>> EffectGroups = new Dictionary<string, List<SoundData>>();

        internal static void Initialize() {
            Music.Clear();
            Ambience.Clear();
            Effects.Clear();

            ReadDatabase();
        }

        private static void ReadDatabase() {
            if (File.Exists(FILENAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(FILENAME));

                //First load music
                short totalMusic = f.GetShort();
                while (--totalMusic > -1) {
                    SoundData s = new SoundData();
                    s.Filename = f.GetString();
                    s.Name = f.GetString();
                    Music.Add(s);
                }

                //Now load ambience
                short totalAmbience = f.GetShort();
                while (--totalAmbience > -1) {
                    SoundData s = new SoundData();
                    s.Filename = f.GetString();
                    s.Name = f.GetString();
                    Ambience.Add(s);
                }

                //Now load effects
                List<string> effectNames = new List<string>();
                short totalEffects = f.GetShort();
                while (--totalEffects > -1) {
                    SoundData s = new SoundData();
                    s.Filename = f.GetString();
                    s.Name = f.GetString();
                    effectNames.Add(s.Name);
                    Effects.Add(s);
                }

                //Now load effect groups
                if (!f.IsEndOfFile()) {
                    short totalGroups = f.GetShort();

                    while (--totalGroups > -1) {
                        string name = f.GetString();
                        List<SoundData> sd = new List<SoundData>();
                        EffectGroups.Add(name, sd);

                        short totalSounds = f.GetShort();
                        while (--totalSounds > -1) {
                            sd.Add(Effects[effectNames.IndexOf(f.GetString())]);
                        }
                    }
                }
            }
        }

        public static void SaveDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)Music.Count);
            foreach (SoundData s in Music) {
                f.AddString(s.Filename);
                f.AddString(s.Name);
            }

            f.AddShort((short)Ambience.Count);
            foreach (SoundData s in Ambience) {
                f.AddString(s.Filename);
                f.AddString(s.Name);
            }

            f.AddShort((short)Effects.Count);
            foreach (SoundData s in Effects) {
                f.AddString(s.Filename);
                f.AddString(s.Name);
            }

            f.AddShort((short)EffectGroups.Count);
            foreach (KeyValuePair<string, List<SoundData>> kvp in EffectGroups) {
                f.AddString(kvp.Key);
                f.AddShort((short)kvp.Value.Count);
                foreach (SoundData s in kvp.Value) {
                    f.AddString(s.Name);
                }
            }

            f.Encode(FILENAME);
        }

        internal static bool HasEffect(string EffectName) {
            foreach (SoundData sound in Effects) {
                if (sound.Name == EffectName) {
                    return true;
                }
            }

            return false;
        }

        public static List<SoundData> GetEffectGroup(string effectGroupName) {
            if (EffectGroups.ContainsKey(effectGroupName)) {
                return EffectGroups[effectGroupName];
            }

            return null;
        }
    }
}
