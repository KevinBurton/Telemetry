namespace CLI.Commands.MeasurementBoard
{
    public class AdcStartCommand : MeasurementBoardCommandBase
    {
        public AdcStartCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
