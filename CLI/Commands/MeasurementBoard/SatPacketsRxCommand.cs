namespace CLI.Commands.MeasurementBoard
{
    public class SatPacketsRxCommand : MeasurementBoardCommandBase
    {
        public SatPacketsRxCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
