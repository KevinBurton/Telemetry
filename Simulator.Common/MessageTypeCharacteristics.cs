namespace Simulator.Common
{
    public class MessageTypeCharacteristics
    {
        public MessageTypeCharacteristics(string description, int headerLength)
        {
            Description = description;
            HeaderLength = headerLength;
        }
        public string Description { get; }
        public int HeaderLength { get; }
    }
}
