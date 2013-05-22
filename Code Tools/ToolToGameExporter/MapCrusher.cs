using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using ToolCache.General;
using ToolCache.Map.Objects;
using ToolCache.World;

namespace ToolToGameExporter {
    public class MapCrusher {

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

                    if(map.Music != "") Processor.Errors.Add(new ProcessingError("Map", map.Name, "Music (" + map.Music + ") doesn't exist."));
                }

                f.AddByte((byte)map.Portals.Count);
                m.AddByte((byte)map.Portals.Count);

                foreach (Portal p in map.Portals) {
                    m.AddShort(PortalCrusher.RemappedPortalIDs[p.ID]);

                    f.AddShort(PortalCrusher.RemappedPortalIDs[p.ID]);
                    f.AddShort(PortalCrusher.RemappedPortalIDs[p.ExitID]);
                    f.AddShort((short)p.ExitPoint.X);
                    f.AddShort((short)p.ExitPoint.Y);
                    f.AddShort((short)p.EntryPoint.X);
                    f.AddShort((short)p.EntryPoint.Y);
                    f.AddShort((short)p.EntrySize.Width);
                    f.AddShort((short)p.EntrySize.Height);
                }

                //Tiles First?
                f.AddShort((short)map.Tiles.numTilesX);
                f.AddShort((short)map.Tiles.numTilesY);

                for (int i = 0; i < map.Tiles.numTilesX; i++) {
                    for (int j = 0; j < map.Tiles.numTilesY; j++) {
                        if (i == 1 && j == 1) {
                            System.Diagnostics.Debug.WriteLine(map.Name + " " + map.Tiles[i, j]);
                        }

                        short _d = map.Tiles[i, j];

                        f.AddShort(TileCrusher.RemappedTileIds[map.Tiles[i, j]]);
                    }
                }

                //Now objects
                f.AddShort((short)map.Objects.Count);

                for (int i = 0; i < map.Objects.Count; i++) {
                    BaseObject obj = map.Objects[i];

                    f.AddShort(ObjectCrusher.RealignedItemIndexes[obj.ObjectType]);
                    f.AddShort((short)obj.Location.X);
                    f.AddShort((short)obj.Location.Y);
                }

                f.Encode(Global.EXPORT_DIRECTORY + "/Map_" + map.Name + ".bin");
            }

            m.Encode(Global.EXPORT_DIRECTORY + "/MapInfo.bin");
        }

    }
}
