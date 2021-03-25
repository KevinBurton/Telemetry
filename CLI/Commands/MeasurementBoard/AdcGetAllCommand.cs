using System.Collections.Generic;

namespace CLI.Commands.MeasurementBoard
{
    public class AdcGetAllCommand : MeasurementBoardCommandBase
	{
        public AdcGetAllCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
