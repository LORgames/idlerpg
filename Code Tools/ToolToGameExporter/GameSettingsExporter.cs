using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolToGameExporter {
    internal class GameSettingsExporter {
        
        public static void Go() {
            BinaryIO f = new BinaryIO();

            byte forBools = 0;
            forBools |= (byte)(GlobalSettings.enableTiles?1:0);
            forBools |= (byte)(GlobalSettings.disableCharacter?2:0);

            f.AddString(GlobalSettings.gameName);
            f.AddByte(forBools);
            f.AddShort((short)GlobalSettings.tileSize);
            f.AddShort((short)GlobalSettings.targetGameFPS);

            f.AddFloat(GlobalSettings.perspectiveSkew);

            f.Encode(Global.EXPORT_DIRECTORY + "/Settings.bin");
        }
    }
}
