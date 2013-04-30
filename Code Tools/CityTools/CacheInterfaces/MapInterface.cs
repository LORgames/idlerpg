using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using CityTools.Core;
using System.Windows.Forms;
using ToolCache.Map.Tiles;

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
            MainWindow.instance.DrawThumbnail();

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
    }
}
