namespace Simulator.Common.Models
{
    public class UnformattedCommon
    {
        public uint SerialNumber { get; set; }
        public byte MessageType { get; } = 5;
        public uint TimeStamp { get; set; }
    }
}
