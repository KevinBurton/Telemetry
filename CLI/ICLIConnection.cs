namespace CLI
{
    public interface ICLIConnection
    {
        public string Read();
        public void Send(string values);
    }
}
