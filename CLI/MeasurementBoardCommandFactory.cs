using CLI.Commands.MeasurementBoard;
using System;
using System.Text.RegularExpressions;

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
            var tokens = new Regex(@"\s+").Split(command);
            float fv;
            int iv;
            switch (tokens[0].ToLowerInvariant())
            {
                case "adc":
                    if(tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "start":
                            return new AdcStartCommand(command);
                        case "stop":
                            return new AdcStopCommand(command);
                        case "reset":
                            return new AdcResetCommand(command);
                        case "toggle":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "crcb":
                                    return new AdcToggleCrcbCommand(command);
                                case "statusword":
                                    return new AdcToggleStatusWord(command);
                                case "spitout_en":
                                    return new AdcToggleSpitout_enCommand(command);
                                case "spitout":
                                    return new AdcToggleSpitoutCommand(command);
                                case "ofc":
                                    return new AdcToggleOfcCommand(command);
                                case "fsc":
                                    return new AdcToggleFscCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "setofc":
                            if (tokens.Length < 3) throw new ArgumentException(nameof(command));
                            iv = Utility.Utility.ParseIntegerValue(tokens[2]);
                            return new AdcSetofcCommand(iv);
                        case "setfsc":
                            if (tokens.Length < 3) throw new ArgumentException(nameof(command));
                            if(float.TryParse(tokens[2], out fv))
                            {
                                new AdcSetfscCommand(command,fv);
                            }
                            throw new ArgumentException(nameof(command));
                        case "setfs":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "slave":
                                    return new AdcSetfsSlaveCommand(command);
                                case "master":
                                    return new AdcSetfsMasterCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "setinterface":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "spi":
                                    return new AdcSetInterfaceSpiCommand(command);
                                case "fsync":
                                    return new AdcSetinterfaceFsyncCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "setfilter":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch(tokens[2].ToLowerInvariant())
                            {
                                case "wb1":
                                    return new AdcSetfilterWb1Command(command);
                                case "wb2":
                                    return new AdcSetfilterWb2Command(command);
                                case "ll":
                                    return new AdcSetfilterLlCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "setosr":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "00":
                                    return new AdcSetosr00Command(command);
                                case "01":
                                    return new AdcSetosr01Command(command);
                                case "l0":
                                    return new AdcSetosr10Command(command);
                                case "ll":
                                    return new AdcSetosr11Command(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "sethr":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "off":
                                    return new AdcSethrOffCommand(command);
                                case "o":
                                    return new AdcSethrOCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "get":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "id":
                                    return new AdcGetIdCommand(command);
                                case "config":
                                    return new AdcGetConfigCommand(command);
                                case "ofc":
                                    return new AdcGetOfcCommand(command);
                                case "fsc":
                                    return new AdcGetFscCommand(command);
                                case "modes":
                                    return new AdcGetModesCommand(command);
                                case "all":
                                    return new AdcGetAllCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "read":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "voltage":
                                    return new AdcReadVoltageCommand(command);
                                case "counts":
                                    return new AdcReadCountsCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "cont":
                            return new AdcContCommand(command);
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "rtc":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "get":
                            return new RtcGetCommand(command);
                        case "set":
                            return new RtcSetCommand(command);
                        case "reset":
                            return new RtcResetCommand(command);
                        case "fout":
                            return new RtcFoutCommand(command);
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "nfc":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "wake":
                            return new NfcWakeCommand(command);
                        case "disable":
                            return new NfcDisableCommand(command);
                        case "enable":
                            return new NfcEnableCommand(command);
                        case "toggle":
                            return new NfcToggleCommand(command);
                        case "get":
                            return new NfcGetCommand(command);
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
                                    return new RtdGetResistanceCommand(command);
                                case "kelvin":
                                    return new RtdGetKelvinCommand(command);
                                case "fahrenheit":
                                    return new RtdGetFarenheitCommand(command);
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
                            return new BleStatusCommand(command);
                        case "disable":
                            return new BleDisableCommand(command);
                        case "enable":
                            return new BleEnableCommand(command);
                        case "connect":
                            return new BleConnectCommand(command);
                        case "disconnect":
                            return new BleDisconnectCommand(command);
                        case "send":
                            return new BlePacketsTxCommand(command);
                        case "toggle":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "broadcast":
                                    return new BleToggleBroadcastCommand(command);
                                case "pairing":
                                    return new BleTogglePairingCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "signal":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "strength":
                                    return new BleSignalStrengthCommand(command);
                                case "interference":
                                    return new BleSignalInterferenceCommand(command);
                                case "connects":
                                    return new BleSignalConnectsCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "packets":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "tx":
                                    return new BlePacketsTxCommand(command);
                                case "rx":
                                    return new BlePacketsRxCommand(command);
                                case "dropped":
                                    return new BlePacketsDroppedCommand(command);
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
                            return new AmbientTemperatureCommand(command);
                        case "humidity":
                            return new AmbientHumidityCommand(command);
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "acf":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "calibrate":
                            return new AccelCalibrateCommand(command);
                        case "measure":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new AccelMeasureXCommand(command);
                                case "y":
                                    return new AccelMeasureYCommand(command);
                                case "z":
                                    return new AccelMeasureZCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "mean":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new AccelMeanXCommand(command);
                                case "y":
                                    return new AccelMeanYCommand(command);
                                case "z":
                                    return new AccelMeanZCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "standarddeviation":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new AccelStandardDeviationXCommand(command);
                                case "y":
                                    return new AccelStandardDeviationYCommand(command);
                                case "z":
                                    return new AccelStandardDeviationZCommand(command);
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
                            return new MagCalibrateCommand(command);
                        case "measure":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new MagMaxXCommand(command);
                                case "y":
                                    return new MagMaxYCommand(command);
                                case "z":
                                    return new MagMaxZCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "mean":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new MagMeanXCommand(command);
                                case "y":
                                    return new MagMeanYCommand(command);
                                case "z":
                                    return new MagMeanZCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "standarddeviation":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "x":
                                    return new MagStandardDeviationXCommand(command);
                                case "y":
                                    return new MagStandardDeviationYCommand(command);
                                case "z":
                                    return new MagStandardDeviationZCommand(command);
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
                            return new MdmIdCommand(command);
                        case "status":
                            return new MdmStatusCommand(command);
                        case "enable":
                            return new MdmEnableCommand(command);
                        case "disable":
                            return new MdmDisableCommand(command);
                        case "connect":
                            return new MdmConnectCommand(command);
                        case "disconnect":
                            return new MdmDisconnectCommand(command);
                        case "search":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "start":
                                    return new MdmSearchStartCommand(command);
                                case "end":
                                    return new MdmSearchEndCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "signal":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "strength":
                                    return new MdmSignalStrengthCommand(command);
                                case "interference":
                                    return new MdmSignalInterferenceCommand(command);
                                case "connects":
                                    return new MdmSignalConnectsCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "packets":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "tx":
                                    return new MdmPacketsTxCommand(command);
                                case "rx":
                                    return new MdmPacketsRxCommand(command);
                                case "dropped":
                                    return new MdmPacketsDroppedCommand(command);
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
                            return new SatIdCommand(command);
                        case "status":
                            return new SatStatusCommand(command);
                        case "disable":
                            return new SatDisableCommand(command);
                        case "enable":
                            return new SatEnableCommand(command);
                        case "search":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "start":
                                    return new SatSearchStartCommand(command);
                                case "end":
                                    return new SatSearchEndCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "signal":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "strength":
                                    return new SatSignalStrengthCommand(command);
                                case "interference":
                                    return new SatSignalInterferenceCommand(command);
                                case "connects":
                                    return new SatSignalConnectsCommand(command);
                                default:
                                    throw new ArgumentException(nameof(command));
                            }
                        case "packets":
                            if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                            switch (tokens[2].ToLowerInvariant())
                            {
                                case "tx":
                                    return new SatPacketsTxCommand(command);
                                case "rx":
                                    return new SatPacketsRxCommand(command);
                                case "dropped":
                                    return new SatPacketsDroppedCommand(command);
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
                            return new FileLsCommand(command);
                        case "rm":
                            return new FileRmCommand(command);
                        case "find":
                            return new FileFindCommand(command);
                        case "cp":
                            return new FileCpCommand(command);
                        case "cat":
                            return new FileCatCommand(command);
                        case "hexdump":
                            return new FileHexDumpCommand(command);
                        case "upload":
                            return new FileUploadCommand(command);
                        case "download":
                            return new FileDownloadCommand(command);
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                default:
                    throw new ArgumentException(nameof(command));
            }
            throw new NotImplementedException(command);
        }
    }
}
