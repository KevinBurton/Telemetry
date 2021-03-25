namespace CLI.Commands.MeasurementBoard
{
    public class NfcSendCommand : MeasurementBoardCommandBase
    {
        public NfcSendCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
