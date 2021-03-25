namespace CLI.Commands.MeasurementBoard
{
    public class MagMaxZCommand : MeasurementBoardCommandBase
    {
        public MagMaxZCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
