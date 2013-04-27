using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ToolToGameExporter {
    public class Processor {
        public static bool Go(string p, bool silent = false) {
            if (Directory.Exists(Global.EXPORT_DIRECTORY)) {
                Directory.Delete(Global.EXPORT_DIRECTORY, true);
            }

            Directory.CreateDirectory(Global.EXPORT_DIRECTORY);

            //try {
                ObjectCrusher.Go();
                TileCrusher.Go();
                MapCrusher.Go();
                EquipmentCrusher.Go();

                if (Directory.Exists(p)) {
                    Directory.Delete(p, true);
                }

                Directory.Move(Global.EXPORT_DIRECTORY, p);

                if(!silent) MessageBox.Show("Exported To The Data Folder");
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
