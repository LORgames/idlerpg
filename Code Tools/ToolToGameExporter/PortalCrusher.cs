using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.World;

namespace ToolToGameExporter {
    public class PortalCrusher {
        public static Dictionary<short, short> RemappedPortalIDs = new Dictionary<short, short>();

        public static void Go() {
            RemappedPortalIDs.Clear();

            short nextID = 0;

            foreach (Portal p in Portals.Data.Values) {
                RemappedPortalIDs[p.ID] = nextID;
                nextID++;
            }
        }

    }
}
