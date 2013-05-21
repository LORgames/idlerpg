using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ToolToGameExporter {
    public class Processor {

        public static List<String> Errors = new List<string>();

        public static bool Go(string p, bool silent = false) {
            Errors.Clear();

            if (Directory.Exists(Global.EXPORT_DIRECTORY)) {
                Directory.Delete(Global.EXPORT_DIRECTORY, true);
            }

            Directory.CreateDirectory(Global.EXPORT_DIRECTORY);

            //try {
                //Tier 0  Crushing. No Dependancies.
                SoundCrusher.Go();
                ObjectCrusher.Go();
                TileCrusher.Go();
                PortalCrusher.Go();

                //Tier 1 Crushing. Tier 0 Dependancies
                EquipmentCrusher.Go(); //Requires Sounds.
                
                //Tier 2 Crushing. Tier 1 Dependancies
                CritterCrusher.Go(); //Requires Equipment

                //Tier 3 Crushing. Tier 2 Depedancies
                MapCrusher.Go(); //Requires Portals, Tiles, Sounds and Objects. + Critters

                if (Directory.Exists(p)) {
                    Directory.Delete(p, true);
                }
                
                Directory.Move(Global.EXPORT_DIRECTORY, p);
                
                if(!silent) MessageBox.Show("Exported To The Data Folder");
                
                string ss = "";
                
                foreach (String error in Errors) {
                    ss += error + "\n";
                }
                
                if(ss != "") MessageBox.Show(ss);
                
                return true;
            /*} catch {
                if(!silent) MessageBox.Show("Please close the exporter and try again! (Some kind of caching issue occurred)");

                try {
                    Directory.Delete(Global.EXPORT_DIRECTORY, true);
                } catch { }

                return false;
            }*/
        }
    }
}
