using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using System.Drawing;

namespace ToolCache.Map.Objects {
    public class ObjectTemplate {
        public short TypeID;
        public AnimatedObject Animation;
        public Rectangle Base;

        public ObjectTemplate(short typeID, AnimatedObject animation, Rectangle _base) {
            TypeID = typeID;
            Animation = animation;
            Base = _base;
        }
    }
}
