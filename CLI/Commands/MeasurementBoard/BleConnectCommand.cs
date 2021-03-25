namespace CLI.Commands.MeasurementBoard
{
    public class BleConnectCommand : MeasurementBoardCommandBase
	{
        public BleConnectCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
