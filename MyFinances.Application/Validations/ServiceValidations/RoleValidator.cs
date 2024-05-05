using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class RoleValidator: IRoleValidator
    {
        public BaseResult ValidateOnNull(Role? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("Role.NotFound", ErrorMessages.Role_NotFound)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNotNull(Role? model)
        {
            if (model != null)
                return new BaseResult()
                {
                    Failure = Error.Conflict("Role.AlreadyExist", ErrorMessages.Role_AlreadyExist)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnUserRoleExist(User? user, string roleName)
        {
            if (user == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("User.NotFound", ErrorMessages.User_NotFound)
                };

            if (!user.Roles.Any(x => x.Name.Equals(roleName)))
                return new BaseResult()
                {
                    Failure = Error.NotFound("UserRole.NotFound", ErrorMessages.UserRole_NotFound)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnUserRoleNotExist(User? user, string roleName)
        {
            if (user == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("User.NotFound", ErrorMessages.User_NotFound)
                };

            if (user.Roles.Any(x => x.Name.Equals(roleName)))
                return new BaseResult()
                {
                    Failure = Error.NotFound("UserRole.AlreadyExist", ErrorMessages.UserRole_AlreadyExist)
                };

            return new BaseResult();
        }
    }
}
