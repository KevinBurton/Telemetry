namespace CLI.Commands.DebugBoard
{
    public class DacSetCountCommand : DebugBoardCommandBase
    {
        public DacSetCountCommand(int dac, int dacChannel, int value)
        {
            Dac = dac;
            DacChannel = dacChannel;
            Value = value;
        }

        public int Dac { get; }
        public int DacChannel { get; }
        public int Value { get; }
    }
}
