namespace CLI.Commands.MeasurementBoard
{
    public class AccelMeanZCommand : MeasurementBoardCommandBase
	{
        public AccelMeanZCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
