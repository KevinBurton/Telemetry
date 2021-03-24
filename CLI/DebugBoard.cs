using System;

namespace CLI
{
    public class DebugBoard : ICLI
    {
        public DebugBoard(ICLIConnection connection)
        {
            Connection = connection;
        }

        public ICLIConnection Connection { get; }
        public ICLICommandResult Command(ICLICommand command)
        {
            if(!typeof(ICLICommand).IsAssignableFrom(typeof(IDebugBoardCommand)))
            {
                throw new ArgumentException(nameof(command));
            }
            throw new NotImplementedException();
        }
    }
}
