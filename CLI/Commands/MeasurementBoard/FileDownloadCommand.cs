namespace CLI.Commands.MeasurementBoard
{
    public class FileDownloadCommand : MeasurementBoardCommandBase
    {
        public FileDownloadCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
