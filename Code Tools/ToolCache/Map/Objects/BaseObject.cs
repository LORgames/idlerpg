using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Box2CS;
using System.Drawing;
using ToolCache.Drawing;
using ToolCache.Animation;

namespace ToolCache.Map.Objects {
    public class BaseObject : IComparable<BaseObject> {

        //Circular references
        public bool selected = false;
        public Point Location;
        public short ObjectType;

        public Template ObjectTemplate;
        public int ActualY;
        public int ActualX;

        // Constructor for indexing and sorting
        public BaseObject(short ObjectType, Point initialLocation) {
            this.ObjectType = ObjectType;
            Location = initialLocation;

            ObjectTemplate = TemplateCache.G(ObjectType);

            ActualX = Location.X + ObjectTemplate.Base.Left;
            ActualY = Location.Y + ObjectTemplate.Base.Top;

            //Figure out what tiles I'm touching and mark them unwalkable

        }

        // Move function
        public void Move(int x, int y) {
            // Move each point
            Location.Offset(x, y);
        }

        public int CompareTo(BaseObject other) {
            if (ActualY < other.ActualY) {
                return -1;
            } else if (ActualY > other.ActualY) {
                return 1;
            } else if (ActualX < other.ActualX) {
                return -1;
            }

            return 1;
        }

        public void Delete() {
            //TODO: Implement this
        }
    }
}
