namespace CLI.Commands.MeasurementBoard
{
    public class MdmDisconnectCommand : MeasurementBoardCommandBase
    {
        public MdmDisconnectCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
