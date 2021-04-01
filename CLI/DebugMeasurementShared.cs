using System;

namespace CLI
{
    public class CLIDacChannels
    {
        public ushort Counts { get; set; }
        public float Volts { get; set; }
    }
    public class DebugMeasurementShared
    {
        public DebugMeasurementShared()
        {
            Settings = new CLIDacChannels [2,8]
            {
                {
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels()
                },
                {
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels(),
                    new CLIDacChannels()
                }
            };
            channelIndex = 0;
            dacIndex = 0;
            DacValues = new int[2] { 0, 0, };
            ChannelValues = new int[2] { 0, 0, };
            channelRelayIndex = 0;
            dacRelayIndex = 0;
            DacRelayValues = new int[2] { 0, 0, };
            ChannelRelayValues = new int[2] { 0, 0, };
        }
        public void RelayReset()
        {
            channelRelayIndex = 0;
            dacRelayIndex = 0;
            DacRelayValues[0] = 0;
            DacRelayValues[1] = 0;
            ChannelRelayValues[0] = 0;
            ChannelRelayValues[1] = 0;
        }
        private int channelRelayIndex;
        private int dacRelayIndex;
        private int[] DacRelayValues { get; }
        private int[] ChannelRelayValues { get; }
        public int DacRelay
        {
            get
            {
                return DacRelayValues[dacRelayIndex];
            }
            set
            {
                if (value > 1) throw new ArgumentOutOfRangeException($"Allowed values for Dac are 0, 1 {value}");
                if (value == DacRelayValues[dacRelayIndex]) return;
                dacRelayIndex = dacRelayIndex == 0 ? 1 : 0;
                DacRelayValues[dacRelayIndex] = value;
            }
        }
        public int ChannelRelay
        {
            get
            {
                return ChannelRelayValues[channelRelayIndex];
            }
            set
            {
                if (value > 7 || value < 0) throw new ArgumentOutOfRangeException($"Allowed values for Channel are 0-7 {value}");
                if (value == ChannelRelayValues[channelRelayIndex]) return;
                channelRelayIndex = channelRelayIndex == 0 ? 1 : 0;
                ChannelRelayValues[channelRelayIndex] = value;
            }
        }
        public ushort GetCounts => (ushort)(Settings[DacRelayValues[0], ChannelRelayValues[0]].Counts - Settings[DacRelayValues[1], ChannelRelayValues[1]].Counts);
        public float GetVolts => Settings[DacRelayValues[0], ChannelRelayValues[0]].Volts - Settings[DacRelayValues[1], ChannelRelayValues[1]].Volts;

        private int channelIndex;
        private int dacIndex;
        private int[] DacValues { get; }
        private int[] ChannelValues { get; }
        public int Dac
        { 
            get
            {
                return DacValues[dacIndex];
            }
            set
            {
                if (value > 1) throw new ArgumentOutOfRangeException($"Allowed values for Dac are 0, 1 {value}");
                if (value == DacValues[dacIndex]) return;
                dacIndex = dacIndex == 0 ? 1 : 0;
                DacValues[dacIndex] = value;
            }
        }
        public int Channel
        {
            get
            {
                return ChannelValues[channelIndex];
            }
            set
            {
                if (value > 7 || value < 0) throw new ArgumentOutOfRangeException($"Allowed values for Channel are 0-7 {value}");
                if (value == ChannelValues[channelIndex]) return;
                channelIndex = channelIndex == 0 ? 1 : 0;
                ChannelValues[channelIndex] = value;
            }
        }
        public ushort SetCounts => (ushort)(Settings[DacValues[0], ChannelValues[0]].Counts - Settings[DacValues[1], ChannelValues[1]].Counts);
        public float SetVolts => Settings[DacValues[0], ChannelValues[0]].Volts - Settings[DacValues[1], ChannelValues[1]].Volts;
        public CLIDacChannels[,] Settings { get; }
    }
}
