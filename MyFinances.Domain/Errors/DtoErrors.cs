using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class DtoErrors
    {
        public static readonly Error DtoEmptyField = Error.Validation("Dto.EmptyField", ErrorMessages.Dto_EmptyField);

        public static readonly Error DtoIncorrectValue = Error.Validation("Dto.IncorrectValue", ErrorMessages.Dto_IncorrectValue);

        public static readonly Error DtoOutOfRange = Error.Validation("Dto.OutOfRange", ErrorMessages.Dto_OutOfRange);

        public static readonly Error DtoTooBigValue = Error.Validation("Dto.TooBigValue", ErrorMessages.Dto_TooBigValue);

        public static readonly Error DtoTooLowValue = Error.Validation("Dto.TooLowValue", ErrorMessages.Dto_TooLowValue);
    }
}
