namespace MyFinances.Domain.Result
{
    /// <summary>
    /// HTTP response with collection of data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionResult<T>: BaseResult<IEnumerable<T>>
    {
        public int Count { get; set; }
    }
}
