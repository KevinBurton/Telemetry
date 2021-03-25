namespace CLI.Commands.MeasurementBoard
{
    public class AdcSetInterfaceSpiCommand : MeasurementBoardCommandBase
    {
        public AdcSetInterfaceSpiCommand(string command)
        {
            Command = command;
        }
        public override string Command { get; }
    }
}
