namespace CLI.Commands.MeasurementBoard
{
    public class MagStandardDeviationXCommand : MeasurementBoardCommandBase
    {
        public MagStandardDeviationXCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
