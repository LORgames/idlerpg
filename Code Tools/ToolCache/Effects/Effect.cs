using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using System.Drawing;
using ToolCache.General;

namespace ToolCache.Effects {
    public class Effect {
        public string OldName = "";
        public string OldGroup = "";

        public string Name = "";
        public string Group = "";

        public short MovementSpeed = 0;
        public float Life = 0;

        public DictionaryEx<string, AnimatedObject> Animations = new DictionaryEx<string, AnimatedObject>();
        public string Script = "";

        public Rectangle Area = new Rectangle();

        internal static Effect ReadFromBinaryIO(BinaryIO f) {
            Effect e = new Effect();

            e.Name = f.GetString();
            e.Group = f.GetString();

            e.Script = f.GetString();

            e.MovementSpeed = f.GetShort();
            e.Life = f.GetFloat();

            e.Area = new Rectangle();
            e.Area.X = f.GetShort();
            e.Area.Y = f.GetShort();
            e.Area.Width = f.GetShort();
            e.Area.Height = f.GetShort();

            short totalAnimations = f.GetShort();

            while (--totalAnimations > -1) {
                string animName = f.GetString();
                AnimatedObject anim = AnimatedObject.UnpackFromBinaryIO(f);
                e.Animations.Add(animName, anim);
            }

            e.CleanUpAnimations();

            return e;
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            CleanUpAnimations();

            f.AddString(Name);
            f.AddString(Group);

            f.AddString(Script);

            f.AddShort(MovementSpeed);
            f.AddFloat(Life);

            f.AddShort((short)Area.X);
            f.AddShort((short)Area.Y);
            f.AddShort((short)Area.Width);
            f.AddShort((short)Area.Height);

            f.AddShort((short)Animations.Count);

            foreach (KeyValuePair<String, AnimatedObject> kvp in Animations) {
                f.AddString(kvp.Key);
                kvp.Value.PackIntoBinaryIO(f);
            }
        }

        private void CleanUpAnimations() {
            List<String> BadAnimations = new List<string>();

            foreach (KeyValuePair<String, AnimatedObject> kvp in Animations) {
                if (kvp.Value.Frames.Count == 0) {
                    BadAnimations.Add(kvp.Key);
                }
            }

            foreach (String s in BadAnimations) {
                Animations.Remove(s);
            }
        }

        public AnimatedObject GetAnimation(string key) {
            if (Animations.ContainsKey(key)) {
                return Animations[key];
            }

            AnimatedObject ao = new AnimatedObject();
            Animations.Add(key, ao);

            return ao;
        }
    }
}
