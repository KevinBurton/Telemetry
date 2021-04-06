using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace PacketCommunication
{
    public class Client
    {
        public Action<IAsyncResult> Callback { get; }

        public Client (Action<IAsyncResult> callback)
        {
            Callback = callback;
            UdpClient = new UdpClient();
        }

        private UdpClient UdpClient { get; set; }
        public void Send(string address, int port, byte[] data)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(address), port); // endpoint where server is listening
            UdpClient.Connect(ep);
            // send data
            UdpClient.Send(data,data.Length);

            var s = new UdpState()
            {
                Client = UdpClient,
                Endpoint = ep
            };
            // then receive data
            var receivedData = UdpClient.BeginReceive(new AsyncCallback(Callback), s);
        }
    }
}
