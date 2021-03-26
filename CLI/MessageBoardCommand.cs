using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class MessageBoardCommand : ICliCommandSend
    {
        #region ADC
        //adc
        //    help(List adc commands)
        public void AdcHelp()
        {
            throw new NotImplementedException();
        }
        //    start(Start adc conversions)
        public void AdcStart()
        {
            throw new NotImplementedException();
        }
        //    stop(Stop adc conversions)
        public void AdcStop()
        {
            throw new NotImplementedException();
        }
        //    reset(Reset adc device)
        public void AdcReset()
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
        public void AdcToggle()
        {
            throw new NotImplementedException();
        }
        //setofc[int24_t] (Set system offset calibration) 
        //  -8388608 to 8388607 
        public void Setofc()
        {
            throw new NotImplementedException();
        }
        //setfsc[float / uint16_t] (Set gain cal) 
        //  0-1.99993/0xNNNN
        public void Setfsc()
        {
            throw new NotImplementedException();
        }
        //setfs[mode] (Set frame-sync mode) 
        //  slave
        //  master
        public void Setfs()
        {
            throw new NotImplementedException();
        }
        //setinterface[mode] (Set interface mode) 
        //  spi
        //  fsync
        public void Setinterface()
        {
            throw new NotImplementedException();
        }
        //setfilter[mode] (Set filter mode) 
        //  wb1
        //  wb2
        //  ll
        public void Setfilter()
        {
            throw new NotImplementedException();
        }
        //setosr[mode] (Set oversampling ratio) 
        //  00 
        //  01 
        //  10 
        //  11 
        public void Setosr()
        {
            throw new NotImplementedException();
        }
        //sethr[mode] (Set low power or high res] 
        //  off
        //  o
        public void Sethr()
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
        public void Get()
        {
            throw new NotImplementedException();
        }
        //read[uint16_t] (Number of samples to read from adc) 
        //  0-65535 
        public void Read()
        {
            throw new NotImplementedException();
        }
        //cont(Get continuous readings from adc)
        public void Cont()
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
        public void RtcHelp()
        {
            throw new NotImplementedException();
        }
        public void RtcGet()
        {
            throw new NotImplementedException();
        }
        public void RtcSet()
        {
            throw new NotImplementedException();
        }
        public void RtcFout()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region NFC - Near Field Communication
        //        nfc
        //          help(List nfc commands)
        public void NfcHelp()
        {
            throw new NotImplementedException();
        }
        //          disable(Put the MCU to sleep)
        public void NfcDisable()
        {
            throw new NotImplementedException();
        }
        //          enable(Wake up the MCU)
        public void NfcEnable()
        {
            throw new NotImplementedException();
        }
        //          send[data]
        public void NfcSend()
        {
            throw new NotImplementedException();
        }
        //          discovery(Send Bluetooth discovery information to an Android device)
        public void NfcDiscovery()
        {
            throw new NotImplementedException();
        }
        //          toggle[data]
        public void NfcToggle()
        {
            throw new NotImplementedException();
        }
        //          cli(Switch between CLI via Bluetooth/Serial)
        public void NfcCli()
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
        public void RtdHelp()
        {
            throw new NotImplementedException();
        }
        public void RtdGet()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region BLE - Bluetooth Low Energy
        //        ble
        //          help(List ble commands)
        public void BleHelp()
        {
            throw new NotImplementedException();
        }
        //          status(Aggregate status information about transmitter ie. connected, last sent message) disable(Turn off bluetooth)
        public void BleStatus()
        {
            throw new NotImplementedException();
        }
        //          enable(Turn on bluetooth)
        public void BleEnable()
        {
            throw new NotImplementedException();
        }
        //          connect(Connect to previous bluetooth device)
        public void BleConnect()
        {
            throw new NotImplementedException();
        }
        //          disconnect(Disconnect current bluetooth device)
        public void BleDisconnect()
        {
            throw new NotImplementedException();
        }
        //          send[data]
        //              discovery(Send Bluetooth discovery information to an Android device)
        //              testmessage[data]
        //                  string of characters ending with nul
        public void BleSend()
        {
            throw new NotImplementedException();
        }
        //          toggle
        //              broadcast(Make the device discoverable to other bluetooth devices)
        //              pairing(Enter/exit bluetooth paring mode)
        public void BleToggle()
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
        public void BleSignal()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Humidity/Ambient Temperature Sensor
        //        ambient
        //          help(List humidity/ambient temperature commands)
        public void AmbientHelp()
        {
            throw new NotImplementedException();
        }
        //          temperature(Return the ambient temperature)
        public void AmbientTemperature()
        {
            throw new NotImplementedException();
        }
        //          humidity(Return the ambient humidity)
        public void AmbientHumidity()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Accelerometer
        //        accel
        //          help(List accelerometer commands)
        public void AccelHelp()
        {
            throw new NotImplementedException();
        }
        //          calibrate(Calibrate the accelerometer for the current orientation)
        public void AccelCalibrate()
        {
            throw new NotImplementedException();
        }
        //          measure
        //              x(Current magnitude in x axis)
        //              y(Current magnitude in y axis)
        //              z(Current magnitude in z axis)
        public void AccelMeasure()
        {
            throw new NotImplementedException();
        }
        //          max[data]
        //              x(Maximum magnitude in x axis)
        //              y(Maximum magnitude in y axis)
        //              z(Maximum magnitude in z axis)
        public void AccelMax()
        {
            throw new NotImplementedException();
        }
        //          mean[data]
        //              x(Mean magnitude in x axis)
        //              y(Mean magnitude in y axis)
        //              z(Mean magnitude in z axis)
        public void AccelMean()
        {
            throw new NotImplementedException();
        }
        //          standarddeviation[data]
        //              x(Standard deviation of magnitude in x axis)
        //              y(Standard deviation of magnitude in y axis)
        //              z(Standard deviation of magnitude in z axis)
        public void AccelStandardDeviation()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 3-Axis Magnetic Sensor
        //        mag
        //          help(List mag commands)
        public void MagHelp()
        {
            throw new NotImplementedException();
        }
        //          calibrate(Calibrate the magnetic sensor for the current orientation)
        public void MagCalibrate()
        {
            throw new NotImplementedException();
        }
        //          measure
        //              x(Current magnitude in x axis)
        //              y(Current magnitude in y axis)
        //              z(Current magnitude in z axis)
        public void MagMeasure()
        {
            throw new NotImplementedException();
        }
        //          max[data]
        //              x(Maximum magnitude in x axis)
        //              y(Maximum magnitude in y axis)
        //              z(Maximum magnitude in z axis)
        public void MagMax()
        {
            throw new NotImplementedException();
        }
        //          mean[data]
        //              x(Mean magnitude in x axis)
        //              y(Mean magnitude in y axis)
        //              z(Mean magnitude in z axis)
        public void MagMean()
        {
            throw new NotImplementedException();
        }
        //          standarddeviation[data]
        //              x(Standard deviation of magnitude in x axis)
        //              y(Standard deviation of magnitude in y axis)
        //              z(Standard deviation of magnitude in z axis)
        public void MagStandardDeviation()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Cellular Modem
        //        mdm
        //          help(List mdm commands)
        public void MdmHelp()
        {
            throw new NotImplementedException();
        }
        //          id(List the identification information for the modem)
        public void MdmId()
        {
            throw new NotImplementedException();
        }
        //          status(Aggregate status information about transmitter ie. connected, last sent message) disable(Turn off cellular modem)
        public void MdmStatus()
        {
            throw new NotImplementedException();
        }
        //          enable(Turn on cellular modem)
        public void MdmEnable()
        {
            throw new NotImplementedException();
        }
        //          connect(Connect to cellular tower device)
        public void MdmConnect()
        {
            throw new NotImplementedException();
        }
        //          disconnect(Disconnect current cellular tower device)
        public void MdmDisconnect()
        {
            throw new NotImplementedException();
        }
        //          search(Search for available cellular towers)
        public void MdmSearch()
        {
            throw new NotImplementedException();
        }
        //          send[data]
        //              testmessage[data]
        //                  string of characters ending with nul
        public void MdmSend()
        {
            throw new NotImplementedException();
        }
        //          signal
        //              strength(Return strength of signal to cellular tower)
        //              interference(Amount of interference encountered)
        //              connects(Count of how many times the device has connected to cellular towers)
        public void MdmSignal()
        {
            throw new NotImplementedException();
        }
        //          packets
        //              tx(Count of transmitted packets)
        //              rx(Count of received packets)
        //              dropped(Count of dropped packets)
        public void MdmPackets()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Satellite transmitter
        //        sat
        //          help(List sat commands)
        public void SatHelp()
        {
            throw new NotImplementedException();
        }
        //          id(List the identification information for the transmitter)
        public void SatId()
        {
            throw new NotImplementedException();
        }
        //          status(Aggregate status information about transmitter ie. connected, last sent message) disable(Turn off satellite transmitter)
        public void SatStatus()
        {
            throw new NotImplementedException();
        }
        //          enable(Turn on satellite transmitter)
        public void SatEnable()
        {
            throw new NotImplementedException();
        }
        //          connect(Connect to a satellite)
        public void SatConnect()
        {
            throw new NotImplementedException();
        }
        //          disconnect(Disconnect current satellite)
        public void SatDisconnect()
        {
            throw new NotImplementedException();
        }
        //          search(Search for available satellite signals)
        public void SatSearch()
        {
            throw new NotImplementedException();
        }
        //          send[data]
        //              testmessage[data]
        //                  string of characters ending with nul
        public void SatSend()
        {
            throw new NotImplementedException();
        }
        //          signal
        //              strength(Return strength of signal to the satellite
        //              interference (Amount of interference encountered)
        //              connects(Count of how many times the device has connected to satellites)
        public void SatSignal()
        {
            throw new NotImplementedException();
        }
        //          packets
        //              tx(Count of transmitted packets)
        //              rx(Count of received packets)
        //              dropped(Count of dropped packets)
        public void SatPackets()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
