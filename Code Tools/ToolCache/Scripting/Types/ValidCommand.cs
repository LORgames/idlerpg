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

            if (myParams.Length == 0) {
                throw new Exception("0x" + CommandID.ToString("X4") + " cannot have no parametres, if its empty, use Param.Void!");
            }

            //Do some checking :)
            MaximumParams = myParams.Length;
            MinimumParams = MaximumParams;

            for (int i = 0; i < MaximumParams; i++) {
                if (myParams.Length > 1 && myParams[i] == Param.Void) {
                    throw new Exception("0x" + CommandID.ToString("X4") + " Param.Void must be the only Parameter!");
                }

                if ((myParams[i] & Param.Optional) == Param.Optional) {
                    if (MinimumParams > i) {
                        MinimumParams = i;
                    }
                } else if (MinimumParams < i) {
                    throw new Exception("0x" + CommandID.ToString("X4") + " OPTIONAL PARAMS MUST GO AFTER NON-OPTIONAL ONES Command=" + CommandID.ToString());
                }
            }
        }
    }
}
