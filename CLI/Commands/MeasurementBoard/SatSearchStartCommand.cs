namespace CLI.Commands.MeasurementBoard
{
    public class SatSearchStartCommand : MeasurementBoardCommandBase
    {
        public SatSearchStartCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
