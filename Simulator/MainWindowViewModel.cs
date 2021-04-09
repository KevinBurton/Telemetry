using Microsoft.Extensions.Options;
using PacketCommunication;
using Simulator.Common;
using Simulator.Common.Models;
using Simulator.Controls;
using Simulator.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Simulator
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(IOptions<SateliteConfiguration> settings)
        {
            LTEViewModel = new LTEViewModel(lteModel);
            SateliteViewModel = new SateliteViewModel(sateliteModel);
            LogViewModel = new LogViewModel(logModel);
            ConfigViewModel = new ConfigViewModel(configModel);

            SendCommand = new DelegateCommand(Send);
            SendSateliteCommand = new DelegateCommand(SendSatelite);
            Settings = settings;
        }

        LTE lteModel = new();
        Satelite sateliteModel = new();
        Log logModel = new();
        Config configModel = new();

        public LTEViewModel LTEViewModel { get; }
        public SateliteViewModel SateliteViewModel { get; }
        public LogViewModel LogViewModel { get; }
        public ConfigViewModel ConfigViewModel { get; }
        public DelegateCommand SendCommand { get; }
        public DelegateCommand SendSateliteCommand { get; }
        public string Success { get; set; }
        public string Error { get; set;}
        public IOptions<SateliteConfiguration> Settings { get; }

        public void OnReceiveCallback(IAsyncResult ar)
        {
            UdpClient u = ((UdpState)(ar.AsyncState)).Client;
            IPEndPoint e = ((UdpState)(ar.AsyncState)).Endpoint;
            var s = new UdpState() { Client = u, Endpoint = e };
            var successMessage = string.Empty;
            var errorMessage = string.Empty;
            try
            {

                byte[] receiveBytes = u.EndReceive(ar, ref e);

                // Process the received bytes
                if(receiveBytes.Length > 8)
                {
                    if(MessageTypeMetrics.KnownMessageType(receiveBytes[3]))
                    {
                        MessageTypeCharacteristics characteristics = MessageTypeMetrics.Characteristics(receiveBytes[3]);
                        if (receiveBytes.Length < characteristics.HeaderLength)
                        {
                            errorMessage = $"Received {receiveBytes.Length} bytes identified as an {characteristics.Description}  message but there are not enought bytes for the header";
                        }
                        else
                        {
                            successMessage = $"Received {receiveBytes.Length} bytes identified as an {characteristics.Description} message";
                        }
                    }
                    else
                    {
                            errorMessage = $"Received {receiveBytes.Length} bytes that shows an unknown message type {receiveBytes[3]}";
                    }
                }
                else
                {
                    // This is an error because not enough bytes were received to
                    // determine what the message was.
                    errorMessage = $"Received {receiveBytes.Length} bytes but there are not enough bytes to determine the message type";
                }

                // Set the status and error

                Error = errorMessage;
                Success = successMessage;
            }
            catch(KeyNotFoundException ex)
            {
                Error = $"Key not found exception received {ex.Message}";
            }
            catch(SocketException ex)
            {
                Error = $"Socket exception received {ex.Message} - {ex.ErrorCode}";
            }
        }

        public void Send()
        {
            lteModel.Initialize();
            sateliteModel.Initialize();

            var client = new Client(OnReceiveCallback);

            System.Diagnostics.Debug.WriteLine($"Sending {lteModel.Block.Length} bytes of LTE data");
            client.Send(Settings.Value.Address, Settings.Value.Port, lteModel.Block);

        }
        public void SendSatelite()
        {
            sateliteModel.Initialize();

            var client = new Client(OnReceiveCallback);

            System.Diagnostics.Debug.WriteLine($"Sending {sateliteModel.Block.Length} bytes of Satelite data");
            client.Send(Settings.Value.Address, Settings.Value.Port, sateliteModel.Block);
        }
    }
}
