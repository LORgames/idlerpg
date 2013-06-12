using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting {
    enum ValidEvents {
        Attack = 0x0000,
        Spawn = 0x0001,
        Attacked = 0x0002,
        Use = 0x0003,
        Equip = 0x0004,
        MinionDied = 0x0005,
        AnimationEnded = 0x0006,
        StartMoving = 0x0007,
        EndMoving = 0x0008
    }

    enum ValidTypes {
        Critter = 0xA000,
        Enemy = 0xA001,
        Attackable = 0xA002,
        Ally = 0xA003
    }
}
