using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    /// <summary>
    /// The types of scripts so they can be parsed differently.
    /// </summary>
    public enum ScriptTypes {
        Unknown = 0,
        Map = 1,
        Critter = 2,
        Item = 4,
        Equipment = 8,
        Object = 16,
        Effect = 32,
        Region = 64,
        UIElement = 128
    }
}
