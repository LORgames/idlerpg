﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CityTools.Core;
using System.Windows.Forms;
using CityTools.Physics;
using System.Drawing;

namespace CityTools.ObjectSystem {
    public class ScenicObjectCache {
        public const string SCENIC_DATABASE = Program.CACHE;
        public const string SCENIC_TYPEFILE = SCENIC_DATABASE + "scenic_types.bin";

        private static int _highestTypeIndex = 0;

        public static Dictionary<int, ScenicType> s_objectTypes = new Dictionary<int, ScenicType>();
        public static Dictionary<string, int> s_StringToInt = new Dictionary<string, int>();
        
        public static void InitializeCache() {
            if (!Directory.Exists(SCENIC_DATABASE)) {
                Directory.CreateDirectory(SCENIC_DATABASE);
            }

            // Load object types from file
            if (File.Exists(SCENIC_TYPEFILE)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(SCENIC_TYPEFILE));

                int totalShapes = f.GetInt();
                _highestTypeIndex = f.GetInt();
                int totalShapesWithPhysics = f.GetInt();

                //This is where we load the BASIC information
                for (int i = 0; i < totalShapes; i++) {
                    int type_id = f.GetInt();
                    string source = f.GetString();
                    byte layer = f.GetByte();

                    s_objectTypes.Add(type_id, new ScenicType(type_id, source, layer));
                    s_StringToInt.Add(source, type_id);
                }

                //Now we load the PHYSICS information (yes quite expensive looping twice but much more backwards compatible
                for (int i = 0; i < totalShapesWithPhysics; i++) {
                    int type_id = f.GetInt();
                    int totalPhysics = f.GetInt();

                    for (int j = 0; j < totalPhysics; j++) {
                        int shapeType = f.GetByte();

                        float xPos = f.GetFloat();
                        float yPos = f.GetFloat();

                        switch ((PhysicsShapes)shapeType) {
                            case PhysicsShapes.Circle:
                                float r = f.GetFloat();
                                s_objectTypes[type_id].Physics.Add(new PhysicsCircle(new RectangleF(xPos, yPos, r, 0), false));
                                break;
                            case PhysicsShapes.Rectangle:
                                float w = f.GetFloat();
                                float h = f.GetFloat();
                                s_objectTypes[type_id].Physics.Add(new PhysicsRectangle(new RectangleF(xPos, yPos, w, h), false));
                                break;
                            case PhysicsShapes.Edge:
                                float xPos2 = f.GetFloat();
                                float yPos2 = f.GetFloat();
                                s_objectTypes[type_id].Physics.Add(new PhysicsEdge(new RectangleF(new PointF(xPos, yPos), new SizeF(xPos2, yPos2)), false));
                                break;
                            default:
                                MessageBox.Show("Unknown shape found in file. Suspected corruption. Formatting C:");
                                break;
                        }
                    }
                }
            }

            //Scan for new objects
            foreach (string filename in Directory.GetFiles(Components.ObjectCacheControl.OBJECT_CACHE_FOLDER, "*.png", SearchOption.AllDirectories)) {
                if (!ImageCache.HasCached(filename)) {
                    _highestTypeIndex++;
                    s_objectTypes.Add(_highestTypeIndex, new ScenicType(_highestTypeIndex, filename, 0));
                    s_StringToInt.Add(filename, _highestTypeIndex);
                }
            }
        }

        public static void SaveTypes() {
            //Count physics objects first...
            List<int> objectsWithPhysics = new List<int>();

            foreach (KeyValuePair<int, ScenicType> kvp in s_objectTypes) {
                if (kvp.Value.Physics.Count > 0) {
                    objectsWithPhysics.Add(kvp.Key);
                }
            }

            BinaryIO f = new BinaryIO();
            f.AddInt(s_objectTypes.Count);
            f.AddInt(_highestTypeIndex);
            f.AddInt(objectsWithPhysics.Count); //total shapes with physics

            foreach (KeyValuePair<int, ScenicType> kvp in s_objectTypes) {
                f.AddInt(kvp.Key);
                f.AddString(kvp.Value.ImageName);
                f.AddByte(kvp.Value.layer);
            }

            //Now we load the PHYSICS information (yes quite expensive looping twice but much more backwards compatible
            foreach (int index in objectsWithPhysics) {
                f.AddInt(index);
                f.AddInt(s_objectTypes[index].Physics.Count);

                foreach (PhysicsShape ps in s_objectTypes[index].Physics) {
                    f.AddByte((byte)ps.myShape);

                    switch (ps.myShape) {
                        case PhysicsShapes.Circle:

                            f.AddFloat(ps.aabb.Left);
                            f.AddFloat(ps.aabb.Top);
                            f.AddFloat(ps.aabb.Width);
                            break;
                        case PhysicsShapes.Rectangle:

                            f.AddFloat(ps.aabb.Left);
                            f.AddFloat(ps.aabb.Top);
                            f.AddFloat(ps.aabb.Width);
                            f.AddFloat(ps.aabb.Height);
                            break;
                        case PhysicsShapes.Edge:
                            PhysicsEdge pe = ps as PhysicsEdge;
                            f.AddFloat(pe.p0.X);
                            f.AddFloat(pe.p0.Y);
                            f.AddFloat(pe.p1.X);
                            f.AddFloat(pe.p1.Y);
                            break;
                        default:
                            MessageBox.Show("Unknown shape found in file. Suspected corruption. Formatting C:");
                            break;
                    }
                }
            }

            f.Encode(SCENIC_TYPEFILE);
        }
    }
}
