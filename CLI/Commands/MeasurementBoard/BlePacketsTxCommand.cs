namespace CLI.Commands.MeasurementBoard
{
    public class BlePacketsTxCommand : MeasurementBoardCommandBase
	{
        public BlePacketsTxCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
