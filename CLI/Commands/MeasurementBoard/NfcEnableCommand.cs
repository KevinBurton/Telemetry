namespace CLI.Commands.MeasurementBoard
{
    public class NfcEnableCommand : MeasurementBoardCommandBase
    {
        public NfcEnableCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
