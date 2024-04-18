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
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField)
                .MaximumLength(50).WithMessage(ErrorMessages.Dto_TooBigValue);

            RuleFor(x => x.TypeId)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField);

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField);
        }
    }
}
