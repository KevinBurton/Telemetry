namespace CLI.Commands.MeasurementBoard
{
    public class AdcToggleFscCommand : MeasurementBoardCommandBase
    {
        public AdcToggleFscCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
