namespace CLI.Commands.MeasurementBoard
{
    public class NfcDisableCommand : MeasurementBoardCommandBase
    {
        public NfcDisableCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
