using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using System.Drawing;

namespace ToolCache.Map.Objects {
    public class Template {
        public short ObjectID;
        public string ObjectGroup;

        public AnimatedObject Animation;
        public Rectangle Base;

        public bool isSolid;

        public Template(short typeID, string group, AnimatedObject animation, Rectangle _base, bool isSolid) {
            ObjectID = typeID;
            ObjectGroup = group;

            Animation = animation;
            Base = _base;

            this.isSolid = isSolid;
        }
    }
}
