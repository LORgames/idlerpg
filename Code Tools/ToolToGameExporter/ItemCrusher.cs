using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace ToolToGameExporter {
    internal class ItemCrusher {

        public static void Go() {
            List<string> GoodImages = new List<string>();

            foreach (String s in Directory.GetFiles("Icons")) {
                if (Path.GetExtension(s) == ".png") {
                    Image im = Image.FromFile(s);
                    if (im.Size.Width == 48 && im.Size.Height == 48) {
                        GoodImages.Add(s);
                    }
                    im.Dispose();
                }
            }

            SpriteSheetHelper.PackAnimationsLinear(GoodImages, new Size(48, 48), new Size(1024, 1024), "Items", false);
        }

    }
}
