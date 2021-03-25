namespace CLI.Commands.DebugBoard
{
    public class DacSetVoltCommand : DebugBoardCommandBase
    {
        public DacSetVoltCommand(int dac, int dacChannel, float value)
        {
            Dac = dac;
            DacChannel = dacChannel;
            Value = value;
        }

        public int Dac { get; }
        public int DacChannel { get; }
        public float Value { get; }
    }
}
