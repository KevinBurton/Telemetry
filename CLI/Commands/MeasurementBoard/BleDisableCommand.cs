namespace CLI.Commands.MeasurementBoard
{
    public class BleDisableCommand : MeasurementBoardCommandBase
	{
        public BleDisableCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
