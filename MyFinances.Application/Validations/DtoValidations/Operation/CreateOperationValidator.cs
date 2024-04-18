using FluentValidation;
using MyFinances.Application.Resources;
using MyFinances.Domain.DTO.Operation;
namespace MyFinances.Application.Validations.DtoValidations.Operation
{
    public class CreateOperationValidator: AbstractValidator<CreateOperationDto>
    {
        public CreateOperationValidator()
        {
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField")
                .InclusiveBetween(-999_999, 999_999).WithMessage(ErrorMessages.Dto_IncorrectValue).WithErrorCode("Dto.IncorrectValue");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField")
                .MaximumLength(50).WithMessage(ErrorMessages.Dto_TooBigValue).WithErrorCode("Dto.TooBigValue");

            RuleFor(x => x.TypeId)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField");

            RuleFor(x => x.PeriodId)
                .NotEmpty().WithMessage(ErrorMessages.Dto_EmptyField).WithErrorCode("Dto.EmptyField");
        }
    }
}
