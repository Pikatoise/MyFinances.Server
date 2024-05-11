using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class RoleErrors
    {
        public static readonly Error RoleNotFound = Error.NotFound("Role.NotFound", ErrorMessages.Role_NotFound);
        public static readonly Error RoleAlreadyExist = Error.Conflict("Role.AlreadyExist", ErrorMessages.Role_AlreadyExist);
        public static readonly Error UserRoleNotFound = Error.NotFound("UserRole.NotFound", ErrorMessages.UserRole_NotFound);
        public static readonly Error UserRoleAlreadyExist = Error.Conflict("UserRole.AlreadyExist", ErrorMessages.UserRole_AlreadyExist);
    }
}
