using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Critters {
    public enum AITypes {
        Wonder = 1,             // Aimlessly walks around
        Kite = 2,               // Ranged and runs away
        ClosestTarget = 4,      // No idea?
        Aggressive = 8,         // Actively looks for new targets
        Supportive = 16,        // Chooses ally units as targets rather than enemies
        Territorial = 32,       // Defends their spawn zone and returns to it if they get too far away
        RunAway = 64,           // Runs away on low health
        Untargetable = 128,     // Can you target this unit?
        TargetLowestHP = 256,   // Targets the unit with the lowest HP
        BlindBehind = 512,      // Targets the unit with the lowest HP
        Unsupportable = 1024,   // Targets the unit with the lowest HP
        DisableTurning = 2048,  // Unit can't turn around
    }

    public class AITypesHelper {
        public static Dictionary<string, ushort> StringToValue = new Dictionary<string, ushort>();
        public static Dictionary<string, ushort> StringLowerToValue = new Dictionary<string, ushort>();

        internal static void Initialize() {
            StringToValue.Clear();
            Array x = Enum.GetValues(typeof(AITypes));

            foreach (AITypes ait in x) {
                string name = Enum.GetName(typeof(AITypes), ait);
                StringToValue.Add(name, (ushort)ait);
                StringLowerToValue.Add(name.ToLower(), (ushort)ait);
            }
        }
    }
}
