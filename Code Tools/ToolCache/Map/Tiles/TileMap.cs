﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Map.Tiles {
    public class TileMap {
        public int numTilesX;
        public int numTilesY;

        public short[,] Data;
        public bool[,] Walkable;

        public TileMap() {
            
        }

        public void CreateMapFromNothing(short fillTileID) {
            numTilesX = 50;
            numTilesY = 50;

            Data = new short[numTilesX, numTilesY];
            Walkable = new bool[numTilesX, numTilesY];

            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    Data[i, j] = fillTileID;

                    if(TileCache.Tiles.ContainsKey(Data[i, j])) {
                        Walkable[i, j] = TileCache.Tiles[Data[i, j]].isWalkable;
                    } else {
                        Walkable[i, j] = false;
                    }
                }
            }
        }

        public void LoadMapFromFile(BinaryIO mapFile) {
            numTilesX = mapFile.GetInt();
            numTilesY = mapFile.GetInt();

            Data = new short[numTilesX, numTilesY];
            Walkable = new bool[numTilesX, numTilesY];

            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    Data[i, j] = mapFile.GetShort();
                    Walkable[i, j] = TileCache.Tiles[Data[i, j]].isWalkable;
                }
            }
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

        public void ChangeSizeTo(short fillTileID, int newSizeW, int newSizeH, int extendMethodX, int extendMethodY) {
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
                        newTiles[i, j] = fillTileID;
                    }
                }
            }

            Data = newTiles;
        }
    }
}
