namespace CLI.Commands.MeasurementBoard
{
    public class RtcResetCommand : MeasurementBoardCommandBase
    {
        public RtcResetCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
