namespace CLI.Commands.MeasurementBoard
{
    public class MagStandardDeviationYCommand : MeasurementBoardCommandBase
    {
        public MagStandardDeviationYCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
