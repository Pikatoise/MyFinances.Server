namespace MyFinances.Domain.Result
{
    /// <summary>
    /// HTTP response
    /// </summary>
    public class BaseResult
    {
        public bool IsSuccess => Failure == null;

        public Error? Failure { get; set; }
    }

    /// <summary>
    /// HTTP response with data
    /// </summary>
    /// <typeparam name="T">response data type</typeparam>
    public class BaseResult<T>: BaseResult
    {
        public BaseResult(Error failure, T data)
        {
            Failure = failure;
            Data = data;
        }

        public BaseResult() { }

        public T? Data { get; set; }
    }
}
