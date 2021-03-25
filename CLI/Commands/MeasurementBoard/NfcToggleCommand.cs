namespace CLI.Commands.MeasurementBoard
{
    public class NfcToggleCommand : MeasurementBoardCommandBase
    {
        public NfcToggleCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
