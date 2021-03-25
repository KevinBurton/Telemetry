namespace CLI.Commands.MeasurementBoard
{
    public class MagMeanXCommand : MeasurementBoardCommandBase
    {
        public MagMeanXCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
