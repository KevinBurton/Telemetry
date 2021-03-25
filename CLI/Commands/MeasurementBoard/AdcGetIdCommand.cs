namespace CLI.Commands.MeasurementBoard
{
    public class AdcGetIdCommand : MeasurementBoardCommandBase
    {
        public AdcGetIdCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
