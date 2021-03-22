using CLI.Args;
using CLI.Args.MeasurementBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLI
{
    public class MeasurementBoardCommand : CommandBase
    {
        protected override MethodInfo[] Methods { get; set; }

        public MeasurementBoardCommand()
        {
            Methods = typeof(MeasurementBoardCommand).GetMethods();
        }
        #region ADC
        //
        //    help(List adc commands)
        private void AdcHelp(AdcHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        //    start(Start adc conversions)
        private void AdcStart(AdcStartArgs a = null)
        {
            throw new NotImplementedException();
        }
        //    stop(Stop adc conversions)
        private void AdcStop(AdcStopArgs a = null)
        {
            throw new NotImplementedException();
        }
        //    reset(Reset adc device)
        private void AdcReset(AdcResetArgs a = null)
        {
            throw new NotImplementedException();
        }
        //    toggle[Register] (Toggle config bits) 
        //      crcb
        //      statusword
        //      spitout_en
        //      spitout
        //      ofc
        //      fsc
        private void AdcToggle(AdcToggleArgs a = null)
        {
            throw new NotImplementedException();
        }
        //setofc[int24_t] (Set system offset calibration) 
        //  -8388608 to 8388607 
        private void Setofc(SetofcArgs a = null)
        {
            throw new NotImplementedException();
        }
        //setfsc[float / uint16_t] (Set gain cal) 
        //  0-1.99993/0xNNNN
        private void Setfsc(SetfscArgs a = null)
        {
            throw new NotImplementedException();
        }
        //setfs[mode] (Set frame-sync mode) 
        //  slave
        //  master
        private void Setfs(SetfsArgs a = null)
        {
            throw new NotImplementedException();
        }
        //setinterface[mode] (Set interface mode) 
        //  spi
        //  fsync
        private void Setinterface(SetinterfaceArgs a = null)
        {
            throw new NotImplementedException();
        }
        //setfilter[mode] (Set filter mode) 
        //  wb1
        //  wb2
        //  ll
        private void Setfilter(SetfilterArgs a = null)
        {
            throw new NotImplementedException();
        }
        //setosr[mode] (Set oversampling ratio) 
        //  00 
        //  01 
        //  10 
        //  11 
        private void Setosr(SetosrArgs a = null)
        {
            throw new NotImplementedException();
        }
        //sethr[mode] (Set low power or high res] 
        //  off
        //  o
        private void Sethr(SethrArgs a = null)
        {
            throw new NotImplementedException();
        }
        //get[data] (Get adc information) 
        //  id
        //  config
        //  ofc
        //  fsc
        //  modes
        //  all
        private void Get(GetArgs a = null)
        {
            throw new NotImplementedException();
        }
        //read[uint16_t] (Number of samples to read from adc) 
        //  0-65535 
        private void Read(ReadArgs a = null)
        {
            throw new NotImplementedException();
        }
        //cont(Get continuous readings from adc)
        private void Cont(ContArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region RTC - Real Time Clock
        //        rtc
        //          help(List rtc commands)
        //          get[data] (Get rtc information) 
        //              frequency(Frequency of clock in use)
        //              time(Return the current time in timestamp format)
        //              wake[data] (View the amount of time between interrupt triggers) 
        //                  time(YYYY-MM-DD HH:MM:SS)
        //                  remaining(YYYY-MM-DD HH:MM:SS)
        //                  seconds(0-59)
        //                  minutes(0-59)
        //                  hours(0-23)
        //                  days(0-31)
        //                  months(0-12)
        //                  years(0-99)
        //          set[data]
        //              time[data]
        //                  timestamp(Set the current time in timestamp format)
        //              wake[data] (Set the amount of time between interrupt triggers) 
        //                  time(YYYY-MM-DD HH:MM:SS)
        //                  seconds(0-59)
        //                  minutes(0-59)
        //                  hours(0-23)
        //                  date(0-31)
        //                  months(0-12)
        //                  years(0-99)
        //          fout
        //              set(set the FOUT pin)
        //              clear(clear the FOUT pin)
        private void RtcHelp(RtcHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void RtcGet(RtcGetArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void RtcSet(RtcSetArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void RtcFout(RtcFoutArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region NFC - Near Field Communication
        //        nfc
        //          help(List nfc commands)
        private void NfcHelp(NfcHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          disable(Put the MCU to sleep)
        private void NfcDisable(NfcDisableArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          enable(Wake up the MCU)
        private void NfcEnable(NfcEnableArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          send[data]
        private void NfcSend(NfcSendArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          discovery(Send Bluetooth discovery information to an Android device)
        private void NfcDiscovery(NfcDiscoveryArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          toggle[data]
        private void NfcToggle(NfcToggleArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          cli(Switch between CLI via Bluetooth/Serial)
        private void NfcCli(NfcCliArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region RTD - Resistive Temperature Device
        //        rtd
        //          help(List rtd commands)
        //          get[data]
        //              resistance(Get the resistance measured by the RTD)
        //              Kelvin(Temperature)
        //              Fahrenheit(Temperature)
        private void RtdHelp(RtdHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void RtdGet(RtdGetArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region BLE - Bluetooth Low Energy
        //        ble
        //          help(List ble commands)
        private void BleHelp(BleHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          status(Aggregate status information about transmitter ie. connected, last sent message) disable(Turn off bluetooth)
        private void BleStatus(BleStatusArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          enable(Turn on bluetooth)
        private void BleEnable(BleEnableArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          connect(Connect to previous bluetooth device)
        private void BleConnect(BleConnectArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          disconnect(Disconnect current bluetooth device)
        private void BleDisconnect(BleDisconnectArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          send[data]
        //              discovery(Send Bluetooth discovery information to an Android device)
        //              testmessage[data]
        //                  string of characters ending with nul
        private void BleSend(BleSendArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          toggle
        //              broadcast(Make the device discoverable to other bluetooth devices)
        //              pairing(Enter/exit bluetooth paring mode)
        private void BleToggle(BleToggleArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          signal
        //              strength(Return strength of signal to end device)
        //              interference(Amount of interference encountered)
        //              connects(Count of how many times the device has connected to bluetooth devices) packets
        //              tx(Count of transmitted packets)
        //              rx(Count of received packets)
        //              dropped(Count of dropped packets)
        private void BleSignal(BleSignalArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Humidity/Ambient Temperature Sensor
        //        ambient
        //          help(List humidity/ambient temperature commands)
        private void AmbientHelp(AmbientHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          temperature(Return the ambient temperature)
        private void AmbientTemperature(AmbientTemperatureArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          humidity(Return the ambient humidity)
        private void AmbientHumidity(AmbientHumidityArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Accelerometer
        //        accel
        //          help(List accelerometer commands)
        private void AccelHelp(AccelHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          calibrate(Calibrate the accelerometer for the current orientation)
        private void AccelCalibrate(AccelCalibrateArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          measure
        //              x(Current magnitude in x axis)
        //              y(Current magnitude in y axis)
        //              z(Current magnitude in z axis)
        private void AccelMeasure(AccelMeasureArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          max[data]
        //              x(Maximum magnitude in x axis)
        //              y(Maximum magnitude in y axis)
        //              z(Maximum magnitude in z axis)
        private void AccelMax(AccelMaxArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          mean[data]
        //              x(Mean magnitude in x axis)
        //              y(Mean magnitude in y axis)
        //              z(Mean magnitude in z axis)
        private void AccelMean(AccelMeanArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          standarddeviation[data]
        //              x(Standard deviation of magnitude in x axis)
        //              y(Standard deviation of magnitude in y axis)
        //              z(Standard deviation of magnitude in z axis)
        private void AccelStandardDeviation(AccelStandardDeviationArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 3-Axis Magnetic Sensor
        //        mag
        //          help(List mag commands)
        private void MagHelp(MagHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          calibrate(Calibrate the magnetic sensor for the current orientation)
        private void MagCalibrate(MagCalibrateArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          measure
        //              x(Current magnitude in x axis)
        //              y(Current magnitude in y axis)
        //              z(Current magnitude in z axis)
        private void MagMeasure(MagMeasureArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          max[data]
        //              x(Maximum magnitude in x axis)
        //              y(Maximum magnitude in y axis)
        //              z(Maximum magnitude in z axis)
        private void MagMax(MagMaxArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          mean[data]
        //              x(Mean magnitude in x axis)
        //              y(Mean magnitude in y axis)
        //              z(Mean magnitude in z axis)
        private void MagMean(MagMeanArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          standarddeviation[data]
        //              x(Standard deviation of magnitude in x axis)
        //              y(Standard deviation of magnitude in y axis)
        //              z(Standard deviation of magnitude in z axis)
        private void MagStandardDeviation(MagStandardDeviationArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Cellular Modem
        //        mdm
        //          help(List mdm commands)
        private void MdmHelp(MdmHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          id(List the identification information for the modem)
        private void MdmId(MdmIdArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          status(Aggregate status information about transmitter ie. connected, last sent message) disable(Turn off cellular modem)
        private void MdmStatus(MdmStatusArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          enable(Turn on cellular modem)
        private void MdmEnable(MdmEnableArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          connect(Connect to cellular tower device)
        private void MdmConnect(MdmConnectArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          disconnect(Disconnect current cellular tower device)
        private void MdmDisconnect(MdmDisconnectArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          search(Search for available cellular towers)
        private void MdmSearch(MdmSearchArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          send[data]
        //              testmessage[data]
        //                  string of characters ending with nul
        private void MdmSend(MdmSendArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          signal
        //              strength(Return strength of signal to cellular tower)
        //              interference(Amount of interference encountered)
        //              connects(Count of how many times the device has connected to cellular towers)
        private void MdmSignal(MdmSignalArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          packets
        //              tx(Count of transmitted packets)
        //              rx(Count of received packets)
        //              dropped(Count of dropped packets)
        private void MdmPackets(MdmPacketsArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Satellite transmitter
        //        sat
        //          help(List sat commands)
        private void SatHelp(SatHelpArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          id(List the identification information for the transmitter)
        private void SatId(SatIdArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          status(Aggregate status information about transmitter ie. connected, last sent message) disable(Turn off satellite transmitter)
        private void SatStatus(SatStatusArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          enable(Turn on satellite transmitter)
        private void SatEnable(SatEnableArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          connect(Connect to a satellite)
        private void SatConnect(SatConnectArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          disconnect(Disconnect current satellite)
        private void SatDisconnect(SatDisconnectArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          search(Search for available satellite signals)
        private void SatSearch(SatSearchArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          send[data]
        //              testmessage[data]
        //                  string of characters ending with nul
        private void SatSend(SatSendArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          signal
        //              strength(Return strength of signal to the satellite
        //              interference (Amount of interference encountered)
        //              connects(Count of how many times the device has connected to satellites)
        private void SatSignal(SatSignalArgs a = null)
        {
            throw new NotImplementedException();
        }
        //          packets
        //              tx(Count of transmitted packets)
        //              rx(Count of received packets)
        //              dropped(Count of dropped packets)
        private void SatPackets(SatPacketsArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region File System
        private void FileLs (FileLsArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void FileRm (FileRmArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void FileFind (FileFindArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void FileCp (FileCpArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void FileCat (FileCatArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void FileHexDump (FileHexDumpArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void FileUpload (FileUploadArgs a = null)
        {
            throw new NotImplementedException();
        }
        private void FileDownload (FileDownloadArgs a = null)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
