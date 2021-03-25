namespace CLI.Commands.MeasurementBoard
{
    public class AccelMeasureYCommand : MeasurementBoardCommandBase
	{
        public AccelMeasureYCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
