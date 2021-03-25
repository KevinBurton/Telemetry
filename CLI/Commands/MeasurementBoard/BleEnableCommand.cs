namespace CLI.Commands.MeasurementBoard
{
    public class BleEnableCommand : MeasurementBoardCommandBase
	{
        public BleEnableCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
