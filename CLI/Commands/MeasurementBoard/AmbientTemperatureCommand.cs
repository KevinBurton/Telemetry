namespace CLI.Commands.MeasurementBoard
{
    public class AmbientTemperatureCommand : MeasurementBoardCommandBase
	{
        public AmbientTemperatureCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
