namespace CLI.Commands.MeasurementBoard
{
    public class SatSignalConnectsCommand : MeasurementBoardCommandBase
    {
        public SatSignalConnectsCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
