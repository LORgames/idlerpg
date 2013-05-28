using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Scripting;

namespace CityTools.Components {
    public class ScriptInfoArgs : EventArgs {

        public ScriptInfo Info;

        public ScriptInfoArgs(ScriptInfo info) {
            Info = info;
        }

    }
}
