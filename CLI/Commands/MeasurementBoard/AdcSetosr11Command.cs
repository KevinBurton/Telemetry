namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetosr11Command : MeasurementBoardCommandBase
    {
        public AdcSetosr11Command(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
