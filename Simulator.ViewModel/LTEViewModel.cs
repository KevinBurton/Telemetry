using Simulator.Common.DataProviders;
using Simulator.Common.Models;
using System;

namespace Simulator.ViewModel
{
    public class LTEViewModel : ViewModelBase
    {
        private readonly LTE _lte;
        private readonly ILTEDataProvider _lteDataProvider;
        public LTEViewModel(LTE lte, ILTEDataProvider lteDataProvider)
        {
            _lte = lte;
            _lteDataProvider = lteDataProvider;
        }
        public uint SerialNumber
        {
            get => _lte.SerialNumber;
            set
            {
                if (_lte.SerialNumber != value)
                {
                    _lte.SerialNumber = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MessageType
        {
            get => _lte.MessageType;
            set
            {
                if (_lte.MessageType != value)
                {
                    _lte.MessageType = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint TimeStamp
        {
            get => _lte.TimeStamp;
            set
            {
                if (_lte.TimeStamp != value)
                {
                    _lte.TimeStamp = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FWMajorRev
        {
            get => _lte.FWMajorRev;
            set
            {
                if (_lte.FWMajorRev != value)
                {
                    _lte.FWMajorRev = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FWMinorRev
        {
            get => _lte.FWMinorRev;
            set
            {
                if (_lte.FWMinorRev != value)
                {
                    _lte.FWMinorRev = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FWBuild
        {
            get => _lte.FWBuild;
            set
            {
                if (_lte.FWBuild != value)
                {
                    _lte.FWBuild = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte ModemFWMajor
        {
            get => _lte.ModemFWMajor;
            set
            {
                if (_lte.ModemFWMajor != value)
                {
                    _lte.ModemFWMajor = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte ModemFWMinor
        {
            get => _lte.ModemFWMinor;
            set
            {
                if (_lte.ModemFWMinor != value)
                {
                    _lte.ModemFWMinor = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte ModemFWBuild
        {
            get => _lte.ModemFWBuild;
            set
            {
                if (_lte.ModemFWBuild != value)
                {
                    _lte.ModemFWBuild = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte LTEConnectionFailureStatus
        {
            get => _lte.LTEConnectionFailureStatus;
            set
            {
                if (_lte.LTEConnectionFailureStatus != value)
                {
                    _lte.LTEConnectionFailureStatus = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte UnloadsFailureStatus
        {
            get => _lte.UnloadsFailureStatus;
            set
            {
                if (_lte.UnloadsFailureStatus != value)
                {
                    _lte.UnloadsFailureStatus = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte GetMailboxFailureStatus
        {
            get => _lte.GetMailboxFailureStatus;
            set
            {
                if (_lte.GetMailboxFailureStatus != value)
                {
                    _lte.GetMailboxFailureStatus = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte GetFirmwareFailureStatus
        {
            get => _lte.GetFirmwareFailureStatus;
            set
            {
                if (_lte.GetFirmwareFailureStatus != value)
                {
                    _lte.GetFirmwareFailureStatus = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public ushort BatteryVoltage
        {
            get => _lte.BatteryVoltage;
            set
            {
                if (_lte.BatteryVoltage != value)
                {
                    _lte.BatteryVoltage = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public ushort RMSModemCurrent
        {
            get => _lte.RMSModemCurrent;
            set
            {
                if (_lte.RMSModemCurrent != value)
                {
                    _lte.RMSModemCurrent = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public ushort PeakModemCurrent
        {
            get => _lte.PeakModemCurrent;
            set
            {
                if (_lte.PeakModemCurrent != value)
                {
                    _lte.PeakModemCurrent = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte TSMFW
        {
            get => _lte.TSMFW;
            set
            {
                if (_lte.TSMFW != value)
                {
                    _lte.TSMFW = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MODFW
        {
            get => _lte.MODFW;
            set
            {
                if (_lte.MODFW != value)
                {
                    _lte.MODFW = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FaultCodes
        {
            get => _lte.FaultCodes;
            set
            {
                if (_lte.FaultCodes != value)
                {
                    _lte.FaultCodes = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint[] Measurements
        {
            get => _lte.Measurements;
            set
            {
                if (_lte.Measurements != value)
                {
                    _lte.Measurements = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
    }
}
