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
using ToolCache.World;

namespace CityTools.CacheInterfaces {
    /// <summary>
    /// Interfaces with the ToolCache.Map classes to update the tools when data changes and vice versa.
    /// </summary>
    public class MapInterface {
        /// <summary>
        /// Setup all the required links to the GUI and load any databases that might need loading
        /// </summary>
        internal static void Initialize() {
            UpdateGUI();

            MainWindow.instance.cbMapPieces.SelectedIndexChanged += new EventHandler(combo_mappieces_SelectedIndexChanged);
            MainWindow.instance.txtPieceName.Leave += new EventHandler(txtPieceName_TextChanged);
            MainWindow.instance.cbMapMusic.TextChanged += new EventHandler(cbMapMusic_TextChanged);
            MainWindow.instance.scriptMap.ScriptUpdated += new EventHandler<EventArgs>(scriptMap_ScriptUpdated);

            MainWindow.instance.btnMapResize.Click += new EventHandler(mapSize_TextChanged);

            PortalInterface.Initialize();
        }

        /// <summary>
        /// Updates textfields and lists to display the most upto date data
        /// </summary>
        private static void UpdateGUI() {
            //Update the list of all maps
            MainWindow.instance.cbMapPieces.Items.Clear();
            foreach (MapPiece mp in MapPieceCache.Pieces) {
                MainWindow.instance.cbMapPieces.Items.Add(mp.Name);
            }

            //Update the map info
            MainWindow.instance.txtPieceName.Text = MapPieceCache.CurrentPiece.Name;
            MainWindow.instance.txtFilename.Text = MapPieceCache.CurrentPiece.Filename;

            //Update the map size
            MainWindow.instance.txtMapSizeX.Text = MapPieceCache.CurrentPiece.Tiles.numTilesX.ToString();
            MainWindow.instance.txtMapSizeY.Text = MapPieceCache.CurrentPiece.Tiles.numTilesY.ToString();

            //Update the music
            MainWindow.instance.cbMapMusic.Text = MapPieceCache.CurrentPiece.Music;
            
            PortalInterface.UpdatePortalList();
            PortalInterface.UpdateGUI();

            SpawnRegionInterface.UpdateRegionList();
            SpawnRegionInterface.UpdateGUI();

            //Update the script
            MainWindow.instance.scriptMap.Script = MapPieceCache.CurrentPiece.Script;
        }

        /// <summary>
        /// Called when the user changes the size of the map
        /// </summary>
        /// <param name="sender">Not too important, can be null</param>
        /// <param name="e">Not important, can be null</param>
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

        /// <summary>
        /// Is called when the script is modified by the user. Just causes the script to update on the Map Object.
        /// </summary>
        /// <param name="sender">Not too important, can be null</param>
        /// <param name="e">Not too important, can be null</param>
        static void scriptMap_ScriptUpdated(object sender, EventArgs e) {
            if (MapPieceCache.CurrentPiece != null) {
                MapPieceCache.CurrentPiece.Edited();
                MapPieceCache.CurrentPiece.Script = MainWindow.instance.scriptMap.Script;
            }
        }

        /// <summary>
        /// This function is called when the name of the map is changed. Alters the name of the map in the database.
        /// </summary>
        /// <param name="sender">Not important, can be null</param>
        /// <param name="e">Not important, can be null</param>
        private static void txtPieceName_TextChanged(object sender, EventArgs e) {
            if (MainWindow.instance.txtPieceName.Text != MapPieceCache.CurrentPiece.Name) {
                if (MapPieceCache.GetMapByName(MainWindow.instance.txtPieceName.Text) != null) {
                    MessageBox.Show("Sorry! A map is already named that! Map names must be unique.");
                    MainWindow.instance.txtPieceName.Text = MapPieceCache.CurrentPiece.Name;
                } else {
                    MapPieceCache.CurrentPiece.ChangeName(MainWindow.instance.txtPieceName.Text);
                }
            }
        }

        /// <summary>
        /// Called when the map is changed in the map display list.
        /// </summary>
        /// <param name="sender">Not important, can be null</param>
        /// <param name="e">Not important, can be null</param>
        private static void combo_mappieces_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainWindow.instance.cbMapPieces.SelectedIndex >= 0 && MainWindow.instance.cbMapPieces.SelectedIndex < MapPieceCache.Pieces.Count) {
                ChangeCurrentPiece(MapPieceCache.Pieces[MainWindow.instance.cbMapPieces.SelectedIndex]);
            }
        }

        /// <summary>
        /// Called when the music dropdown is changed. Alters the MapPiece information.
        /// </summary>
        /// <param name="sender">Not important, can be null</param>
        /// <param name="e">Not important, can be null</param>
        static void cbMapMusic_TextChanged(object sender, EventArgs e) {
            if (MainWindow.instance.cbMapMusic.Text != MapPieceCache.CurrentPiece.Music)
                MapPieceCache.CurrentPiece.ChangeMusic(MainWindow.instance.cbMapMusic.Text);
        }

        /// <summary>
        /// Helper function to reset the camera view and setup the GUI for the new map.
        /// </summary>
        /// <param name="newPiece">The map we want to change to. Should be fully loaded already.</param>
        internal static void ChangeCurrentPiece(MapPiece newPiece) {
            //Reset camera
            Camera.Offset.X = 0;
            Camera.Offset.Y = 0;
            Camera.ZoomLevel = 1;
            Camera.FixViewArea(MainWindow.instance.mapViewPanel.Size);

            //Change the piece
            MapPieceCache.ChangeCurrentPiece(newPiece);

            UpdateGUI();
        }

        /// <summary>
        /// Creates a new map and swaps GUI over to display it
        /// </summary>
        internal static void NewPiece() {
            MapPieceCache.CreateNew(34); //Blank tile
            UpdateGUI();
        }

        /// <summary>
        /// Saves the current map to file and generates a new thumbnail for it. Also refreshes the GUI in case a change was missed.
        /// </summary>
        internal static void Save() {
            MapPieceCache.CurrentPiece.Save();
            DrawThumbnail();

            if (MapPieceCache.Pieces.IndexOf(MapPieceCache.CurrentPiece) == -1) {
                MapPieceCache.Pieces.Add(MapPieceCache.CurrentPiece);
            }

            UpdateGUI();
        }

        /// <summary>
        /// Asks the user if they really want to delete the current map. It then deletes the file for the map and switches to a new blank map.
        /// </summary>
        internal static void Delete() {
            if (MessageBox.Show("Are you sure you want to delete '" + MapPieceCache.CurrentPiece.Name + "'?", "Delete?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                MapPieceCache.DeleteCurrent();
            }

            UpdateGUI();
        }

        /// <summary>
        /// Duplicates the file of the current map and then opens it as the current map.
        /// </summary>
        internal static void Duplicate() {
            MapPieceCache.Duplicate();
            UpdateGUI();
        }

        /// <summary>
        /// Zooms the map to 1/10 scale and exports a thumbnail of the full map the the /Maps/Thumbs/ folder. The thumb name is <mapname>.png
        /// </summary>
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
