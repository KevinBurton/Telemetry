namespace CLI.Commands.MeasurementBoard
{
    public class MdmPacketsRxCommand : MeasurementBoardCommandBase
    {
        public MdmPacketsRxCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
