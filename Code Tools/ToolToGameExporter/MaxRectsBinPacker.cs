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

        public List<Rectangle> usedRectangleangles = new List<Rectangle>();
        public List<Rectangle> freeRectangleangles = new List<Rectangle>();

        public enum FreeRectangleChoiceHeuristic {
            RectangleBestShortSideFit, ///< -BSSF: Positions the Rectangleangle against the short side of a free Rectangleangle into which it fits the best.
            RectangleBestLongSideFit, ///< -BLSF: Positions the Rectangleangle against the long side of a free Rectangleangle into which it fits the best.
            RectangleBestAreaFit, ///< -BAF: Positions the Rectangleangle into the smallest free Rectangle into which it fits.
            RectangleBottomLeftRule, ///< -BL: Does the Tetris placement.
            RectangleContactPointRule ///< -CP: Choosest the placement where the Rectangleangle touches other Rectangles as much as possible.
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

            usedRectangleangles.Clear();

            freeRectangleangles.Clear();
            freeRectangleangles.Add(n);
        }

        public Rectangle Insert(int width, int height, FreeRectangleChoiceHeuristic method) {
            Rectangle newNode = new Rectangle();
            int score1 = 0; // Unused in this function. We don't need to know the score after finding the position.
            int score2 = 0;
            switch (method) {
                case FreeRectangleChoiceHeuristic.RectangleBestShortSideFit: newNode = FindPositionForNewNodeBestShortSideFit(width, height, ref score1, ref score2); break;
                case FreeRectangleChoiceHeuristic.RectangleBottomLeftRule: newNode = FindPositionForNewNodeBottomLeft(width, height, ref score1, ref score2); break;
                case FreeRectangleChoiceHeuristic.RectangleContactPointRule: newNode = FindPositionForNewNodeContactPoint(width, height, ref score1); break;
                case FreeRectangleChoiceHeuristic.RectangleBestLongSideFit: newNode = FindPositionForNewNodeBestLongSideFit(width, height, ref score2, ref score1); break;
                case FreeRectangleChoiceHeuristic.RectangleBestAreaFit: newNode = FindPositionForNewNodeBestAreaFit(width, height, ref score1, ref score2); break;
            }

            if (newNode.Height == 0)
                return newNode;

            int numRectangleanglesToProcess = freeRectangleangles.Count;
            for (int i = 0; i < numRectangleanglesToProcess; ++i) {
                if (SplitFreeNode(freeRectangleangles[i], ref newNode)) {
                    freeRectangleangles.RemoveAt(i);
                    --i;
                    --numRectangleanglesToProcess;
                }
            }

            PruneFreeList();

            usedRectangleangles.Add(newNode);
            return newNode;
        }

        public void Insert(List<Rectangle> Rectangles, List<Rectangle> dst, FreeRectangleChoiceHeuristic method) {
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
            int numRectangleanglesToProcess = freeRectangleangles.Count;
            for (int i = 0; i < numRectangleanglesToProcess; ++i) {
                if (SplitFreeNode(freeRectangleangles[i], ref node)) {
                    freeRectangleangles.RemoveAt(i);
                    --i;
                    --numRectangleanglesToProcess;
                }
            }

            PruneFreeList();

            usedRectangleangles.Add(node);
        }

        Rectangle ScoreRectangle(int width, int height, FreeRectangleChoiceHeuristic method, ref int score1, ref int score2) {
            Rectangle newNode = new Rectangle();
            score1 = int.MaxValue;
            score2 = int.MaxValue;
            switch (method) {
                case FreeRectangleChoiceHeuristic.RectangleBestShortSideFit: newNode = FindPositionForNewNodeBestShortSideFit(width, height, ref score1, ref score2); break;
                case FreeRectangleChoiceHeuristic.RectangleBottomLeftRule: newNode = FindPositionForNewNodeBottomLeft(width, height, ref score1, ref score2); break;
                case FreeRectangleChoiceHeuristic.RectangleContactPointRule: newNode = FindPositionForNewNodeContactPoint(width, height, ref score1);
                    score1 = -score1; // Reverse since we are minimizing, but for contact point score bigger is better.
                    break;
                case FreeRectangleChoiceHeuristic.RectangleBestLongSideFit: newNode = FindPositionForNewNodeBestLongSideFit(width, height, ref score2, ref score1); break;
                case FreeRectangleChoiceHeuristic.RectangleBestAreaFit: newNode = FindPositionForNewNodeBestAreaFit(width, height, ref score1, ref score2); break;
            }

            // Cannot fit the current Rectangleangle.
            if (newNode.Height == 0) {
                score1 = int.MaxValue;
                score2 = int.MaxValue;
            }

            return newNode;
        }

        /// Computes the ratio of used surface area.
        public float Occupancy() {
            ulong usedSurfaceArea = 0;
            for (int i = 0; i < usedRectangleangles.Count; ++i)
                usedSurfaceArea += (uint)usedRectangleangles[i].Width * (uint)usedRectangleangles[i].Height;

            return (float)usedSurfaceArea / (binWidth * binHeight);
        }

        Rectangle FindPositionForNewNodeBottomLeft(int width, int height, ref int bestY, ref int bestX) {
            Rectangle bestNode = new Rectangle();
            //memset(bestNode, 0, sizeof(Rectangle));

            bestY = int.MaxValue;

            for (int i = 0; i < freeRectangleangles.Count; ++i) {
                // Try to place the Rectangleangle in upright (non-flipped) orientation.
                if (freeRectangleangles[i].Width >= width && freeRectangleangles[i].Height >= height) {
                    int topSideY = (int)freeRectangleangles[i].Y + height;
                    if (topSideY < bestY || (topSideY == bestY && freeRectangleangles[i].X < bestX)) {
                        bestNode.X = freeRectangleangles[i].X;
                        bestNode.Y = freeRectangleangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestY = topSideY;
                        bestX = (int)freeRectangleangles[i].X;
                    }
                }
                if (allowRotations && freeRectangleangles[i].Width >= height && freeRectangleangles[i].Height >= width) {
                    int topSideY = (int)freeRectangleangles[i].Y + width;
                    if (topSideY < bestY || (topSideY == bestY && freeRectangleangles[i].X < bestX)) {
                        bestNode.X = freeRectangleangles[i].X;
                        bestNode.Y = freeRectangleangles[i].Y;
                        bestNode.Width = height;
                        bestNode.Height = width;
                        bestY = topSideY;
                        bestX = (int)freeRectangleangles[i].X;
                    }
                }
            }
            return bestNode;
        }

        Rectangle FindPositionForNewNodeBestShortSideFit(int width, int height, ref int bestShortSideFit, ref int bestLongSideFit) {
            Rectangle bestNode = new Rectangle();
            //memset(&bestNode, 0, sizeof(Rectangle));

            bestShortSideFit = int.MaxValue;

            for (int i = 0; i < freeRectangleangles.Count; ++i) {
                // Try to place the Rectangleangle in upright (non-flipped) orientation.
                if (freeRectangleangles[i].Width >= width && freeRectangleangles[i].Height >= height) {
                    int leftoverHoriz = Math.Abs((int)freeRectangleangles[i].Width - width);
                    int leftoverVert = Math.Abs((int)freeRectangleangles[i].Height - height);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);
                    int longSideFit = Math.Max(leftoverHoriz, leftoverVert);

                    if (shortSideFit < bestShortSideFit || (shortSideFit == bestShortSideFit && longSideFit < bestLongSideFit)) {
                        bestNode.X = freeRectangleangles[i].X;
                        bestNode.Y = freeRectangleangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestShortSideFit = shortSideFit;
                        bestLongSideFit = longSideFit;
                    }
                }

                if (allowRotations && freeRectangleangles[i].Width >= height && freeRectangleangles[i].Height >= width) {
                    int flippedLeftoverHoriz = Math.Abs((int)freeRectangleangles[i].Width - height);
                    int flippedLeftoverVert = Math.Abs((int)freeRectangleangles[i].Height - width);
                    int flippedShortSideFit = Math.Min(flippedLeftoverHoriz, flippedLeftoverVert);
                    int flippedLongSideFit = Math.Max(flippedLeftoverHoriz, flippedLeftoverVert);

                    if (flippedShortSideFit < bestShortSideFit || (flippedShortSideFit == bestShortSideFit && flippedLongSideFit < bestLongSideFit)) {
                        bestNode.X = freeRectangleangles[i].X;
                        bestNode.Y = freeRectangleangles[i].Y;
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

            for (int i = 0; i < freeRectangleangles.Count; ++i) {
                // Try to place the Rectangleangle in upright (non-flipped) orientation.
                if (freeRectangleangles[i].Width >= width && freeRectangleangles[i].Height >= height) {
                    int leftoverHoriz = Math.Abs((int)freeRectangleangles[i].Width - width);
                    int leftoverVert = Math.Abs((int)freeRectangleangles[i].Height - height);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);
                    int longSideFit = Math.Max(leftoverHoriz, leftoverVert);

                    if (longSideFit < bestLongSideFit || (longSideFit == bestLongSideFit && shortSideFit < bestShortSideFit)) {
                        bestNode.X = freeRectangleangles[i].X;
                        bestNode.Y = freeRectangleangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestShortSideFit = shortSideFit;
                        bestLongSideFit = longSideFit;
                    }
                }

                if (allowRotations && freeRectangleangles[i].Width >= height && freeRectangleangles[i].Height >= width) {
                    int leftoverHoriz = Math.Abs((int)freeRectangleangles[i].Width - height);
                    int leftoverVert = Math.Abs((int)freeRectangleangles[i].Height - width);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);
                    int longSideFit = Math.Max(leftoverHoriz, leftoverVert);

                    if (longSideFit < bestLongSideFit || (longSideFit == bestLongSideFit && shortSideFit < bestShortSideFit)) {
                        bestNode.X = freeRectangleangles[i].X;
                        bestNode.Y = freeRectangleangles[i].Y;
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

            for (int i = 0; i < freeRectangleangles.Count; ++i) {
                int areaFit = (int)freeRectangleangles[i].Width * (int)freeRectangleangles[i].Height - width * height;

                // Try to place the Rectangleangle in upright (non-flipped) orientation.
                if (freeRectangleangles[i].Width >= width && freeRectangleangles[i].Height >= height) {
                    int leftoverHoriz = Math.Abs((int)freeRectangleangles[i].Width - width);
                    int leftoverVert = Math.Abs((int)freeRectangleangles[i].Height - height);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);

                    if (areaFit < bestAreaFit || (areaFit == bestAreaFit && shortSideFit < bestShortSideFit)) {
                        bestNode.X = freeRectangleangles[i].X;
                        bestNode.Y = freeRectangleangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestShortSideFit = shortSideFit;
                        bestAreaFit = areaFit;
                    }
                }

                if (allowRotations && freeRectangleangles[i].Width >= height && freeRectangleangles[i].Height >= width) {
                    int leftoverHoriz = Math.Abs((int)freeRectangleangles[i].Width - height);
                    int leftoverVert = Math.Abs((int)freeRectangleangles[i].Height - width);
                    int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);

                    if (areaFit < bestAreaFit || (areaFit == bestAreaFit && shortSideFit < bestShortSideFit)) {
                        bestNode.X = freeRectangleangles[i].X;
                        bestNode.Y = freeRectangleangles[i].Y;
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

            for (int i = 0; i < usedRectangleangles.Count; ++i) {
                if (usedRectangleangles[i].X == x + width || usedRectangleangles[i].X + usedRectangleangles[i].Width == x)
                    score += CommonIntervalLength((int)usedRectangleangles[i].Y, (int)usedRectangleangles[i].Y + (int)usedRectangleangles[i].Height, y, y + height);
                if (usedRectangleangles[i].Y == y + height || usedRectangleangles[i].Y + usedRectangleangles[i].Height == y)
                    score += CommonIntervalLength((int)usedRectangleangles[i].X, (int)usedRectangleangles[i].X + (int)usedRectangleangles[i].Width, x, x + width);
            }
            return score;
        }

        Rectangle FindPositionForNewNodeContactPoint(int width, int height, ref int bestContactScore) {
            Rectangle bestNode = new Rectangle();
            //memset(&bestNode, 0, sizeof(Rectangle));

            bestContactScore = -1;

            for (int i = 0; i < freeRectangleangles.Count; ++i) {
                // Try to place the Rectangleangle in upright (non-flipped) orientation.
                if (freeRectangleangles[i].Width >= width && freeRectangleangles[i].Height >= height) {
                    int score = ContactPointScoreNode((int)freeRectangleangles[i].X, (int)freeRectangleangles[i].Y, width, height);
                    if (score > bestContactScore) {
                        bestNode.X = (int)freeRectangleangles[i].X;
                        bestNode.Y = (int)freeRectangleangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestContactScore = score;
                    }
                }
                if (allowRotations && freeRectangleangles[i].Width >= height && freeRectangleangles[i].Height >= width) {
                    int score = ContactPointScoreNode((int)freeRectangleangles[i].X, (int)freeRectangleangles[i].Y, height, width);
                    if (score > bestContactScore) {
                        bestNode.X = (int)freeRectangleangles[i].X;
                        bestNode.Y = (int)freeRectangleangles[i].Y;
                        bestNode.Width = height;
                        bestNode.Height = width;
                        bestContactScore = score;
                    }
                }
            }
            return bestNode;
        }

        bool SplitFreeNode(Rectangle freeNode, ref Rectangle usedNode) {
            // Test with SAT if the Rectangleangles even intersect.
            if (usedNode.X >= freeNode.X + freeNode.Width || usedNode.X + usedNode.Width <= freeNode.X ||
                usedNode.Y >= freeNode.Y + freeNode.Height || usedNode.Y + usedNode.Height <= freeNode.Y)
                return false;

            if (usedNode.X < freeNode.X + freeNode.Width && usedNode.X + usedNode.Width > freeNode.X) {
                // New node at the top side of the used node.
                if (usedNode.Y > freeNode.Y && usedNode.Y < freeNode.Y + freeNode.Height) {
                    Rectangle newNode = freeNode;
                    newNode.Height = usedNode.Y - newNode.Y;
                    freeRectangleangles.Add(newNode);
                }

                // New node at the bottom side of the used node.
                if (usedNode.Y + usedNode.Height < freeNode.Y + freeNode.Height) {
                    Rectangle newNode = freeNode;
                    newNode.Y = usedNode.Y + usedNode.Height;
                    newNode.Height = freeNode.Y + freeNode.Height - (usedNode.Y + usedNode.Height);
                    freeRectangleangles.Add(newNode);
                }
            }

            if (usedNode.Y < freeNode.Y + freeNode.Height && usedNode.Y + usedNode.Height > freeNode.Y) {
                // New node at the left side of the used node.
                if (usedNode.X > freeNode.X && usedNode.X < freeNode.X + freeNode.Width) {
                    Rectangle newNode = freeNode;
                    newNode.Width = usedNode.X - newNode.X;
                    freeRectangleangles.Add(newNode);
                }

                // New node at the right side of the used node.
                if (usedNode.X + usedNode.Width < freeNode.X + freeNode.Width) {
                    Rectangle newNode = freeNode;
                    newNode.X = usedNode.X + usedNode.Width;
                    newNode.Width = freeNode.X + freeNode.Width - (usedNode.X + usedNode.Width);
                    freeRectangleangles.Add(newNode);
                }
            }

            return true;
        }

        void PruneFreeList() {
            for (int i = 0; i < freeRectangleangles.Count; ++i)
                for (int j = i + 1; j < freeRectangleangles.Count; ++j) {
                    if (freeRectangleangles[i].Contains(freeRectangleangles[j])) {
                        freeRectangleangles.RemoveAt(i);
                        --i;
                        break;
                    }
                    if (freeRectangleangles[j].Contains(freeRectangleangles[i])) {
                        freeRectangleangles.RemoveAt(j);
                        --j;
                    }
                }
        }
    }
}
