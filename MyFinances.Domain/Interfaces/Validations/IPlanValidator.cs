using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    public interface IPlanValidator: IBaseValidator<Plan>
    {
        /// <summary>
        /// Check is user and type for new plan exists
        /// </summary>
        /// <param name="user">Owner of new plan</param>
        /// <param name="type">Type of new plan</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateOnUserAndTypeExist(User? user, OperationType? type);
    }
}
