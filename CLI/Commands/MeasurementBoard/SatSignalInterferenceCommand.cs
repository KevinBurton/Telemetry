namespace CLI.Commands.MeasurementBoard
{
    public class SatSignalInterferenceCommand : MeasurementBoardCommandBase
	{
        public SatSignalInterferenceCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
