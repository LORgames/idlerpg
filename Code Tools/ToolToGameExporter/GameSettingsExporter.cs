using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Scripting;
using ToolCache.Scripting.Extensions;
using ToolCache.Storage;

namespace ToolToGameExporter {
    internal class GameSettingsExporter {
        
        public static void Go() {
            BinaryIO f = new BinaryIO();

            byte forBools = 0;
            forBools |= (byte)(GlobalSettings.TilesEnabled?1:0);

            f.AddString(GlobalSettings.GameName);
            f.AddByte(forBools);
            f.AddShort((short)GlobalSettings.TileSize);
            f.AddShort((short)GlobalSettings.GameFPS);

            f.AddFloat(GlobalSettings.PerspectiveSkew);

            f.AddShort((short)(GlobalSettings.VariablePressedWorldX == "" ? 0 : Variables.GlobalVariables[GlobalSettings.VariablePressedWorldX].Index));
            f.AddShort((short)(GlobalSettings.VariablePressedWorldY == "" ? 0 : Variables.GlobalVariables[GlobalSettings.VariablePressedWorldY].Index));
            f.AddShort((short)(GlobalSettings.VariablePressedLocalX == "" ? 0 : Variables.GlobalVariables[GlobalSettings.VariablePressedLocalX].Index));
            f.AddShort((short)(GlobalSettings.VariablePressedLocalY == "" ? 0 : Variables.GlobalVariables[GlobalSettings.VariablePressedLocalY].Index));

            f.AddByte(GlobalSettings.PlayerTotal);
            f.AddByte(GlobalSettings.PlayerCritters);
            f.AddShort(GlobalSettings.PlayerTurnLength);

            f.AddString(GlobalSettings.DefaultMap);

            f.Encode(Global.EXPORT_DIRECTORY + "/Settings.bin");
        }
    }
}
