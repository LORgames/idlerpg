using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ToolCache.Map.Tiles;

namespace ToolCache.Map {
    public class MapPieceCache {
        private static MapPiece _cp = null;
        private const short DefaultTileID = 34;

        public static MapPiece CurrentPiece {
            get { return _cp; }
        }

        internal static List<MapPiece> _p = new List<MapPiece>();
        public static List<MapPiece> Pieces {
            get { return _p; }
        }

        internal const string PIECES_DIRECTORY = "Maps";

        public static void Initialize() {
            if (!Directory.Exists(PIECES_DIRECTORY)) Directory.CreateDirectory(PIECES_DIRECTORY);

            //Load all the files in (get the map names especially)
            String[] files = Directory.GetFiles(PIECES_DIRECTORY);

            foreach (String file in files) {
                MapPiece mp = new MapPiece(file, 0);
                mp.Load(false);

                _p.Add(mp);
            }

            //Create a new map
            CreateNew(DefaultTileID);
        }

        public static void DeleteCurrent() {
            CurrentPiece.DeleteFile();
            CreateNew(DefaultTileID);
        }

        public static void SaveIfRequired() {
            if (CurrentPiece == null) return;

            if (CurrentPiece.isEdited && MessageBox.Show("Do you want to save your current changes?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                CurrentPiece.Save();
            } else if(CurrentPiece.isLoaded) {
                CurrentPiece.Load(true);
            }
        }

        public static void CreateNew (short fillTileID) {
            SaveIfRequired();
            ChangeCurrentPiece(new MapPiece(GetNextFilename(), fillTileID));
        }

        public static void ChangeCurrentPiece(MapPiece newPiece) {
            SaveIfRequired();
            _cp = newPiece;
            newPiece.Load(true);
        }

        public static void Duplicate() {
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
