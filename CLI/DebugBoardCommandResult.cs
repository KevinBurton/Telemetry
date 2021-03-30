namespace CLI
{
    public class DebugBoardCommandResult : ICLICommandResult
    {
        public DebugBoardCommandResult(string[] result)
        {
            Result = result;
        }
        public string[] Result { get; }
        public bool IsSuccess => Result != null && Result.Length > 0 && Result[Result.Length - 1][0] == '.';
    }
}
