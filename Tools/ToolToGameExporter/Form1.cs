using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using System.IO;
using CityTools.Core;
using CityTools.Physics;

namespace ToolToGameExporter {
    public partial class Form1 : Form {
        public const float PHYSICS_SCALE = 10.0f;

        Dictionary<int, int> remappedKeysForPlaces = new Dictionary<int, int>();  // <old, new>
        Dictionary<int, int> remappedKeysForScenary = new Dictionary<int, int>();  // <old, new>

        public Form1() {
            InitializeComponent();
        }

        private void tool_btn_Click(object sender, EventArgs e) {
            folderBrowserDialog1.ShowDialog();
            tool_loc_TB.Text = folderBrowserDialog1.SelectedPath;
        }

        private void game_btn_Click(object sender, EventArgs e) {
            folderBrowserDialog1.ShowDialog();
            game_loc_TB.Text = folderBrowserDialog1.SelectedPath;
        }

        private void convert_btn_Click(object sender, EventArgs e) {
            if (!File.Exists(GetGameLibZip())) {
                MessageBox.Show("The game content library does not exist. Did you select the correct folder?"); return;
            }

            ZipFile zip = new ZipFile(GetGameLibZip());

            //OBJECT CONVERSION
            try { zip.RemoveEntry("scenic.cache"); } catch { }
            OptimizeAndAddObjectLayer(zip);

            //PLACES CONVERSION
            try { zip.RemoveEntry("places.cache"); } catch { }
            OptimizeAndAddPlaces(zip);

            //PIECES COPYING
            AddMapPieces(zip);

            //SAVE IT OUT
            while (true) {
                try {
                    zip.Save();
                    MessageBox.Show("Saved successfully!");
                    break;
                } catch {
                    MessageBox.Show("Please close the zip and then click OK");
                }
            }
        }

        private void OptimizeAndAddObjectLayer(ZipFile zp) {
            ClearOutOldObjects(zp);

            BinaryIO f = new BinaryIO(File.ReadAllBytes(GetScenicTypes()));
            BinaryIO o = new BinaryIO();

            int totalShapes = f.GetInt();
            f.GetInt(); //Just need to clear this value :)
            int totalPhysicsShapes = f.GetInt();

            o.AddInt(totalShapes);
            o.AddInt(totalPhysicsShapes);

            Dictionary<int, string> typeID_to_filename = new Dictionary<int, string>();

            int previousKey = 0;

            for (int i = 0; i < totalShapes; i++) {
                int type_id = f.GetInt();
                string source = f.GetString();
                byte layer = f.GetByte();

                remappedKeysForScenary.Add(type_id, previousKey);

                zp.AddEntry("obj/" + previousKey + ".png", File.ReadAllBytes(tool_loc_TB.Text + source));

                typeID_to_filename.Add(type_id, source);

                o.AddByte(layer);

                previousKey++;
            }

            for (int i = 0; i < totalPhysicsShapes; i++) {
                int typeID = f.GetInt();

                o.AddInt(remappedKeysForScenary[typeID]);

                int totalPhysics = f.GetInt();
                o.AddInt(totalPhysics);

                Image im = Image.FromFile(tool_loc_TB.Text + typeID_to_filename[typeID]);

                for (int j = 0; j < totalPhysics; j++) {
                    byte shapeType = f.GetByte();

                    o.AddByte(shapeType);

                    //This needs to be converted to the center rather than the extents.
                    float xPos = f.GetFloat(); //xPos
                    float yPos = f.GetFloat(); //yPos

                    float wDim = f.GetFloat();
                    float hDim = wDim;

                    if((PhysicsShapes)shapeType == PhysicsShapes.Rectangle) {
                        hDim = f.GetFloat();
                    } else if ((PhysicsShapes)shapeType == PhysicsShapes.Edge) {
                        hDim = f.GetFloat();
                    }

                    if ((PhysicsShapes)shapeType != PhysicsShapes.Edge) {
                        xPos += (wDim - im.Width) / 2;
                        yPos += (hDim - im.Height) / 2;
                        wDim /= 2; // Game uses radial w and h
                        hDim /= 2;
                    } else {
                        xPos -= im.Width / 2;
                        yPos -= im.Height / 2;
                        wDim -= im.Width / 2;
                        hDim -= im.Height / 2;
                    }

                    o.AddFloat(xPos / PHYSICS_SCALE);
                    o.AddFloat(yPos / PHYSICS_SCALE);
                    o.AddFloat(wDim / PHYSICS_SCALE);
                    o.AddFloat(hDim / PHYSICS_SCALE);
                }

                im.Dispose();
            }

            f.Dispose();

            zp.AddEntry("scenic.cache", o.EncodedBytes());

            o.Dispose();
        }

        private void ClearOutOldObjects(ZipFile zp) {
            string[] files = new string[zp.EntryFileNames.Count];
            zp.EntryFileNames.CopyTo(files, 0);

            foreach (string entry in files) {
                if (entry.Substring(0, 4) == "obj/" && entry.Length > 6) {
                    zp.RemoveEntry(entry);
                }
            }
        }

        private void OptimizeAndAddPlaces(ZipFile zp) {
            ClearOutOldPlaces(zp);

            BinaryIO f = new BinaryIO(File.ReadAllBytes(GetPlacesTypes()));
            BinaryIO o = new BinaryIO();

            int totalShapes = f.GetInt();
            f.GetInt(); //Just need to clear this value :)

            o.AddInt(totalShapes);

            int previousKey = 0;

            for (int i = 0; i < totalShapes; i++) {
                int type_id = f.GetInt();
                string source = f.GetString();

                remappedKeysForPlaces.Add(type_id, previousKey);

                zp.AddEntry("Places/" + previousKey + ".png", File.ReadAllBytes(tool_loc_TB.Text + source));

                int startLoc = source.LastIndexOf('\\');
                int endLoc = source.LastIndexOf('.');

                string triggerName = source.Substring(startLoc+1, endLoc-startLoc-1);

                o.AddString(triggerName); //Trigger name

                previousKey++;
            }

            zp.AddEntry("places.cache", o.EncodedBytes());

            f.Dispose();
            o.Dispose();
        }

        private void ClearOutOldPlaces(ZipFile zp) {
            string[] files = new string[zp.EntryFileNames.Count];
            zp.EntryFileNames.CopyTo(files, 0);

            foreach (string entry in files) {
                if (entry.Length > 8 && entry.Substring(0, 7) == "Places/") {
                    zp.RemoveEntry(entry);
                }
            }
        }

        private void AddMapPieces(ZipFile zp) {
            string[] files = new string[zp.EntryFileNames.Count];
            zp.EntryFileNames.CopyTo(files, 0);

            foreach (string entry in files) {
                if (entry.Substring(0, 6) == "world/" && entry.Length > 6) {
                    zp.RemoveEntry(entry);
                }

                if (entry == "start.platform") {
                    zp.RemoveEntry("start.platform");
                }
            }

            int previousKey = 0;

            foreach (string file in Directory.GetFiles(GetToolMapPiecesLoc())) {
                if (file != GetToolMapPiecesLoc() + "Home.0") {
                    ProcessMapPiece(file, "world/" + previousKey, zp);
                } else {
                    ProcessMapPiece(file, "start.platform", zp);
                }

                previousKey++;
            }
        }

        private void ProcessMapPiece(string filename, string zipID, ZipFile zp) {
            string f2 = filename.Split('/')[5];

            BinaryIO f = new BinaryIO(File.ReadAllBytes(GetToolMapPiecesLoc() + f2));
            BinaryIO o = new BinaryIO();

            f.GetString(); //Strip Name

            //First load the scenary
            int totalShapes = f.GetInt();
            o.AddShort((short)totalShapes);

            for (int i = 0; i < totalShapes; i++) {
                o.AddShort((short)remappedKeysForScenary[f.GetInt()]);
                o.AddFloat(f.GetFloat());
                o.AddFloat(f.GetFloat());
                o.AddInt(f.GetInt());
            }

            //Now load the physics
            totalShapes = f.GetInt();
            o.AddShort((short)totalShapes);

            for (int i = 0; i < totalShapes; i++) {
                int shapeType = f.GetInt();
                o.AddByte((byte)shapeType);

                o.AddFloat(f.GetFloat());
                o.AddFloat(f.GetFloat());
                o.AddFloat(f.GetFloat());

                if (shapeType != (int)PhysicsShapes.Circle) {
                    o.AddFloat(f.GetFloat());
                }
            }

            //And finally places
            totalShapes = f.GetInt();
            o.AddShort((short)totalShapes);

            for (int i = 0; i < totalShapes; i++) {
                o.AddShort((short)remappedKeysForPlaces[f.GetInt()]);
                o.AddFloat(f.GetFloat());
                o.AddFloat(f.GetFloat());
                o.AddInt(f.GetInt());
            }

            zp.AddEntry(zipID, o.EncodedBytes());

            f.Dispose();
            o.Dispose();
        }

        //Game files
        private string GetGameLibZip() { return game_loc_TB.Text + "//lib//default.zip"; }

        //Tool folders
        private string GetToolCacheLoc() { return tool_loc_TB.Text + "//cache//"; }
        private string GetObjCacheLoc() { return tool_loc_TB.Text + "//objcache//"; }
        private string GetToolMapPiecesLoc() { return tool_loc_TB.Text + "//Pieces//"; }

        //Tool files
        private string GetScenicTypes() { return GetToolCacheLoc() + "scenic_types.bin"; }
        private string GetPlacesTypes() { return GetToolCacheLoc() + "places_types.bin"; }
    }
}
