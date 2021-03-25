using CLI.Commands.DebugBoard;
using System;
using System.Text.RegularExpressions;

namespace CLI
{
    public static class DebugtBoardCommandFactory
    {
        public static ICLICommand Command(string command)
        {
            if(string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentNullException(nameof(command));
            }
            var tokens = new Regex(@"\s+").Split(command);
            switch(tokens[0].ToLowerInvariant())
            {
                case "dac":
                    if(tokens.Length < 2) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "reset":
                            return new DacResetCommand();
                        case "set":
                            if (tokens.Length < 6) throw new ArgumentException(nameof(command));
                            int dac;
                            int dacChannel;
                            if(int.TryParse(tokens[2], out dac) &&
                               int.TryParse(tokens[3], out dacChannel))
                            {
                                float fv;
                                int iv;
                                switch (tokens[4].ToLowerInvariant())
                                {
                                    case "volts":
                                        if (float.TryParse(tokens[4], out fv))
                                        {
                                            return new DacSetVoltCommand(dac, dacChannel, fv);
                                        }
                                        throw new ArgumentException(nameof(command));
                                    case "counts":
                                        iv  = Utility.Utility.ParseIntegerValue(tokens[4]);
                                        return new DacSetCountCommand(dac, dacChannel, iv);
                                        throw new ArgumentException(nameof(command));
                                    default:
                                        throw new ArgumentException(nameof(command));
                                }
                            }
                            throw new ArgumentException(nameof(command));
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "pot":
                    if (tokens.Length < 2) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "reset":
                            return new PotResetCommand();
                        case "set":
                            if (tokens.Length < 3) throw new ArgumentException(nameof(command));
                            float v;
                            if(float.TryParse(tokens[2], out v))
                            {
                                return new PotSetCommand(v);
                            }
                            throw new ArgumentException(nameof(command));
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "serial":
                    if (tokens.Length < 1) throw new ArgumentException(nameof(command));
                    switch (tokens[1].ToLowerInvariant())
                    {
                        case "inject_urc":
                            return new SerialInjectUrcCommand();
                        default:
                            throw new ArgumentException(nameof(command));
                    }
                case "nkc":
                    return new NkcCommand();
                default:
                    throw new ArgumentException(nameof(command));
            }
            throw new NotImplementedException();
        }
    }
}
