namespace CLI.Commands.MeasurementBoard
{
    public class RtdGetResistanceCommand : MeasurementBoardCommandBase
    {
        public RtdGetResistanceCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
