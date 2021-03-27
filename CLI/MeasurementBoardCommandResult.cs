namespace CLI
{
    public class MeasurementBoardCommandResult : ICLICommandResult
    {
        public MeasurementBoardCommandResult(string[] result)
        {
            Result = result;
        }
        public string[] Result { get; }
        public bool IsSuccess => Result != null && Result.Length > 0 && Result[0][0] == '.';
    }
}
