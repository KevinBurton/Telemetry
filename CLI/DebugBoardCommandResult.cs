using System.Linq;
using System.Collections.Generic;

namespace CLI
{
    public class DebugBoardCommandResult : ICLICommandResult
    {
        public DebugBoardCommandResult(IEnumerable<string> result)
        {
            Result = result;
        }
        public IEnumerable<string> Result { get; }
        public bool IsSuccess => Result != null && Result.Count() > 0 && Result.Last().StartsWith('.');
    }
}
