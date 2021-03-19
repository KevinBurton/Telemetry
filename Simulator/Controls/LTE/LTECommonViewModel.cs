using Simulator.Common.Models;
using Simulator.Common.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Simulator.Controls
{
    public class LTECommonViewModel : ViewModelBase
    {
        public LTECommonViewModel(LTECommon lteCommon)
        {
            LteCommon = lteCommon;
            MessageTypeValues = MessageTypeDescription.ObservableCollection();
        }
        public LTECommon LteCommon { get; }
        public uint SerialNumber
        {
            get => LteCommon.SerialNumber;
            set
            {
                if (LteCommon.SerialNumber != value)
                {
                    LteCommon.SerialNumber = value;
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
        public ObservableCollection<MessageTypeDescription> MessageTypeValues { get; }
        public byte MessageType
        {
            get => LteCommon.MessageType;
            set
            {
                if (LteCommon.MessageType != value)
                {
                    LteCommon.MessageType = value;
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
            get => LteCommon.TimeStamp;
            set
            {
                if (LteCommon.TimeStamp != value)
                {
                    LteCommon.TimeStamp = value;
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
            get => LteCommon.GNSS;
            set
            {
                if (LteCommon.GNSS != value)
                {
                    LteCommon.GNSS = value;
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
            get => LteCommon.FWMajorRev;
            set
            {
                if (LteCommon.FWMajorRev != value)
                {
                    LteCommon.FWMajorRev = value;
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
            get => LteCommon.FWMinorRev;
            set
            {
                if (LteCommon.FWMinorRev != value)
                {
                    LteCommon.FWMinorRev = value;
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
            get => LteCommon.FWBuild;
            set
            {
                if (LteCommon.FWBuild != value)
                {
                    LteCommon.FWBuild = value;
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
            get => LteCommon.ModemFWMajor;
            set
            {
                if (LteCommon.ModemFWMajor != value)
                {
                    LteCommon.ModemFWMajor = value;
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
            get => LteCommon.ModemFWMinor;
            set
            {
                if (LteCommon.ModemFWMinor != value)
                {
                    LteCommon.ModemFWMinor = value;
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
            get => LteCommon.ModemFWBuild;
            set
            {
                if (LteCommon.ModemFWBuild != value)
                {
                    LteCommon.ModemFWBuild = value;
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
            get => LteCommon.LTEConnectionFailureStatus;
            set
            {
                if (LteCommon.LTEConnectionFailureStatus != value)
                {
                    LteCommon.LTEConnectionFailureStatus = value;
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
            get => LteCommon.UnloadsFailureStatus;
            set
            {
                if (LteCommon.UnloadsFailureStatus != value)
                {
                    LteCommon.UnloadsFailureStatus = value;
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
            get => LteCommon.GetMailboxFailureStatus;
            set
            {
                if (LteCommon.GetMailboxFailureStatus != value)
                {
                    LteCommon.GetMailboxFailureStatus = value;
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
            get => LteCommon.GetFirmwareFailureStatus;
            set
            {
                if (LteCommon.GetFirmwareFailureStatus != value)
                {
                    LteCommon.GetFirmwareFailureStatus = value;
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
            get => LteCommon.BatteryVoltage;
            set
            {
                if (LteCommon.BatteryVoltage != value)
                {
                    LteCommon.BatteryVoltage = value;
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
            get => LteCommon.RMSModemCurrent;
            set
            {
                if (LteCommon.RMSModemCurrent != value)
                {
                    LteCommon.RMSModemCurrent = value;
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
            get => LteCommon.PeakModemCurrent;
            set
            {
                if (LteCommon.PeakModemCurrent != value)
                {
                    LteCommon.PeakModemCurrent = value;
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
            get => LteCommon.TSMFW;
            set
            {
                if (LteCommon.TSMFW != value)
                {
                    LteCommon.TSMFW = value;
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
            get => LteCommon.MODFW;
            set
            {
                if (LteCommon.MODFW != value)
                {
                    LteCommon.MODFW = value;
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
            get => LteCommon.FaultCodes;
            set
            {
                if (LteCommon.FaultCodes != value)
                {
                    LteCommon.FaultCodes = value;
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
