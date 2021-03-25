namespace CLI.Commands.MeasurementBoard
{
    public class AdcSethrOCommand : MeasurementBoardCommandBase
	{
        public AdcSethrOCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
