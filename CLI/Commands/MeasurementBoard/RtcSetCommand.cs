namespace CLI.Commands.MeasurementBoard
{
    public class RtcSetCommand : MeasurementBoardCommandBase
    {
        public RtcSetCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
