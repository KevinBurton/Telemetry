namespace CLI.Commands.MeasurementBoard
{
    public class FileRmCommand : MeasurementBoardCommandBase
    {
        public FileRmCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
