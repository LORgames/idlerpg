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

                ScriptInfo script = new ScriptInfo("Critter:AI:" + c.Name, ScriptTypes.Critter);
                script.AnimationNames = (c.CritterType == CritterTypes.NonHumanoid) ? (c as CritterBeast).AnimationNames() : null;

                ScriptCrusher.ProcessScript(script, c.AICommands, f);

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

                        f.AddFloat(cb.playbackSpeed);
                        f.AddShort(cb.rectWidth);
                        f.AddShort(cb.rectHeight);
                        f.AddShort(cb.rectOffsetX);
                        f.AddShort(cb.rectOffsetY);

                        f.AddByte((byte)Animations.Count);

                        int i = Animations.Count;

                        while (--i > -1) {
                            CritterAnimationSet cas = Animations[i];
                            EncodeCritterList(cas.Down, AnimationSets, TotalFrames);
                            EncodeCritterList(cas.Up, AnimationSets, TotalFrames);
                            EncodeCritterList(cas.Right, AnimationSets, TotalFrames);
                            EncodeCritterList(cas.Left, AnimationSets, TotalFrames);
                        }

                        //Add all frames to binary
                        if (AnimationSets.Count > 255) {
                            Processor.Errors.Add(new ProcessingError("Critter", c.Name, "Has more than 255 frames. Critters can have a maximum of 255 frames."));
                        }

                        f.AddByte((byte)AnimationSets.Count);

                        //Calculate the size of the frames
                        Size FrameSize = SpriteSheetHelper.GetFrameSizeOf(AnimationSets);

                        int totalPixels = FrameSize.Width * FrameSize.Height * AnimationSets.Count;

                        //Generate the spritesheet
                        int sizeW = 0; int sizeH = 0;
                        CalculateCanvasSize(AnimationSets, FrameSize, ref sizeW, ref sizeH);

                        SpriteSheetHelper.PackAnimationsLinear(AnimationSets, FrameSize, new Size(sizeW, sizeH), "Critter_" + RemappedCritterIDs[c.ID], true);

                        //Add all the frame lengths
                        //TODO: Make this 1 short per animation 4bits per direction. Much better memory usage.
                        foreach (short frameCount in TotalFrames) {
                            f.AddShort(frameCount);
                        }

                        f.AddUnsignedShort((ushort)sizeW);
                        f.AddUnsignedShort((ushort)sizeH);
                        f.AddUnsignedShort((ushort)FrameSize.Width);
                        f.AddUnsignedShort((ushort)FrameSize.Height);
                    } catch (Exception ex) {
                        Processor.Errors.Add(new ProcessingError("Critter", cb.Name, ex.Message));
                    }
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/CritterInfo.bin");
        }

        private static void CalculateCanvasSize(List<String> AnimationSets, Size FrameSize, ref int sizeW, ref int sizeH) {
            int nextSize = 7;

            while (true) {
                sizeW = (int)Math.Pow(2, nextSize);

                int totalColumns = (sizeW / FrameSize.Width);

                if (totalColumns > 0) {
                    int requiredRows = (int)Math.Ceiling(1.0 * AnimationSets.Count / totalColumns);

                    int totalHeight = FrameSize.Height * requiredRows;

                    if (sizeW >= totalHeight) {
                        sizeH = sizeW;
                        if (sizeW / 2 >= totalHeight) sizeH = sizeW / 2;
                        break;
                    }
                }

                nextSize++;
            }
        }

        private static void EncodeCritterList(AnimatedObject anim, List<string> AnimationSets, List<short> totalFrames) {
            totalFrames.Add((short)anim.Frames.Count);
            AnimationSets.AddRange(anim.Frames);
        }
    }
}
