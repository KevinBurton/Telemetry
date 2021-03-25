namespace CLI.Commands.MeasurementBoard
{
    public class AccelMeasureZCommand : MeasurementBoardCommandBase
	{
        public AccelMeasureZCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
