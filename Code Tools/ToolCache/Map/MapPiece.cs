﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;
using System.IO;
using ToolCache.General;
using ToolCache.Map.Objects;
using ToolCache.Map.Tiles;

namespace ToolCache.Map {
    public class MapPiece {
        bool _iE = false;

        public bool isEdited {
            get {
                return _iE;
            }
        }

        public bool isLoaded = false;

        public string Name = "Unnamed";
        public string Filename = "";

        public Point WorldPosition = Point.Empty;

        public List<BaseObject> Objects = new List<BaseObject>();
        public TileMap Tiles;

        public Rectangle WorldRectangle;
        public string Music = "";
        
        public MapPiece(string filename, short fillTileID) {
            Filename = filename;
            Tiles = new TileMap(this);
            Tiles.CreateMapFromNothing(fillTileID);
        }

        public void Edited() { _iE = true; }

        public void Load(Boolean loadingForUse) {
            if (!File.Exists(Filename)) return;
            
            BinaryIO f = new BinaryIO(File.ReadAllBytes(Filename));
            Name = f.GetString();
            Music = f.GetString();

            WorldPosition.X = f.GetShort();
            WorldPosition.Y = f.GetShort();

            //Exit Early
            if (!loadingForUse) {
                f.Dispose();
                return;
            }

            isLoaded = true;
            Objects = new List<BaseObject>();

            //First load the terrain
            Tiles.LoadMapFromFile(f);

            //then load the scenary
            int totalShapes = f.GetInt();

            for (int i = 0; i < totalShapes; i++) {
                short sourceID = f.GetShort();
                int locationX = f.GetInt();
                int locationY = f.GetInt();

                Objects.Add(new BaseObject(sourceID, new Point(locationX, locationY)));
            }

            f.Dispose();
        }

        public void Save() {
            BinaryIO f = new BinaryIO();

            //Save Settings
            f.AddString(Name);
            f.AddString(Music);

            f.AddShort((short)WorldPosition.X);
            f.AddShort((short)WorldPosition.Y);

            //Save terrain
            Tiles.SaveMap(f);

            //finally save the scenary
            f.AddInt(Objects.Count);

            foreach (BaseObject ps in Objects) {
                f.AddShort(ps.ObjectType);
                f.AddInt(ps.Location.X);
                f.AddInt(ps.Location.Y);
            }

            f.Encode(Filename);

            _iE = false;
        }

        internal void DeleteFile() {
            if (File.Exists(Filename)) {
                File.Delete(Filename);
            }
        }

        public void ChangeName(string p) {
            Name = p;
            Edited();
        }

        public void ChangeMusic(string p) {
            Music = p;
            Edited();
        }

        public override string ToString() {
            return Name + " (map)";
        }
    }
}
