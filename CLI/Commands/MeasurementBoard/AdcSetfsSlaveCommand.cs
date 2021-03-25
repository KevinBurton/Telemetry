namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetfsSlaveCommand : MeasurementBoardCommandBase
	{
        public AdcSetfsSlaveCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
