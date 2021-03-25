namespace CLI.Commands.MeasurementBoard
{
    public class MagMeanZCommand : MeasurementBoardCommandBase
    {
        public MagMeanZCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
