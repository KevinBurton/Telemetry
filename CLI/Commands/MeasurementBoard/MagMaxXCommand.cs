namespace CLI.Commands.MeasurementBoard
{
    public class MagMaxXCommand : MeasurementBoardCommandBase
    {
        public MagMaxXCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
