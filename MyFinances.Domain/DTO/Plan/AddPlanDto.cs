namespace MyFinances.Domain.DTO.Plan
{
    public record AddPlanDto(int UserId, string Name, string FinalDate, int TypeId);
}
