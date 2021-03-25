namespace CLI.Commands.MeasurementBoard
{
    public class AccelCalibrateCommand : MeasurementBoardCommandBase
    {
        public AccelCalibrateCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
