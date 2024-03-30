namespace MyFinances.Domain.Result
{
    /// <summary>
    /// HTTP response
    /// </summary>
    public class BaseResult
    {
        public bool IsSuccess => ErrorMessage == null;

        public string? ErrorMessage { get; set; }

        public int? ErrorCode { get; set; }
    }

    /// <summary>
    /// HTTP response with data
    /// </summary>
    /// <typeparam name="T">response data type</typeparam>
    public class BaseResult<T>: BaseResult
    {
        public BaseResult(string errorMessage, int errorCode, T data)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
            Data = data;
        }

        public BaseResult() { }

        public T? Data { get; set; }
    }
}
