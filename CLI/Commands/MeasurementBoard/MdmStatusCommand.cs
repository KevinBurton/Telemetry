namespace CLI.Commands.MeasurementBoard
{
    public class MdmStatusCommand : MeasurementBoardCommandBase
    {
        public MdmStatusCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
