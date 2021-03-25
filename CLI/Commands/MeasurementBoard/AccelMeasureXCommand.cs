namespace CLI.Commands.MeasurementBoard
{
    public class AccelMeasureXCommand : MeasurementBoardCommandBase
	{
        public AccelMeasureXCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
