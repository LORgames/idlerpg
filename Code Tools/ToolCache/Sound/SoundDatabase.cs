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
                short totalEffects = f.GetShort();
                while (--totalEffects > -1) {
                    SoundData s = new SoundData();
                    s.Filename = f.GetString();
                    s.Name = f.GetString();
                    Effects.Add(s);
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
    }
}
