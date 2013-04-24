using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Equipment;
using ToolCache.General;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ToolCache.Animation;

namespace ToolToGameExporter {
    internal class EquipmentCrusher {

        public static EquipmentTypes[] equipmenttypes = { EquipmentTypes.Shadow, EquipmentTypes.Legs, EquipmentTypes.Body, EquipmentTypes.Head, EquipmentTypes.Headgear, EquipmentTypes.Weapon };
        public static Direction[] directions = { Direction.Left, Direction.Right, Direction.Up, Direction.Down };
        public static States[] states = { States.Default, States.Walking, States.Attacking, States.Dancing };
        public static int[] layers = { 0, 1 };

        public static void Go() {
            BinaryIO f = new BinaryIO();
            short nextID = 0;
            
            //Add the sizes to the things
            foreach(EquipmentTypes et in equipmenttypes) {
                f.AddShort((short)EquipmentManager.TypeLists[et].Count);
            }

            foreach(EquipmentTypes et in equipmenttypes) {
                //Now throw the equipment into the file as well..?
                foreach (EquipmentItem ei in EquipmentManager.TypeLists[et]) {
                    f.AddString(ei.Name);
                    f.AddByte((byte)((ei.isAvailableAtStart?1:0) + (ei.OffsetsLocked?2:0)));

                    f.AddShort(ei.OffsetX);
                    f.AddShort(ei.OffsetY);

                    if (!ei.OffsetsLocked) {
                        f.AddShort(ei.OffsetX_1);
                        f.AddShort(ei.OffsetY_1);
                        f.AddShort(ei.OffsetX_2);
                        f.AddShort(ei.OffsetY_2);
                        f.AddShort(ei.OffsetX_3);
                        f.AddShort(ei.OffsetY_3);
                    }

                    int rows, cols;
                    Size size = GetSizeOf(ei, out rows, out cols);
                    f.AddByte((byte)size.Width);
                    f.AddByte((byte)size.Height);

                    if (size.Height > 255 || size.Width > 255) {
                        MessageBox.Show("Size overflow in Equipment crusher. Alert a tool programmer.");
                    }

                    if (rows != 0 && cols != 0) {
                        PackAnimations(ei, nextID, size, rows, cols);
                    } else {
                        Bitmap bmp = new Bitmap(1, 1);
                        bmp.Save(Global.EXPORT_DIRECTORY + "/Equipment_" + ei.Name + ".png");
                        bmp.Dispose();
                    }

                    //build an atlas of the frame counts
                    foreach (States s in states) {
                        int stateData = 0;
                        int stateOffset = 0;

                        foreach (int l in layers) {
                            foreach (Direction d in directions) {
                                if (ei.Animations[s].GetAnimation(d, l).Frames.Count < 16) {
                                    stateData |= ((ei.Animations[s].GetAnimation(d, l).Frames.Count & 0xF) << stateOffset);
                                } else {
                                    MessageBox.Show("Can no longer have 16 frame limit on equipment. this will be bad.");
                                }

                                stateOffset += 4;
                            }
                        }

                        f.AddInt(stateData);
                    }

                    nextID++;
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/EquipmentInfo.bin");
        }

        private static void PackAnimations(EquipmentItem ei, short nextID, Size size, int rows, int cols) {
            int hI = -1;

            Bitmap bmp = new Bitmap(size.Width * cols, size.Height * rows, PixelFormat.Format32bppPArgb);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Image im;

            foreach (States s in states) {
                foreach (int l in layers) {
                    foreach (Direction d in directions) {
                        AnimatedObject anim = ei.Animations[s].GetAnimation(d, l);
                        
                        if (anim.Frames.Count > 0) {
                            hI++;

                            for (int i = 0; i < anim.Frames.Count; i++) {
                                im = Image.FromFile(anim.Frames[i]);

                                int xPos = size.Width * i;
                                int yPos = size.Height * hI;

                                if (size.Width > im.Width) xPos += (size.Width - im.Width) / 2;
                                if (size.Height > im.Height) yPos += (size.Height - im.Height) / 2;

                                gfx.DrawImage(im, new Rectangle(xPos, yPos, im.Width, im.Height));
                                im.Dispose();
                            }
                        }
                    }
                }
            }

            bmp.Save(Global.EXPORT_DIRECTORY + "/Equipment_" + ei.Name + ".png");
            bmp.Dispose();
        }

        public static Size GetSizeOf(EquipmentItem ei, out int rows, out int cols) {
            Size s = Size.Empty;

            rows = 0;
            cols = 0;

            foreach (KeyValuePair<States, EquipmentAnimationSet> kvp in ei.Animations) {
                foreach (Direction d in directions) {
                    foreach (int l in layers) {
                        AnimatedObject anim = kvp.Value.GetAnimation(d, l);

                        if (anim.Frames.Count > 0) {
                            rows++;
                            if (anim.Frames.Count > cols) cols = anim.Frames.Count;
                        }

                        for (int i = 0; i < anim.Frames.Count; i++) {
                            Image im = ImageCache.RequestImage(kvp.Value.GetAnimation(d, l).Frames[i]);
                            if (s.Width < im.Width) s.Width = im.Width;
                            if (s.Height < im.Height) s.Height = im.Height;
                        }
                    }
                }
            }

            return s;
        }
    }
}
