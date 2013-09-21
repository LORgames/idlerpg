using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Scripting;

namespace ToolToGameExporter {
    internal class GameSettingsExporter {
        
        public static void Go() {
            BinaryIO f = new BinaryIO();

            byte forBools = 0;
            forBools |= (byte)(GlobalSettings.TilesEnabled?1:0);
            forBools |= (byte)(GlobalSettings.CharacterDisabled?2:0);

            f.AddString(GlobalSettings.GameName);
            f.AddByte(forBools);
            f.AddShort((short)GlobalSettings.TileSize);
            f.AddShort((short)GlobalSettings.GameFPS);

            f.AddFloat(GlobalSettings.PerspectiveSkew);

            f.AddShort((short)(GlobalSettings.VariablePressedWorldX == "" ? 0 : GlobalVariables.Variables[GlobalSettings.VariablePressedWorldX].Index));
            f.AddShort((short)(GlobalSettings.VariablePressedWorldY == "" ? 0 : GlobalVariables.Variables[GlobalSettings.VariablePressedWorldY].Index));
            f.AddShort((short)(GlobalSettings.VariablePressedLocalX == "" ? 0 : GlobalVariables.Variables[GlobalSettings.VariablePressedLocalX].Index));
            f.AddShort((short)(GlobalSettings.VariablePressedLocalY == "" ? 0 : GlobalVariables.Variables[GlobalSettings.VariablePressedLocalY].Index));

            f.Encode(Global.EXPORT_DIRECTORY + "/Settings.bin");
        }
    }
}
