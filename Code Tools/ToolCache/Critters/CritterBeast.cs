using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Critters {
    public class CritterBeast : Critter {

        internal static Critter LoadBeastoid(BinaryIO f) {
            Critter c = Critter.Load(f);
            c.CritterType = CritterTypes.NonHumanoid;

            return c;
        }

        internal override void PackIntoBinaryIO(General.BinaryIO f) {
            base.PackIntoBinaryIO(f);
        }


    }
}
