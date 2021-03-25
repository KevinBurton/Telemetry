namespace CLI.Commands.MeasurementBoard
{
    public class AdcGetConfigCommand : MeasurementBoardCommandBase
	{
        public AdcGetConfigCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
