using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using ToolCache.General;
using System.Drawing;

namespace ToolCache.Equipment {
    public class EquipmentAnimationSet {
        public string StateName = "Default";

        public AnimatedObject Left_0;
        public AnimatedObject Right_0;
        public AnimatedObject Up_0;
        public AnimatedObject Down_0;

        public AnimatedObject Left_1;
        public AnimatedObject Right_1;
        public AnimatedObject Up_1;
        public AnimatedObject Down_1;

        public EquipmentAnimationSet(bool initialize = true, String s = "Default") {
            if (initialize) {
                StateName = s;

                Left_0 = new AnimatedObject();
                Right_0 = new AnimatedObject();
                Up_0 = new AnimatedObject();
                Down_0 = new AnimatedObject();

                Left_1 = new AnimatedObject();
                Right_1 = new AnimatedObject();
                Up_1 = new AnimatedObject();
                Down_1 = new AnimatedObject();
            }
        }

        public AnimatedObject GetAnimation(Direction d, int layer) {
            switch (d) {
                case Direction.Left:
                    return (layer == 0 ? Left_0 : Left_1);
                case Direction.Right:
                    return (layer == 0 ? Right_0 : Right_1);
                case Direction.Up:
                    return (layer == 0 ? Up_0 : Up_1);
                default:
                    return (layer == 0 ? Down_0 : Down_1);
            }
        }

        internal static EquipmentAnimationSet LoadFromBinaryIO(BinaryIO f) {
            EquipmentAnimationSet eas = new EquipmentAnimationSet(false);

            //Set information
            eas.StateName = f.GetString();

            //Unpack animations
            eas.Left_0 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Right_0 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Up_0 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Down_0 = AnimatedObject.UnpackFromBinaryIO(f);

            eas.Left_1 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Right_1 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Up_1 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Down_1 = AnimatedObject.UnpackFromBinaryIO(f);

            if (eas.TotalFrames() == 0) {
                return null;
            }

            return eas;
        }

        public int TotalFrames() {
            int frames = 0;

            frames += Left_0.Frames.Count;
            frames += Right_0.Frames.Count;
            frames += Up_0.Frames.Count;
            frames += Down_0.Frames.Count;
            frames += Left_1.Frames.Count;
            frames += Right_1.Frames.Count;
            frames += Up_1.Frames.Count;
            frames += Down_1.Frames.Count;

            return frames;
        }

        internal void SaveToBinaryIO(BinaryIO f) {
            //Set information
            f.AddString(StateName);

            //Unpack animations
            Left_0.PackIntoBinaryIO(f);
            Right_0.PackIntoBinaryIO(f);
            Up_0.PackIntoBinaryIO(f);
            Down_0.PackIntoBinaryIO(f);

            Left_1.PackIntoBinaryIO(f);
            Right_1.PackIntoBinaryIO(f);
            Up_1.PackIntoBinaryIO(f);
            Down_1.PackIntoBinaryIO(f);
        }

        public void SwapAnimations(Direction currentDirection) {
            AnimatedObject _t;

            switch (currentDirection) {
                case Direction.Left:
                    _t = Left_0;
                    Left_0 = Left_1;
                    Left_1 = _t;
                    break;
                case Direction.Right:
                    _t = Right_0;
                    Right_0 = Right_1;
                    Right_1 = _t;
                    break;
                case Direction.Up:
                    _t = Up_0;
                    Up_0 = Up_1;
                    Up_1 = _t;
                    break;
                default:
                    _t = Down_0;
                    Down_0 = Down_1;
                    Down_1 = _t;
                    break;
            }
        }

        internal void UpdateSpeed(float AnimationSpeed) {
            Left_1.PlaybackSpeed = AnimationSpeed;
            Left_0.PlaybackSpeed = AnimationSpeed;
            Right_1.PlaybackSpeed = AnimationSpeed;
            Right_0.PlaybackSpeed = AnimationSpeed;
            Up_1.PlaybackSpeed = AnimationSpeed;
            Up_0.PlaybackSpeed = AnimationSpeed;
            Down_1.PlaybackSpeed = AnimationSpeed;
            Down_0.PlaybackSpeed = AnimationSpeed;
        }

        internal EquipmentAnimationSet Clone() {
            EquipmentAnimationSet temp = new EquipmentAnimationSet();

            temp.Down_0 = Down_0.Clone();
            temp.Down_1 = Down_1.Clone();
            temp.Left_0 = Left_0.Clone();
            temp.Left_1 = Left_1.Clone();
            temp.Right_0 = Right_0.Clone();
            temp.Right_1 = Right_1.Clone();
            temp.StateName = StateName;
            temp.Up_0 = Up_0.Clone();
            temp.Up_1 = Up_1.Clone();

            return temp;
        }
    }
}
