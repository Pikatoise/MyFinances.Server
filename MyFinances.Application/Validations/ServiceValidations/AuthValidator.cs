using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
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
                    Failure = Error.Validation("User.RequiredPassword", ErrorMessages.User_RequiredPassword)
                };

            if (password.Length < 6)
                return new BaseResult()
                {
                    Failure = Error.Validation("User.PasswordTooShort", ErrorMessages.User_PasswordTooShort)
                };

            if (!password.Equals(passwordConfirm))
                return new BaseResult()
                {
                    Failure = Error.Validation("User.WrongPasswordConfirm", ErrorMessages.User_WrongPassword)
                };

            if (!password.Any(char.IsLetter))
                return new BaseResult()
                {
                    Failure = Error.Validation("User.PasswordMustContainLetters", ErrorMessages.User_PasswordMustContainLetters)
                };

            if (!password.Any(char.IsDigit))
                return new BaseResult()
                {
                    Failure = Error.Validation("User.PasswordMustContainDigit", ErrorMessages.User_PasswordMustContainDigit)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(User? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("User.NotFound", ErrorMessages.User_NotFound)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnUserNotExist(User? user)
        {
            if (user != null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("User.AlreadyExist", ErrorMessages.User_AlreadyExist)
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
