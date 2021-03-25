namespace CLI.Commands.MeasurementBoard
{
    public class SatEnableCommand : MeasurementBoardCommandBase
    {
        public SatEnableCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
