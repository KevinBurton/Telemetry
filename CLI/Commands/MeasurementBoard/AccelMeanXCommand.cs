namespace CLI.Commands.MeasurementBoard
{
    public class AccelMeanXCommand : MeasurementBoardCommandBase
	{
        public AccelMeanXCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
