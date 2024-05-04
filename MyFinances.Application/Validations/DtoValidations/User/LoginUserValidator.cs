using FluentValidation;
using MyFinances.Application.Resources;
using MyFinances.Domain.DTO.User;

namespace MyFinances.Application.Validations.DtoValidations.User
{
    public class LoginUserValidator: AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField")
                .MinimumLength(4).WithMessage(ErrorMessages.Dto_TooLowValue).WithErrorCode("Dto.TooLowValue")
                .MaximumLength(20).WithMessage(ErrorMessages.Dto_TooBigValue).WithErrorCode("Dto.TooBigValue");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField");
        }
    }
}
