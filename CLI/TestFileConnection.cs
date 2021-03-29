using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CLI
{
    public class TestFileConnection : ICLIConnection
    {
        public TestFileConnection(string path)
        {
            if(File.Exists(path))
            {
                Path = path;
                return;
            }
            throw new ArgumentException($"{path} does not exist.");
        }

        public string Path { get; }

        StreamReader Reader { get; }

        string Command { get; set; }
        public string[] Read()
        {
            return LookForMatch(Command);
        }
        public void Send(string command)
        {
            Command = command;
        }
        string[] LookForMatch(string command)
        {
            string line = string.Empty;
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(Path);
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    var rex = new Regex(line.Trim());
                    var match = rex.Match(Command);
                    if(match.Success)
                    {
                        return GetCommandReturn(sr);
                    }
                    //Skip to the next candidate
                    line = SkiptoNext(sr);
                }
                throw new InvalidOperationException($"File format error. Could not find {command}");
            }
            catch(InvalidOperationException)
            {
                throw new InvalidOperationException($"File format error. Could not find {command}");
            }
            finally
            {
                if(sr != null)
                {
                    sr.Close();
                }
            }
        }
        string SkiptoNext(StreamReader sr)
        {
            string line;
            while((line = sr.ReadLine()) != null)
            {
                if (line[0] == '.' || line[0] == '!')
                {
                    return sr.ReadLine();
                }
            }
            throw new InvalidOperationException("File format error (SkiptoNext)");
        }
        string[] GetCommandReturn(StreamReader sr)
        {
            var stringList = new List<string>();
            string line = string.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                if (line[0] == '.' || line[0] == '!')
                {
                    stringList.Add(line);
                    sr.ReadLine();
                    return stringList.ToArray();
                }
                stringList.Add(line);
            }
            throw new InvalidOperationException("File format error (GetCommandReturn)");
        }
    }
}
