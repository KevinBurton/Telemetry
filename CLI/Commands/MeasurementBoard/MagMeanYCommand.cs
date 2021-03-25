namespace CLI.Commands.MeasurementBoard
{
    public class MagMeanYCommand : MeasurementBoardCommandBase
    {
        public MagMeanYCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
