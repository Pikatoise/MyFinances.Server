using FluentValidation;
using MyFinances.Domain.DTO.Operation;
using MyFinances.Domain.Errors;

namespace MyFinances.Application.Validations.DtoValidations.Operation
{
    public class UpdateOperationValidator: AbstractValidator<UpdateOperationDto>
    {
        public UpdateOperationValidator()
        {
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .InclusiveBetween(-999_999, 999_999).WithMessage(DtoErrors.DtoOutOfRange.Description).WithErrorCode(DtoErrors.DtoOutOfRange.Code);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code)
                .MaximumLength(50).WithMessage(DtoErrors.DtoTooBigValue.Description).WithErrorCode(DtoErrors.DtoTooBigValue.Code);

            RuleFor(x => x.TypeId)
                .NotNull().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code);

            RuleFor(x => x.OperationId)
                .NotNull().WithMessage(DtoErrors.DtoEmptyField.Description).WithErrorCode(DtoErrors.DtoEmptyField.Code);
        }
    }
}
