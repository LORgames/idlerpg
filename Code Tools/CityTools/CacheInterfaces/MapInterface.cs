using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using CityTools.Core;
using System.Windows.Forms;
using ToolCache.Map.Tiles;
using System.Drawing;
using ToolCache.Drawing;
using System.Drawing.Imaging;
using CityTools.Terrain;
using CityTools.ObjectSystem;
using System.Threading;
using System.IO;

namespace CityTools.CacheInterfaces {
    public class MapInterface {
        internal static void Initialize() {
            UpdateGUI();

            MainWindow.instance.cbMapPieces.SelectedIndexChanged += new EventHandler(combo_mappieces_SelectedIndexChanged);
            MainWindow.instance.txtPieceName.TextChanged += new EventHandler(txtPieceName_TextChanged);
            MainWindow.instance.cbMapMusic.TextChanged += new EventHandler(cbMapMusic_TextChanged);

            MainWindow.instance.btnMapResize.Click += new EventHandler(mapSize_TextChanged);
        }


        private static void UpdateGUI() {
            MainWindow.instance.cbMapPieces.Items.Clear();

            foreach (MapPiece mp in MapPieceCache.Pieces) {
                MainWindow.instance.cbMapPieces.Items.Add(mp.Name);
            }

            MainWindow.instance.txtPieceName.Text = MapPieceCache.CurrentPiece.Name;
            MainWindow.instance.txtFilename.Text = MapPieceCache.CurrentPiece.Filename;

            MainWindow.instance.txtMapSizeX.Text = MapPieceCache.CurrentPiece.Tiles.numTilesX.ToString();
            MainWindow.instance.txtMapSizeY.Text = MapPieceCache.CurrentPiece.Tiles.numTilesY.ToString();

            MainWindow.instance.cbMapMusic.Text = MapPieceCache.CurrentPiece.Music;
        }

        private static void mapSize_TextChanged(object sender, EventArgs e) {
            int w = 0;
            int h = 0;

            int.TryParse(MainWindow.instance.txtMapSizeX.Text, out w);
            int.TryParse(MainWindow.instance.txtMapSizeY.Text, out h);

            if (w <= 0 || h <= 0) {
                MessageBox.Show("Cannot have 0 for width or height.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                MapPieceCache.CurrentPiece.Tiles.ChangeSizeTo(Terrain.TerrainHelper.GetCurrentTile(), w, h, MainWindow.instance.cbMapExtendX.SelectedIndex, MainWindow.instance.cbMapExtendY.SelectedIndex);
            }
        }

        private static void txtPieceName_TextChanged(object sender, EventArgs e) {
            if(MainWindow.instance.txtPieceName.Text != MapPieceCache.CurrentPiece.Name)
                MapPieceCache.CurrentPiece.ChangeName(MainWindow.instance.txtPieceName.Text);
        }

        private static void combo_mappieces_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainWindow.instance.cbMapPieces.SelectedIndex >= 0 && MainWindow.instance.cbMapPieces.SelectedIndex < MapPieceCache.Pieces.Count) {
                ChangeCurrentPiece(MapPieceCache.Pieces[MainWindow.instance.cbMapPieces.SelectedIndex]);
            }
        }

        static void cbMapMusic_TextChanged(object sender, EventArgs e) {
            if (MainWindow.instance.cbMapMusic.Text != MapPieceCache.CurrentPiece.Music)
                MapPieceCache.CurrentPiece.ChangeMusic(MainWindow.instance.cbMapMusic.Text);
        }

        internal static void ChangeCurrentPiece(MapPiece newPiece) {
            Camera.Offset.X = 0;
            Camera.Offset.Y = 0;
            Camera.ZoomLevel = 1;
            Camera.FixViewArea(MainWindow.instance.mapViewPanel.Size);

            MapPieceCache.ChangeCurrentPiece(newPiece);

            UpdateGUI();
        }

        internal static void NewPiece() {
            MapPieceCache.CreateNew(34); //Blank tile
            UpdateGUI();
        }

        internal static void Save() {
            MapPieceCache.CurrentPiece.Save();
            DrawThumbnail();

            UpdateGUI();
        }

        internal static void Delete() {
            if (MessageBox.Show("Are you sure you want to delete '" + MapPieceCache.CurrentPiece.Name + "'?", "Delete?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                MapPieceCache.DeleteCurrent();
            }

            UpdateGUI();
        }

        internal static void Duplicate() {
            MapPieceCache.Duplicate();
            UpdateGUI();
        }

        internal static void DrawThumbnail() {
            float scale = 0.1f;
            Size s = new Size((int)(MapPieceCache.CurrentPiece.Tiles.numTilesX * TileTemplate.PIXELS_X * scale), (int)(MapPieceCache.CurrentPiece.Tiles.numTilesY * TileTemplate.PIXELS_Y * scale));
            Rectangle r = new Rectangle(Point.Empty, s);

            Bitmap total = new Bitmap(s.Width, s.Height, PixelFormat.Format32bppArgb);
            LBuffer terrainBits = new LBuffer(s);
            LBuffer objectBits = new LBuffer(s);

            float prev_CamX = Camera.Offset.X;
            float prev_CamY = Camera.Offset.Y;
            float prev_CamZ = Camera.ZoomLevel;
            RectangleF prev_CamV = Camera.ViewArea;

            Camera.Offset.X = 0;
            Camera.Offset.Y = 0;
            Camera.ZoomLevel = scale;
            Camera.FixViewArea(s);

            TerrainHelper.DrawTerrain(terrainBits);
            ScenicHelper.DrawObjects(objectBits);

            using (Graphics gfx = Graphics.FromImage(total)) {
                gfx.DrawImage(terrainBits.bmp, Point.Empty);
                gfx.DrawImage(objectBits.bmp, Point.Empty);
            }

            terrainBits.gfx.Dispose();
            objectBits.gfx.Dispose();
            terrainBits.bmp.Dispose();
            objectBits.bmp.Dispose();

            Thread.Yield();

            if (!Directory.Exists("Maps/Thumbs")) Directory.CreateDirectory("Maps/Thumbs");

            total.Save("Maps/Thumbs/" + MapPieceCache.CurrentPiece.Name + ".png");

            Camera.Offset.X = prev_CamX;
            Camera.Offset.Y = prev_CamY;
            Camera.ZoomLevel = prev_CamZ;
            Camera.ViewArea = prev_CamV;
        }
    }
}
