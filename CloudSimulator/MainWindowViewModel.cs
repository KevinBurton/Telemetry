using PacketCommunication;
using System;
using System.Net;
using System.Net.Sockets;
using System.Linq;

namespace CloudSimulator
{
    public class MainWindowViewModel
    {
        public string Error { get; set; }
        public string Success { get; set; }
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
                if(receiveBytes.Length > 4)
                {
                    switch(receiveBytes[3])
                    {
                        case 0x1:
                            // LTE Measurement
                            if(receiveBytes.Length < 32)
                            {
                                // Error Not enough bytes to contain the header
                                errorMessage = $"Received {receiveBytes.Length} bytes identified as an LTE Measurement message but there are not enought bytes for the header";
                                break;
                            }
                            successMessage = $"Received {receiveBytes.Length} bytes identified as an LTE Measurement message";
                            break;
                        case 0x2:
                            // Satelite Measurement
                            if(receiveBytes.Length < 8)
                            {
                                // Error Not enough bytes to contain the header
                                errorMessage = $"Received {receiveBytes.Length} bytes identified as an Satelite Measurement message but there are not enought bytes for the header";
                                break;
                            }
                            successMessage = $"Received {receiveBytes.Length} bytes identified as an Satelite Measurement message";
                            break;
                        case 0x3:
                            // Log Structure
                            if(receiveBytes.Length < 8)
                            {
                                // Error Not enough bytes to contain the header
                                errorMessage = $"Received {receiveBytes.Length} bytes identified as an Log Structure message but there are not enought bytes for the header";
                                break;
                            }
                            successMessage = $"Received {receiveBytes.Length} bytes identified as a Log Stucture message";
                            break;
                        case 0x4:
                            // Configuration
                            if(receiveBytes.Length < 8)
                            {
                                // Error Not enough bytes to contain the header
                                errorMessage = $"Received {receiveBytes.Length} bytes identified as an Configuration message but there are not enought bytes for the header";
                                break;
                            }
                            successMessage = $"Received {receiveBytes.Length} bytes identified as a Configuration message";
                            break;
                        case 0x5:
                            // Unformatted 1KB Block
                            if(receiveBytes.Length < 8)
                            {
                                // Error Not enough bytes to contain the header
                                errorMessage = $"Received {receiveBytes.Length} bytes identified as an Unformatted 1KB Block message but there are not enought bytes for the header";
                                break;
                            }
                            successMessage = $"Received {receiveBytes.Length} bytes identified as as Unformatted 1KB Block message";
                            break;
                        default:
                            // Error. Unrecognized message type
                            errorMessage = $"Received {receiveBytes.Length} bytes but could not determine the message type {receiveBytes[3]}";
                            break;
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
            catch(SocketException ex)
            {
                Error = $"Socket exception received {ex.Message} - {ex.ErrorCode}";
            }

            // Start listening again
            u.BeginReceive(this.OnReceiveCallback, s);

        }
    }
}
