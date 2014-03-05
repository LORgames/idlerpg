using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Map.Objects;
using ToolCache.Map.Regions;
using ToolCache.Storage;

namespace ToolCache.Map.Tiles {
    public class TileMap {
        public int numTilesX;
        public int numTilesY;
        public MapPiece Map;

        public short this[int i, int j] {
            get {
                return Data[i,j].TileID;
            }
            set {
                Data[i, j].ChangeTile(value);
            }
        }

        public TileInstance[,] Data;

        public TileMap(MapPiece owner) {
            Map = owner;
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

            Map.WorldRectangle = new RectangleX(0, 0, numTilesX * TileTemplate.PIXELS, numTilesY * TileTemplate.PIXELS, 0.0f);
        }

        public void LoadMapFromFile(IStorage mapFile) {
            numTilesX = mapFile.GetInt();
            numTilesY = mapFile.GetInt();

            Data = new TileInstance[numTilesX, numTilesY];

            for (int i = 0; i < numTilesX; i++) {
                for (int j = 0; j < numTilesY; j++) {
                    Data[i, j] = new TileInstance(mapFile.GetShort(), i, j);
                }
            }

            Map.WorldRectangle = new RectangleX(0, 0, numTilesX * TileTemplate.PIXELS, numTilesY * TileTemplate.PIXELS, 0.0f);
        }

        public void SaveMap(IStorage mapFile) {
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
                    effectiveX = (extendX == 0) ? i : (extendX == 2 ? i - sizeDifX : i - sizeDifX / 2);
                    effectiveY = (extendY == 0) ? j : (extendY == 2 ? j - sizeDifY : j - sizeDifY / 2);

                    if (effectiveX >= 0 && effectiveX < oldTotalTilesX && effectiveY >= 0 && effectiveY < oldTotalTilesY) {
                        newTiles[i, j] = new TileInstance(Data[effectiveX, effectiveY].TileID, i, j);
                    } else {
                        newTiles[i, j] = new TileInstance(fillTileID, i, j);
                    }
                }
            }

            //Loop over objects and move them
            int offsetX = (extendX == 0) ? 0 : (extendX == 2 ? TileTemplate.PIXELS * sizeDifX : TileTemplate.PIXELS * sizeDifX / 2);
            int offsetY = (extendY == 0) ? 0 : (extendY == 2 ? TileTemplate.PIXELS * sizeDifY : TileTemplate.PIXELS * sizeDifY / 2);

            Data = newTiles;

            foreach (BaseObject o in Map.Objects) {
                o.Move(offsetX, offsetY, false);
            }

            foreach (Portal o in Map.Portals) {
                o.Move(offsetX, offsetY);
            }

            foreach (SpawnRegion o in Map.Spawns) {
                o.Move(offsetX, offsetY);
            }

            foreach (ScriptRegion o in Map.ScriptRegions) {
                o.Move(offsetX, offsetY);
            }

            Map.WorldRectangle = new RectangleX(0, 0, numTilesX * TileTemplate.PIXELS, numTilesY * TileTemplate.PIXELS, 0.0f);
        }

        public List<TileInstance> GetTilesFromWorldRectangle(int x, int y, int w, int h, float r) {
            List<TileInstance> retList = new List<TileInstance>();

            int LX = x / TileTemplate.PIXELS;
            int LY = y / TileTemplate.PIXELS;
            int UX = (x + w) / TileTemplate.PIXELS;
            int UY = (y + h) / TileTemplate.PIXELS;

            if (LX < 0) LX = 0;
            if (LY < 0) LY = 0;
            if (UX >= numTilesX) UX = numTilesX - 1;
            if (UY >= numTilesY) UY = numTilesY - 1;

            for (int i = LX; i <= UX; i++) {
                for (int j = LY; j <= UY; j++) {
                    //Calculate if the object is somewhere useful or not
                    retList.Add(Data[i, j]);
                }
            }

            return retList;
        }

        public override string ToString() {
            return Map.Name + " (Tiles)";
        }
    }
}
