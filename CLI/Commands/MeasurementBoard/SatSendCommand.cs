namespace CLI.Commands.MeasurementBoard
{
    public class SatSendCommand : MeasurementBoardCommandBase
    {
        public SatSendCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
