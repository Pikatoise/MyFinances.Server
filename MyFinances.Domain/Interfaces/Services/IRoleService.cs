using MyFinances.Domain.DTO.Role;
using MyFinances.Domain.DTO.UserRole;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Service for role controle
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Create new role
        /// </summary>
        /// <param name="roleName">Name for new role</param>
        /// <returns><c>RoleDto</c>: data of new role</returns>
        Task<BaseResult<RoleDto>> CreateRoleAsync(string roleName);

        /// <summary>
        /// Remove role
        /// </summary>
        /// <param name="id">Role identificator</param>
        /// <returns><c>RoleDto</c>: data of deleted role</returns>
        Task<BaseResult<RoleDto>> DeleteRoleAsync(long id);

        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="dto">Data for updating</param>
        /// <returns><c>RoleDto</c>: data of updated role</returns>
        Task<BaseResult<RoleDto>> UpdateRoleAsync(RoleDto dto);

        /// <summary>
        /// Add role to user
        /// </summary>
        /// <param name="dto">Data for adding role to user</param> 
        /// <returns><c>UserRoleDto</c>: data of user with new role</returns>
        Task<BaseResult<UserRoleDto>> SetRoleToUserAsync(AddUserRoleDto dto);

        /// <summary>
        /// Remove role from user
        /// </summary>
        /// <param name="dto">Data for removing role from user</param>
        /// <returns><c>UserRoleDto</c>: data of user without role</returns>
        Task<BaseResult<UserRoleDto>> RemoveUserRole(RemoveUserRoleDto dto);
    }
}
