using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ToolToGameExporter {
    public class Processor {

        public static List<ProcessingError> Errors = new List<ProcessingError>();

        public static bool Go(string p, bool silent = false) {
            Errors.Clear();

            if (Directory.Exists(Global.EXPORT_DIRECTORY)) {
                Directory.Delete(Global.EXPORT_DIRECTORY, true);
            }

            Directory.CreateDirectory(Global.EXPORT_DIRECTORY);

            //try {
                //Precrush. No Dependancies.
                CritterCrusher.Precrush();

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

                if (Errors.Count == 0) {
                    if (!silent) {
                        MessageBox.Show("Exported To Data Folder");
                    }
                    return true;
                } else {
                    FinishedDisplay fd = new FinishedDisplay("Did not export successfully. Errors:", Errors);
                    fd.ShowDialog();
                    return false;
                }
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
