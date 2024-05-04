using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class AuthValidator: IAuthValidator
    {
        public BaseResult ValidateOnNull(User? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("User.NotFound", ErrorMessages.User_NotFound)
                };

            return new BaseResult();
        }

        public BaseResult ValidatePasswordVerifying(Func<string, string, bool> passwordVerifier, string userPassword, string dtoPassword)
        {
            bool result = passwordVerifier(userPassword, dtoPassword);

            if (!result)
                return new BaseResult()
                {
                    Failure = Error.Validation("User.WrongPassword", ErrorMessages.User_WrongPassword)
                };

            return new BaseResult();
        }
    }
}
