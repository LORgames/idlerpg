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

            TileRectangleC = new Rectangle(x * TileTemplate.PIXELS + ALLOWED_PENETRATION, y * TileTemplate.PIXELS + ALLOWED_PENETRATION, TileTemplate.PIXELS - 2 * ALLOWED_PENETRATION, TileTemplate.PIXELS - 2 * ALLOWED_PENETRATION);
            TileRectangleL = new Rectangle(x * TileTemplate.PIXELS, y * TileTemplate.PIXELS + ALLOWED_PENETRATION, ALLOWED_PENETRATION, TileTemplate.PIXELS - ALLOWED_PENETRATION * 2);
            TileRectangleR = new Rectangle((x + 1) * TileTemplate.PIXELS - ALLOWED_PENETRATION, y * TileTemplate.PIXELS + ALLOWED_PENETRATION, ALLOWED_PENETRATION, TileTemplate.PIXELS - ALLOWED_PENETRATION * 2);
            TileRectangleT = new Rectangle(x * TileTemplate.PIXELS + ALLOWED_PENETRATION, y * TileTemplate.PIXELS, TileTemplate.PIXELS - ALLOWED_PENETRATION*2, ALLOWED_PENETRATION);
            TileRectangleB = new Rectangle(x * TileTemplate.PIXELS + ALLOWED_PENETRATION, (y + 1) * TileTemplate.PIXELS - ALLOWED_PENETRATION, TileTemplate.PIXELS - ALLOWED_PENETRATION * 2, ALLOWED_PENETRATION);
        }

        internal void ChangeTile(short newid) {
            TileID = newid;

            if (TileCache.G(newid) == null) TileID = 0;
        }

        private void UpdateFromTemplate() {
            
        }

        internal void AddObject(BaseObject obj) {
            Objects.Add(obj);
        }

        internal void RemoveObject(BaseObject obj) {
            Objects.Remove(obj);
        }

        public override string ToString() {
            return "Tile: " + TileID;
        }
    }
}
