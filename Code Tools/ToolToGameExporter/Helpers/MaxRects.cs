using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

/*
 	Based on the Public Domain MaxRectanglesBinPack.cpp source by Jukka Jylänki
 	https://github.com/juj/RectangleangleBinPack/
 
 	Ported to C# by Sven Magnus
 	This version is also public domain - do whatever you want with it.
*/
namespace ToolToGameExporter.Helpers {
    public class MaxRects {
	    public int binWidth = 0;
	    public int binHeight = 0;
 
	    public List<Rectangle> usedRectangleangles = new List<Rectangle>();
	    public List<Rectangle> freeRectangleangles = new List<Rectangle>();
        
	    public MaxRects(int width, int height) {
		    Init(width, height);
	    }
 
	    public void Init(int width, int height) {
		    binWidth = width;
		    binHeight = height;
 
		    Rectangle n = new Rectangle();
		    n.X = 0;
		    n.Y = 0;
		    n.Width = width;
		    n.Height = height;
 
		    usedRectangleangles.Clear();
 
		    freeRectangleangles.Clear();
		    freeRectangleangles.Add(n);
	    }
 
	    public Rectangle Insert(int width, int height) {
		    Rectangle newNode = new Rectangle();
		    int score1 = 0; // Unused in this function. We don't need to know the score after finding the position.
		    int score2 = 0;

			newNode = FindPositionForNewNodeBestAreaFit(width, height, ref score1, ref score2);
 
		    if (newNode.Height == 0)
			    return newNode;
 
		    int numRectangleanglesToProcess = freeRectangleangles.Count;
		    for(int i = 0; i < numRectangleanglesToProcess; ++i) {
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
 
	    public void Insert(List<Rectangle> Rectangles, List<Rectangle> dst) {
		    dst.Clear();
 
		    while(Rectangles.Count > 0) {
			    int bestScore1 = int.MaxValue;
			    int bestScore2 = int.MaxValue;
			    int bestRectangleIndex = -1;
			    Rectangle bestNode = new Rectangle();
 
			    for(int i = 0; i < Rectangles.Count; ++i) {
				    int score1 = 0;
				    int score2 = 0;
				    Rectangle newNode = ScoreRectangle((int)Rectangles[i].Width, (int)Rectangles[i].Height, ref score1, ref score2);
 
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
		    for(int i = 0; i < numRectangleanglesToProcess; ++i) {
			    if (SplitFreeNode(freeRectangleangles[i], ref node)) {
				    freeRectangleangles.RemoveAt(i);
				    --i;
				    --numRectangleanglesToProcess;
			    }
		    }
 
		    PruneFreeList();
 
		    usedRectangleangles.Add(node);
	    }
 
	    Rectangle ScoreRectangle(int width, int height, ref int score1, ref int score2) {
		    Rectangle newNode = new Rectangle();
		    score1 = int.MaxValue;
		    score2 = int.MaxValue;

			newNode = FindPositionForNewNodeBestAreaFit(width, height, ref score1, ref score2);
 
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
		    for(int i = 0; i < usedRectangleangles.Count; ++i)
			    usedSurfaceArea += (uint)usedRectangleangles[i].Width * (uint)usedRectangleangles[i].Height;
 
		    return (float)usedSurfaceArea / (binWidth * binHeight);
	    }

	    private Rectangle FindPositionForNewNodeBestAreaFit(int width, int height, ref int bestAreaFit, ref int bestShortSideFit) {
		    Rectangle bestNode = new Rectangle();
		    //memset(&bestNode, 0, sizeof(Rectangle));
 
		    bestAreaFit = int.MaxValue;
 
		    for(int i = 0; i < freeRectangleangles.Count; ++i) {
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
		    }
		    return bestNode;
	    }
 
	    /// Returns 0 if the two intervals i1 and i2 are disjoint, or the length of their overlap otherwise.
	    private int CommonIntervalLength(int i1start, int i1end, int i2start, int i2end) {
		    if (i1end < i2start || i2end < i1start)
			    return 0;
		    return Math.Min(i1end, i2end) - Math.Max(i1start, i2start);
	    }
 
	    private int ContactPointScoreNode(int x, int y, int width, int height) {
		    int score = 0;
 
		    if (x == 0 || x + width == binWidth)
			    score += height;
		    if (y == 0 || y + height == binHeight)
			    score += width;
 
		    for(int i = 0; i < usedRectangleangles.Count; ++i) {
			    if (usedRectangleangles[i].X == x + width || usedRectangleangles[i].X + usedRectangleangles[i].Width == x)
				    score += CommonIntervalLength((int)usedRectangleangles[i].Y, (int)usedRectangleangles[i].Y + (int)usedRectangleangles[i].Height, y, y + height);
			    if (usedRectangleangles[i].Y == y + height || usedRectangleangles[i].Y + usedRectangleangles[i].Height == y)
				    score += CommonIntervalLength((int)usedRectangleangles[i].X, (int)usedRectangleangles[i].X + (int)usedRectangleangles[i].Width, x, x + width);
		    }
		    return score;
	    }
 
	    private Rectangle FindPositionForNewNodeContactPoint(int width, int height, ref int bestContactScore) {
		    Rectangle bestNode = new Rectangle();
		    //memset(&bestNode, 0, sizeof(Rectangle));
 
		    bestContactScore = -1;
 
		    for(int i = 0; i < freeRectangleangles.Count; ++i) {
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
		    }
		    return bestNode;
	    }
 
	    private bool SplitFreeNode(Rectangle freeNode, ref Rectangle usedNode) {
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
 
	    private void PruneFreeList() {
		    for(int i = 0; i < freeRectangleangles.Count; ++i) {
			    for(int j = i+1; j < freeRectangleangles.Count; ++j) {
				    if (IsContainedIn(freeRectangleangles[i], freeRectangleangles[j])) {
					    freeRectangleangles.RemoveAt(i);
					    --i;
					    break;
				    }
				    if (IsContainedIn(freeRectangleangles[j], freeRectangleangles[i])) {
					    freeRectangleangles.RemoveAt(j);
					    --j;
				    }
			    }
            }
	    }
 
	    private bool IsContainedIn(Rectangle a, Rectangle b) {
            return a.Contains(b);
	    }

        public static Rectangle[] PackTextures(Image[] textures, int width, int height, int maxSize, out Bitmap texture) {
            texture = null;

            if (width > maxSize && height > maxSize) return null;
            if (width > maxSize || height > maxSize) { int temp = width; width = height; height = temp; }

            MaxRects bp = new MaxRects(width, height);
            Rectangle[] rects = new Rectangle[textures.Length];

            texture = new Bitmap(width, height);

            for (int i = 0; i < textures.Length; i++) {
                Image tex = textures[i];
                Rectangle rect = bp.Insert(tex.Width, tex.Height);

                if (rect.Width == 0 || rect.Height == 0) {
                    return PackTextures(textures, width * (width <= height ? 2 : 1), height * (height < width ? 2 : 1), maxSize, out texture);
                }

                rects[i] = rect;
            }

            Graphics g = Graphics.FromImage(texture);

            for (int i = 0; i < textures.Length; i++) {
                Image tex = textures[i];
                Rectangle rect = rects[i];

                g.DrawImageUnscaledAndClipped(tex, rect);
            }

            g.Dispose();

            return rects;
        }
    }
}