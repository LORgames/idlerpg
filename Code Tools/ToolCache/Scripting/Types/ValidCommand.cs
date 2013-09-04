using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    public struct ValidCommand {
        public ushort CommandID;
        public Param[] ExpectedParameters;

        public int MinimumParams;
        public int MaximumParams;

        public ValidCommand(ushort cID, Param[] myParams) {
            CommandID = cID;
            ExpectedParameters = myParams;

            //Do some checking :)
            MaximumParams = myParams.Length;
            MinimumParams = MaximumParams;

            for (int i = 0; i < MaximumParams; i++) {
                if ((myParams[i] | Param.Optional) == Param.Optional) {
                    if (MinimumParams >= i) {
                        MinimumParams = i - 1;
                    } else {
                        throw new Exception("OPTIONAL PARAMS MUST GO AFTER NON-OPTIONAL ONES Command=" + CommandID.ToString());
                    }
                }
            }
        }
    }
}
