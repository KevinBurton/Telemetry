namespace CLI.Commands.MeasurementBoard
{
    public class SatDisconnectCommand : MeasurementBoardCommandBase
    {
        public SatDisconnectCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
