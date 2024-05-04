using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    public interface IRoleValidator: IBaseValidator<Role>
    {
        /// <summary>
        /// Check is userRole exist
        /// </summary>
        /// <param name="userRole">Entity to validate</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateOnUserRoleExist(UserRole? userRole);

        /// <summary>
        /// Check is userRole not exist
        /// </summary>
        /// <param name="userRole">Entity to validate</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateOnUserRoleNotExist(UserRole? userRole);
    }
}
