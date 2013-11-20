using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Objects;
using ToolCache.General;
using System.Drawing;
using System.Drawing.Imaging;
using ToolCache.Scripting;
using ToolCache.Animation;
using ToolCache.Scripting.Types;
using ToolCache.Storage;

namespace ToolToGameExporter {
    internal class MapObjectCrusher {

        public static Dictionary<short, short> RealignedItemIndexes = new Dictionary<short, short>();
        public static Dictionary<String, short> RemappedItemNameToID = new Dictionary<string, short>();

        public static void Precrush() {
            RealignedItemIndexes.Clear();
            RemappedItemNameToID.Clear();

            ExportCrushers.RemappedObjectIDs = RemappedItemNameToID;

            short highestIndex = 0;

            foreach (MapObject t in MapObjectCache.ObjectTypes.Values) {
                if (!RemappedItemNameToID.ContainsKey(t.ObjectName)) {
                    RemappedItemNameToID.Add(t.ObjectName, highestIndex);
                } else {
                    RemappedItemNameToID[t.ObjectName] = highestIndex;
                }
                RealignedItemIndexes.Add(t.ObjectID, highestIndex);

                highestIndex++;
            }
        }

        public static void Go() {
            BinaryIO f = new BinaryIO();
            f.AddShort((short)MapObjectCache.ObjectTypes.Count);

            int i = 0;

            foreach (MapObject t in MapObjectCache.ObjectTypes.Values) {
                f.AddString(t.ObjectName);

                //Some animation things :)
                if (t.Animations.Count > 255) Processor.Errors.Add(new ProcessingError("Object", t.ObjectName, "Cannot have more than 255 animation sets."));
                f.AddByte((byte)t.Animations.Count);

                //Animations as list of frame range
                List<string> Animations = new List<string>();
                List<string> AnimationFrames = new List<string>();

                foreach (KeyValuePair<String, AnimatedObject> kvp in t.Animations) {
                    if (kvp.Value.Frames.Count > 255) Processor.Errors.Add(new ProcessingError("Object", t.ObjectName + ":" + kvp.Key, "Individual animations cannot have more than 255 frames!"));

                    Animations.Add(kvp.Key);
                    AnimationFrames.AddRange(kvp.Value.Frames);

                    f.AddByte((byte)kvp.Value.Frames.Count);
                    f.AddFloat(kvp.Value.PlaybackSpeed);
                }

                Size sizeSprite = SpriteSheetHelper.GetFrameSizeOf(AnimationFrames);
                Size sizeTex = SpriteSheetHelper.GetTextureSizeFor(sizeSprite, AnimationFrames.Count);

                f.AddShort((short)sizeSprite.Width);
                f.AddShort((short)sizeSprite.Height);
                f.AddShort((short)(sizeTex.Width/sizeSprite.Width));

                SpriteSheetHelper.PackAnimationsLinear(AnimationFrames, sizeSprite, sizeTex, "/Object_" + RealignedItemIndexes[t.ObjectID], false);
                
                f.AddShort((short)t.OffsetY);

                f.AddByte((byte)t.Blocks.Count);
                i = t.Blocks.Count;

                while (--i > -1) {
                    f.AddShort((short)(t.Blocks[i].X));
                    f.AddShort((short)(t.Blocks[i].Y));
                    f.AddShort((short)(t.Blocks[i].Width));
                    f.AddShort((short)(t.Blocks[i].Height));
                }

                f.AddByte(t.GetBooleanData());

                ScriptInfo info = new ScriptInfo(t.ObjectName, ScriptTypes.Object);
                info.AnimationNames.AddRange(t.Animations.Keys);
                ScriptCrusher.ProcessScript(info, t.Script, f);
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/ObjectInfo.bin");
        }

    }
}
