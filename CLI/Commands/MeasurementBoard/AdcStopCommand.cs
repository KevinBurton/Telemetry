namespace CLI.Commands.MeasurementBoard
{
    public class AdcStopCommand : MeasurementBoardCommandBase
    {
        public AdcStopCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
