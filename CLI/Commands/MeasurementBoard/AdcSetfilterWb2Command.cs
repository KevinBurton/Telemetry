namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetfilterWb2Command : MeasurementBoardCommandBase
	{
        public AdcSetfilterWb2Command(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
