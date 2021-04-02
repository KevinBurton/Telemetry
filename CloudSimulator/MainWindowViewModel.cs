using PacketCommunication;
using System;
using System.Net;
using System.Net.Sockets;

namespace CloudSimulator
{
    public class MainWindowViewModel
    {
        public void OnReceiveCallback(IAsyncResult ar)
        {
            UdpClient u = ((UdpState)(ar.AsyncState)).Client;
            IPEndPoint e = ((UdpState)(ar.AsyncState)).Endpoint;
            try
            {

                byte[] receiveBytes = u.EndReceive(ar, ref e);

                var s = new UdpState() { Client = u, Endpoint = e };

                // Start listening again
                u.BeginReceive(this.OnReceiveCallback, s);

                // Process the received bytes
            }
            catch(SocketException ex)
            {

            }
        }
    }
}
