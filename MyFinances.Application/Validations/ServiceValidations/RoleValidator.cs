using MyFinances.Domain.Entity;
using MyFinances.Domain.Errors;
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
                    Failure = RoleErrors.RoleNotFound
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNotNull(Role? model)
        {
            if (model != null)
                return new BaseResult()
                {
                    Failure = RoleErrors.RoleAlreadyExist
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
                    Failure = RoleErrors.UserRoleNotFound
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
                    Failure = RoleErrors.UserRoleAlreadyExist
                };

            return new BaseResult();
        }
    }
}
