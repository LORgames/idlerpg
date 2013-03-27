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

        // Constructor for indexing and sorting
        public BaseObject(short ObjectType, Point initialLocation) {
            this.ObjectType = ObjectType;
            Location = initialLocation;
        }

        // Move function
        public void Move(int x, int y) {
            // Move each point
            Location.Offset(x, y);
        }

        public int CompareTo(BaseObject other) {
            //Compare Y positions for sorting.
            return Location.Y.CompareTo(other.Location.Y);
        }

        public void Delete() {
            //TODO: Implement this
        }
    }
}
