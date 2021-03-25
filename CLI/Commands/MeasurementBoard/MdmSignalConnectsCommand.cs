namespace CLI.Commands.MeasurementBoard
{
    public class MdmSignalConnectsCommand : MeasurementBoardCommandBase
    {
        public MdmSignalConnectsCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
