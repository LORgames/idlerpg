using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    /// <summary>
    /// Types that can be called from within the scripts
    /// </summary>
    enum InternalTypes {
        Critter = 0xA000,
        Enemy = 0xA001,
        Object = 0xA002,
        Ally = 0xA003,
        NotCritter = 0xA005,
        NotMe = 0xA006,
        Effect = 0xA007,
        NotEffect = 0xA008,
        NotObject = 0xA009
    }
}
