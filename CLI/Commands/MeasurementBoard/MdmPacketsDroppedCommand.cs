namespace CLI.Commands.MeasurementBoard
{
    public class MdmPacketsDroppedCommand : MeasurementBoardCommandBase
    {
        public MdmPacketsDroppedCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
