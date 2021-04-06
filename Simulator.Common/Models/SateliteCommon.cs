namespace Simulator.Common.Models
{
    public class SateliteCommon
    {
        public uint SerialNumber { get; set; }
        public byte MessageType { get; } = 2;
        public uint TimeStamp { get; set; }
        public byte BatteryVoltage { get; set; }
        public byte FaultCodes { get; set; }
    }
}
