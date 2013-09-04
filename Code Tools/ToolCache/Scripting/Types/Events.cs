using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    /// <summary>
    /// A list of the events
    /// </summary>
    enum ValidEvents {
        Attack = 0x0000,
        Press = 0x0000,
        Spawn = 0x0001,
        Attacked = 0x0002,
        Use = 0x0003,
        Equip = 0x0004,
        OnEnter = 0x0004,
        MinionDied = 0x0005,
        AnimationEnded = 0x0006,
        OnExit = 0x0006,
        StartMoving = 0x0007,
        EndMoving = 0x0008,
        Died = 0x0009,
        Update = 0x000A,
        OnTrigger = 0x000B
    }
}
