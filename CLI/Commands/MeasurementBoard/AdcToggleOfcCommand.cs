namespace CLI.Commands.MeasurementBoard
{
    public class AdcToggleOfcCommand : MeasurementBoardCommandBase
    {
        public AdcToggleOfcCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
