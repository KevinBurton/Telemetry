namespace CLI.Commands.MeasurementBoard
{
    public class MdmSearchStartCommand : MeasurementBoardCommandBase
    {
        public MdmSearchStartCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
