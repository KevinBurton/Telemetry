namespace CLI.Commands.MeasurementBoard
{
    public class MdmSearchEndCommand : MeasurementBoardCommandBase
    {
        public MdmSearchEndCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
