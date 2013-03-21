using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CityTools.ObjectSystem;
using CityTools.Places;
using CityTools.Physics;
using CityTools.Core;
using System.Drawing;
using System.Collections.ObjectModel;
using System.IO;

namespace CityTools.MapPieces {
    class MapPiece {
        bool _iE = false;

        public bool isEdited {
            get {
                if (MainWindow.instance.txtPieceName.Text != Name) {
                    return true;
                }

                return _iE;
            }
        }

        public bool isLoaded = false;

        public string Name = "Unnamed";
        public string Filename = "";

        public List<ScenicObject> Scenary = new List<ScenicObject>();
        public List<PlacesObject> Places = new List<PlacesObject>();
        public List<PhysicsShape> Physics = new List<PhysicsShape>();

        public MapPiece(string filename) {
            Filename = filename;
        }

        public void Edited() { _iE = true; }

        public void Load() {
            if (!File.Exists(Filename)) return;

            Scenary = new List<ScenicObject>();
            Places = new List<PlacesObject>();
            Physics = new List<PhysicsShape>();

            isLoaded = true;
            BinaryIO f = new BinaryIO(File.ReadAllBytes(Filename));

            Name = f.GetString();

            //First load the scenary
            int totalShapes = f.GetInt();

            for (int i = 0; i < totalShapes; i++) {
                int sourceID = f.GetInt();
                float locationX = f.GetFloat();
                float locationY = f.GetFloat();
                int rotation = f.GetInt();

                Scenary.Add(new ScenicObject(sourceID, new PointF(locationX, locationY), rotation));
            }

            //Now load the physics
            totalShapes = f.GetInt();

            for (int i = 0; i < totalShapes; i++) {
                int shapeType = f.GetInt();

                if (shapeType == (int)PhysicsShapes.Rectangle) {
                    float r0 = f.GetFloat();
                    float r1 = f.GetFloat();
                    float r2 = f.GetFloat();
                    float r3 = f.GetFloat();

                    Physics.Add(new PhysicsRectangle(new System.Drawing.RectangleF(r0, r1, r2, r3), true));
                } else if (shapeType == (int)PhysicsShapes.Circle) {
                    float r0 = f.GetFloat();
                    float r1 = f.GetFloat();
                    float r2 = f.GetFloat();

                    Physics.Add(new PhysicsCircle(new System.Drawing.RectangleF(r0, r1, r2, r2), true));
                } else if (shapeType == (int)PhysicsShapes.Edge) {
                    float r0 = f.GetFloat();
                    float r1 = f.GetFloat();
                    float r2 = f.GetFloat();
                    float r3 = f.GetFloat();

                    Physics.Add(new PhysicsEdge(new System.Drawing.RectangleF(r0, r1, r2, r3), true));
                }
            }

            //And finally places
            totalShapes = f.GetInt();

            for (int i = 0; i < totalShapes; i++) {
                int sourceID = f.GetInt();
                float locationX = f.GetFloat();
                float locationY = f.GetFloat();
                int rotation = f.GetInt();

                Places.Add(new PlacesObject(sourceID, new System.Drawing.PointF(locationX, locationY), rotation, false));
            }

            //And terrain last
            Terrain.MapCache.LoadMapFromFile(f);

            f.Dispose();
        }

        public void Save() {
            BinaryIO f = new BinaryIO();

            f.AddString(Name);

            //First save the scenary
            f.AddInt(Scenary.Count);

            foreach (ScenicObject ps in Scenary) {
                f.AddInt(ps.object_index);
                f.AddFloat(ps.baseBody.Position.X);
                f.AddFloat(ps.baseBody.Position.Y);
                f.AddInt(ps.angle);
            }

            //Now save physics
            f.AddInt(Physics.Count);

            foreach (PhysicsShape ps in Physics) {
                f.AddInt((int)ps.myShape);

                if (ps.myShape == PhysicsShapes.Rectangle) {
                    f.AddFloat(ps.aabb.Left);
                    f.AddFloat(ps.aabb.Top);
                    f.AddFloat(ps.aabb.Width);
                    f.AddFloat(ps.aabb.Height);
                } else if (ps.myShape == PhysicsShapes.Circle) {
                    f.AddFloat(ps.aabb.Left);
                    f.AddFloat(ps.aabb.Top);
                    f.AddFloat(ps.aabb.Width);
                } else if (ps.myShape == PhysicsShapes.Edge) {
                    f.AddFloat((ps as PhysicsEdge).p0.X);
                    f.AddFloat((ps as PhysicsEdge).p0.Y);
                    f.AddFloat((ps as PhysicsEdge).p1.X);
                    f.AddFloat((ps as PhysicsEdge).p1.Y);
                }
            }

            //And save places
            f.AddInt(Places.Count);

            foreach (PlacesObject ps in Places) {
                f.AddInt(ps.object_index);
                f.AddFloat(ps.baseBody.Position.X);
                f.AddFloat(ps.baseBody.Position.Y);
                f.AddInt(ps.angle);
            }

            //And finally terrain
            Terrain.MapCache.SaveMap(f);

            f.Encode(Filename);

            MapPieceCache.UpdateCombobox();

            _iE = false;
        }

        internal void DeleteFile() {
            if (File.Exists(Filename)) {
                File.Delete(Filename);
            }
        }
    }
}
