namespace CLI.Commands.MeasurementBoard
{
    public class MagCalibrateCommand : MeasurementBoardCommandBase
    {
        public MagCalibrateCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
