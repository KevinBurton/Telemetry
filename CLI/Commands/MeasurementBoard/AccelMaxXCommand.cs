using System.Collections.Generic;

namespace CLI.Commands.MeasurementBoard
{
    public class AccelMaxXCommand : MeasurementBoardCommandBase
	{
        public AccelMaxXCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
