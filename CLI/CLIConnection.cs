using System;
using System.IO.Ports;

namespace CLI
{
    public class CLIConnection : SerialPort, ICLIConnection
    {
        public string Port { get; }

        public CLIConnection(string port)
        {
            Port = port;
        }
        public void Send(string value)
        {
            throw new NotImplementedException();
        }
        public string Read()
        {
            var response = string.Empty;

            do
            {
                // Read from serial port
                response += ". Success";
            } while (response[1] != '.' && response[0] != '!');
            return response;
            throw new NotImplementedException();
        }
    }
}
