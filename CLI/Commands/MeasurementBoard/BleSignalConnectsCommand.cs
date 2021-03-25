namespace CLI.Commands.MeasurementBoard
{
    public class BleSignalConnectsCommand : MeasurementBoardCommandBase
	{
        public BleSignalConnectsCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
