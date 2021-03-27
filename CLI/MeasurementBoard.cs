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
            try
			{
 				Send("acl calibrate");
                return Receive();
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelMaxXCommand()
        {
            try
			{
 				Send("acl max x");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelMaxYCommand()
        {
            try
			{
 				Send("acl max y");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelMaxZCommand()
        {
            try
			{
 				Send("acl max z");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelMeanXCommand()
        {
            try
			{
 				Send("acl mean x");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelMeanYCommand()
        {
            try
			{
 				Send("acl mean y");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelMeanZCommand()
        {
            try
			{
 				Send("acl mean z");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelMeasureXCommand()
        {
            try
			{
 				Send("acl measure x");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelMeasureYCommand()
        {
            try
			{
 				Send("acl measure y");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelMeasureZCommand()
        {
            try
			{
 				Send("acl measure z");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelStandardDeviationXCommand()
        {
            try
			{
 				Send("acl standarddeviation x");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelStandardDeviationYCommand()
        {
            try
			{
 				Send("acl standarddeviation y");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AccelStandardDeviationZCommand()
        {
            try
			{
 				Send("acl standarddeviation z");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcContCommand()
        {
            try
			{
 				Send("adc cont");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcGetAllCommand()
        {
            try
			{
 				Send("adc get all");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcGetConfigCommand()
        {
            try
			{
 				Send("adc get config");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcGetFscCommand()
        {
            try
			{
 				Send("adc get fsc");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcGetIdCommand()
        {
            try
			{
 				Send("adc get id");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcGetModesCommand()
        {
            try
			{
 				Send("adc get modes");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcGetOfcCommand()
        {
        	Send("adc get ofc");
            return Receive();
        }

        public ICLICommandResult AdcReadCountsCommand(int n)
        {
            try
			{
 				Send($"adc read counts {n}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcReadVoltageCommand(int n)
        {
            try
			{
 				Send($"adc read voltage {n}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcResetCommand()
        {
            try
			{
 				Send("adc reset");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetfilterLlCommand()
        {
            try
			{
 				Send("adc set filter ll");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetfilterWb1Command()
        {
            try
			{
 				Send("adc set filter wb1");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetfilterWb2Command()
        {
            try
			{
 				Send("adc set filter wb2");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetfscCommand(float value)
        {
            try
			{
 				Send($"adc setfsc {value}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetfsMasterCommand()
        {
            try
			{
 				Send("adc setfs master");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetfsSlaveCommand()
        {
            try
			{
 				Send("adc setfx slave");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSethrOCommand()
        {
            try
			{
 				Send("adc sethr o");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSethrOffCommand()
        {
            try
			{
 				Send("adc sethr off");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetinterfaceFsyncCommand()
        {
            try
			{
 				Send("adc setinterface fsync");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetinterfaceSpiCommand()
        {
            try
			{
 				Send("adc setinterface spi");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetofcCommand(int value)
        {
            try
			{
 				Send($"adc setofc {value}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetosr00Command()
        {
            try
			{
 				Send("adc setosr 00");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetosr01Command()
        {
            try
			{
 				Send("adc setosr 01");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetosr10Command()
        {
            try
			{
 				Send("adc setosr 10");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcSetosr11Command()
        {
            try
			{
 				Send("adc setosr 11");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcStartCommand()
        {
            try
			{
 				Send("adc start");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcStopCommand()
        {
            try
			{
 				Send("adc stop");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcToggleCrcbCommand()
        {
            try
			{
 				Send("adc toggle crb");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcToggleFscCommand()
        {
            try
			{
 				Send("adc toggle fsc");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcToggleOfcCommand()
        {
            try
			{
 				Send("adc toggle ofc");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcToggleSpitoutCommand()
        {
            try
			{
 				Send("adc toggle spitout");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcToggleSpitout_enCommand()
        {
            try
			{
 				Send("adc toggle spitout_en");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AdcToggleStatusWord()
        {
            try
			{
 				Send("adc toggle statusword");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AmbientHumidityCommand()
        {
            try
			{
 				Send("amb humidity");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult AmbientTemperatureCommand()
        {
            try
			{
 				Send("amb temperature");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleConnectCommand()
        {
            try
			{
 				Send("ble connect");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleDisableCommand()
        {
            try
			{
 				Send("ble disable");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleDisconnectCommand()
        {
            try
			{
 				Send("ble disconnect");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleEnableCommand()
        {
            try
			{
 				Send("ble enable");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BlePacketsDroppedCommand()
        {
            try
			{
 				Send("ble packates dropped");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BlePacketsRxCommand()
        {
            try
			{
 				Send("ble packets rx");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BlePacketsTxCommand()
        {
            try
			{
 				Send("ble packets tx");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleSignalConnectsCommand()
        {
            try
			{
 				Send("ble signal connects");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleSignalInterferenceCommand()
        {
            try
			{
 				Send("ble signal interference");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleSignalStrengthCommand()
        {
            try
			{
 				Send("ble signal strength");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleStatusCommand()
        {
            try
			{
 				Send("ble status");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleToggleBroadcastCommand()
        {
            try
			{
 				Send("ble toggle broadcast");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult BleTogglePairingCommand()
        {
            try
			{
 				Send("ble toggle pairing");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult FileCatCommand(string fileName)
        {
            try
			{
 				Send($"file cat {fileName}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult FileCpCommand(string currentPath, string newPath)
        {
            try
			{
 				Send($"file cp {currentPath} {newPath}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult FileDownloadCommand(string path)
        {
            try
			{
 				Send("$file download {path}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult FileFindCommand(string directory, string flags, string expression)
        {
            try
			{
 				Send($"file find {directory} {flags} {expression}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult FileHexDumpCommand(string flags, string filename)
        {
            try
			{
 				Send($"file hexdump {flags} {filename}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult FileLsCommand(string flags, string directory)
        {
            try
			{
 				Send($"file ls {flags} {directory}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult FileRmCommand(string flags, string path)
        {
            try
			{
 				Send($"file rm {flags} {path}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult FileUploadCommand(string path, string username, string destinationServer)
        {
            try
			{
 				Send($"file upload {path} {username}@{destinationServer}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagCalibrateCommand()
        {
            try
			{
 				Send("mag calibrate");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagMaxXCommand()
        {
            try
			{
 				Send("mag max x");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagMaxYCommand()
        {
            try
			{
 				Send("mag max y");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagMaxZCommand()
        {
            try
			{
 				Send("mag max z");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagMeanXCommand()
        {
            try
			{
 				Send("mag mean x");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagMeanYCommand()
        {
            try
			{
 				Send("mag mean y");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagMeanZCommand()
        {
            try
			{
 				Send("mag mean z");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagStandardDeviationXCommand()
        {
            try
			{
 				Send("mag standarddeviation x");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagStandardDeviationYCommand()
        {
            try
			{
 				Send("mag standarddeviation y");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MagStandardDeviationZCommand()
        {
            try
			{
 				Send("mag standarddeviation z");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmConnectCommand()
        {
            try
			{
 				Send("mdm connect");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmDisableCommand()
        {
            try
			{
 				Send("mdm disable");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmDisconnectCommand()
        {
            try
			{
 				Send("mdm disconnect");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmEnableCommand()
        {
            try
			{
 				Send("mdm enable");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmIdCommand()
        {
            try
			{
 				Send("mdm id");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmPacketsDroppedCommand()
        {
            try
			{
 				Send("mdm packets dropped");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmPacketsRxCommand()
        {
            try
			{
 				Send("mdm packets rx");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmPacketsTxCommand()
        {
            try
			{
 				Send("mdm packets tx");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmSearchEndCommand()
        {
            try
			{
 				Send("mdm search end");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmSearchStartCommand()
        {
            try
			{
 				Send("mdm search start");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmSignalConnectsCommand()
        {
            try
			{
 				Send("mdm signal connects");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmSignalInterferenceCommand()
        {
            try
			{
 				Send("mdm signal interference");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmSignalStrengthCommand()
        {
            try
			{
 				Send("mdm signal strength");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult MdmStatusCommand()
        {
            try
			{
 				Send("mdm status");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult NfcDisableCommand()
        {
            try
			{
 				Send("nfc disable");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult NfcDiscoveryCommand()
        {
            try
			{
 				Send("nfc discovery");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult NfcEnableCommand()
        {
            try
			{
 				Send("nfc enable");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult NfcGetCommand()
        {
            try
			{
 				Send("nfc get");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult NfcToggleCommand(string discovery)
        {
            try
			{
 				Send($"nfc toggle {discovery}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult NfcWakeCommand()
        {
            try
			{
 				Send("nfc wake");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult RtcFoutYieldCommand()
        {
            try
			{
 				Send("rtc fout yield");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult RtcFoutSetCommand()
        {
            try
            {
                Send("rtc fout set");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult RtcFoutClearCommand()
        {
            try
            {
                Send("rtc fout clear");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult RtcGetFrequencyCommand()
        {
            try
			{
 				Send("rtc get frequency");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult RtcGetTimeCommand()
        {
            try
            {
                Send("rtc get time");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }
        public ICLICommandResult RtcGetWakeCommand()
        {
            try
            {
                Send("rtc get wake");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }
        public ICLICommandResult RtcGetWakeCountdownCommand()
        {
            try
            {
                Send("rtc get wake countdown");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }
        public ICLICommandResult RtcGetWakeIntervalCommand()
        {
            try
            {
                Send("rtc get wake interval");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }
        public ICLICommandResult RtcResetCountdownCommand()
        {
            try
			{
 				Send("rtc reset countdown");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult RtcResetDefaultCommand()
        {
            try
            {
                Send("rtc reset default");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult RtcSetTimeCommand(string date)
        {
            try
			{
 				Send($"rtc set time {date}");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult RtcSetWakeIntervalCommand(string date)
        {
            try
            {
                Send($"rtc set wakeinterval {date}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult RtcSetcountdownCommand(string date)
        {
            try
            {
                Send($"rtc set countdown {date}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult RtdGetFarenheitCommand()
        {
            try
			{
 				Send("rtd get fahrenheit");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult RtdGetKelvinCommand()
        {
            try
			{
 				Send("rtd get kelvin");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult RtdGetResistanceCommand()
        {
            try
			{
 				Send("rtd get resistance");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatDisableCommand()
        {
            try
			{
 				Send("sat disable");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatDisconnectCommand()
        {
            try
			{
 				Send("sat disconnect");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatEnableCommand()
        {
            try
			{
 				Send("sat enable");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatIdCommand()
        {
            try
			{
 				Send("sat id");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatPacketsDroppedCommand()
        {
            try
			{
 				Send("sat packets dropped");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatPacketsRxCommand()
        {
            try
			{
 				Send("sat packets rx");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatPacketsTxCommand()
        {
            try
			{
 				Send("sat packets tx");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatSearchEndCommand()
        {
            try
			{
 				Send("sat search end");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatSearchStartCommand()
        {
            try
			{
 				Send("sat search start");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatSignalConnectsCommand()
        {
            try
			{
 				Send("sat signal strength");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatSignalInterferenceCommand()
        {
            try
			{
 				Send("sat signal interference");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatSignalStrengthCommand()
        {
            try
			{
 				Send("sat signal strength");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

        public ICLICommandResult SatStatusCommand()
        {
            try
			{
 				Send("sat status");
 			}
			catch(CLIException)
 			{
			}
            throw new NotImplementedException();
        }

    }
}
