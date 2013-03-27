using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Drawing;
using System.Drawing;

namespace ToolCache.Animation {
    public class AnimatedObject {
        private static Random r = new Random();
        private static double totalTime = 0.0;

        public byte TotalFrames = 0;
        public float PlaybackSpeed = 0.2f;

        public List<String> Frames = new List<string>();

        internal void PackIntoBinaryIO(BinaryIO f) {
            f.AddByte((byte)Frames.Count);
            f.AddFloat(PlaybackSpeed);

            for (int i = 0; i < Frames.Count; i++) {
                f.AddString(Frames[i]);
            }
        }

        // Static Unpacker
        internal static AnimatedObject UnpackFromBinaryIO(BinaryIO f) {
            AnimatedObject animation = new AnimatedObject();

            animation.TotalFrames = f.GetByte();
            animation.PlaybackSpeed = f.GetFloat();

            for (int i = 0; i < animation.TotalFrames; i++) {
                animation.Frames.Add(f.GetString());
            }

            return animation;
        }

        public void Draw(LBuffer buffer, int xPos, int yPos, float scale) {
            int frameID = (int)(totalTime / PlaybackSpeed);
            Image im = ImageCache.RequestImage(Frames[frameID % Frames.Count]);
            buffer.gfx.DrawImage(im, xPos, yPos, im.Width * scale, im.Height * scale);
        }

        public void Draw(LBuffer buffer, float xPos, float yPos, float scale) {
            Draw(buffer, (int)xPos, (int)yPos, scale);
        }

        public static void Update(double dt) {
            totalTime += dt;
        }
    }
}
