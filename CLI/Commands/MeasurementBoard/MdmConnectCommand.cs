namespace CLI.Commands.MeasurementBoard
{
    public class MdmConnectCommand : MeasurementBoardCommandBase
    {
        public MdmConnectCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
