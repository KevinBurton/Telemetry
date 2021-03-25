using System;

namespace CLI.Commands
{
    public class MeasurementBoardCommandBase : IMeasurementBoardCommand
    {
        public ICLICommandResult Do(ICLIConnection connection)
        {
            connection.Send(this.Command);
            //return connection.Read();
            return new MeasurementBoardCommandResult(this.Command);
        }
        public virtual string Command
        {
            get => string.Empty;
        }
    }
}
