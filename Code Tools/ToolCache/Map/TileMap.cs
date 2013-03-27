using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Map {
    public class TileMap {
        public int numTilesX;
        public int numTilesY;

        public short[,] Data;

        public TileMap() {
            CreateMapFromNothing();
        }

        public void CreateMapFromNothing() {
            numTilesX = 50;
            numTilesY = 50;

            Data = new short[numTilesX, numTilesY];

            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    Data[i, j] = 0;
                }
            }
        }

        public void LoadMapFromFile(BinaryIO mapFile) {
            numTilesX = mapFile.GetInt();
            numTilesY = mapFile.GetInt();

            Data = new short[numTilesX, numTilesY];

            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    Data[i, j] = mapFile.GetShort();
                }
            }

            //MainWindow.instance.txtMapSizeX.Text = numTilesX.ToString();
            //MainWindow.instance.txtMapSizeY.Text = numTilesY.ToString();
        }

        public void SaveMap(BinaryIO mapFile) {
            mapFile.AddInt(numTilesX);
            mapFile.AddInt(numTilesY);

            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    mapFile.AddShort(Data[i, j]);
                }
            }
        }

        public void ChangeSizeTo(int newSizeW, int newSizeH, int extendMethodX, int extendMethodY) {
            short[,] newTiles = new short[newSizeW, newSizeH];

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
                        newTiles[i, j] = Data[effectiveX, effectiveY];
                    } else {
                        newTiles[i, j] = 0;
                    }
                }
            }

            Data = newTiles;
        }
    }
}
