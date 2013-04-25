using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using System.Drawing;

namespace ToolCache.Map.Objects {
    public class Template {
        public short ObjectID;
        public string ObjectName;
        public string ObjectGroup;

        public AnimatedObject Animation;
        public List<Rectangle> Blocks;

        public int OffsetY = 0;

        public bool isSolid;

        public Template(short typeID, string name, string group, AnimatedObject animation, int OffsetY, List<Rectangle> _blocks, bool isSolid) {
            ObjectID = typeID;

            ObjectName = name;
            ObjectGroup = group;

            Animation = animation;
            Blocks = _blocks;

            this.OffsetY = OffsetY;
            this.isSolid = isSolid;
        }
    }
}
