using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using System.IO;

namespace ToolCache.World {
    public class WorldManager {
        public static List<Portal> Portals = new List<Portal>();
        public static Dictionary<String, Point> MapPositions = new Dictionary<string, Point>();

        public static short NextPortalID = 0;

        internal static void Initialize() {

        }

        private static void LoadDatabase() {
            if (File.Exists(Settings.CACHE + "/db_World.bin")) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(Settings.CACHE + "/db_World.bin"));

                //Read maps
                short totalMaps = f.GetShort();
                while (--totalMaps > -1) {
                    string mapName = f.GetString();
                    short _x = f.GetShort();
                    short _y = f.GetShort();

                    MapPositions.Add(mapName, new Point(_x, _y));
                }

                //Read portals
                short totalPortals = f.GetShort();
                while (--totalPortals > -1) {
                    
                }
            }
        }
    }
}
