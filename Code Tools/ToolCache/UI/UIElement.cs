using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.UI {
    public enum UIAnchorPoint {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    public class UIElement {
        public List<UILayer> Layers = new List<UILayer>();
        public short OffsetX;
        public short OffsetY;
    }
}
