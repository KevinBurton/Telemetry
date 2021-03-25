namespace CLI.Commands.MeasurementBoard
{
    public class BleSignalStrengthCommand : MeasurementBoardCommandBase
	{
        public BleSignalStrengthCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
