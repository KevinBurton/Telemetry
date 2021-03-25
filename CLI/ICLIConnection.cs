namespace CLI
{
    public interface ICLIConnection
    {
        public ICLICommandResult Read();
        public void Send(string values);
    }
}
