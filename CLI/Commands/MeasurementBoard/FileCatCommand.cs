namespace CLI.Commands.MeasurementBoard
{
    public class FileCatCommand : MeasurementBoardCommandBase
    {
        public FileCatCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
