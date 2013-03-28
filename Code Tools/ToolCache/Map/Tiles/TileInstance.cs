using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Objects;

namespace ToolCache.Map.Tiles {
    public class TileInstance {
        public short TileID;

        public Boolean Walkable;
        public byte AccessDirections = TileTemplate.ACCESS_ALL;

        private List<BaseObject> Objects = new List<BaseObject>();

        internal TileInstance(short id) {
            ChangeTile(id);
        }

        internal void ChangeTile(short newid) {
            TileID = newid;
            RecalculateWalkable();
        }

        private void UpdateFromTemplate() {
            AccessDirections = TileCache.G(TileID).directionalAccess;
            Walkable = TileCache.G(TileID).isWalkable;
        }

        internal void RecalculateWalkable() {
            UpdateFromTemplate();

            if (Walkable) {
                foreach (BaseObject b in Objects) {
                    if (TemplateCache.G(b.ObjectType).isSolid) {
                        Walkable = false;
                        break;
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
    }
}
