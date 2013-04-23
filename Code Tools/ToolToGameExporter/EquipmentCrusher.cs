using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Equipment;
using ToolCache.General;
using System.Drawing;
using System.Windows.Forms;

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

                    if (ei.OffsetsLocked) {
                        f.AddShort(ei.OffsetX_1);
                        f.AddShort(ei.OffsetY_1);
                        f.AddShort(ei.OffsetX_2);
                        f.AddShort(ei.OffsetY_2);
                        f.AddShort(ei.OffsetX_3);
                        f.AddShort(ei.OffsetY_3);
                    }

                    Size size = GetSizeOf(ei);
                    f.AddByte((byte)size.Width);
                    f.AddByte((byte)size.Height);

                    if (size.Height > 255 || size.Width > 255) {
                        MessageBox.Show("Size overflow in Equipment crusher. Alert a tool programmer.");
                    }

                    PackAnimations(ei, nextID, size);

                    //First build an atlas of what animations exist
                    foreach (States s in states) {
                        byte stateSets = 0;
                        nextID = 0;

                        foreach (int l in layers) {
                            foreach (Direction d in directions) {
                                nextID++;
                                stateSets &= (byte)(ei.Animations[s].GetAnimation(d, l).Frames.Count > 0 ? (0x1 << nextID) : 0);
                            }
                        }

                        f.AddByte(stateSets);
                    }

                    //Now build an atlas of the frame counts
                    foreach (States s in states) {
                        foreach (int l in layers) {
                            foreach (Direction d in directions) {
                                if (ei.Animations[s].GetAnimation(d, l).Frames.Count > 0) {
                                    f.AddByte((byte)ei.Animations[s].GetAnimation(d, l).Frames.Count);
                                }
                            }
                        }
                    }

                    nextID++;
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/Equipment_Info.bin");
        }

        private static void PackAnimations(EquipmentItem ei, short nextID, Size s) {
            Image im = Image.FromFile(t.Animation.Frames[0]);
            Bitmap bmp = new Bitmap(im.Width * t.Animation.Frames.Count, im.Height, PixelFormat.Format32bppPArgb);
            Graphics gfx = Graphics.FromImage(bmp);

            im.Dispose();

            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            for (int i = 0; i < t.Animation.Frames.Count; i++) {
                im = Image.FromFile(t.Animation.Frames[i]);
                gfx.DrawImage(im, new Rectangle(im.Width * i, 0, im.Width, im.Height));
                im.Dispose();
            }

            bmp.Save(Global.EXPORT_DIRECTORY + "/Equipment_" + nextID + ".png");
            bmp.Dispose();
        }

        public static Size GetSizeOf(EquipmentItem ei) {
            Size s = Size.Empty;

            foreach (KeyValuePair<States, EquipmentAnimationSet> kvp in ei.Animations) {
                foreach (Direction d in directions) {
                    foreach (int l in layers) {
                        for (int i = 0; i < kvp.Value.GetAnimation(d, l).Frames.Count; i++) {
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
