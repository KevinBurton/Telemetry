namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetfscCommand : MeasurementBoardCommandBase
	{
        public AdcSetfscCommand(string command, float value)
        {
            Command = command;
            Value = value;
        }
        public float Value { get; }

        public override string Command { get; }
    }
}
