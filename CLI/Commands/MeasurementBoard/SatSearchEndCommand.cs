namespace CLI.Commands.MeasurementBoard
{
    public class SatSearchEndCommand : MeasurementBoardCommandBase
    {
        public SatSearchEndCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
