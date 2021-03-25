namespace CLI.Commands.MeasurementBoard
{
    public class MdmDisableCommand : MeasurementBoardCommandBase
    {
        public MdmDisableCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
