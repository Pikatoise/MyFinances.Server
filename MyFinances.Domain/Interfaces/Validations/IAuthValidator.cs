using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    public interface IAuthValidator: IBaseValidator<User>
    {
        /// <summary>
        /// Check is password verified
        /// </summary>
        /// <param name="passwordVerifier">Func that verify password and return result</param>
        /// <param name="userPassword">Right user passoword</param>
        /// <param name="dtoPassword">Received password from request</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidatePasswordVerifying(Func<string, string, bool> passwordVerifier, string userPassword, string dtoPassword);

        /// <summary>
        /// Complex password verification
        /// </summary>
        /// <param name="password">New password</param>
        /// <param name="passwordConfirm">Copy of new password</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateNewUserPassword(string? password, string? passwordConfirm);

        /// <summary>
        /// Check is user with same login not already exist
        /// </summary>
        /// <param name="user">User with same login</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateOnUserNotExist(User? user);
    }
}
