﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Critters {
    public class CritterBeast : Critter {

        private Dictionary<string, CritterAnimationSet> Animations = new Dictionary<string, CritterAnimationSet>();
        public float playbackSpeed = 0.2f;

        public short rectWidth = 0;
        public short rectHeight = 0;

        public CritterBeast() {
            CritterType = CritterTypes.NonHumanoid;
        }

        internal static CritterBeast LoadBeastoid(BinaryIO f) {
            CritterBeast c = new CritterBeast();
            
            //Load basic information
            c.BaseLoad(f);

            //Load playback speed
            c.playbackSpeed = f.GetFloat();

            c.rectWidth = f.GetShort();
            c.rectHeight = f.GetShort();

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

            f.AddShort(rectWidth);
            f.AddShort(rectHeight);

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

        public List<string> AnimationNames() {
            return Animations.Keys.ToList<String>();
        }

        public List<CritterAnimationSet> GetValidAnimations() {
            List<CritterAnimationSet> usableSets = new List<CritterAnimationSet>();

            foreach (CritterAnimationSet anim in Animations.Values) {
                if (anim.TotalFrames() > 0) {
                    usableSets.Add(anim);
                }
            }

            if(usableSets.Count == 0) return usableSets;

            if (usableSets[0].State != "Default") {
                bool switched = false;
                CritterAnimationSet cas_0 = usableSets[0];

                for (int i = 1; i < usableSets.Count; i++) {
                    if (usableSets[i].State == "Default") {
                        switched = true;

                        usableSets[0] = usableSets[i];
                        usableSets[i] = cas_0;

                        break;
                    }
                }

                if (!switched) {
                    throw new Exception("No default animation!");
                }
            }

            return usableSets;
        }

        public override Critter Clone() {
            CritterBeast temp = new CritterBeast();

            this.CloneX(temp);

            foreach (KeyValuePair<string, CritterAnimationSet> pair in this.Animations) {
                temp.Animations.Add(pair.Key, pair.Value.Clone());
            }

            temp.playbackSpeed = this.playbackSpeed;
            temp.rectWidth = this.rectWidth;
            temp.rectHeight = this.rectHeight;

            return temp;
        }
    }
}
