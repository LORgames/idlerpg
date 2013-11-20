using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace ToolToGameExporter {
    public class Processor {

        internal static List<ProcessingError> Errors = new List<ProcessingError>();
        internal static List<ProcessingError> Warnings = new List<ProcessingError>();

        public static bool Go(string p, bool silent = false) {
            Thread t = new Thread(new ParameterizedThreadStart(TaskMon));

            ExportProgressForm epf = new ExportProgressForm();

            InputData d = new InputData();
            d.p = p;
            d.silent = silent;
            d.epf = epf;

            t.Start(d);

            epf.ShowDialog();

            ToolCache.General.ExportCrushers.BlankAll();

            return d.result;
        }

        private static void TaskMon(object d) {
            string p = (d as InputData).p;
            bool silent = (d as InputData).silent;
            bool result = (d as InputData).result;
            ExportProgressForm epf = (d as InputData).epf;

            Errors.Clear();

            if (Directory.Exists(Global.EXPORT_DIRECTORY)) {
                Directory.Delete(Global.EXPORT_DIRECTORY, true);
            }

            Directory.CreateDirectory(Global.EXPORT_DIRECTORY);

#if !DEBUG
            try {
#endif
                //Precrush. No Dependancies.
                UpdateEPF(epf, "Setting an Example...", 1);
                GameSettingsExporter.Go();
                UpdateEPF(epf, "Applying Diplomacy...", 2);
                FactionCrusher.Go();
                UpdateEPF(epf, "Counting Monsters...", 3);
                CritterCrusher.Precrush();
                UpdateEPF(epf, "Evaluating Projectiles...", 4);
                EffectCrusher.Precrush();
                UpdateEPF(epf, "Measuring Objects...", 5);
                MapObjectCrusher.Precrush();
                UpdateEPF(epf, "Navigating the world...", 6);
                MapCrusher.Precrush();
                UpdateEPF(epf, "Calculating Standard Deviations...", 7);
                GlobalVariableCrusher.Precrush();
                UpdateEPF(epf, "Purchasing Salves and Lotions...", 8);
                BuffCrusher.Precrush();
                UpdateEPF(epf, "Counting Coins...", 9);
                DatabaseCrusher.Precrush();

                //Tier 0  Crushing. No Dependancies.
                UpdateEPF(epf, "Amplyfying Sounds...", 10);
                SoundCrusher.Go();
                UpdateEPF(epf, "Laying Tiles...", 15);
                TileCrusher.Go();
                UpdateEPF(epf, "Entering Portals...", 20);
                PortalCrusher.Go();
                UpdateEPF(epf, "Organizing Functions... Sending Invites...", 25);
                GlobalVariableCrusher.Go();

                //Tier 1 Crushing. Tier 0 Dependancies
                UpdateEPF(epf, "Polishing Equipment...", 30);
                EquipmentCrusher.Go(); //Requires Sounds.
                UpdateEPF(epf, "Squishing Objects...", 40);
                MapObjectCrusher.Go(); //Requires Sounds
                UpdateEPF(epf, "Firing Arrows...", 50);
                EffectCrusher.Go(); //Requires Sounds
                UpdateEPF(epf, "Stocktaking Inventory...", 60);
                ItemCrusher.Go();
                UpdateEPF(epf, "Experimenting with Steroids...", 65);
                BuffCrusher.Go();

                //Tier 2 Crushing. Tier 1 Dependancies
                UpdateEPF(epf, "Breeding Critters...", 70);
                CritterCrusher.Go(); //Requires Equipment
                
                //Tier 3 Crushing. Tier 2 Depedancies
                UpdateEPF(epf, "Navigating Maps...", 80);
                MapCrusher.Go(); //Requires Portals, Tiles, Sounds and Objects. + Critters

                //Tier 4 Crushing.
                UpdateEPF(epf, "Breaking the fourth wall...", 90);
                UICrusher.Go();
                
                //Tier N Crushing. Requires everything.
                UpdateEPF(epf, "Archiving Knowledge...", 95);
                DatabaseCrusher.Go();

                UpdateEPF(epf, "Pushing Information...", 100);
                if (Directory.Exists(p)) {
                    Directory.Delete(p, true);
                }
                
                Directory.Move(Global.EXPORT_DIRECTORY, p);

                UpdateEPF(epf, "Complete", 100);
                
                if (Errors.Count == 0) {
                    if (!silent) {
                        MessageBox.Show("Exported To Data Folder");
                    }
                    ((InputData)d).result = true;
                } else {
                    FinishedDisplay fd = new FinishedDisplay("Did not export successfully. Errors:", Errors);
                    fd.ShowDialog();
                    ((InputData)d).result = false;
                }
#if !DEBUG
            } catch (Exception e) {
                if(!silent) MessageBox.Show("Please close the exporter and try again! (Some kind of caching issue occurred)\n\n"+e.Message);

                try {
                    Directory.Delete(Global.EXPORT_DIRECTORY, true);
                } catch { }

                ((InputData)d).result = false;
            }
#endif

            epf.Invoke((MethodInvoker)delegate {
                epf.Close();
            });
        }

        private static void UpdateEPF(ExportProgressForm epf, string progressLabel, int percent) {
            try {
                epf.Invoke((MethodInvoker)delegate {
                    epf.lblExportTask.Text = progressLabel;
                    epf.progress.Value = percent;
                });
            } catch {
                //DO nothing, its just in case the EPF isn't created yet.
            }
        }
    }

    internal class InputData {
        public string p;
        public bool silent;
        public bool result;
        public ExportProgressForm epf;
    }
}
