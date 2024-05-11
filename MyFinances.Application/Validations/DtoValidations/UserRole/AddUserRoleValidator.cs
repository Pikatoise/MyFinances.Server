using FluentValidation;
using MyFinances.Domain.DTO.UserRole;
using MyFinances.Domain.Errors;

namespace MyFinances.Application.Validations.DtoValidations.UserRole
{
    public class AddUserRoleValidator: AbstractValidator<AddUserRoleDto>
    {
        public AddUserRoleValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .MinimumLength(4).WithMessage(DtoErrors.DtoTooLowValue.Description).WithErrorCode(DtoErrors.DtoTooLowValue.Code)
                .MaximumLength(20).WithMessage(DtoErrors.DtoTooBigValue.Description).WithErrorCode(DtoErrors.DtoTooBigValue.Code);

            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .MinimumLength(4).WithMessage(DtoErrors.DtoTooLowValue.Description).WithErrorCode(DtoErrors.DtoTooLowValue.Code)
                .MaximumLength(20).WithMessage(DtoErrors.DtoTooBigValue.Description).WithErrorCode(DtoErrors.DtoTooBigValue.Code);
        }
    }
}
