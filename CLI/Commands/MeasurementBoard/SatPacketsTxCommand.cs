namespace CLI.Commands.MeasurementBoard
{
    public class SatPacketsTxCommand : MeasurementBoardCommandBase
    {
        public SatPacketsTxCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
