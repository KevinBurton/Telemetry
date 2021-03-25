namespace CLI.Commands.MeasurementBoard
{
    public class AdcGetOfcCommand : MeasurementBoardCommandBase
    {
        public AdcGetOfcCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
