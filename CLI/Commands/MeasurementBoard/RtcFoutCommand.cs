namespace CLI.Commands.MeasurementBoard
{
    public class RtcFoutCommand : MeasurementBoardCommandBase
    {
        public RtcFoutCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
