namespace CLI.Commands.MeasurementBoard
{
    public class RtdGetFarenheitCommand : MeasurementBoardCommandBase
    {
        public RtdGetFarenheitCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
