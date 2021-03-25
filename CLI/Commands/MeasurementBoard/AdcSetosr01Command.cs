namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetosr01Command : MeasurementBoardCommandBase
    {
        public AdcSetosr01Command(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
