using System.Collections.Generic;

namespace CLI
{
    public interface ICLICommandResult
    {
        IEnumerable<string> Result { get; }
        bool IsSuccess { get; }
    }
}
