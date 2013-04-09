using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Drawing;
using System.Drawing;
using System.Drawing.Imaging;

namespace ToolCache.Animation {
    public class AnimatedObject {
        private static Random r = new Random();
        private static double totalTime = 0.0;

        public byte TotalFrames = 0;
        public float PlaybackSpeed = 0.2f;

        public List<String> Frames = new List<string>();

        public Point p = new Point(-1, -1); //Center point

        public Point Center {
            get {
                if (Frames.Count == 0)
                    return p;

                if(p.X < 0 || p.Y < 0) {
                    using(Image i = Image.FromFile(Frames[0])) {
                        p.X = i.Width/2;
                        p.Y = i.Height/2;
                    }
                }

                return p;
            }
        }

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

        public void Draw(Graphics gfx, int xPos, int yPos, float scale, float alpha = 1.0f) {
            if (Frames.Count == 0) return;

            int frameID = (int)(totalTime / PlaybackSpeed);
            Image im = ImageCache.RequestImage(Frames[frameID % Frames.Count]);

            if (alpha >= 0.95f) {
                gfx.DrawImage(im, xPos, yPos, im.Width * scale, im.Height * scale);
            } else {
                // Initialize the color matrix.
                float[][] matrixItems ={ 
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, alpha, 0}, 
                    new float[] {0, 0, 0, 0, 1}};
                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                // Create an ImageAttributes object and set its color matrix.
                ImageAttributes imageAtt = new ImageAttributes();
                imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                gfx.DrawImage(im, new Rectangle(xPos, yPos, (int)(im.Width * scale), (int)(im.Height * scale)), 0, 0, im.Width, im.Height, GraphicsUnit.Pixel, imageAtt);
            }
        }

        public void Draw(Graphics gfx, float xPos, float yPos, float scale, float alpha = 1.0f) {
            Draw(gfx, (int)xPos, (int)yPos, scale, alpha);
        }

        public static void Update(double dt) {
            totalTime += dt;
        }
    }
}
