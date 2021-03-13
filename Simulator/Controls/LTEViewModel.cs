using Simulator.Common.Models;
using Simulator.ViewModel.Command;
using System;
using System.Text;

namespace Simulator.Controls
{
    public class LTEViewModel : ViewModelBase
    {
        readonly LTE _lte;
        public LTEViewModel(LTE lte)
        {
            _lte = lte;
            AddCommand = new DelegateCommand(Add);
        }
        public uint SerialNumber
        {
            get => _lte.Common.SerialNumber;
            set
            {
                if (_lte.Common.SerialNumber != value)
                {
                    _lte.Common.SerialNumber = value;
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
            get => _lte.Common.MessageType;
            set
            {
                if (_lte.Common.MessageType != value)
                {
                    _lte.Common.MessageType = value;
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
            get => _lte.Common.TimeStamp;
            set
            {
                if (_lte.Common.TimeStamp != value)
                {
                    _lte.Common.TimeStamp = value;
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
        public string GNSS
        {
            get => _lte.Common.GNSS;
            set
            {
                if (_lte.Common.GNSS != value)
                {
                    _lte.Common.GNSS = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("GNSSBitString1");
                    RaisePropertyChanged("GNSSBitString2");
                    RaisePropertyChanged("GNSSBitString3");
                }
            }
        }
        public string GNSSBitString1
        {
            get
            {
                var pad = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                if (GNSS != null)
                {
                    var values = Encoding.ASCII.GetBytes(GNSS);
                    for (int i = 0; i < values.Length && i < pad.Length; i++)
                    {
                        pad[i] = values[i];
                    }
                }
                return Convert.ToString((byte)(pad[0] & 0xFFFF), 2).PadLeft(8, '0');
            }
        }
        public string GNSSBitString2
        {
            get
            {
                var pad = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                if (GNSS != null)
                {
                    var values = Encoding.ASCII.GetBytes(GNSS);
                    for (int i = 0; i < values.Length && i < pad.Length; i++)
                    {
                        pad[i] = values[i];
                    }
                }
                string ret = Convert.ToString((byte)(pad[1] & 0xFFFF), 2).PadLeft(8, '0') +
                             Convert.ToString((byte)(pad[2] & 0xFFFF), 2).PadLeft(8, '0') +
                             Convert.ToString((byte)(pad[3] & 0xFFFF), 2).PadLeft(8, '0') +
                             Convert.ToString((byte)(pad[4] & 0xFFFF), 2).PadLeft(8, '0');
                return ret;
            }
        }
        public string GNSSBitString3
        {
            get
            {
                var pad = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                if (GNSS != null)
                {
                    var values = Encoding.ASCII.GetBytes(GNSS);
                    for (int i = 0; i < values.Length && i < pad.Length; i++)
                    {
                        pad[i] = values[i];
                    }
                }
                string ret = Convert.ToString((byte)(pad[5] & 0xFFFF), 2).PadLeft(8, '0') +
                             Convert.ToString((byte)(pad[6] & 0xFFFF), 2).PadLeft(8, '0') +
                             Convert.ToString((byte)(pad[7] & 0xFFFF), 2).PadLeft(8, '0');
                return ret;
            }
        }
        public byte FWMajorRev
        {
            get => _lte.Common.FWMajorRev;
            set
            {
                if (_lte.Common.FWMajorRev != value)
                {
                    _lte.Common.FWMajorRev = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("FWMajorRevBitString");
                }
            }
        }
        public string FWMajorRevBitString
        {
            get
            {
                return Convert.ToString((byte)(FWMajorRev & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public byte FWMinorRev
        {
            get => _lte.Common.FWMinorRev;
            set
            {
                if (_lte.Common.FWMinorRev != value)
                {
                    _lte.Common.FWMinorRev = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("FWMinorRevBitString");
                }
            }
        }
        public string FWMinorRevBitString
        {
            get
            {
                return Convert.ToString((byte)(FWMinorRev & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public byte FWBuild
        {
            get => _lte.Common.FWBuild;
            set
            {
                if (_lte.Common.FWBuild != value)
                {
                    _lte.Common.FWBuild = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("FWBuildBitString");
                }
            }
        }
        public string FWBuildBitString
        {
            get
            {
                return Convert.ToString((byte)(FWBuild & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public byte ModemFWMajor
        {
            get => _lte.Common.ModemFWMajor;
            set
            {
                if (_lte.Common.ModemFWMajor != value)
                {
                    _lte.Common.ModemFWMajor = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("ModemFWMajorBitString");
                }
            }
        }
        public string ModemFWMajorBitString
        {
            get
            {
                return Convert.ToString((byte)(ModemFWMajor & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public byte ModemFWMinor
        {
            get => _lte.Common.ModemFWMinor;
            set
            {
                if (_lte.Common.ModemFWMinor != value)
                {
                    _lte.Common.ModemFWMinor = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("ModemFWMinorBitString");
                }
            }
        }
        public string ModemFWMinorBitString
        {
            get
            {
                return Convert.ToString((byte)(ModemFWMinor & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public byte ModemFWBuild
        {
            get => _lte.Common.ModemFWBuild;
            set
            {
                if (_lte.Common.ModemFWBuild != value)
                {
                    _lte.Common.ModemFWBuild = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("ModemFWBuildBitString");
                }
            }
        }
        public string ModemFWBuildBitString
        {
            get
            {
                return Convert.ToString((byte)(ModemFWBuild & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public byte LTEConnectionFailureStatus
        {
            get => _lte.Common.LTEConnectionFailureStatus;
            set
            {
                if (_lte.Common.LTEConnectionFailureStatus != value)
                {
                    _lte.Common.LTEConnectionFailureStatus = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("LTEConnectionFailureStatusBitString");
                }
            }
        }
        public string LTEConnectionFailureStatusBitString
        {
            get
            {
                return Convert.ToString((byte)(LTEConnectionFailureStatus & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public byte UploadsFailureStatus
        {
            get => _lte.Common.UnloadsFailureStatus;
            set
            {
                if (_lte.Common.UnloadsFailureStatus != value)
                {
                    _lte.Common.UnloadsFailureStatus = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("UnloadsFailureStatusBitString");
                }
            }
        }
        public string UploadsFailureStatusBitString
        {
            get
            {
                return Convert.ToString((byte)(UploadsFailureStatus & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public byte GetMailboxFailureStatus
        {
            get => _lte.Common.GetMailboxFailureStatus;
            set
            {
                if (_lte.Common.GetMailboxFailureStatus != value)
                {
                    _lte.Common.GetMailboxFailureStatus = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("GetMailboxFailureStatusBitString");
                }
            }
        }
        public string GetMailboxFailureStatusBitString
        {
            get
            {
                return Convert.ToString((byte)(GetMailboxFailureStatus & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public byte GetFirmwareFailureStatus
        {
            get => _lte.Common.GetFirmwareFailureStatus;
            set
            {
                if (_lte.Common.GetFirmwareFailureStatus != value)
                {
                    _lte.Common.GetFirmwareFailureStatus = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("GetFirmwareFailureStatusBitString");
                }
            }
        }
        public string GetFirmwareFailureStatusBitString
        {
            get
            {
                return Convert.ToString((byte)(GetFirmwareFailureStatus & 0xFF), 2).PadLeft(8, '0');
            }
        }
        public ushort BatteryVoltage
        {
            get => _lte.Common.BatteryVoltage;
            set
            {
                if (_lte.Common.BatteryVoltage != value)
                {
                    _lte.Common.BatteryVoltage = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("BatteryVoltageBitString");
                }
            }
        }
        public string BatteryVoltageBitString
        {
            get
            {
                return Convert.ToString((ushort)(BatteryVoltage & 0x3FFF), 2).PadLeft(12, '0');
            }
        }
        public ushort RMSModemCurrent
        {
            get => _lte.Common.RMSModemCurrent;
            set
            {
                if (_lte.Common.RMSModemCurrent != value)
                {
                    _lte.Common.RMSModemCurrent = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("RMSModemCurrentBitString");
                }
            }
        }
        public string RMSModemCurrentBitString
        {
            get
            {
                return Convert.ToString((ushort)(RMSModemCurrent & 0x3FFF), 2).PadLeft(12, '0');
            }
        }
        public ushort PeakModemCurrent
        {
            get => _lte.Common.PeakModemCurrent;
            set
            {
                if (_lte.Common.PeakModemCurrent != value)
                {
                    _lte.Common.PeakModemCurrent = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("PeakModemCurrentBitString");
                }
            }
        }
        public string PeakModemCurrentBitString
        {
            get
            {
                return Convert.ToString((ushort)(PeakModemCurrent & 0x3FFF), 2).PadLeft(12, '0');
            }
        }
        public byte TSMFW
        {
            get => _lte.Common.TSMFW;
            set
            {
                if (_lte.Common.TSMFW != value)
                {
                    _lte.Common.TSMFW = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("TSMFWBitString");
                }
            }
        }
        public string TSMFWBitString
        {
            get
            {
                return Convert.ToString((byte)(TSMFW & 0x3), 2).PadLeft(2, '0');
            }
        }
        public byte MODFW
        {
            get => _lte.Common.MODFW;
            set
            {
                if (_lte.Common.MODFW != value)
                {
                    _lte.Common.MODFW = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("MODFWBitString");
                }
            }
        }
        public string MODFWBitString
        {
            get
            {
                return Convert.ToString((byte)(MODFW & 0x3), 2).PadLeft(2, '0');
            }
        }
        public byte FaultCodes
        {
            get => _lte.Common.FaultCodes;
            set
            {
                if (_lte.Common.FaultCodes != value)
                {
                    _lte.Common.FaultCodes = value;
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
        public DelegateCommand AddCommand { get; }
        public void Add()
        {
        }
    }
}
