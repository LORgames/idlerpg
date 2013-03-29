using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Map.Tiles {
    public class TileMap {
        public int numTilesX;
        public int numTilesY;

        public short this[int i, int j] {
            get {
                return Data[i,j].TileID;
            }
            set {
                Data[i, j].ChangeTile(value);
            }
        }

        public TileInstance[,] Data;

        public TileMap() {
            
        }

        public void CreateMapFromNothing(short fillTileID) {
            numTilesX = 50;
            numTilesY = 50;

            Data = new TileInstance[numTilesX, numTilesY];

            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    Data[i, j] = new TileInstance(fillTileID, i, j);
                }
            }
        }

        public void LoadMapFromFile(BinaryIO mapFile) {
            numTilesX = mapFile.GetInt();
            numTilesY = mapFile.GetInt();

            Data = new TileInstance[numTilesX, numTilesY];

            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    Data[i, j] = new TileInstance(mapFile.GetShort(), i, j);
                }
            }
        }

        public void SaveMap(BinaryIO mapFile) {
            mapFile.AddInt(numTilesX);
            mapFile.AddInt(numTilesY);

            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    mapFile.AddShort(Data[i, j].TileID);
                }
            }
        }

        public void ChangeSizeTo(short fillTileID, int newSizeW, int newSizeH, int extendMethodX, int extendMethodY) {
            TileInstance[,] newTiles = new TileInstance[newSizeW, newSizeH];

            int oldTotalTilesX = numTilesX;
            int oldTotalTilesY = numTilesY;

            numTilesX = newSizeW;
            numTilesY = newSizeH;

            int effectiveX = 0;
            int effectiveY = 0;

            int sizeDifX = newSizeW - oldTotalTilesX;
            int sizeDifY = newSizeH - oldTotalTilesY;

            int extendX = extendMethodX;
            int extendY = extendMethodY;

            for (int i = 0; i < newSizeW; i++) {
                for (int j = 0; j < newSizeH; j++) {
                    effectiveX = (extendX == 0) ? i : (extendX == 2 ? i - (oldTotalTilesX - 1) : i - sizeDifX / 2);
                    effectiveY = (extendY == 0) ? j : (extendY == 2 ? j - (oldTotalTilesY - 1) : j - sizeDifY / 2);

                    if (effectiveX >= 0 && effectiveX < oldTotalTilesX && effectiveY >= 0 && effectiveY < oldTotalTilesY) {
                        newTiles[i, j] = new TileInstance(Data[effectiveX, effectiveY].TileID, i, j);
                    } else {
                        newTiles[i, j] = new TileInstance(fillTileID, i, j);
                    }
                }
            }

            Data = newTiles;
        }

        internal void RecalculateWalkable() {
            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    Data[i, j].RecalculateWalkable();
                }
            }
        }

        public List<TileInstance> GetTilesFromWorldRectangle(int x, int y, int w, int h) {
            List<TileInstance> retList = new List<TileInstance>();

            int LX = x / TileTemplate.PIXELS_X;
            int LY = y / TileTemplate.PIXELS_Y;
            int UX = (x + w) / TileTemplate.PIXELS_X;
            int UY = (y + h) / TileTemplate.PIXELS_Y;

            if (LX < 0) LX = 0;
            if (LY < 0) LY = 0;
            if (UX >= numTilesX) UX = numTilesX - 1;
            if (UY >= numTilesY) UY = numTilesY - 1;

            for (int i = LX; i <= UX; i++) {
                for (int j = LY; j <= UY; j++) {
                    retList.Add(Data[i, j]);
                }
            }

            return retList;
        }
    }
}
