namespace CLI.Commands.MeasurementBoard
{
    public class BleToggleBroadcastCommand : MeasurementBoardCommandBase
	{
        public BleToggleBroadcastCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
