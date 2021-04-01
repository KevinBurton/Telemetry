using System;
using System.IO.Ports;

namespace CLI
{
    public class MeasurementBoard : ICLI
    {
        public MeasurementBoard(ICLIConnection connection)
        {
            Connection = connection;
        }
        void Send(string command)
        {
            Connection.Send(command);
        }
        ICLICommandResult Receive()
        {
            var response = Connection.Read();
            return new MeasurementBoardCommandResult(response);
        }
        ICLIConnection Connection { get; }
        public ICLICommandResult AccelCalibrateCommand()
        {
            Send("acl calibrate");
            return Receive();
        }

        public ICLICommandResult AccelMaxXCommand()
        {
            Send("acl max x");
            return Receive();
        }

        public ICLICommandResult AccelMaxYCommand()
        {
            Send("acl max y");
            return Receive();
        }

        public ICLICommandResult AccelMaxZCommand()
        {
            Send("acl max z");
            return Receive();
        }

        public ICLICommandResult AccelMeanXCommand()
        {
            Send("acl mean x");
            return Receive();
        }

        public ICLICommandResult AccelMeanYCommand()
        {
            Send("acl mean y");
            return Receive();
        }

        public ICLICommandResult AccelMeanZCommand()
        {
            Send("acl mean z");
            return Receive();
        }

        public ICLICommandResult AccelMeasureXCommand()
        {
            Send("acl measure x");
            return Receive();
        }

        public ICLICommandResult AccelMeasureYCommand()
        {
            Send("acl measure y");
            return Receive();
        }

        public ICLICommandResult AccelMeasureZCommand()
        {
            Send("acl measure z");
            return Receive();
        }

        public ICLICommandResult AccelStandardDeviationXCommand()
        {
            Send("acl standarddeviation x");
            return Receive();
        }

        public ICLICommandResult AccelStandardDeviationYCommand()
        {
            Send("acl standarddeviation y");
            return Receive();
        }

        public ICLICommandResult AccelStandardDeviationZCommand()
        {
            Send("acl standarddeviation z");
            return Receive();
        }

        public ICLICommandResult AdcContCommand()
        {
            Send("adc cont");
            return Receive();
        }

        public ICLICommandResult AdcGetAllCommand()
        {
            Send("adc get all");
            return Receive();
        }

        public ICLICommandResult AdcGetConfigCommand()
        {
            Send("adc get config");
            return Receive();
        }

        public ICLICommandResult AdcGetFscCommand()
        {
            Send("adc get fsc");
            return Receive();
        }

        public ICLICommandResult AdcGetIdCommand()
        {
            Send("adc get id");
            return Receive();
        }

        public ICLICommandResult AdcGetModesCommand()
        {
            Send("adc get modes");
            return Receive();
        }

        public ICLICommandResult AdcGetOfcCommand()
        {
            Send("adc get ofc");
            return Receive();
        }

        public ICLICommandResult AdcReadCountsCommand(int n)
        {
            Send($"adc read counts {n}");
            return Receive();
        }

        public ICLICommandResult AdcReadVoltageCommand(int n)
        {
            Send($"adc read voltage {n}");
            return Receive();
        }

        public ICLICommandResult AdcResetCommand()
        {
            Send("adc reset");
            return Receive();
        }

        public ICLICommandResult AdcSetfilterLlCommand()
        {
            Send("adc setfilter ll");
            return Receive();
        }

        public ICLICommandResult AdcSetfilterWb1Command()
        {
            Send("adc setfilter wb1");
            return Receive();
        }

        public ICLICommandResult AdcSetfilterWb2Command()
        {
            Send("adc setfilter wb2");
            return Receive();
        }

        public ICLICommandResult AdcSetfscCommand(float value)
        {
            Send($"adc setfsc {value}");
            return Receive();
        }

        public ICLICommandResult AdcSetfsMasterCommand()
        {
            Send("adc setfs master");
            return Receive();
        }

        public ICLICommandResult AdcSetfsSlaveCommand()
        {
            Send("adc setfs slave");
            return Receive();
        }

        public ICLICommandResult AdcSethrOCommand()
        {
            Send("adc sethr o");
            return Receive();
        }

        public ICLICommandResult AdcSethrOffCommand()
        {
            Send("adc sethr off");
            return Receive();
        }

        public ICLICommandResult AdcSetinterfaceFsyncCommand()
        {
            Send("adc setinterface fsync");
            return Receive();
        }

        public ICLICommandResult AdcSetinterfaceSpiCommand()
        {
            Send("adc setinterface spi");
            return Receive();
        }

        public ICLICommandResult AdcSetofcCommand(int value)
        {
            Send($"adc setofc {value}");
            return Receive();
        }

        public ICLICommandResult AdcSetosr00Command()
        {
            Send("adc setosr 00");
            return Receive();
        }

        public ICLICommandResult AdcSetosr01Command()
        {
            Send("adc setosr 01");
            return Receive();
        }

        public ICLICommandResult AdcSetosr10Command()
        {
            Send("adc setosr 10");
            return Receive();
        }

        public ICLICommandResult AdcSetosr11Command()
        {
            Send("adc setosr 11");
            return Receive();
        }

        public ICLICommandResult AdcStartCommand()
        {
            Send("adc start");
            return Receive();
        }

        public ICLICommandResult AdcStopCommand()
        {
            Send("adc stop");
            return Receive();
        }

        public ICLICommandResult AdcToggleCrcbCommand()
        {
            Send("adc toggle crcb");
            return Receive();
        }

        public ICLICommandResult AdcToggleFscCommand()
        {
            Send("adc toggle fsc");
            return Receive();
        }

        public ICLICommandResult AdcToggleOfcCommand()
        {
            Send("adc toggle ofc");
            return Receive();
        }

        public ICLICommandResult AdcToggleSpitoutCommand()
        {
            Send("adc toggle spitout");
            return Receive();
        }

        public ICLICommandResult AdcToggleSpitout_enCommand()
        {
            Send("adc toggle spitout_en");
            return Receive();
        }

        public ICLICommandResult AdcToggleStatusWord()
        {
            Send("adc toggle statusword");
            return Receive();
        }

        public ICLICommandResult AmbientHumidityCommand()
        {
            Send("amb humidity");
            return Receive();
        }

        public ICLICommandResult AmbientTemperatureCommand()
        {
            Send("amb temperature");
            return Receive();
        }

        public ICLICommandResult BleConnectCommand()
        {
            Send("ble connect");
            return Receive();
        }

        public ICLICommandResult BleDisableCommand()
        {
            Send("ble disable");
            return Receive();
        }

        public ICLICommandResult BleDisconnectCommand()
        {
            Send("ble disconnect");
            return Receive();
        }

        public ICLICommandResult BleEnableCommand()
        {
            Send("ble enable");
            return Receive();
        }

        public ICLICommandResult BlePacketsDroppedCommand()
        {
            Send("ble packets dropped");
            return Receive();
        }

        public ICLICommandResult BlePacketsRxCommand()
        {
            Send("ble packets rx");
            return Receive();
        }

        public ICLICommandResult BlePacketsTxCommand()
        {
            Send("ble packets tx");
            return Receive();
        }

        public ICLICommandResult BleSignalConnectsCommand()
        {
            Send("ble signal connects");
            return Receive();
        }

        public ICLICommandResult BleSignalInterferenceCommand()
        {
            Send("ble signal interference");
            return Receive();
        }

        public ICLICommandResult BleSignalStrengthCommand()
        {
            Send("ble signal strength");
            return Receive();
        }

        public ICLICommandResult BleStatusCommand()
        {
            Send("ble status");
            return Receive();
        }

        public ICLICommandResult BleToggleBroadcastCommand()
        {
            Send("ble toggle broadcast");
            return Receive();
        }

        public ICLICommandResult BleTogglePairingCommand()
        {
            Send("ble toggle pairing");
            return Receive();
        }

        public ICLICommandResult FileCatCommand(string fileName)
        {
            Send($"file cat {fileName}");
            return Receive();
        }

        public ICLICommandResult FileCpCommand(string currentPath, string newPath)
        {
            Send($"file cp {currentPath} {newPath}");
            return Receive();
        }

        public ICLICommandResult FileFindCommand(string directory, string flags, string expression)
        {
            Send($"file find {directory} {flags} {expression}");
            return Receive();
        }

        public ICLICommandResult FileHexDumpCommand(string flags, string fileName)
        {
            Send($"file hexdump {flags} {fileName}");
            return Receive();
        }

        public ICLICommandResult FileLsCommand(string flags, string directory)
        {
            Send($"file ls {flags} {directory}");
            return Receive();
        }

        public ICLICommandResult FileRmCommand(string flags, string path)
        {
            Send($"file rm {flags} {path}");
            return Receive();
        }

        public ICLICommandResult FileUploadCommand(string path, string userName, string destinationServer)
        {
            Send($"file upload {path} {userName}@{destinationServer}");
            return Receive();
        }

        public ICLICommandResult FileDownloadCommand(string path)
        {
            Send($"file download {path}");
            return Receive();
        }

        public ICLICommandResult MagCalibrateCommand()
        {
            Send("mag calibrate");
            return Receive();
        }

        public ICLICommandResult MagMaxXCommand()
        {
            Send("mag max x");
            return Receive();
        }

        public ICLICommandResult MagMaxYCommand()
        {
            Send("mag max y");
            return Receive();
        }

        public ICLICommandResult MagMaxZCommand()
        {
            Send("mag max z");
            return Receive();
        }

        public ICLICommandResult MagMeanXCommand()
        {
            Send("mag mean x");
            return Receive();
        }

        public ICLICommandResult MagMeanYCommand()
        {
            Send("mag mean y");
            return Receive();
        }

        public ICLICommandResult MagMeanZCommand()
        {
            Send("mag mean z");
            return Receive();
        }

        public ICLICommandResult MagStandardDeviationXCommand()
        {
            Send("mag standarddeviation x");
            return Receive();
        }

        public ICLICommandResult MagStandardDeviationYCommand()
        {
            Send("mag standarddeviation y");
            return Receive();
        }

        public ICLICommandResult MagStandardDeviationZCommand()
        {
            Send("mag standarddeviation z");
            return Receive();
        }

        public ICLICommandResult MdmConnectCommand()
        {
            Send("mdm connect");
            return Receive();
        }

        public ICLICommandResult MdmDisableCommand()
        {
            Send("mdm disable");
            return Receive();
        }

        public ICLICommandResult MdmDisconnectCommand()
        {
            Send("mdm disconnect");
            return Receive();
        }

        public ICLICommandResult MdmEnableCommand()
        {
            Send("mdm enable");
            return Receive();
        }

        public ICLICommandResult MdmIdCommand()
        {
            Send("mdm id");
            return Receive();
        }

        public ICLICommandResult MdmPacketsDroppedCommand()
        {
            Send("mdm packets dropped");
            return Receive();
        }

        public ICLICommandResult MdmPacketsRxCommand()
        {
            Send("mdm packets rx");
            return Receive();
        }

        public ICLICommandResult MdmPacketsTxCommand()
        {
            Send("mdm packets tx");
            return Receive();
        }

        public ICLICommandResult MdmSearchEndCommand()
        {
            Send("mdm search end");
            return Receive();
        }

        public ICLICommandResult MdmSearchStartCommand()
        {
            Send("mdm search start");
            return Receive();
        }

        public ICLICommandResult MdmSignalConnectsCommand()
        {
            Send("mdm signal connects");
            return Receive();
        }

        public ICLICommandResult MdmSignalInterferenceCommand()
        {
            Send("mdm signal interference");
            return Receive();
        }

        public ICLICommandResult MdmSignalStrengthCommand()
        {
            Send("mdm signal strength");
            return Receive();
        }

        public ICLICommandResult MdmStatusCommand()
        {
            Send("mdm status");
            return Receive();
        }

        public ICLICommandResult NfcDisableCommand()
        {
            Send("nfc disable");
            return Receive();
        }

        public ICLICommandResult NfcToggleDiscoveryCommand()
        {
            Send("nfc toggle discovery");
            return Receive();
        }

        public ICLICommandResult NfcEnableCommand()
        {
            Send("nfc enable");
            return Receive();
        }

        public ICLICommandResult NfcGetCommand()
        {
            Send("nfc get");
            return Receive();
        }

        public ICLICommandResult NfcWakeCommand()
        {
            Send("nfc wake");
            return Receive();
        }

        public ICLICommandResult RtcFoutYieldCommand()
        {
            Send("rtc fout yield");
            return Receive();
        }

        public ICLICommandResult RtcFoutSetCommand()
        {
            Send("rtc fout set");
            return Receive();
        }

        public ICLICommandResult RtcFoutClearCommand()
        {
            Send("rtc fout clear");
            return Receive();
        }

        public ICLICommandResult RtcGetFrequencyCommand()
        {
            Send("rtc get frequency");
            return Receive();
        }

        public ICLICommandResult RtcGetTimeCommand()
        {
            Send("rtc get time");
            return Receive();
        }
        public ICLICommandResult RtcGetWakeCountdownCommand()
        {
            Send("rtc get wake countdown");
            return Receive();
        }
        public ICLICommandResult RtcGetWakeIntervalCommand()
        {
            Send("rtc get wake interval");
            return Receive();
        }
        public ICLICommandResult RtcResetCountdownCommand()
        {
            Send("rtc reset countdown");
            return Receive();
        }

        public ICLICommandResult RtcResetDefaultCommand()
        {
            Send("rtc reset default");
            return Receive();
        }

        public ICLICommandResult RtcSetTimeCommand(string date)
        {
            Send($"rtc set time {date}");
            return Receive();
        }

        public ICLICommandResult RtcSetWakeIntervalCommand(string date)
        {
            Send($"rtc set wakeinterval {date}");
            return Receive();
        }

        public ICLICommandResult RtcSetcountdownCommand(string date)
        {
            Send($"rtc set countdown {date}");
            return Receive();
        }

        public ICLICommandResult RtdGetFarenheitCommand()
        {
            Send("rtd get fahrenheit");
            return Receive();
        }

        public ICLICommandResult RtdGetKelvinCommand()
        {
            Send("rtd get kelvin");
            return Receive();
        }

        public ICLICommandResult RtdGetResistanceCommand()
        {
            Send("rtd get resistance");
            return Receive();
        }

        public ICLICommandResult SatDisableCommand()
        {
            Send("sat disable");
            return Receive();
        }

        public ICLICommandResult SatDisconnectCommand()
        {
            Send("sat disconnect");
            return Receive();
        }

        public ICLICommandResult SatEnableCommand()
        {
            Send("sat enable");
            return Receive();
        }

        public ICLICommandResult SatIdCommand()
        {
            Send("sat id");
            return Receive();
        }

        public ICLICommandResult SatPacketsDroppedCommand()
        {
            Send("sat packets dropped");
            return Receive();
        }

        public ICLICommandResult SatPacketsRxCommand()
        {
            Send("sat packets rx");
            return Receive();
        }

        public ICLICommandResult SatPacketsTxCommand()
        {
            Send("sat packets tx");
            return Receive();
        }

        public ICLICommandResult SatSearchEndCommand()
        {
            Send("sat search end");
            return Receive();
        }

        public ICLICommandResult SatSearchStartCommand()
        {
            Send("sat search start");
            return Receive();
        }

        public ICLICommandResult SatSignalConnectsCommand()
        {
            Send("sat signal strength");
            return Receive();
        }

        public ICLICommandResult SatSignalInterferenceCommand()
        {
            Send("sat signal interference");
            return Receive();
        }

        public ICLICommandResult SatSignalStrengthCommand()
        {
            Send("sat signal strength");
            return Receive();
        }

        public ICLICommandResult SatStatusCommand()
        {
            Send("sat status");
            return Receive();
        }
        bool CheckInput(MeasurementBoardChannels first, MeasurementBoardChannels second)
        {
            if (first == MeasurementBoardChannels.s1 ||
               first == MeasurementBoardChannels.s2 ||
               first == MeasurementBoardChannels.pc1 ||
               first == MeasurementBoardChannels.nc ||
               first == MeasurementBoardChannels.acc ||
               first == MeasurementBoardChannels.pc2)
            {
                if(second != MeasurementBoardChannels.ref1 &&
                   second != MeasurementBoardChannels.ref1)
                {
                    return false;
                }
            }
            if (first == MeasurementBoardChannels.ref1 ||
                first == MeasurementBoardChannels.ref1)
            {
                if (second != MeasurementBoardChannels.s1 &&
                    second != MeasurementBoardChannels.s2 &&
                    second != MeasurementBoardChannels.pc1 &&
                    second != MeasurementBoardChannels.nc &&
                    second != MeasurementBoardChannels.acc &&
                    second != MeasurementBoardChannels.pc2)
                {
                    return false;
                }
            }
            if ((first == MeasurementBoardChannels.aux2_pos && second != MeasurementBoardChannels.aux2_neg) ||
               (first == MeasurementBoardChannels.aux2_neg && second != MeasurementBoardChannels.aux2_pos))
            {
                return false;
            }
            if ((first == MeasurementBoardChannels.ishnt_pos && second != MeasurementBoardChannels.ishnt_neg) ||
                (first == MeasurementBoardChannels.ishnt_neg && second != MeasurementBoardChannels.ishnt_pos))
            {
                return false;
            }
            if ((first == MeasurementBoardChannels.pcr_pos && second != MeasurementBoardChannels.pcr_neg) ||
                (first == MeasurementBoardChannels.pcr_neg && second != MeasurementBoardChannels.pcr_pos))
            {
                return false;
            }
            if ((first == MeasurementBoardChannels.eshnt_pos && second != MeasurementBoardChannels.eshnt_neg) ||
                (first == MeasurementBoardChannels.eshnt_neg && second != MeasurementBoardChannels.eshnt_pos))
            {
                return false;
            }
            return true;
        }
        public ICLICommandResult RelayCommand(MeasurementBoardChannels first, MeasurementBoardChannels second)
        {
            // Check input
            if(!CheckInput(first, second))
            {
                throw new ArgumentOutOfRangeException($"Invalid relay latch combination. {first}, {second}");
            }
            int dac = 0;
            int channel = 0;
            switch (first)
            {
                case MeasurementBoardChannels.s1:
                    dac = 0;
                    channel = 0;
                    break;
                case MeasurementBoardChannels.s2:
                    dac = 0;
                    channel = 1;
                    break;
                case MeasurementBoardChannels.pc1:
                    dac = 0;
                    channel = 2;
                    break;
                case MeasurementBoardChannels.nc:
                    dac = 0;
                    channel = 3;
                    break;
                case MeasurementBoardChannels.acc:
                    dac = 0;
                    channel = 4;
                    break;
                case MeasurementBoardChannels.pc2:
                    dac = 0;
                    channel = 5;
                    break;
                case MeasurementBoardChannels.aux2_pos:
                    dac = 0;
                    channel = 6;
                    break;
                case MeasurementBoardChannels.aux2_neg:
                    dac = 0;
                    channel = 7;
                    break;
                case MeasurementBoardChannels.ishnt_pos:
                    dac = 1;
                    channel = 0;
                    break;
                case MeasurementBoardChannels.ishnt_neg:
                    dac = 1;
                    channel = 1;
                    break;
                case MeasurementBoardChannels.ref1:
                    dac = 1;
                    channel = 2;
                    break;
                case MeasurementBoardChannels.ref2:
                    dac = 1;
                    channel = 3;
                    break;
                case MeasurementBoardChannels.pcr_pos:
                    dac = 1;
                    channel = 4;
                    break;
                case MeasurementBoardChannels.pcr_neg:
                    dac = 1;
                    channel = 5;
                    break;
                case MeasurementBoardChannels.eshnt_pos:
                    dac = 1;
                    channel = 6;
                    break;
                case MeasurementBoardChannels.eshnt_neg:
                    dac = 1;
                    channel = 7;
                    break;
                default:
                    break;
            }
            Send($"relay {dac} {channel}");
            var result = Receive();
            if (!result.IsSuccess) return result;
            switch (second)
            {
                case MeasurementBoardChannels.s1:
                    dac = 0;
                    channel = 0;
                    break;
                case MeasurementBoardChannels.s2:
                    dac = 0;
                    channel = 1;
                    break;
                case MeasurementBoardChannels.pc1:
                    dac = 0;
                    channel = 2;
                    break;
                case MeasurementBoardChannels.nc:
                    dac = 0;
                    channel = 3;
                    break;
                case MeasurementBoardChannels.acc:
                    dac = 0;
                    channel = 4;
                    break;
                case MeasurementBoardChannels.pc2:
                    dac = 0;
                    channel = 5;
                    break;
                case MeasurementBoardChannels.aux2_pos:
                    dac = 0;
                    channel = 6;
                    break;
                case MeasurementBoardChannels.aux2_neg:
                    dac = 0;
                    channel = 7;
                    break;
                case MeasurementBoardChannels.ishnt_pos:
                    dac = 1;
                    channel = 0;
                    break;
                case MeasurementBoardChannels.ishnt_neg:
                    dac = 1;
                    channel = 1;
                    break;
                case MeasurementBoardChannels.ref1:
                    dac = 1;
                    channel = 2;
                    break;
                case MeasurementBoardChannels.ref2:
                    dac = 1;
                    channel = 3;
                    break;
                case MeasurementBoardChannels.pcr_pos:
                    dac = 1;
                    channel = 4;
                    break;
                case MeasurementBoardChannels.pcr_neg:
                    dac = 1;
                    channel = 5;
                    break;
                case MeasurementBoardChannels.eshnt_pos:
                    dac = 1;
                    channel = 6;
                    break;
                case MeasurementBoardChannels.eshnt_neg:
                    dac = 1;
                    channel = 7;
                    break;
                default:
                    break;
            }
            Send($"relay {dac} {channel}");
            return Receive();
        }
        public ICLICommandResult RelayResetCommand()
        {
            Send("relay reset");
            return Receive();
        }
    }
}
