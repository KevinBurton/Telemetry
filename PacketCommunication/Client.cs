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
        UdpClient client;
        public Client ()
        {
            client = new UdpClient();
        }
        public void Send(string address, int port, byte[] data)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(address), port); // endpoint where server is listening
            client.Connect(ep);
            // send data
            client.Send(data,data.Length);

            // then receive data
            var receivedData = client.Receive(ref ep);
            Console.Write("receive data from " + ep.ToString());
        }
    }
}
