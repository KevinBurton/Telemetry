namespace CLI.Commands.MeasurementBoard
{
    public class MagMaxYCommand : MeasurementBoardCommandBase
    {
        public MagMaxYCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
