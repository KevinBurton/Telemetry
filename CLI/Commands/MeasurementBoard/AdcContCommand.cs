using System.Collections.Generic;

namespace CLI.Commands.MeasurementBoard
{
    public class AdcContCommand : MeasurementBoardCommandBase
	{
        public AdcContCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
