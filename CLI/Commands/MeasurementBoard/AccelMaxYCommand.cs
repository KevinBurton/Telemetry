namespace CLI.Commands.MeasurementBoard
{
    public class AccelMaxYCommand : MeasurementBoardCommandBase
	{
        public AccelMaxYCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
