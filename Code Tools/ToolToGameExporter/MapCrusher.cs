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

                m.AddString(map.Name);
                f.AddString(map.Name);

                //Tiles First?
                f.AddShort((short)map.Tiles.numTilesX);
                f.AddShort((short)map.Tiles.numTilesY);

                for (int i = 0; i < map.Tiles.numTilesX; i++) {
                    for (int j = 0; j < map.Tiles.numTilesY; j++) {
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
