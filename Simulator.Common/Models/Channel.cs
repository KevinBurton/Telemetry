using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Common.Models
{
    public class Channel
    {
        private Channel(int dac, int dacChannel, string measurementChannelName, string measurementChannelShortName)
        {
            Dac = dac;
            DacChannel = dacChannel;
            MeasurementChannelName = measurementChannelName;
            MeasurementChannelShortName = measurementChannelShortName;
        }

        public int Dac { get; }
        public int DacChannel { get; }
        public string MeasurementChannelName { get; }
        public string MeasurementChannelShortName { get; }

        public static Channel[] Channels = new Channel[]
        {
            new Channel(0, 0, "Struct 1", "s1"),
            new Channel(0, 1,"Struct 2", "s2"),
            new Channel(0, 2,"Prot Coupon 1", "pc1"),
            new Channel(0, 3,"Native Coupon", "nc"),
            new Channel(0, 4,"AC Coupon", "acc"),
            new Channel(0, 5,"Prot Coupon", "pc2"),
            new Channel(0, 6,"Aux2 +", "aux2_pos"),
            new Channel(0, 7,"Aux2 -", "aux2_neg"),

            new Channel(1, 0,"Internal Shunt +", "ishnt_pos"),
            new Channel(1, 1,"Internal Shunt-", "ishnt_neg"),
            new Channel(1, 2,"Reference 1", "ref1"),
            new Channel(1, 3,"Reference 2", "ref2"),
            new Channel(1, 4,"PCR +", "pcr_pos"),
            new Channel(1, 5,"PCR -", "pcr_neg"),
            new Channel(1, 6,"External Shunt +", "eshnt_pos"),
            new Channel(1, 7,"External Shunt -", "eshnt_neg")
        };
        public Channel[] ByDac(int dac)
        {
            return Channels.Where(c => c.Dac == dac).ToArray();
        }
    }
}
