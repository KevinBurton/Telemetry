namespace CLI.Commands.MeasurementBoard
{
    public class SatConnectCommand : MeasurementBoardCommandBase
    {
        public SatConnectCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
