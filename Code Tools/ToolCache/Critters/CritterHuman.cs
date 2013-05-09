using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Critters {
    public class CritterHuman : Critter {
        public string Shadow = "";
        public string Legs = "";
        public string Body = "";
        public string Face = "";
        public string Headgear = "";
        public string Weapon = "";

        public CritterHuman() {
            CritterType = CritterTypes.Humanoid;
        }

        internal static CritterHuman LoadHumanoid(BinaryIO f) {
            CritterHuman c = new CritterHuman();
            
            //Load and set basic information
            c.BaseLoad(f);

            //Load the equipment information
            c.Shadow = f.GetString();
            c.Legs = f.GetString();
            c.Body = f.GetString();
            c.Face = f.GetString();
            c.Headgear = f.GetString();
            c.Weapon = f.GetString();

            return c;
        }

        internal override void PackIntoBinaryIO(BinaryIO f) {
            base.PackIntoBinaryIO(f);

            f.AddString(Shadow);
            f.AddString(Legs);
            f.AddString(Body);
            f.AddString(Face);
            f.AddString(Headgear);
            f.AddString(Weapon);
        }
    }
}