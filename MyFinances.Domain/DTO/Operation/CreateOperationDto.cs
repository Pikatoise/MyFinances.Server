namespace MyFinances.Domain.DTO.Operation
{
    public record CreateOperationDto(int PeriodId, string Title, double Amount, int TypeId);
}
