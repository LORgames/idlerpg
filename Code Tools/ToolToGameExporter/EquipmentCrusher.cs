using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Equipment;
using ToolCache.General;
using System.Drawing;

namespace ToolToGameExporter {
    internal class EquipmentCrusher {

        public static EquipmentTypes[] states = { EquipmentTypes.Shadow, EquipmentTypes.Legs, EquipmentTypes.Body, EquipmentTypes.Head, EquipmentTypes.Headgear, EquipmentTypes.Weapon };

        public static void Go() {
            BinaryIO f = new BinaryIO();
            
            //Add the sizes to the things
            foreach(EquipmentTypes et in states) {
                f.AddShort((short)EquipmentManager.TypeLists[et].Count);
            }

            foreach(EquipmentTypes et in states) {
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

                    byte defaultsets = 0;
                    byte walkingsets = 0;
                    byte attackingsets = 0;
                    byte dancingsets = 0;

                    defaultsets &= (byte)(ei.Animations[States.Default].Left_0.Frames.Count > 0 ? 1 : 0);
                    defaultsets &= (byte)(ei.Animations[States.Default].Right_0.Frames.Count > 0 ? 2 : 0);
                    defaultsets &= (byte)(ei.Animations[States.Default].Up_0.Frames.Count > 0 ? 4 : 0);
                    defaultsets &= (byte)(ei.Animations[States.Default].Down_0.Frames.Count > 0 ? 8 : 0);
                    defaultsets &= (byte)(ei.Animations[States.Default].Left_1.Frames.Count > 0 ? 16 : 0);
                    defaultsets &= (byte)(ei.Animations[States.Default].Right_1.Frames.Count > 0 ? 32 : 0);
                    defaultsets &= (byte)(ei.Animations[States.Default].Up_1.Frames.Count > 0 ? 64 : 0);
                    defaultsets &= (byte)(ei.Animations[States.Default].Down_1.Frames.Count > 0 ? 128 : 0);

                    walkingsets &= (byte)(ei.Animations[States.Walking].Left_0.Frames.Count > 0 ? 1 : 0);
                    walkingsets &= (byte)(ei.Animations[States.Walking].Right_0.Frames.Count > 0 ? 2 : 0);
                    walkingsets &= (byte)(ei.Animations[States.Walking].Up_0.Frames.Count > 0 ? 4 : 0);
                    walkingsets &= (byte)(ei.Animations[States.Walking].Down_0.Frames.Count > 0 ? 8 : 0);
                    walkingsets &= (byte)(ei.Animations[States.Walking].Left_1.Frames.Count > 0 ? 16 : 0);
                    walkingsets &= (byte)(ei.Animations[States.Walking].Right_1.Frames.Count > 0 ? 32 : 0);
                    walkingsets &= (byte)(ei.Animations[States.Walking].Up_1.Frames.Count > 0 ? 64 : 0);
                    walkingsets &= (byte)(ei.Animations[States.Walking].Down_1.Frames.Count > 0 ? 128 : 0);

                    attackingsets &= (byte)(ei.Animations[States.Attacking].Left_0.Frames.Count > 0 ? 1 : 0);
                    attackingsets &= (byte)(ei.Animations[States.Attacking].Right_0.Frames.Count > 0 ? 2 : 0);
                    attackingsets &= (byte)(ei.Animations[States.Attacking].Up_0.Frames.Count > 0 ? 4 : 0);
                    attackingsets &= (byte)(ei.Animations[States.Attacking].Down_0.Frames.Count > 0 ? 8 : 0);
                    attackingsets &= (byte)(ei.Animations[States.Attacking].Left_1.Frames.Count > 0 ? 16 : 0);
                    attackingsets &= (byte)(ei.Animations[States.Attacking].Right_1.Frames.Count > 0 ? 32 : 0);
                    attackingsets &= (byte)(ei.Animations[States.Attacking].Up_1.Frames.Count > 0 ? 64 : 0);
                    attackingsets &= (byte)(ei.Animations[States.Attacking].Down_1.Frames.Count > 0 ? 128 : 0);

                    dancingsets &= (byte)(ei.Animations[States.Dancing].Left_0.Frames.Count > 0 ? 1 : 0);
                    dancingsets &= (byte)(ei.Animations[States.Dancing].Right_0.Frames.Count > 0 ? 2 : 0);
                    dancingsets &= (byte)(ei.Animations[States.Dancing].Up_0.Frames.Count > 0 ? 4 : 0);
                    dancingsets &= (byte)(ei.Animations[States.Dancing].Down_0.Frames.Count > 0 ? 8 : 0);
                    dancingsets &= (byte)(ei.Animations[States.Dancing].Left_1.Frames.Count > 0 ? 16 : 0);
                    dancingsets &= (byte)(ei.Animations[States.Dancing].Right_1.Frames.Count > 0 ? 32 : 0);
                    dancingsets &= (byte)(ei.Animations[States.Dancing].Up_1.Frames.Count > 0 ? 64 : 0);
                    dancingsets &= (byte)(ei.Animations[States.Dancing].Down_1.Frames.Count > 0 ? 128 : 0);

                    f.AddByte(defaultsets);
                    f.AddByte(walkingsets);
                    f.AddByte(attackingsets);
                    f.AddByte(dancingsets);

                    if (defaultsets > 0) {
                        f.AddByte((byte)ei.Animations[States.Default].Left_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Default].Right_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Default].Up_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Default].Down_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Default].Left_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Default].Right_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Default].Up_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Default].Down_1.Frames.Count);
                    }

                    if (walkingsets > 0) {
                        f.AddByte((byte)ei.Animations[States.Walking].Left_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Walking].Right_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Walking].Up_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Walking].Down_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Walking].Left_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Walking].Right_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Walking].Up_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Walking].Down_1.Frames.Count);
                    }

                    if (attackingsets > 0) {
                        f.AddByte((byte)ei.Animations[States.Attacking].Left_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Attacking].Right_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Attacking].Up_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Attacking].Down_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Attacking].Left_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Attacking].Right_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Attacking].Up_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Attacking].Down_1.Frames.Count);
                    }

                    if (dancingsets > 0) {
                        f.AddByte((byte)ei.Animations[States.Dancing].Left_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Dancing].Right_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Dancing].Up_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Dancing].Down_0.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Dancing].Left_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Dancing].Right_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Dancing].Up_1.Frames.Count);
                        f.AddByte((byte)ei.Animations[States.Dancing].Down_1.Frames.Count);
                    }
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/Equipment_Info.bin");
        }

        public Size GetSizeOf(EquipmentItem ei) {
            return Size.Empty;
        }
    }
}
