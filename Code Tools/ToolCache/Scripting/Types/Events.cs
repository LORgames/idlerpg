using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    /// <summary>
    /// A list of the events
    /// </summary>
    enum ValidEvents {
        Attack = 0x00,
        Press = 0x00,
        Spawn = 0x01,
        Attacked = 0x02,
        Use = 0x03,
        PressAndDrag = 0x03,
        Equip = 0x04,
        OnEnter = 0x04,
        MinionDied = 0x05,
        AnimationEnded = 0x06,
        OnExit = 0x06,
        StartMoving = 0x07,
        EndMoving = 0x08,
        Died = 0x09,
        Update = 0x0A,
        OnTrigger = 0x0B,
        AIEvent = 0x0C
    }

    /// <summary>
    /// A list of possible AIEvents
    /// </summary>
    enum AIEvents {
        TargetDied = 0x00,
        TargetOutOfRange = 0x01,
        TargetUntargetable = 0x02,
        AttackedByNonTarget = 0x03,
        OwnerChanged = 0x04,
        FactionChanged = 0x05
    }

    public class EventsHelper {
        public static Dictionary<string, ushort> ScriptEvents = new Dictionary<string, ushort>();
        public static Dictionary<string, ushort> AIScriptEvents = new Dictionary<string, ushort>();

        internal static void Initialize() {
            ScriptEvents.Clear();
            AIScriptEvents.Clear();

            //Process ValidEvents
            Array x = Enum.GetValues(typeof(ValidEvents));
            String[] s = Enum.GetNames(typeof(ValidEvents));
            for (var i = 0; i < x.Length; i++) {
                ValidEvents ait = (ValidEvents)x.GetValue(i);
                string name = s[i];
                ScriptEvents.Add(name.ToLower(), (ushort)ait);
            }

            //Process AIEvents
            x = Enum.GetValues(typeof(AIEvents));
            foreach (AIEvents ait in x) {
                string name = ait.ToString();
                AIScriptEvents.Add(name.ToLower(), (ushort)ait);
            }
        }
    }
}
