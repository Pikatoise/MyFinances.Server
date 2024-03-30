namespace MyFinances.Domain.Interfaces.Validations
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type of entity identificator</typeparam>
    public interface IEntityId<T> where T : struct
    {
        /// <summary>
        /// Entity identificator
        /// </summary>
        public T Id { get; set; }
    }
}
