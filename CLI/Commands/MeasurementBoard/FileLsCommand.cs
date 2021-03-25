namespace CLI.Commands.MeasurementBoard
{
    public class FileLsCommand : MeasurementBoardCommandBase
    {
        public FileLsCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
