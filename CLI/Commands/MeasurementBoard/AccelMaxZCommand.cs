namespace CLI.Commands.MeasurementBoard
{
    public class AccelMaxZCommand : MeasurementBoardCommandBase
	{
        public AccelMaxZCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
