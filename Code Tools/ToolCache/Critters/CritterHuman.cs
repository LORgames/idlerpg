using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Critters {
    public class CritterHuman : Critter {

        internal static Critter LoadHumanoid(BinaryIO f) {
            Critter c = Critter.Load(f);
            c.CritterType = CritterTypes.NonHumanoid;

            return c;
        }
    }
}