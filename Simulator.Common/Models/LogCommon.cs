namespace Simulator.Common.Models
{
    public class LogCommon
    {
        public uint SerialNumber { get; set; }
        public byte MessageType { get; } = 3;
        public uint TimeStamp { get; set; }
    }
}
