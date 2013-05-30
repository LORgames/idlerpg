using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting {
    public class ValidEventList {
        public static readonly string[] ValidEvents = {
            "Attack",
            "Spawn",
            "Attacked",
            "Use",
            "Equip",
            "MinionDied",
            "AnimationEnded",
            "StartMoving",
            "EndMoving"
        };
    }
}
