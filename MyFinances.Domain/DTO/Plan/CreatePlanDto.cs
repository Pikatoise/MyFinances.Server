namespace MyFinances.Domain.DTO.Plan
{
    public record CreatePlanDto(int UserId, string Name, string FinalDate, double Amount, int TypeId);
}
