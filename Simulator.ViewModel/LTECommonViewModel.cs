using Simulator.Common.DataProviders;
using Simulator.Common.Models;

namespace Simulator.ViewModel
{
    public class LTECommonViewModel : ViewModelBase
    {
        private readonly LTECommon _lteCommon;
        private readonly ILTECommonDataProvider _lteCommonDataProvider;
        public LTECommonViewModel(LTECommon lteCommon, ILTECommonDataProvider lteCommonDataProvider)
        {
            _lteCommon = lteCommon;
            _lteCommonDataProvider = lteCommonDataProvider;
        }
        public uint SerialNumber
        {
            get => _lteCommon.SerialNumber;
            set
            {
                if (_lteCommon.SerialNumber != value)
                {
                    _lteCommon.SerialNumber = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MessageType
        {
            get => _lteCommon.MessageType;
            set
            {
                if (_lteCommon.MessageType != value)
                {
                    _lteCommon.MessageType = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public uint TimeStamp
        {
            get => _lteCommon.TimeStamp;
            set
            {
                if (_lteCommon.TimeStamp != value)
                {
                    _lteCommon.TimeStamp = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FWMajorRev
        {
            get => _lteCommon.FWMajorRev;
            set
            {
                if (_lteCommon.FWMajorRev != value)
                {
                    _lteCommon.FWMajorRev = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FWMinorRev
        {
            get => _lteCommon.FWMinorRev;
            set
            {
                if (_lteCommon.FWMinorRev != value)
                {
                    _lteCommon.FWMinorRev = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FWBuild
        {
            get => _lteCommon.FWBuild;
            set
            {
                if (_lteCommon.FWBuild != value)
                {
                    _lteCommon.FWBuild = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte ModemFWMajor
        {
            get => _lteCommon.ModemFWMajor;
            set
            {
                if (_lteCommon.ModemFWMajor != value)
                {
                    _lteCommon.ModemFWMajor = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte ModemFWMinor
        {
            get => _lteCommon.ModemFWMinor;
            set
            {
                if (_lteCommon.ModemFWMinor != value)
                {
                    _lteCommon.ModemFWMinor = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte ModemFWBuild
        {
            get => _lteCommon.ModemFWBuild;
            set
            {
                if (_lteCommon.ModemFWBuild != value)
                {
                    _lteCommon.ModemFWBuild = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte LTEConnectionFailureStatus
        {
            get => _lteCommon.LTEConnectionFailureStatus;
            set
            {
                if (_lteCommon.LTEConnectionFailureStatus != value)
                {
                    _lteCommon.LTEConnectionFailureStatus = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte UnloadsFailureStatus
        {
            get => _lteCommon.UnloadsFailureStatus;
            set
            {
                if (_lteCommon.UnloadsFailureStatus != value)
                {
                    _lteCommon.UnloadsFailureStatus = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte GetMailboxFailureStatus
        {
            get => _lteCommon.GetMailboxFailureStatus;
            set
            {
                if (_lteCommon.GetMailboxFailureStatus != value)
                {
                    _lteCommon.GetMailboxFailureStatus = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte GetFirmwareFailureStatus
        {
            get => _lteCommon.GetFirmwareFailureStatus;
            set
            {
                if (_lteCommon.GetFirmwareFailureStatus != value)
                {
                    _lteCommon.GetFirmwareFailureStatus = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public ushort BatteryVoltage
        {
            get => _lteCommon.BatteryVoltage;
            set
            {
                if (_lteCommon.BatteryVoltage != value)
                {
                    _lteCommon.BatteryVoltage = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public ushort RMSModemCurrent
        {
            get => _lteCommon.RMSModemCurrent;
            set
            {
                if (_lteCommon.RMSModemCurrent != value)
                {
                    _lteCommon.RMSModemCurrent = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public ushort PeakModemCurrent
        {
            get => _lteCommon.PeakModemCurrent;
            set
            {
                if (_lteCommon.PeakModemCurrent != value)
                {
                    _lteCommon.PeakModemCurrent = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte TSMFW
        {
            get => _lteCommon.TSMFW;
            set
            {
                if (_lteCommon.TSMFW != value)
                {
                    _lteCommon.TSMFW = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte MODFW
        {
            get => _lteCommon.MODFW;
            set
            {
                if (_lteCommon.MODFW != value)
                {
                    _lteCommon.MODFW = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
        public byte FaultCodes
        {
            get => _lteCommon.FaultCodes;
            set
            {
                if (_lteCommon.FaultCodes != value)
                {
                    _lteCommon.FaultCodes = value;
                    RaisePropertyChanged();
                    //RaisePropertyChanged(nameof(CanSave));
                }
            }
        }
    }
}
