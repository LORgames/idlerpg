using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineDebugger {
    class Logger {
        public static void Log(DebugForm form, string message) {
            form.AddTrace("[DEBUGGER] " + message);
        }
    }
}
