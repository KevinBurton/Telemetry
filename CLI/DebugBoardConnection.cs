using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class DebugBoardConnection : SerialPort, ICLIConnection
    {
        public DebugBoardConnection(string port)
        {
            Port = port;
        }

        public string Port { get; }

        public string Read()
        {
            return "test";
        }
        public void Send(string command)
        {
            System.Diagnostics.Debug.WriteLine(command);
        }
    }
}
