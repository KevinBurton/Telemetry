using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class DebugBoardCommandResult : ICLICommandResult
    {
        public DebugBoardCommandResult(string result)
        {
            Result = result;
        }
        public string Result { get; }
    }
}
