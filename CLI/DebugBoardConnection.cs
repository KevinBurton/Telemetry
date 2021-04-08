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
        public DebugBoardConnection(string port) : base(port)
        {
            Port = port;
        }

        public string Port { get; }

        public IEnumerable<string> Read()
        {
            List<string> response = new List<string>();
            var currentLine = ReadLine();
            while (currentLine != null && currentLine.Length > 0 && currentLine[0] != '.' && currentLine[0] != '!')
            {
                response.Add(currentLine);
                // Read from serial port
                currentLine = ReadLine();
            }
            response.Add(currentLine);
            return response;
        }
        public void Send(string command)
        {
            if (!IsOpen)
            {
                Open();
            }
            Write(command);
        }
    }
}
