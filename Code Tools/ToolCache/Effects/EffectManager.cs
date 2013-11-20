using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.Effects {
    public class EffectManager {
        private const string filename = General.Settings.Database + "Effects.bin";

        public static Dictionary<String, Effect> Effects = new Dictionary<string, Effect>();
        public static Dictionary<String, List<Effect>> EffectsInGroups = new Dictionary<string, List<Effect>>();

        internal static void Initialize() {
            Effects.Clear();
            EffectsInGroups.Clear();

            ReadDatabase();
        }

        private static void ReadDatabase() {
            if (File.Exists(filename)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(filename));

                short totalEffects = f.GetShort();

                while (--totalEffects > -1) {
                    AddEffect(Effect.ReadFromBinaryIO(f));
                }
            }
        }

        public static void WriteDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)Effects.Count);

            foreach (Effect fx in Effects.Values) {
                fx.WriteToBinaryIO(f);
            }

            f.Encode(filename);
        }

        public static void AddEffect(Effect e) {
            //Cannot have spaces in the name
            e.Name = e.Name.Replace(" ", "");

            e.OldName = e.Name;
            e.OldGroup = e.Group;

            Effects.Add(e.Name, e);

            VerifyGroup(e.Group);

            EffectsInGroups[e.Group].Add(e);
        }

        private static void VerifyGroup(String groupName) {
            if (!EffectsInGroups.ContainsKey(groupName)) {
                EffectsInGroups.Add(groupName, new List<Effect>());
            }
        }

        public static void UpdatedEffect(Effect e) {
            e.Name = e.Name.Replace(" ", "");

            if (e.Group != e.OldGroup) {
                EffectsInGroups[e.OldGroup].Remove(e);
                VerifyGroup(e.Group);
                EffectsInGroups[e.Group].Add(e);
            }

            if (e.Name != e.OldName) {
                Effects.Remove(e.OldName);
                Effects.Add(e.Name, e);
            }

            e.OldGroup = e.Group;
            e.OldName = e.Name;
        }

    }
}
