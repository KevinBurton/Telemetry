namespace CLI.Commands.MeasurementBoard
{
    public class NfcGetCommand : MeasurementBoardCommandBase
    {
        public NfcGetCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
