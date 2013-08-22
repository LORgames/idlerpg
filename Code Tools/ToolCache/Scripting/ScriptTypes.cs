using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting {
    /// <summary>
    /// The types of scripts so they can be parsed differently.
    /// </summary>
    public enum ScriptTypes {
        Unknown,
        Map,
        Critter,
        Item,
        Equipment,
        Object,
        Effect,
        Region
    }
}
