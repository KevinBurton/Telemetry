namespace CLI.Commands.MeasurementBoard
{
    public class RtdGetKelvinCommand : MeasurementBoardCommandBase
    {
        public RtdGetKelvinCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
