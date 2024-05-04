using FluentValidation;
using MyFinances.Application.Resources;
using MyFinances.Domain.DTO.UserRole;

namespace MyFinances.Application.Validations.DtoValidations.UserRole
{
    public class AddUserRoleValidator: AbstractValidator<AddUserRoleDto>
    {
        public AddUserRoleValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField")
                .MinimumLength(4).WithMessage(ErrorMessages.Dto_TooLowValue).WithErrorCode("Dto.TooLowValue")
                .MaximumLength(20).WithMessage(ErrorMessages.Dto_TooBigValue).WithErrorCode("Dto.TooBigValue");

            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField")
                .MinimumLength(4).WithMessage(ErrorMessages.Dto_TooLowValue).WithErrorCode("Dto.TooLowValue")
                .MaximumLength(20).WithMessage(ErrorMessages.Dto_TooBigValue).WithErrorCode("Dto.TooBigValue");
        }
    }
}
