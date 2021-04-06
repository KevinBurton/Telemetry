namespace Simulator.Common.Models
{
    public class ConfigCommon
    {
        public uint SerialNumber { get; set; }
        public byte MessageType { get; } = 4;
        public uint EffectiveTimeStamp { get; set; }
    }
}
