namespace CLI.Commands.MeasurementBoard
{
    public class BlePacketsRxCommand : MeasurementBoardCommandBase
	{
        public BlePacketsRxCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
