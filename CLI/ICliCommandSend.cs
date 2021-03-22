using CLI.Args;

namespace CLI
{
    public interface ICliCommandSend
    {
        public void Send(string commandName, ICLICommandArgs args);
        public string Receive();

    }
}
