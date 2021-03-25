namespace CLI.Commands.MeasurementBoard
{
    public class SatPacketsDroppedCommand : MeasurementBoardCommandBase
    {
        public SatPacketsDroppedCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
