using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    public interface IRoleValidator: IBaseValidator<Role>
    {
        /// <summary>
        /// Check is user and his userRole exist
        /// </summary>
        /// <param name="user">User, owner of role</param>
        /// <param name="roleId">Identificator of role</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateOnUserRoleExist(User? user, string roleName);

        /// <summary>
        /// Check is userRole not exist
        /// </summary>
        /// <param name="user">User with roles for check</param>
        /// <param name="roleName">Name of role, which user should not have</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateOnUserRoleNotExist(User? user, string roleName);

        /// <summary>
        /// Check is role already exist
        /// </summary>
        /// <param name="model">Role to check</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateOnNotNull(Role? model);
    }
}
