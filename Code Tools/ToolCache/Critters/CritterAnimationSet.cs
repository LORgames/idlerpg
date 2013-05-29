using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using ToolCache.General;
using System.Drawing;
using ToolCache.Equipment;

namespace ToolCache.Critters {
    public class CritterAnimationSet {
        public string State = "Default";

        public AnimatedObject Left;
        public AnimatedObject Right;
        public AnimatedObject Up;
        public AnimatedObject Down;

        public CritterAnimationSet(bool initialize = true, string s = "Default") {
            if (initialize) {
                State = s;

                Left = new AnimatedObject();
                Right = new AnimatedObject();
                Up = new AnimatedObject();
                Down = new AnimatedObject();
            }
        }

        public AnimatedObject GetDirection(Direction d) {
            switch (d) {
                case Direction.Left:
                    return Left;
                case Direction.Right:
                    return Right;
                case Direction.Up:
                    return Up;
                default:
                    return Down;
            }
        }

        internal static CritterAnimationSet LoadFromBinaryIO(BinaryIO f) {
            CritterAnimationSet eas = new CritterAnimationSet(false);

            //Set information
            eas.State = f.GetString();

            //Unpack animations
            eas.Left = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Right = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Up = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Down = AnimatedObject.UnpackFromBinaryIO(f);

            return eas;
        }

        internal void SaveToBinaryIO(BinaryIO f) {
            //Set information
            f.AddString(State);

            //Unpack animations
            Left.PackIntoBinaryIO(f);
            Right.PackIntoBinaryIO(f);
            Up.PackIntoBinaryIO(f);
            Down.PackIntoBinaryIO(f);
        }

        internal void UpdateSpeed(float AnimationSpeed) {
            Left.PlaybackSpeed = AnimationSpeed;
            Right.PlaybackSpeed = AnimationSpeed;
            Up.PlaybackSpeed = AnimationSpeed;
            Down.PlaybackSpeed = AnimationSpeed;
        }

        public int TotalFrames() {
            int i = 0;

            i += Left.Frames.Count;
            i += Right.Frames.Count;
            i += Up.Frames.Count;
            i += Down.Frames.Count;

            return i;
        }
    }
}
