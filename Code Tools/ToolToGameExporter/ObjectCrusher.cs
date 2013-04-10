using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Objects;
using ToolCache.General;

namespace ToolToGameExporter {
    public class ObjectCrusher {

        public static Dictionary<short, short> RealignedItemIndexes = new Dictionary<short, short>();

        public static void Go() {
            short highestIndex = 0;

            BinaryIO f = new BinaryIO();
            f.AddShort((short)TemplateCache.ObjectTypes.Count);

            foreach (Template t in TemplateCache.ObjectTypes.Values) {
                RealignedItemIndexes.Add(t.ObjectID, highestIndex);



                highestIndex++;
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/Objects.bin");
        }

    }
}
