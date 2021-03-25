using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class MeasurementBoardCommandResult : ICLICommandResult
    {
        public MeasurementBoardCommandResult(string result)
        {
            Result = result;
        }
        public string Result { get; }
    }
}
