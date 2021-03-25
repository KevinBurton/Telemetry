namespace CLI.Commands.MeasurementBoard
{
    public class FileCpCommand : MeasurementBoardCommandBase
    {
        public FileCpCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
