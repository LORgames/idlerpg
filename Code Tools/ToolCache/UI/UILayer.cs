using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.UI {
    public enum UILayerType {
        Overlay,
        Stretch,
        StretchToValue
    }

    public class UILayer {
        public UILayerType MyType = UILayerType.Overlay;
        public short Width;
        public short Height;

        public UILayer() {

        }
    }
}
