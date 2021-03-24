namespace CLI
{
    internal interface ICLI
    {
        ICLICommandResult Command(ICLICommand command);
    }
}