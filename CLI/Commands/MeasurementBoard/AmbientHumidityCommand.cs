namespace CLI.Commands.MeasurementBoard
{
    public class AmbientHumidityCommand : MeasurementBoardCommandBase
	{
        public AmbientHumidityCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
