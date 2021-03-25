namespace CLI.Commands.MeasurementBoard
{
    public class FileUploadCommand : MeasurementBoardCommandBase
    {
        public FileUploadCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
