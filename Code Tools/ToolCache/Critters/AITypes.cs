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
        RunAway = 64           // Runs away on low health
    }
}
