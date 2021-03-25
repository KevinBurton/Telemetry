using System;

namespace CLI.Commands
{
    public class DebugBoardCommandBase : IDebugBoardCommand
    {
        public ICLICommandResult Do(ICLIConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
