using System.Collections.Generic;

namespace CLI.Commands.MeasurementBoard
{
    public class AdcReadCountsCommand : MeasurementBoardCommandBase
    {
        public AdcReadCountsCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
