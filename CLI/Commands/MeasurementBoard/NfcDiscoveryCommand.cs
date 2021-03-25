namespace CLI.Commands.MeasurementBoard
{
    public class NfcDiscoveryCommand : MeasurementBoardCommandBase
    {
        public NfcDiscoveryCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
