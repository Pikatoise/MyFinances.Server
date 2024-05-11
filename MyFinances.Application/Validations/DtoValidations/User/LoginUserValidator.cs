using FluentValidation;
using MyFinances.Domain.DTO.User;
using MyFinances.Domain.Errors;

namespace MyFinances.Application.Validations.DtoValidations.User
{
    public class LoginUserValidator: AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .MinimumLength(4).WithMessage(DtoErrors.DtoTooLowValue.Description).WithErrorCode(DtoErrors.DtoTooLowValue.Code)
                .MaximumLength(20).WithMessage(DtoErrors.DtoTooBigValue.Description).WithErrorCode(DtoErrors.DtoTooBigValue.Code);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code);
        }
    }
}
