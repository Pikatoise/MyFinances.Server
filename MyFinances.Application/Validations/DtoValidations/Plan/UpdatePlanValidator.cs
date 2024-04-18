using FluentValidation;
using MyFinances.Application.Resources;
using MyFinances.Domain.DTO.Plan;

namespace MyFinances.Application.Validations.DtoValidations.Plan
{
    public class UpdatePlanValidator: AbstractValidator<UpdatePlanDto>
    {
        public UpdatePlanValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField")
                .MaximumLength(50).WithMessage(ErrorMessages.Dto_TooBigValue).WithErrorCode("Dto.TooBigValue");

            RuleFor(x => x.TypeId)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField");

            RuleFor(x => x.PlanId)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField");
        }
    }
}
