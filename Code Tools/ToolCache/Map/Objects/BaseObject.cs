using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.Drawing;
using ToolCache.Animation;
using ToolCache.Map.Tiles;

namespace ToolCache.Map.Objects {
    public class BaseObject : IComparable<BaseObject> {

        //Circular references
        public bool selected = false;
        public Point Location;
        public short ObjectType;

        public Template ObjectTemplate;

        public int ActualY;
        public int ActualX;
        public List<Rectangle> ActualBases = new List<Rectangle>();

        // Constructor for indexing and sorting
        public BaseObject(short ObjectType, Point initialLocation) {
            this.ObjectType = ObjectType;
            Location = initialLocation;

            ObjectTemplate = TemplateCache.G(ObjectType);

            RecalculatePosition();
        }

        // Move function
        public void Move(int x, int y) {
            //Remove from the existing tiles
            //Figure out what tiles I'm touching and mark them unwalkable
            foreach(Rectangle ActualBase in ActualBases) {
                List<TileInstance> tiles = MapPieceCache.CurrentPiece.Tiles.GetTilesFromWorldRectangle(ActualBase.X, ActualBase.Y, ActualBase.Width, ActualBase.Height);

                foreach (TileInstance tile in tiles) {
                    tile.RemoveObject(this);
                }
            }

            //Physically move the object
            Location.Offset(x, y);

            //Recalculate the new position
            RecalculatePosition();
        }

        private void RecalculatePosition() {
            ActualX = Location.X;// +ObjectTemplate.Base.Left;
            ActualY = Location.Y + ObjectTemplate.OffsetY;

            ActualBases.Clear();

            foreach (Rectangle r in ObjectTemplate.Blocks) {
                Rectangle ActualBase = new Rectangle(r.X + Location.X, r.Y + Location.Y, r.Width, r.Height);
                
                //Figure out what tiles I'm touching and mark them unwalkable
                List<TileInstance> tiles = MapPieceCache.CurrentPiece.Tiles.GetTilesFromWorldRectangle(ActualBase.X, ActualBase.Y, ActualBase.Width, ActualBase.Height);

                foreach (TileInstance tile in tiles) {
                    tile.AddObject(this);
                }
            }
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
            foreach (Rectangle ActualBase in ActualBases) {
                List<TileInstance> tiles = MapPieceCache.CurrentPiece.Tiles.GetTilesFromWorldRectangle(ActualBase.X, ActualBase.Y, ActualBase.Width, ActualBase.Height);

                foreach (TileInstance tile in tiles) {
                    tile.RemoveObject(this);
                }
            }
        }
    }
}
