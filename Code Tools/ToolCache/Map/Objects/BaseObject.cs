using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.Drawing;
using ToolCache.Animation;
using ToolCache.Map.Tiles;
using ToolCache.General;

namespace ToolCache.Map.Objects {
    public class BaseObject : IComparable<BaseObject> {

        //Circular references
        public bool selected = false;
        public Point Location;
        public short ObjectType;

        public MapObject ObjectTemplate;

        public int ActualY;
        public int ActualX;
        public List<RectangleX> ActualBases = new List<RectangleX>();
        public List<RectangleX> OldActualBases = new List<RectangleX>();

        // Constructor for indexing and sorting
        public BaseObject(short ObjectType, Point initialLocation) {
            this.ObjectType = ObjectType;
            Location = initialLocation;

            ObjectTemplate = MapObjectCache.G(ObjectType);

            RecalculatePosition();
        }

        // Move function
        public void Move(int x, int y, bool needsUnlinkFromTiles = true) {
            if (needsUnlinkFromTiles) {
                UnlinkFromTiles();
            }

            //Physically move the object
            Location.Offset(x, y);

            //Recalculate the new position
            RecalculatePosition();
        }

        public void UnlinkFromTiles() {
            //Remove from the existing tiles
            //Figure out what tiles I'm touching and mark them unwalkable
            foreach (RectangleX ActualBase in OldActualBases) {
                List<TileInstance> tiles = MapPieceCache.CurrentPiece.Tiles.GetTilesFromWorldRectangle(ActualBase.X, ActualBase.Y, ActualBase.W, ActualBase.H, ActualBase.Rotation);

                foreach (TileInstance tile in tiles) {
                    tile.RemoveObject(this);
                }
            }
        }

        public void RecalculatePosition() {
            ActualX = Location.X;// +ObjectTemplate.Base.Left;
            ActualY = Location.Y + ObjectTemplate.OffsetY;

            ActualBases.Clear();

            foreach (RectangleX r in ObjectTemplate.Blocks) {
                RectangleX ActualBase = new RectangleX(r.X + Location.X, r.Y + Location.Y, r.W, r.H, r.Rotation);
                ActualBases.Add(ActualBase);

                //Figure out what tiles I'm touching and mark them unwalkable
                List<TileInstance> tiles = MapPieceCache.CurrentPiece.Tiles.GetTilesFromWorldRectangle(ActualBase.X, ActualBase.Y, ActualBase.W, ActualBase.H, ActualBase.Rotation);

                foreach (TileInstance tile in tiles) {
                    tile.AddObject(this);
                }
            }

            OldActualBases.Clear();
            OldActualBases.AddRange(ActualBases);
        }

        public int CompareTo(BaseObject other) {
            if (ActualY < other.ActualY) {
                return -1;
            } else if (ActualY > other.ActualY) {
                return 1;
            } else if (ActualX < other.ActualX) {
                return -1;
            } else if (ActualX > other.ActualX) {
                return 1;
            }

            return 0;
        }

        public void Delete() {
            MapPieceCache.CurrentPiece.Objects.Remove(this);

            //Figure out what tiles I'm touching and mark them unwalkable
            foreach (RectangleX ActualBase in ActualBases) {
                List<TileInstance> tiles = MapPieceCache.CurrentPiece.Tiles.GetTilesFromWorldRectangle(ActualBase.X, ActualBase.Y, ActualBase.W, ActualBase.H, ActualBase.Rotation);

                foreach (TileInstance tile in tiles) {
                    tile.RemoveObject(this);
                }
            }
        }
    }
}
