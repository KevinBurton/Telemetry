namespace CLI.Commands.MeasurementBoard
{
    public class MdmEnableCommand : MeasurementBoardCommandBase
    {
        public MdmEnableCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
