namespace CLI
{
    public interface ICLICommandResult
    {
        string[] Result { get; }
        bool IsSuccess { get; }
    }
}
