using Simulator.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class SateliteViewModel : ViewModelBase
    {
        readonly Satelite _satelite;
        public SateliteViewModel(Satelite satelite)
        {
            _satelite = satelite;
        }
        public uint SerialNumber
        {
            get => _satelite.Common.SerialNumber;
            set
            {
                if (_satelite.Common.SerialNumber != value)
                {
                    _satelite.Common.SerialNumber = value;
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
            get => _satelite.Common.MessageType;
            set
            {
                if (_satelite.Common.MessageType != value)
                {
                    _satelite.Common.MessageType = value;
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
            get => _satelite.Common.TimeStamp;
            set
            {
                if (_satelite.Common.TimeStamp != value)
                {
                    _satelite.Common.TimeStamp = value;
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
            get => _satelite.Common.BatteryVoltage;
            set
            {
                if (_satelite.Common.BatteryVoltage != value)
                {
                    _satelite.Common.BatteryVoltage = value;
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
            get => _satelite.Common.FaultCodes;
            set
            {
                if (_satelite.Common.FaultCodes != value)
                {
                    _satelite.Common.FaultCodes = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("FaultCodesBitString");
                }
            }
        }
        public string FaultCodesBitString
        {
            get
            {
                return Convert.ToString((byte)(FaultCodes & 0xFF), 2).PadLeft(8, '0');
            }
        }
    }
}
