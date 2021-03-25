namespace CLI.Commands.MeasurementBoard
{
    public class FileFindCommand : MeasurementBoardCommandBase
    {
        public FileFindCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
