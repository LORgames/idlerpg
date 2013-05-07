﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Critters {
    public class CritterBeast : Critter {

        internal static CritterBeast LoadBeastoid(BinaryIO f) {
            CritterBeast c = new CritterBeast();
            
            //Load basic information
            c.BaseLoad(f);
            c.CritterType = CritterTypes.NonHumanoid;

            //Now load more complex information (there will probably be a lot of this kind of stuff

            return c;
        }

        internal override void PackIntoBinaryIO(General.BinaryIO f) {
            base.PackIntoBinaryIO(f);
        }


    }
}
