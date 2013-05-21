using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.Drawing;

namespace ToolCache.Map.Background {
    public interface IBackground {
        void LoadFromBinary(BinaryIO f);
        void SaveToBinary(BinaryIO f);

        void Draw(Graphics gfx, Rectangle r);
    }
}
