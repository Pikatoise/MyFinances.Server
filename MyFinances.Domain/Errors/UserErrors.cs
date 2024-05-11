using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class UserErrors
    {
        public static readonly Error UserNotFound = Error.NotFound("User.NotFound", ErrorMessages.User_NotFound);

        public static readonly Error UserAlreadyExist = Error.Conflict("User.AlreadyExist", ErrorMessages.User_AlreadyExist);

        public static readonly Error UserWrongPassword = Error.Validation("User.WrongPassword", ErrorMessages.User_WrongPassword);

        public static readonly Error UserRequiredPassword = Error.Validation("User.RequiredPassword", ErrorMessages.User_RequiredPassword);

        public static readonly Error UserPasswordTooShort = Error.Validation("User.PasswordTooShort", ErrorMessages.User_PasswordTooShort);

        public static readonly Error UserPasswordConfirmWrong = Error.Validation("User.WrongPasswordConfirm", ErrorMessages.User_WrongPassword);

        public static readonly Error UserPasswordMustContainLetters = Error.Validation("User.PasswordMustContainLetters", ErrorMessages.User_PasswordMustContainLetters);

        public static readonly Error UserPasswordMustContainDigit = Error.Validation("User.PasswordMustContainDigit", ErrorMessages.User_PasswordMustContainDigit);

    }
}
