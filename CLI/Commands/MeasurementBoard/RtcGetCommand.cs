namespace CLI.Commands.MeasurementBoard
{
    public class RtcGetCommand : MeasurementBoardCommandBase
    {
        public RtcGetCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
