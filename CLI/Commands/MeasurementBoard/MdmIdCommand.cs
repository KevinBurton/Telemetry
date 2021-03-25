namespace CLI.Commands.MeasurementBoard
{
    public class MdmIdCommand : MeasurementBoardCommandBase
    {
        public MdmIdCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
