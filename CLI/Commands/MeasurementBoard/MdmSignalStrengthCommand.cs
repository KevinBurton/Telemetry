namespace CLI.Commands.MeasurementBoard
{
    public class MdmSignalStrengthCommand : MeasurementBoardCommandBase
    {
        public MdmSignalStrengthCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
