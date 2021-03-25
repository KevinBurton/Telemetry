namespace CLI.Commands.MeasurementBoard
{
    public class SatIdCommand : MeasurementBoardCommandBase
    {
        public SatIdCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
