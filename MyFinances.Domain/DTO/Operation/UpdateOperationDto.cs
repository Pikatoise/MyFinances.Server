namespace MyFinances.Domain.DTO.Operation
{
    public record UpdateOperationDto(int OperationId, string Title, double Amount, int TypeId);
}
