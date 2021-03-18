using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class SateliteCommonViewModel : ViewModelBase
    {
        public SateliteCommon Common { get; }
        public SateliteCommonViewModel(SateliteCommon common)
        {
            Common = common;
        }
        public uint SerialNumber
        {
            get => Common.SerialNumber;
            set
            {
                if (Common.SerialNumber != value)
                {
                    Common.SerialNumber = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("SerialNumberBitString");
                }
            }
        }
        public string SerialNumberBitString
        {
            get
            {
                return Convert.ToString((uint)(SerialNumber & 0xFFFFFF), 2).PadLeft(24, '0');
            }
        }
        public byte MessageType
        {
            get => Common.MessageType;
            set
            {
                if (Common.MessageType != value)
                {
                    Common.MessageType = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("MessageTypeBitString");
                }
            }
        }
        public string MessageTypeBitString
        {
            get
            {
                return Convert.ToString((byte)(MessageType & 0xFFFF), 2).PadLeft(8, '0');
            }
        }
        public uint TimeStamp
        {
            get => Common.TimeStamp;
            set
            {
                if (Common.TimeStamp != value)
                {
                    Common.TimeStamp = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("TimeStampBitString");
                }
            }
        }
        public string TimeStampBitString
        {
            get
            {
                return Convert.ToString((uint)(TimeStamp & 0xFFFFFF), 2).PadLeft(24, '0');
            }
        }
        public byte BatteryVoltage
        {
            get => Common.BatteryVoltage;
            set
            {
                if (Common.BatteryVoltage != value)
                {
                    Common.BatteryVoltage = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("BatteryVoltageBitString");
                }
            }
        }
        public string BatteryVoltageBitString
        {
            get
            {
                return Convert.ToString((byte)(BatteryVoltage & 0xF), 2).PadLeft(4, '0');
            }
        }
        public byte FaultCodes
        {
            get => Common.FaultCodes;
            set
            {
                if (Common.FaultCodes != value)
                {
                    Common.FaultCodes = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("FaultCodesBitString1");
                    RaisePropertyChanged("FaultCodesBitString2");
                }
            }
        }
        public string FaultCodesBitString1
        {
            get
            {
                return Convert.ToString((byte)((FaultCodes & 0xF0)>>4), 2).PadLeft(4, '0');
            }
        }
        public string FaultCodesBitString2
        {
            get
            {
                return Convert.ToString((byte)(FaultCodes & 0x0F), 2).PadLeft(4, '0');
            }
        }
    }
}
