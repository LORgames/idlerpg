using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.Elements {
    public class Element {
        public short ElementID = 0;
        public string ElementName = "";

        private Dictionary<short, float> Multipliers = new Dictionary<short, float>();

        public void SetMultiplier(short elementID, float Multiplier) {
            if(Multipliers.ContainsKey(elementID)) {
                if (Multiplier == 1) {
                    Multipliers.Remove(elementID); //Save memory when not special
                } else {
                    Multipliers[elementID] = Multiplier; 
                }
            } else if(Multiplier != 1) { //Only save it if its not special
                Multipliers.Add(elementID, Multiplier);
            }
        }

        public void RemoveMultiplier(short elementID) {
            SetMultiplier(elementID, 1); //Removes the element from the database?
        }

        public float GetMultiplier(short elementID) {
            if (Multipliers.ContainsKey(elementID)) {
                return Multipliers[elementID];
            } else {
                return 1;
            }
        }

        internal void PackIntoBinaryIO(IStorage f) {
            f.AddShort(ElementID);
            f.AddString(ElementName);

            f.AddShort((short)Multipliers.Count);
            foreach (KeyValuePair<short, float> kvp in Multipliers) {
                f.AddShort(kvp.Key);
                f.AddFloat(kvp.Value);
            }
        }

        //Factory method
        internal static Element UnpackFromBinaryIO(IStorage f) {
            Element e = new Element();
            e.ElementID = f.GetShort();
            e.ElementName = f.GetString();

            short totalElementMultipliers = f.GetShort();
            for (int i = 0; i < totalElementMultipliers; i++) {
                e.SetMultiplier(f.GetShort(), f.GetFloat());
            }

            return e;
        }
    }
}
