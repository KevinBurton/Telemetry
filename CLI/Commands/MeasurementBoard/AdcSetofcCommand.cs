namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetofcCommand : MeasurementBoardCommandBase
	{
        public AdcSetofcCommand(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public AdcSetofcCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
