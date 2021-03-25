namespace CLI.Commands.MeasurementBoard
{
    public class RtdHelpCommand : MeasurementBoardCommandBase
    {
        public RtdHelpCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
