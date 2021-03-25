namespace CLI.Commands.MeasurementBoard
{
    public class BleSignalInterferenceCommand : MeasurementBoardCommandBase
	{
        public BleSignalInterferenceCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
