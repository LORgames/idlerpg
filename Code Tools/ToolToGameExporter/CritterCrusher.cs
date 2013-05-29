using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Critters;
using ToolCache.General;
using ToolCache.Scripting;
using ToolCache.Animation;
using System.Drawing;

namespace ToolToGameExporter {
    public class CritterCrusher {
        public static Dictionary<short, short> RemappedCritterIDs = new Dictionary<short, short>();
        public static Dictionary<string, short> NameToRemappedIDs = new Dictionary<string, short>();

        public static void Precrush() {
            RemappedCritterIDs.Clear();
            NameToRemappedIDs.Clear();

            short nextID = 0;

            foreach (Critter c in CritterManager.Critters.Values) {
                RemappedCritterIDs.Add(c.ID, nextID);
                NameToRemappedIDs.Add(c.Name, nextID);
                nextID++;
            }
        }

        public static void Go() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)CritterManager.Critters.Count);

            foreach (Critter c in CritterManager.Critters.Values) {
                f.AddByte((byte)c.CritterType);
                f.AddString(c.Name);

                f.AddInt(c.AIType);

                f.AddInt(c.ExperienceGain);
                f.AddInt(c.Health);

                ScriptCrusher.ProcessScript(new ScriptInfo("Critter:AI:" + c.Name, ScriptTypes.Critter), c.AICommands, f);

                if (c.CritterType == CritterTypes.Humanoid) {
                    CritterHuman ch = (c as CritterHuman);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Shadow]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Legs]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Body]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Face]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Headgear]);
                    f.AddShort(EquipmentCrusher.MappedEquipmentIDs[ch.Weapon]);
                } else {
                    CritterBeast cb = (c as CritterBeast);

                    List<CritterAnimationSet> Animations;

                    List<String> AnimationSets = new List<string>();
                    List<short> TotalFrames = new List<short>();

                    try {
                        Animations = cb.GetValidAnimations();

                        //f.AddByte((byte)Animations.Count);

                        foreach (CritterAnimationSet cas in Animations) {
                            EncodeCritterList(cas.Left, AnimationSets, TotalFrames);
                            EncodeCritterList(cas.Right, AnimationSets, TotalFrames);
                            EncodeCritterList(cas.Up, AnimationSets, TotalFrames);
                            EncodeCritterList(cas.Down, AnimationSets, TotalFrames);
                        }

                        Size FrameSize = SpriteSheetHelper.GetFrameSizeOf(AnimationSets);
                        SpriteSheetHelper.PackAnimationsLinear(AnimationSets, FrameSize, new Size(2048, 1024), "Critter_" + RemappedCritterIDs[c.ID]);

                        
                    } catch (Exception ex) {
                        Processor.Errors.Add(new ProcessingError("Critter", cb.Name, ex.Message));
                    }
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/CritterInfo.bin");
        }

        private static void EncodeCritterList(AnimatedObject anim, List<string> AnimationSets, List<short> totalFrames) {
            totalFrames.Add((short)anim.Frames.Count);
            AnimationSets.AddRange(anim.Frames);
        }
    }
}
