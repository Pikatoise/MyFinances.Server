using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    /// <summary>
    /// Base interface with common validators
    /// </summary>
    /// <typeparam name="T">Domain entity, for which the validator is</typeparam>
    public interface IBaseValidator<in T> where T : class
    {
        /// <summary>
        /// Check the <typeparamref name="T"/> is empty
        /// </summary>
        /// <param name="model">Entity</param>
        /// <returns></returns>
        BaseResult ValidateOnNull(T? model);
    }
}
