using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Critters;
using System.IO;

namespace ToolToGameExporter {
    internal class FactionCrusher {
        public static void Go() {
            Factions.SaveDatabase(); //Lets just do this in case :)

            try {
                File.Copy(Factions.FILENAME, Global.EXPORT_DIRECTORY + "/Factions.bin");
            } catch {
                Processor.Errors.Add(new ProcessingError("Factions", "All", "Could not save factions. Try opening and closing the faction editor."));
            }
        }
    }
}
