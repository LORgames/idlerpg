using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Critters {
    public class CritterHuman : Critter {
        private string shadow = "";
        private string legs = "";
        private string body = "";
        private string face = "";
        private string headgear = "";
        private string weapon = "";

        public CritterHuman() {
            CritterType = CritterTypes.Humanoid;
        }

        internal static CritterHuman LoadHumanoid(BinaryIO f) {
            CritterHuman c = new CritterHuman();
            
            //Load and set basic information
            c.BaseLoad(f);

            //Load the equipment information
            c.shadow = f.GetString();
            c.legs = f.GetString();
            c.body = f.GetString();
            c.face = f.GetString();
            c.headgear = f.GetString();
            c.weapon = f.GetString();

            return c;
        }

        internal override void PackIntoBinaryIO(BinaryIO f) {
            base.PackIntoBinaryIO(f);

            f.AddString(shadow);
            f.AddString(legs);
            f.AddString(body);
            f.AddString(face);
            f.AddString(headgear);
            f.AddString(weapon);
        }
    }
}