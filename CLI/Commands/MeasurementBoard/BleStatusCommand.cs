namespace CLI.Commands.MeasurementBoard
{
    public class BleStatusCommand : MeasurementBoardCommandBase
	{
        public BleStatusCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
