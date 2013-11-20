using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.Drawing;
using ToolCache.Storage;

namespace ToolCache.Map.Background {
    public interface IBackground {
        void LoadFromBinary(IStorage f);
        void SaveToBinary(IStorage f);

        void Draw(Graphics gfx, Rectangle r);
    }
}
