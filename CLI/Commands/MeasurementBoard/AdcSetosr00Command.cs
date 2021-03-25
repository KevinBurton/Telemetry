namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetosr00Command : MeasurementBoardCommandBase
    {
        public AdcSetosr00Command(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
