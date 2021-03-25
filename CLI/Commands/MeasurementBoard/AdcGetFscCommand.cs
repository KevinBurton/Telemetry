namespace CLI.Commands.MeasurementBoard
{
    public class AdcGetFscCommand : MeasurementBoardCommandBase
    {
        public AdcGetFscCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
