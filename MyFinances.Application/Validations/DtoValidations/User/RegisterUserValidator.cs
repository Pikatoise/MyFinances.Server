using FluentValidation;
using MyFinances.Domain.DTO.User;
using MyFinances.Domain.Errors;

namespace MyFinances.Application.Validations.DtoValidations.User
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .MinimumLength(4).WithMessage(DtoErrors.DtoTooLowValue.Description).WithErrorCode(DtoErrors.DtoTooLowValue.Code)
                .MaximumLength(20).WithMessage(DtoErrors.DtoTooBigValue.Description).WithErrorCode(DtoErrors.DtoTooBigValue.Code);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .MinimumLength(6).WithMessage(DtoErrors.DtoTooLowValue.Description).WithErrorCode(DtoErrors.DtoTooLowValue.Code)
                .MaximumLength(30).WithMessage(DtoErrors.DtoTooBigValue.Description).WithErrorCode(DtoErrors.DtoTooBigValue.Code);

            RuleFor(x => x.PasswordConfirm)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .MinimumLength(6).WithMessage(DtoErrors.DtoTooLowValue.Description).WithErrorCode(DtoErrors.DtoTooLowValue.Code)
                .MaximumLength(30).WithMessage(DtoErrors.DtoTooBigValue.Description).WithErrorCode(DtoErrors.DtoTooBigValue.Code);
        }
    }
}
