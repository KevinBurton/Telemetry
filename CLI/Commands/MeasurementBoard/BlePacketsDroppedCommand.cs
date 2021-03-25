namespace CLI.Commands.MeasurementBoard
{
    public class BlePacketsDroppedCommand : MeasurementBoardCommandBase
	{
        public BlePacketsDroppedCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
