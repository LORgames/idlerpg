using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineDebugger {
    public class NetworkLogic {
        public static void ProcessMessage(NetworkMessage msg, DebugForm form) {
            if (msg.Type == MSG.MESSAGE) {
                form.AddTrace(msg.GetString());
            } else if (msg.Type == MSG.REQUEST_VARIABLES) {
                VariableDebugHelper.IntVarValues.Clear();
                int totalInts = msg.GetInt(); while (--totalInts > 0) VariableDebugHelper.IntVarValues.Add(msg.GetInt());
                int totalStrs = msg.GetInt(); while (--totalStrs > 0) VariableDebugHelper.StrVarValues.Add(msg.GetString());
                VariableDebugHelper.RebuildForm(form);
            }
        }
    }
}
