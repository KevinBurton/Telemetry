namespace CLI.Commands.MeasurementBoard
{
    public class AdcReadVoltageCommand : MeasurementBoardCommandBase
    {
        public AdcReadVoltageCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
