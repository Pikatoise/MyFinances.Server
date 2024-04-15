using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    /// <summary>
    /// Collection of validators for operation service
    /// </summary>
    public interface IOperationValidator: IBaseValidator<Operation>
    {
        /// <summary>
        /// Check is period and type exists
        /// </summary>
        /// <param name="operationPeriod">Period of operation</param>
        /// <param name="operationType">Type of operation</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult CreateValidator(Period operationPeriod, OperationType operationType);

        /// <summary>
        /// Check is operation and type exists
        /// </summary>
        /// <param name="operation">Updated operation</param>
        /// <param name="operationType">Type of operation</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult UpdateValidator(Operation operation, OperationType operationType);
    }
}
