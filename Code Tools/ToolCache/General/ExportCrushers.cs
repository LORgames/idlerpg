using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;

namespace ToolCache.General {
    public class ExportCrushers {
        public static MapPiece CurrentMap;
        public static Dictionary<string, short> RemappedEquipmentIDs;
        public static Dictionary<string, short> RemappedEffectIDs;
        public static Dictionary<string, short> RemappedObjectIDs;

        public static Dictionary<string, short> MusicConversions = new Dictionary<string, short>();
        public static Dictionary<string, short> AmbienceConversions = new Dictionary<string, short>();
        public static Dictionary<string, short> RemappedSoundEffectIDs;
        public static Dictionary<string, short> RemappedSoundEffectGroups;

        public static Dictionary<string, short> RemappedCritterIDs;
        public static Dictionary<string, short> RemappedMapIDs;
        public static Dictionary<string, short> RemappedFunctionIDs;
        public static Dictionary<string, short> RemappedDatabaseNames;
    }
}
