using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Effects;
using ToolCache.General;
using ToolCache.Animation;
using ToolCache.Scripting;
using System.Drawing;
using ToolCache.Scripting.Types;

namespace ToolToGameExporter {
    internal class EffectCrusher {
        public static Dictionary<string, short> RemappedEffectNames = new Dictionary<string, short>();

        public static void Precrush() {
            RemappedEffectNames.Clear();
            short nextID = 0;

            foreach (Effect e in EffectManager.Effects.Values) {
                if (e.Animations.Count == 0) continue;

                RemappedEffectNames.Add(e.Name, nextID);
                nextID++;
            }
        }

        public static void Go() {
            BinaryIO f = new BinaryIO();
            f.AddShort((short)RemappedEffectNames.Count);

            foreach (Effect e in EffectManager.Effects.Values) {
                if (e.Animations.Count == 0) continue;

                f.AddString(e.Name);

                f.AddShort(e.MovementSpeed);
                f.AddShort((short)Math.Round(e.Life * 20));

                f.AddByte((byte)(e.IsSolid?1:0));

                if(e.Animations.Count > 255) Processor.Errors.Add(new ProcessingError("Effect", e.Name, "Cannot have more than 255 animation sets."));
                f.AddByte((byte)e.Animations.Count);

                //Animations as list of frame range
                List<string> Animations = new List<string>();
                List<string> AnimationFrames = new List<string>();

                foreach (KeyValuePair<String, AnimatedObject> kvp in e.Animations) {
                    Animations.Add(kvp.Key);

                    if(kvp.Value.Frames.Count > 255) Processor.Errors.Add(new ProcessingError("Effect", e.Name + ":" + kvp.Key, "Individual animations cannot have more than 255 frames!"));
                    f.AddByte((byte)kvp.Value.Frames.Count);
                    AnimationFrames.AddRange(kvp.Value.Frames);
                }

                f.AddShort((short)e.Area.X);
                f.AddShort((short)e.Area.Y);
                f.AddShort((short)e.Area.Width);
                f.AddShort((short)e.Area.Height);

                Size s = SpriteSheetHelper.GetFrameSizeOf(AnimationFrames);
                Size t = SpriteSheetHelper.GetTextureSizeFor(s, AnimationFrames.Count);

                f.AddShort((short)s.Width);
                f.AddShort((short)s.Height);
                f.AddShort((short)t.Width);
                f.AddShort((short)t.Height);

                SpriteSheetHelper.PackAnimationsLinear(AnimationFrames, s, t, "Effect_" + RemappedEffectNames[e.Name], false);

                ScriptInfo Info = new ScriptInfo("Effect."+e.Name, ScriptTypes.Effect);
                Info.AnimationNames.AddRange(Animations);
                ScriptCrusher.ProcessScript(Info, e.Script, f);
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/EffectInfo.bin");
        }
    }
}
