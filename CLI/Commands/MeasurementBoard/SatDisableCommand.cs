namespace CLI.Commands.MeasurementBoard
{
    public class SatDisableCommand : MeasurementBoardCommandBase
	{
        public SatDisableCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
