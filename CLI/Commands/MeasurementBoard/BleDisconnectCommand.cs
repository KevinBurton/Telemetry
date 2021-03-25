namespace CLI.Commands.MeasurementBoard
{
    public class BleDisconnectCommand : MeasurementBoardCommandBase
	{
        public BleDisconnectCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
