namespace CLI.Commands.MeasurementBoard
{
    public class AdcGetModesCommand : MeasurementBoardCommandBase
    {
        public AdcGetModesCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
