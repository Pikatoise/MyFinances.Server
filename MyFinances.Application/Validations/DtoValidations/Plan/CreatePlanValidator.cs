using FluentValidation;
using MyFinances.Application.Resources;
using MyFinances.Domain.DTO.Plan;

namespace MyFinances.Application.Validations.DtoValidations.Plan
{
    public class CreatePlanValidator: AbstractValidator<CreatePlanDto>
    {
        public CreatePlanValidator()
        {
            RuleFor(x => x.FinalDate)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField")
                .MaximumLength(50).WithMessage(ErrorMessages.Dto_TooBigValue).WithErrorCode("Dto.TooBigValue");

            RuleFor(x => x.Amount)
                .NotNull().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField")
                .ExclusiveBetween(-999_999, 999_999).WithMessage(ErrorMessages.Dto_OutOfRange).WithErrorCode("Dto.IncorrectValue");

            RuleFor(x => x.TypeId)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField");
        }
    }
}
