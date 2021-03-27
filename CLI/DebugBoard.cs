using System;

namespace CLI
{
    public class DebugBoard : ICLI
    {
        public DebugBoard(ICLIConnection connection)
        {
            Connection = connection;
        }

        public ICLIConnection Connection { get; }

        void Send(string command)
        {
            Connection.Send(command);
        }
        ICLICommandResult Receive()
        {
            return new DebugBoardCommandResult(new string[0]);
        }

        public ICLICommandResult DacResetCommand()
        {
            try
            {
                Send("dac reset");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult DacSetCountCommand(int dac, int channel, float value)
        {
            try
            {
                Send($"dac set {dac} {channel} counts {value}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult DacSetVoltCommand(int dac, int channel, float value)
        {
            try
            {
                Send($"dac set {dac} {channel} volts {value}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult NkcCommand()
        {
            try
            {
                Send("nkc");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult PotResetCommand()
        {
            try
            {
                Send("pot reset");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult PotSetCommand(float value)
        {
            try
            {
                Send($"pot set {value}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult SerialInjecUrcCommand(string urc)
        {
            try
            {
                Send($"serial inject_urc {urc}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }
        public ICLICommandResult FileCatCommand(string fileName)
        {
            try
            {
                Send($"file cat {fileName}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult FileCpCommand(string currentPath, string newPath)
        {
            try
            {
                Send($"file cp {currentPath} {newPath}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult FileDownloadCommand(string path)
        {
            try
            {
                Send("$file download {path}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult FileFindCommand(string directory, string flags, string expression)
        {
            try
            {
                Send($"file find {directory} {flags} {expression}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult FileHexDumpCommand(string flags, string filename)
        {
            try
            {
                Send($"file hexdump {flags} {filename}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult FileLsCommand(string flags, string directory)
        {
            try
            {
                Send($"file ls {flags} {directory}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult FileRmCommand(string flags, string path)
        {
            try
            {
                Send($"file rm {flags} {path}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }

        public ICLICommandResult FileUploadCommand(string path, string username, string destinationServer)
        {
            try
            {
                Send($"file upload {path} {username}@{destinationServer}");
            }
            catch (CLIException)
            {
            }
            throw new NotImplementedException();
        }
    }
}
