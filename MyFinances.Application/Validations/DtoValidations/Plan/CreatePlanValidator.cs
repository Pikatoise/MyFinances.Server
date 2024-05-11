using FluentValidation;
using MyFinances.Domain.DTO.Plan;
using MyFinances.Domain.Errors;

namespace MyFinances.Application.Validations.DtoValidations.Plan
{
    public class CreatePlanValidator: AbstractValidator<CreatePlanDto>
    {
        public CreatePlanValidator()
        {
            RuleFor(x => x.FinalDate)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .MaximumLength(50).WithMessage(DtoErrors.DtoTooBigValue.Description).WithErrorCode(DtoErrors.DtoTooBigValue.Code);

            RuleFor(x => x.Amount)
                .NotNull().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .ExclusiveBetween(-999_999, 999_999).WithMessage(DtoErrors.DtoOutOfRange.Description).WithErrorCode(DtoErrors.DtoOutOfRange.Code);

            RuleFor(x => x.TypeId)
                .NotNull().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code);

            RuleFor(x => x.UserId)
                .NotNull().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code);
        }
    }
}
