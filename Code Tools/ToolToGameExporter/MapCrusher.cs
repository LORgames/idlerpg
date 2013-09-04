using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using ToolCache.General;
using ToolCache.Map.Objects;
using ToolCache.Map.Regions;
using System.Drawing;
using ToolCache.Scripting;
using ToolCache.Scripting.Types;

namespace ToolToGameExporter {
    internal class MapCrusher {

        public static void Go() {
            BinaryIO m = new BinaryIO();

            m.AddShort((short)MapPieceCache.Pieces.Count);
            m.AddShort((short)Portals.Data.Count);

            foreach (MapPiece map in MapPieceCache.Pieces) {
                BinaryIO f = new BinaryIO();

                if (!map.isLoaded) map.Load(true);
                
                m.AddString(map.Name);
                f.AddString(map.Name);

                //Add the music ID
                if (SoundCrusher.MusicConversions.ContainsKey(map.Music)) {
                    f.AddShort(SoundCrusher.MusicConversions[map.Music]);
                } else {
                    f.AddShort(0);
                    if (map.Music != "") Processor.Errors.Add(new ProcessingError("Map", map.Name, "Music (" + map.Music + ") doesn't exist."));
                }

                f.AddByte((byte)map.Portals.Count);
                m.AddByte((byte)map.Portals.Count);

                foreach (Portal p in map.Portals) {
                    m.AddShort(PortalCrusher.RemappedPortalIDs[p.ID]);

                    f.AddShort(PortalCrusher.RemappedPortalIDs[p.ID]);
                    f.AddShort(PortalCrusher.RemappedPortalIDs[p.ExitID]);
                    f.AddShort((short)p.EntryPoint.X);
                    f.AddShort((short)p.EntryPoint.Y);
                    f.AddShort((short)p.EntrySize.Width);
                    f.AddShort((short)p.EntrySize.Height);
                }

                //Tiles First?
                f.AddShort((short)map.Tiles.numTilesX);
                f.AddShort((short)map.Tiles.numTilesY);

                if (GlobalSettings.enableTiles) {
                    for (int i = 0; i < map.Tiles.numTilesX; i++) {
                        for (int j = 0; j < map.Tiles.numTilesY; j++) {
                            short _d = map.Tiles[i, j];
                            f.AddShort(TileCrusher.RemappedTileIds[map.Tiles[i, j]]);
                        }
                    }
                }

                //Now objects
                f.AddShort((short)map.Objects.Count);

                for (int i = 0; i < map.Objects.Count; i++) {
                    BaseObject obj = map.Objects[i];

                    f.AddShort(MapObjectCrusher.RealignedItemIndexes[obj.ObjectType]);
                    f.AddShort((short)obj.Location.X);
                    f.AddShort((short)obj.Location.Y);
                }

                //Spawn things
                if (map.Spawns.Count > 255) Processor.Errors.Add(new ProcessingError("Map", map.Name + ":Spawns", "Can only have upto 255 spawns per map."));
                f.AddByte((byte)map.Spawns.Count);

                for (int i = 0; i < map.Spawns.Count; i++) {
                    SpawnRegion sr = map.Spawns[i];

                    // All the spawn information (thats relevant)
                    f.AddByte((byte)sr.MaxSpawn);
                    f.AddByte((byte)sr.SpawnOnLoad);
                    f.AddShort((short)sr.Timeout);

                    // Rectangles
                    if (sr.Areas.Count > 255) Processor.Errors.Add(new ProcessingError("Map", map.Name + ":Spawns:Zones", "Can only have upto 255 zones per spawn. Surpassed in " + sr.Name));
                    f.AddByte((byte)sr.Areas.Count); // How many rectangles we have

                    // Rectangle0 (needs to be extended)
                    foreach (Rectangle Area in sr.Areas) {
                        f.AddShort((short)Area.Left);
                        f.AddShort((short)Area.Top);
                        f.AddShort((short)Area.Width);
                        f.AddShort((short)Area.Height);
                    }
                    
                    // Add what critters are here and what percents
                    if (sr.SpawnList.Count > 255) Processor.Errors.Add(new ProcessingError("Map", map.Name + ":Spawns:Critters", "Can only have upto 255 critters in the spawn list. Surpassed in " + sr.Name));
                    f.AddByte((byte)sr.SpawnList.Count);

                    foreach (CritterSpawn cs in sr.SpawnList) {
                        f.AddShort(CritterCrusher.RemappedCritterIDs[cs.critterID]);
                        f.AddByte((byte)(cs.spawnChance/100.0f * 255));
                    }
                }

                //Script Regions
                if (map.ScriptRegions.Count > 255) Processor.Errors.Add(new ProcessingError("Map", map.Name + ":ScriptRegions", "Can only have upto 255 ScriptRegions per map."));
                f.AddByte((byte)map.ScriptRegions.Count);

                for (int i = 0; i < map.ScriptRegions.Count; i++) {
                    ScriptRegion sr = map.ScriptRegions[i];

                    // Rectangles
                    if (sr.Areas.Count > 255) Processor.Errors.Add(new ProcessingError("Map", map.Name + ":ScriptRegion:Zones", "Can only have upto 255 zones per ScriptRegion. Surpassed in " + sr.Name));
                    f.AddByte((byte)sr.Areas.Count); // How many rectangles we have

                    // Rectangle0 (needs to be extended)
                    foreach (Rectangle Area in sr.Areas) {
                        f.AddShort((short)Area.Left);
                        f.AddShort((short)Area.Top);
                        f.AddShort((short)Area.Width);
                        f.AddShort((short)Area.Height);
                    }

                    ScriptInfo info = new ScriptInfo("Map."+map.Name+":ScriptRegion."+sr.Name, ScriptTypes.Region);
                    ScriptCrusher.ProcessScript(info, sr.Script, f);
                }

                f.Encode(Global.EXPORT_DIRECTORY + "/Map_" + map.Name + ".bin");
            }

            m.Encode(Global.EXPORT_DIRECTORY + "/MapInfo.bin");
        }

    }
}
