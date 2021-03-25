namespace CLI.Commands.MeasurementBoard
{
    public class BleTogglePairingCommand : MeasurementBoardCommandBase
	{
        public BleTogglePairingCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
