namespace CLI.Commands.MeasurementBoard
{
    public class AccelStandardDeviationYCommand : MeasurementBoardCommandBase
	{
        public AccelStandardDeviationYCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
