namespace CLI.Commands.MeasurementBoard
{
    public class AdcSethrOffCommand : MeasurementBoardCommandBase
    {
        public AdcSethrOffCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
