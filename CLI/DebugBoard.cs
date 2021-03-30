using System;

namespace CLI
{
    public class DebugBoard : ICLI
    {
        public DebugBoard(ICLIConnection connection)
        {
            Connection = connection;
        }

        ICLIConnection Connection { get; }

        void Send(string command)
        {
            Connection.Send(command);
        }
        ICLICommandResult Receive()
        {
            var response = Connection.Read();
            return new DebugBoardCommandResult(response);
        }

        public ICLICommandResult DacResetCommand()
        {
            Send("dac reset");
            return Receive();
        }

        public ICLICommandResult DacSetCountCommand(int dac, int channel, float value)
        {
            Send($"dac set {dac} {channel} counts {value}");
            return Receive();
        }

        public ICLICommandResult DacSetVoltCommand(int dac, int channel, float value)
        {
            Send($"dac set {dac} {channel} volts {value}");
            return Receive();
        }

        public ICLICommandResult NkcCommand()
        {
            Send("nkc");
            return Receive();
        }

        public ICLICommandResult PotResetCommand()
        {
            Send("pot reset");
            return Receive();
        }

        public ICLICommandResult PotSetCommand(float value)
        {
            Send($"pot set {value}");
            return Receive();
        }

        public ICLICommandResult SerialInjecUrcCommand(string urc)
        {
            Send($"serial inject_urc {urc}");
            return Receive();
        }
        public ICLICommandResult FileCatCommand(string fileName)
        {
            Send($"file cat {fileName}");
            return Receive();
        }

        public ICLICommandResult FileCpCommand(string currentPath, string newPath)
        {
            Send($"file cp {currentPath} {newPath}");
            return Receive();
        }

        public ICLICommandResult FileFindCommand(string directory, string flags, string expression)
        {
            Send($"file find {directory} {flags} {expression}");
            return Receive();
        }

        public ICLICommandResult FileHexDumpCommand(string flags, string fileName)
        {
            Send($"file hexdump {flags} {fileName}");
            return Receive();
        }

        public ICLICommandResult FileLsCommand(string flags, string directory)
        {
            Send($"file ls {flags} {directory}");
            return Receive();
        }

        public ICLICommandResult FileRmCommand(string flags, string path)
        {
            Send($"file rm {flags} {path}");
            return Receive();
        }

        public ICLICommandResult FileUploadCommand(string path, string userName, string destinationServer)
        {
            Send($"file upload {path} {userName}@{destinationServer}");
            return Receive();
        }

        public ICLICommandResult FileDownloadCommand(string path)
        {
            Send($"file download {path}");
            return Receive();
        }
    }
}
