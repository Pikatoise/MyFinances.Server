using FluentValidation;
using MyFinances.Domain.DTO.Operation;
using MyFinances.Domain.Errors;
namespace MyFinances.Application.Validations.DtoValidations.Operation
{
    public class CreateOperationValidator: AbstractValidator<CreateOperationDto>
    {
        public CreateOperationValidator()
        {
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .InclusiveBetween(-999_999, 999_999).WithMessage(DtoErrors.DtoOutOfRange.Description).WithErrorCode(DtoErrors.DtoOutOfRange.Code);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .MaximumLength(50).WithMessage(DtoErrors.DtoTooBigValue.Description).WithErrorCode(DtoErrors.DtoTooBigValue.Code);

            RuleFor(x => x.TypeId)
                .NotNull().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code);

            RuleFor(x => x.PeriodId)
                .NotNull().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code);
        }
    }
}
