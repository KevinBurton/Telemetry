using System.Collections.Generic;

namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetfsMasterCommand : MeasurementBoardCommandBase
	{
        public AdcSetfsMasterCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
