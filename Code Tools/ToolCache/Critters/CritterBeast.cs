using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Critters {
    public class CritterBeast : Critter {

        private Dictionary<string, CritterAnimationSet> Animations = new Dictionary<string, CritterAnimationSet>();
        public float playbackSpeed = 0.2f;

        public CritterBeast() {
            CritterType = CritterTypes.NonHumanoid;
        }

        internal static CritterBeast LoadBeastoid(BinaryIO f) {
            CritterBeast c = new CritterBeast();
            
            //Load basic information
            c.BaseLoad(f);

            //Load playback speed
            c.playbackSpeed = f.GetFloat();

            //Now load more complex information (there will probably be a lot of this kind of stuff
            short totalAnimations = f.GetByte();

            while (--totalAnimations > -1) {
                CritterAnimationSet animation = CritterAnimationSet.LoadFromBinaryIO(f);
                c.Animations.Add(animation.State, animation);
            }

            return c;
        }

        internal override void PackIntoBinaryIO(General.BinaryIO f) {
            base.PackIntoBinaryIO(f);

            f.AddFloat(playbackSpeed);
            f.AddByte((byte)Animations.Count);

            foreach (CritterAnimationSet animation in Animations.Values) {
                animation.SaveToBinaryIO(f);
            }
        }

        public CritterAnimationSet GetAnimation(string animation) {
            if (Animations.ContainsKey(animation)) {
                return Animations[animation];
            }

            CritterAnimationSet anim = new CritterAnimationSet(true, animation);
            Animations.Add(animation, anim);
            return anim;
        }

    }
}
