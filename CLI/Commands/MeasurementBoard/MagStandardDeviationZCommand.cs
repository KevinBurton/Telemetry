namespace CLI.Commands.MeasurementBoard
{
    public class MagStandardDeviationZCommand : MeasurementBoardCommandBase
    {
        public MagStandardDeviationZCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
