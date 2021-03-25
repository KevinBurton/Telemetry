namespace CLI.Commands.MeasurementBoard
{
    public class AccelStandardDeviationZCommand : MeasurementBoardCommandBase
	{
        public AccelStandardDeviationZCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
