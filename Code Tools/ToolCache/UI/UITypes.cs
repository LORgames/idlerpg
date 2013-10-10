using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.UI {
    public enum UILayerType {
        Static,
        Tile,
        Stretch,
        StretchToValueX,
        StretchToValueY,
        StretchToValueXNeg,
        StretchToValueYNeg,
        PanX,
        PanY,
        PanXNeg,
        PanYNeg,
        Radial
    }

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
}
