namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetinterfaceFsyncCommand : MeasurementBoardCommandBase
	{
        public AdcSetinterfaceFsyncCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
