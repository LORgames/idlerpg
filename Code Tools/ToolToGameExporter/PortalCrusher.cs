using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Regions;

namespace ToolToGameExporter {
    internal class PortalCrusher {
        public static Dictionary<short, short> RemappedPortalIDs = new Dictionary<short, short>();

        public static void Go() {
            RemappedPortalIDs.Clear();

            short nextID = 0;

            List<Portal> AllValues = Portals.Data.Values.ToList<Portal>();
            AllValues.Sort();

            foreach (Portal p in AllValues) {
                RemappedPortalIDs[p.ID] = nextID;
                nextID++;
            }

            return;
        }

    }
}
