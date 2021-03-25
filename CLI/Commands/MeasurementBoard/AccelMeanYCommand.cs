namespace CLI.Commands.MeasurementBoard
{
    public class AccelMeanYCommand : MeasurementBoardCommandBase
	{
        public AccelMeanYCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
