namespace CLI.Commands.MeasurementBoard
{
    public class MdmHelpCommand : MeasurementBoardCommandBase
    {
        public MdmHelpCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
