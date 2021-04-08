using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common
{
    public static class MessageTypeMetrics
    {
        static Dictionary<uint, MessageTypeCharacteristics> messageMapping;
        static MessageTypeMetrics()
        {
            messageMapping = new Dictionary<uint, MessageTypeCharacteristics>()
            {
                {  0x1, new MessageTypeCharacteristics("LTE", 32) },
                {  0x2, new MessageTypeCharacteristics("Satelite", 12) },
                {  0x3, new MessageTypeCharacteristics("Log", 8) },
                {  0x4, new MessageTypeCharacteristics("Configuration", 8) },
                {  0x5, new MessageTypeCharacteristics("Unformatted 1KB Block", 32) }
            };
        }
        public static bool KnownMessageType(uint messageType)
        {
            return messageMapping.ContainsKey(messageType);
        }
        public static MessageTypeCharacteristics Characteristics(uint messageType)
        {
            return messageMapping[messageType];
        }
    }
}
