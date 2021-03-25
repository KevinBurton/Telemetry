namespace CLI.Commands.MeasurementBoard
{
    public class SatSignalStrengthCommand : MeasurementBoardCommandBase
	{
        public SatSignalStrengthCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
