using System.Collections.Generic;
using System.Linq;

namespace CLI
{
    public class MeasurementBoardCommandResult : ICLICommandResult
    {
        public MeasurementBoardCommandResult(IEnumerable<string> result)
        {
            Result = result;
        }
        public IEnumerable<string> Result { get; }
        public bool IsSuccess => Result != null && Result.Count() > 0 && Result.Last().StartsWith('.');
    }
}
