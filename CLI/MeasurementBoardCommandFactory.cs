using CLI.Commands.MeasurementBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLI
{
    public static class MeasurementBoardCommandFactory
    {
        public static IMeasurementBoardCommand Command(string command)
        {
            if(string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentNullException(nameof(command));
            }
            var tokens = new Regex(@"\b").Split(command);
            switch(tokens[0].ToLowerInvariant())
            {
                case "adc":
                    if(tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "start":
                            return new AdcStartCommand();
                        case "stop":
                            return new AdcStopCommand();
                        case "reset":
                            return new AdcResetCommand();
                        case "toggle":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "crcb":
                                    return new AdcToggleCrcbCommand();
                                case "statusword":
                                    return new AdcToggleStatusWord();
                                case "spitout_en":
                                    return new AdcToggleSpitout_enCommand();
                                case "spitout":
                                    return new AdcToggleSpitoutCommand();
                                case "ofc":
                                    return new AdcToggleOfcCommand();
                                case "fsc":
                                    return new AdcToggleFscCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "setofc":
                            return new AdcSetofcCommand();
                        case "setfsc":
                            return new AdcSetfscCommand();
                        case "setfs":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "slave":
                                    return new AdcSetfsSlaveCommand();
                                case "master":
                                    return new AdcSetfsMasterCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "setinterface":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "spi":
                                    return new AdcSetInterfaceSpiCommand();
                                case "fsync":
                                    return new AdcSetinterfaceFsyncCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "setfilter":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch(tokens[2].ToLowerInvariant())
                            {
                                case "wb1":
                                    return new AdcSetfilterWb1Command();
                                case "wb2":
                                    return new AdcSetfilterWb2Command();
                                case "ll":
                                    return new AdcSetfilterLlCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "setosr":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "00":
                                    return new AdcSetosr00Command();
                                case "01":
                                    return new AdcSetosr01Command();
                                case "l0":
                                    return new AdcSetosr10Command();
                                case "ll":
                                    return new AdcSetosr11Command();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "sethr":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "off":
                                    return new AdcSethrOffCommand();
                                case "o":
                                    return new AdcSethrOCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "get":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "id":
                                    return new AdcGetIdCommand();
                                case "config":
                                    return new AdcGetConfigCommand();
                                case "ofc":
                                    return new AdcGetOfcCommand();
                                case "fsc":
                                    return new AdcGetFscCommand();
                                case "modes":
                                    return new AdcGetModesCommand();
                                case "all":
                                    return new AdcGetAllCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "read":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "voltage":
                                    return new AdcReadVoltageCommand();
                                case "counts":
                                    return new AdcReadCountsCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "cont":
                            return new AdcContCommand();
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "rtc":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "get":
                            return new RtcGetCommand();
                        case "set":
                            return new RtcSetCommand();
                        case "reset":
                            return new RtcResetCommand();
                        case "fout":
                            return new RtcFoutCommand();
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "nfc":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "wake":
                            return new NfcWakeCommand();
                        case "disable":
                            return new NfcDisableCommand();
                        case "enable":
                            return new NfcEnableCommand();
                        case "toggle":
                            return new NfcToggleCommand();
                        case "get":
                            return new NfcGetCommand();
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "rtd":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "get":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "resistace":
                                    return new RtdGetResistanceCommand();
                                case "kelvin":
                                    return new RtdGetKelvinCommand();
                                case "fahrenheit":
                                    return new RtdGetFarenheitCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "ble":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "status":
                            return new BleStatusCommand();
                        case "disable":
                            return new BleDisableCommand();
                        case "enable":
                            return new BleEnableCommand();
                        case "connect":
                            return new BleConnectCommand();
                        case "disconnect":
                            return new BleDisconnectCommand();
                        case "send":
                            return new BlePacketsTxCommand();
                        case "toggle":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "broadcast":
                                    return new BleToggleBroadcastCommand();
                                case "pairing":
                                    return new BleTogglePairingCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "signal":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "strength":
                                    return new BleSignalStrengthCommand();
                                case "interference":
                                    return new BleSignalInterferenceCommand();
                                case "connects":
                                    return new BleSignalConnectsCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "packets":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "tx":
                                    return new BlePacketsTxCommand();
                                case "rx":
                                    return new BlePacketsRxCommand();
                                case "dropped":
                                    return new BlePacketsDroppedCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "amb":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "temperature":
                            return new AmbientTemperatureCommand();
                        case "humidity":
                            return new AmbientHumidityCommand();
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "acf":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "calibrate":
                            return new AccelCalibrateCommand();
                        case "measure":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new AccelMaxXCommand();
                                case "y":
                                    return new AccelMaxYCommand();
                                case "z":
                                    return new AccelMaxZCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "mean":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new AccelMeanXCommand();
                                case "y":
                                    return new AccelMeanYCommand();
                                case "z":
                                    return new AccelMeanZCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "standarddeviation":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new AccelStandardDeviationXCommand();
                                case "y":
                                    return new AccelStandardDeviationYCommand();
                                case "z":
                                    return new AccelStandardDeviationZCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "mag":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "calibrate":
                            return new MagCalibrateCommand();
                        case "measure":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new MagMaxXCommand();
                                case "y":
                                    return new MagMaxYCommand();
                                case "z":
                                    return new MagMaxZCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "mean":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new MagMeanXCommand();
                                case "y":
                                    return new MagMeanYCommand();
                                case "z":
                                    return new MagMeanZCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "standarddeviation":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new MagStandardDeviationXCommand();
                                case "y":
                                    return new MagStandardDeviationYCommand();
                                case "z":
                                    return new MagStandardDeviationZCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "mdm":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "id":
                            return new MdmIdCommand();
                        case "status":
                            return new MdmStatusCommand();
                        case "enable":
                            return new MdmEnableCommand();
                        case "disable":
                            return new MdmDisableCommand();
                        case "connect":
                            return new MdmConnectCommand();
                        case "disconnect":
                            return new MdmDisconnectCommand();
                        case "search":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "start":
                                    return new MdmSearchStartCommand();
                                case "end":
                                    return new MdmSearchEndCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "signal":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "strength":
                                    return new MdmSignalStrengthCommand();
                                case "interference":
                                    return new MdmSignalInterferenceCommand();
                                case "connects":
                                    return new MdmSignalConnectsCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "packets":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "tx":
                                    return new MdmPacketsTxCommand();
                                case "rx":
                                    return new MdmPacketsRxCommand();
                                case "dropped":
                                    return new MdmPacketsDroppedCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "sat":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "id":
                            return new SatIdCommand();
                        case "status":
                            return new SatStatusCommand();
                        case "disable":
                            return new SatDisableCommand();
                        case "enable":
                            return new SatEnableCommand();
                        case "search":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "start":
                                    return new SatSearchStartCommand();
                                case "end":
                                    return new SatSearchEndCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "signal":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "strength":
                                    return new SatSignalStrengthCommand();
                                case "interference":
                                    return new SatSignalInterferenceCommand();
                                case "connects":
                                    return new SatSignalConnectsCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "packets":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "tx":
                                    return new SatPacketsTxCommand();
                                case "rx":
                                    return new SatPacketsRxCommand();
                                case "dropped":
                                    return new SatPacketsDroppedCommand();
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "file":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "ls":
                            return new FileLsCommand();
                        case "rm":
                            return new FileRmCommand();
                        case "find":
                            return new FileFindCommand();
                        case "cp":
                            return new FileCpCommand();
                        case "cat":
                            return new FileCatCommand();
                        case "hexdump":
                            return new FileHexDumpCommand();
                        case "upload":
                            return new FileUploadCommand();
                        case "download":
                            return new FileDownloadCommand();
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                default:
                    throw new ArgumentException(nameof(command));
            }
            throw new NotImplementedException();
        }
    }
}
