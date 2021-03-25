namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetosr10Command : MeasurementBoardCommandBase
    {
        public AdcSetosr10Command(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
