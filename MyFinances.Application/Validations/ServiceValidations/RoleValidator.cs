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

        public BaseResult ValidateOnUserRoleExist(UserRole? userRole)
        {
            if (userRole == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("UserRole.NotFound", ErrorMessages.UserRole_NotFound)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnUserRoleNotExist(UserRole? userRole)
        {
            if (userRole != null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("UserRole.AlreadyExist", ErrorMessages.UserRole_AlreadyExist)
                };

            return new BaseResult();
        }
    }
}
