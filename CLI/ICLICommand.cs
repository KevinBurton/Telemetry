namespace CLI
{
    public interface ICLICommand
    {
        public ICLICommandResult Do(ICLIConnection connection);
    }
}
