namespace CLI.Commands.MeasurementBoard
{
    public class SatStatusCommand : MeasurementBoardCommandBase
	{
        public SatStatusCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
