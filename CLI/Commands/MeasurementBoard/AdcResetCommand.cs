namespace CLI.Commands.MeasurementBoard
{
    public class AdcResetCommand : MeasurementBoardCommandBase
    {
        public AdcResetCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
