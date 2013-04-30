using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using ToolCache.General;
using ToolCache.Map.Objects;

namespace ToolToGameExporter {
    public class MapCrusher {

        public static void Go() {
            BinaryIO m = new BinaryIO();

            m.AddShort((short)MapPieceCache.Pieces.Count);

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

                    if(map.Music != "") Processor.Errors.Add("Map (" + map.Name + ") uses music (" + map.Music + ") that doesn't exist.");
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
