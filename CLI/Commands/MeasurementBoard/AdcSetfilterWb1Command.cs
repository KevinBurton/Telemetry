using System.Collections.Generic;

namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetfilterWb1Command : MeasurementBoardCommandBase
	{
        public AdcSetfilterWb1Command(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
