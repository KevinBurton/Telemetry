namespace CLI
{
    internal interface ICLI
    {
        public void Open(string port);
        public void Close();
        public void Send(ICliCommandSend command);
        public ICLICommandReceive Receive();
    }
}