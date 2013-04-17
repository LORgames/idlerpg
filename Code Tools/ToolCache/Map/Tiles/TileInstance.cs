using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Objects;
using System.Drawing;

namespace ToolCache.Map.Tiles {
    public class TileInstance {
        public const int ALLOWED_PENETRATION = 10;

        public short TileID;

        public Rectangle TileRectangleC;
        public Rectangle TileRectangleL;
        public Rectangle TileRectangleR;
        public Rectangle TileRectangleT;
        public Rectangle TileRectangleB;

        public Boolean Walkable;
        public byte AccessDirections = TileTemplate.ACCESS_ALL;

        //public TileInstance Left;
		//public TileInstance Right;
		//public TileInstance Up;
		//public TileInstance Down;

        private List<BaseObject> Objects = new List<BaseObject>();

        public List<BaseObject> EXOB {
            get { return Objects; }
        }

        internal TileInstance(short id, int x, int y) {
            ChangeTile(id);

            TileRectangleC = new Rectangle(x * TileTemplate.PIXELS_X + ALLOWED_PENETRATION, y * TileTemplate.PIXELS_Y + ALLOWED_PENETRATION, TileTemplate.PIXELS_X - 2 * ALLOWED_PENETRATION, TileTemplate.PIXELS_Y - 2 * ALLOWED_PENETRATION);
            TileRectangleL = new Rectangle(x * TileTemplate.PIXELS_X, y * TileTemplate.PIXELS_Y + ALLOWED_PENETRATION, ALLOWED_PENETRATION, TileTemplate.PIXELS_Y - ALLOWED_PENETRATION * 2);
            TileRectangleR = new Rectangle((x + 1) * TileTemplate.PIXELS_X - ALLOWED_PENETRATION, y * TileTemplate.PIXELS_Y + ALLOWED_PENETRATION, ALLOWED_PENETRATION, TileTemplate.PIXELS_Y - ALLOWED_PENETRATION * 2);
            TileRectangleT = new Rectangle(x * TileTemplate.PIXELS_X + ALLOWED_PENETRATION, y * TileTemplate.PIXELS_Y, TileTemplate.PIXELS_X - ALLOWED_PENETRATION*2, ALLOWED_PENETRATION);
            TileRectangleB = new Rectangle(x * TileTemplate.PIXELS_X + ALLOWED_PENETRATION, (y + 1) * TileTemplate.PIXELS_Y - ALLOWED_PENETRATION, TileTemplate.PIXELS_X - ALLOWED_PENETRATION * 2, ALLOWED_PENETRATION);
        }

        internal void ChangeTile(short newid) {
            TileID = newid;

            if (TileCache.G(newid) == null) TileID = 0;

            RecalculateWalkable();
        }

        private void UpdateFromTemplate() {
            try {
                AccessDirections = TileCache.G(TileID).directionalAccess;
                Walkable = TileCache.G(TileID).isWalkable;
            } catch {
                
            }
        }

        internal void RecalculateWalkable() {
            UpdateFromTemplate();

            if (Walkable) {
                foreach (BaseObject b in Objects) {
                    if (TemplateCache.G(b.ObjectType).isSolid) {
                        if(b.ActualBase.IntersectsWith(TileRectangleC)) { // Check the core first
                            Walkable = false;
                            break;
                        } else if ((AccessDirections & TileTemplate.ACCESS_LEFT) > 0 && b.ActualBase.IntersectsWith(TileRectangleL)) { //Start removing sides
                            AccessDirections -= TileTemplate.ACCESS_LEFT;
                        } else if ((AccessDirections & TileTemplate.ACCESS_RIGHT) > 0 && b.ActualBase.IntersectsWith(TileRectangleR)) { //Start removing sides
                            AccessDirections -= TileTemplate.ACCESS_RIGHT;
                        } else if ((AccessDirections & TileTemplate.ACCESS_TOP) > 0 && b.ActualBase.IntersectsWith(TileRectangleT)) { //Start removing sides
                            AccessDirections -= TileTemplate.ACCESS_TOP;
                        } else if ((AccessDirections & TileTemplate.ACCESS_BOTTOM) > 0 && b.ActualBase.IntersectsWith(TileRectangleB)) { //Start removing sides
                            AccessDirections -= TileTemplate.ACCESS_BOTTOM;
                        }

                        if (AccessDirections == TileTemplate.ACCESS_NONE) {
                            Walkable = false;
                            break;
                        }
                    }
                }
            }
        }

        internal void AddObject(BaseObject obj) {
            Objects.Add(obj);

            if (Walkable) {
                RecalculateWalkable();
            }
        }

        internal void RemoveObject(BaseObject obj) {
            Objects.Remove(obj);

            if (!Walkable) {
                RecalculateWalkable();
            }
        }

        public override string ToString() {
            return "Tile: " + TileID;
        }
    }
}
