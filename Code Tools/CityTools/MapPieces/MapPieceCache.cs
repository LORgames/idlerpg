using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CityTools.Core;

namespace CityTools.MapPieces {
    class MapPieceCache {
        private static MapPiece _cp = null;

        public static MapPiece CurrentPiece {
            get { return _cp; }
        }

        public static List<MapPiece> Pieces = new List<MapPiece>();

        public const string PIECES_DIRECTORY = "Pieces";

        internal static void Initialize() {
            if (!Directory.Exists(PIECES_DIRECTORY)) Directory.CreateDirectory(PIECES_DIRECTORY);
            
            String[] files = Directory.GetFiles(PIECES_DIRECTORY);

            foreach (String file in files) {
                MapPiece mp = new MapPiece(file);
                mp.Load(false);

                Pieces.Add(mp);
            }

            UpdateCombobox();

            MainWindow.instance.combo_mappieces.SelectedIndexChanged += new EventHandler(combo_mappieces_SelectedIndexChanged);
            MainWindow.instance.txtPieceName.TextChanged += new EventHandler(txtPieceName_TextChanged);

            MainWindow.instance.btnMapSizeChange.Click += new EventHandler(mapSize_TextChanged);

            CreateNew();
        }

        static void mapSize_TextChanged(object sender, EventArgs e) {
            int w = 0;
            int h = 0;

            int.TryParse(MainWindow.instance.txtMapSizeX.Text, out w);
            int.TryParse(MainWindow.instance.txtMapSizeY.Text, out h);

            if (w <= 0 || h <= 0) {
                MessageBox.Show("Cannot have 0 for width or height.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                Terrain.MapCache.TerrainChangeSizeTo(w, h);
            }
        }

        static void txtPieceName_TextChanged(object sender, EventArgs e) {
            CurrentPiece.Name = MainWindow.instance.txtPieceName.Text;
        }

        static void combo_mappieces_SelectedIndexChanged(object sender, EventArgs e) {
            SaveIfRequired();

            if (MainWindow.instance.combo_mappieces.SelectedIndex >= 0 && MainWindow.instance.combo_mappieces.SelectedIndex < Pieces.Count) {
                ChangeCurrentPiece(Pieces[MainWindow.instance.combo_mappieces.SelectedIndex]);
            }
        }

        internal static void DeleteCurrent() {
            CurrentPiece.DeleteFile();
            UpdateCombobox();

            CreateNew();
        }

        internal static void SaveIfRequired() {
            if (CurrentPiece == null) return;

            if (CurrentPiece.isEdited && MessageBox.Show("Do you want to save your current changes?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                CurrentPiece.Save();
            } else if(CurrentPiece.isLoaded) {
                CurrentPiece.Load(true);
            }
        }

        internal static void CreateNew() {
            SaveIfRequired();

            ChangeCurrentPiece(new MapPiece(GetNextFilename()));

            UpdateTextField();
        }

        internal static void UpdateCombobox() {
            MainWindow.instance.combo_mappieces.Items.Clear();

            foreach (MapPiece mp in Pieces) {
                MainWindow.instance.combo_mappieces.Items.Add(mp.Name);
            }
        }

        internal static void UpdateTextField() {
            MainWindow.instance.txtPieceName.Text = CurrentPiece.Name;
            MainWindow.instance.lblFilename.Text = CurrentPiece.Filename;
        }

        internal static void ChangeCurrentPiece(MapPiece newPiece) {
            SaveIfRequired();

            Camera.Offset.X = 0;
            Camera.Offset.Y = 0;
            Camera.ZoomLevel = 1;
            Camera.FixViewArea(MainWindow.instance.mapViewPanel.DisplayRectangle);

            Box2D.B2System.Initialize();
            newPiece.Load(true);

            _cp = newPiece;

            UpdateTextField();
        }

        internal static void Duplicate() {
            MapPieceCache.SaveIfRequired();
            File.Copy(CurrentPiece.Filename, GetNextFilename());
        }

        internal static string GetNextFilename() {
            String[] files = Directory.GetFiles(PIECES_DIRECTORY, Environment.UserName + ".*");
            Array.Sort(files, new SortFilenames());

            if (files.Length > 0) {
                string fs = files[files.Length - 1];
                fs = fs.Split('.')[1];

                return PIECES_DIRECTORY + "/" + Environment.UserName + "." + (int.Parse(fs) + 1);
            } else {
                return PIECES_DIRECTORY + "/" + Environment.UserName + ".0";
            }
        }
    }

    class SortFilenames : IComparer<string> {
        public int Compare(string x, string y) {
            if (int.Parse(x.Split('.')[1]) > int.Parse(y.Split('.')[1])) return 1;
            else if (int.Parse(x.Split('.')[1]) < int.Parse(y.Split('.')[1])) return -1;
            else return 0;
        }
    }
}
