using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Critters {
    public enum AITypes {
        Wonder = 1,
        Kite = 2,
        Pathfind = 4,
        Aggressive = 8,
        Hunting = 16,
        HiveMind = 32,
        RunAway = 64,
        Alpha = 128,
        Territorial = 256
    }
}
