namespace CLI.Commands.MeasurementBoard
{
    public class AdcToggleSpitout_enCommand : MeasurementBoardCommandBase
    {
        public AdcToggleSpitout_enCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
