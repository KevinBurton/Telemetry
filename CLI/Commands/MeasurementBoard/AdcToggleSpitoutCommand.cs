namespace CLI.Commands.MeasurementBoard
{
    public class AdcToggleSpitoutCommand : MeasurementBoardCommandBase
    {
        public AdcToggleSpitoutCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
