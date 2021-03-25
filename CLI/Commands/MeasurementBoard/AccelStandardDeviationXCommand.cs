namespace CLI.Commands.MeasurementBoard
{
    public class AccelStandardDeviationXCommand : MeasurementBoardCommandBase
	{
        public AccelStandardDeviationXCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
