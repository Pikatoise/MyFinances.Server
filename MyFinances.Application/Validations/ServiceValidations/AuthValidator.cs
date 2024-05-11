using MyFinances.Domain.Entity;
using MyFinances.Domain.Errors;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class AuthValidator: IAuthValidator
    {
        public BaseResult ValidateNewUserPassword(string? password, string? passwordConfirm)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(passwordConfirm))
                return new BaseResult()
                {
                    Failure = UserErrors.UserRequiredPassword
                };

            if (password.Length < 6)
                return new BaseResult()
                {
                    Failure = UserErrors.UserPasswordTooShort
                };

            if (!password.Equals(passwordConfirm))
                return new BaseResult()
                {
                    Failure = UserErrors.UserPasswordConfirmWrong
                };

            if (!password.Any(char.IsLetter))
                return new BaseResult()
                {
                    Failure = UserErrors.UserPasswordMustContainLetters
                };

            if (!password.Any(char.IsDigit))
                return new BaseResult()
                {
                    Failure = UserErrors.UserPasswordMustContainDigit
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(User? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = UserErrors.UserNotFound
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnUserNotExist(User? user)
        {
            if (user != null)
                return new BaseResult()
                {
                    Failure = UserErrors.UserAlreadyExist
                };

            return new BaseResult();
        }

        public BaseResult ValidatePasswordVerifying(Func<string, string, bool> passwordVerifier, string userPassword, string dtoPassword)
        {
            bool result = passwordVerifier(userPassword, dtoPassword);

            if (!result)
                return new BaseResult()
                {
                    Failure = UserErrors.UserWrongPassword
                };

            return new BaseResult();
        }
    }
}
