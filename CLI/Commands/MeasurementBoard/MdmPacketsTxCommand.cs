namespace CLI.Commands.MeasurementBoard
{
    public class MdmPacketsTxCommand : MeasurementBoardCommandBase
    {
        public MdmPacketsTxCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
