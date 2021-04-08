using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PacketCommunication
{
    public class Server
    {
        UdpClient udpServer;
        public Server(Action<IAsyncResult> callback, int port = 11000)
        {
            udpServer = new UdpClient(port);
            Callback = callback;
            Port = port;
        }

        public Action<IAsyncResult> Callback { get; }
        public int Port { get; }

        public void Start()
        {
            // Receive a message and write it to the console.
            IPEndPoint e = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            UdpClient c = new UdpClient(e);

            UdpState s = new UdpState();
            s.Endpoint = e;
            s.Client = c;

            c.BeginReceive(new AsyncCallback(Callback), s);
        }
    }
}
