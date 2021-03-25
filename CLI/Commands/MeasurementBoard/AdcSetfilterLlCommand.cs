namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetfilterLlCommand : MeasurementBoardCommandBase
	{
        public AdcSetfilterLlCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
