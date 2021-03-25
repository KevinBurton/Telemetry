namespace CLI.Commands.MeasurementBoard
{
    public class AdcToggleCrcbCommand : MeasurementBoardCommandBase
    {
        public AdcToggleCrcbCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
