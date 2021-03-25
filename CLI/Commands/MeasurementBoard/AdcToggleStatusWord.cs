namespace CLI.Commands.MeasurementBoard
{
    public class AdcToggleStatusWord : MeasurementBoardCommandBase
    {
        public AdcToggleStatusWord(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
