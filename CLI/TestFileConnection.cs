﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CLI
{
    public class TestFileConnection : ICLIConnection
    {
        public TestFileConnection(string path, DebugMeasurementShared shared)
        {
            Shared = shared;
            if (File.Exists(path))
            {
                Path = path;
                return;
            }
            throw new ArgumentException($"{path} does not exist.");
        }

        public string Path { get; }

        StreamReader Reader { get; }

        string Command { get; set; }
        public DebugMeasurementShared Shared { get; }

        public string[] Read()
        {
            var result = LookForMatch(Command);
            if(Command.Contains("adc read"))
            {
                // Handle adc read special
                // The assumption is that there is only
                // a '.' success indicator
                var tokens = Command.Split(' ');
                var count = int.Parse(tokens[3]);
                var diff = 0.0f;
                // 5 percent variation +_4 volts 0-4095 counts
                if(tokens[2] == "counts")
                {
                    diff = 205f;
                }
                else
                {
                    diff = 0.4f;
                }
                var value = tokens[2] == "counts" ? Shared.Counts : Shared.Volts;
                var resultList = new List<string>();
                for(var i = 0; i < count; i++)
                {
                    resultList.Add($"{value + (i%2 == 0 ? -diff : diff)}");
                }
                resultList.Add(".");
                return resultList.ToArray();
            }
            else if(Command.Contains("dac set"))
            {
                var tokens = Command.Split(' ');
                Shared.DAC = int.Parse(tokens[2]);
                Shared.Channel = int.Parse(tokens[3]);
                if(tokens[4] == "volts")
                {
                    var value = float.Parse(tokens[5]);
                    value = Math.Min(value, 4);
                    value = Math.Max(value, -4);
                    Shared.Volts = value;
                }
                else if(tokens[4] == "counts")
                {
                    var value = int.Parse(tokens[5]);
                    value = Math.Min(value, 4095);
                    value = Math.Max(value, 0);
                    Shared.Counts = (ushort)value;
                }
            }
            return result;
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
                        var result = GetCommandReturn(sr);
                        for(var i = 0;i < match.Groups.Count; i++)
                        {
                            for(var j = 0; j < result.Length; j++)
                            {
                                result[j] = result[j].Replace($"{i}$", match.Groups[i].Value);
                            }
                        }
                        return result;
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
