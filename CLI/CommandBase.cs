using CLI.Args;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CLI
{
    public abstract class CommandBase : ICliCommandSend
    {
        protected abstract MethodInfo[] Methods { get; set; }

        public CommandBase()
        {

        }
        public void Send(string commandName, ICLICommandArgs args = null)
        {
            if (string.IsNullOrWhiteSpace(commandName)) return;
            var commandSubcommandRegex = new Regex(@"([A-Za-z0-9]+) ([A-Za-z0-9]+)");
            var match = commandSubcommandRegex.Match(commandName);
            if (match.Success)
            {
                // There is a space
                var command = match.Groups[1].Value;
                var subCommand = match.Groups[2].Value;
                if (!Methods.Any(m => string.Compare(m.Name, command + subCommand, true) == 0))
                {
                    throw new ArgumentException($"{commandName} not found");
                }
                Methods.Single(m => string.Compare(m.Name, command + subCommand, true) == 0).Invoke(this, new object[] { args });
            }
            else
            {
                if (!Methods.Any(m => string.Compare(m.Name, commandName, true) == 0))
                {
                    throw new ArgumentException($"{commandName} not found");
                }
                Methods.Single(m => string.Compare(m.Name, commandName, true) == 0).Invoke(this, new object[] { args });
            }
        }
        public string Receive()
        {
            throw new NotImplementedException();
        }
    }
}
