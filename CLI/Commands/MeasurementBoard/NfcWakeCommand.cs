namespace CLI.Commands.MeasurementBoard
{
    public class NfcWakeCommand : MeasurementBoardCommandBase
    {
        public NfcWakeCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
