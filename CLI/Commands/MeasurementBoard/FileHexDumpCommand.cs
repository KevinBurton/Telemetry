namespace CLI.Commands.MeasurementBoard
{
    public class FileHexDumpCommand : MeasurementBoardCommandBase
    {
        public FileHexDumpCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
