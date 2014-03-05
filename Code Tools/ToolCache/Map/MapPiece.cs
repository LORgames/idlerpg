using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;
using System.IO;
using ToolCache.General;
using ToolCache.Map.Objects;
using ToolCache.Map.Tiles;
using ToolCache.Map.Regions;
using ToolCache.Map.Background;
using ToolCache.Storage;

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
        public string Script = "";

        public Point WorldPosition = Point.Empty;

        public List<BaseObject> Objects = new List<BaseObject>();
        public TileMap Tiles;

        //Region informations
        public List<Portal> Portals = new List<Portal>();
        public List<SpawnRegion> Spawns = new List<SpawnRegion>();
        public List<ScriptRegion> ScriptRegions = new List<ScriptRegion>();

        public RectangleX WorldRectangle;
        public string Music = "";

        public IBackground Background = new SolidBackground(Color.CornflowerBlue);
        
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

            Portals.Clear();
            short totalPortals = f.GetByte();
            while (--totalPortals > -1) {
                Map.Regions.Portals.LoadPortal(this, f);
            }

            //Exit Early
            if (!loadingForUse) {
                f.Dispose();
                return;
            }

            isLoaded = true;
            Objects = new List<BaseObject>();
            Spawns = new List<SpawnRegion>();
            ScriptRegions = new List<ScriptRegion>();

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

            //Now load the critters
            if (!f.IsEndOfFile()) {
                int totalTerritories = f.GetShort();

                while (--totalTerritories > -1) {
                    Spawns.Add(SpawnRegion.LoadFromBinaryIO(f));
                }
            }

            //Background information
            if (!f.IsEndOfFile()) {
                if ((BackgroundTypes)f.GetByte() == BackgroundTypes.Solid) {
                    Background = new SolidBackground(f);
                }
            }

            //Scripting information
            if (!f.IsEndOfFile()) {
                Script = f.GetString();
            }

            //Scripting region information
            if (!f.IsEndOfFile()) {
                int totalTerritories = f.GetShort();

                while (--totalTerritories > -1) {
                    ScriptRegions.Add(ScriptRegion.LoadFromBinaryIO(f));
                }
            }

            f.Dispose();
        }

        public void Save() {
            BinaryIO f = new BinaryIO();

            //Save Settings
            f.AddString(Name);
            f.AddString(Music);

            //Some shorts for the position in the world editor
            f.AddShort((short)WorldPosition.X);
            f.AddShort((short)WorldPosition.Y);

            //Save the portals
            f.AddByte((byte)Portals.Count);
            foreach (Portal p in Portals) {
                p.Save(f);
            }

            //Save terrain
            Tiles.SaveMap(f);

            //finally save the objects
            f.AddInt(Objects.Count);

            foreach (BaseObject ps in Objects) {
                f.AddShort(ps.ObjectType);
                f.AddInt(ps.Location.X);
                f.AddInt(ps.Location.Y);
            }

            //Now save the critters
            f.AddShort((short)Spawns.Count);
            foreach (SpawnRegion spawn in Spawns) {
                spawn.SaveToBinaryIO(f);
            }

            //Save background information
            Background.SaveToBinary(f);

            //And save the script
            f.AddString(Script);

            //Append the script regions
            f.AddShort((short)ScriptRegions.Count);
            foreach (ScriptRegion scriptR in ScriptRegions) {
                scriptR.SaveToBinaryIO(f);
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
            string OldName = Name;
            Name = p;

            string OldFilename = Filename;
            Filename = ".\\Maps\\" + p + ".map";

            if (File.Exists(OldFilename)) {
                File.Move(OldFilename, Filename);
            }

            if (File.Exists(".\\Maps\\Thumbs\\" + OldName + ".png")) {
                File.Move(".\\Maps\\Thumbs\\" + OldName + ".png", ".\\Maps\\Thumbs\\" + p + ".png");
            }

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
