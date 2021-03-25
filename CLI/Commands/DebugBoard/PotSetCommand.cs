namespace CLI.Commands.DebugBoard
{
    public class PotSetCommand : DebugBoardCommandBase
    {
        public PotSetCommand(float value)
        {
            Value = value;
        }

        public float Value { get; }
    }
}
