using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ToolToGameExporter {
    public class MaxRectanglesBinPack {

        public int binWidth = 0;
        public int binHeight = 0;
        public bool allowRotations;

        public List<Rectangle> usedRectangles = new List<Rectangle>();
        public List<Rectangle> freeRectangles = new List<Rectangle>();

        public enum Heuristic {
            BestShortSideFit, ///< -BSSF: Positions the Rectangle against the short side of a free Rectangle into which it fits the best.
            BestLongSideFit, ///< -BLSF: Positions the Rectangle against the long side of a free Rectangle into which it fits the best.
            BestAreaFit, ///< -BAF: Positions the Rectangle into the smallest free Rectangle into which it fits.
            BottomLeftRule, ///< -BL: Does the Tetris placement.
            ContactPointRule ///< -CP: Choosest the placement where the Rectangle touches other Rectangles as much as possible.
        };

        public MaxRectanglesBinPack(int width, int height, bool rotations = true) {
            Init(width, height, rotations);
        }

        public void Init(int width, int height, bool rotations = true) {
            binWidth = width;
            binHeight = height;
            allowRotations = rotations;

            Rectangle n = new Rectangle();
            n.X = 0;
            n.Y = 0;
            n.Width = width;
            n.Height = height;

            usedRectangles.Clear();

            freeRectangles.Clear();
            freeRectangles.Add(n);
        }

        public Rectangle Insert(int width, int height, Heuristic method) {
            Rectangle newNode = new Rectangle();
            int score1 = 0; // Unused in this function. We don't need to know the score after finding the position.
            int score2 = 0;
            switch (method) {
                case Heuristic.BestShortSideFit: newNode = FindPositionForNewNodeBestShortSideFit(width, height, ref score1, ref score2); break;
                case Heuristic.BottomLeftRule: newNode = FindPositionForNewNodeBottomLeft(width, height, ref score1, ref score2); break;
                case Heuristic.ContactPointRule: newNode = FindPositionForNewNodeContactPoint(width, height, ref score1); break;
                case Heuristic.BestLongSideFit: newNode = FindPositionForNewNodeBestLongSideFit(width, height, ref score2, ref score1); break;
                case Heuristic.BestAreaFit: newNode = FindPositionForNewNodeBestAreaFit(width, height, ref score1, ref score2); break;
            }

            if (newNode.Height == 0)
                return newNode;

            int numRectanglesToProcess = freeRectangles.Count;
            for (int i = 0; i < numRectanglesToProcess; ++i) {
                if (SplitFreeNode(freeRectangles[i], ref newNode)) {
                    freeRectangles.RemoveAt(i);
                    --i;
                    --numRectanglesToProcess;
                }
            }

            PruneFreeList();

            usedRectangles.Add(newNode);
            return newNode;
        }

        public void Insert(List<Rectangle> Rectangles, List<Rectangle> dst, Heuristic method) {
            dst.Clear();

            while (Rectangles.Count > 0) {
                int bestScore1 = int.MaxValue;
                int bestScore2 = int.MaxValue;
                int bestRectangleIndex = -1;
                Rectangle bestNode = new Rectangle();

                for (int i = 0; i < Rectangles.Count; ++i) {
                    int score1 = 0;
                    int score2 = 0;
                    Rectangle newNode = ScoreRectangle((int)Rectangles[i].Width, (int)Rectangles[i].Height, method, ref score1, ref score2);

                    if (score1 < bestScore1 || (score1 == bestScore1 && score2 < bestScore2)) {
                        bestScore1 = score1;
                        bestScore2 = score2;
                        bestNode = newNode;
                        bestRectangleIndex = i;
                    }
                }

                if (bestRectangleIndex == -1)
                    return;

                PlaceRectangle(bestNode);
                Rectangles.RemoveAt(bestRectangleIndex);
            }
        }

        void PlaceRectangle(Rectangle node) {
            int numRectanglesToProcess = freeRectangles.Count;
            for (int i = 0; i < numRectanglesToProcess; ++i) {
                if (SplitFreeNode(freeRectangles[i], ref node)) {
                    freeRectangles.RemoveAt(i);
                    --i;
                    --numRectanglesToProcess;
                }
            }

            PruneFreeList();

            usedRectangles.Add(node);
        }

        Rectangle ScoreRectangle(int width, int height, Heuristic method, ref int score1, ref int score2) {
            Rectangle newNode = new Rectangle();
            score1 = int.MaxValue;
            score2 = int.MaxValue;
            switch (method) {
                case Heuristic.BestShortSideFit: newNode = FindPositionForNewNodeBestShortSideFit(width, height, ref score1, ref score2); break;
                case Heuristic.BottomLeftRule: newNode = FindPositionForNewNodeBottomLeft(width, height, ref score1, ref score2); break;
                case Heuristic.ContactPointRule: newNode = FindPositionForNewNodeContactPoint(width, height, ref score1);
                    score1 = -score1; // Reverse since we are minimizing, but for contact point score bigger is better.
                    break;
                case Heuristic.BestLongSideFit: newNode = FindPositionForNewNodeBestLongSideFit(width, height, ref score2, ref score1); break;
                case Heuristic.BestAreaFit: newNode = FindPositionForNewNodeBestAreaFit(width, height, ref score1, ref score2); break;
            }

            // Cannot fit the current Rectangle.
            if (newNode.Height == 0) {
                score1 = int.MaxValue;
                score2 = int.MaxValue;
            }

            return newNode;
        }

        /// Computes the ratio of used surface area.
        public float Occupancy() {
            ulong usedSurfaceArea = 0;
            for (int i = 0; i < usedRectangles.Count; ++i)
                usedSurfaceArea += (uint)usedRectangles[i].Width * (uint)usedRectangles[i].Height;

            return (float)usedSurfaceArea / (binWidth * binHeight);
        }

        Rectangle FindPositionForNewNodeBottomLeft(int width, int height, ref int bestY, ref int bestX) {
            Rectangle bestNode = new Rectangle();
            //memset(bestNode, 0, sizeof(Rectangle));

            bestY = int.MaxValue;

            for (int i = 0; i < freeRectangles.Count; ++i) {
                // Try to place the Rectangle in upright (non-flipped) orientation.
                if (freeRectangles[i].Width >= width && freeRectangles[i].Height >= height) {
                    int topSideY = (int)freeRectangles[i].Y + height;
                    if (topSideY < bestY || (topSideY == bestY && freeRectangles[i].X < bestX)) {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestY = topSideY;
                        bestX = (int)freeRectangles[i].X;
                    }
                }
                if (allowRotations && freeRectangles[i].Width >= height && freeRectangles[i].Height >= width) {
                    int topSideY = (int)freeRectangles[i].Y + width;
                    if (topSideY < bestY || (topSideY == bestY && freeRectangles[i].X < bestX)) {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = height;
                        bestNode.Height = width;
                        bestY = topSideY;
                        bestX = (int)freeRectangles[i].X;
                    }
                }
            }
            return bestNode;
        }

        Rectangle FindPositionForNewNodeBestShortSideFit(int width, int height, ref int bestShortSideFit, ref int bestLongSideFit) {
            Rectangle bestNode = new Rectangle();
            //memset(&bestNode, 0, sizeof(Rectangle));

            bestShortSideFit = int.MaxValue;

            for (int i = 0; i < freeRectangles.Count; ++i) {
                // Try to place the Rectangle in upright (non-flipped) orientation.
                if (freeRectangles[i].Width >= width && freeRectangles[i].Height >= height) {
                    int leftoverHoriz = Math.Abs((int)freeRectangles[i].Width - width);
                    int leftoverVert = Math.Abs((int)freeRectangles[i].Height - height);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);
                    int longSideFit = Math.Max(leftoverHoriz, leftoverVert);

                    if (shortSideFit < bestShortSideFit || (shortSideFit == bestShortSideFit && longSideFit < bestLongSideFit)) {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestShortSideFit = shortSideFit;
                        bestLongSideFit = longSideFit;
                    }
                }

                if (allowRotations && freeRectangles[i].Width >= height && freeRectangles[i].Height >= width) {
                    int flippedLeftoverHoriz = Math.Abs((int)freeRectangles[i].Width - height);
                    int flippedLeftoverVert = Math.Abs((int)freeRectangles[i].Height - width);
                    int flippedShortSideFit = Math.Min(flippedLeftoverHoriz, flippedLeftoverVert);
                    int flippedLongSideFit = Math.Max(flippedLeftoverHoriz, flippedLeftoverVert);

                    if (flippedShortSideFit < bestShortSideFit || (flippedShortSideFit == bestShortSideFit && flippedLongSideFit < bestLongSideFit)) {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = height;
                        bestNode.Height = width;
                        bestShortSideFit = flippedShortSideFit;
                        bestLongSideFit = flippedLongSideFit;
                    }
                }
            }
            return bestNode;
        }

        Rectangle FindPositionForNewNodeBestLongSideFit(int width, int height, ref int bestShortSideFit, ref int bestLongSideFit) {
            Rectangle bestNode = new Rectangle();
            //memset(&bestNode, 0, sizeof(Rectangle));

            bestLongSideFit = int.MaxValue;

            for (int i = 0; i < freeRectangles.Count; ++i) {
                // Try to place the Rectangle in upright (non-flipped) orientation.
                if (freeRectangles[i].Width >= width && freeRectangles[i].Height >= height) {
                    int leftoverHoriz = Math.Abs((int)freeRectangles[i].Width - width);
                    int leftoverVert = Math.Abs((int)freeRectangles[i].Height - height);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);
                    int longSideFit = Math.Max(leftoverHoriz, leftoverVert);

                    if (longSideFit < bestLongSideFit || (longSideFit == bestLongSideFit && shortSideFit < bestShortSideFit)) {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestShortSideFit = shortSideFit;
                        bestLongSideFit = longSideFit;
                    }
                }

                if (allowRotations && freeRectangles[i].Width >= height && freeRectangles[i].Height >= width) {
                    int leftoverHoriz = Math.Abs((int)freeRectangles[i].Width - height);
                    int leftoverVert = Math.Abs((int)freeRectangles[i].Height - width);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);
                    int longSideFit = Math.Max(leftoverHoriz, leftoverVert);

                    if (longSideFit < bestLongSideFit || (longSideFit == bestLongSideFit && shortSideFit < bestShortSideFit)) {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = height;
                        bestNode.Height = width;
                        bestShortSideFit = shortSideFit;
                        bestLongSideFit = longSideFit;
                    }
                }
            }
            return bestNode;
        }

        Rectangle FindPositionForNewNodeBestAreaFit(int width, int height, ref int bestAreaFit, ref int bestShortSideFit) {
            Rectangle bestNode = new Rectangle();
            //memset(&bestNode, 0, sizeof(Rectangle));

            bestAreaFit = int.MaxValue;

            for (int i = 0; i < freeRectangles.Count; ++i) {
                int areaFit = (int)freeRectangles[i].Width * (int)freeRectangles[i].Height - width * height;

                // Try to place the Rectangle in upright (non-flipped) orientation.
                if (freeRectangles[i].Width >= width && freeRectangles[i].Height >= height) {
                    int leftoverHoriz = Math.Abs((int)freeRectangles[i].Width - width);
                    int leftoverVert = Math.Abs((int)freeRectangles[i].Height - height);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);

                    if (areaFit < bestAreaFit || (areaFit == bestAreaFit && shortSideFit < bestShortSideFit)) {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestShortSideFit = shortSideFit;
                        bestAreaFit = areaFit;
                    }
                }

                if (allowRotations && freeRectangles[i].Width >= height && freeRectangles[i].Height >= width) {
                    int leftoverHoriz = Math.Abs((int)freeRectangles[i].Width - height);
                    int leftoverVert = Math.Abs((int)freeRectangles[i].Height - width);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);

                    if (areaFit < bestAreaFit || (areaFit == bestAreaFit && shortSideFit < bestShortSideFit)) {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = height;
                        bestNode.Height = width;
                        bestShortSideFit = shortSideFit;
                        bestAreaFit = areaFit;
                    }
                }
            }
            return bestNode;
        }

        /// Returns 0 if the two intervals i1 and i2 are disjoint, or the length of their overlap otherwise.
        int CommonIntervalLength(int i1start, int i1end, int i2start, int i2end) {
            if (i1end < i2start || i2end < i1start)
                return 0;
            return Math.Min(i1end, i2end) - Math.Max(i1start, i2start);
        }

        int ContactPointScoreNode(int x, int y, int width, int height) {
            int score = 0;

            if (x == 0 || x + width == binWidth)
                score += height;
            if (y == 0 || y + height == binHeight)
                score += width;

            for (int i = 0; i < usedRectangles.Count; ++i) {
                if (usedRectangles[i].X == x + width || usedRectangles[i].X + usedRectangles[i].Width == x)
                    score += CommonIntervalLength((int)usedRectangles[i].Y, (int)usedRectangles[i].Y + (int)usedRectangles[i].Height, y, y + height);
                if (usedRectangles[i].Y == y + height || usedRectangles[i].Y + usedRectangles[i].Height == y)
                    score += CommonIntervalLength((int)usedRectangles[i].X, (int)usedRectangles[i].X + (int)usedRectangles[i].Width, x, x + width);
            }
            return score;
        }

        Rectangle FindPositionForNewNodeContactPoint(int width, int height, ref int bestContactScore) {
            Rectangle bestNode = new Rectangle();
            //memset(&bestNode, 0, sizeof(Rectangle));

            bestContactScore = -1;

            for (int i = 0; i < freeRectangles.Count; ++i) {
                // Try to place the Rectangle in upright (non-flipped) orientation.
                if (freeRectangles[i].Width >= width && freeRectangles[i].Height >= height) {
                    int score = ContactPointScoreNode((int)freeRectangles[i].X, (int)freeRectangles[i].Y, width, height);
                    if (score > bestContactScore) {
                        bestNode.X = (int)freeRectangles[i].X;
                        bestNode.Y = (int)freeRectangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestContactScore = score;
                    }
                }
                if (allowRotations && freeRectangles[i].Width >= height && freeRectangles[i].Height >= width) {
                    int score = ContactPointScoreNode((int)freeRectangles[i].X, (int)freeRectangles[i].Y, height, width);
                    if (score > bestContactScore) {
                        bestNode.X = (int)freeRectangles[i].X;
                        bestNode.Y = (int)freeRectangles[i].Y;
                        bestNode.Width = height;
                        bestNode.Height = width;
                        bestContactScore = score;
                    }
                }
            }
            return bestNode;
        }

        bool SplitFreeNode(Rectangle freeNode, ref Rectangle usedNode) {
            // Test with SAT if the Rectangles even intersect.
            if (usedNode.X >= freeNode.X + freeNode.Width || usedNode.X + usedNode.Width <= freeNode.X ||
                usedNode.Y >= freeNode.Y + freeNode.Height || usedNode.Y + usedNode.Height <= freeNode.Y)
                return false;

            if (usedNode.X < freeNode.X + freeNode.Width && usedNode.X + usedNode.Width > freeNode.X) {
                // New node at the top side of the used node.
                if (usedNode.Y > freeNode.Y && usedNode.Y < freeNode.Y + freeNode.Height) {
                    Rectangle newNode = freeNode;
                    newNode.Height = usedNode.Y - newNode.Y;
                    freeRectangles.Add(newNode);
                }

                // New node at the bottom side of the used node.
                if (usedNode.Y + usedNode.Height < freeNode.Y + freeNode.Height) {
                    Rectangle newNode = freeNode;
                    newNode.Y = usedNode.Y + usedNode.Height;
                    newNode.Height = freeNode.Y + freeNode.Height - (usedNode.Y + usedNode.Height);
                    freeRectangles.Add(newNode);
                }
            }

            if (usedNode.Y < freeNode.Y + freeNode.Height && usedNode.Y + usedNode.Height > freeNode.Y) {
                // New node at the left side of the used node.
                if (usedNode.X > freeNode.X && usedNode.X < freeNode.X + freeNode.Width) {
                    Rectangle newNode = freeNode;
                    newNode.Width = usedNode.X - newNode.X;
                    freeRectangles.Add(newNode);
                }

                // New node at the right side of the used node.
                if (usedNode.X + usedNode.Width < freeNode.X + freeNode.Width) {
                    Rectangle newNode = freeNode;
                    newNode.X = usedNode.X + usedNode.Width;
                    newNode.Width = freeNode.X + freeNode.Width - (usedNode.X + usedNode.Width);
                    freeRectangles.Add(newNode);
                }
            }

            return true;
        }

        void PruneFreeList() {
            for (int i = 0; i < freeRectangles.Count; ++i)
                for (int j = i + 1; j < freeRectangles.Count; ++j) {
                    if (freeRectangles[i].Contains(freeRectangles[j])) {
                        freeRectangles.RemoveAt(i);
                        --i;
                        break;
                    }
                    if (freeRectangles[j].Contains(freeRectangles[i])) {
                        freeRectangles.RemoveAt(j);
                        --j;
                    }
                }
        }
    }
}
