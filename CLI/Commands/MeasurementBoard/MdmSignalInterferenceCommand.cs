namespace CLI.Commands.MeasurementBoard
{
    public class MdmSignalInterferenceCommand : MeasurementBoardCommandBase
    {
        public MdmSignalInterferenceCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
